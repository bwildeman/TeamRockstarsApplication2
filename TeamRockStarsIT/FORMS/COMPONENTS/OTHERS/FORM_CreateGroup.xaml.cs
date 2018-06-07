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
using TRS_Domain.EXCEPTIONS;
using System.Windows.Threading;

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS
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
        private string PicturePath;
        private Data Client;
        private DispatcherTimer timer;

        //  References:
        Group_Logic groupLogic = new Group_Logic();
        InterestLogic interestLogic = new InterestLogic();

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

        private void RequiredFieldCheck(System.Windows.Controls.TextBox Field)
        {
            if (!string.IsNullOrEmpty(Field.Text))
            {
                Field.BorderBrush = new SolidColorBrush(Color.FromRgb(179, 171, 171));
                Field.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else
            {
                Field.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                Field.Background = new SolidColorBrush(Color.FromRgb(255, 167, 167));
            }
        }

        private void SetTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Lbl_Warning.Visibility = Visibility.Hidden;
            timer.Stop();
        }

        private void ShowWarning(string warningText)
        {
            Lbl_Warning.Content = warningText;
            Lbl_Warning.Visibility = Visibility.Visible;
            SetTimer();
        }

        //  Program:
        public FORM_CreateGroup(Data client)
        {
            Client = client;
            InitializeComponent();
            Loaded += FORM_CreateGroup_Loaded;
        }

        private void FORM_CreateGroup_Loaded(object sender, RoutedEventArgs e)
        {
            List<TRS_Domain.INTEREST.Data> Interest = interestLogic.GetAllVerifiedInterests();
            CBox_Interests.ItemsSource = Interest;
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
                PicturePath = filedialog.FileName;
                ShowImage();
            }
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (groupLogic.CreateGroup(Client, TB_Name.Text, TB_Description.Text, CBox_Interests.SelectedItem, PicturePath, BitMap))
                {
                    this.DialogResult = true;
                }
            }
            catch(EmptyField ex)
            {
                ShowWarning(ex.Message);
            }
            catch(MaxPhotoSizeReached ex)
            {
                ShowWarning(ex.Message);
            }
            catch(PhotoNotFound ex)
            {
                ShowWarning(ex.Message);
            }   
            catch(Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TB_Name_LostFocus(object sender, RoutedEventArgs e)
        {
            RequiredFieldCheck(TB_Name);
        }

        private void TB_Description_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                RequiredFieldCheck(TB_Description);
                if (TB_Description.Text.Length <= 20)
                {
                    throw new DescriptionTooShort();
                }
            }
            catch(DescriptionTooShort ex)
            {
                ShowWarning(ex.Message);
            }
        }
    }
}
