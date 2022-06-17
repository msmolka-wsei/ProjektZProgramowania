using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektZProgramowania
{
    /// <summary>
    /// Logika interakcji dla klasy UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        long userId;
        public UserMenu(long ?id)
        {
            try
            {
                userId = (long)id;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException();
            }
            InitializeComponent();
        }
        public UserMenu()
        {
            InitializeComponent();
        }
        private void CreateNotification_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddNotification addNotification = new AddNotification(userId);
            addNotification.Show();
            this.Close();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        private void ShowNotification_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ShowNotifications showNotifications = new ShowNotifications(userId);
            showNotifications.Show();
            this.Close();
        }
    }
}
