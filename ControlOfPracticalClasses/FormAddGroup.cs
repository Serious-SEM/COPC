using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlOfPracticalClasses
{
    public partial class FormAddGroup : Form
    {
        List<int> listError = new List<int>();

        bool fcorectGroupName = false;
        bool fcorectListStudents = false;

        public FormAddGroup()
        {
            InitializeComponent();
            this.Show();
            CheckGroupName();
            CheckListStudents();
        }

        private void CheckGroupName()
        {
            string error = "Незаполненно поле 'Название группы'!" + "\r\n";

            textBoxGroupName.Text = MyFunction.FixSpace(textBoxGroupName.Text);

            if (textBoxGroupName.Text == "")
            {
                textBoxGroupName.BackColor = Color.FromArgb(220, 140, 140);
                textBoxError.Text += error;
                fcorectGroupName = false;
            }
            else
            {
                textBoxGroupName.BackColor = Color.White;
                textBoxError.Text = textBoxError.Text.Replace(error, "");
                fcorectGroupName = true;
            }
        }

        private void CheckGroupName(object sender, EventArgs e)
        {
            CheckGroupName();
        }

        private void CheckListStudents()
        {
            fcorectListStudents = true;

            //Удаляем все ошибки связанные с ФИО студентов
            for (int i = 0; i < listError.Count; i++)
            {
                textBoxError.Text = Regex.Replace(textBoxError.Text, @".*" + listError[i] + "\r\n", "");
                listError.RemoveAt(i--);                    
            }     

            //Проверяем есть ли студенты
            if (textBoxListStudents.Lines.Length != 0)
            {                   
                //Проверяем ФИО на ошибки и выводим их
                for (int i = 0; i < textBoxListStudents.Lines.Length; i++)
                {                 
                    if (!MyFunction.CheckFIO(MyFunction.FixSpace(textBoxListStudents.Lines[i])))
                    {
                        fcorectListStudents = false;
                        listError.Add(i + 1);
                        textBoxError.Text += "Допущена ошибка в ФИО студента '" + textBoxListStudents.Lines[i] + "' Строка " + (i+1).ToString() + "\r\n";
                    }
                }

                //если есть ошибки подсвечиваем окно красным
                if (!fcorectListStudents)
                    textBoxListStudents.BackColor = Color.FromArgb(220, 140, 140);
                else
                    textBoxListStudents.BackColor = Color.White;
            }
            else
            {
                textBoxListStudents.BackColor = Color.White;
            }
                      
        }

        private void CheckListStudents(object sender, EventArgs e)
        {
            CheckListStudents();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string GroupName = textBoxGroupName.Text;
            string GroupId;


            if (fcorectGroupName && fcorectListStudents)
            {
                SqlQuery.CreateGroup(GroupName);

                GroupId = SqlQuery.GetIdGroupForCreate(GroupName);

                for (int i = 0; i < textBoxListStudents.Lines.Length; i++)
                {
                    int j = 1;

                    string password = MyFunction.GetPassword(textBoxListStudents.Lines[i]);
                    string login = MyFunction.GetLogin(textBoxListStudents.Lines[i]);

                    do
                    {
                        login = MyFunction.GetLogin(textBoxListStudents.Lines[i]) + j.ToString();
                        if (!SqlQuery.CheckLogin(login)) break;
                        j++;
                    } while (j<100);                                                            

                    SqlQuery.CreateStudentAccount(login, password, MyFunction.FixSpace(textBoxListStudents.Lines[i]), GroupId);
                }
            }

            this.Close();
        }
 
    }
}
