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
using TRS_Domain.EVENT;

namespace TeamRockStarsIT.FORMS.COMPONENTS.CHANNEL
{
    /// <summary>
    /// Interaction logic for PAGE_EditEvent.xaml
    /// </summary>
    public partial class PAGE_EditEvent : Page
    {
        private readonly Data _currentEvent;
        private TRS_Domain.USER.Data _currentClient;
        private Frame _contentFrame;
        private Frame _channelFrame;

        public PAGE_EditEvent(Data currentEvent, Frame contentFrame, Frame panelContentFrame, TRS_Domain.USER.Data client)
        {
            _currentEvent = currentEvent;
            _contentFrame = contentFrame;
            _channelFrame = panelContentFrame;
            _currentClient = client;
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // set values
            TB_Name.Text = _currentEvent.Name;
            DateP_Start.Value = _currentEvent.StartDate;
            DateP_End.Value = _currentEvent.EndDate;
            TB_Description.Text = _currentEvent.Description;
            CheckOnlineOffline(_currentEvent.Online);
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            _channelFrame.Content = new PAGE_EventOverview(_contentFrame, _channelFrame, _currentEvent, _currentClient);
        }

        private void SetOnlineEvent()
        {
            TB_Adres.IsHitTestVisible = false;
            TB_Adres.Opacity = 0.5;
            Lbl_Adres.Opacity = 0.5;

            TB_Url.IsHitTestVisible = true;
            TB_Url.Opacity = 1;
            Lbl_Url.Opacity = 1;

            TB_Url.Text = _currentEvent.LocationUrl;

        }

        private void SetOfflineEvent()
        {
            TB_Adres.IsHitTestVisible = false;
            TB_Adres.Opacity = 1;
            Lbl_Adres.Opacity = 1;

            TB_Url.IsHitTestVisible = false;
            TB_Url.Opacity = 0.5;
            Lbl_Url.Opacity = 0.5;

            TB_Adres.Text = _currentEvent.LocationUrl;

        }

        private void CheckOnlineOffline(bool offline)
        {
            if (offline)
            {
                SetOfflineEvent();
            }
            if(offline == false)
            {
                SetOnlineEvent();
            }
        }

        private void RBtn_Online_Checked(object sender, RoutedEventArgs e)
        {
            TB_Adres.IsHitTestVisible = false;
            TB_Adres.Opacity = 0.5;
            Lbl_Adres.Opacity = 0.5;

            TB_Url.IsHitTestVisible = true;
            TB_Url.Opacity = 1;
            Lbl_Url.Opacity = 1;

            TB_Adres.Clear();
        }

        private void RBtn_IRL_Checked(object sender, RoutedEventArgs e)
        {
            TB_Adres.IsHitTestVisible = true;
            TB_Adres.Opacity = 1;
            Lbl_Adres.Opacity = 1;

            TB_Url.IsHitTestVisible = false;
            TB_Url.Opacity = 0.5;
            Lbl_Url.Opacity = 0.5;

            TB_Url.Clear();
        }
    }
}
