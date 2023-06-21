using KursovayaISP_336.BDModels;
using KursovayaISP_336.Windows;
using MySqlConnector;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace KursovayaISP_336
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var bild = new MySqlConnectionStringBuilder
            {
                Server = "cfif31.ru",
                Port = 3306,
                UserID = "ISPr23-36_MurzinKA_Kurs",
                Database = "ISPr23-36_MurzinKA_Kurs",
                Password = "ISPr23-36_MurzinKA_Kurs",
                CharacterSet = "utf8"
            };
            Trace.WriteLine(bild.ConnectionString);
        }

        private void Author_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text == null && PassTB.Text == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            var user = CoreModel.init().Users.FirstOrDefault(u => u.Login == LoginTB.Text && u.Password == PassTB.Text);
            if (user == null)
            {
                MessageBox.Show($"Такого пользователя нет");
                return;
            }
            MessageBox.Show($"Добро пожаловать {user.Login}");
            Window_Menu wind = new Window_Menu();
            wind.Show();
            Close();
        }
    }
}