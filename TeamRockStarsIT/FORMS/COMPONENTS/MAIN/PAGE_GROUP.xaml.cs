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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeamRockStarsIT.FORMS.COMPONENTS.OTHERS;
using TRS_Logic;

namespace TeamRockStarsIT.FORMS.COMPONENTS.MAIN
{
    /// <summary>
    /// Interaction logic for PAGE_GROUP.xaml
    /// </summary>
    public partial class PageGroup : Page
    {
        //  References:
        ClientLogic _clientLogic = new ClientLogic();
        Group_Logic _groupLogic = new Group_Logic();
        ChatLogic _chatLogic = new ChatLogic();
        Event_Logic eventLogic = new Event_Logic();
        ClientLogic clientLogic = new ClientLogic();
        ClientClass client;
        private FORMS.FormMain Main;
        TRS_Domain.USER.Data _client;

        //  Memory:
        private Frame _contentFrame;
        private TRS_Domain.GROUP.Data _selectedGroup;
        private Channel _selectedChannel = Channel.Chat;

        //  Private methodes:
        private void LoadChannelList()
        {
            Lb_Channel.Items.Clear();
            switch (_selectedChannel)
            {
                case Channel.Chat:
                    Lbl_SelectedChannel.Content = "Chats";
                    Btn_AddChannel.Content = "Add chat";
                    _selectedGroup.SetChats(_chatLogic.GetAllChats(_selectedGroup.GroupId));
                    foreach (var item in _selectedGroup.Chats)
                    {
                        Lb_Channel.Items.Add(item);
                    }
                    break;
                case Channel.Event:
                    Lbl_SelectedChannel.Content = "Event";
                    Btn_AddChannel.Content = "Add event";
                    _selectedGroup.SetEvents(eventLogic.GetGroupEvents(_selectedGroup.GroupId));
                    foreach (var item in _selectedGroup.Events)
                    {
                        Lb_Channel.Items.Add(item);
                    }
                    break;
                default:
                    Lbl_SelectedChannel.Content = "Channel";
                    Btn_AddChannel.Content = "Placeholder";
                    break;
            }
        }
        private void ChangeChannel(bool changeIndexUp)
        {
            int minEnumValue = Convert.ToInt32(Enum.GetValues(typeof(Channel)).Cast<Channel>().Min());
            int maxEnumValue = Convert.ToInt32(Enum.GetValues(typeof(Channel)).Cast<Channel>().Max());
            int currentIndex = Convert.ToInt32(_selectedChannel);
            int newChannelIndex = _groupLogic.ChangeChannel(currentIndex, minEnumValue, maxEnumValue, changeIndexUp);
            _selectedChannel = (Channel)newChannelIndex;
            LoadChannelList();
        }
        public PageGroup(Frame contentFrame, TRS_Domain.GROUP.Data selectedGroup,TRS_Domain.USER.Data _client, ClientClass client, Channel selectedChannel, FORMS.FormMain main)
        {
            _contentFrame = contentFrame;
            _selectedGroup = selectedGroup;
            this.client = client;
            this._client = _client;
            _selectedChannel = selectedChannel;
            Main = main;
            _contentFrame.NavigationService.RemoveBackEntry();
            InitializeComponent();
            Loaded += PAGE_GROUP_Loaded;
        }

        private void PAGE_GROUP_Loaded(object sender, RoutedEventArgs e)
        {
            LoadChannelList();
            if (_selectedGroup.GroupLeader == _client.UserId)
            {
                Btn_EditGrouo.Visibility = Visibility.Visible;
                Lb_Channel.Height = 399;

            }
        }

        private void Lb_Channel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Lb_Channel.SelectedItem != null)
            {
                switch (_selectedChannel)
                {
                    case Channel.Chat:
                        Fr_Channel.Content = new CHANNEL.PageChat(_contentFrame, Fr_Channel, (TRS_Domain.CHANNEL.CHAT.Chat)Lb_Channel.SelectedItem,_client, client);
                        break;
                    case Channel.Event:
                        Fr_Channel.Content = new CHANNEL.PAGE_EventOverview(_contentFrame, Fr_Channel, (TRS_Domain.EVENT.Data)Lb_Channel.SelectedItem, _client, _selectedGroup, client, Main);
                        break;
                }
            }
        }

        private void Btn_Left_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeChannel(false);
        }

        private void Btn_Right_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeChannel(true);
        }

        public enum Channel
        {
            Chat = 1,
            Event = 2
        }

        private void Btn_AddChannel_Click(object sender, RoutedEventArgs e)
        {
            switch (_selectedChannel)
            {
                case Channel.Chat:
                    FORMS.COMPONENTS.OTHERS.WINDOW_AddChannel addChannel= new WINDOW_AddChannel(_selectedGroup.GroupId);
                    addChannel.ShowDialog();
                    
                    break;
                case Channel.Event:
                    Fr_Channel.Content = new CHANNEL.PAGE_AddEvent(_selectedGroup, _client, _contentFrame, _selectedGroup, client, Main);
                    break;
            }
            LoadChannelList();
        }

        private void Btn_EditChannel_Click(object sender, RoutedEventArgs e)
        {
            Fr_Channel.Content = new  FORMS.COMPONENTS.OTHERS.MENU.Channels(_selectedGroup.GroupId,true, _contentFrame);
        }

        private void Btn_EditGrouo_Click(object sender, RoutedEventArgs e)
        {
            Lb_Channel.SelectedIndex = -1;
            Fr_Channel.Content = new  FORMS.COMPONENTS.OTHERS.MENU.General(_selectedGroup.GroupId, _contentFrame, _client, Main );
        }

        private void Btn_LEAVE_Click(object sender, RoutedEventArgs e)
        {
            _groupLogic.Leavegroup(_client.UserId,_selectedGroup.GroupId);
            _client = clientLogic.LoadClient(_client.UserId);
            Main.LB_Groups.Items.Clear();
            foreach (var item in _client.Groups)
            {
                Main.LB_Groups.Items.Add(item);
            }

            _contentFrame.Content = null;
        }
    }
}
