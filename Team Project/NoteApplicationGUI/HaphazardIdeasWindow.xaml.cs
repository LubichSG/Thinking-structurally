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
    /// Логика взаимодействия для HaphazardIdeasWindow.xaml
    /// </summary>
    public partial class HaphazardIdeasWindow : Window
    {
        UserManager userManager = new UserManager();
        NoteManager noteManager = new NoteManager();
        public User _user;
        public int id;
        public NoteHaphazardIdeas _note;


        public event Action<Window> userClosedWindow;

        public HaphazardIdeasWindow(User user, NoteHaphazardIdeas note)
        {
            InitializeComponent();
            _user = user;
            _note = note;
            if (note != null)
            {

                HeadlineBox.Text = note.Headline;
                RecordTextBox.Text = note.Content;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (_note?.Id == null && !String.IsNullOrEmpty(RecordTextBox.Text) && !String.IsNullOrEmpty(HeadlineBox.Text) || _note?.Id>0 && (_note.Headline != HeadlineBox.Text || _note.Content != RecordTextBox.Text) && !String.IsNullOrEmpty(HeadlineBox.Text))

                {
                MessageBox.Show("Do you want to save the record?");
                }
            else 
            { 
                userClosedWindow?.Invoke(this); 
            }
        }

        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        { 
            if(!String.IsNullOrEmpty(RecordTextBox.Text) && !String.IsNullOrEmpty(HeadlineBox.Text))
            {
                if (_note?.Id == null)
                {
                    if (noteManager.UniqueHeadline(HeadlineBox.Text))
                    {
                        _note = noteManager.SaveNoteHaphazardIdeas(0, HeadlineBox.Text, DateTime.Now, RecordTextBox.Text, _user.Id);
                    }
                    else { MessageBox.Show("Headline is not unique!"); }
                }
                else
                {
                    
                    _note = noteManager.SaveNoteHaphazardIdeas(_note.Id, HeadlineBox.Text, DateTime.Now, RecordTextBox.Text, _user.Id);
                }
            }
        else { MessageBox.Show("Headline and text box must be filled!"); }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            noteManager.DeleteNote(_note.Id);
            userClosedWindow?.Invoke(this);
            //noteManager.DeleteNote(_note.Id);
            //var ideaNotes = noteManager.FindAllUserIdeaNotes(_user.Id);
            //var listNotes = noteManager.FindAllUserListNotes(_user.Id);
            //ViewRecordsWindow viewWindow = new ViewRecordsWindow(_user, ideaNotes, listNotes);
            //viewWindow.Show();
            //this.Close();
        }
    }
}
