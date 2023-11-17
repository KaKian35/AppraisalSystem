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
    public partial class FromUserApparaisalEdit : Form
    {
        private int _userId;
        private string _year;
        private Action _bindDgv;
        public FromUserApparaisalEdit()
        {
            InitializeComponent();
        }
      
        public FromUserApparaisalEdit(int userId, string year,Action BindDgv) :this()
        {
            _userId = userId;
            _year = year;
            _bindDgv = BindDgv;
        }

        private void FromUserApparaisalEdit_Load(object sender, EventArgs e)
        {
            CreateControls();
            BlindControl();
        }

        private void BlindControl()
        {
            List<UserAppraisal> userAppraisals = UserAppraisal.ListByUserIdAndYear(_userId, _year);
            foreach (var ua in userAppraisals)
            {
                var plcontrols = flowLayout.Controls;
                foreach (Control control in plcontrols)
                {
                    if (control is Panel)
                    {

                        var plcontrol = control.Controls;
                        foreach (var flcontrol in plcontrol)
                        {
                            if (flcontrol is TextBox)
                            {
                                int acId = Convert.ToInt32(((TextBox)flcontrol).Name.Split('_')[1]);
                                ((TextBox)flcontrol).Text = userAppraisals.Find(m => m.CoefficientId == acId).Count.ToString();
                            }
                        }
                    }
                }
            }
        }

        private void CreateControls()
        {
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            foreach (var ac in appraisalCoefficients)
            {
                Panel panel = new Panel();
                Label label = new Label
                {
                    Location = new Point(0, 5),
                    Text = ac.AppraisalType,
                    Width = 60
                };
                TextBox textBox = new TextBox
                {
                    Location = new Point(60, 0),
                    Width = 120,
                    Height = 26,
                    Name = "txtAppraisalType_" + ac.Id
                };
                panel.Controls.Add(label);
                panel.Controls.Add(textBox);
                flowLayout.Controls.Add(panel);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var plcontrols = flowLayout.Controls;
            foreach (Control control in plcontrols)
            {
                if (control is Panel)
                {

                    var plcontrol = control.Controls;
                    foreach (var flcontrol in plcontrol)
                    {
                        if (flcontrol is TextBox)
                        {
                            int acId = Convert.ToInt32(((TextBox)flcontrol).Name.Split('_')[1]);
                            double count = Convert.ToDouble(((TextBox)flcontrol).Text);
                            UserAppraisal.Delete(_userId,_year, acId);
                            UserAppraisal userAppraisal = new UserAppraisal
                            {
                                UserId = _userId,
                                CoefficientId = acId,
                                AssessmentYear = _year,
                                Count = count,
                                IsDel = false
,                           };
                            UserAppraisal.Insert(userAppraisal);
                         
                        }
                    }
                }
            }
            MessageBox.Show("Change Successfully");
            _bindDgv();
            this.Close();
            

        }
    }
}
