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
        PassOneObject RetreiveById(int id);
        void Create(PassOneObject obj);
        void Delete(PassOneObject obj);
        int GetNextIdValue();
    }
}
