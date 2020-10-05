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
    public partial class FormDelSubject : Form
    {
        public FormDelSubject()
        {
            InitializeComponent();
            this.Show();
        }

        //Загрузка данных
        private void FormDelSubject_Load(object sender, EventArgs e)
        {
            DataTable table = SqlQuery.GetListSubjectForDel();

            dataGridViewListSubject.DataSource = table;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxId.Items.Add(table.Rows[i].ItemArray[0]);
            }            
        }

        //Выход
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Удаление
        private void buttonDel_Click(object sender, EventArgs e)
        {
            SqlQuery.DelSubject(comboBoxId.Text);
            this.Close();
        }
    }
}
