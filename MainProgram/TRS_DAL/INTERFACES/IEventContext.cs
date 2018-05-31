﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_DAL.INTERFACES
{
    interface IEventContext
    {
        List<TRS_Domain.EVENT.Data> GetGroupEvents(int groupId);

        void CreateGroupEvent(int groupId, string name, DateTime startDate, DateTime endDate, bool online,
            string location, string description);

        void AssignUserToEvent(int eventId, int userId);

        void RemoveUserFromEvent(int eventId, int userId);

        List<TRS_Domain.USER.Data> GetAllEventSignOns(int eventId);
    }
}
