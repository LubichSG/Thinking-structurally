﻿using System;
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
        List<ContentToDo> notes = new List<ContentToDo>(); //new
        public ToDoListWindow(User user, NoteToDoList note)
        //List<NoteToDoList> notes = new List<NoteToDoList>();
        {
            InitializeComponent();
            ToDoListDataGrid.ItemsSource = notes;//new
            //_user = user;
            //if (note != null)
            //{
            //    HeadlineBox.Text = note.Headline;
            //}
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
