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
        private readonly Data _currentEvent;
        private readonly TRS_Domain.USER.Data _currentUser;
        readonly Event_Logic _eventLogic = new Event_Logic();
        private readonly Frame _contentFrame;

        public PAGE_EventOverview(Data selectedEvent, TRS_Domain.USER.Data user)
        {
            InitializeComponent();
            _currentEvent = new Data(selectedEvent);
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
            if (offline)
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
            CheckIfUserIsOwner(_currentUser);
            // set values
            TB_Name.Text = _currentEvent.Name;
            TB_StartDate.Text = Convert.ToString(_currentEvent.StartDate);
            TB_EndDate.Text = Convert.ToString(_currentEvent.EndDate);
            TB_Description.Text = _currentEvent.Description;
            CheckOnlineOffline(_currentEvent.Online);

            foreach (var user in _eventLogic.GetEventUsers(_currentEvent.Id))
            {
                LB_Users.Items.Add(user);
            }


        }

        private void Btn_Join_Click(object sender, RoutedEventArgs e)
        {
            if (!LB_Users.Items.Contains(_currentUser))
            {
                _eventLogic.AddUserToEvent(_currentEvent.Id, _currentUser.UserId);
                LB_Users.Items.Add(_currentUser);
            }

        }

        private void Btn_Leave_Click(object sender, RoutedEventArgs e)
        {
            if (LB_Users.Items.Contains(_currentUser))
            {
                _eventLogic.RemoveUserFromEvent(_currentEvent.Id, _currentUser.UserId);
                LB_Users.Items.Remove(_currentUser);
            }

        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            _contentFrame.Content = new PAGE_EditEvent(_currentEvent);
        }

        private void CheckIfUserIsOwner(TRS_Domain.USER.Data user)
        {
            if (user.UserId == _currentEvent.EventOwnerId || user.Type == 1)
            {
                Btn_Edit.IsHitTestVisible = true;
            }
            else
            {
                Btn_Edit.IsHitTestVisible = false;
                Btn_Edit.Opacity = 0;
            }
        }
    }
}
