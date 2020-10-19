using ControlOfPracticalClasses.Properties;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Переделать получение Id
/// </summary>

//
//
//добавить удаление всех зависимых элементов
//добавить проверки на разрешение удалить практику или группу
//добавить проверки на добавление данных в БД
//добавить проверки на получение данных(id и т.д)
//в mygroup не должно быть объектов с одновременно повторяющимися GroupName
//в mysubject не должно быть объектов с одновременно повторяющимися SubjectName и IDGroup
//в atendance не должно быть объектов с одновременно повторяющимися Date IDSubject IDUser
//в StageSubject не должно быть объектов с одновременно повторяющимися StageSubjectName, IDSubject

//
//CHAT
//
//в Chat не должно быть объектов с одновременно повторяющимися name, creator_id
//при получении списка однагруппников исключить получение себя
//


namespace ControlOfPracticalClasses
{
    class SqlQuery
    {
        public static string IDUser { get; set; }
        public static string UserFIO { get; set; }

        public static string IDSubject { get; set; }
        public static string IDGroup { get; set; }
        public static string IDStageSubject { get; set; }
        public static string IDChat { get; set; }


        public static string GroupName { get; set; }
        public static string SubjectName { get; set; }
        public static string StageSubjectName { get; set; }


        private static string _ActiveDate = "";

        public static string ActiveDate { 
            get 
            {
                string s;
                if (_ActiveDate != "")
                {

                    s = _ActiveDate[6].ToString() +
                    _ActiveDate[7] +
                    _ActiveDate[8] +
                    _ActiveDate[9] +
                    '-' +
                    _ActiveDate[3] +
                    _ActiveDate[4] +
                    '-' +
                    _ActiveDate[0] +
                    _ActiveDate[1];


                }
                else
                {
                    s = "";
                }
                
                return s;

            }
            set { _ActiveDate = value; } }

        #region//tcopc

        //устанавливаем id группы
        private static void setIdGroup()
        {
            DataTable table = SqlConnect.Query("SELECT IDGroup FROM mygroup WHERE GroupName = '" + GroupName + "'; ");

            try
            {
                IDGroup = table.Rows[0].ItemArray[0].ToString();
            }
            catch
            {                
                MessageBox.Show("Не удалось установить ID Группы!");
            }
        }

        //устанавливаем id практики
        private static void setIdSubject()
        {
            DataTable table = SqlConnect.Query("SELECT IDSubject FROM mysubject WHERE (SubjectName = '" + SubjectName + "')and(IDGroup = " + IDGroup + ");");

            try
            {
                IDSubject = table.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
                MessageBox.Show("Не удалось установить ID Практики!");
            }
        }

        //сохраняем название выбранной группы
        public static void setGroupName(string name)
        {
            GroupName = name;//сохраняем название выбранной группы

            setIdGroup();//устанавливаем id группы

            setIdSubject();//устанавливаем id практики
        }


        //Получение id этапа практики
        public static DataTable GetIdStageSubject { get { return SqlConnect.Query("SELECT IDStageSubject FROM stagessubject WHERE (IDSubject = " + IDSubject + ") and (StageSubjectName = '" + StageSubjectName + "');"); } }


        //Список практик
        public static DataTable ListSubject { get { return SqlConnect.Query("SELECT IDSubject, SubjectName FROM mysubject WHERE IDTeacher = " + IDUser + ";"); } }
        //Список групп
        public static DataTable ListGroup { get { return SqlConnect.Query("SELECT mygroup.IDGroup, GroupName  FROM mygroup, mysubject WHERE (IDTeacher = " + IDUser + " and SubjectName = '" + SubjectName + "')and(mygroup.IDGroup = mysubject.IDGroup);"); } }
        //Список однагруппников
        public static DataTable ListGroupMates { get { return SqlConnect.Query("SELECT IDUser, FIO FROM accounts WHERE accounts.IDGroup = " + IDGroup + ";"); } }
        //Список однагруппников без меня
        public static DataTable ListGroupMatesWithoutMe { get { return SqlConnect.Query("SELECT IDUser, FIO FROM accounts WHERE accounts.IDGroup = '" + IDGroup + "' and IDUser != '" + IDUser + "';"); } }
        //Список дат занятий
        public static DataTable ListDataAttendance { get { return SqlConnect.Query("SELECT DISTINCT Date FROM attendance, accounts WHERE (IDSubject = '" + IDSubject + "') and (attendance.IDUser = accounts.IDUser) ORDER BY Date;"); } }
        //Список посещаймости группы определенной практики
        public static DataTable ListAttendance { get { return SqlConnect.Query("SELECT IDAttendance, Date, FIO, AttendancePoint FROM attendance, accounts WHERE (IDSubject = '" + IDSubject + "') and (attendance.IDUser = accounts.IDUser) and (Date = '" + ActiveDate + "') ORDER BY Date;"); } }
        //Список успеваймости практики
        public static DataTable ListSubjectProgress { get { return SqlConnect.Query("SELECT IDProgress, subjectprogress.Date, FIO, Progress FROM subjectprogress, stagessubject, accounts where (subjectprogress.IDStageSubject = '" + IDStageSubject + "') and (subjectprogress.IDStageSubject = stagessubject.IDStageSubject) and (subjectprogress.IDUser = accounts.IDUser);"); } }
        //Список этапов практики
        public static DataTable ListStagesSubject { get { return SqlConnect.Query("SELECT StageSubjectName FROM stagessubject WHERE stagessubject.IDSubject = '" + IDSubject + "';"); } }


