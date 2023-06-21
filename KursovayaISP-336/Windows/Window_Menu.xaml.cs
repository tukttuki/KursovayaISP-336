
using KursovayaISP_336.Pages;
using System.Windows;

namespace KursovayaISP_336.Windows
{
    /// <summary>
    /// Interaction logic for Window_Menu.xaml
    /// </summary>
    public partial class Window_Menu : Window
    {
        public Window_Menu()
        {
            InitializeComponent();
        }

        private void Show_Employee(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Employee_Page());
        }

        private void Show_FitCategory(object sender, RoutedEventArgs e)
        {

            FrameNav.Navigate(new FitCategory_Page());
        }

        private void Show_Notification(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Notification_Page());
            
        }

        private void Show_Recruit(object sender, RoutedEventArgs e)
        {

            FrameNav.Navigate(new Recruit_Page());
        }

        private void Show_User(object sender, RoutedEventArgs e)
        {

            FrameNav.Navigate(new User_Page());
        }
    }
}
