using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_DAL.INTERFACES
{
    interface IGroupContext
    {
        TRS_Domain.GROUP.Data GetGroupInfo(int groupId);

        List<TRS_Domain.GROUP.Data> GetAllGroupInfo();

        List<TRS_Domain.GROUP.Data> GetGroups(int userId);

        bool JoinGroup(TRS_Domain.USER.Data client, TRS_Domain.GROUP.Data myGroup);

        bool AddGroup(TRS_Domain.USER.Data client, string name, string description);
        bool AddGroup(TRS_Domain.USER.Data client, string name, string description, byte[] bitMap);
        List<TRS_Domain.GROUP.Data> GetAllGroupsThatUserIsNotIn(int UserID);
    }
}
