using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_DAL.INTERFACES
{
    interface IChatContext
    {
        void AddMessage(int user, int chat, string message, DateTime time);

        void AddChat(int groupId, string name, string description);

        List<TRS_Domain.CHANNEL.CHAT.Chat> GetAllChats(int groupId);

        List<TRS_Domain.CHAT.Message> GetMessages(int chatId);

        bool MessageAdded(string message, DateTime time);
    }
}
