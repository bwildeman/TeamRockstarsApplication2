using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;


//using MySql.Data.MySqlClient;

namespace TRS_Logic
{
    public class ClientClass
    {
        public static Socket master;
        public string name;
        public string id;
        public int SenderId;
        public int chatindex;
        public int loginid;
        public List<TRS_Domain.CHAT.Message> ChatList = new List<TRS_Domain.CHAT.Message>();
        public List<TRS_Domain.CHAT.Message> NewMsg = new List<TRS_Domain.CHAT.Message>();
        public bool IsDone = false;
        public bool IsLoading = false;
        public bool NewMsgLoad = false;
        public bool loginstate = false;
        ChatLogic chatLogic = new ChatLogic();
        TRS_Domain.USER.Data _client;
        ControllerLogin _loginlogic = new ControllerLogin();
        public void LoadIn()
        {
            string ip = "127.0.0.1";

            master = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(ip), 4242);
            
            try
            {
                master.Connect(ipe);
                Console.WriteLine("connected");
                Thread t = new Thread(Data_IN);
                t.Start();
                
            }
            catch
            {
                Console.WriteLine("Could not connect");
                Thread.Sleep(1000);
            }        
        }

        public void GetPersonInfo(TRS_Domain.USER.Data data)
        {
            _client = data;
        }


        public void LoadChat(int Chatid)
        {
            bool state = true;
            while (state == true)
            {
                if (id != null)
                {
                    Console.WriteLine("Loading Chat");
                    Packet p = new Packet(PacketType.GetAllChat, id, Chatid);
                    p.senderID = id;
                    p.Gdata.Add(id);
                    p.Gdata.Add(Convert.ToString(Chatid));
                    p.groupid = Chatid;
                    master.Send(p.ToBytes());
                    state = false;
                }
            }
        }

        public void GetForm(Form form)
        {
            
        }

        public List<TRS_Domain.CHAT.Message> LoadinChat()
        {
            return ChatList;
        }

        public int GetLoginId()
        {
            return loginid;
        }

        public void ClearList()
        {
            ChatList.Clear();
            IsDone = false;
        }

        public void ClearMsgList()
        {
            NewMsg.Clear();
        }

        public List<TRS_Domain.CHAT.Message> AddNewMsg()
        {
            return NewMsg;
        }

        public void Msg(string text,int chatindex)
        {

                this.chatindex = chatindex;
                string input = text;
                Packet p = new Packet(PacketType.Chat, id,chatindex);
                p.Gdata.Add(_client.Name + " " + _client.Surname);
                p.Gdata.Add(input);
                p.Gdata.Add(Convert.ToString(chatindex));
                p.Gdata.Add(Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")));
                master.Send(p.ToBytes());
            
        }

        public void Login(string email, string password)
        {
            Packet p = new Packet(PacketType.Login,id);
            p.Gdata.Add(email);
            p.Gdata.Add(password);
            master.Send(p.ToBytes());
        }

        public void Data_IN()
        {
            byte[] Buffer;
            int readByte;

            while (true)
            {
                Buffer = new byte[master.SendBufferSize];
                readByte = master.Receive(Buffer);
                if (readByte > 0) 
                {
                    DataManeger(new Packet(Buffer));
                }
            }
        }


        public void DataManeger(Packet p)
        {
            switch (p.packetType)
            {
                case PacketType.Registration:
                    id = p.Gdata[0];
                    Console.WriteLine("Connected id: " + id);
                    IsLoading = true;
                    break;

                case PacketType.Chat:
                            if (Convert.ToInt32(p.Gdata[2]) == chatindex)
                            {
                                NewMsg.Add(new TRS_Domain.CHAT.Message(p.Gdata[0],p.Gdata[1],p.Gdata[3]));
                                chatLogic.AddMessage(_client.UserId,Convert.ToInt32(p.Gdata[2]),p.Gdata[1],Convert.ToDateTime(p.Gdata[3]));
                                NewMsgLoad = true;
                                
                            }
                    break;
                case PacketType.GetAllChat:
                    Console.WriteLine("Getting msg " + p.Gdata[1]);
                    foreach (TRS_Domain.CHAT.Message message in p.listmessage)
                    {
                        ChatList.Add(new TRS_Domain.CHAT.Message(message.Username,message.Text,message.SendDate));
                    }
                    IsDone = true;
                    break;
                case PacketType.Login:
                    loginid = p.loginid;
                    loginstate = true;
                    break;
            }
        }

        
    }
}
