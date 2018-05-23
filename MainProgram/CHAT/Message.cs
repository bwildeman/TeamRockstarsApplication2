using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram.CHAT
{
    public class Message
    {
        public int UserId { get; private set; }
        public string Text { get; private set; }

        public Message(int id, string text)
        {
            UserId = id;
            Text = text;
        }
        public override string ToString()
        {
            return MainProgram.DATABASE.DbConnect.GetUserName(UserId) + ": " + Text;
        }
    }
}
