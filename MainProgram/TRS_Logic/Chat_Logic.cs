using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.REPOSITORIES;
using TRS_Domain.CHAT;

namespace TRS_Logic
{
    public class ChatLogic
    {
        //  Add DAL reference
        ChatRepository _chatRepo = new ChatRepository();
        ChannelRepository _channelRepository = new ChannelRepository();
        public List<TRS_Domain.CHANNEL.CHAT.Chat> GetAllChats(int groupId)
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

        public void AddChannel(string name,string discription,int groupID)
        {
           _channelRepository.AddChannel(name, discription, 1,groupID);
        }
    }
}
