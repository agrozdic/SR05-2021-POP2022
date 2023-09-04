using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
using SkolaJezika.resources.services;
using SkolaJezika.resources.views.Languages;
using System;
using System.Collections.Generic;
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

namespace SkolaJezika.resources.views.Schools
{
    /// <summary>
    /// Interaction logic for SchoolsWindow.xaml
    /// </summary>
    public partial class SchoolsWindow : Window
    {
        private SchoolService service;
        private ICollectionView view;
        public SchoolsWindow()
        {
            InitializeComponent();
            service = new SchoolService();
            InitializeData();
        }

        private void InitializeData()
        {
            view = CollectionViewSource.GetDefaultView(service.GetAllSchools());
            dataSchool.ItemsSource = view;
            dataSchool.IsSynchronizedWithCurrentItem = true;

            dataSchool.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateUpdateSchoolWindow cusw = new CreateUpdateSchoolWindow(EWindowStatus.CREATE);
            if(cusw.ShowDialog() == true)
            {
                view.Refresh();
                dataSchool.ItemsSource = service.GetAllSchools();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataSchool.SelectedItems.Count == 0)
            {
                MessageBox.Show("Prvo oznacite polje!");
                return;
            }
            School school = (School) dataSchool.SelectedItem;
            CreateUpdateSchoolWindow culw = new CreateUpdateSchoolWindow(EWindowStatus.UPDATE, school);
            culw.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataSchool.SelectedItems.Count == 0)
            {
                MessageBox.Show("Prvo oznacite polje!");
                return;
            }
            School school = (School)dataSchool.SelectedItem;
            service.Delete(school.Id);
            dataSchool.ItemsSource = service.GetAllSchools();
        }
    }
}
