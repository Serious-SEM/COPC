using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ControlOfPracticalClasses
{
    class SqlConnect
    {

        static string serverIP = "5.3.132.62";
        //static string serverIP = "192.168.0.102";
        static string userName = "remoteUser";
        static string bdName = "tcopc";
        static string port = "3306";
        static string password = "password";

        //Инфа для подключения к БД
        public static string connectInfo = "server = " + serverIP +
            ";user = " + userName +
            ";database = " + bdName +
            ";port = " + port +
            ";password = " + password + ";";

        //Объект для соединения с бд 
        static MySqlConnection sqlConnection = new MySqlConnection(connectInfo);

        //подключение к БД
        public static void Connect()
        {
            try
            {
                sqlConnection.Open();
            }
            catch (Exception e)
            {              
                MessageBox.Show("Не удается связаться с базой данных!");
                //FormError error = new FormError("Не удается связаться с базой данных!");
                //FormError error = new FormError(e.Message);               
            }           
        }

        //Проверяет открыто ли соединение
        public static bool isConnect()
        {
            if (ConnectionState.Open == sqlConnection.State) return true;
            else return false;
        }

        //Получение соединения с БД
        public static MySqlConnection getConnection()
        {
            return sqlConnection;
        }

        public static DataTable Query()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM students", sqlConnection);

            DataTable table = new DataTable();

            if (isConnect())
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(table);
                }
                catch (Exception)
                {
                    FormError error = new FormError("Не коректно заданный запрос!");
                }
                
            }

            return table;
        }

        //запрос с использованием своей команды
        public static DataTable Query(string str)
        {
            DataTable table = new DataTable();

            if (isConnect())
            {
                MySqlCommand command = new MySqlCommand(str, sqlConnection);

                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(table);
                }
                catch (Exception e)
                {
                    //FormError error = new FormError("Не коректно заданный запрос!");
                    // FormError error = new FormError(e.Message);
                    //MessageBox.Show(e.Message);
                }
            }

            return table;
        }

        //Отсоединение от БД
        public static void Disconnect()
        {
            if(sqlConnection.Ping())
                sqlConnection.Close();
        }

        ~SqlConnect()
        {
            Disconnect();
        }

    }
}

