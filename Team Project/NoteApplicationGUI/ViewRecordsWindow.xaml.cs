using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Team_Project;

namespace NoteApplicationGUI
{
    /// <summary>
    /// Логика взаимодействия для ViewRecordsWindow.xaml
    /// </summary>
    public partial class ViewRecordsWindow : Window
    {
        UserManager userManager = new UserManager();
        public User _user;
        public event Action<Window> userClosedWindow;
        public ViewRecordsWindow(User user)
        {
            
            InitializeComponent();
            _user = user;
            ViewContent.Content = new ViewRecordsPage1();
        }

        private void СhangeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            userClosedWindow?.Invoke(this);
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            HaphazardIdeaButton.Visibility = Visibility.Visible;
            ToDoListButton.Visibility = Visibility.Visible;
        }

        private void HaphazardIdeaButton_Click(object sender, RoutedEventArgs e)
        {
            HaphazardIdeasWindow ideaWindow = new HaphazardIdeasWindow(_user);
            ideaWindow.userClosedWindow += SeeThisWindowAgain;
            ideaWindow.Show();
            HaphazardIdeaButton.Visibility = Visibility.Hidden;
            ToDoListButton.Visibility = Visibility.Hidden;
            this.Hide();
        }

        private void ToDoListButton_Click(object sender, RoutedEventArgs e)
        {
            ToDoListWindow listWindow = new ToDoListWindow(_user);
            listWindow.userClosedWindow += SeeThisWindowAgain;
            listWindow.Show();
            HaphazardIdeaButton.Visibility = Visibility.Hidden;
            ToDoListButton.Visibility = Visibility.Hidden;
            this.Hide();
        }

        private void SeeThisWindowAgain(Window window)
        {
            this.Show();
            window.Close();
        }
    }
}
