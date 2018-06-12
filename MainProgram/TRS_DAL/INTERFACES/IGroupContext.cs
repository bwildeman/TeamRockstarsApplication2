using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_DAL.INTERFACES
{
    interface IGroupContext
    {
        List<TRS_Domain.GROUP.Data> GetAllGroupsThatUserIsNotIn(int UserID);
        #region Create Methods

        bool AddGroup(TRS_Domain.USER.Data client, string name, string description,string region);
        bool AddGroup(TRS_Domain.USER.Data client, string name, string description, byte[] bitMap, string region);

        #endregion
        #region Read Methods

        TRS_Domain.GROUP.Data GetGroupInfo(int groupID);

        List<TRS_Domain.GROUP.Data> GetAllGroupInfo();

        List<TRS_Domain.GROUP.Data> GetGroups(int userID);

        /// <summary>
        /// returns the selected channel
        /// </summary>
        /// <param name="GroupId"></param>
        /// <param name="Id"></param>
        /// <returns></returns>

        /// <summary>
        /// Returns all the channels in a group
        /// </summary>
        /// <returns></returns>
        
        #endregion
        #region Update Methods

        void UpdateName(int id, string name);
        void UpdateImage(int id, byte[] newImage);
        void UpdateRegion(int id, string newRegion);
        void UpdateDescription(int id, string newDescription);
        void UpdateStartUpChannel(string selectedChannel);

        bool JoinGroup(TRS_Domain.USER.Data client, TRS_Domain.GROUP.Data myGroup);
        
        #endregion
        #region Delete Methods

        void LeaveGroup(int userID, int GroupID);

        #endregion
    }
}
