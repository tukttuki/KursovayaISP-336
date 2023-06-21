using KursovayaISP_336.BDModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KursovayaISP_336.Pages
{
    /// <summary>
    /// Interaction logic for Employee_Page_add.xaml
    /// </summary>
    public partial class Employee_Page_add : Page
    {
        Employee data;
        public Employee_Page_add(Employee Data)
        {
            data = Data;
            DataContext = Data;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(data.FirstName) ||
                    string.IsNullOrEmpty(data.SecondName) ||
                    string.IsNullOrEmpty(data.Patronymic)) throw new Exception("Заполните данные");
                if (data.Id == 0) CoreModel.init().Employees.Add(data);
                else CoreModel.init().Employees.Update(data);
                CoreModel.init().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Результат", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (data.Id != 0)
            {
                CoreModel.init().Entry(data).Reload();
            }
        }
    }
}