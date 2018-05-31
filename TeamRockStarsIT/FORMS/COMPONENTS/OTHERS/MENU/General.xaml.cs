using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TRS_Logic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS.MENU
{
    /// <summary>
    /// Interaction logic for General.xaml
    /// </summary>
    public partial class General : UserControl
    {
        int groupId;

        public General(int groupId)
        {
            this.groupId = groupId;
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            TRS_Domain.GROUP.Data selectedGroup = GroupControl_Logic.GetGroupInformation(groupId);

            DisplayImage(selectedGroup.Img);

            TB_GroupName.Text = selectedGroup.Name;
            CB_Region.ItemsSource = Enum.GetNames(typeof(GroupControl_Logic.Regions));
            RTB_Description.Text = selectedGroup.Description;
            CB_StartUpChannel.ItemsSource = selectedGroup.Chats;
        }

        private void BTN_UploudImage_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BTN_SaveGroupName_Click(object sender, RoutedEventArgs e)
        {
            GroupControl_Logic.SaveGroupName(groupId, TB_GroupName.Text);
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

        private void BTN_ChangeStartUpChannel_Click(object sender, RoutedEventArgs e)
        {
            GroupControl_Logic.ChangeStartUpChannel(groupId, CB_StartUpChannel.SelectedValue.ToString());
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
