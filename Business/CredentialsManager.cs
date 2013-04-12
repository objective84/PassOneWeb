using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PassOne.Domain.Exceptions;
using PassOne.Service;
using PassOne.Domain;

namespace PassOne.Business
{
    public class CredentialsManager : ManagerBase
    {
        //Constructors
        public CredentialsManager()
            : base(Services.EntityCredentialsImplementation)
        {
        }

        /// <summary>
        /// Method to create a new credentials entry and save it to the data.bin file
        /// </summary>
        /// <param name="passOneUser">The user these credentials are saved on</param>
        /// <param name="creds">Credentials to be created</param>
        /// <param name="path">The location of the data.bin file</param>
        /// <returns>the Id of the credentials just created</returns>
        public int CreateCredentials(PassOneUser passOneUser, PassOneCredentials creds)
        {
            if (GetCredentialsList(passOneUser).ContainsKey(creds.Website))
                throw new TitleAlreadyExistsException();

            var credsSvc = GetService(Services.EntityCredentialsImplementation);
            creds.Id = credsSvc.GetNextIdValue();
            creds.UserId = passOneUser.Id;
            credsSvc.Create(creds);
            return creds.Id;
        }

        /// <summary>
        /// Method for updating the contents of a saved set of credentials
        /// </summary>
        /// <param name="passOneUser">The user whose list contains the credentials in question</param>
        /// <param name="creds">The credentials to be updated</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        public void UpdateCredentials(PassOneUser passOneUser, PassOneCredentials creds)
        {
            var list = GetCredentialsList(passOneUser);
            if (list.ContainsKey(creds.Website) && FindCredentials(passOneUser, (list[creds.Website])).Id != creds.Id) 
                throw new TitleAlreadyExistsException();
            try
            {
                GetService(Services.EntityCredentialsImplementation).Edit(creds);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }

        /// <summary>
        /// Method for retrieving a specific set of credentials
        /// </summary>
        /// <param name="passOneUser">The user whose list contains the credentials in question</param>
        /// <param name="id">The Id of the credentials to be retrieved</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <returns>The requested credentials, if found; if not, returns null</returns>
        public PassOneCredentials FindCredentials(PassOneUser passOneUser, int id)
        {
            try
            {
                var creds =
                    ((EntityCredentialsImplementation) GetService(Services.EntityCredentialsImplementation))
                        .RetreiveById(id) as PassOneCredentials;
                return creds;
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }
        /// <summary>
        /// Method for deleting a credentials entry
        /// </summary>
        /// <param name="creds">The credentials to be deleted</param>
        /// <param name="passOneUser">The user whose list contains the credentials in question</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        public void DeleteCredentials(PassOneCredentials creds, PassOneUser passOneUser)
        {
            try
            {
                //creds.Encrypt(user.Encryption);
                GetService(Services.EntityCredentialsImplementation).Delete(creds);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }
    }
}
