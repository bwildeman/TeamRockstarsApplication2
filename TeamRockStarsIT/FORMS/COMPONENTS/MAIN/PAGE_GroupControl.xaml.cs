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

namespace TeamRockStarsIT.FORMS.COMPONENTS.MAIN
{
    /// <summary>
    /// Interaction logic for PAGE_GroupControl.xaml
    /// </summary>
    public partial class PAGE_GroupControl : Page
    {
        int groupId;
        public PAGE_GroupControl(int groupId)
        {
            this.groupId = groupId;
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LB_QuickMenu.Items.Add("General");
            LB_QuickMenu.Items.Add("Members");
            LB_QuickMenu.Items.Add("Channels");
            LB_QuickMenu.SelectedIndex = 0;
        }

        private void LB_QuickMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (LB_QuickMenu.SelectedItem.ToString())
            {
                case "General":
                    this.Panel.Content = new OTHERS.MENU.General(groupId);
                    break;
                case "Members":
                    this.Panel.Content = new OTHERS.MENU.Members(groupId);
                    break;
                case "Channels":
                    this.Panel.Content = new OTHERS.MENU.Channels(groupId);
                    break;
                default:
                    break;
            }
        }   
    }
}
