using System;
using System.Collections.Generic;
using System.Text;

namespace TRS_Domain.CHANNEL.CHAT
{
    [Serializable]
    public class Message
    {
        public string Username { get; private set; }
        public string Text { get; private set; }
        public string SendDate { get; private set; }

        public Message(string username, string text, string sendDate)
        {
            Username = username;
            Text = text;
            SendDate = sendDate;
        }
        public override string ToString()
        {
            return $"{SendDate}: {Username}: {Text}";
        }
    }
}
