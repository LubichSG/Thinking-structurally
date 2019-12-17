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
    /// Логика взаимодействия для ViewRecordsWindow.xaml
    /// </summary>
    public partial class ViewRecordsWindow : Window
    {
        UserManager userManager = new UserManager();
        public User _user;
        public List<Note> _notes;
        public event Action<Window> userClosedWindow;
        public Note noteToView;
        public ViewRecordsWindow(User user, List<Note> notes)
        {
            InitializeComponent();
            _user = user;
            _notes = notes;
            noteToView = null;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            userClosedWindow?.Invoke(this);
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

        public void ShowButtonsToAddNote()
        {
            HaphazardIdeaButton.Visibility = Visibility.Visible;
            ToDoListButton.Visibility = Visibility.Visible;
        }

        public void ShowButtonToViewNote(Note note)
        {
            //ViewNote.Visibility = Visibility.Visible;
            noteToView = note;
        }

        private void SeeThisWindowAgain(Window window)
        {
            this.Show();
            window.Close();
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            HaphazardIdeaButton.Visibility = Visibility.Hidden;
            ToDoListButton.Visibility = Visibility.Hidden;
            ViewRecordsPage2 page = new ViewRecordsPage2();
            ViewContent.Content = page;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            HaphazardIdeaButton.Visibility = Visibility.Hidden;
            ToDoListButton.Visibility = Visibility.Hidden;
            ViewRecordsPage1 page = new ViewRecordsPage1(this, _notes, _user);
            ViewContent.Content = page;
        }

        private void ViewNote_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
