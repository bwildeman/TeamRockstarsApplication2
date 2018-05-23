using MainProgram.DATABASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.CHAT
{
    public class Logic
    {
        public static void CheckAndUpdate(ListBox list, FORMS.COMPONENTS.MAINPANEL.Chat form)
        {
            if (form.ChatList.Count < DbConnect.GetMessages(form.SelectedChat.ChatId).Count)
            {
                int oldCount = form.ChatList.Count;
                form.ChatList = DbConnect.GetMessages(form.SelectedChat.ChatId);
                for (int i = oldCount; i < form.ChatList.Count; i++)
                {
                    list.Items.Add(form.ChatList[i]);
                }
            }
        }
    }
}
