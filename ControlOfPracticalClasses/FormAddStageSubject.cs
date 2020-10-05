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
    public partial class FormAddStageSubject : Form
    {
        MainForm form;

        public FormAddStageSubject(MainForm f)
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

        //добавление этапа практики
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SqlQuery.AddStageSubject(textBoxStageSubjectName.Text);
            form.UpdateProgress();
            this.Close();
        }
    }
}
