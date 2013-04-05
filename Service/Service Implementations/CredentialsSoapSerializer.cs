using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using PassOne.Domain;
using PassOne.Domain.Exceptions;

namespace PassOne.Service
{
    internal class CredentialsSoapSerializer : SoapSerializerBaseImpl
    {
        public override string FileName
        {
            get { return DirectoryPath + "data\\data.bin"; }
        }

        private readonly PassOneUser _myPassOneUser;

        public PassOneUser MyPassOneUser
        {
            get { return _myPassOneUser; }
        }

        //Contructor
        public CredentialsSoapSerializer(PassOneUser passOneUser)
        {
            _myPassOneUser = passOneUser;
        }

        /// <summary>
        /// Method overides parent method due to the fact that credentials must be decrypted before they can be compared.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override object RetreiveById(int id)
        {
            try
            {
                var value = RetrieveTable()[id] as PassOneCredentials;
                value.Decrypt(_myPassOneUser.Encryption);
                return value;
            }
            catch (NullReferenceException)
            {
                throw new CredentialsNotFoundException(id);
            }
            
        }

        /// <summary>
        /// Method to update a credentials entry into the data.bin file.
        /// </summary>
        /// <param name="obj">Credential to be stored</param>
        public override void UpdateTable(object obj)
        {
            PassOneCredentials passOneCredentials = null;
            try
            {
                passOneCredentials = (PassOneCredentials) obj;
                passOneCredentials.Encrypt(_myPassOneUser.Encryption);
                var credsTable = RetrieveTable();
                if (credsTable.ContainsKey(passOneCredentials.Id))
                    credsTable[passOneCredentials.Id] = passOneCredentials;
                else
                    credsTable.Add(passOneCredentials.Id, passOneCredentials);
                Store(credsTable);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Object is not a Credentials");
            }
        }
    }
}
