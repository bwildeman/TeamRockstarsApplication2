using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_DAL.INTERFACES
{
    interface IEventContext
    {
        List<TRS_Domain.EVENT.Data> GetGroupEvents(int groupId);

        void CreateGroupEvent(int groupId, string name, DateTime startDate, DateTime endDate, bool online,
            string location, string description);
    }
}
