using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_DAL.INTERFACES
{
    interface IGroupContext
    {
        #region Create Methods

        void AddGroup(string name, string description);

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
        TRS_Domain.CHANNEL.Channel GetChannel(int GroupId, int Id);

        /// <summary>
        /// Returns all the channels in a group
        /// </summary>
        /// <returns></returns>
        TRS_Domain.CHANNEL.Channel[] GetChannels(int GroupId);
        
        #endregion
        #region Update Methods

        void UpdateName(int id, string name);
        void UpdateImage(int id, byte[] newImage);
        void UpdateRegion(int id, string newRegion);
        void UpdateDescription(int id, string newDescription);
        void UpdateStartUpChannel(string selectedChannel);

        void JoinGroup(TRS_Domain.USER.Data client, TRS_Domain.GROUP.Data myGroup);
        
        #endregion
        #region Delete Methods

        #endregion
    }
}
