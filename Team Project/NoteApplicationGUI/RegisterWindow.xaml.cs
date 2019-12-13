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

namespace NoteApplicationGUI
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void UnregisterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

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
                    //return value will be needed in the logic
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

            return true;
        }
    }
}
