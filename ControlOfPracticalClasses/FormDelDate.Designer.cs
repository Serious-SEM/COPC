namespace ControlOfPracticalClasses
{
    partial class FormDelDate
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.labeldate = new System.Windows.Forms.Label();
            this.comboBoxdate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(88, 135);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(157, 49);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(88, 80);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(157, 49);
            this.buttonDel.TabIndex = 6;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // labeldate
            // 
            this.labeldate.AutoSize = true;
            this.labeldate.Location = new System.Drawing.Point(18, 15);
            this.labeldate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labeldate.Name = "labeldate";
            this.labeldate.Size = new System.Drawing.Size(116, 20);
            this.labeldate.TabIndex = 5;
            this.labeldate.Text = "Удалить дату";
            // 
            // comboBoxdate
            // 
            this.comboBoxdate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxdate.FormattingEnabled = true;
            this.comboBoxdate.Location = new System.Drawing.Point(22, 38);
            this.comboBoxdate.Name = "comboBoxdate";
            this.comboBoxdate.Size = new System.Drawing.Size(298, 28);
            this.comboBoxdate.TabIndex = 8;
            // 
            // FormDelDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 198);
            this.Controls.Add(this.comboBoxdate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.labeldate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormDelDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаление даты занятия";
            this.Load += new System.EventHandler(this.FormDelDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Label labeldate;
        private System.Windows.Forms.ComboBox comboBoxdate;
    }
}