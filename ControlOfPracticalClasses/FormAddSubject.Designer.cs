namespace ControlOfPracticalClasses
{
    partial class FormAddSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddSubject));
            this.comboBoxSubjectName = new System.Windows.Forms.ComboBox();
            this.labelSubjectName = new System.Windows.Forms.Label();
            this.dateBegin = new System.Windows.Forms.DateTimePicker();
            this.labelDateBegin = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.labelDateEnd = new System.Windows.Forms.Label();
            this.comboBoxGroupName = new System.Windows.Forms.ComboBox();
            this.labelGroupName = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxSubjectName
            // 
            this.comboBoxSubjectName.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxSubjectName, "comboBoxSubjectName");
            this.comboBoxSubjectName.Name = "comboBoxSubjectName";
            this.comboBoxSubjectName.SelectedIndexChanged += new System.EventHandler(this.CheckSubjectName);
            this.comboBoxSubjectName.TextUpdate += new System.EventHandler(this.CheckSubjectName1);
            // 
            // labelSubjectName
            // 
            resources.ApplyResources(this.labelSubjectName, "labelSubjectName");
            this.labelSubjectName.Name = "labelSubjectName";
            // 
            // dateBegin
            // 
            resources.ApplyResources(this.dateBegin, "dateBegin");
            this.dateBegin.Name = "dateBegin";
            // 
            // labelDateBegin
            // 
            resources.ApplyResources(this.labelDateBegin, "labelDateBegin");
            this.labelDateBegin.Name = "labelDateBegin";
            // 
            // dateEnd
            // 
            resources.ApplyResources(this.dateEnd, "dateEnd");
            this.dateEnd.Name = "dateEnd";
            // 
            // labelDateEnd
            // 
            resources.ApplyResources(this.labelDateEnd, "labelDateEnd");
            this.labelDateEnd.Name = "labelDateEnd";
            // 
            // comboBoxGroupName
            // 
            this.comboBoxGroupName.BackColor = System.Drawing.Color.White;
            this.comboBoxGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxGroupName, "comboBoxGroupName");
            this.comboBoxGroupName.FormattingEnabled = true;
            this.comboBoxGroupName.Name = "comboBoxGroupName";
            this.comboBoxGroupName.SelectedIndexChanged += new System.EventHandler(this.CheckGroupName);
            this.comboBoxGroupName.TextUpdate += new System.EventHandler(this.CheckGroupName1);
            // 
            // labelGroupName
            // 
            resources.ApplyResources(this.labelGroupName, "labelGroupName");
            this.labelGroupName.Name = "labelGroupName";
            // 
            // buttonAdd
            // 
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormAddSubject
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelGroupName);
            this.Controls.Add(this.comboBoxGroupName);
            this.Controls.Add(this.labelDateEnd);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.labelDateBegin);
            this.Controls.Add(this.dateBegin);
            this.Controls.Add(this.labelSubjectName);
            this.Controls.Add(this.comboBoxSubjectName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAddSubject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSubjectName;
        private System.Windows.Forms.Label labelSubjectName;
        private System.Windows.Forms.DateTimePicker dateBegin;
        private System.Windows.Forms.Label labelDateBegin;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label labelDateEnd;
        private System.Windows.Forms.ComboBox comboBoxGroupName;
        private System.Windows.Forms.Label labelGroupName;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
    }
}