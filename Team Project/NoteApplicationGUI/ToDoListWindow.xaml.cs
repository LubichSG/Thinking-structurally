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
    /// Логика взаимодействия для ToDoListWindow.xaml
    /// </summary>
    public partial class ToDoListWindow : Window
    {
        UserManager userManager = new UserManager();
        public User _user;
        public event Action<Window> userClosedWindow;
        public ToDoListWindow(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            userClosedWindow?.Invoke(this);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToDoListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
