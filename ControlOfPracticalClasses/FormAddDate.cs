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
    public partial class FormAddDate : Form
    {
        MainForm form;

        public FormAddDate(MainForm f)
        {
            InitializeComponent();
            this.Show();
            form = f;
        }

        //выход
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //добавить
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SqlQuery.AddDateAttendance(dateTimePicker1.Value.ToShortDateString());
            form.UpdateAttendance();
            this.Close();
        }
    }
}
