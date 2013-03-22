﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PassOne.Service;
using PassOne.Domain;

namespace PassOne.Business
{
    public class CredentialsManager : ManagerBase
    {
        //Constructors
        public CredentialsManager()
            : base(Services.CredentialsSoapSerializer)
        {
        }

        /// <summary>
        /// Method to create a new credentials entry and save it to the data.bin file
        /// </summary>
        /// <param name="user">The user these credentials are saved on</param>
        /// <param name="creds">Credentials to be created</param>
        /// <param name="path">The location of the data.bin file</param>
        /// <returns>the Id of the credentials just created</returns>
        public int CreateCredentials(User user, Credentials creds, string path)
        {
            var credsSvc = GetService(Services.CredentialsSoapSerializer, path, user) as ISerializeSvc;
            creds.Id = credsSvc.GetNextIdValue();
            if (!user.CredentialsList.ContainsKey(creds.Website))
                user.CredentialsList.Add(creds.Website, creds.Id);
            credsSvc.UpdateTable(creds);
            (GetService(Services.UserSoapSerializer, path) as UserSoapSerializer).UpdateTable(user);
            return creds.Id;
        }

        /// <summary>
        /// Method for updating the contents of a saved set of credentials
        /// </summary>
        /// <param name="user">The user whose list contains the credentials in question</param>
        /// <param name="creds">The credentials to be updated</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        public void UpdateCredentials(User user, Credentials creds, string path)
        {
            try
            {
                GetService(path, user).UpdateTable(creds);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }

        /// <summary>
        /// Method for retrieving a specific set of credentials
        /// </summary>
        /// <param name="user">The user whose list contains the credentials in question</param>
        /// <param name="id">The Id of the credentials to be retrieved</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <returns>The requested credentials, if found; if not, returns null</returns>
        public Credentials FindCredentials(User user, int id, string path)
        {
            try
            {
                var creds =
                    ((CredentialsSoapSerializer) GetService(Services.CredentialsSoapSerializer, path, user))
                        .RetreiveById(id) as Credentials;
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
        /// <param name="user">The user whose list contains the credentials in question</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        public void DeleteCredentials(Credentials creds, User user, string path)
        {
            try
            {
                creds.Encrypt(user.Encryption);
                GetService(path, user).DeleteValue(creds);
                user.CredentialsList.Remove(creds.Id);
            }
            catch (CryptographicException)
            {
                throw new EncryptionException();
            }
        }
    }
}