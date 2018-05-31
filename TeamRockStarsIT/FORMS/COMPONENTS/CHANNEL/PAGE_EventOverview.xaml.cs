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
using TRS_Logic;

namespace TeamRockStarsIT.FORMS.COMPONENTS.CHANNEL
{
    /// <summary>
    /// Interaction logic for PAGE_EventOverview.xaml
    /// </summary>
    public partial class PAGE_EventOverview : Page
    {
        private Data _currentEvent;
        private TRS_Domain.USER.Data _currentUser;

        Event_Logic eventLogic = new Event_Logic();

        public PAGE_EventOverview(Data selectedEvent, TRS_Domain.USER.Data user)
        {
            InitializeComponent();
            _currentEvent = selectedEvent;
            _currentUser = user;
        }

        private void SetOnlineEvent()
        {
            TB_Adres.IsHitTestVisible = false;
            TB_Adres.Opacity = 0.5;
            Lbl_Adres.Opacity = 0.5;

            TB_Url.IsHitTestVisible = true;
            TB_Url.Opacity = 1;
            Lbl_Url.Opacity = 1;

            TB_OnlineOffline.Text = "Online";
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

            TB_OnlineOffline.Text = "Offline";
            TB_Adres.Text = _currentEvent.LocationUrl;

        }

        private void CheckOnlineOffline(bool offline)
        {
            if (offline == true)
            {
                SetOfflineEvent();
            }

            if (offline == false)
            {
                SetOnlineEvent();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // set values
            TB_Name.Text = _currentEvent.Name;
            TB_StartDate.Text = Convert.ToString(_currentEvent.StartDate);
            TB_EndDate.Text = Convert.ToString(_currentEvent.EndDate);
            TB_Description.Text = _currentEvent.Description;
            CheckOnlineOffline(_currentEvent.Online);

            foreach (var user in eventLogic.GetEventUsers(_currentEvent.Id))
            {
                LB_Users.Items.Add(user);
            }
            

        }

        private void Btn_Join_Click(object sender, RoutedEventArgs e)
        {
            eventLogic.AddUserToEvent(_currentEvent.Id, _currentUser.UserId);
            LB_Users.Items.Add(_currentUser);
        }

        private void Btn_Leave_Click(object sender, RoutedEventArgs e)
        {
            eventLogic.RemoveUserFromEvent(_currentEvent.Id, _currentUser.UserId);
            LB_Users.Items.Remove(_currentUser);
        }
    }
}
