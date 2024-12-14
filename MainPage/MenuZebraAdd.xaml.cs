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
    /// Логика взаимодействия для MenuZebraAdd.xaml
    /// </summary>
    public partial class MenuZebraAdd : Page
    {
        public MenuZebraAdd()
        {
            InitializeComponent();
            DGMenu.ItemsSource = ZebraEntities.GetContext().Zakaz.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new Add(null));
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var tovarForRemoving = DGMenu.SelectedItems.Cast<Zakaz>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующее {tovarForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ZebraEntities.GetContext().Zakaz.RemoveRange(tovarForRemoving);
                    ZebraEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGMenu.ItemsSource = ZebraEntities.GetContext().Zakaz.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new Add((sender as Button).DataContext as Zakaz));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ZebraEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGMenu.ItemsSource = ZebraEntities.GetContext().Zakaz.ToList();
            }
        }
    }
}
