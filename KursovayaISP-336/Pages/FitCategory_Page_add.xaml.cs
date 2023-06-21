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
    public partial class FitCategory_Page_add : Page
    {
        FitCategory data;
        public FitCategory_Page_add(FitCategory Data)
        {
            data=Data;
            DataContext = Data;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(data.Name)) throw new Exception("Заполните данные");
                if (data.Id == 0) CoreModel.init().FitCategories.Add(data);
                else CoreModel.init().FitCategories.Update(data);
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