using System;
using System.Collections.Generic;
using System.Text;
using TRS_Domain.CHANNEL.CHAT;

namespace TRS_DAL.INTERFACES
{
    interface IChatContext
    {
        void AddMessage(int user, int chat, string message, DateTime time);

        void AddChat(int groupId, string name, string description);

        List<Chat> GetAllChats(int groupId);

        List<Message> GetMessages(int chatId);

        bool MessageAdded(string message, DateTime time);
    }
}
