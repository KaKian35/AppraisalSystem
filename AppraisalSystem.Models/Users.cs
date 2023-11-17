using AppraisalSystem.Utility;
using AppraisalSytstem.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalSystem.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Sex { get; set; }

        public string Password { get; set; }

        public int BaseId { get; set; }

        public bool IsDel { get; set; }

        public static  List<Users> ListAll()
        {

            DataTable dt = sqlHelper.ExecuteTable("SELECT u.Id, u.UserName, u.Password, u.Sex, u.BaseId, u.IsDel  FROM StaffUsers u");

            List<Users> users = new List<Users>();

            foreach (DataRow dr in dt.Rows)
            {
                users.Add(dr.DataRowToModel<Users>());
            }

            return users;
        }

        public static int Insert(Users user)
        {
               return sqlHelper.ExecuteNonQuery($"INSERT INTO StaffUsers(UserName, Sex, Password, BaseId, IsDel) VALUES (@UserName, @Sex, @Password, @BaseId, @IsDel)",
                new SqlParameter("Username", user.Username),
                new SqlParameter("Sex", user.Sex),
                new SqlParameter("Password", user.Password),
                new SqlParameter("BaseId", user.BaseId),
                new SqlParameter("IsDel", user.IsDel)
                );

        }


        public static int Update(Users user)
        {
             return sqlHelper.ExecuteNonQuery($"UPDATE StaffUsers SET UserName = @UserName, Sex=@Sex, Password = @Password, BaseId = @BaseId, IsDel = @IsDel Where Id = @Id" ,
             new SqlParameter("Id", user.Id),
             new SqlParameter("Username", user.Username),
             new SqlParameter("Sex", user.Sex),
             new SqlParameter("Password", user.Password),
             new SqlParameter("BaseId", user.BaseId),
             new SqlParameter("IsDel", user.IsDel)
             );

        }
    }
}
