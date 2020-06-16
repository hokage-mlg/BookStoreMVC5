using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BookStore.Domain.Concrete;

namespace BookStore.WebUI.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override string[] GetRolesForUser(string username)
        {
            var roles = new string[] { };
            using (var db = new EFDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == username);
                if (user != null)
                {
                    var userRole = db.Roles.Find(user.RoleId);
                    if (userRole != null)
                        roles = new string[] { userRole.Name };
                }
            }
            return roles;
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            var outputResult = false;
            using (var db = new EFDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == username);
                if (user != null)
                {
                    var userRole = db.Roles.Find(user.RoleId);
                    if (userRole != null && userRole.Name == roleName)
                        outputResult = true;
                }
            }
            return outputResult;
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }       
    }
}