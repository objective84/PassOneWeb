using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PassOne.Domain;


namespace PassOne.Service
{
    public class EntityUserImplementation : IService
    {
        public User RetreiveById(int id)
        {
            var context = new PassOneDataContext();
            var query = from u in context.UserEntities select u;
            var users = query.ToList();

            return users.Where(user => user.Id == id).Select(ConvertToDomainObject).FirstOrDefault();
        }

        public void Create(User user)
        {
            user.Id = GetNextIdValue();
            using (var db = new PassOneDataContext())
            {
                db.UserEntities.Add(ConverToEntity(user));
                db.SaveChanges();
            }
        }

        public void Delete(User user)
        {
            using (var db = new PassOneDataContext())
            {
                db.UserEntities.Remove(ConverToEntity(user));
                db.SaveChanges();
            }
        }

        public int GetNextIdValue()
        {
            var context = new PassOneDataContext();
            var query = from u in context.UserEntities select u;
            var users = query.ToList();

            return users.Select(user => user.Id).Concat(new[] {0}).Max();
        }
        
        private User ConvertToDomainObject(UserEntity entity)
        {
            return new User(entity.Id, entity.FirstName, entity.LastName, entity.Username, entity.Password);
        }

        private UserEntity ConverToEntity(User user)
        {
            var newUser = new UserEntity();
            newUser.Id = user.Id;
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.Username = user.Username;
            newUser.Password = user.Password;
            return newUser;
        }
    }
}