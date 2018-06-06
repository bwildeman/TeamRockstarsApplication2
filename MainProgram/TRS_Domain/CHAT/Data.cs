using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.CHAT
{
    public class Data
    {
        public int ChatId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Data(int id, string name, string description)
        {
            ChatId = id;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
