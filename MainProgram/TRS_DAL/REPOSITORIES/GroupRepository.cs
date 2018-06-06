using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.CONTEXT;
using TRS_DAL.INTERFACES;
using TRS_Domain.CHANNEL;
using TRS_Domain.GROUP;

namespace TRS_DAL.REPOSITORIES
{
    public class GroupRepository : IGroupContext
    {
        //  Add Context reference:
        IGroupContext groupContext = new GroupSqlContext();

        public bool AddGroupWithPic(int clientID, string name, string description, byte[] bitMap)
        {
            throw new NotImplementedException();
        }

        public List<Data> GetAllGroupsThatUserIsNotIn(int UserID)
        {
            throw new NotImplementedException();
        }

        public void AddGroup(string name, string description)
        {
            groupContext.AddGroup(name, description);
        }

        public List<TRS_Domain.GROUP.Data> GetAllGroupInfo()
        {
            return groupContext.GetAllGroupInfo();
        }

        public Channel GetChannel(int GroupId, int Id)
        {
            return groupContext.GetChannel(GroupId, Id);
        }

        public Channel[] GetChannels(int GroupId)
        {
            return groupContext.GetChannels(GroupId);
        }

        public TRS_Domain.GROUP.Data GetGroupInfo(int groupID)
        {
            return groupContext.GetGroupInfo(groupID);
        }

        public List<TRS_Domain.GROUP.Data> GetGroups(int userID)
        {
            return groupContext.GetGroups(userID);
        }

        public void JoinGroup(TRS_Domain.USER.Data client, TRS_Domain.GROUP.Data myGroup)
        {
            groupContext.JoinGroup(client, myGroup);
        }

        public void UpdateDescription(int id, string newDescription)
        {
            groupContext.UpdateDescription(id, newDescription);
        }

        public void UpdateImage(int id, byte[] newImage)
        {
            groupContext.UpdateImage(id, newImage);
        }

        public void UpdateName(int id, string name)
        {
            groupContext.UpdateName(id, name);
        }

        public void UpdateRegion(int id, string newName)
        {
            groupContext.UpdateRegion(id, newName);
        }

        public void UpdateStartUpChannel(string selectedChannel)
        {
            groupContext.UpdateStartUpChannel(selectedChannel);
        }
    }
}

