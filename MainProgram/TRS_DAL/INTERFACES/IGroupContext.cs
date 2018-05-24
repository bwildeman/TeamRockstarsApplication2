using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_DAL.INTERFACES
{
    interface IGroupContext
    {
        TRS_Domain.GROUP.Data GetGroupInfo(int groupID);

        List<TRS_Domain.GROUP.Data> GetAllGroupInfo();

        List<TRS_Domain.GROUP.Data> GetGroups(int userID);

        void JoinGroup(TRS_Domain.USER.Data client, TRS_Domain.GROUP.Data myGroup);

        void AddGroup(string name, string description);

        void UpdateName(int id, string name);
        void UpdateImage(int id, byte[] newImage);
        void UpdateRegion(int id, string newRegion);
        void UpdateDescription(int id, string newDescription);
        void UpdateStartUpChannel(string selectedChannel);
    }
}
