using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessInterfaces;
using DataAccessLayer;
using System.Security.Cryptography;

namespace LogicLayer
{
    public class UserManager : IUserManager
    {
        private IUserAccessor userAccessor = null;

        public UserManager()
        {
            userAccessor = new UserAccessor();
        }

        public UserManager(IUserAccessor ua)
        {
            userAccessor = ua;
        }

        public string HashSha256(string source)
        {
            string result = "";

            if (source == "" || source == null)
            {
                throw new ArgumentException("Source cannot be empty");
            }

            // byte array
            byte[] data;

            // .NET has provider
            using (SHA256 sha256haser = SHA256.Create())
            {
                // hash the input
                data = sha256haser.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            // stringbuilder
            var s = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            result = s.ToString();

            return result.ToLower();
        }

        public User LoginUser(string email, string password)
        {
            User user = null;

            try
            {
                password = HashSha256(password);
                if (1 == userAccessor.AuthenticateUser(email, password))
                {
                    //user is valid
                    user = userAccessor.SelectUserByEmail(email);
                    user.Roles = userAccessor.SelectRolesByMemberID(user.MemberID);
                }
                else
                {
                    throw new ApplicationException("Bad Username or Password");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Login Failed.", ex);
            }

            return user;
        }

        public bool ResetPassword(int employeeID, string password, string oldPassword)
        {
            throw new NotImplementedException();
        }
    }
}
