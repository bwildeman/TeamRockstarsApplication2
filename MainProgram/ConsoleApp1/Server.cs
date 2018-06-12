using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using TRS_Logic;
using TRS_DAL.REPOSITORIES;

namespace Server
{
    class Server
    {
        static Socket listenerSocket;
        static List<ClientData> _clients;
        static UserRepository _userRepo = new UserRepository();
        static ChatRepository _chatsql = new ChatRepository();
        static string currgroep;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Server on " + Packet.GetIP4Adress());

            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clients = new List<ClientData>();

            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(Packet.GetIP4Adress()), 4242);
            listenerSocket.Bind(ip);

            Thread listenThread = new Thread(ListenThread);
            listenThread.Start();


        }


        static void ListenThread()
        {
            while (true)
            {
                listenerSocket.Listen(0);
                _clients.Add(new ClientData(listenerSocket.Accept()));
            }
        }


        public static void Data_IN(object cSocket)
        {
            Socket clientSocket = (Socket)cSocket;

            byte[] Buffer;
            int readBytes;

            while (true)
            {
                Buffer = new byte[clientSocket.SendBufferSize];

                readBytes = clientSocket.Receive(Buffer);

                if (readBytes > 0)
                {
                    Packet packet = new Packet(Buffer);
                    DataManager(packet);
                }
            }
        }


        static public void DataManager(Packet p)
        {
            switch (p.packetType)
            {
                case PacketType.Chat:
                    foreach (ClientData c in _clients)
                    {
                       c.clientSocket.Send(p.ToBytes());
                    }
                    break;
                case PacketType.GetAllChat:
                    foreach (ClientData c in _clients)
                    {
                        if (c.id == p.senderID)
                        {
                            p.listmessage = _chatsql.GetMessages(Convert.ToInt32(p.Gdata[1]));
                            currgroep = p.Gdata[1];
                            c.clientSocket.Send(p.ToBytes());
                        }
                    }
                    break;
                case PacketType.Login:
                    foreach (ClientData c in _clients)
                    {
                        if (c.id == p.senderID)
                        {
                                while (p.loginid == 0)
                                {
                                    p.loginid = _userRepo.Login(p.Gdata[0], p.Gdata[1]);
                                    if (p.loginid == 0)
                                    {
                                        p.loginid = -1;
                                    }
                                }
                           
                            c.clientSocket.Send(p.ToBytes());
                        }
                    }
                    break;
            }
        }
    }

    class ClientData
    {
        public Socket clientSocket;
        public Thread clientThread;
        public string id;


        public ClientData()
        {
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(Server.Data_IN);
            clientThread.Start(clientSocket);
            SendRegistrationPacket();
        }

        public ClientData(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(Server.Data_IN);
            clientThread.Start(clientSocket);
            SendRegistrationPacket();
        }

        public void SendRegistrationPacket()
        {
            Packet p = new Packet(PacketType.Registration, "server");
            Console.WriteLine(id);
            p.Gdata.Add(id);
            clientSocket.Send(p.ToBytes());
        }
    }
}
