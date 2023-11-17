using AppraisalSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppraisalSystem
{
    public delegate void DelBindDgv();
    public partial class FrmUserManager : Form
    {
        DelBindDgv delBindDgv;
        public FrmUserManager()
        {
            InitializeComponent();
        }

        private void FrmUserManager_Load(object sender, EventArgs e)
        {
            BindCbx();
            BindGv();
            delBindDgv = BindGv;

        }

        private void BindGv()
        {
            string UserName = txtUserName.Text.Trim();
            int baseTypeId = (int)cbxBases.SelectedValue;
            bool isStop = Suspendedchx.Checked;
            GridViewAppraisal.AutoGenerateColumns = false;
            List<UserAppraisalBases> userAppraisalBases = UserAppraisalBases.GetListJoinAppraisal();
            if (baseTypeId == 0)
            {
                GridViewAppraisal.DataSource = userAppraisalBases.FindAll(m => m.Username.Contains(UserName) && m.IsDel == isStop);
            }
            else
            {
                GridViewAppraisal.DataSource = userAppraisalBases.FindAll(m => m.Username.Contains(UserName) && m.BaseTypeById == baseTypeId && m.IsDel == isStop);
            }
        }
         
        private void BindCbx()
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
            appraisalBases = AppraisalBases.ListAll();
            appraisalBases.Insert(0, new AppraisalBases
            {
                Id = 0,
                BaseType = "--All--",
                AppraisalBase = 0,
                IsDel = false
            });
            cbxBases.DataSource = appraisalBases;
            cbxBases.DisplayMember = "BaseType";
            cbxBases.ValueMember = "Id";

            //Method1
            /*  List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
                appraisalBases.Add(new AppraisalBases
                {

                    Id = 0,
                    BaseType = "--All--",
                    AppraisalBase = 0,
                    IsDel = false
                }); ;
               //IEnumerable<AppraisalBases> appraisalBase2 = AppraisalBases.ListAll();
                appraisalBases.AddRange(AppraisalBases.ListAll());
                cbxBases.DataSource = appraisalBases;
                cbxBases.DisplayMember = "BaseType";
                cbxBases.ValueMember = "Id";*/


            //Normal Method
            /*  List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
                appraisalBases = AppraisalBases.ListAll();
                cbxBases.Text ="--Check--";
                cbxBases.Items.Add("All");
                foreach (var appraisal in appraisalBases)
                {
                    cbxBases.Items.Add(appraisal.BaseType);
                }
               */
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGv();
        }

        private void GridViewAppraisal_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right) {
                tsmAdd.Visible = true;
                tsmEdit.Visible = false;
                tsmSuspended.Visible = false;
                tsmUnsuspended.Visible = false;
            }
        }

        private void GridViewAppraisal_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1) {

                    GridViewAppraisal.Rows[e.RowIndex].Selected = true;
                    tsmAdd.Visible = true;
                    tsmEdit.Visible = true;

                    bool isDel = (bool)GridViewAppraisal.SelectedRows[0].Cells["IsDel"].Value;
                    if (isDel)
                    {

                        tsmUnsuspended.Visible = true;

                    }
                    else
                    {

                        tsmSuspended.Visible = true;

                    }

                }

            }

        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            FrmSetUser  frmsetuser = new FrmSetUser(delBindDgv);
            frmsetuser.ShowDialog();
            BindGv();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            int id = (int)GridViewAppraisal.SelectedRows[0].Cells["Id"].Value;
            FrmSetUser frmSetUser = new FrmSetUser(delBindDgv, id);
            frmSetUser.ShowDialog();
        }
    }
}
