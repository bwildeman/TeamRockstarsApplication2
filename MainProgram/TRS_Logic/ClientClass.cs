﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;


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
            string ip = "145.93.45.228";

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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
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
            try
            {
                this.chatindex = chatindex;
                string input = text;
                Packet p = new Packet(PacketType.Chat, id, chatindex);
                p.Gdata.Add(_client.Name + " " + _client.Surname);
                p.Gdata.Add(input);
                p.Gdata.Add(Convert.ToString(chatindex));
                p.Gdata.Add(Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")));
                chatLogic.AddMessage(_client.UserId, chatindex, input, DateTime.Now);
                master.Send(p.ToBytes());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                
        }

        public void Login(string email, string password)
        {
            try
            {
                Packet p = new Packet(PacketType.Login, id);
                p.Gdata.Add(email);
                p.Gdata.Add(password);
                master.Send(p.ToBytes());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Data_IN()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                        NewMsg.Add(new TRS_Domain.CHAT.Message(p.Gdata[0], p.Gdata[1], p.Gdata[3]));

                        NewMsgLoad = true;
                    }
                    break;
                case PacketType.GetAllChat:
                    Console.WriteLine("Getting msg " + p.Gdata[1]);
                    foreach (TRS_Domain.CHAT.Message message in p.listmessage)
                    {
                        chatindex = Convert.ToInt32(p.Gdata[1]);
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
