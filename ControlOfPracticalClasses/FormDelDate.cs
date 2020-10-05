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
    public partial class FormDelDate : Form
    {
        MainForm form;

        public FormDelDate(MainForm f)
        {
            InitializeComponent();
            form = f;
            this.Show();
        }

        //загрузка данных
        private void FormDelDate_Load(object sender, EventArgs e)
        {
            DataTable table = SqlQuery.ListDataAttendance;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxdate.Items.Add(table.Rows[i].ItemArray[0]);
            }
        }

        //выход
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //удалить
        private void buttonDel_Click(object sender, EventArgs e)
        {
            SqlQuery.DelDateAttendance(comboBoxdate.Text);
            form.UpdateAttendance();
            this.Close();
        }
    }
}
