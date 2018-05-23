using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram.GROUP
{
    public class Data
    {
        // ********** PROPERTIES *********
        public int GroupId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<CHAT.Data> Chats { get; private set; }

        public Data(){}

        public Data(int id, string name, string description)
        {
            GroupId = id;
            Name = name;
            Description = description;
        }

        public void FillChats()
        {
            Chats = DATABASE.DbConnect.GetAllChats(GroupId);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
