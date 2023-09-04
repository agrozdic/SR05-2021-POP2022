using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
using SkolaJezika.resources.services;
using SkolaJezika.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for CreateUpdateStudent.xaml
    /// </summary>
    public partial class CreateUpdateStudentWindow : Window
    {
        private EWindowStatus status;
        private Student student;
        private StudentService service;
        public CreateUpdateStudentWindow(EWindowStatus status, Student student = null)
        {
            InitializeComponent();
            this.status = status;
            this.student = student;
            service = new StudentService();
            comboGender.ItemsSource = Enum.GetNames(typeof(EGender));
            MakeWindowChangesBasedByStatus();
            InitializeTextBoxValues();
        }

        private void MakeWindowChangesBasedByStatus()
        {
            if (status.Equals(EWindowStatus.CREATE))
            {
                this.Title = "Novi student";
                btnSubmit.Content = "Kreiraj";
            }
            else
            {
                this.Title = "Azuriranje studenta";
                btnSubmit.Content = "Azuriraj";
                txtPersonalIdentityNumber.IsEnabled = false;
                this.DataContext = student;
                comboGender.SelectedIndex = (int)student.Gender;
             }
        }


        private void InitializeTextBoxValues()
        {
            if (student == null)
            {
                return;
            }
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtPersonalIdentityNumber.Text = student.PersonalIdentityNumber;
            txtEmail.Text = student.Email;
            txtPassword.Password = student.Password;
            txtStreetAddress.Text = student.Address.Street;
            txtStreetNumber.Text = student.Address.Number.ToString();
            txtCity.Text = student.Address.City;
            txtCountry.Text = student.Address.Country;
            comboGender.SelectedItem = student.Gender;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (status.Equals(EWindowStatus.CREATE))
            {
                CreateNewStudent();
                this.DialogResult = true;
            }
            else
            {
                UpdateStudent();
            }
        }

        private void CreateNewStudent()
        {

            if (CheckForPersonalIdentityDuplicates.CheckForDuplicates(txtPersonalIdentityNumber.Text))
            {
                MessageBox.Show($"Personal identity already exists, use your own!");
                return;
            }

            service.CreateStudent(txtFirstName.Text, txtLastName.Text, txtPersonalIdentityNumber.Text, txtEmail.Text, txtPassword.Password, EUserType.Student, (EGender)Enum.Parse(typeof(EGender), comboGender.Text), txtStreetAddress.Text, int.Parse(txtStreetNumber.Text), txtCity.Text, txtCountry.Text);
        }

        private void UpdateStudent()
        {
            service.UpdateStudent(txtFirstName.Text, txtLastName.Text, txtPersonalIdentityNumber.Text, txtEmail.Text, txtPassword.Password, EUserType.Student, (EGender)Enum.Parse(typeof(EGender), comboGender.Text), txtStreetAddress.Text, int.Parse(txtStreetNumber.Text), txtCity.Text, txtCountry.Text);
        }
    }
}
