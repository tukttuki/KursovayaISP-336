using KursovayaISP_336.BDModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KursovayaISP_336.Pages
{
    /// <summary>
    /// Interaction logic for Notification_Page_add.xaml
    /// </summary>
    public partial class Notification_Page_add : Page
    {
        Notification data;
        public Notification_Page_add(Notification Data)
        {
            data = Data;
            DataContext = Data;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (data.Idrecruit==0||(data.IsNotification!=0&&data.IsNotification!=1)) throw new Exception("Заполните данные");
                if (data.Id == 0) CoreModel.init().Notifications.Add(data);
                else CoreModel.init().Notifications.Update(data);
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