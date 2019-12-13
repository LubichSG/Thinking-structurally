using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        UserManager userManager = new UserManager();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void UnregisterButton_Click(object sender, RoutedEventArgs e)
        {
            WelcomeWindow welcomeWindow = new WelcomeWindow();
            welcomeWindow.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(NameTextBox.Text) || String.IsNullOrEmpty(SurnameTextBox.Text) ||
                String.IsNullOrEmpty(PasswordConfirmTextBox.Password) ||
                String.IsNullOrEmpty(PhoneNumberTextBox.Text) || String.IsNullOrEmpty(PasswordTextBox.Password))
            {
                MessageBox.Show("All blanks should be filled!");
            }
            else if(CheckUserInput(NameTextBox.Text, SurnameTextBox.Text, PhoneNumberTextBox.Text, PasswordTextBox.Password, PasswordConfirmTextBox.Password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private bool CheckUserInput(string name, string surname, string phone, string password, string passwordCheck)
        {
            int[] digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach(var digit in digits)
            {
                if (name.Contains(digit.ToString()) || surname.Contains(digit.ToString()))
                {
                    MessageBox.Show("Name and surname should contain letters only!");
                    return false;
                }
            }

            Regex phonePattern = new Regex(@"^[+]\d*");
            if (!phonePattern.IsMatch(phone))
            {
                MessageBox.Show("Phone number should start with \"+\" and contain digits only!");
                return false;
            }

            if (!password.Equals(passwordCheck))
            {
                MessageBox.Show("Passwords do not coincide!");
                return false;
            }

            if(userManager.CheckUserExists(phone, password))
            {
                MessageBox.Show("User with this login already exists!");
                return false;
            }

            return true;
        }
    }
}
