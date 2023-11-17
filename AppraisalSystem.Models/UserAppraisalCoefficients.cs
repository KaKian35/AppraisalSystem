using AppraisalSystem.Utility;
using AppraisalSytstem.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalSystem.Models
{
    public class UserAppraisalCoefficients
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CoefficientId { get; set; }
        public double Count { get; set; }
        public string AssessmentYear { get; set; }
        public string AppraisalType { get; set; }
        public double AppraisalCoefficient { get; set; }
        public double CalculationMethod { get; set; }

        public static List<UserAppraisalCoefficients> ListAll()
        {
            List<UserAppraisalCoefficients> userAppraisalCoefficients = new List<UserAppraisalCoefficients>();
            DataTable dt = sqlHelper.ExecuteTable("SELECT ua.*, ac.AppraisalType, ac.AppraisalCoefficient,ac.CalculationMethod FROM UsersAppraisals ua LEFT JOIN" +
                " AppraisalCoefficients ac ON ua.CoefficientId = ac.Id");
            foreach (DataRow dr in dt.Rows) {
                userAppraisalCoefficients.Add(dr.DataRowToModel<UserAppraisalCoefficients>());
            }
             return userAppraisalCoefficients;
        }
    }
}
