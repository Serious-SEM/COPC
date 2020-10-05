namespace ControlOfPracticalClasses
{
    partial class FormAddGroup
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
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.textBoxListStudents = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelList = new System.Windows.Forms.Label();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGroupName.Location = new System.Drawing.Point(68, 40);
            this.textBoxGroupName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Size = new System.Drawing.Size(326, 26);
            this.textBoxGroupName.TabIndex = 0;
            this.textBoxGroupName.TextChanged += new System.EventHandler(this.CheckGroupName);
            // 
            // textBoxListStudents
            // 
            this.textBoxListStudents.Location = new System.Drawing.Point(68, 99);
            this.textBoxListStudents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxListStudents.Multiline = true;
            this.textBoxListStudents.Name = "textBoxListStudents";
            this.textBoxListStudents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxListStudents.Size = new System.Drawing.Size(326, 238);
            this.textBoxListStudents.TabIndex = 1;
            this.textBoxListStudents.WordWrap = false;
            this.textBoxListStudents.TextChanged += new System.EventHandler(this.CheckListStudents);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(123, 461);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(208, 35);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(123, 506);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(208, 35);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(64, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(139, 20);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Название группы";
            // 
            // labelList
            // 
            this.labelList.AutoSize = true;
            this.labelList.Location = new System.Drawing.Point(64, 74);
            this.labelList.Name = "labelList";
            this.labelList.Size = new System.Drawing.Size(147, 20);
            this.labelList.TabIndex = 5;
            this.labelList.Text = "Список студентов";
            // 
            // textBoxError
            // 
            this.textBoxError.Location = new System.Drawing.Point(68, 365);
            this.textBoxError.Multiline = true;
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.ReadOnly = true;
            this.textBoxError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxError.Size = new System.Drawing.Size(326, 88);
            this.textBoxError.TabIndex = 6;
            this.textBoxError.TabStop = false;
            this.textBoxError.WordWrap = false;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(64, 342);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(69, 20);
            this.labelError.TabIndex = 7;
            this.labelError.Text = "Ошибки";
            // 
            // FormAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 552);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.textBoxError);
            this.Controls.Add(this.labelList);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxListStudents);
            this.Controls.Add(this.textBoxGroupName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAddGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить группу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxGroupName;
        private System.Windows.Forms.TextBox textBoxListStudents;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelList;
        private System.Windows.Forms.TextBox textBoxError;
        private System.Windows.Forms.Label labelError;
    }
}