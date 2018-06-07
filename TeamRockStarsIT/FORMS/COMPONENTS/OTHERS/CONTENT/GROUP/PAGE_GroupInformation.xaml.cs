using System;
using System.Collections.Generic;
using System.IO;
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
using TRS_Domain.GROUP;
using TRS_Domain.USER;
using TRS_Logic;

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS.CONTENT.GROUP
{
    /// <summary>
    /// Interaction logic for PAGE_GroupInformation.xaml
    /// </summary>
    public partial class PAGE_GroupInformation : Page
    {
        //MEmory:
        private TRS_Domain.GROUP.Data groupdata;
        private TRS_Domain.USER.Data client;
        private FormMain Main;
        private TRS_Logic.Group_Logic grouplogic = new Group_Logic();
        private ClientLogic clientLogic = new ClientLogic();


        public PAGE_GroupInformation(TRS_Domain.GROUP.Data Groupdata, TRS_Domain.USER.Data Client, FormMain main)
        {
            InitializeComponent();
            client = Client;
            groupdata = Groupdata;
            Main = main;
            Lbl_GroupName.Content = Groupdata.Name;

        }

        private void BTN_JoinGroup_Click(object sender, RoutedEventArgs e)
        {
            if (grouplogic.JoinGroup(client, groupdata))
            {
                BTN_JoinGroup.IsEnabled = false;
                client = clientLogic.LoadClient((client.UserId));

                Main.LB_Groups.Items.Clear();
                foreach (var item in client.Groups)
                {
                    Main.LB_Groups.Items.Add(item);
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (groupdata.Img != null)
            {
                var image = new BitmapImage();
                using (var mem = new MemoryStream(groupdata.Img))
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                image.Freeze();

                RCTL_GroupImage.Fill = new ImageBrush(image);
            }
        }
    }
}
