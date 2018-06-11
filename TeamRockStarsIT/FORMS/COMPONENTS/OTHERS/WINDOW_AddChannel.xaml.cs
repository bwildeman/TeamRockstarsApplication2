using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TRS_Logic;


namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS
{
    /// <summary>
    /// Interaction logic for WINDOW_AddChannel.xaml
    /// </summary>
    public partial class WINDOW_AddChannel : Window
    {
        public int _groupID { get; private set; }
        ChatLogic chatlogic = new ChatLogic();
        
        public WINDOW_AddChannel(int groupID)
        {
            _groupID = groupID;
            InitializeComponent();
        }
        

        private void BTN_Create_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Create_Click_1(object sender, RoutedEventArgs e)
        {
            chatlogic.AddChannel(TB_ChannelName.Text,TB_ChannelDEscr.Text,_groupID);
            this.Close();
        }
    }
}
