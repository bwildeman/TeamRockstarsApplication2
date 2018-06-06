using System;
using System.Collections.Generic;
using System.Text;
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
        public List<CHAT.Data> Chats { get; private set; }
        public List<EVENT.Data> Events { get; private set; }
        public byte[] Img { get; private set; }

        public Data() { }

        public Data(int id, string name, string description, byte[] img)
        {
            GroupId = id;
            Name = name;
            Description = description;
            Img = img;
        }

        public void FillChats(List<CHAT.Data> inputList)
        {
            Chats = inputList;
        }
        public override string ToString()
        {
            return Name;
        }

        public void SetChats(List<CHAT.Data> newChatList)
        {
            Chats = newChatList;
        }

        public void SetEvents(List<EVENT.Data> newEventsList)
        {
            Events = newEventsList;
        }
    }
}
