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
        private readonly IEventContext _eventContext = new EventSqlContext();

        public List<TRS_Domain.EVENT.Data> GetGroupEvents(int groupId)
        {
            return _eventContext.GetGroupEvents(groupId);
        }

        public void CreateGroupEvent(int groupId, int ownerId, string name, DateTime startDate, DateTime endDate, bool online,
            string location, string description)
        {
            _eventContext.CreateGroupEvent(groupId, ownerId, name, startDate, endDate, online, location, description);
        }

        public void AssignUserToEvent(int eventId, int userId)
        {
            _eventContext.AssignUserToEvent(eventId, userId);
        }

        public void RemoveUserFromEvent(int eventId, int userId)
        {
            _eventContext.RemoveUserFromEvent(eventId, userId);
        }

        public List<TRS_Domain.USER.Data> GetAllEventSignOns(int eventId)
        {
            return _eventContext.GetAllEventSignOns(eventId);
        }
    }
}
