using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.CONTEXT;
using TRS_DAL.INTERFACES;

namespace TRS_DAL.REPOSITORIES
{
    public class GroupRepository
    {
        //  Add Context reference:
        IGroupContext _groupContext = new GroupSqlContext();

        public void AddGroup(int clientID, string name, string description)
        {
            _groupContext.AddGroup(clientID, name, description);
        }

        public List<TRS_Domain.GROUP.Data> GetAllGroupInfo()
        {
            return _groupContext.GetAllGroupInfo();
        }

        public TRS_Domain.GROUP.Data GetGroupInfo(int groupId)
        {
            return _groupContext.GetGroupInfo(groupId);
        }

        public List<TRS_Domain.GROUP.Data> GetGroups(int userId)
        {
            return _groupContext.GetGroups(userId);
        }

        public bool JoinGroup(TRS_Domain.USER.Data client, TRS_Domain.GROUP.Data myGroup)
        {
            return _groupContext.JoinGroup(client, myGroup);
        }

        public List<TRS_Domain.GROUP.Data> GetAllGroupsThatUserIsNotIn(int UserID)
        {
            return _groupContext.GetAllGroupsThatUserIsNotIn(UserID);
        }

        public bool AddGroupWithPic(int clientID, string name, string description, byte[] bitMap)
        {
            return _groupContext.AddGroupWithPic(clientID, name, description, bitMap);
        }
    }
}

