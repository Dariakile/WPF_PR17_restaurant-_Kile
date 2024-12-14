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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        private Zakaz _currentZakaz = new Zakaz();
        public Add(Zakaz selectedZakaz)
        {
            InitializeComponent();

            if (selectedZakaz != null)
                _currentZakaz = selectedZakaz;

            DataContext = _currentZakaz;
            ComboName.ItemsSource = ZebraEntities.GetContext().TableName.ToList();
            ComboStol.ItemsSource = ZebraEntities.GetContext().TableStol.ToList();
            ComboStatus.ItemsSource = ZebraEntities.GetContext().TableStatus.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentZakaz.kolichestvo))
                errors.AppendLine("Укажите количество");

            if (_currentZakaz.TableName == null)
                errors.AppendLine("Укажите наименование");

            if (_currentZakaz.cena <= 0)
                errors.AppendLine("Цена не может быть меньше или равно 0");

            if (_currentZakaz.TableStatus == null)
                errors.AppendLine("Укажите статус");

            if (_currentZakaz.TableStol == null)
                errors.AppendLine("Укажите стол");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentZakaz.id == 0)
                ZebraEntities.GetContext().Zakaz.Add(_currentZakaz);
            try
            {
                ZebraEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
