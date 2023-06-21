using KursovayaISP_336.BDModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KursovayaISP_336.Pages
{
    /// <summary>
    /// Interaction logic for Notification_Page.xaml
    /// </summary>
    public partial class Notification_Page : Page
    {
        public Notification_Page()
        {
            InitializeComponent();
            DataGridEmployee.ItemsSource = CoreModel.init().Notifications.ToList();
        }
        private void Update()
        {
            DataGridEmployee.ItemsSource = CoreModel.init().Notifications.ToList();
        }
        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Notification_Page_add(new Notification()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEmployee.SelectedItem == null)
                return;

            Notification data = DataGridEmployee.SelectedItem as Notification;
            if (MessageBox.Show("Удаление", "Удалить выбранный элемент?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Notifications.Remove(data);
                CoreModel.init().SaveChanges();
                Update();
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DataGridEmployee.SelectedItem == null)
                return;
            NavigationService.Navigate(new Notification_Page_add(DataGridEmployee.SelectedItem as Notification));
        }
    }
}