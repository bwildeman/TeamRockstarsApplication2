using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.REPOSITORIES;
using TRS_Domain.CHANNEL.CHAT;

namespace TRS_Logic
{
    public class ChatLogic
    {
        //  Add DAL reference
        ChatRepository _chatRepo = new ChatRepository();
        public List<Chat> GetAllChats(int groupId)
        {
            return _chatRepo.GetAllChats(groupId);
        }

        public List<Message> GetAllMessages(int chatId)
        {
            return _chatRepo.GetMessages(chatId);
        }

        public void AddMessage(int id, int chat, string msg, DateTime dateTime)
        {
            _chatRepo.AddMessage(id,chat,msg,dateTime);
        }

    }
}
