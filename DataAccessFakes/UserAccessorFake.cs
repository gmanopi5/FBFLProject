using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    public class UserAccessorFake : IUserAccessor
    {
        private List<User> fakeUsers = new List<User>();
        private List<string> passwordHashes = new List<string>();
        public UserAccessorFake()
        {
            fakeUsers.Add(new User()
            {
                MemberID = 999999,
                Email = "tess@fbfl.com",
                Name = "Tess Data",
                Phone = "123456789",
                Roles = new List<string>()
            });

            fakeUsers.Add(new User()
            {
                MemberID = 999999,
                Email = "duplicate1@fbfl.com",
                Name = "Bad Data",
                Phone = "123456789",
                Roles = new List<string>()
            });

            fakeUsers.Add(new User()
            {
                MemberID = 999999,
                Email = "duplicate2@fbfl.com",
                Name = "Worse Data",
                Phone = "123456789",
                Roles = new List<string>()
            });

            passwordHashes.Add("9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e");
            passwordHashes.Add("invalid-hash");
            passwordHashes.Add("invalid-hash");

            fakeUsers[0].Roles.Add("Commissioner");
            fakeUsers[0].Roles.Add("Manager");
        }

        public int AuthenticateUser(string email, string passwordHash)
        {
            int result = 0;

            //check for user record
            for (int i = 0; i < fakeUsers.Count; i++)
            {
                if (fakeUsers[i].Email == email && passwordHashes[i] == passwordHash)
                {
                    result++;
                }
            }

            return result;
        }

        public List<string> SelectRolesByMemberID(int memberID)
        {
            List<string> roles = null;

            foreach (var fakeUser in fakeUsers)
            {
                if (fakeUser.MemberID == memberID)
                {
                    roles = fakeUser.Roles;
                }
            }

            return roles;
        }

        public List<string> SelectUserByEmail(int memberID)
        {
            throw new NotImplementedException();
        }

        public User SelectUserByEmail(string email)
        {
            User user = null;

            foreach (var fakeUser in fakeUsers)
            {
                if (fakeUser.Email == email)
                {
                    user = fakeUser;
                    break;
                }
            }

            if (user == null)
            {
                throw new ApplicationException("User not found");
            }

            return user;
        }

        public int UpdatePasswordHash(int memberID, string passwordHash, string oldPasswordHash)
        {
            throw new NotImplementedException();
        }
    }
}
