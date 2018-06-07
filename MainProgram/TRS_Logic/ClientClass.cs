using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;


//using MySql.Data.MySqlClient;

namespace TRS_Logic
{
    public class ClientClass
    {
        //Memory
        public static Socket master;
        public string id;
        public int SenderId;
        public int chatindex;
        public int loginid;
        public bool IsDone = false;
        public bool IsLoading = false;
        public bool NewMsgLoad = false;
        public bool loginstate = false;

        //Reference
        List<TRS_Domain.CHAT.Message> ChatList = new List<TRS_Domain.CHAT.Message>();
        List<TRS_Domain.CHAT.Message> NewMsg = new List<TRS_Domain.CHAT.Message>();
        ChatLogic chatLogic = new ChatLogic();
        TRS_Domain.USER.Data _client;
        ControllerLogin _loginlogic = new ControllerLogin();

        //public
        public List<TRS_Domain.CHAT.Message> AddNewMsg()
        {
            return NewMsg;
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

        public void GetPersonInfo(TRS_Domain.USER.Data data)
        {
            _client = data;
        }

        public int GetLoginId()
        {
            return loginid;
        }

        public List<TRS_Domain.CHAT.Message> LoadinChat()
        {
            return ChatList;
        }


        public void LoadIn()
        {
            string ip = "145.93.45.157";
            //string ip = "145.93.64.37";

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

        public void Login(string email, string password)
        {
            Packet p = new Packet(PacketType.Login, id);
            p.Gdata.Add(email);
            p.Gdata.Add(password);
            master.Send(p.ToBytes());
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
                chatLogic.AddMessage(_client.UserId,chatindex,input,DateTime.Now);
                master.Send(p.ToBytes());
        }


        //private
        private void Data_IN()
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


        private void DataManeger(Packet p)
        {
            switch (p.packetType)
            {
                case PacketType.Registration:
                    id = p.Gdata[0];
                    Console.WriteLine("Connected id: " + id);
                    IsLoading = true;
                    break;

                case PacketType.Chat:
                        NewMsg.Add(new TRS_Domain.CHAT.Message(p.Gdata[0],p.Gdata[1],p.Gdata[3]));
                        
                        NewMsgLoad = true;
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