        //Получает список всех практик для создания
        public static DataTable GetListSubjectForCreate()
        {
            return SqlConnect.Query("SELECT DISTINCT SubjectName FROM mysubject;");
        }

        //Получает список всех практик для удаления
        public static DataTable GetListSubjectForDel()
        {
            return SqlConnect.Query("SELECT IDSubject as ID, SubjectName, FIO, GroupName  FROM mysubject, accounts, mygroup where (IDTeacher = IDUser) and (mysubject.IDGroup = mygroup.IDGroup);");
        }

        //Получает список всех групп
        public static DataTable GetListGroupForCreate()
        {
            return SqlConnect.Query("SELECT GroupName FROM mygroup;");
        }

        //получение id Группы по имени
        public static string GetIdGroupForCreate(string name)
        {
            DataTable table =  SqlConnect.Query("SELECT IDGroup FROM mygroup WHERE GroupName = '" + name + "'; ");

            if (table.Rows.Count != 0) return table.Rows[0].ItemArray[0].ToString();
            return "-1";
        }

        //получение id этапа практики
        public static string GetIdStageSubjectForCreate(string name)
        {
            name = MyFunction.FixSpace(name);

            DataTable table = SqlConnect.Query("SELECT IDStageSubject FROM tcopc.stagessubject WHERE (StageSubjectName = '" + name + "') AND (IDSubject = " + IDSubject + ");");

            if (table.Rows.Count != 0) return table.Rows[0].ItemArray[0].ToString();
            return "-1";
        }

        //создание группы
        public static void CreateGroup(string name)
        {
            SqlConnect.Query("INSERT INTO mygroup (GroupName) VALUES('" + name + "')");

        }

        //создание практики
        public static void CreateSubject(string name, string dateBegin, string dateEnd, string idGroup)
        {
            dateBegin = ConvertDate(dateBegin);
            dateEnd = ConvertDate(dateEnd);
            SqlConnect.Query("INSERT INTO mysubject (SubjectName, SubjectDateBegin, SubjectDateEnd, IDGroup, IDTeacher) VALUES ('" + name + "', '" + dateBegin + "', '" + dateEnd + "', '" + idGroup + "', '" + IDUser + "');");

        }

        //добавление даты занятия
        public static void AddDateAttendance(string date)
        {
            date = ConvertDate(date);
            DataTable table = ListGroupMates;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                SqlConnect.Query("INSERT INTO attendance (Date, IDSubject, IDUser) VALUES ('" + date + "', '" + IDSubject + "', '" + table.Rows[i].ItemArray[0].ToString() + "');");
            }
        }

