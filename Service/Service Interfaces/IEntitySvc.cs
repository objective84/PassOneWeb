using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;
using PassOne.Service;

namespace PassOne.Service
{
    public interface IEntitySvc : IService
    {

        Credentials RetreiveById(int id);
        void Create(Credentials creds);
        void Delete(Credentials creds);
        int GetNextIdValue();
        Credentials ConvertToDomainObject(CredentialsEntity entity);
        CredentialsEntity ConvertToEntity(Credentials creds);
    }
}
