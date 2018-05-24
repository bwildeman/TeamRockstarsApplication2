using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.CHANNEL.CHAT
{
    public class Chat : Channel
    {
        public Chat(int id, string name, string description) : base(id, name, description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
