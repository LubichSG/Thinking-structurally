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
        public int count;
        public int id;
      
        public event Action<Window> userClosedWindow;

        public HaphazardIdeasWindow(User user, NoteHaphazardIdeas note)
        {
            InitializeComponent();
            _user = user;  
            count = 0;
            if(note != null)
            {
                HeadlineBox.Text = note.Headline;
                RecordTextBox.Text = note.Content;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(RecordTextBox.Text) && !String.IsNullOrEmpty(HeadlineBox.Text) && (count == 0))
                {
                MessageBox.Show("Do not want to save the record?");
                }
            else { userClosedWindow?.Invoke(this); }
        }

        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        { if(!String.IsNullOrEmpty(RecordTextBox.Text) && !String.IsNullOrEmpty(HeadlineBox.Text))
            {
                if (count == 0)
                {
                    if (noteManager.UniqueHeadline(HeadlineBox.Text))
                    {
                        id = noteManager.SaveNoteHaphazardIdeas(0, HeadlineBox.Text, DateTime.Now, RecordTextBox.Text, _user.Id);
                        count++;
                    }
                    else { MessageBox.Show("Headline is not unique!"); }
                }
                else
                {
                    
                    noteManager.SaveNoteHaphazardIdeas(id, HeadlineBox.Text, DateTime.Now, RecordTextBox.Text, _user.Id);
                    //DialogResult = true;
                    
                }
            }
        else { MessageBox.Show("Headline and text box must be filled!"); }

        }
    }
}
