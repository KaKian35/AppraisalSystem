﻿using AppraisalSystem.Utility;
using AppraisalSytstem.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalSystem.Models
{
    public class AppraisalCoefficients
    {
        public int Id { get; set; }
        public string AppraisalType { get; set; }
        public double AppraisalCoefficient { get; set; }
        public double CalculationMethod { get; set; }
        public bool IsDel { get; set;}

        public static List<AppraisalCoefficients> ListAll() {
        List<AppraisalCoefficients> appraisalCoefficients = new List<AppraisalCoefficients>();
            DataTable dt = sqlHelper.ExecuteTable("SELECT * FROM AppraisalCoefficients");
            foreach (DataRow dr in dt.Rows)
            {
                appraisalCoefficients.Add(dr.DataRowToModel<AppraisalCoefficients>());
            }

        return appraisalCoefficients;
        }
    }
}
