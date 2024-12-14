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
using WPF_PR17_restaurant__Kile.ApplicationData;
using WPF_PR17_restaurant__Kile.MainPage;

namespace WPF_PR17_restaurant__Kile
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.modelodb = new ZebraEntities();
            AppFrame.FrameMain = MyFrame;
            MyFrame.Navigate(new MenuZebra());
        }
    }
}
