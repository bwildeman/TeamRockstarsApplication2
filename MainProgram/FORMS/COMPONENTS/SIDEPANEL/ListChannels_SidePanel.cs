using MainProgram.USER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.FORMS.COMPONENTS.SIDEPANEL
{
    public partial class ListChannelsSidePanel : Form
    {
        private GROUP.Data _group;

        public ListChannelsSidePanel(GROUP.Data group)
        {
            _group = group;
            InitializeComponent();
        }

        private void ListChannels_SidePanel_Load(object sender, EventArgs e)
        {
            //  Clear lists
            LB_Chats.Items.Clear();
            LB_Events.Items.Clear();

            // Fill Chats:
            _group.FillChats();
            foreach (var item in _group.Chats)
            {
                LB_Chats.Items.Add(item);
            }
        }

        private void LB_Chats_SelectedIndexChanged(object sender, EventArgs e)
        {
            CONTROLLERS.ControllerMain.ChangeChat((CHAT.Data)LB_Chats.SelectedItem, LB_Chats.SelectedIndex);
        }
    }
}
