using SkolaJezika.resources.models;
using SkolaJezika.resources.services;
using SkolaJezika.resources.views;
using SkolaJezika.resources.views.Admin;
using SkolaJezika.resources.views.Students;
using SkolaJezika.resources.views.Teachers;
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

namespace SkolaJezika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        StudentService studentService;
        AdminService adminService;
        TeacherService teacherService;

        public LoginWindow()
        {
            InitializeComponent();
            studentService = new StudentService();
            adminService = new AdminService();
            teacherService = new TeacherService();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.Show();
            this.Close();
        }

        private void btnContinueAsGuest_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow gw = new GuestWindow();
            gw.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string personalIdentity = txtPersonalIdentityNumber.Text;
            string password = txtPassword.Password;
            Admin admin = adminService.FindByPersonalIDAndPassword(personalIdentity, password);
            Teacher teacher = teacherService.FindByPersonalIDAndPassword(personalIdentity, password);
            Student student = studentService.FindByPersonalIDAndPassword(personalIdentity, password);

            if (admin != null)
            {
                MessageBox.Show("Admin");
                AdminWindow adminView = new AdminWindow();
                adminView.Show();
                this.Close();
            }
            else if (teacher != null)
            {
                MessageBox.Show("Nastavnik");
                TeacherWindow teacherWindow = new TeacherWindow(teacher);
                teacherWindow.Show();
                this.Close();
            }
            else if (student != null)
            {
                MessageBox.Show("Student");
                StudentWindow studentWindow = new StudentWindow(student);
                studentWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login credentials are wrong!");
            }
        }
    }
}
