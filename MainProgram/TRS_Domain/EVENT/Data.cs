using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.EVENT
{
    public class Data
    {
        public int Id { get; private set; }
        public int EventOwnerId { get; private set; }
        public int GroupId { get; private set; }
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool Online { get; private set; }
        public string LocationUrl { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Empty event constructor
        /// </summary>
        public Data(Data eventData)
        {
            Id = eventData.Id;
            EventOwnerId = eventData.EventOwnerId;
            GroupId = eventData.GroupId;
            Name = eventData.Name;
            StartDate = eventData.StartDate;
            EndDate = eventData.EndDate;
            Online = eventData.Online;
            LocationUrl = eventData.LocationUrl;
            Description = eventData.Description;
        }

        /// <summary>
        /// New event constructor
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="online"></param>
        /// <param name="locationUrl"></param>
        /// <param name="description"></param>
        public Data(int groupId, int ownerId, string name, DateTime startDate, DateTime endDate, bool online, string locationUrl, string description)
        {
            GroupId = groupId;
            EventOwnerId = ownerId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Online = online;
            LocationUrl = locationUrl;
            Description = description;
        }

        /// <summary>
        /// Event constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ownerId"></param>
        /// <param name="groupId"></param>
        /// <param name="name"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="online"></param>
        /// <param name="locationUrl"></param>
        /// <param name="description"></param>
        public Data(int id, int ownerId, int groupId, string name, DateTime startDate, DateTime endDate, bool online, string locationUrl, string description)
        {
            Id = id;
            EventOwnerId = ownerId;
            GroupId = groupId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Online = online;
            LocationUrl = locationUrl;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
