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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ControlOfPracticalClasses
{
    public partial class MainForm : Form
    {
        public MainForm(string idUser, string idGroup = "-1")
        {
            InitializeComponent();

            //Инициализация моих компонентов
            MyInitialize();

            //Делаем видемой основную форму
            this.Show();

            //Приготовления при первом запуске
            First();

            //SqlConnect.Connect();
            SqlQuery.IDUser = idUser;

            if (idGroup != "-1")
            {
                SqlQuery.IDGroup = idGroup;
            }
        }

        //
        #region //Настойки высоты чатов
        int CountChats = 30;//кол-во чатов
        int HeightChats = 50;//высота чата

        #endregion 
        //

        //
        #region //переменные для сохранения инфы

        //Панель для чатов
        TableLayoutPanel tableLayoutPanelListChats = new TableLayoutPanel();

        //Класс с сохраннеными сообщениями
        ChatsSaveOnPC chatsSaveOnPC;

        //лист с таблицами сообщений
        private List<DataTable> massagesChats;

        //лист с id чатов
        List<string> idChat;

        //id последне полученного сообщения
        private string idLastMessage;

        //Дата последне полученного сообщения
        private string dateLastMessage;

        //id последне полученного чата
        private string idLastChat;

        #endregion
        //

        //
        #region //мои функции

        void MyInitialize()
        {     

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

        //получение новых сообщений
        void GetNewMessages()
        {
            int timeOld = 0;//переменная для таймера 1

            while (PanelMessages.Visible)
            {                
                int timeNew = DateTime.Now.Second;//переменная для таймера 2

                if (timeNew != timeOld)
                {
                    timeOld = timeNew;

                    DataTable tableMessages = SqlQuery.GetNewMessages(idLastMessage);

                    int IForOldMessageTable;

                    if (massagesChats[0].Rows.Count > 0)
                        IForOldMessageTable = massagesChats[0].Rows.Count - 1;                    
                        //IForOldMessageTable = massagesChats[0].Rows[massagesChats[0].Rows.Count - 1].ItemArray[0].ToString();                    
                    else
                        IForOldMessageTable = 0;

                    //Записывем все сообщения в текст бокс
                    for (int i = 0; i < tableMessages.Rows.Count; i++)
                    {
                        DataRow row = massagesChats[0].NewRow();

                        row.ItemArray = new object[] { 0, "", "", new DateTime()};

                        for (int j = 0; j < tableMessages.Columns.Count; j++)
                        {
                            row.ItemArray[j] = tableMessages.Rows[i].ItemArray[j];
                        }

                        massagesChats[0].Rows.Add(row);

                        IForOldMessageTable++;

                        //Получаем дату текущего сообщения
                        string activeDate = ((DateTime)tableMessages.Rows[i].ItemArray[3]).ToShortDateString();

                        //Если новая дата то выводим ее
                        if (activeDate != dateLastMessage)
                        {
                            dateLastMessage = activeDate;

                            this.Invoke(new Action(() =>
                            {
                                textBoxRX.Text += "\r\n\r\n" + dateLastMessage + ":\r\n\r\n";
                            }));
                        }

                        //имя того кто отправил сообщение
                        string nameSendUser = MyFunction.GetNameFromFIO(tableMessages.Rows[i].ItemArray[2].ToString());

                        //текст сообщения
                        string contentMessage = tableMessages.Rows[i].ItemArray[1].ToString();

                        this.Invoke(new Action(() =>
                        {
                            //Выводим сообщения
                            textBoxRX.Text += nameSendUser + ": " + contentMessage + "\r\n";
                        }));
                        
                        //Сохраняем id последнего сообщения
                        idLastMessage = tableMessages.Rows[i].ItemArray[0].ToString();
                                                                       
                    }

                    //прокрутка в конец textboxRX
                    this.Invoke(new Action(() =>
                    {
                        textBoxRX.SelectionStart = textBoxRX.Text.Length;
                        textBoxRX.ScrollToCaret();
                    }));
                }                
            }
        }

        void GetSaveMessage()
        {
            //Дата последнего сообщения
            string lastDateMessage = "";

            //Сохроняем и Записыывем первую дату сообщений 
            if (massagesChats[0].Rows.Count > 0)
            {
                //lastDateMessage = ((DateTime)massagesChats[0].Rows[0].ItemArray[3]).ToShortDateString();
                dateLastMessage = "00.00.0000";
                textBoxRX.Text = lastDateMessage + ":\r\n\r\n";
            }

            //Записывем все сообщения в текст бокс
            for (int i = 0; i < massagesChats[0].Rows.Count; i++)
            {
                //Получаем дату текущего сообщения
                //string activeDate = ((DateTime)massagesChats[0].Rows[i].ItemArray[3]).ToShortDateString();
                string activeDate = "00.00.0000";

                //Если новая дата то выводим ее
                if (activeDate != lastDateMessage)
                {
                    lastDateMessage = activeDate;
                    textBoxRX.Text += "\r\n\r\n" + lastDateMessage + ":\r\n\r\n";
                }

                //Выводим сообщения
                textBoxRX.Text += MyFunction.GetNameFromFIO(massagesChats[0].Rows[i].ItemArray[2].ToString()) + ": " + massagesChats[0].Rows[i].ItemArray[1].ToString() + "\r\n";
            }
        }

        //Обновление списка чатов
        public void UpdateChatsList()
        {
            //устонавливаем начальный id чата
            idLastChat = "0";

            //находим последний(максимальный) id чата
            for (int i = 0; i < idChat.Count; i++)
            {
                if (Convert.ToInt32(idLastChat) < Convert.ToInt32(idChat[i])) idLastChat = idChat[i];
            }

            ////очищаем список чатов
            //tableLayoutPanelListChats.Controls.Clear();

            ////очищаем id чатов
            //idChat.Clear();

            //DataTable table = SqlQuery.ListChatWithMe;//получение чатов в которых я участвую

            //Получаем новые чаты
            DataTable table = SqlQuery.GetNewChats(idLastChat);

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

                //название чата в зависимости от того беседа или нет
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
                    tableLayoutPanelListChats.Controls.SetChildIndex(btn, 0);

                    idChat.Insert(0, table.Rows[i].ItemArray[0].ToString());

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("1", Type.GetType("System.Int32"));
                    dataTable.Columns.Add("2", Type.GetType("System.String"));
                    dataTable.Columns.Add("3", Type.GetType("System.String"));
                    dataTable.Columns.Add("4", Type.GetType("System.DateTime"));
                    massagesChats.Insert(0, dataTable);
                }
            }

            //for (int i = 0; i < CountChats; i++)
            //{
            //    tableLayoutPanelListChats.RowStyles.Add(new RowStyle(SizeType.Absolute, HeightChats));
            //}
            //

            label1.Text = tableLayoutPanelListChats.Controls.Count.ToString();
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

            //дессериализация класса ChatsSaveOnPC
            try
            {
                FileStream stream = new FileStream("test.bin", FileMode.Open, FileAccess.Read);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                //дессериализация класса ChatsSaveOnPC
                chatsSaveOnPC = (ChatsSaveOnPC)binaryFormatter.Deserialize(stream);

                //дессериализация листа с таблицами сообщений
                massagesChats = chatsSaveOnPC.massagesChats;

                //дессериализация листа с id чатов
                idChat = chatsSaveOnPC.idChat;

                //дессериализация последне полученного сообщения
                //idLastMessage = chatsSaveOnPC.idLastMessage;

                //дессериализация последне полученного чата
                //idLastChat = chatsSaveOnPC.idLastChat;

                stream.Close();
            }
            catch
            {
                chatsSaveOnPC = new ChatsSaveOnPC(); //создание класса для сохранения данных о пересписках
                massagesChats = new List<DataTable>();//создание листа с таблицами сообщений
                idChat = new List<string>();//создание листа с id чатов
                idLastMessage = "0";//создание последне полученного сообщения
                idLastChat = "0";//создание последне полученного чата

            }

            //chatsSaveOnPC.ShowIdChat();

            //PanelMessages.Visible = true;
            //PanelMessagesChats.Visible = true;
            //Test.Visible = true;//TOODO
            PanelSubject.Visible = true;//TOODO
        }

        #endregion
        //

        //
        #region //Правая панель
 
        //Обсуждения
        private void ButtonDiscussions_Click(object sender, EventArgs e)
        {
            DisplayNon();

            PanelDiscussions.Visible = true;
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



        #endregion
        //

        //
        #region //Панель практика

        //Практика
        private void ButtonSubject_Click(object sender, EventArgs e)
        {
            DisplayNon();

            DataTable table = SqlQuery.ListSubject;

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

        //выбор практики
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

        //выбор группы
        private void SelectedGroup(object sender, EventArgs e)
        { 
            //Получаем имя выбранной группы
            string GroupName = listBoxGroup.SelectedItem.ToString();

            //сохраняем название выбранной группы
            SqlQuery.setGroupName(GroupName);  
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
        #region //Кнопки панели Успеваймость

        //Успеваймость
        private void ButtonProgress_Click(object sender, EventArgs e)
        {
            DisplayNon();

            UpdateProgress();

            PanelProgress.Visible = true;
        }

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

        //Посещения
        private void ButtonAttendance_Click(object sender, EventArgs e)
        {
            DisplayNon();

            UpdateAttendance();

            PanelAttendance.Visible = true;
        }

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
        #region //Панель Сообщения(список чатов) 

            //Сообщения
            private void ButtonMessages_Click(object sender, EventArgs e)
            {
                DisplayNon();

                //Обновление списка чатов
                UpdateChatsList();

                PanelMessagesChats.Visible = true;
            }

            //Вызов окна определенного чата
            private void EnterChat(object sender, EventArgs e)
                {
                    //индекс выбранного чата
                    int index = tableLayoutPanelListChats.Controls.GetChildIndex((Button)sender);

                    //Заголовок чата
                    buttonTxtChat.Text = tableLayoutPanelListChats.Controls[index].Text;

                    //Установка id выбранного чата
                    SqlQuery.IDChat = idChat[index];

                    //Помещаем индекс выбранного чата на 1 место
                    string temp1 = idChat[index];
                    idChat.Remove(idChat[index]);
                    idChat.Insert(0, temp1);

                    //Помещаем выбранный чат на 1 место
                    tableLayoutPanelListChats.Controls.SetChildIndex((Button)sender, 0);

                    //Помещаем таблицу сообщений на 1 место
                    DataTable temp2 = massagesChats[index];
                    massagesChats.Remove(massagesChats[index]);
                    massagesChats.Insert(0, temp2);

            
                    if (massagesChats[0].Rows.Count > 0)
                    {
                        //устанавливаем id последнего сообщения
                        idLastMessage = massagesChats[0].Rows[massagesChats[0].Rows.Count - 1].ItemArray[0].ToString();

                        //устанавливаем дату последнего сообщения
                        //dateLastMessage = ((DateTime)massagesChats[0].Rows[massagesChats[0].Rows.Count - 1].ItemArray[3]).ToShortDateString();
                        dateLastMessage = "00.00.0000";
                    }
                    else
                    {
                        //устанавливаем id последнего сообщения
                        idLastMessage = "0";

                        //устанавливаем дату последнего сообщения
                        dateLastMessage = "00.00.0000";
                    }

                    //Очищаем текст бокс для отправки от написанных сообщений 
                    textBoxTXMessage.Text = "";

                    //Очищаем текст бокс для приема от сообщений 
                    textBoxRX.Text = "";

                    DisplayNon();
                    PanelMessages.Visible = true;

                    //вывод сохранненых сообщений
                    //GetSaveMessage();

                    Thread thread = new Thread(new ThreadStart(GetNewMessages));            
                    thread.Start();                       

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

        //Настройки
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            DisplayNon();

            PanelSettings.Visible = true;
        }

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

            chatsSaveOnPC.PrepareSerializable(idChat, massagesChats);

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            FileStream stream = new FileStream("test.bin", FileMode.OpenOrCreate, FileAccess.Write);

            binaryFormatter.Serialize(stream, chatsSaveOnPC);

            stream.Close();

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
