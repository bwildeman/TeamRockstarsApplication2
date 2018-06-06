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
        IEventContext _eventContext = new EventSqlContext();
    }
}
