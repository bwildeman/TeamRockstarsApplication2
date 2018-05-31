using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TRS_Domain.CHAT;

namespace TRS_Logic
{
    [Serializable]
    public class Packet
    {
        public List<string> Gdata;
        public int packetInt;
        public bool packetBool;
        public string senderID;
        public int groupid;
        public PacketType packetType;
        public List<Message> listmessage = new List<Message>();
        public Packet(PacketType type, string senderID)
        {
            Gdata = new List<string>();
            this.senderID = senderID;
            this.packetType = type;
        }

        public Packet(PacketType type, string senderID,int groupid)
        {
            Gdata = new List<string>();
            this.senderID = senderID;
            this.groupid = groupid;
            this.packetType = type;
        }

        

        public Packet(byte[] packetbytes)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(packetbytes);

            Packet p = (Packet)bf.Deserialize(ms);
            ms.Close();
            this.Gdata = p.Gdata;
            this.packetInt = p.packetInt;
            this.packetBool = p.packetBool;
            this.senderID = p.senderID;
            this.packetType = p.packetType;
            this.listmessage = p.listmessage;
        }



        public byte[] ToBytes()
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            bf.Serialize(ms, this);
            byte[] bytes = ms.ToArray();
            ms.Close();
            return bytes;
        }


        public static string GetIP4Adress()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

            foreach(IPAddress i in ips)
            {
                    if (i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        if (i.ToString().IndexOf("9") != 1)
                        {
                        return i.ToString();
                        }
                        
                    }
                
            }
            return "127.0.0.1";
        }
    }


    public enum PacketType
    {
        Registration,
        Chat,
        GetAllChat,
        Login
    }
}
