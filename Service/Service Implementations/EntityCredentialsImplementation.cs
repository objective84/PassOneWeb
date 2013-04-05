using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PassOne.Domain;

namespace PassOne.Service
{
    public class EntityCredentialsImplementation : IEntitySvc
    {
        public PassOneObject RetreiveById(int id)
        {
            var context = new PassOneContext();
            var query = from u in context.Credentials select u;
            var creds = query.ToList();

            return creds.Where(user => user.Id == id).Select(ConvertToDomainObject).FirstOrDefault();
        }

        public void Create(PassOneObject obj)
        {
            obj.Id = GetNextIdValue();
            using (var db = new PassOneContext())
            {
                db.Credentials.Add(ConvertToEntity(obj));
                db.SaveChanges();
            }
        }

        public void Delete(PassOneObject obj)
        {
            using (var db = new PassOneContext())
            {
                db.Credentials.Remove(ConvertToEntity(obj));
                db.SaveChanges();
            }
        }

        public int GetNextIdValue()
        {
            var context = new PassOneContext();
            var query = from u in context.Users select u;
            var users = query.ToList();

            return users.Select(user => user.Id).Concat(new[] { 0 }).Max() + 1;
        }

        private PassOneCredentials ConvertToDomainObject(Credential entity)
        {
            return new PassOneCredentials(entity.Id, entity.UserId, entity.Title, entity.Url, entity.Username, entity.Email, entity.Password);
        }

        private Credential ConvertToEntity(PassOneObject obj)
        {
            var creds = (PassOneCredentials) obj;
            var newCred = new Credential
                {
                    Id = creds.Id,
                    UserId = creds.UserId,
                    Title = creds.Website,
                    Url = creds.Url,
                    Username = creds.Username,
                    Email = creds.EmailAddress,
                    Password = creds.Password
                };
            return newCred;
        }
    }
}