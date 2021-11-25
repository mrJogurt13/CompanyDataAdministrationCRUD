
namespace CompanyDataAdministrationApplication
{
    partial class DataAdministration
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
            this.lv_Overview = new System.Windows.Forms.ListView();
            this.col_CompanyNr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_CompanyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_EmailAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_edit_delete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_newEntry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lv_Overview
            // 
            this.lv_Overview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_CompanyNr,
            this.col_CompanyName,
            this.col_EmailAddress,
            this.col_edit_delete});
            this.lv_Overview.HideSelection = false;
            this.lv_Overview.Location = new System.Drawing.Point(12, 12);
            this.lv_Overview.Name = "lv_Overview";
            this.lv_Overview.Size = new System.Drawing.Size(776, 397);
            this.lv_Overview.TabIndex = 0;
            this.lv_Overview.UseCompatibleStateImageBehavior = false;
            this.lv_Overview.View = System.Windows.Forms.View.Details;
            this.lv_Overview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UpdateEntry);
            // 
            // col_CompanyNr
            // 
            this.col_CompanyNr.Text = "CompanyNr";
            this.col_CompanyNr.Width = 80;
            // 
            // col_CompanyName
            // 
            this.col_CompanyName.Text = "CompanyName";
            this.col_CompanyName.Width = 200;
            // 
            // col_EmailAddress
            // 
            this.col_EmailAddress.Text = "EmailAddress";
            this.col_EmailAddress.Width = 200;
            // 
            // col_edit_delete
            // 
            this.col_edit_delete.Text = "";
            // 
            // btn_newEntry
            // 
            this.btn_newEntry.Location = new System.Drawing.Point(12, 415);
            this.btn_newEntry.Name = "btn_newEntry";
            this.btn_newEntry.Size = new System.Drawing.Size(776, 23);
            this.btn_newEntry.TabIndex = 1;
            this.btn_newEntry.Text = "new entry";
            this.btn_newEntry.UseVisualStyleBackColor = true;
            this.btn_newEntry.Click += new System.EventHandler(this.btn_newEntry_Click);
            // 
            // DataAdministration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_newEntry);
            this.Controls.Add(this.lv_Overview);
            this.Name = "DataAdministration";
            this.Text = "DataAdministration";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_Overview;
        private System.Windows.Forms.ColumnHeader col_CompanyNr;
        private System.Windows.Forms.ColumnHeader col_CompanyName;
        private System.Windows.Forms.ColumnHeader col_EmailAddress;
        private System.Windows.Forms.ColumnHeader col_edit_delete;
        private System.Windows.Forms.Button btn_newEntry;
    }
}

