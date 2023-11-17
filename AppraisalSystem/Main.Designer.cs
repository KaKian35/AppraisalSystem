namespace AppraisalSystem
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("UserManager");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("BaseManager");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("CoefficientManager");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("UserAppraisal");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MenuTree = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MenuTree);
            this.splitContainer1.Size = new System.Drawing.Size(979, 425);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 0;
            // 
            // MenuTree
            // 
            this.MenuTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuTree.FullRowSelect = true;
            this.MenuTree.ItemHeight = 35;
            this.MenuTree.Location = new System.Drawing.Point(0, 0);
            this.MenuTree.Name = "MenuTree";
            treeNode1.Name = "tnUserManager";
            treeNode1.Tag = "FrmUserManager";
            treeNode1.Text = "UserManager";
            treeNode2.Name = "tnBaseManager";
            treeNode2.Tag = "FrmBaseManager";
            treeNode2.Text = "BaseManager";
            treeNode3.Name = "tnCoefficientManager";
            treeNode3.Text = "CoefficientManager";
            treeNode4.Name = "tnUserAppraisal";
            treeNode4.Tag = "FrmUserAppraisal";
            treeNode4.Text = "UserAppraisal";
            this.MenuTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.MenuTree.ShowLines = false;
            this.MenuTree.Size = new System.Drawing.Size(325, 425);
            this.MenuTree.TabIndex = 0;
            this.MenuTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MenuTree_AfterSelect);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 425);
            this.Controls.Add(this.splitContainer1);
            this.IsMdiContainer = true;
            this.Name = "Main";
            this.Text = "Appraisal System";
            this.Load += new System.EventHandler(this.Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView MenuTree;
    }
}

