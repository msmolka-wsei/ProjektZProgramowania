using ProjektZProgramowania.Data;
using ProjektZProgramowania.Enities;
using ProjektZProgramowania.Services;
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
using static ProjektZProgramowania.Enities.Notification;

namespace ProjektZProgramowania
{
    /// <summary>
    /// Logika interakcji dla klasy AddNotification.xaml
    /// </summary>
    public partial class AddNotification : Window
    {
        long userId;
        public AddNotification(long? id)
        {
            InitializeComponent();
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
            UserMenu userMenu = new UserMenu(userId);
            userMenu.Show();
            this.Close();
        }

        private void SubmitNotification(object sender, RoutedEventArgs e)
        {
            if(TitleBox.Text.Length == 0 || DescriptionBox.Text.Length == 0 || ComboBoxValue.Text.Length == 0)
            {
                string messageBoxText = "Introduced incorrect data.";
                string caption = "Warning";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                IDataService<Notification> notificationService = new GenericDataService<Notification>(new ApplicationDbContextFactory());
                Notification notification = new() { title = TitleBox.Text, description = DescriptionBox.Text, priority = Enum.Parse<PriorityType>(ComboBoxValue.Text), creatorId = userId};
                notificationService.Create(notification).Wait();

                string messageBoxText = "Done.";
                string caption = "Done";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }
    }
}
