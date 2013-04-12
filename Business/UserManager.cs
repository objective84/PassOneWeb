using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PassOne.Domain.Exceptions;
using PassOne.Service;
using PassOne.Domain;

namespace PassOne.Business
{
    public class UserManager : ManagerBase
    {
        public UserManager()
            : base(Services.EntityUserImplementation)
        {
        }
        /// <summary>
        /// Method to create a new user in the user.bin file, takes the individual strings instead of a User object.
        /// </summary>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <param name="fn">The user's first name</param>
        /// <param name="ln">The user's last name</param>
        /// <param name="un">The user's chosen username</param>
        /// <param name="pass">The user's chosen password</param>
        public void CreateUser(string path, string fn, string ln, string un, string pass)
        {
            GetService(path).Create(new PassOneUser(GetService(path).GetNextIdValue(), fn, ln, un, pass));
        }

        /// <summary>
        /// Method to create a new user in the user.bin file, takes a preconstructed User object
        /// </summary>
        /// <param name="passOneUser">The user to be created</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        public void CreateUser(PassOneUser passOneUser, string path )
        {
            GetService(path).Create(passOneUser);
        }

        /// <summary>
        /// Method to update user information contained in the user.bin file
        /// </summary>
        /// <param name="passOneUser">The new user data</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        public void UpdateUser(PassOneUser passOneUser, string path)
        {
            //GetService(path).UpdateTable(passOneUser);
        }

        /// <summary>
        /// Method to authenticate a user's login information
        /// </summary>
        /// <param name="username">The username the user typed into the login form</param>
        /// <param name="password">The password the user typed into the login form</param>
        /// <param name="path">The directory path to where the app can find the PassOne data files</param>
        /// <returns>If the authentication was successful, returns the User object associated with the provided username, otherwise throws an InvalidLoginException</returns>
        public PassOneUser Authenticate(string username, string password, string path)
        {
            var service = GetService(path) as EntityUserImplementation;
            return service.Authenticate(username, password);
        }

        public void DeleteUser(PassOneUser passOneUser, string path)
        {
            GetService(path).Delete(passOneUser);
        }
    }
}
