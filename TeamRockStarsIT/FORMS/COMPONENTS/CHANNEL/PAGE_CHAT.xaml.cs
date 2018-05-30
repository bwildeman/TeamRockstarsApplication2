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
        ClientClass client = new ClientClass();
        //  Memory:
        private Frame _contentFrame;
        private Frame _channelFrame;
        private TRS_Domain.USER.Data _client;
        TRS_Domain.CHAT.Data _selectedChat;
        private List<TRS_Domain.CHAT.Message> ChatList { get; set; }
        private List<TRS_Domain.CHAT.Message> NewMsg { get; set; }


        public PageChat(Frame contentFrame, Frame channelFrame, TRS_Domain.CHAT.Data selectedChat, TRS_Domain.USER.Data _client)
        {
            _contentFrame = contentFrame;
            _channelFrame = channelFrame;
            _selectedChat = selectedChat;
            this._client = _client;
            InitializeComponent();
            client.LoadIn(_client);
            Loaded += PAGE_CHAT_Loaded;
        }

        private void PAGE_CHAT_Loaded(object sender, RoutedEventArgs e)
        {
            Lb_Chat.Items.Clear();
            while (true)
            {
                while (client.IsLoading == true)
                {
                    client.LoadChat(_selectedChat.ChatId);
                    B:
                    while (client.IsDone == true)
                    {
                        ChatList = client.LoadinChat();
                        foreach (var item in ChatList)
                        {
                            TextBlock txtBlock = new TextBlock();
                            txtBlock.TextWrapping = TextWrapping.Wrap;
                            txtBlock.Text = $"{item.SendDate}: {item.Username}: {item.Text}";
                            Lb_Chat.Items.Add(txtBlock);
                        }
                        goto A;
                    }
                    goto B;
                }
                
            }
            A:;
        }

        private void Txt_Message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            { 
                client.Msg(Txt_Message.Text, _selectedChat.ChatId);
                Txt_Message.Clear();
                while (true)
                {
                    if (client.NewMsgLoad == true)
                    {
                        NewMsg = client.AddNewMsg();
                        foreach (var item in NewMsg)
                        {
                            TextBlock txtBlock = new TextBlock();
                            txtBlock.TextWrapping = TextWrapping.Wrap;
                            txtBlock.Text = $"{item.SendDate}: {item.Username}: {item.Text}";
                            Lb_Chat.Items.Add(txtBlock);
                        }
                        goto A;
                    }
                }
                A:;
            }
            
        }

        private void Txt_Message_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
