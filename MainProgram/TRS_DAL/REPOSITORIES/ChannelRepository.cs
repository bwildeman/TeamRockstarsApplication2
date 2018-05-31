using System;
using System.Collections.Generic;
using System.Text;
using TRS_Domain.CHANNEL;

namespace TRS_DAL.REPOSITORIES
{
    public class ChannelRepository : INTERFACES.IChannelContext
    {
        INTERFACES.IChannelContext CC = new CONTEXT.ChannelContext();

        public void AddChannel(string Name, string Description, int type)
        {
            CC.AddChannel(Name, Description, type);
        }

        public void DeleteChannel(int groupId, int Id)
        {
            CC.DeleteChannel(groupId, Id);
        }

        public Channel GetChannel(int groupId, int Id)
        {
            return CC.GetChannel(groupId, Id);
        }

        public Channel[] GetChannels(int groupId)
        {
            return CC.GetChannels(groupId);
        }

        public void UpdateDescription(string newDescription)
        {
            CC.UpdateDescription(newDescription);
        }

        public void UpdateName(string newName)
        {
            CC.UpdateName(newName);
        }
    }
}
