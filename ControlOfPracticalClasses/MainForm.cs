using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace ControlOfPracticalClasses
{
    public partial class MainForm : Form
    {
        //
        #region //Настойки
        int CountChats = 30;//кол-во чатов
        int HeightChats = 50;//высота чата

        #endregion
        //

        //Панель для чатов
        TableLayoutPanel tableLayoutPanelListChats = new TableLayoutPanel();
        //TableLayoutPanel tableLayoutPanelMessage = new TableLayoutPanel();
        //TableLayoutPanel tableLayoutPanelMessageBottom = new TableLayoutPanel();
        //Panel panel = new Panel();
        //Button buttonTxt = new Button();
        //Button buttonSend = new Button();
        //TextBox messageRX = new TextBox();
        //TextBox messageTX = new TextBox();

        List<string> idChat = new List<string>();

        public MainForm(string idUser, string idGroup = "-1")
        {
            InitializeComponent();
            MyInitialize();
            this.Show();
            First();
            //SqlConnect.Connect();
            SqlQuery.IDUser = idUser;

            if (idGroup != "-1")
            {
                SqlQuery.IDGroup = idGroup;
            }
        }

        //
        #region //мои функции

        void MyInitialize()
        {
            //// 
            //// panel
            ////
            //panel.Dock = DockStyle.Fill;
            ////panel.BackColor = Color.AliceBlue;
            //ContainerRightAndLeft.Panel1.Controls.Add(panel);
            //panel.Controls.Add(tableLayoutPanelMessage);

            ////panel.BackColor = Color.Red;           
            //// 
            //// tableLayoutPanelMessage
            //// 
            //tableLayoutPanelMessage.ColumnCount = 1;
            //tableLayoutPanelMessage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            //tableLayoutPanelMessage.Controls.Add(buttonTxt, 0, 0);
            //tableLayoutPanelMessage.Controls.Add(messageRX, 0, 1);
            //tableLayoutPanelMessage.Controls.Add(tableLayoutPanelMessageBottom, 0, 2);
            //tableLayoutPanelMessage.Dock = DockStyle.Fill;
            //tableLayoutPanelMessage.Location = new Point(0, 0);
            //tableLayoutPanelMessage.Name = "tableLayoutPanelMessage";
            //tableLayoutPanelMessage.RowCount = 3;
            //tableLayoutPanelMessage.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            //tableLayoutPanelMessage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            //tableLayoutPanelMessage.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            //tableLayoutPanelMessage.Size = new Size(697, 561);
            //tableLayoutPanelMessage.TabIndex = 0;
            //// 
            //// buttonTxt
            //// 
            //buttonTxt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //buttonTxt.Dock = DockStyle.Fill;
            //buttonTxt.Enabled = false;
            //buttonTxt.FlatAppearance.BorderSize = 0;
            //buttonTxt.FlatStyle = FlatStyle.Flat;
            //buttonTxt.Font = new Font("Microsoft Sans Serif", 25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            //buttonTxt.Location = new Point(3, 3);
            //buttonTxt.Name = "buttonTxt";
            //buttonTxt.Size = new Size(691, 44);
            //buttonTxt.TabIndex = 0;
            //buttonTxt.Text = "txt";
            //buttonTxt.UseVisualStyleBackColor = true;
            //// 
            //// messageRX
            //// 
            //messageRX.Dock = DockStyle.Fill;
            //messageRX.Location = new Point(3, 53);
            //messageRX.Multiline = true;
            //messageRX.Name = "messageRX";
            //messageRX.Size = new Size(694, 405);
            //messageRX.TabIndex = 1;
            //// 
            //// tableLayoutPanelMessageBottom
            //// 
            //tableLayoutPanelMessageBottom.ColumnCount = 2;
            //tableLayoutPanelMessageBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.24561F));
            //tableLayoutPanelMessageBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.75439F));
            //tableLayoutPanelMessageBottom.Controls.Add(messageTX, 0, 0);
            //tableLayoutPanelMessageBottom.Controls.Add(buttonSend, 1, 0);
            //tableLayoutPanelMessageBottom.Dock = DockStyle.Fill;
            //tableLayoutPanelMessageBottom.Location = new Point(3, 464);
            //tableLayoutPanelMessageBottom.Name = "tableLayoutPanelMessageBottom";
            //tableLayoutPanelMessageBottom.RowCount = 1;
            //tableLayoutPanelMessageBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            //tableLayoutPanelMessageBottom.Size = new Size(694, 94);
            //tableLayoutPanelMessageBottom.TabIndex = 2;
            //// 
            //// messageTX
            //// 
            //messageTX.Dock = DockStyle.Fill;
            //messageTX.Location = new Point(3, 3);
            //messageTX.Multiline = true;
            //messageTX.Name = "messageTX";
            //messageTX.Size = new Size(502, 88);
            //messageTX.TabIndex = 0;


            //// 
            //// buttonSend
            //// 
            //buttonSend.Dock = DockStyle.Fill;
            //buttonSend.Location = new Point(511, 3);
            //buttonSend.Name = "buttonSend";
            //buttonSend.Size = new Size(180, 88);
            //buttonSend.TabIndex = 1;
            //buttonSend.Text = "buttonSend";
            //buttonSend.UseVisualStyleBackColor = true;

            //
            //tableLayoutPanelListChats
            //
            splitContainerChatsHeader.Panel2.Controls.Add(tableLayoutPanelListChats);
            tableLayoutPanelListChats.RowCount = CountChats;
            tableLayoutPanelListChats.Name = "tableLayoutPanelListChats";
            tableLayoutPanelListChats.Dock = DockStyle.Fill;
            tableLayoutPanelListChats.AutoScroll = true;
            //tableLayoutPanelListChats.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanelListChats.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth - 8, 0);
        }

        void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }

        //Обновление данных о посещаймости
        public void UpdateAttendance()
        {
            DataTable table = SqlQuery.ListDataAttendance;//получаем список дат занятий

            comboBoxDateAttendance.Items.Clear();//очищаем старые даты

            //записываем новые
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxDateAttendance.Items.Add(table.Rows[i].ItemArray[0]);
            }

            //Ставим активную дату
            if (comboBoxDateAttendance.Items.Count > 0)
            {
                comboBoxDateAttendance.Text = comboBoxDateAttendance.Items[0].ToString();
                comboBoxDateAttendance.Text = comboBoxDateAttendance.Text.Remove(10);
                SqlQuery.ActiveDate = comboBoxDateAttendance.Items[0].ToString();
            }
            else
            {
                SqlQuery.ActiveDate = "00.00.0000";
                comboBoxDateAttendance.Text = "";
            }

            //получаем список посещенией в активную дату
            DataAttendance.DataSource = SqlQuery.ListAttendance;

            //запрещаем изменять все столбцы кроме последнего
            for (int i = 0; i < DataAttendance.Columns.Count - 1; i++)
            {
                DataAttendance.Columns[i].ReadOnly = true;
            }
        }

        //Обновление данных об успеваймости
        public void UpdateProgress()
        {
            DataTable table = SqlQuery.ListStagesSubject;//получение списка этапов практики

            comboBoxStageSubject.Items.Clear();//очищаем от старых этпов

            //записываем новые
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxStageSubject.Items.Add(table.Rows[i].ItemArray[0]);
            }

            //Ставим активный этап
            if (comboBoxStageSubject.Items.Count > 0)
            {
                comboBoxStageSubject.Text = comboBoxStageSubject.Items[0].ToString();
                SqlQuery.StageSubjectName = comboBoxStageSubject.Items[0].ToString();

                DataTable tablet = SqlQuery.GetIdStageSubject;//получаем id этапа практики
                try
                {
                    SqlQuery.IDStageSubject = tablet.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                    FormError error = new FormError("Не удаеться получить ID этапа практики!");
                }
            }
            else
            {
                comboBoxStageSubject.Text = "";
                SqlQuery.StageSubjectName = "";
                SqlQuery.IDStageSubject = "";
            }

            //получаем список успеваймости в активный этап
            DataProgress.DataSource = SqlQuery.ListSubjectProgress;

            //запрещаем изменять все столбцы кроме последнего
            for (int i = 0; i < DataProgress.Columns.Count - 1; i++)
            {
                DataProgress.Columns[i].ReadOnly = true;
            }
        }

        //Скрыть все панели
        void DisplayNon()
        {
            for (int i = 0; i < ContainerRightAndLeft.Panel1.Controls.Count; i++)
            {
                ContainerRightAndLeft.Panel1.Controls[i].Visible = false;
            }
        }

        //Первоначальная настройка программы
        void First()
        {
            DisplayNon();

            DataTable table = new DataTable();

            // table = SqlConnect.Query("select distinct SubjectName from mysubject where IDTeacher = " + IDTeacher + ";");

            //PanelMessages.Visible = true;
            //PanelMessagesChats.Visible = true;
            //Test.Visible = true;//TOODO
            PanelSubject.Visible = true;//TOODO
        }

        #endregion
        //

        //
        #region //Правая панель

        //Посещения
        private void ButtonAttendance_Click(object sender, EventArgs e)
        {
            DisplayNon();

            UpdateAttendance();

            PanelAttendance.Visible = true;
        }

        //Обсуждения
        private void ButtonDiscussions_Click(object sender, EventArgs e)
        {
            DisplayNon();

            PanelDiscussions.Visible = true;
        }

        //Сообщения
        private void ButtonMessages_Click(object sender, EventArgs e)
        {
            DisplayNon();

            //очищаем список чатов
            tableLayoutPanelListChats.Controls.Clear();

            //очищаем id чатов
            idChat.Clear();

            DataTable table = SqlQuery.ListChatWithMe;//получение чатов в которых я участвую

            //добовление кнопок чатов 
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //Флаг для добавления
                bool f = true;

                //Создание кнопки для добовления
                Button btn = new Button();
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.CadetBlue;
                btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                btn.Dock = DockStyle.Fill;
                btn.Font = new Font("Microsoft Sans Serif", 12);
                btn.Margin = new Padding(SystemInformation.VerticalScrollBarWidth - 8, 5, 0, 5);
                btn.Click += EnterChat;

                //название чата
                if (table.Rows[i].ItemArray[2].ToString() == "0")
                {
                    btn.Text = SqlQuery.GetNameChat(table.Rows[i].ItemArray[0].ToString());
                }
                else
                {
                    btn.Text = table.Rows[i].ItemArray[1].ToString();
                }
                

                //Проверка на существование такого чата
                for (int j = 0; j < tableLayoutPanelListChats.Controls.Count; j++)
                {
                    if (tableLayoutPanelListChats.Controls[j].Text == btn.Text) f = false;
                }

                //Добаление чата
                if (f)
                {
                    tableLayoutPanelListChats.RowStyles.Add(new RowStyle(SizeType.Absolute, HeightChats));
                    tableLayoutPanelListChats.Controls.Add(btn);
                    idChat.Add(table.Rows[i].ItemArray[0].ToString());
                }
            }

            //for (int i = 0; i < CountChats; i++)
            //{
            //    tableLayoutPanelListChats.RowStyles.Add(new RowStyle(SizeType.Absolute, HeightChats));
            //}
            //

            label1.Text = tableLayoutPanelListChats.Controls.Count.ToString();

            PanelMessagesChats.Visible = true;
        }

        //Успеваймость
        private void ButtonProgress_Click(object sender, EventArgs e)
        {
            DisplayNon();

            UpdateProgress();

            PanelProgress.Visible = true;
        }

        //Расписание
        private void ButtonSchedule_Click(object sender, EventArgs e)
        {
            DisplayNon();

            PanelSchedule.Visible = true;
        }

        //Учебные материалы
        private void ButtonScienceContent_Click(object sender, EventArgs e)
        {
            DisplayNon();

            PanelScienceContent.Visible = true;
        }

        //Настройки
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            DisplayNon();

            PanelSettings.Visible = true;
        }

        //Практика
        private void ButtonSubject_Click(object sender, EventArgs e)
        {
            DisplayNon();

            DataTable table = new DataTable();

            table = SqlQuery.ListSubject;

            listBoxSubject.Items.Clear();
            listBoxGroup.Items.Clear();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                //Проверка на наличие такой практики
                if (-1 == listBoxSubject.FindStringExact(table.Rows[i].ItemArray[1].ToString()))
                    listBoxSubject.Items.Add(table.Rows[i].ItemArray[1]);// Добавление практики    
            }

            PanelSubject.Visible = true;
        }

        #endregion
        //

        //
        #region //Кнопки панели Успеваймость

        //Добавить этап
        private void ButtonAddColumnProgress_Click(object sender, EventArgs e)
        {
            FormAddStageSubject formAddStageSubject = new FormAddStageSubject(this);
        }

        //Удалить этап
        private void ButtonDeleteColumnProgress_Click(object sender, EventArgs e)
        {
            FormDelStageSubject formDelStageSubject = new FormDelStageSubject(this);
        }

        //Сохранить изменения
        private void ButtonSaveDataProgress_Click(object sender, EventArgs e)
        {
            SqlQuery.SaveProgress(DataProgress);
            UpdateProgress();
        }


        //Изменяет размер колонок под их содержимое
        private void DataProgress_Paint(object sender, PaintEventArgs e)
        {
            DataProgress.AutoResizeColumns();
        }

        //Записывает имя выбранного этапа практики
        private void comboBoxStageSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlQuery.StageSubjectName = comboBoxStageSubject.SelectedItem.ToString();

            DataTable table = SqlQuery.GetIdStageSubject;//получаем id этапа практики
            try
            {
                SqlQuery.IDStageSubject = table.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                FormError error = new FormError("Не удаеться получить ID этапа практики!");
            }

            DataProgress.DataSource = SqlQuery.ListSubjectProgress;
        }

        //Обнавляет данные при нажатии на выбор этапа
        private void comboBoxStageSubject_Click(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        #endregion
        //

        //
        #region //Кнопки панели посещения 

        //Сохранить изменения
        private void ButtonSaveData_Click(object sender, EventArgs e)
        {
            SqlQuery.SaveAttendance(DataAttendance);
            UpdateAttendance();
        }

        //Добавить дату
        private void ButtonAddColumn_Click(object sender, EventArgs e)
        {
            FormAddDate formAddDate = new FormAddDate(this);
        }

        //Удалить дату
        private void ButtonDeleteColumn_Click(object sender, EventArgs e)
        {
            FormDelDate formDelDate = new FormDelDate(this);
        }

        //Изменяет размер колонок под их содержимое
        private void DataAttendance_Paint(object sender, PaintEventArgs e)
        {
            DataAttendance.AutoResizeColumns();
        }

        //Записывает дату выбранного занятия
        private void comboBoxDateAttendance_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlQuery.ActiveDate = comboBoxDateAttendance.SelectedItem.ToString();
            DataAttendance.DataSource = SqlQuery.ListAttendance;
        }

        //Обнавляет данные при нажатии на выбор даты
        private void comboBoxDateAttendance_Click(object sender, EventArgs e)
        {
            UpdateAttendance();
        }

        #endregion
        //

        //
        #region //Панель практика

        private void SelectedSubject(object sender, EventArgs e)
        {
            try
            {
                SqlQuery.SubjectName = listBoxSubject.SelectedItem.ToString();//сохраняем название выбранной практики
                DataTable table = SqlQuery.ListGroup;//получаем список групп

                listBoxGroup.Items.Clear();

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    listBoxGroup.Items.Add(table.Rows[i].ItemArray[1]);
                }
            }
            catch (Exception)
            {


            }
        }

        private void SelectedGroup(object sender, EventArgs e)
        {
            try
            {
                SqlQuery.GroupName = listBoxGroup.SelectedItem.ToString();//сохраняем название выбранной группы
                DataTable table = SqlQuery.GetIdGroup;//получаем id группы

                try
                {
                    SqlQuery.IDGroup = table.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                    FormError error = new FormError("Не удаеться получить ID Группы!");
                }

                table = null;
                table = SqlQuery.GetIdSubject;//получаем id практики

                try
                {
                    SqlQuery.IDSubject = table.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                    FormError error = new FormError("Не удаеться получить ID Практики!");
                }
            }
            catch (Exception)
            {

            }
        }

        //Вызывает форму для добавления новой группы
        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            FormAddGroup formAddGroup = new FormAddGroup();
        }

        //Вызывает форму для добавления новой практики
        private void buttonAddSubject_Click(object sender, EventArgs e)
        {
            FormAddSubject formAddSubject = new FormAddSubject();
        }

        //Вызывает форму для удаления группы
        private void buttonDeleteGroup_Click(object sender, EventArgs e)
        {
            FormDelGroup formDelGroup = new FormDelGroup();
        }

        //Вызывает форму для удаления практики
        private void buttonDeleteSubject_Click(object sender, EventArgs e)
        {
            FormDelSubject formDelSubject = new FormDelSubject();
        }

        #endregion
        //

        //
        #region //Панель Сообщения(список чатов) 

        //Отправка сообщения
        private void buttonSend_Click(object sender, EventArgs e)
        {
            //Communication.TX(textBoxMessage.Text);
            //textBoxRX.Text += Environment.NewLine + "Я: " + textBoxMessage.Text;
            //textBoxMessage.Text = "";
        }

        //Получение сообщения
        private void getMessagee()
        {
            //while (true)
            //{
            //    string message;
            //    message = Communication.RXStart();
            //    textBoxRX.Text += Environment.NewLine + message;

            //    textBoxRX.SelectionStart = textBoxRX.Text.Length-1;
            //    textBoxRX.ScrollToCaret();
            //}
        }

        //Вызов окна определенного чата
        private void EnterChat(object sender, EventArgs e)
        {
            //buttonTxtChat.Text = tableLayoutPanelListChats.Controls[tableLayoutPanelListChats.Controls.GetChildIndex((Button)sender)].Text + " " + tableLayoutPanelListChats.Controls.GetChildIndex((Button)sender).ToString();

            //Заголовок чата
            buttonTxtChat.Text = tableLayoutPanelListChats.Controls[tableLayoutPanelListChats.Controls.GetChildIndex((Button)sender)].Text;

            //Установка id выбранного чата
            SqlQuery.IDChat = idChat[tableLayoutPanelListChats.Controls.GetChildIndex((Button)sender)];

            //Помещаем индекс выбранного чата на 1 место
            string c = idChat[tableLayoutPanelListChats.Controls.GetChildIndex((Button)sender)];
            idChat.Remove(idChat[tableLayoutPanelListChats.Controls.GetChildIndex((Button)sender)]);
            idChat.Insert(0, c);

            //Помещаем выбранный чат на 1 место
            tableLayoutPanelListChats.Controls.SetChildIndex((Button)sender, 0);

            //Очищаем текст бокс для отправки от написанных сообщений 
            textBoxTXMessage.Text = "";

            //Очищаем текст бокс для приема от сообщений 
            textBoxRX.Text = "";

            DisplayNon();
            PanelMessages.Visible = true;

            //получение всей переписки
            DataTable tableMessages = SqlQuery.GetFullMessageChat();

            //Дата последнего сообщения
            string lastDateMessage = "";

            //Сохроняем и Записыывем первую дату сообщений 
            if (tableMessages.Rows.Count > 0)
            {
                lastDateMessage = ((DateTime)tableMessages.Rows[0].ItemArray[3]).ToShortDateString();
                textBoxRX.Text = lastDateMessage + ":\r\n\r\n";
            }

            //Записывем все сообщения в текст бокс
            for (int i = 0; i < tableMessages.Rows.Count; i++)
            {
                //Получаем дату текущего сообщения
                string activeDate = ((DateTime)tableMessages.Rows[i].ItemArray[3]).ToShortDateString();

                //Если новая дата то выводим ее
                if (activeDate != lastDateMessage)
                {
                    lastDateMessage = activeDate;
                    textBoxRX.Text += "\r\n\r\n" + lastDateMessage + ":\r\n\r\n";
                }

                //Выводим сообщения
                textBoxRX.Text += MyFunction.GetNameFromFIO(tableMessages.Rows[i].ItemArray[2].ToString()) + ": " + tableMessages.Rows[i].ItemArray[1].ToString() + "\r\n";
            }            

        }

        //вызов формы для создания чата
        private void buttonAddChat_Click(object sender, EventArgs e)
        {
            FormAddChat formAddChat = new FormAddChat();
        }

        #endregion
        //

        //
        #region //Панель Сообщения(Переписка) 

            //Отправить сообщение
            private void buttonSend_Click_1(object sender, EventArgs e)
            {
                //Отправка сообщение 
                SqlQuery.SendMessage(textBoxTXMessage.Text, MyFunction.FlipShortDate(DateTime.Today.ToShortDateString()));

                //Очистка поля для ввода сообщения
                textBoxTXMessage.Text = "";
            }

        #endregion
        //

        //
        #region //Панель Настройки


        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox4.Text;
            dataGridView1.DataSource = SqlConnect.Query(str);

            dataGridView1.AutoResizeColumns();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DisplayNon();
            Test.Visible = true;
        }

        #endregion
        //

      

        //
        //Закрытие программы
        //
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SqlConnect.Disconnect();
            Program.Exit();
        }

        //
        #region //Панель Test
        //

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = SqlQuery.IDGroup;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = SqlQuery.GroupName;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = tableLayoutPanelListChats.Controls.Count.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DisplayNon();

            //panel.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = SqlQuery.IDSubject;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = SqlQuery.SubjectName;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = SqlQuery.ActiveDate;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = SqlQuery.StageSubjectName;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = SqlQuery.IDStageSubject;
        }

        int j = 0;
        private void button13_Click(object sender, EventArgs e)
        {
            //dateTimePicker1.CustomFormat = DateTimePickerFormat.Long.ToString();
            textBox1.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DataTable table = SqlQuery.ListGroupMates;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                textBox2.Text += table.Rows[i].ItemArray[0] + " " + table.Rows[i].ItemArray[1] + "\r\n";
            }
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DataAttendance.Rows.Count; i++)
            {
                textBox2.Text += DataAttendance.Rows[i].Cells[0].Value + " " + DataAttendance.Rows[i].Cells[3].Value + "\r\n";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            FormAddChat formAddChat = new FormAddChat();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            for (int i = 0; i < idChat.Count; i++)
            {
                textBox2.Text += idChat[i] + "\r\n";
            }
            textBox1.Text = idChat.Count.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string c = idChat[idChat.Count - 1];
            idChat.Remove(idChat[idChat.Count - 1]);
            idChat.Insert(0, c);

        }

        private void button19_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.CadetBlue;
            btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn.Dock = DockStyle.Fill;
            btn.Font = new Font("Microsoft Sans Serif", 12);
            btn.Margin = new Padding(SystemInformation.VerticalScrollBarWidth - 8, 5, 0, 5);
            btn.Click += EnterChat;

            tableLayoutPanelListChats.RowStyles.Add(new RowStyle(SizeType.Absolute, HeightChats));
            tableLayoutPanelListChats.Controls.Add(btn);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = SqlQuery.IDChat;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = MyFunction.FlipShortDate(DateTime.Today.ToShortDateString());
        }



        #endregion

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text = MyFunction.GetNameFromFIO(textBox2.Text);
        }
    }
}
