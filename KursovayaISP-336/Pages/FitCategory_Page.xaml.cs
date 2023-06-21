using KursovayaISP_336.BDModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KursovayaISP_336.Pages
{
    /// <summary>
    /// Interaction logic for FitCategory_Page.xaml
    /// </summary>
    public partial class FitCategory_Page : Page
    {
        public FitCategory_Page()
        {
            InitializeComponent();
            DataGridEmployee.ItemsSource = CoreModel.init().FitCategories.ToList();
        }
        private void Update()
        {
            DataGridEmployee.ItemsSource = CoreModel.init().FitCategories.ToList();
        }
        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FitCategory_Page_add(new FitCategory()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEmployee.SelectedItem == null)
                return;

            FitCategory data = DataGridEmployee.SelectedItem as FitCategory;
            if (MessageBox.Show("Удаление", "Удалить выбранный элемент?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().FitCategories.Remove(data);
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
            NavigationService.Navigate(new FitCategory_Page_add(DataGridEmployee.SelectedItem as FitCategory));
        }
    }
}