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
    public partial class FormAddChat : Form
    {
        public FormAddChat()
        {
            InitializeComponent();
            this.Show();
        }

        DataTable table;

        //загрузка данных
        private void FormAddChat_Load(object sender, EventArgs e)
        {
            table = SqlQuery.ListGroupMatesWithoutMe;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                checkedListBoxParty.Items.Add(table.Rows[i].ItemArray[1]);                
            }      
        }

        //запрещает выбор нескольких элементов если radioButtonPrivate = true
        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (checkedListBoxParty.CheckedItems.Count > 1 && radioButtonPrivate.Checked)
            {
                try
                {
                    checkedListBoxParty.SetItemCheckState(checkedListBoxParty.SelectedIndex, CheckState.Unchecked);
                }
                catch
                {

                } 
            }
        }

        //запрещает выбор нескольких элементов если radioButtonPrivate = true
        private void checkedListBox1_DoubleClick(object sender, EventArgs e)
        {
            if (checkedListBoxParty.CheckedItems.Count > 1 && radioButtonPrivate.Checked)
            {
                try
                {
                    checkedListBoxParty.SetItemCheckState(checkedListBoxParty.SelectedIndex, CheckState.Unchecked);
                }
                catch
                {

                }
            }
        }

        //снимает все выбранные элементы если radioButtonPrivate становиться true
        private void radioButtonPrivate_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPrivate.Checked)
            {
                textBoxChatName.Enabled = false;
                for (int i = 0; i < checkedListBoxParty.Items.Count; i++)
                {
                    checkedListBoxParty.SetItemCheckState(i, CheckState.Unchecked);
                    checkedListBoxParty.SetSelected(i, false);
                }
            }
            else textBoxChatName.Enabled = true;
                      
        }

        //выход
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //создание чата
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            List<string> party = new List<string>();

            foreach (var item in checkedListBoxParty.CheckedIndices)
            {
                party.Add(table.Rows[Convert.ToInt32(item.ToString())].ItemArray[0].ToString());
            }

            if(radioButtonPrivate.Checked)
                SqlQuery.CreateChat(party, "0");
            else
                SqlQuery.CreateChat(party, "1", textBoxChatName.Text);

            this.Close();
        }
    }
}
