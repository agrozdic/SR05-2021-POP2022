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

namespace SkolaJezika.resources.views.Teachers
{
    /// <summary>
    /// Interaction logic for CreateUpdateTeacher.xaml
    /// </summary>
    public partial class CreateUpdateTeacher : Window
    {
        private EWindowStatus status;
        private Teacher teacher;
        private TeacherService service;
        private LanguageService languageService;
        private SchoolService schoolService;
        public CreateUpdateTeacher(EWindowStatus status, Teacher teacher = null)
        {
            InitializeComponent();
            this.status = status;
            this.teacher = teacher;
            this.service = new TeacherService();
            this.languageService = new LanguageService();
            this.schoolService = new SchoolService();
            comboGender.ItemsSource = Enum.GetNames(typeof(EGender));
            cmbSchool.ItemsSource = schoolService.GetAllSchools();
            MakeWindowChangesBasedByStatus();
            InitializeListBoxValues();
            InitializeTextBoxValues();
        }
        private void MakeWindowChangesBasedByStatus()
        {
            if (status.Equals(EWindowStatus.CREATE))
            {
                this.Title = "Novi nastavnik";
                btnSubmit.Content = "Create";
            }
            else
            {
                this.Title = "Azuriranje nastavnika";
                btnSubmit.Content = "Update";
                txtPersonalIdentityNumber.IsEnabled = false;
                this.DataContext = teacher;
                comboGender.SelectedIndex = (int)teacher.Gender;
            }
        }

        private void InitializeListBoxValues()
        {
            listLanguages.ItemsSource = languageService.GetAllLanguages();
            listLanguages.SelectionMode = SelectionMode.Extended;
            if (teacher == null)
            {
                return;
            }

            var foundedMatchingLanguages = languageService.GetAllLanguages().Where(language => teacher.TeachingLanguages.Contains(language));
            foreach (Language lang in foundedMatchingLanguages)
            {
                listLanguages.SelectedItems.Add(lang);
            }
        }

        private void InitializeTextBoxValues()
        {
            if (teacher == null)
            {
                return;
            }
            txtFirstName.Text = teacher.FirstName;
            txtLastName.Text = teacher.LastName;
            txtPersonalIdentityNumber.Text = teacher.PersonalIdentityNumber;
            txtEmail.Text = teacher.Email;
            txtPassword.Password = teacher.Password;
            txtStreetAddress.Text = teacher.Address.Street;
            txtStreetNumber.Text = teacher.Address.Number.ToString();
            txtCity.Text = teacher.Address.City;
            txtCountry.Text = teacher.Address.Country;
            comboGender.SelectedItem = teacher.Gender;
            cmbSchool.SelectedItem = teacher.WorkingSchool;
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (status.Equals(EWindowStatus.CREATE))
            {
                CreateNewTeacher();
                this.DialogResult = true;
            }
            else
            {
                UpdateTeacher();
            }
        }

        private void CreateNewTeacher()
        {
            if (CheckForPersonalIdentityDuplicates.CheckForDuplicates(txtPersonalIdentityNumber.Text))
            {
                MessageBox.Show($"Personal identity already exists, use your own!");
                return;
            }
            List<Language> languages = listLanguages.SelectedItems.Cast<Language>().ToList();
            service.CreateTeacher(txtFirstName.Text, txtLastName.Text, txtPersonalIdentityNumber.Text, txtEmail.Text, txtPassword.Password, EUserType.Teacher, (EGender)Enum.Parse(typeof(EGender), comboGender.Text), txtStreetAddress.Text, int.Parse(txtStreetNumber.Text), txtCity.Text, txtCountry.Text, true, cmbSchool.Text, languages);
        }

        private void UpdateTeacher()
        {
            List<Language> languages = listLanguages.SelectedItems.Cast<Language>().ToList();
            service.UpdateTeacher(txtFirstName.Text, txtLastName.Text, txtPersonalIdentityNumber.Text, txtEmail.Text, txtPassword.Password, EUserType.Teacher, (EGender)Enum.Parse(typeof(EGender), comboGender.Text), txtStreetAddress.Text, int.Parse(txtStreetNumber.Text), txtCity.Text, txtCountry.Text, true, cmbSchool.Text, languages);
        }
    }
}
    