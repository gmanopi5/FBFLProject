using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterfaces;
using System.Data;              //holds common definitions for classes and enums
using System.Data.SqlClient;    //hold class definitions for SQL server

namespace DataAccessLayer
{
    public class UserAccessor : IUserAccessor
    {
        public int AuthenticateUser(string email, string passwordHash)
        {
            int result = 0;

            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_authenticate_user";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar);

            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {
                conn.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public List<string> SelectRolesByMemberID(int memberID)
        {
            List<string> roles = new List<string>();

            //connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_select_roles_by_memberid";

            //command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //parameters
            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar, 100);

            //value
            cmd.Parameters["@MemberID"].Value = memberID;

            //try-catch-finally
            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return roles;
        }

        public User SelectUserByEmail(string email)
        {
            User user = null;

            //connection
            DBConnection connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            //command text
            var cmdText = "sp_select_user_by_email";

            //command
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //parameters
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);

            //value
            cmd.Parameters["@Email"].Value = email;

            //try-catch finally
            try
            {
                conn.Open();

                // get a dat reader
                var reader = cmd.ExecuteReader();

                //process results
                if (reader.HasRows)
                {
                    // usally, there will be a while loop
                    reader.Read();

                    user = new User();
                    user.MemberID = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.Phone = reader.GetString(2);
                    user.Email = reader.GetString(3);
                }
                else
                {
                    throw new ApplicationException("User not found.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return user;
        }

        public int UpdatePasswordHash(int memberID, string passwordHash, string oldPasswordHash)
        {
            throw new NotImplementedException();
        }
    }
}