﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        private readonly TRS_Domain.USER.Data _currentUser;
        private readonly TRS_Domain.GROUP.Data _selectedGroup;
        private ClientClass ClientClass;
        readonly Event_Logic _eventLogic = new Event_Logic();
        private Frame _contentFrame;
        private Frame _channelFrame;
        private FORMS.FormMain _main;

        public PAGE_EventOverview(Frame contentFrame, Frame channelFrame, Data selectedEvent, TRS_Domain.USER.Data user, TRS_Domain.GROUP.Data selectedgroup, ClientClass clientClass, FORMS.FormMain main)
        {
            InitializeComponent();
            _channelFrame = channelFrame;
            _contentFrame = contentFrame;
            _currentEvent = selectedEvent;
            _currentUser = user;
            _selectedGroup = selectedgroup;
            ClientClass = clientClass;
            _main = main;
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
            TB_Adres.IsHitTestVisible = true;
            TB_Adres.Opacity = 1;
            Lbl_Adres.Opacity = 1;

            TB_Url.IsHitTestVisible = false;
            TB_Url.Opacity = 0.5;
            Lbl_Url.Opacity = 0.5;

            TB_OnlineOffline.Text = "Offline";
            TB_Adres.Text = _currentEvent.LocationUrl;

        }

        private void CheckOnlineOffline(bool online)
        {
            if (!online)
            {
                SetOfflineEvent();
            }
            if (online)
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
            if (LB_Users.Items.Cast<TRS_Domain.USER.Data>().ToList().Count > 0)
            {
                foreach (var user in LB_Users.Items.Cast<TRS_Domain.USER.Data>().ToList())
                {
                    if (user.UserId != _currentUser.UserId)
                    {
                        _eventLogic.AddUserToEvent(_currentEvent.Id, _currentUser.UserId);
                        LB_Users.Items.Add(_currentUser);
                        break;
                    }
                }
            }
            else
            {
                _eventLogic.AddUserToEvent(_currentEvent.Id, _currentUser.UserId);
                LB_Users.Items.Add((_currentUser));
            }

        }

        private void Btn_Leave_Click(object sender, RoutedEventArgs e)
        {
            if (LB_Users.Items.Cast<TRS_Domain.USER.Data>().ToList().Count > 0)
            {
                foreach (var user in LB_Users.Items.Cast<TRS_Domain.USER.Data>().ToList())
                {
                    if (user.UserId == _currentUser.UserId)
                    {
                        _eventLogic.RemoveUserFromEvent(_currentEvent.Id, _currentUser.UserId);
                        LB_Users.Items.Remove(user);
                        break;
                    }
                }
            }
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            _channelFrame.Content = new PAGE_EditEvent(_currentEvent, _contentFrame, _channelFrame, _currentUser, _selectedGroup, ClientClass, _main);
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
