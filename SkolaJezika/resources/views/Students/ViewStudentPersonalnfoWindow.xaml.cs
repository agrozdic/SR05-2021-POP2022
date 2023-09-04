using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
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

namespace SkolaJezika.resources.views.Students
{
    /// <summary>
    /// Interaction logic for ViewStudentPersonalnfoWindow.xaml
    /// </summary>
    public partial class ViewStudentPersonalnfoWindow : Window
    {
        private Student student;
        private StudentService studentService;
        public ViewStudentPersonalnfoWindow(Student student)
        {
            InitializeComponent();
            this.student = student;
            this.studentService = new StudentService();
            this.DataContext = student;
            comboGender.ItemsSource = Enum.GetValues(typeof(EGender));
            InitializeTextBoxValues();
        }

        private void InitializeTextBoxValues()
        {
            if (student == null)
            {
                return;
            }
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtEmail.Text = student.Email;
            txtStreetAddress.Text = student.Address.Street;
            txtStreetNumber.Text = student.Address.Number.ToString();
            txtCity.Text = student.Address.City;
            txtPassword.Password = student.Password;
            txtCountry.Text = student.Address.Country;
            comboGender.SelectedIndex = (int) student.Gender;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            studentService.UpdateStudent(txtFirstName.Text, txtLastName.Text, student.PersonalIdentityNumber, txtEmail.Text, txtPassword.Password, EUserType.Student, (EGender) Enum.Parse(typeof(EGender), comboGender.SelectedValue.ToString()), txtStreetAddress.Text, int.Parse(txtStreetNumber.Text), txtCity.Text, txtCountry.Text);
            this.Close();
        }
    }
}
 