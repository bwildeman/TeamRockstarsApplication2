﻿using System;
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
        public Channels(int groupId, bool Owner)
        {
            this.groupId = groupId;
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
            Window w = new WINDOW_AddChannel();
            w.ShowDialog();
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
            FrameworkElement[] movingElements = { LBL_OC, CB_OC_Choose, BTN_OC_Select, BTN_OC_Select };
            for (int i = 0; i < movingElements.Length; i++)
            {
                Thickness t = movingElements[i].Margin;
                t.Top += change;
                movingElements[i].Margin = t;

            }
        }

        private void ElementsVisibility(Visibility vis)
        {
            FrameworkElement[] HidingElements = { LBL_CS, LB_CS_Channels, BTN_CS_Add, BTN_CS_Edit, BTN_CS_Remove, SEP_CS };
            for (int i = 0; i < HidingElements.Length; i++)
            {
                HidingElements[i].Visibility = vis;
            }
        }

        #endregion

    }
}