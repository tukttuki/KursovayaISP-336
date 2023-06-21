using KursovayaISP_336.BDModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KursovayaISP_336.Pages
{
    /// <summary>
    /// Interaction logic for Recruit_Page.xaml
    /// </summary>
    public partial class Recruit_Page : Page
    {
        public Recruit_Page()
        {
            InitializeComponent();
            DataGridEmployee.ItemsSource = CoreModel.init().Recruits.ToList();
        }
        private void Update()
        {
            DataGridEmployee.ItemsSource = CoreModel.init().Recruits.ToList();
        }
        private void Add_Show_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Recruit_Page_add(new Recruit()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEmployee.SelectedItem == null)
                return;

            Recruit data = DataGridEmployee.SelectedItem as Recruit;
            if (MessageBox.Show("Удаление", "Удалить выбранный элемент?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Recruits.Remove(data);
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
            NavigationService.Navigate(new Recruit_Page_add(DataGridEmployee.SelectedItem as Recruit));
        }
    }
}