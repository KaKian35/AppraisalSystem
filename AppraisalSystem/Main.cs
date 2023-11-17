using AppraisalSystem.Common;
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
    public partial class Main : Form
    {
/*      FrmUserManager frmUserManager;
        FrmBaseManager frmBaseManager;*/
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Form form = FormFactory.CreateForm("FrmUserManager");
            /* frmUserManager = new FrmUserManager();
               frmUserManager.MdiParent = this;
               frmUserManager.Parent = splitContainer1.Panel2;
               frmUserManager.Show();*/

            //Form form = FormFactory.CreateForm(0);
            form.MdiParent = this;
            form.Parent = splitContainer1.Panel2;
            form.Show();
        }

        private void MenuTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            /*          bool b1 = ((TreeView)sender).SelectedNode == MenuTree.SelectedNode;
                        bool b2 = ((TreeView)sender).SelectedNode == e.Node;*/

            foreach (TreeNode node in MenuTree.Nodes)
            {
                node.BackColor = Color.White;
                node.ForeColor = Color.Black;
            }
            e.Node.BackColor = SystemColors.Highlight;
            e.Node.ForeColor = Color.White;

            Form form = FormFactory.CreateForm(e.Node.Tag?.ToString());
            form.MdiParent = this;
            form.Parent = splitContainer1.Panel2;
            form.Show();
        }
    }
}
