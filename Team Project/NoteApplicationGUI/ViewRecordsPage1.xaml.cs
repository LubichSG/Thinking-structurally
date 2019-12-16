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

        ViewRecordsWindow _window;
        public ViewRecordsPage1(ViewRecordsWindow window)
        {
            InitializeComponent();
            _window = window;
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            _window.ShowButtonsToAddNote();
        }

    }
}
