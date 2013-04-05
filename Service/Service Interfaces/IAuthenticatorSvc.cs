using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain;

namespace PassOne.Service
{
   public interface IAuthenticatorSvc
   {
       PassOneUser Authenticate(string username, string password);
   }
}
