namespace AppraisalSystem
{
    partial class FrmBaseManager
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
            this.GridViewBase = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewBase)).BeginInit();
            this.SuspendLayout();
            // 
            // GridViewBase
            // 
            this.GridViewBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewBase.Location = new System.Drawing.Point(0, 0);
            this.GridViewBase.Name = "GridViewBase";
            this.GridViewBase.RowHeadersWidth = 51;
            this.GridViewBase.RowTemplate.Height = 24;
            this.GridViewBase.Size = new System.Drawing.Size(800, 450);
            this.GridViewBase.TabIndex = 0;
            this.GridViewBase.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewBase_CellValueChanged);
            // 
            // FrmBaseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GridViewBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBaseManager";
            this.Text = "FrmBaseManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBaseManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridViewBase;
    }
}