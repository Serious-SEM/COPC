using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlOfPracticalClasses
{
    public partial class FormEnter : Form
    {
        MainForm form = null;
        DataTable login = new DataTable();
        public FormEnter()
        {
            InitializeComponent();
            this.Show();
            login = SqlConnect.Query("SELECT * FROM accounts;");


            //Добавление логинов и паролей в combobox
            for (int i = 0; i < login.Rows.Count; i++)
            {
                comboBox1.Items.Add(login.Rows[i].ItemArray[1]);
                comboBox2.Items.Add(login.Rows[i].ItemArray[2]);
            }
        }

        private void ButtonIn_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = 0; i < login.Rows.Count; i++)
            {
                if (TextBoxLogin.Text == login.Rows[i].ItemArray[1].ToString())
                {
                    if (TextBoxPassword.Text == login.Rows[i].ItemArray[2].ToString())
                    {
                        //Thread thread = new Thread(new ParameterizedThreadStart(this.Closing));

                        this.Hide();
                        form = new MainForm(login.Rows[i].ItemArray[0].ToString(), login.Rows[i].ItemArray[5].ToString());
                        form.Show();


                        return;
                    }
                }
            }
            FormError error = new FormError("Не верно введен логин или пароль!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = comboBox2.Items[comboBox1.SelectedIndex].ToString();

            TextBoxLogin.Text = comboBox1.Text;
            TextBoxPassword.Text = comboBox2.Text;
        }
    }
}
