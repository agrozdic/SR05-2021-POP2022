using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
using SkolaJezika.resources.services;
using SkolaJezika.resources.views.Addresses;
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

namespace SkolaJezika.resources.views.Languages
{
    /// <summary>
    /// Interaction logic for LanguagesWindow.xaml
    /// </summary>
    public partial class LanguagesWindow : Window
    {
        private LanguageService service = new LanguageService();
        private ICollectionView view;
        public LanguagesWindow()
        {
            InitializeComponent();
            InitializeData();
            view = CollectionViewSource.GetDefaultView(service.GetAllLanguages());
        }

        private void InitializeData()
        {
            view = CollectionViewSource.GetDefaultView(service.GetAllLanguages());
            dataLanguages.ItemsSource = view;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateUpdateLanguageWindow culw = new CreateUpdateLanguageWindow(EWindowStatus.CREATE);
            if (culw.ShowDialog() == true)
            {
                view.Refresh();
                dataLanguages.ItemsSource = service.GetAllLanguages();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataLanguages.SelectedItems.Count == 0)
            {
                MessageBox.Show("Prvo oznacite polje!");
                return;
            }
            Language language = (Language)dataLanguages.SelectedItem; 
            CreateUpdateLanguageWindow culw = new CreateUpdateLanguageWindow(EWindowStatus.UPDATE, language);
            culw.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataLanguages.SelectedItems.Count == 0)
            {
                MessageBox.Show("Prvo oznacite polje!");
                return;
            }
            Language language = (Language)dataLanguages.SelectedItem;
            service.DeleteLanguage(language.Id);
            dataLanguages.ItemsSource = service.GetAllLanguages();
        }
    }
}
