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
using Microsoft.Win32;
using TRS_Logic;

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS.MENU
{
    /// <summary>
    /// Interaction logic for General.xaml
    /// </summary>
 /// <summary>
    /// Interaction logic for General.xaml
    /// </summary>
    public partial class General : UserControl
    {
        private byte[] BitMap;
        private string PicturePath;
        int groupId;
        private Frame frameimin;
        private FORMS.FormMain Main;
  
        private TRS_Domain.USER.Data _client;
        ClientLogic clientLogic = new ClientLogic();
        public General(int groupId, Frame frame, TRS_Domain.USER.Data client, FORMS.FormMain main)
        {
            this.groupId = groupId;
            InitializeComponent();
            frameimin = frame;
            _client = client;
            Main = main;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            TRS_Domain.GROUP.Data selectedGroup = GroupControl_Logic.GetGroupInformation(groupId);
            ChatLogic chatlogic = new ChatLogic();

            DisplayImage(selectedGroup.Img);

            TB_GroupName.Text = selectedGroup.Name;
            CB_Region.ItemsSource = Enum.GetNames(typeof(GroupControl_Logic.Regions));
            CB_Region.SelectedItem = selectedGroup._region;
            RTB_Description.Text = selectedGroup.Description;
           
        }
        private void ShowImage()
        {
            var image = new BitmapImage();
            using (var mem = new MemoryStream(BitMap))
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

            IMG_GroupImage.Fill = new ImageBrush(image);
        }

        private void BTN_UploudImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filedialog.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp";
            filedialog.FilterIndex = 2;
            if (filedialog.ShowDialog() == true)
            {
                BitMap = File.ReadAllBytes($@"{filedialog.FileName}");
                PicturePath = filedialog.FileName;
                ShowImage();
            }
            GroupControl_Logic.UpdateImg(groupId,BitMap);
        }
        

        private void BTN_SaveGroupName_Click(object sender, RoutedEventArgs e)
        {
            GroupControl_Logic.SaveGroupName(groupId, TB_GroupName.Text);
            _client = clientLogic.LoadClient((_client.UserId));

            Main.LB_Groups.Items.Clear();
            foreach (var item in _client.Groups)
            {
                Main.LB_Groups.Items.Add(item);
            }

        }

        private void BTN_SaveGroupRegion_Click(object sender, RoutedEventArgs e)
        {
            GroupControl_Logic.SaveGroupRegion(groupId, CB_Region.SelectedValue.ToString());
        }

        private void BTN_EmptyDescription_Click(object sender, RoutedEventArgs e)
        {
            RTB_Description.Text = "";
        }

        private void BTN_ResetDescription_Click(object sender, RoutedEventArgs e)
        {
            RTB_Description.Text = GroupControl_Logic.GetGroupInformation(groupId).Description;

        }

        private void BTN_SaveDescription_Click(object sender, RoutedEventArgs e)
        {
            GroupControl_Logic.SaveDescription(groupId, RTB_Description.Text);
        }



        private void DisplayImage(byte[] image)
        {
            if (image != null)
            {
                var Image = new BitmapImage();
                using (var mem = new MemoryStream(image))
                {
                    mem.Position = 0;
                    Image.BeginInit();
                    Image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    Image.CacheOption = BitmapCacheOption.OnLoad;
                    Image.UriSource = null;
                    Image.StreamSource = mem;
                    Image.EndInit();
                }
                Image.Freeze();
                IMG_GroupImage.Fill = new ImageBrush(Image);
            }
        }
    }
}
