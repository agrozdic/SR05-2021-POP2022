using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
using SkolaJezika.resources.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SkolaJezika.resources.views.Search
{
    /// <summary>
    /// Interaction logic for SearchRegisteredUser.xaml
    /// </summary>
    public partial class SearchRegisteredUser : Window
    {
        private SearchUserService searchUserService;
        public SearchRegisteredUser()
        {
            InitializeComponent();
            searchUserService = new SearchUserService();
            cmbType.ItemsSource = Enum.GetNames(typeof(EUserType));
            cmbType.SelectedIndex = 0;
            dataUsers.ItemsSource = searchUserService.SearchStudents();
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(cmbType.SelectedIndex)
            {
                case 0:
                    dataUsers.ItemsSource = searchUserService.SearchStudents();
                    break;
                case 1:
                    dataUsers.ItemsSource = searchUserService.SearchTeachers();
                    break;
                default:
                    MessageBox.Show("Studenti!");
                    cmbType.SelectedIndex = 0;
                    dataUsers.ItemsSource = searchUserService.SearchStudents();
                    break;
            }
        }

        private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbType.SelectedIndex == 1 && txtFirstName.Text == "" && txtLastName.Text == "" && txtMail.Text == "")
            {
                dataUsers.ItemsSource = searchUserService.SearchTeachers();
                return;
            }

            if (cmbType.SelectedIndex == 0 && txtFirstName.Text == "" && txtLastName.Text == "" && txtMail.Text == "")
            {
                dataUsers.ItemsSource = searchUserService.SearchStudents();
                return;
            }

            if(txtFirstName.Text == "")
            {
                SendExistingDataRequest();
                return;
            }

            if (cmbType.SelectedIndex == 1)
            {
                dataUsers.ItemsSource = searchUserService.SearchTeachersByFirstName(txtFirstName.Text);
                return;
            }
            dataUsers.ItemsSource = searchUserService.SearchStudentsByFirstName(txtFirstName.Text);
            return;
        }

        private void txtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbType.SelectedIndex == 1 && txtFirstName.Text == "" && txtLastName.Text == "" && txtMail.Text == "")
            {
                dataUsers.ItemsSource = searchUserService.SearchTeachers();
                return;
            }

            if (cmbType.SelectedIndex == 0 && txtFirstName.Text == "" && txtLastName.Text == "" && txtMail.Text == "")
            {
                dataUsers.ItemsSource = searchUserService.SearchStudents();
                return;
            }

            if (txtLastName.Text == "")
            {
                SendExistingDataRequest();
                return;
            }

            if (cmbType.SelectedIndex == 1)
            {
                dataUsers.ItemsSource = searchUserService.SearchTeachersByLastName(txtLastName.Text);
                return;
            }
            dataUsers.ItemsSource = searchUserService.SearchStudentsByLastName(txtLastName.Text);
            return;
        }

        private void txtMail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbType.SelectedIndex == 1 && txtFirstName.Text == "" && txtLastName.Text == "" && txtMail.Text == "")
            {
                dataUsers.ItemsSource = searchUserService.SearchTeachers();
                return;
            }

            if (cmbType.SelectedIndex == 0 && txtFirstName.Text == "" && txtLastName.Text == "" && txtMail.Text == "")
            {
                dataUsers.ItemsSource = searchUserService.SearchStudents();
                return;
            }

            if (txtMail.Text == "")
            {
                SendExistingDataRequest();
                return;
            }

            if (cmbType.SelectedIndex == 1)
            {
                dataUsers.ItemsSource = searchUserService.SearchTeachersByMail(txtMail.Text);
                return;
            }
            dataUsers.ItemsSource = searchUserService.SearchStudentsByMail(txtMail.Text);
            return;
        }

        private void SendExistingDataRequest()
        {
            bool isTxtFirstNameExisting = txtFirstName.Text != "";
            bool isTxtLastNameExisting = txtLastName.Text != "" ;
            bool isMailExisting = txtMail.Text != "" ;
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();
            if (isTxtFirstNameExisting && cmbType.SelectedIndex == 1) teachers = searchUserService.SearchTeachersByFirstName(txtFirstName.Text);
            if (isTxtLastNameExisting && cmbType.SelectedIndex == 1) teachers = searchUserService.SearchTeachersByLastName(txtLastName.Text);
            if (isMailExisting && cmbType.SelectedIndex == 1 ) teachers = searchUserService.SearchTeachersByMail(txtMail.Text);

            if (isTxtFirstNameExisting && cmbType.SelectedIndex == 0) students = searchUserService.SearchStudentsByFirstName(txtFirstName.Text);
            if (isTxtLastNameExisting && cmbType.SelectedIndex == 0) students = searchUserService.SearchStudentsByLastName(txtLastName.Text);
            if (isMailExisting && cmbType.SelectedIndex == 0) students = searchUserService.SearchStudentsByMail(txtMail.Text);

            if (cmbType.SelectedIndex == 0) dataUsers.ItemsSource = students;
            else dataUsers.ItemsSource = teachers;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
