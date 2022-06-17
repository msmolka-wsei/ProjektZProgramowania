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
    /// Logika interakcji dla klasy AddNotification.xaml
    /// </summary>
    public partial class AddNotification : Window
    {
        public AddNotification()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackToUserMenu(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserMenu userMenu = new UserMenu();
            userMenu.Show();
            this.Close();
        }
    }
}
