using SkolaJezika.resources.managers;
using SkolaJezika.resources.models;
using SkolaJezika.resources.services;
using SkolaJezika.resources.views.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        private SchoolService schoolService;
        private LanguageService languageService;
        private AddressService addressService;
        public GuestWindow()
        {
            InitializeComponent();
            this.schoolService = new SchoolService();
            this.languageService = new LanguageService();
            this.addressService = new AddressService();
            InitializeData();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void InitializeData()
        {
            dataSchools.ItemsSource = null;
            dataSchools.ItemsSource = schoolService.GetAllSchools();
            cmbPlace.ItemsSource = addressService.GetAllCities();
            listLanguages.ItemsSource = languageService.GetAllLanguages();
        }

        private void btnSearchTeacher_Click(object sender, RoutedEventArgs e)
        {
            var selectedSchool = dataSchools.SelectedItem;
            if (selectedSchool == null)
            {
                MessageBox.Show("Prvo oznacite polje!");
                return;
            }

            School clickedSchool = (School)selectedSchool;
            SearchTeachersWindow stw = new SearchTeachersWindow(clickedSchool.Id);
            stw.Show();
        }

        private void btnGetBack_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            this.Hide();
        }

        private void cmbPlace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string searchedName = cmbPlace.SelectedItem.ToString();
            dataSchools.ItemsSource = schoolService.GetSchoolByCityName(searchedName);
        }

        private void listLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Language> selectedItems = listLanguages.SelectedItems.Cast<Language>().ToList<Language>();
            if (cmbPlace.SelectedIndex != -1)
            {
                dataSchools.ItemsSource = schoolService.GetSchoolsByLanguagesAndCity(selectedItems, cmbPlace.SelectedItem.ToString());
            }
            else
            {
                dataSchools.ItemsSource = schoolService.GetSchoolsByLanguages(selectedItems); 
            }
        }

        private void btnSearchForTeacher_Click(object sender, RoutedEventArgs e)
        {
            SearchTeacherWindow stw = new SearchTeacherWindow();
            stw.Show();
        }
    }
}
