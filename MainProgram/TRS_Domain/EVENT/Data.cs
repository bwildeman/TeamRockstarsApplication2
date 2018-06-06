using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EVENT
{
    public class Data
    {
        public int EventId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Data(int eventId, string name, string description)
        {
            EventId = eventId;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
