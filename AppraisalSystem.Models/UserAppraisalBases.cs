using AppraisalSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalSystem.Models
{
    public class UserAppraisalBases
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Sex { get; set; }

        public string Password { get; set; }

        public int BaseTypeById { get; set; }

        public string BaseType { get; set; }

        public string AppraisalBase { get; set; }

        public bool IsDel { get; set; }

        public static DataTable GetDtJoinAppraisal()
        {
            DataTable dt = sqlHelper.ExecuteTable("SELECT u.Id, u.UserName, u.Sex, u.BaseId, u.IsDel, a.AppraisalBase, " +
                "a.BaseType FROM StaffUsers u LEFT JOIN AppraisalBases a ON u.BaseId = a.Id");

            return dt;
        }

        public static List<UserAppraisalBases> GetListJoinAppraisal()
        {
            List <UserAppraisalBases> userAppraisals = new List<UserAppraisalBases>();
            DataTable dt = GetDtJoinAppraisal();
            foreach (DataRow dr in dt.Rows)
            {
                userAppraisals.Add(ToModel(dr));
            }

            return userAppraisals;
        }

        private static UserAppraisalBases ToModel(DataRow dr)
        {
            UserAppraisalBases userappraisal = new UserAppraisalBases();
            userappraisal.Id = (int)dr["Id"];
            userappraisal.Username = dr["Username"].ToString();
            userappraisal.Sex = dr["Sex"].ToString();
            userappraisal.BaseTypeById = (int)dr["BaseId"];
            userappraisal.BaseType = dr["BaseType"].ToString();
            userappraisal.AppraisalBase = dr["AppraisalBase"].ToString();
            userappraisal.IsDel = (bool)dr["IsDel"];
            return userappraisal;

        }
    }
}
