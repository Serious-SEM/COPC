namespace ControlOfPracticalClasses
{
    partial class FormDelSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDelSubject));
            this.dataGridViewListSubject = new System.Windows.Forms.DataGridView();
            this.comboBoxId = new System.Windows.Forms.ComboBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelList = new System.Windows.Forms.Label();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListSubject)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewListSubject
            // 
            this.dataGridViewListSubject.AllowUserToAddRows = false;
            this.dataGridViewListSubject.AllowUserToDeleteRows = false;
            this.dataGridViewListSubject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewListSubject.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewListSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridViewListSubject, "dataGridViewListSubject");
            this.dataGridViewListSubject.Name = "dataGridViewListSubject";
            this.dataGridViewListSubject.ReadOnly = true;
            // 
            // comboBoxId
            // 
            this.comboBoxId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxId.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxId, "comboBoxId");
            this.comboBoxId.Name = "comboBoxId";
            // 
            // labelId
            // 
            resources.ApplyResources(this.labelId, "labelId");
            this.labelId.Name = "labelId";
            // 
            // labelList
            // 
            resources.ApplyResources(this.labelList, "labelList");
            this.labelList.Name = "labelList";
            // 
            // buttonDel
            // 
            resources.ApplyResources(this.buttonDel, "buttonDel");
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormDelSubject
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.labelList);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.comboBoxId);
            this.Controls.Add(this.dataGridViewListSubject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormDelSubject";
            this.Load += new System.EventHandler(this.FormDelSubject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListSubject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewListSubject;
        private System.Windows.Forms.ComboBox comboBoxId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelList;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonCancel;
    }
}