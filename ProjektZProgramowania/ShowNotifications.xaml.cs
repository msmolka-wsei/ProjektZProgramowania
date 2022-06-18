using ProjektZProgramowania.Data;
using ProjektZProgramowania.Enities;
using ProjektZProgramowania.Services;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logika interakcji dla klasy ShowNotifications.xaml
    /// </summary>
    public partial class ShowNotifications : Window
    {
        long userId;
        public ShowNotifications(long? id)
        {
            try
            {
                userId = (long)id;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException();
            }

            
            //ListBoxNotifications.ItemsSource = notificationList.ToList();
            InitializeComponent();
        }

        public ShowNotifications()
        {
            InitializeComponent();
        }

        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserMenu userMenu = new UserMenu(userId);
            userMenu.Show();
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void gridNotifications_Loaded(object sender, RoutedEventArgs e)
        {
            IDataService<Notification> notificationService = new GenericDataService<Notification>(new ApplicationDbContextFactory());
            IEnumerable<Notification> notificationList = notificationService.GettAllNotification(userId);

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Title");
            dt.Columns.Add("Description");
            dt.Columns.Add("Priority");
            foreach (Notification notification in notificationList)
            {
                dt.Rows.Add(notification.id, notification.title, notification.description, notification.priority);
            }

            gridNotifications.DataContext = dt.DefaultView;
        }

        private void DeleteNotification(object sender, RoutedEventArgs e)
        {
            IDataService<Notification> notificationService = new GenericDataService<Notification>(new ApplicationDbContextFactory());
            IEnumerable<Notification> notificationList = notificationService.GettAllNotification(userId);

            notificationService.DeleteButBetterThanPrevorious(userId, long.Parse(EnterId.Text));

            this.Hide();
            ShowNotifications showNotifications = new ShowNotifications(userId);
            showNotifications.Show();
            this.Close();
            
        }
    }
}
