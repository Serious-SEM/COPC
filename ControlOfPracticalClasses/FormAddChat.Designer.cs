namespace ControlOfPracticalClasses
{
    partial class FormAddChat
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
            this.textBoxChatName = new System.Windows.Forms.TextBox();
            this.labelChatName = new System.Windows.Forms.Label();
            this.radioButtonPrivate = new System.Windows.Forms.RadioButton();
            this.radioButtonChat = new System.Windows.Forms.RadioButton();
            this.checkedListBoxParty = new System.Windows.Forms.CheckedListBox();
            this.labelParty = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxChatName
            // 
            this.textBoxChatName.Enabled = false;
            this.textBoxChatName.Location = new System.Drawing.Point(14, 133);
            this.textBoxChatName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxChatName.Name = "textBoxChatName";
            this.textBoxChatName.Size = new System.Drawing.Size(350, 26);
            this.textBoxChatName.TabIndex = 0;
            // 
            // labelChatName
            // 
            this.labelChatName.AutoSize = true;
            this.labelChatName.Location = new System.Drawing.Point(16, 108);
            this.labelChatName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChatName.Name = "labelChatName";
            this.labelChatName.Size = new System.Drawing.Size(123, 20);
            this.labelChatName.TabIndex = 1;
            this.labelChatName.Text = "Название чата";
            // 
            // radioButtonPrivate
            // 
            this.radioButtonPrivate.AutoSize = true;
            this.radioButtonPrivate.Checked = true;
            this.radioButtonPrivate.Location = new System.Drawing.Point(6, 25);
            this.radioButtonPrivate.Name = "radioButtonPrivate";
            this.radioButtonPrivate.Size = new System.Drawing.Size(172, 24);
            this.radioButtonPrivate.TabIndex = 2;
            this.radioButtonPrivate.TabStop = true;
            this.radioButtonPrivate.Text = "личные сообщения";
            this.radioButtonPrivate.UseVisualStyleBackColor = true;
            this.radioButtonPrivate.CheckedChanged += new System.EventHandler(this.radioButtonPrivate_CheckedChanged);
            // 
            // radioButtonChat
            // 
            this.radioButtonChat.AutoSize = true;
            this.radioButtonChat.Location = new System.Drawing.Point(6, 55);
            this.radioButtonChat.Name = "radioButtonChat";
            this.radioButtonChat.Size = new System.Drawing.Size(82, 24);
            this.radioButtonChat.TabIndex = 3;
            this.radioButtonChat.Text = "беседа";
            this.radioButtonChat.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxParty
            // 
            this.checkedListBoxParty.CheckOnClick = true;
            this.checkedListBoxParty.FormattingEnabled = true;
            this.checkedListBoxParty.HorizontalScrollbar = true;
            this.checkedListBoxParty.Location = new System.Drawing.Point(14, 187);
            this.checkedListBoxParty.Name = "checkedListBoxParty";
            this.checkedListBoxParty.Size = new System.Drawing.Size(352, 235);
            this.checkedListBoxParty.TabIndex = 4;
            this.checkedListBoxParty.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged_1);
            this.checkedListBoxParty.DoubleClick += new System.EventHandler(this.checkedListBox1_DoubleClick);
            // 
            // labelParty
            // 
            this.labelParty.AutoSize = true;
            this.labelParty.Location = new System.Drawing.Point(15, 164);
            this.labelParty.Name = "labelParty";
            this.labelParty.Size = new System.Drawing.Size(89, 20);
            this.labelParty.TabIndex = 6;
            this.labelParty.Text = "Участники";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(132, 437);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(105, 47);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(132, 490);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(105, 47);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonChat);
            this.groupBox1.Controls.Add(this.radioButtonPrivate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 93);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид чата";
            // 
            // FormAddChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.labelParty);
            this.Controls.Add(this.checkedListBoxParty);
            this.Controls.Add(this.labelChatName);
            this.Controls.Add(this.textBoxChatName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAddChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание чата";
            this.Load += new System.EventHandler(this.FormAddChat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxChatName;
        private System.Windows.Forms.Label labelChatName;
        private System.Windows.Forms.RadioButton radioButtonPrivate;
        private System.Windows.Forms.RadioButton radioButtonChat;
        private System.Windows.Forms.CheckedListBox checkedListBoxParty;
        private System.Windows.Forms.Label labelParty;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}