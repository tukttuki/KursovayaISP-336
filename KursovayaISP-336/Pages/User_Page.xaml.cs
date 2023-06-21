﻿using KursovayaISP_336.BDModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KursovayaISP_336.Pages
{
    /// <summary>
    /// Interaction logic for User_Page.xaml
    /// </summary>
    public partial class User_Page : Page
    {
        public User_Page()
        {
            InitializeComponent();
            DataGridEmployee.ItemsSource = CoreModel.init().Users.ToList();
        }
        private void Update()
        {
            DataGridEmployee.ItemsSource = CoreModel.init().Users.ToList();
        }
        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new User_Page_add(new User()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEmployee.SelectedItem == null)
                return;

            User data = DataGridEmployee.SelectedItem as User;
            if (MessageBox.Show("Удаление", "Удалить выбранный элемент?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Users.Remove(data);
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
            NavigationService.Navigate(new User_Page_add(DataGridEmployee.SelectedItem as User));
        }

        private void DataGridEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}