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
using TeamRockStarsIT.FORMS.COMPONENTS.OTHERS;
using TRS_Domain.GROUP;
using TRS_Domain.USER;
using TRS_Logic;

namespace TeamRockStarsIT.FORMS.COMPONENTS.MAIN
{
    /// <summary>
    /// Interaction logic for PAGE_JoinGroup.xaml
    /// </summary>
    public partial class PageJoinGroup : Page
    {
        //  Memory:
        private Frame mainFrame_;
        private FormMain Main;
        private TRS_Domain.USER.Data userdata;

        //  Refernce logic layer
        private Group_Logic groupLogic = new Group_Logic();

        //  Program
        public PageJoinGroup(Frame mainFrame, TRS_Domain.USER.Data UserData, FormMain main)
        {
            mainFrame_ = mainFrame;
            Main = main;
            userdata = UserData;
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<TRS_Domain.GROUP.Data> ListInput = groupLogic.GetAllGroupsThatUserIsNotIn(userdata.UserId);

            //GroupsList.ItemsSource = ListInput;
           foreach (var item in ListInput)
           {
               //DGrid_Groups.Items.Add(new PAGE_GroupInformation(item));
               Frame testFrame = new Frame();
               testFrame.Width = 300;
               testFrame.Height = 300;

               //TODO
               testFrame.Content = new PAGE_GroupInformation(item,userdata, Main);

               //GroupsList.Add(testFrame);
               //DGrid_Groups.Items.Add(testFrame.Content = new PAGE_GroupInformation(item));
               GroupsList.Items.Add(testFrame);

           }
        }
    }
}
