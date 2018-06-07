using System;
using System.Collections.Generic;
using System.Text;
using TRS_Domain.CHANNEL;

namespace TRS_DAL.REPOSITORIES
{
    public class ChannelRepository : INTERFACES.IChannelContext
    {
        INTERFACES.IChannelContext CC = new CONTEXT.ChannelContext();

        public void AddChannel(string Name, string Description, int type, int groupID)
        {
            CC.AddChannel(Name, Description, type, groupID);
        }

        public void DeleteChannel(int groupId, int Id, int type)
        {
            CC.DeleteChannel(groupId, Id,type);
        }

        public Channel GetChannel(int groupId, int Id, int type)
        {
            return CC.GetChannel(groupId, Id, type);
        }

        public Channel[] GetChannels(int groupId)
        {
            return CC.GetChannels(groupId);
        }

        public void UpdateDescription(int groupID, int channelID,int type,string newdesc)
        {
            CC.UpdateDescription( groupID,  channelID, type, newdesc);
        }

        public void UpdateName(int groupID, int channeID,int type,string newName)
        {
            CC.UpdateName(groupID, channeID, type, newName);
        }
    }
}
