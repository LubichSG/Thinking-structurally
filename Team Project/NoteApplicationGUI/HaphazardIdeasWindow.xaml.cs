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

        public HaphazardIdeasWindow(string login)
        {
            InitializeComponent();
            _user = userManager.ReturnUser(login);
            count = 0;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            userClosedWindow?.Invoke(this);
        }

        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        { if(RecordTextBox.Text != null)
            {
                if (++count == 1)
                {
                    id = noteManager.SaveNoteHaphazardIdeas(0,HeadlineBox.Text, DateTime.Now, RecordTextBox.Text, _user.Id);
                }
                else
                {
                    noteManager.SaveNoteHaphazardIdeas(id, HeadlineBox.Text, DateTime.Now, RecordTextBox.Text, _user.Id);
                }
            }

        }
    }
}
