using AppraisalSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppraisalSystem
{
    public partial class FrmUserAppraisal : Form
    {
        public FrmUserAppraisal()
        {
            InitializeComponent();
        }

        Action BindDgv;

        private void FrmUserAppraisal_Load(object sender, EventArgs e)
        {
            SetCol();
            BindDgv = BindDgvAppraisal;
        }

        private void BindDgvAppraisal()
        {
            DataTable dtUser = UserAppraisalBases.GetDtJoinAppraisal();
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            foreach (var item in appraisalCoefficients)
            {
                dtUser.Columns.Add(new DataColumn
                {
                    ColumnName = "AppraisalType" + item.Id
                });

                dtUser.Columns.Add(new DataColumn
                {
                    ColumnName = "AppraisalCoefficient" + item.Id
                });

                dtUser.Columns.Add(new DataColumn
                {
                    ColumnName = "CalculationMethod" + item.Id
                });

            }

            dtUser.Columns.Add(new DataColumn
            {
                ColumnName = "AssessmentYear"
            });

            dtUser.Columns.Add(new DataColumn
            {
                ColumnName = "YearBonus"
            });


            List<UserAppraisalCoefficients> userAppraisalCoefficients = UserAppraisalCoefficients.ListAll();
            for (int i = 0; i < dtUser.Rows.Count; i++)
            {
                var uacFilter = userAppraisalCoefficients.FindAll(m => m.UserId == (int)dtUser.Rows[i]["Id"] && m.AssessmentYear == cbxYear.Text);
                double[] yearBonusArray = new double[uacFilter.Count];
                for (int j = 0; j < uacFilter.Count; j++)
                {
                    string AppraisalTypeKey = "AppraisalType" + uacFilter[j].CoefficientId;
                    double AppraisalTypeCountValue = uacFilter[j].Count;

                    string AppraisalCoefficientKey = "AppraisalCoefficient" + uacFilter[j].CoefficientId;
                    double AppraisalCoefficientValue = uacFilter[j].AppraisalCoefficient;

                    string CalculationMethodKey = "CalculationMethod" + uacFilter[j].CoefficientId;
                    double CalculationMethodKeyValue = uacFilter[j].CalculationMethod;

                    dtUser.Rows[i][AppraisalTypeKey] = AppraisalTypeCountValue;
                    dtUser.Rows[i][AppraisalCoefficientKey] = AppraisalCoefficientValue;
                    dtUser.Rows[i][CalculationMethodKey] = CalculationMethodKeyValue;

                    yearBonusArray[j] = AppraisalTypeCountValue * AppraisalCoefficientValue * CalculationMethodKeyValue;
                }

                dtUser.Rows[i]["AssessmentYear"] = cbxYear.Text;

                double yearBonusAll = 0;
                for (int j = 0; j < yearBonusArray.Length; j++)
                {
                    yearBonusAll += yearBonusArray[j];
                }

                double yearBonus = (1 + yearBonusAll) * Convert.ToDouble(dtUser.Rows[i]["AppraisalBase"]);

                dtUser.Rows[i]["YearBonus"] = yearBonus < 0 ? 0 : yearBonus;
            }

            dgvUserAppraisal.AutoGenerateColumns = false;
            dgvUserAppraisal.DataSource = dtUser;
        }

        private void SetCol()
        {
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            List<DataGridViewTextBoxColumn> dataGridViewTextBoxColumns = new List<DataGridViewTextBoxColumn>();

            foreach (var appraisalCoefficient in appraisalCoefficients)
            {
                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = appraisalCoefficient.AppraisalType,
                    Name = "AppraisalType" + appraisalCoefficient.Id.ToString(),
                    DataPropertyName = "AppraisalType" + appraisalCoefficient.Id.ToString(),
                    ReadOnly = true,
                    Width = 88
                });

                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "AppraisalCoefficient",
                    Name = "AppraisalCoefficient" + appraisalCoefficient.Id.ToString(),
                    DataPropertyName = "AppraisalCoefficient" + appraisalCoefficient.Id.ToString(),
                    Visible = false,
                    ReadOnly = true,
                    Width = 88
                });

                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "CalculationMethod",
                    Name = "CalculationMethod" + appraisalCoefficient.Id.ToString(),
                    DataPropertyName = "CalculationMethod" + appraisalCoefficient.Id.ToString(),
                    Visible = false,
                    ReadOnly = true,
                    Width = 88
                });

            }
            dgvUserAppraisal.Columns.AddRange(dataGridViewTextBoxColumns.ToArray());
            dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "AssessmentYear",
                Name = "AssessmentYear",
                DataPropertyName = "AssessmentYear",
                ReadOnly = true,
                Width = 88
            });

            dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "YearBonus",
                Name = "YearBonus",
                DataPropertyName = "YearBonus",
                ReadOnly = true,
                Width = 88
            });
        }

        private void dgvUserAppraisal_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if (e.RowIndex>-1){

                    dgvUserAppraisal.ClearSelection();
                    dgvUserAppraisal.Rows[e.RowIndex].Selected = true;  
                }
            }
            editInfo.Visible = true;
        }

        private void dgvUserAppraisal_MouseDown(object sender, MouseEventArgs e)
        {
            editInfo.Visible = false;
        }

        private void editInfo_Click(object sender, EventArgs e)
        {
            string year = cbxYear.Text;
            int userId = (int)dgvUserAppraisal.SelectedRows[0].Cells["Id"].Value;
            FromUserApparaisalEdit fromUserApparaisalEdit = new FromUserApparaisalEdit(userId,year, BindDgv);
            fromUserApparaisalEdit.ShowDialog();
        }
    }
}
