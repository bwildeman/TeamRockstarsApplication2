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
    /// Interaction logic for PAGE_AddEvent.xaml
    /// </summary>
    public partial class PAGE_AddEvent : Page
    {
        // reference event logic
        Event_Logic eventLogic = new Event_Logic();

        private int _currentGroupId;

        public PAGE_AddEvent(int groupId)
        {
            InitializeComponent();
            _currentGroupId = groupId;
        }

        private void TB_Name_Copy_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9);
        }

        private void TB_Name_Copy1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9);
        }

        private void TB_Name_Copy2_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9);
        }

        private void TB_Name_Copy3_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9);
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

        private bool CheckRadioButtons()
        {
            var isOnline = false;

            if (RBtn_Online.IsChecked == true)
            {
                isOnline = true;
            }
            else if (RBtn_IRL.IsChecked == true)
            {
                isOnline = false;
            }

            return isOnline;
        }

        private string CheckLocation()
        {
            var location = "";

            if (RBtn_Online.IsChecked == true)
            {
                location = TB_Url.Text;
            }
            else if (RBtn_IRL.IsChecked == true)
            {
                location = TB_Adres.Text;
            }

            return location;
        }

        private void Btn_CreateEvent_Click_1(object sender, RoutedEventArgs e)
        {
            var groupId = _currentGroupId;
            // get event data from form
            var name = TB_Name.Text;
            DateTime startDate = Convert.ToDateTime(DateP_Start.Value);
            DateTime endDate = Convert.ToDateTime(DateP_End.Value);
            var online = CheckRadioButtons();
            var location = CheckLocation();
            var description = TB_Description.Text;

            eventLogic.CreateNewGroupEvent(new Data(groupId, name, startDate, endDate, online, location, description));
        }
    }
}
