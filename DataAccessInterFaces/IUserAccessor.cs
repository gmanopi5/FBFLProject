using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterfaces
{
    public interface IUserAccessor
    {
        int AuthenticateUser(string email, string passwordHash);
        User SelectUserByEmail(string email);
        List<string> SelectRolesByMemberID(int memberID);
        int UpdatePasswordHash(int memberID,
            string passwordHash, string oldPasswordHash);
    }
}
