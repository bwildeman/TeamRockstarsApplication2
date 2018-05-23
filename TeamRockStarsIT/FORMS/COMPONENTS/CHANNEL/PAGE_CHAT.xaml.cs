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
using TRS_Logic;

namespace TeamRockStarsIT.FORMS.COMPONENTS.CHANNEL
{
    /// <summary>
    /// Interaction logic for PAGE_CHAT.xaml
    /// </summary>
    public partial class PageChat : Page
    {
        //  References:
        ChatLogic _chatLogic = new ChatLogic();

        //  Memory:
        private Frame _contentFrame;
        private Frame _channelFrame;
        TRS_Domain.CHAT.Data _selectedChat;
        private List<TRS_Domain.CHAT.Message> ChatList { get; set; }

        public PageChat(Frame contentFrame, Frame channelFrame, TRS_Domain.CHAT.Data selectedChat)
        {
            _contentFrame = contentFrame;
            _channelFrame = channelFrame;
            _selectedChat = selectedChat;
            InitializeComponent();
            Loaded += PAGE_CHAT_Loaded;
        }

        private void PAGE_CHAT_Loaded(object sender, RoutedEventArgs e)
        {
            ChatList = _chatLogic.GetAllMessages(_selectedChat.ChatId);
            Lb_Chat.Items.Clear();
            foreach (var item in ChatList)
            {
                TextBlock txtBlock = new TextBlock();
                txtBlock.TextWrapping = TextWrapping.Wrap;
                txtBlock.Text = $"{item.SendDate}: {item.Username}: {item.Text}";
                Lb_Chat.Items.Add(txtBlock);
            }
        }
    }
}
