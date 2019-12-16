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


        public User _user;
        //public ParkingSession _currentSession;
        //public List<ParkingSession> _pastSessions;
        //public List<DateTime> entryDTs;
        //public MainWindow(string login)
        //{
        //    InitializeComponent();
        //    this.Show();
        //    _parkingManager = new ParkingManager();
        //    _currentUser = _parkingManager.ReturnUser(login);

            public MainWindow(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void ViewNotesButton_Click(object sender, RoutedEventArgs e)
        {
            ViewRecordsWindow viewWindow = new ViewRecordsWindow(_user.Login);
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
