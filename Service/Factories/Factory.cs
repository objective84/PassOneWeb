using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using PassOne.Domain;
using PassOne.Service;

namespace PassOne.Service
{
    public enum Services
    {
        CredentialsSoapSerializer,
        UserSoapSerializer,
        UserAuthenticator,
        EntityUserImplementation,
        EntityCredentialsImplementation
    }

    public abstract class Factory
    {

        public virtual IService GetEntityService(Services serviceName)
        {
            return null;
        }
        public virtual IService GetSoapService(Services serviceName, string path, User user = null)
        {
            return null;
        }

        /// <summary>
        /// Method to get the service class location from the app.config file.
        /// </summary>
        /// <param name="servicename">string representing the service being created.</param>
        /// <returns>The location of the service class from app.config file</returns>
        protected string GetImplName(string servicename)
        {
            var settings =
                WebConfigurationManager.AppSettings;
            var name = settings.Get(servicename);
            return name;
        }
    }
}

