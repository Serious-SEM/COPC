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
    public partial class FormDelGroup : Form
    {
        public FormDelGroup()
        {
            InitializeComponent();
            this.Show();
        }

        private void FormDelGroup_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tcopcDataSet.mygroup". При необходимости она может быть перемещена или удалена.
            this.mygroupTableAdapter.Fill(this.tcopcDataSet.mygroup);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tcopcDataSet.mygroup". При необходимости она может быть перемещена или удалена.
            this.mygroupTableAdapter.Fill(this.tcopcDataSet.mygroup);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tcopcDataSet.accounts". При необходимости она может быть перемещена или удалена.
            this.accountsTableAdapter.Fill(this.tcopcDataSet.accounts);

        }
        
        //Удаление группы
        private void buttonDel_Click(object sender, EventArgs e)
        {
            SqlQuery.DelGroup(comboBoxIdGroup.Text);
            this.Close();
        }

        //Выход
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
