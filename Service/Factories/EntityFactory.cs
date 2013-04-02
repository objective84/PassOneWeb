using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PassOne.Domain;

namespace PassOne.Service.Factories
{
    public class EntityFactory : Factory
    {
        public override IService GetEntityService(Services serviceName)
        {
            var obj = new object();
            var type = Type.GetType(GetImplName(serviceName.ToString()));
            if (type != null) obj = Activator.CreateInstance(type);

            return (IService) obj;
        }
    }
}