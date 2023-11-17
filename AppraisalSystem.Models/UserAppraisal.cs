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
    public class UserAppraisal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CoefficientId { get; set; }
        public double Count { get; set; }
        public string AssessmentYear { get; set; }
        public bool IsDel { get; set; }

        public static List<UserAppraisal> ListByUserIdAndYear(int userId, string year)
        {
            List<UserAppraisal> userAppraisals = new List<UserAppraisal>();
            DataTable dt = sqlHelper.ExecuteTable("SELECT * FROM UsersAppraisals WHERE UserId = @UserId AND AssessmentYear = @AssessmentYear",
                new SqlParameter("@UserId", userId),
                new SqlParameter("@AssessmentYear",year));

            foreach (DataRow dr in dt.Rows)
            {
                userAppraisals.Add(dr.DataRowToModel<UserAppraisal>());
            }
            return userAppraisals;
        }

        public static void Insert(UserAppraisal userAppraisal)
        {
            sqlHelper.ExecuteNonQuery("INSERT INTO UserAppraisals(UserId,CoefficientId,Count,AssessmentYear,IsDel) VALUES (@UserId, @CoefficientId, @Count, @AssessmentyYear,@IsDel)",
                new SqlParameter("@UserId", userAppraisal.UserId),
                new SqlParameter("@CoefficientId", userAppraisal.CoefficientId),
                new SqlParameter("@Count", userAppraisal.Count),
                new SqlParameter("@AssessmentYear", userAppraisal.AssessmentYear),
                new SqlParameter("@IsDel", userAppraisal.IsDel));
        }

        public static void Delete(int UserId, string AssessmentYear, int CoefficientId)
        {
            sqlHelper.ExecuteNonQuery("DELETE FROM UserAppraisals WHERE UserId = @UserId AND AssessmnetYear = @AsessmentYear AND CoefficientId = @CoeficientId",

                new SqlParameter("@UserId", UserId),
                new SqlParameter("@AssessmentYear", AssessmentYear),
                new SqlParameter("@CoefficientId", CoefficientId)
               );
        }
    }
}
