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
    /// Логика взаимодействия для CreateRecordWindow.xaml
    /// </summary>
    public partial class CreateRecordWindow : Window
    {
        UserManager userManager = new UserManager();
        public User _user;
        public event Action<Window> userClosedWindow;

        public CreateRecordWindow(User user)
        {
            InitializeComponent();
          _user = user;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            userClosedWindow?.Invoke(this);
        }

        private void ToDoListButton_Click(object sender, RoutedEventArgs e)
        {
            ToDoListWindow listWindow = new ToDoListWindow(_user);
            listWindow.userClosedWindow += SeeThisWindowAgain;
            listWindow.Show();
            this.Hide();
        }

        private void HaphazardIdeaButton_Click(object sender, RoutedEventArgs e)
        {
            HaphazardIdeasWindow ideaWindow = new HaphazardIdeasWindow(_user);
            ideaWindow.userClosedWindow += SeeThisWindowAgain;
            ideaWindow.Show();
            this.Hide();
        }

        private void ViewSampleTemplatesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SeeThisWindowAgain(Window window)
        {
            this.Show();
            window.Close();
        }
    }
}
