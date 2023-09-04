using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
using SkolaJezika.resources.services;
using SkolaJezika.resources.views.Search;
using SkolaJezika.resources.views.Sessions;
using SkolaJezika.resources.views.Students;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace SkolaJezika.resources.views.Teachers
{
    /// <summary>
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        private Teacher teacher;
        private SessionService sessionService;
        private StudentService studentService;
        private ICollectionView view;

        public TeacherWindow(Teacher loggedTeacher)
        {
            InitializeComponent();
            this.teacher = loggedTeacher;
            sessionService = new SessionService();
            studentService = new StudentService();
            view = CollectionViewSource.GetDefaultView(new ObservableCollection<Session>(teacher.Sessions));
            InitializeData();
        }

        private void InitializeData()
        {
            dataSessions.ItemsSource = view;
        }

        private void sessionDate_ValueChanged(object sender, EventArgs e)
        {
            if (sessionDate.SelectedDate.Equals(null))
            {
                dataSessions.ItemsSource = new ObservableCollection<Session>(teacher.Sessions);
                return;
            }
            dataSessions.ItemsSource = sessionService.GetSessionsBasedByTeacherIDAndDate(teacher.PersonalIdentityNumber, (DateTime)sessionDate.SelectedDate);
        }

        private void btnViewStudent_Click(object sender, RoutedEventArgs e)
        {
            Session session = (Session) dataSessions.SelectedItem;
            if (dataSessions.SelectedItems.Count == 0 || session.Status.Equals(EClassStatus.AVAILABLE))
            {
                MessageBox.Show("Prvo oznacite polje rezervisanog casa!");
                return;
            }
            Student student = studentService.FindBySessionID(session.Id);
            ViewStudentPersonalnfoWindow vspiw = new ViewStudentPersonalnfoWindow(student);
            vspiw.Show();
        }

        private void btnDeleteSession_Click(object sender, RoutedEventArgs e)
        {
            Session session = (Session)dataSessions.SelectedItem;
            if (dataSessions.SelectedItems.Count == 0 || session.Status.Equals(EClassStatus.RESERVED))
            {
                MessageBox.Show("You need to select something, or if you've selected something, you can delete only available sessions!");
                return;
            }
            sessionService.Delete(session.Id);
            dataSessions.ItemsSource = new ObservableCollection<Session>(teacher.Sessions);
            view.Refresh();
        }

        private void btnCreateSession_Click(object sender, RoutedEventArgs e)
        {
            CreateUpdateSession cus = new CreateUpdateSession(EWindowStatus.CREATE, null, teacher) ;
            cus.Show();
            dataSessions.ItemsSource = new ObservableCollection<Session>(teacher.Sessions);
        }

        private void btnViewPersonalInfo_Click(object sender, RoutedEventArgs e)
        {
            ViewUpdatePersonalData vupd = new ViewUpdatePersonalData(teacher);
            vupd.Show();
            dataSessions.ItemsSource = new ObservableCollection<Session>(teacher.Sessions);
         }

        private void btnSearchTeacher_Click(object sender, RoutedEventArgs e)
        {
            SearchTeacherWindow stw = new SearchTeacherWindow();
            stw.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Close();
        }
    }
}
