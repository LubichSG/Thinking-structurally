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
        List<ContentToDo> notes = new List<ContentToDo>(); //new
        public ToDoListWindow(User user, NoteToDoList note)
        //List<NoteToDoList> notes = new List<NoteToDoList>();
        {
            InitializeComponent();
            ToDoListDataGrid.ItemsSource = notes;//new
            _user = user;
            if (note != null)
            {
                HeadlineBox.Text = note.Headline;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            if (_note?.Id == null && notes != null && !String.IsNullOrEmpty(HeadlineBox.Text) || _note?.Id > 0 && (_note.Headline != HeadlineBox.Text || 
                _note.Notes != notes) && !String.IsNullOrEmpty(HeadlineBox.Text))
            {
                MessageBox.Show("Do not want to save the record?");
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
                    //DialogResult = true;


                }
            }
            else { MessageBox.Show("Headline and text box must be filled!"); }

        }

          
    }
}
