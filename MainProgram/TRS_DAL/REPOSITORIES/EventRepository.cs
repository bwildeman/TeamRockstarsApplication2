using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.CONTEXT;
using TRS_DAL.INTERFACES;

namespace TRS_DAL.REPOSITORIES
{
    public class EventRepository
    {
        //  Context reference:
        readonly IEventContext _eventContext = new EventSqlContext();

        List<TRS_Domain.EVENT.Data> GetGroupEvents(int groupId)
        {
            return _eventContext.GetGroupEvents(groupId);
        }

        void CreateGroupEvent(int groupId, string name, DateTime startDate, DateTime endDate, bool online,
            string location, string description)
        {
            _eventContext.CreateGroupEvent(groupId, name, startDate, endDate, online, location, description);
        }

    }
}
