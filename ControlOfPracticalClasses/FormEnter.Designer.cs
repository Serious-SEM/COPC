namespace ControlOfPracticalClasses
{
    partial class FormEnter
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
            this.components = new System.ComponentModel.Container();
            this.TextBoxLogin = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.LabelNameForm = new System.Windows.Forms.Label();
            this.LabelLogin = new System.Windows.Forms.Label();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.ButtonIn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxLogin
            // 
            this.TextBoxLogin.Location = new System.Drawing.Point(150, 93);
            this.TextBoxLogin.Name = "TextBoxLogin";
            this.TextBoxLogin.Size = new System.Drawing.Size(241, 20);
            this.TextBoxLogin.TabIndex = 0;
            this.TextBoxLogin.Text = "Techer@ucosu.ru";
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(150, 136);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(241, 20);
            this.TextBoxPassword.TabIndex = 1;
            this.TextBoxPassword.Text = "123456";
            // 
            // LabelNameForm
            // 
            this.LabelNameForm.AutoSize = true;
            this.LabelNameForm.Font = new System.Drawing.Font("Harlow Solid Italic", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNameForm.Location = new System.Drawing.Point(220, 32);
            this.LabelNameForm.Name = "LabelNameForm";
            this.LabelNameForm.Size = new System.Drawing.Size(88, 40);
            this.LabelNameForm.TabIndex = 2;
            this.LabelNameForm.Text = "Вход";
            // 
            // LabelLogin
            // 
            this.LabelLogin.AutoSize = true;
            this.LabelLogin.Location = new System.Drawing.Point(95, 96);
            this.LabelLogin.Name = "LabelLogin";
            this.LabelLogin.Size = new System.Drawing.Size(38, 13);
            this.LabelLogin.TabIndex = 3;
            this.LabelLogin.Text = "Логин";
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Location = new System.Drawing.Point(95, 139);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(45, 13);
            this.LabelPassword.TabIndex = 4;
            this.LabelPassword.Text = "Пароль";
            // 
            // ButtonIn
            // 
            this.ButtonIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(197)))), ((int)(((byte)(216)))));
            this.ButtonIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonIn.Location = new System.Drawing.Point(186, 197);
            this.ButtonIn.Name = "ButtonIn";
            this.ButtonIn.Size = new System.Drawing.Size(160, 46);
            this.ButtonIn.TabIndex = 5;
            this.ButtonIn.Text = "Войти";
            this.ButtonIn.UseVisualStyleBackColor = false;
            this.ButtonIn.Click += new System.EventHandler(this.ButtonIn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // FormEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 298);
            this.Controls.Add(this.ButtonIn);
            this.Controls.Add(this.LabelPassword);
            this.Controls.Add(this.LabelLogin);
            this.Controls.Add(this.LabelNameForm);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormEnter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxLogin;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label LabelNameForm;
        private System.Windows.Forms.Label LabelLogin;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.Button ButtonIn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}