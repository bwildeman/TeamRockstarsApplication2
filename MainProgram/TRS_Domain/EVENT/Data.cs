using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EVENT
{
    public class Data
    {
        public int Id { get; private set; }
        public int GroupId { get; private set; }
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool Online { get; private set; }
        public string Location { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// New event constructor
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="name"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="online"></param>
        /// <param name="location"></param>
        /// <param name="description"></param>
        public Data( int groupId, string name, DateTime startDate, DateTime endDate, bool online, string location, string description)
        {
            GroupId = groupId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Online = online;
            Location = location;
            Description = description;
        }

        /// <summary>
        /// Event constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupId"></param>
        /// <param name="name"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="online"></param>
        /// <param name="location"></param>
        /// <param name="description"></param>
        public Data(int id, int groupId, string name, DateTime startDate, DateTime endDate, bool online, string location, string description)
        {
            Id = id;
            GroupId = groupId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
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
