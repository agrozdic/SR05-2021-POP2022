using SkolaJezika.resources.managers;
using SkolaJezika.resources.services;
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
using System.Windows.Shapes;

namespace SkolaJezika.resources.views
{
    /// <summary>
    /// Interaction logic for SearchTeachersWindow.xaml
    /// </summary>
    public partial class SearchTeachersWindow : Window
    {
        private int schoolID;
        private TeacherService service;
        public SearchTeachersWindow(int schoolID)
        {
            InitializeComponent();
            this.schoolID = schoolID;
            service = new TeacherService();
            InitializeSchoolTeachers();
        }

        private void InitializeSchoolTeachers()
        {
            dataTeachers.ItemsSource = service.GetTeachersBasedBySchoolID(schoolID);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
