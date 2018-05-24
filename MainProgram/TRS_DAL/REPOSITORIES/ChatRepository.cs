﻿using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.CONTEXT;
using TRS_DAL.INTERFACES;
using TRS_Domain.CHANNEL.CHAT;

namespace TRS_DAL.REPOSITORIES
{
    public class ChatRepository
    {
        //  Add Context reference:
        IChatContext _chatContext = new ChatSqlContext();

        public void AddMessage(int user, int chat, string message, DateTime time)
        {
            _chatContext.AddMessage(user, chat, message, time);
        }

        public void AddChat(int groupId, string name, string description)
        {
            _chatContext.AddChat(groupId, name, description);
        }

        public List<Chat> GetAllChats(int groupId)
        {
            return _chatContext.GetAllChats(groupId);
        }

        public List<Message> GetMessages(int chatId)
        {
            return _chatContext.GetMessages(chatId);
        }

        public bool MessageAdded(string message, DateTime time)
        {
            return _chatContext.MessageAdded(message, time);
        }
    }
}