        //добавление этапа практики
        public static void AddStageSubject(string name) 
        {
            name = MyFunction.FixSpace(name);

            SqlConnect.Query("INSERT INTO stagessubject (StageSubjectName, IDSubject) VALUES ('" + name + "', '" + IDSubject + "');");

            string idStageSubject = GetIdStageSubjectForCreate(name);

            DataTable table = ListGroupMates;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                SqlConnect.Query("INSERT INTO subjectprogress (IDStageSubject, IDUser) VALUES ('" + idStageSubject + "', '" + table.Rows[i].ItemArray[0] + "');");
            }

        }

        //создание аккаунта для ученика
        public static void CreateStudentAccount(string login, string pas, string fio, string id)
        {
            SqlConnect.Query("INSERT INTO tcopc.accounts (Login, Password, FIO, Teacher, IDGroup) VALUES ('" + login  + "', '" + pas + "', '" + fio + "', '0', '" + id + "');");

        }

        //проверка логина на существование
        public static bool CheckLogin(string name) 
        {
            DataTable table = SqlConnect.Query("SELECT Login FROM accounts WHERE Login = '" + name + "';");

            if (table.Rows.Count != 0) return true;

            return false;
        }

        //Конвертирует дату для запроса
        public static string ConvertDate(string date)
        {
            string newDate = date[6].ToString() +
                    date[7] +
                    date[8] +
                    date[9] +
                    '-' +
                    date[3] +
                    date[4] +
                    '-' +
                    date[0] +
                    date[1];
            return newDate;
        }
        
        //Удаление группы
        public static void DelGroup(string idGroup)
        {
            SqlConnect.Query("DELETE FROM mygroup WHERE(IDGroup = '" + idGroup + "');");
        }

        //Удаление практики
        public static void DelSubject(string idSubject)
        {
            SqlConnect.Query("DELETE FROM mysubject WHERE(IDSubject = '" + idSubject + "');");
        }

        //удаление даты занятия
        public static void DelDateAttendance(string date)
        {
            date = ConvertDate(date);
            SqlConnect.Query("DELETE FROM attendance WHERE (IDSubject = '" + IDSubject + "') and (Date = '" + date + "');");
        }

        //удаление этапа практики
        public static void DelStageSubject(string nameStageSubject)
        {
            nameStageSubject = MyFunction.FixSpace(nameStageSubject);
            string idStageSubject = GetIdStageSubjectForCreate(nameStageSubject);
            SqlConnect.Query("DELETE FROM stagessubject WHERE (StageSubjectName = '" + nameStageSubject + "') and (IDSubject = '" + IDSubject + "') and (IDGroup = '" + IDGroup + "') and (IDTeacher = '" + IDUser + "');");
            SqlConnect.Query("DELETE FROM subjectprogress WHERE (IDStageSubject = '" + idStageSubject + "');");
        }

        //Сохраненине посещаймости
        public static void SaveAttendance(DataGridView grid)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                SqlConnect.Query("UPDATE attendance SET AttendancePoint = '" + grid.Rows[i].Cells[3].Value + "' WHERE (IDAttendance = '" + grid.Rows[i].Cells[0].Value + "')");
            }
        }

        //Сохраненине успеваймости
        public static void SaveProgress(DataGridView grid)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                SqlConnect.Query("UPDATE subjectprogress SET Progress = '" + grid.Rows[i].Cells[3].Value + "' WHERE (IDProgress = '" + grid.Rows[i].Cells[0].Value + "');");
            }
        }


        #endregion


        #region //чат

        //получение чатов в которых участвует пользователь
        public static DataTable ListChatWithMe { get { return SqlConnect.Query("SELECT party.chat_id, chat_name, many FROM party, chat where (party.chat_id = chat.chat_id) and (party.IDUser = '" + IDUser + "');"); } }

        //Получение id чата который тока что был создан
        public static string GetIdChat()
        {
            //chatName = MyFunction.FixSpace(chatName);

            DataTable table = SqlConnect.Query("SELECT chat_id FROM chat where (creator_id = '" + IDUser + "') ORDER BY chat_id DESC LIMIT 1;");

            if (table.Rows.Count != 0) return table.Rows[0].ItemArray[0].ToString();
            return "-1";
        }

        //Получение id последне отправленного сообщения
        public static string GetIdLastMessage()
        {
            DataTable table = SqlConnect.Query("SELECT message_id FROM message WHERE (chat_id = " + IDChat + " AND send_IDUser = " + IDUser + ") ORDER BY message_id DESC LIMIT 1;");

            if (table.Rows.Count != 0) return table.Rows[0].ItemArray[0].ToString();
            return "-1";
        }

        //Создание чата
        public static void CreateChat(List<string> party, string type, string chatName = "")
        {
            chatName = MyFunction.FixSpace(chatName);

            SqlConnect.Query("INSERT INTO chat (chat_name, creator_id, many) VALUES('" + chatName + "', '" + IDUser + "', '" + type + "');");

            string idChat = GetIdChat();

            SqlConnect.Query(" INSERT INTO party (chat_id, IDUser) VALUES('" + idChat + "', '" + IDUser + "');");

            for (int i = 0; i < party.Count; i++)
            {
                SqlConnect.Query(" INSERT INTO party (chat_id, IDUser) VALUES('" + idChat + "', '" + party[i] + "');");
            }         
        }     

        //Отправление сообщения
        public static void SendMessage(string mes, string date)
        {
            SqlConnect.Query("INSERT INTO message (content, date_create,chat_id, send_IDUser) VALUES ('" + mes + "','" + date + "','" + IDChat + "','" + IDUser + "');");

            string messageId = GetIdLastMessage();

            if (messageId != "-1")
            {
                SqlConnect.Query("INSERT INTO message_status (message_id, is_read) VALUES ('" + messageId + "', '0');");
            }
        }
                
        //Получение полной переписки
        public static DataTable GetFullMessageChat()
        {
           return SqlConnect.Query("SELECT message_id, content, FIO, date_create FROM tcopc.message, accounts WHERE chat_id = " + IDChat + " and send_IDUser = IDUser ORDER BY message_id;");
        }

        //Получение новых сообщений
        public static DataTable GetNewMessages(string idLastMessage)
        {
            DataTable table = SqlConnect.Query("SELECT message_id, content, FIO, date_create FROM message, accounts WHERE chat_id = " + IDChat + " and send_IDUser = IDUser and message_id > '" + idLastMessage + "' ORDER BY message_id;");

            return table;
        }

        //Получение названия личной переписки
        public static string GetNameChat(string idChat)
        {
            DataTable table = SqlConnect.Query("SELECT FIO FROM party, accounts where (chat_id = '" + idChat + "') and (accounts.IDUser = party.IDUser) and (accounts.IDUser != '" + IDUser + "');");

            if (table.Rows.Count != 0) return table.Rows[0].ItemArray[0].ToString();
            return "-1";
        }


        #endregion

    }
}
