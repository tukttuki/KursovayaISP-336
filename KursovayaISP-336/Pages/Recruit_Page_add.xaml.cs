//using KursovayaISP_336.BDModels;
using KursovayaISP_336.BDModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KursovayaISP_336.Pages
{
    /// <summary>
    /// Interaction logic for FitCategory_Page_add.xaml
    /// </summary>
    public partial class Recruit_Page_add : Page
    {
        Recruit data;
        public Recruit_Page_add(Recruit Data)
        {
            data = Data;
            DataContext = Data;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(data.FirstName)||
                    string.IsNullOrEmpty(data.SecondName) ||
                    string.IsNullOrEmpty(data.Patronymic) ||
                    data.Fit==0) throw new Exception("Заполните данные");
                if (data.Id == 0) CoreModel.init().Recruits.Add(data);
                else CoreModel.init().Recruits.Update(data);
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