using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window  
    {
        UserManager userManager = new UserManager();
        NoteManager noteManager = new NoteManager();


        public User _user;

            public MainWindow(User user)
        {
            InitializeComponent();
            _user = user;
        }
        private void ViewNotesButton_Click(object sender, RoutedEventArgs e)
        {
            var ideaNotes = noteManager.FindAllUserIdeaNotes(_user.Id);
            var listNotes = noteManager.FindAllUserListNotes(_user.Id);
            ViewRecordsWindow viewWindow = new ViewRecordsWindow(_user, ideaNotes, listNotes);
            viewWindow.userClosedWindow += SeeThisWindowAgain;
            viewWindow.Show();
            this.Hide();
        }

        private void CreateNoteButton_Click(object sender, RoutedEventArgs e)
        {
            CreateRecordWindow createWindow = new CreateRecordWindow(_user);
            createWindow.userClosedWindow += SeeThisWindowAgain;
            createWindow.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SeeThisWindowAgain(Window window)
        {
            this.Show();
            window.Close();
        }
    }
}
