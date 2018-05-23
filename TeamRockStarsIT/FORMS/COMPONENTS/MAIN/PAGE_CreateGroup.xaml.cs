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
    /// Interaction logic for PAGE_CreateGroup.xaml
    /// </summary>
    public partial class PageCreateGroup : Page
    {
        // Memory:
        private Frame _mainFrame;
        public PageCreateGroup(Frame mainFrame)
        {
            _mainFrame = mainFrame;
            InitializeComponent();
        }
    }
}
