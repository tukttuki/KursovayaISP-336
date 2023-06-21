using KursovayaISP_336.BDModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KursovayaISP_336.Pages
{
    /// <summary>
    /// Interaction logic for Employee_Page.xaml
    /// </summary>
    public partial class Employee_Page : Page
    {
        public Employee_Page()
        {
            InitializeComponent();
            DataGridEmployee.ItemsSource = CoreModel.init().Employees.ToList();
        }
        private void Update()
        {
            DataGridEmployee.ItemsSource = CoreModel.init().Employees.ToList();
        }
        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Employee_Page_add(new Employee()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEmployee.SelectedItem == null)
                return;

            Employee data = DataGridEmployee.SelectedItem as Employee;
            if (MessageBox.Show("Удаление", "Удалить выбранный элемент?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Employees.Remove(data);
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
            NavigationService.Navigate(new Employee_Page_add(DataGridEmployee.SelectedItem as Employee));
        }
    }
}