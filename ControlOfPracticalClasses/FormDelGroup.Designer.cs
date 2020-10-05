namespace ControlOfPracticalClasses
{
    partial class FormDelGroup
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
            this.dataGridViewGroup = new System.Windows.Forms.DataGridView();
            this.iDGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mygroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tcopcDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tcopcDataSet = new ControlOfPracticalClasses.tcopcDataSet();
            this.accountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountsTableAdapter = new ControlOfPracticalClasses.tcopcDataSetTableAdapters.accountsTableAdapter();
            this.buttonDel = new System.Windows.Forms.Button();
            this.comboBoxIdGroup = new System.Windows.Forms.ComboBox();
            this.mygroupBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.labelId = new System.Windows.Forms.Label();
            this.labelList = new System.Windows.Forms.Label();
            this.mygroupTableAdapter = new ControlOfPracticalClasses.tcopcDataSetTableAdapters.mygroupTableAdapter();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mygroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcopcDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcopcDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mygroupBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGroup
            // 
            this.dataGridViewGroup.AllowUserToAddRows = false;
            this.dataGridViewGroup.AllowUserToDeleteRows = false;
            this.dataGridViewGroup.AutoGenerateColumns = false;
            this.dataGridViewGroup.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDGroupDataGridViewTextBoxColumn,
            this.GroupName});
            this.dataGridViewGroup.DataSource = this.mygroupBindingSource;
            this.dataGridViewGroup.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewGroup.Location = new System.Drawing.Point(13, 109);
            this.dataGridViewGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewGroup.Name = "dataGridViewGroup";
            this.dataGridViewGroup.ReadOnly = true;
            this.dataGridViewGroup.Size = new System.Drawing.Size(270, 341);
            this.dataGridViewGroup.TabIndex = 0;
            // 
            // iDGroupDataGridViewTextBoxColumn
            // 
            this.iDGroupDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.iDGroupDataGridViewTextBoxColumn.DataPropertyName = "IDGroup";
            this.iDGroupDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDGroupDataGridViewTextBoxColumn.Name = "iDGroupDataGridViewTextBoxColumn";
            this.iDGroupDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDGroupDataGridViewTextBoxColumn.Width = 51;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "GroupName";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // mygroupBindingSource
            // 
            this.mygroupBindingSource.DataMember = "mygroup";
            this.mygroupBindingSource.DataSource = this.tcopcDataSetBindingSource;
            // 
            // tcopcDataSetBindingSource
            // 
            this.tcopcDataSetBindingSource.DataSource = this.tcopcDataSet;
            this.tcopcDataSetBindingSource.Position = 0;
            // 
            // tcopcDataSet
            // 
            this.tcopcDataSet.DataSetName = "tcopcDataSet";
            this.tcopcDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountsBindingSource
            // 
            this.accountsBindingSource.DataMember = "accounts";
            this.accountsBindingSource.DataSource = this.tcopcDataSetBindingSource;
            // 
            // accountsTableAdapter
            // 
            this.accountsTableAdapter.ClearBeforeFill = true;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(84, 460);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(112, 35);
            this.buttonDel.TabIndex = 1;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // comboBoxIdGroup
            // 
            this.comboBoxIdGroup.DataSource = this.mygroupBindingSource1;
            this.comboBoxIdGroup.DisplayMember = "IDGroup";
            this.comboBoxIdGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIdGroup.FormattingEnabled = true;
            this.comboBoxIdGroup.Location = new System.Drawing.Point(13, 43);
            this.comboBoxIdGroup.Name = "comboBoxIdGroup";
            this.comboBoxIdGroup.Size = new System.Drawing.Size(270, 28);
            this.comboBoxIdGroup.TabIndex = 2;
            // 
            // mygroupBindingSource1
            // 
            this.mygroupBindingSource1.DataMember = "mygroup";
            this.mygroupBindingSource1.DataSource = this.tcopcDataSetBindingSource;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(9, 20);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(84, 20);
            this.labelId.TabIndex = 3;
            this.labelId.Text = "ID Группы";
            // 
            // labelList
            // 
            this.labelList.AutoSize = true;
            this.labelList.Location = new System.Drawing.Point(9, 84);
            this.labelList.Name = "labelList";
            this.labelList.Size = new System.Drawing.Size(63, 20);
            this.labelList.TabIndex = 4;
            this.labelList.Text = "Список";
            // 
            // mygroupTableAdapter
            // 
            this.mygroupTableAdapter.ClearBeforeFill = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(84, 503);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormDelGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 550);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelList);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.comboBoxIdGroup);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.dataGridViewGroup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormDelGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаление группы";
            this.Load += new System.EventHandler(this.FormDelGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mygroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcopcDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcopcDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mygroupBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGroup;
        private System.Windows.Forms.BindingSource tcopcDataSetBindingSource;
        private tcopcDataSet tcopcDataSet;
        private System.Windows.Forms.BindingSource accountsBindingSource;
        private tcopcDataSetTableAdapters.accountsTableAdapter accountsTableAdapter;
        private System.Windows.Forms.BindingSource mygroupBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.ComboBox comboBoxIdGroup;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelList;
        private System.Windows.Forms.BindingSource mygroupBindingSource1;
        private tcopcDataSetTableAdapters.mygroupTableAdapter mygroupTableAdapter;
        private System.Windows.Forms.Button buttonCancel;
    }
}