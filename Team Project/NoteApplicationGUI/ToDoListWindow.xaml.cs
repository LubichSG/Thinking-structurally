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
        public int id;
        public NoteToDoList _note;


        public event Action<Window> userClosedWindow;
        List<ContentToDo> notes = new List<ContentToDo>(); 
        public ToDoListWindow(User user, NoteToDoList note)
        {
            InitializeComponent();
            ToDoListDataGrid.ItemsSource = notes;
            _user = user;
            _note = note;
            if (_note != null)
            {
                HeadlineBox.Text = note.Headline;
                ToDoListDataGrid.ItemsSource = note.Notes;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            if (_note?.Id == null && notes != null && !String.IsNullOrEmpty(HeadlineBox.Text) || _note?.Id > 0 && (_note.Headline != HeadlineBox.Text || 
                _note.Notes != notes) && !String.IsNullOrEmpty(HeadlineBox.Text))

            {
                MessageBox.Show("Do you want to save the record?");
            }
            else { userClosedWindow?.Invoke(this); }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(HeadlineBox.Text) && (notes != null))
            {
                if (_note?.Id == null)
                {
                    if (noteManager.UniqueHeadline(HeadlineBox.Text))
                    {
                        _note = noteManager.SaveNoteToDoList(HeadlineBox.Text, 0, DateTime.Now, notes, _user.Id);
                    }
                    else { MessageBox.Show("Headline is not unique!"); }
                }
                else
                {

                    _note=noteManager.SaveNoteToDoList(HeadlineBox.Text, _note.Id, DateTime.Now, notes, _user.Id);
                }
            }
            else { MessageBox.Show("Headline and text box must be filled!"); }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
