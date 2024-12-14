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

namespace WPF_PR17_restaurant__Kile.MainPage
{
    /// <summary>
    /// Логика взаимодействия для MenuZebra.xaml
    /// </summary>
    public partial class MenuZebra : Page
    {
        public MenuZebra()
        {
            InitializeComponent();
            DGMenu.ItemsSource = ZebraEntities.GetContext().Zakaz.ToList();
        }

        private void btnVhod_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new Avtorizacia());
        }
    }
}
