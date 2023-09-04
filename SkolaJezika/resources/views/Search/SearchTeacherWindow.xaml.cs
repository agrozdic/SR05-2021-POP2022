using SkolaJezika.resources.models;
using SkolaJezika.resources.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for SearchTeacherWindow.xaml
    /// </summary>
    public partial class SearchTeacherWindow : Window
    {
        private SearchTeacherService searchTeacherService;
        private LanguageService languageService;
        public SearchTeacherWindow()
        {
            InitializeComponent();
            searchTeacherService = new SearchTeacherService();
            languageService = new LanguageService();
            listBoxLanguages.ItemsSource = languageService.GetAllLanguages();
            dataUsers.ItemsSource = searchTeacherService.SearchTeachers();
        }

        private void SendExistingDataRequest()
        {
            bool isTxtFirstNameExisting = txtFirstName.Text != "";
            bool isTxtLastNameExisting = txtLastName.Text != "";
            bool isMailExisting = txtMail.Text != "";
            bool isListBoxItemSelected = listBoxLanguages.SelectedItems.Count != 0;
            bool isAddressExisting = txtAddress.Text != "";
            bool isCityExisting = txtCity.Text != "";
            ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();

            if (isTxtFirstNameExisting) teachers = searchTeacherService.SearchTeachersByFirstName(txtFirstName.Text);
            if (isTxtLastNameExisting) teachers = searchTeacherService.SearchTeachersByLastName(txtLastName.Text);
            if (isMailExisting) teachers = searchTeacherService.SearchTeachersByMail(txtMail.Text);
            if (isListBoxItemSelected) teachers = searchTeacherService.SearchTeachersByLanguages(FormatListOfSelectedLanguages());
            if (isAddressExisting) teachers = searchTeacherService.SearchTeachersByStreetName(txtAddress.Text);
            if (isCityExisting) teachers = searchTeacherService.SearchTeachersByCity(txtCity.Text);
            dataUsers.ItemsSource = teachers;
        }

        private List<Language> FormatListOfSelectedLanguages()
        {
            if  (listBoxLanguages.SelectedItems.Count == 0) return null;
            return listBoxLanguages.SelectedItems.Cast<Language>().ToList();
        }

        private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtFirstName.Text == "" && txtLastName.Text == "" && txtAddress.Text == "" && txtCity.Text == "" && txtMail.Text == "" && listBoxLanguages.SelectedItems.Count == 0)
            {
                dataUsers.ItemsSource = searchTeacherService.SearchTeachers();
                return;
            }

            if (txtFirstName.Text == "")
            {
                SendExistingDataRequest();
                return;
            }

            dataUsers.ItemsSource = searchTeacherService.SearchTeachersByFirstName(txtFirstName.Text);
        }

        private void txtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtFirstName.Text == "" && txtLastName.Text == "" && txtAddress.Text == "" && txtCity.Text == "" && txtMail.Text == "" && listBoxLanguages.SelectedItems.Count == 0)
            {
                dataUsers.ItemsSource = searchTeacherService.SearchTeachers();
                return;
            }

            if (txtLastName.Text == "")
            {
                SendExistingDataRequest();
                return;
            }

            dataUsers.ItemsSource = searchTeacherService.SearchTeachersByLastName(txtLastName.Text);
        }

        private void txtMail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtFirstName.Text == "" && txtLastName.Text == "" && txtAddress.Text == "" && txtCity.Text == "" && txtMail.Text == "" && listBoxLanguages.SelectedItems.Count == 0)
            {
                dataUsers.ItemsSource = searchTeacherService.SearchTeachers();
                return;
            }

            if (txtMail.Text == "")
            {
                SendExistingDataRequest();
                return;
            }

            dataUsers.ItemsSource = searchTeacherService.SearchTeachersByMail(txtMail.Text);
        }

        private void listBoxLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Language> languages = listBoxLanguages.SelectedItems.Cast<Language>().ToList();
            dataUsers.ItemsSource = searchTeacherService.SearchTeachersByLanguages(languages);
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtFirstName.Text == "" && txtLastName.Text == "" && txtAddress.Text == "" && txtCity.Text == "" && txtMail.Text == "" && listBoxLanguages.SelectedItems.Count == 0)
            {
                dataUsers.ItemsSource = searchTeacherService.SearchTeachers();
                return;
            }

            if (txtAddress.Text == "")
            {
                SendExistingDataRequest();
                return;
            }

            dataUsers.ItemsSource = searchTeacherService.SearchTeachersByStreetName(txtAddress.Text);
        }

        private void txtCity_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txtFirstName.Text == "" && txtLastName.Text == "" && txtAddress.Text == "" && txtCity.Text == "" && txtMail.Text == "" && listBoxLanguages.SelectedItems.Count == 0)
            {
                dataUsers.ItemsSource = searchTeacherService.SearchTeachers();
                return;
            }

            if (txtCity.Text == "")
            {
                SendExistingDataRequest();
                return;
            }

            dataUsers.ItemsSource = searchTeacherService.SearchTeachersByCity(txtCity.Text);
        }

    }
}
