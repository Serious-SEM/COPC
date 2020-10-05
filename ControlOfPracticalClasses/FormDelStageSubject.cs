using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlOfPracticalClasses
{
    public partial class FormDelStageSubject : Form
    {
        MainForm form;

        public FormDelStageSubject(MainForm f)
        {
            InitializeComponent();
            this.Show();
            form = f;
        }

        //загрузка данных
        private void FormDelStageSubject_Load(object sender, EventArgs e)
        {
            DataTable table = SqlQuery.ListStagesSubject;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxStageSubject.Items.Add(table.Rows[i].ItemArray[0]);
            }
        }

        //выход
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //удаление
        private void buttonDel_Click(object sender, EventArgs e)
        {
            SqlQuery.DelStageSubject(comboBoxStageSubject.Text);
            form.UpdateProgress();
            this.Close();
        }
    }
}
