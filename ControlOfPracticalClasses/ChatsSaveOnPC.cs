using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlOfPracticalClasses
{
    [Serializable]
    public class ChatsSaveOnPC
    {
        //id последне полученного сообщения
        //public string idLastMessage { get; private set; } = "0";

        //id последне полученного чата
        //public string idLastChat { get; private set; } = "0";

        //лист с таблицами сообщений
        public List<DataTable> massagesChats { get; private set; } = new List<DataTable>();
        //лист с id чатов
        public List<string> idChat { get; private set; } = new List<string>();

        public ChatsSaveOnPC()
        {
            MyInitialize();
        }

        //подготовка к сериализации
        public void PrepareSerializable(List<string> idChat, List<DataTable> massagesChats)
        {
            this.idChat = idChat;
            this.massagesChats = massagesChats;
            //this.idLastChat = idLastChat;
            //this.idLastMessage = idLastMessage;
        }

        public void MyInitialize()
        {
          
        }

        public void ShowIdChat()
        {
            string s = "";

            for (int i = 0; i < idChat.Count; i++)
            {
                s += idChat[i] + "\r\n";
            }
            MessageBox.Show(s);
        }

        public void addIdChat(string id)
        {
            idChat.Add(id);
        }

        public void moveChatOnFirstPlace(Button btn)
        {
            //индекс визуальной кнопки чата
            //int index = tableLayoutPanelListChats.Controls.GetChildIndex(btn);

            ////Установка id выбранного чата
            //SqlQuery.IDChat = idChat[index];

            ////Помещаем индекс выбранного чата на 1 место
            //string temp = idChat[index];
            //idChat.Remove(idChat[index]);
            //idChat.Insert(0, temp);
        }

    }


}
