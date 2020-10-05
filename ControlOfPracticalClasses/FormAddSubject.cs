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
    public partial class FormAddSubject : Form
    {
        bool fcorectSubjectName = false;
        bool fcorectGroupName = false;

        public FormAddSubject()
        {
            InitializeComponent();
            this.Show();
            getSubject();
            getGroup();
            CheckSubjectName();
            CheckGroupName();
        }

        #region //Проверка наличия имени практики
        private void CheckSubjectName()
        {
            string str = MyFunction.FixSpace(comboBoxSubjectName.Text);

            if (str == "")
            {
                comboBoxSubjectName.BackColor = Color.FromArgb(220, 140, 140);
            }
            else
            {
                comboBoxSubjectName.BackColor = Color.White;
                fcorectSubjectName = true;
            }
        }

        private void CheckSubjectName(object sender, EventArgs e)
        {
            CheckSubjectName();
        }

        private void CheckSubjectName1(object sender, EventArgs e)
        {
            CheckSubjectName();
        }
        #endregion

        #region //Проверка наличия имени группы
        private void CheckGroupName()
        {
            string str = MyFunction.FixSpace(comboBoxGroupName.Text);

            if (str == "")
            {
                comboBoxGroupName.BackColor = Color.FromArgb(220, 140, 140);
            }
            else
            {
                comboBoxGroupName.BackColor = Color.White;
                fcorectGroupName = true;
            }
        }

        private void CheckGroupName(object sender, EventArgs e)
        {
            CheckGroupName();
        }

        private void CheckGroupName1(object sender, EventArgs e)
        {
            CheckGroupName();
        }
        #endregion

        //получения списка существующих практик
        private void getSubject()
        {
            DataTable table = SqlQuery.GetListSubjectForCreate();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxSubjectName.Items.Add(table.Rows[i].ItemArray[0]);
            }            
        }

        //получения списка существующих групп
        private void getGroup()
        {
            DataTable table = SqlQuery.GetListGroupForCreate();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxGroupName.Items.Add(table.Rows[i].ItemArray[0]);
            }
        }

        //закрытие формы
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //создание практики
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (fcorectSubjectName && fcorectGroupName)
            {
                string subjectName = MyFunction.FixSpace(comboBoxSubjectName.Text);
                string GroupName = MyFunction.FixSpace(comboBoxGroupName.Text);
                string idGroup = SqlQuery.GetIdGroupForCreate(GroupName);
                string StrdateBegin = dateBegin.Value.ToShortDateString();
                string StrdateEnd = dateEnd.Value.ToShortDateString();

                SqlQuery.CreateSubject(subjectName, StrdateBegin, StrdateEnd, idGroup);
            }
            this.Close();
        }
    }
}
