using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProgram.CHAT;

namespace MainProgram.FORMS.COMPONENTS.MAINPANEL
{
    public partial class Chat : Form
    {
        public CHAT.Data SelectedChat { get; set; }
        public USER.Data Client { get; set; }
        public List<CHAT.Message> ChatList { get; set; }

        public Chat(CHAT.Data inputChat, USER.Data client)
        {
            SelectedChat = inputChat;
            Client = client;
            InitializeComponent();
        }

        private void Form_Chat_Load(object sender, EventArgs e)
        {
            BT_Message.Font = new Font("Microsoft Sans Serif", 9.75f);

            this.LBoxMessages.Items.Clear();
            ChatList = DATABASE.DbConnect.GetMessages(SelectedChat.ChatId);
            foreach (var item in ChatList)
            {
                LBoxMessages.Items.Add(item);
            }
            MessageChecker.Start();
        }

        private void MessageChecker_Tick(object sender, EventArgs e)
        {
            Logic.CheckAndUpdate(LBoxMessages, this);
        }

        private void BT_Message_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TB_MessageInput.Text))
            {
                DATABASE.DbConnect.AddMessage(Client.UserId, SelectedChat.ChatId, TB_MessageInput.Text, DateTime.Now);
                TB_MessageInput.Text = "";
            }
        }

        private void TB_MessageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BT_Message.PerformClick();
            }
        }
    }
}
