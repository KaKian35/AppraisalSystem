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
    public partial class FrmBaseManager : Form
    {
        public FrmBaseManager()
        {
            InitializeComponent();
        }

        private void FrmBaseManager_Load(object sender, EventArgs e)
        {
            GridViewBase.DataSource = AppraisalBases.ListAll();
        }

        private void GridViewBase_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AppraisalBases appraisalBases = (AppraisalBases)GridViewBase.Rows[e.RowIndex].DataBoundItem;
            AppraisalBases.Update(appraisalBases);
        }
    }
}
