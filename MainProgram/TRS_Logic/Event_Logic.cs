using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.REPOSITORIES;
using TRS_Domain.EVENT;

namespace TRS_Logic
{
    public class Event_Logic
    {
        // reference repository
        EventRepository eventRepo = new EventRepository();

        public void CreateNewGroupEvent(Data newEvent)
        {
            eventRepo.CreateGroupEvent(newEvent.GroupId, newEvent.EventOwnerId, newEvent.Name, newEvent.StartDate, newEvent.EndDate, newEvent.Online, newEvent.LocationUrl, newEvent.Description);
        }

        public List<Data> GetGroupEvents(int groupId)
        {
            return eventRepo.GetGroupEvents(groupId);
        }

        public List<TRS_Domain.USER.Data> GetEventUsers(int eventId)
        {
            return eventRepo.GetAllEventSignOns(eventId);
        }

        public void AddUserToEvent(int eventId, int userId)
        {
            eventRepo.AssignUserToEvent(eventId, userId);
        }

        public void RemoveUserFromEvent(int eventId, int userId)
        {
            eventRepo.RemoveUserFromEvent(eventId, userId);
        }
    }
}
