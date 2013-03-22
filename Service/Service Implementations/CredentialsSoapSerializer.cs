﻿using System;
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

        private readonly User _myUser;

        public User MyUser
        {
            get { return _myUser; }
        }

        //Contructor
        public CredentialsSoapSerializer(User user)
        {
            _myUser = user;
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
                var value = RetrieveTable()[id] as Credentials;
                value.Decrypt(_myUser.Encryption);
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
            Credentials credentials = null;
            try
            {
                credentials = (Credentials) obj;
                credentials.Encrypt(_myUser.Encryption);
                var credsTable = RetrieveTable();
                if (credsTable.ContainsKey(credentials.Id))
                    credsTable[credentials.Id] = credentials;
                else
                    credsTable.Add(credentials.Id, credentials);
                Store(credsTable);
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Object is not a Credentials");
            }
        }
    }
}