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
        NoteManager noteManager = new NoteManager();
        public User _user;
        public List<NoteHaphazardIdeas> _ideaNotes;
        public List<NoteToDoList> _listNotes;
        public event Action<Window> userClosedWindow;
        public Note noteToView;
        public ViewRecordsWindow(User user, List<NoteHaphazardIdeas> ideaNotes, List<NoteToDoList> listNotes)
        {
            InitializeComponent();
            _user = user;
            _ideaNotes = ideaNotes;
            _listNotes = listNotes;
            noteToView = null;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            userClosedWindow?.Invoke(this);
        }

        public void AddHaphazardIdea()
        {
            HaphazardIdeasWindow ideaWindow = new HaphazardIdeasWindow(_user, null);
            ideaWindow.userClosedWindow += SeeThisWindowAgain;
            ideaWindow.Show();
            this.Hide();
        }

        public void AddToDoList()
        {
            ToDoListWindow listWindow = new ToDoListWindow(_user, null);
            listWindow.userClosedWindow += SeeThisWindowAgain;
            listWindow.Show();
            this.Hide();
        }

        public void ShowIdeaNote(User user, string headline)
        {
            var noteToView = noteManager.FindNoteByUserAndHeadline(user.Id, headline);
            var newNoteToView = noteToView as NoteHaphazardIdeas;
            HaphazardIdeasWindow ideasWindow = new HaphazardIdeasWindow(user, newNoteToView);
            ideasWindow.userClosedWindow += SeeThisWindowAgain;
            ideasWindow.Show();
            this.Hide();
        }


        public void ShowListNote(User user, string headline)
        {
            var noteToView = noteManager.FindNoteByUserAndHeadline(user.Id, headline);
            var newNoteToView = noteToView as NoteToDoList;
            ToDoListWindow listWindow = new ToDoListWindow(user, newNoteToView);
            listWindow.userClosedWindow += SeeThisWindowAgain;
            listWindow.Show();
            this.Hide();
        }


        private void SeeThisWindowAgain(Window window)
        {
            noteManager = new NoteManager();
            ViewContent.Content = null;
            _ideaNotes = noteManager.FindAllUserIdeaNotes(_user.Id);
            _listNotes = noteManager.FindAllUserListNotes(_user.Id);
            this.Show();
            window.Close();
        }


        private void IdeasButton_Click(object sender, RoutedEventArgs e)
        {
            IdeasButton.Background = Brushes.LightSeaGreen;
            ListsButton.Background = Brushes.SeaShell;
            ViewIdeasPage page = new ViewIdeasPage(this, _ideaNotes, _user);
            ViewContent.Content = page;
        }

        private void ListsButton_Click(object sender, RoutedEventArgs e)
        {
            ListsButton.Background = Brushes.LightSeaGreen;
            IdeasButton.Background = Brushes.SeaShell;
            ViewListsPage page = new ViewListsPage(this, _listNotes, _user);
            ViewContent.Content = page;
        }
    }
}
