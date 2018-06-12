using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TRS_Domain.CHAT;
using TRS_Domain.EVENT;

namespace TRS_Domain.GROUP
{
    public class Data
    {
        // ********** PROPERTIES *********
        public int GroupId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<TRS_Domain.CHANNEL.CHAT.Chat> Chats { get; private set; }
        public List<EVENT.Data> Events { get; private set; }
        public byte[] Img { get; private set; }
        public string _region { get; private set; }
        public int GroupLeader { get; private set; }   


        public Data() { }

        public Data(int id, string name, string description, byte[] img, int groupleader, string region)
        {
            GroupLeader = groupleader;
            GroupId = id;
            Name = name;
            Description = description;
            Img = img;
            _region = region;
        }

        public void FillChats(List<TRS_Domain.CHANNEL.CHAT.Chat> inputList)
        {
            Chats = inputList;
        }
        public override string ToString()
        {
            return Name;
        }

        public void SetChats(List<TRS_Domain.CHANNEL.CHAT.Chat> newChatList)
        {
            Chats = newChatList;
        }

        public void SetEvents(List<EVENT.Data> newEventsList)
        {
            Events = newEventsList;
        }
    }
}
