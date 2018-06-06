using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        ClientClass client;
        //  Memory:
        private Frame _contentFrame;
        private Frame _channelFrame;
        private TRS_Domain.USER.Data _client;
        TRS_Domain.CHAT.Data _selectedChat;
        private List<TRS_Domain.CHAT.Message> ChatList { get; set; }
        private List<TRS_Domain.CHAT.Message> NewMsg { get; set; }
        bool state = true;
        bool state2 = false;


        public PageChat(Frame contentFrame, Frame channelFrame, TRS_Domain.CHAT.Data selectedChat, TRS_Domain.USER.Data _client,ClientClass client)
        {
            _contentFrame = contentFrame;
            _channelFrame = channelFrame;
            _selectedChat = selectedChat;
            this._client = _client;
            this.client = client;
            client.GetPersonInfo(_client);
            InitializeComponent();
            Lb_Chat.Items.Clear();
            Loaded += PAGE_CHAT_Loaded;
        }

        private void PAGE_CHAT_Loaded(object sender, RoutedEventArgs e)
        {
            Lb_Chat.Items.Clear();
            while (state == true)
            {
                    client.LoadChat(_selectedChat.ChatId);
                    state2 = true;
                    while (state2 == true)
                    {
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
                            ChatList.Clear();
                            client.ClearList();
                            state2 = false;
                            state = false;
                            client.IsDone = false;
                            
                        }
                    } 
            }
            //Thread Update = new Thread(new ThreadStart(CheckForUpdate));
            //Update.Start();
        }

        private void Txt_Message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            { 
                client.Msg(Txt_Message.Text, _selectedChat.ChatId);
                Txt_Message.Clear();
            }
            
        }

        //
        public void CheckForUpdate()
        {
            while (client.NewMsgLoad == true)
            {
                if (client.NewMsgLoad == true)
                {
                    NewMsg = client.AddNewMsg();
                    foreach (var item in NewMsg)
                    {
                        TextBlock txtBlock = new TextBlock();
                        txtBlock.TextWrapping = TextWrapping.Wrap;
                        txtBlock.Text = $"{item.SendDate}: {item.Username}: {item.Text}";
                    }
                    client.ClearMsgList();
                }
                client.NewMsgLoad = false;
            }
        }

        private void Txt_Message_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
