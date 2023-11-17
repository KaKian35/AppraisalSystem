using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalSystem.Utility
{
    public class sqlHelper
    {
        public static string ConStr { get; set; }

        public static DataTable ExecuteTable(string cmdText, params SqlParameter[]sqlParameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddRange(sqlParameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }

            catch (Exception ex)
            {
                // Handle the exception here, e.g., log it.
                Console.WriteLine("Error executing SQL query: " + ex.Message);
                return null; // Return null or an empty DataTable on error.
            }
        }

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] sqlParameters) {

            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddRange(sqlParameters);
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }

        }
    }
}
