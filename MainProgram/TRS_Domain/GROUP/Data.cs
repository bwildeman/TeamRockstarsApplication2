using System;
using System.Collections.Generic;
using System.Text;
using TRS_Domain.CHANNEL.CHAT;
using TRS_Domain.EVENT;

namespace TRS_Domain.GROUP
{
    public class Data
    {
        #region Properties

        public int GroupID { get; private set; }
        public int GroupLeadersId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Region { get; private set; }
        public List<CHANNEL.CHAT.Chat> Chats { get; private set; }
        public List<EVENT.Data> Events { get; private set; }
        public byte[] Img { get; private set; }

        #endregion
        #region Constructors

        public Data() { }

        public Data(int id, int groupLeadersId, string name, string description, string region)
        {
            GroupID = id;
            GroupLeadersId = groupLeadersId;
            Name = name;
            Description = description;
            Region = region;
        }

        #endregion
        #region Methods

        public void FillChats(List<Chat> inputList)
        {
            Chats = inputList;
        }
        public override string ToString()
        {
            return Name;
        }

        public void SetChats(List<Chat> newChatList)
        {
            Chats = newChatList;
        }

        public void SetEvents(List<EVENT.Data> newEventsList)
        {
            Events = newEventsList;
        }

        #endregion
    }
}
