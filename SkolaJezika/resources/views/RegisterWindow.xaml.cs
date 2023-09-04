using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
using SkolaJezika.resources.services;
using SkolaJezika.utilities;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private StudentService studentService;
        public RegisterWindow()
        {
            InitializeComponent();
            studentService = new StudentService();
            this.DataContext = new Student();
        }

        private bool IsValid()
        {
            return !Validation.GetHasError(txtEmail) && !Validation.GetHasError(txtPersonalIdentityNumber);
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (CheckForPersonalIdentityDuplicates.CheckForDuplicates(txtPersonalIdentityNumber.Text))
            {
                MessageBox.Show($"JMBG vec postoji!");
                return;
            }
            if (IsValid())
            {
                studentService.CreateStudent(txtFirstName.Text, txtLastName.Text, txtPersonalIdentityNumber.Text, txtEmail.Text, txtPassword.Password, EUserType.Student, (EGender)Enum.Parse(typeof(EGender), comboGender.Text), txtStreetAddress.Text, int.Parse(txtStreetNumber.Text), txtCity.Text, txtCountry.Text);
                MessageBox.Show("Uspesna registracija");
                LoginWindow lw = new LoginWindow();
                lw.Show();
                this.Close();
                return;
            }
            MessageBox.Show("Greska.");
        }
    }
}
