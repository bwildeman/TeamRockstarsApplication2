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

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS
{
    /// <summary>
    /// Interaction logic for PAGE_UserInformation.xaml
    /// </summary>
    public partial class PageUserInformation : Page
    {
        private TRS_Domain.USER.Data _client;
        private Frame _contentFrame;
        private Frame _mainContent;

        public PageUserInformation(TRS_Domain.USER.Data client, Frame contentFrame, Frame mainFrame)
        {
            _client = client;
            _contentFrame = contentFrame;
            _mainContent = mainFrame;
            Loaded += PAGE_UserInformation_Loaded;
            InitializeComponent();
        }

        private void PAGE_UserInformation_Loaded(object sender, RoutedEventArgs e)
        {
            Lbl_Name.Content = $"{_client.Name} {_client.Surname}";
            if (_client.Img != null)
            {
                var image = new BitmapImage();
                using (var mem = new MemoryStream(_client.Img))
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
                
                Rectangle_Picture.Fill = new ImageBrush(image);
            }
        }
    }
}
