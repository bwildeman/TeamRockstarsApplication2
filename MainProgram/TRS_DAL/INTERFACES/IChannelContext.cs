using System;
using System.Collections.Generic;
using System.Text;
using TRS_Domain.CHANNEL;

namespace TRS_DAL.INTERFACES
{
    interface IChannelContext
    {

        #region Create Methods

        /// <summary>
        /// Adds a channel
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="type">either an event, channel or Chat</param>
        void AddChannel(string Name, string Description, int type, int groupID);
        void AddEvent(string Name, string Description, int type,DateTime starttime, DateTime endtime,bool online, string locationurl, int userID, int groupID);

        #endregion
        #region Read Methods

        /// <summary>
        /// Returns selected Channel
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        Channel GetChannel(int groupId, int Id, int type);

        /// <summary>
        /// returns every channel that a group has
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        Channel[] GetChannels(int groupId);

        #endregion
        #region Update Methods

        /// <summary>
        /// Update Name of a group
        /// </summary>
        /// <remarks> Kan niet dezelfde naam zijn als een andere channel in die groep</remarks>
        /// <param name="newName"></param>
        void UpdateName(int groupID, int channelID,int type,string newName);

        void UpdateDescription(int groupID, int channelID,int type,string newDesc);

        #endregion
        #region Delete Methods

        void DeleteChannel(int groupId, int Id, int type);

        #endregion

    }
}
