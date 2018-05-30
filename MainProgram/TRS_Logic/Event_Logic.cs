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
            eventRepo.CreateGroupEvent(newEvent.GroupId, newEvent.Name, newEvent.StartDate, newEvent.EndDate, newEvent.Online, newEvent.Location,newEvent.Description);
        }

        public List<Data> GetGroupEvents(int groupId)
        {
            return eventRepo.GetGroupEvents(groupId);
        }
    }
}
