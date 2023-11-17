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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AppraisalSystem
{
    public partial class FrmSetUser : Form
    {
        private DelBindDgv _delBindDgv;
        public FrmSetUser(DelBindDgv delBindDgv)
        {
            InitializeComponent();
            _delBindDgv = delBindDgv;
        }

        private Users _user;
        public FrmSetUser(DelBindDgv delBindDgv,int UserId):this(delBindDgv)
        {
            _user = Users.ListAll().Find(m => m.Id == UserId);

        }

        private void FrmSetUser_Load(object sender, EventArgs e)
        {
            List<AppraisalBases> appraisalBases = new List<AppraisalBases>();
            appraisalBases = AppraisalBases.ListAll();
            cbxBasesType.DataSource = appraisalBases;
            cbxBasesType.DisplayMember = "BaseType";
            cbxBasesType.ValueMember = "Id";


            if (_user != null)
            {
                txtUserName.Text = _user.Username;
                cbxBasesType.SelectedValue = _user.BaseId;
                cbxSex.Text = _user.Sex;
                cbSuspended.Checked = _user.IsDel;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            int baseTypeId = (int)cbxBasesType.SelectedValue;
            string sex = cbxSex.Text;
            bool isDel = cbSuspended.Checked;

            if (_user == null)
            {
                Users user = new Users
                {
                    Username = userName,
                    BaseId = baseTypeId,
                    Password = "123",
                    IsDel = isDel,
                    Sex = sex
                };

                Users.Insert(user);
                MessageBox.Show("Add Successfully");
            }
            else
            {
                _user.Username = userName;
                _user.BaseId = baseTypeId;
                _user.IsDel = isDel;
                _user.Sex = sex;

                Users.Update(_user);
                MessageBox.Show("Edit Successfully");
            }

            _delBindDgv();
            this.Close();
        }
    }
}
