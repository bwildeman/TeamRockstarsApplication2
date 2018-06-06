using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.INTERFACES;
using TRS_Domain.CHANNEL;

namespace TRS_DAL.CONTEXT
{
    public class ChannelContext : IChannelContext
    {
        ConnectionDB ConnectDB = new ConnectionDB();

        public void AddChannel(string Name, string Description, int type)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteChannel(int groupId, int Id)
        {
            throw new System.NotImplementedException();
        }

        public Channel GetChannel(int groupId, int Id)
        {
            throw new System.NotImplementedException();
        }

        public Channel[] GetChannels(int groupId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDescription(string newDescription)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateName(string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}
