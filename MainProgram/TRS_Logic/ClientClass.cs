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
        public int groupindex;
        public int selectedindex;
        public List<TRS_Domain.CHAT.Message> list = new List<TRS_Domain.CHAT.Message>();

        public void LoadIn()
        {
            string ip = "145.93.45.165";

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
            while (true)
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
                    goto B;
                }
                
               
            }
            B:;
        }

        public List<TRS_Domain.CHAT.Message> LoadinChat()
        {
            return list;
        }

        public void Msg(string text,int groupindex)
        {

                this.groupindex = groupindex;
                string input = text;
                Packet p = new Packet(PacketType.Chat, id,groupindex);
                p.Gdata.Add(name);
                p.Gdata.Add(input);
                p.Gdata.Add(Convert.ToString(groupindex));
                p.Gdata.Add(Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")));
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
                    break;

                case PacketType.Chat:
                        
                            if (Convert.ToInt32(p.Gdata[2]) == selectedindex)
                            {
                                //list.Add(new TRS_Domain.CHAT.Message());
                                //DBconnect.AddMessage();
                            }
                    break;
                case PacketType.GetAllChat:
                    Console.WriteLine("Getting msg " + p.Gdata[1]);
                    foreach (TRS_Domain.CHAT.Message message in p.listmessage)
                    {
                        list.Add(new TRS_Domain.CHAT.Message(message.Username,message.Text,message.SendDate));
                    }
                    break;
            }
        }

        
    }
}
