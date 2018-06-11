using System;
using System.Collections.Generic;
using System.Text;
using TRS_DAL.REPOSITORIES;
using TRS_Domain.EVENT;
using TRS_Domain.EXCEPTIONS;

namespace TRS_Logic
{
    public class Event_Logic
    {
        // reference repository
        EventRepository eventRepo = new EventRepository();
        ExceptionHandler ExHandler = new ExceptionHandler();

        public bool CreateNewGroupEvent(Data newEvent)
        {
            bool output = false;
            try
            {
                if (ExHandler.NewEvent(newEvent.Name, newEvent.Description, newEvent.StartDate, newEvent.EndDate, newEvent.Online, newEvent.LocationUrl))
                {
                    output = eventRepo.CreateGroupEvent(newEvent.GroupId, newEvent.EventOwnerId, newEvent.Name, newEvent.StartDate, newEvent.EndDate, newEvent.Online, newEvent.LocationUrl, newEvent.Description);
                }
            }
            catch(EmptyField ex)
            {
                throw ex;
            }
            catch(InvalidEndDate ex)
            {
                throw ex;
            }
            catch (StartDateInPast ex)
            {
                throw ex;
            }
            return output;
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

        public void UpdateEvent(Data selectedEvent)
        {
            eventRepo.UpdateEvent(selectedEvent);
        }

        public void ValidateStartDate(DateTime? value)
        {
            if (value != null)
            {
                
            }
        }
    }
}
