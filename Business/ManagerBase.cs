using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;
using PassOne.Service;
using PassOne.Service.Factories;

namespace PassOne.Business
{
    public abstract class ManagerBase
    {
        protected Factory Factory;
        private Services _service;

        protected ManagerBase(Services service)
        {
            Factory = new EntityFactory();
            _service = service;
        }
        /// <summary>
        /// Method for retreiving a given service from the Service Layer
        /// </summary>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <param name="passOneUser">Optional parameter - required for credentials services</param>
        /// <returns>The requested service</returns>
        protected IEntitySvc GetService(string path, PassOneUser passOneUser = null)
        {
            return (IEntitySvc)Factory.GetEntityService(_service);
        }
        /// <summary>
        /// Method for retreiving a given service from the Service Layer, used only if the requested service is of another type.
        /// </summary>
        /// <param name="service">Enum - defines the specific service to be retrived</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <param name="passOneUser">Optional parameter - required for credentials services</param>
        /// <returns></returns>
        protected IEntitySvc GetService(Services service)
        {
            return (IEntitySvc)Factory.GetEntityService(service);
        }

        public Dictionary<string, int> GetCredentialsList(PassOneUser passOneUser)
        {
            Dictionary<string, int> list;
            using (var db = new PassOneContext())
            {
                db.Database.Connection.Open();
                var query = from c in db.Credentials select c;
                list = query.ToList().Where(credential => credential.UserId == passOneUser.Id).ToDictionary(credential => credential.Title, credential => credential.Id);
            }
            return list;
        }
    }
}

