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
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using TRS_Domain.USER;
using TRS_Logic;

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS.POP_UPS.GROUP
{
    /// <summary>
    /// Interaction logic for FORM_CreateGroup.xaml
    /// </summary>
    public partial class FORM_CreateGroup : Window
    {
        public FORM_CreateGroup()
        {
            InitializeComponent();
        }

        //  Memory:
        private byte[] BitMap;
        private Data Client;

        //  References:
        Group_Logic groupLogic = new Group_Logic();

        //  Private methode:
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

            RCTL_GroupImage.Fill = new ImageBrush(image);
        }
        public FORM_CreateGroup(Data client)
        {
            Client = client;
            InitializeComponent();
        }

        private void Btn_GetImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filedialog.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp";
            filedialog.FilterIndex = 2;
            if (filedialog.ShowDialog() == true)
            {
                BitMap = File.ReadAllBytes($@"{filedialog.FileName}");
                ShowImage();
            }
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (groupLogic.CreateGroup(Client.UserId, TB_Name.Text, TB_Description.Text, BitMap))
            {
                this.DialogResult = true;
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
