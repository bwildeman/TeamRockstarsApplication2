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

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS.MENU
{
    /// <summary>
    /// Interaction logic for Channels.xaml
    /// </summary>
    public partial class Channels : UserControl
    {
        int groupId;
        private Frame frameimin;
        public Channels(int groupId, bool Owner, Frame frame)
        {
            this.groupId = groupId;
            frameimin = frame;
            InitializeComponent();

            if (!Owner)
            {
                ElementsVisibility(Visibility.Hidden);
                ElementsMove(-300);
            }
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //  initialize the page
            object[] Channels = TRS_Logic.GroupControl_Logic.GetChannels(groupId);
            DG_Channels.Items.Add(Channels);
        }

        private void BTN_AddChannel_Click(object sender, RoutedEventArgs e)
        {
            //Window w = new WINDOW_AddChannel(_selectedGroup.GroupId);
            //w.ShowDialog();
        }

        private void BTN_CS_Edit_Click(object sender, RoutedEventArgs e)
        {
            //  To-Do
            //  Window w = new WINDOW_EditChannel(selectedChannel);
            //  w.ShowDialog();
        }

        private void BTN_CS_Remove_Click(object sender, RoutedEventArgs e)
        {
            //  To-Do
            //  (Window.Confirm = click) => Delete(selected Channel)
        }

        #region Design Methods

        private void ElementsMove(int change)
        {
        }

        private void ElementsVisibility(Visibility vis)
        {
            FrameworkElement[] HidingElements = { LBL_CS, LB_CS_Channels, BTN_CS_Add, BTN_CS_Edit, BTN_CS_Remove,  };
            for (int i = 0; i < HidingElements.Length; i++)
            {
                HidingElements[i].Visibility = vis;
            }
        }

        #endregion

    }
}
