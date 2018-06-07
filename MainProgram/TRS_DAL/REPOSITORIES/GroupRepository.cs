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

        public bool AddGroup(TRS_Domain.USER.Data client, string name, string description, byte[] bitMap)
        {
            return _groupContext.AddGroup(client, name, description, bitMap);
        }

        public bool AddGroup(TRS_Domain.USER.Data client, string name, string description)
        {
            return _groupContext.AddGroup(client, name, description);
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
    }
}

