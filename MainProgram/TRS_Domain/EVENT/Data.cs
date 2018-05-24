﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EVENT
{
    public class Data
    {
        public int Id { get; private set; }
        public int GroupId { get; private set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public bool Online { get; private set; }
        public string Location { get; private set; }
        public string Description { get; private set; }

        public Data(int id, int groupId, string name, DateTime date, bool online, string location, string description)
        {
            Id = id;
            GroupId = groupId;
            Name = name;
            Date = date;
            Online = online;
            Location = location;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
