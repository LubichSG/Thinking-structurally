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
        NoteManager noteManager = new NoteManager();
        public User _user;
        public int count;
        public event Action<Window> userClosedWindow;
        List<ContentToDo> notes = new List<ContentToDo>(); //new
        public ToDoListWindow(User user, NoteToDoList note)
        
        {
            InitializeComponent();
            ToDoListDataGrid.ItemsSource = notes;//new
            _user = user;
            count = 0;
            if (note != null)
            {
                HeadlineBox.Text = note.Headline;
            }
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            userClosedWindow?.Invoke(this);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            noteManager.SaveNoteToDoList();
            //{
            //    if (!String.IsNullOrEmpty(RecordTextBox.Text) && !String.IsNullOrEmpty(HeadlineBox.Text))
            //    {
            //        if (count == 0)
            //        {
            //            //if (noteManager.UniqueHeadline(HeadlineBox.Text))
            //            //{
            //            //    id = noteManager.SaveNoteHaphazardIdeas(0, HeadlineBox.Text, DateTime.Now, RecordTextBox.Text, _user.Id);
            //            //    count++;
            //            //}
            //            //else { MessageBox.Show("Headline is not unique!"); }
            //        }C:\Users\Софья\Source\Repos\Thinking-structurally\Team Project\Team Project\UserManager.cs
            //        else
            //        {

            //            noteManager.SaveNoteToDoList(id, HeadlineBox.Text, DateTime.Now, Number.Text, DateTime.Now, DataGridColumnHeader.Text, RecordTextBox.Text, _user.Id)


            //        }
            //    }
            //    else { MessageBox.Show("Headline and text box must be filled!"); }

            //}
            {
            //    if (!String.IsNullOrEmpty(HeadlineBox.Text)
                    
            //        if(count == 0)
            //        {


            //        }
                    
                                      

            //        }
            //}

        }

         
    }
}
