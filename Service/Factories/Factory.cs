using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using PassOne.Domain;
using PassOne.Service;

namespace PassOne.Service
{
    public enum Services
    {
        CredentialsSoapSerializer,
        UserSoapSerializer,
        UserAuthenticator
    }

    public abstract class Factory
    {

        public abstract IService GetService(Services serviceName, string path, User user = null);

        /// <summary>
        /// Method to get the service class location from the app.config file.
        /// </summary>
        /// <param name="servicename">string representing the service being created.</param>
        /// <returns>The location of the service class from app.config file</returns>
        protected string GetImplName(string servicename)
        {
            var settings =
                ConfigurationManager.AppSettings;
            return settings.Get(servicename);
        }
    }
}

