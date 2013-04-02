using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PassOne.Domain;

namespace PassOne.Service
{
    public class EntityCredentialsImplementation : IService
    {
        public Credentials RetreiveById(int id)
        {
            var context = new PassOneDataContext();
            var query = from u in context.Credentials select u;
            var creds = query.ToList();

            return creds.Where(user => user.Id == id).Select(ConvertToDomainObject).FirstOrDefault();
        }

        public void Create(Credentials creds)
        {
            creds.Id = GetNextIdValue();
            using (var db = new PassOneDataContext())
            {
                db.Credentials.Add(ConvertToEntity(creds));
                db.SaveChanges();
            }
        }

        public void Delete(Credentials creds)
        {
            using (var db = new PassOneDataContext())
            {
                db.Credentials.Remove(ConvertToEntity(creds));
                db.SaveChanges();
            }
        }

        public int GetNextIdValue()
        {
            var context = new PassOneDataContext();
            var query = from u in context.Users select u;
            var users = query.ToList();

            return users.Select(user => user.Id).Concat(new[] { 0 }).Max();
        }

        private Credentials ConvertToDomainObject(CredentialsEntity entity)
        {
            return new Credentials(entity.Id, entity.UserId, entity.Title, entity.Url, entity.Username, entity.Email, entity.Password);
        }

        private CredentialsEntity ConvertToEntity(Credentials creds)
        {
            return new CredentialsEntity(creds.Id, creds.UserId, creds.Website, creds.Url, creds.Username, creds.EmailAddress, creds.Password);
        }
    }
}