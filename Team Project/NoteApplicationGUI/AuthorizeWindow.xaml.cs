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
    /// Логика взаимодействия для AuthorizeWindow.xaml
    /// </summary>
    public partial class AuthorizeWindow : Window
    {
        UserManager userManager = new UserManager();
        public AuthorizeWindow()
        {
            InitializeComponent();
        }

        private void AuthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(LoginTextBox.Text) || String.IsNullOrEmpty(PasswordTextBox.Password))
            {
                MessageBox.Show("All blanks should be filled!");
            }
            else if(userManager.CheckUserExists(LoginTextBox.Text, PasswordTextBox.Password))
            {
                MainWindow mainWindow = new MainWindow(LoginTextBox.Text);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid login or password");
            }
        }

        private void UnauthorizeButton_Click(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }
    }
}
