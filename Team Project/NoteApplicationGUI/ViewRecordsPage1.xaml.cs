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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Team_Project;

namespace NoteApplicationGUI
{
    /// <summary>
    /// Логика взаимодействия для ViewRecordsPage1.xaml
    /// </summary>
    public partial class ViewRecordsPage1 : Page
    {
        NoteManager noteManager = new NoteManager();
        ViewRecordsWindow _window;
        private List<Note> _notes;
        private User _user;
        public ViewRecordsPage1(ViewRecordsWindow window, List<Note> notes, User user)
        {
            InitializeComponent();
            _window = window;
            _notes = notes;
            _user = user;
            var buttons = new List<Button>() { this.Note1, this.Note2, this.Note3, this.Note4, this.Note5 };
            for(int i = 0; i < 5; i++)
            {
                NameButtons(buttons[i], _notes[i]);
            }
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            _window.ShowButtonsToAddNote();
        }

        private void Note1_Click(object sender, RoutedEventArgs e)
        {
            _window.ShowButtonToViewNote(noteManager.FindNoteByUserAndHeadline(_user, Note1.Content));
        }

        private void Note2_Click(object sender, RoutedEventArgs e)
        {
            _window.ShowButtonToViewNote(noteManager.FindNoteByUserAndHeadline(_user, Note2.Content));
        }

        private void Note3_Click(object sender, RoutedEventArgs e)
        {
            _window.ShowButtonToViewNote(noteManager.FindNoteByUserAndHeadline(_user, Note3.Content));
        }

        private void Note4_Click(object sender, RoutedEventArgs e)
        {
            _window.ShowButtonToViewNote(noteManager.FindNoteByUserAndHeadline(_user, Note4.Content));
        }

        private void Note5_Click(object sender, RoutedEventArgs e)
        {
            _window.ShowButtonToViewNote(noteManager.FindNoteByUserAndHeadline(_user, Note5.Content));
        }

        private void NameButtons(Button button, Note note)
        {
            button.Content = note.Headline;
        }
    }
}
