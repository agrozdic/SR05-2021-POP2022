using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
using SkolaJezika.resources.services;
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

namespace SkolaJezika.resources.views.Languages
{
    /// <summary>
    /// Interaction logic for CreateUpdateLanguageWindow.xaml
    /// </summary>
    public partial class CreateUpdateLanguageWindow : Window
    {
        private EWindowStatus status;
        private Language language;
        private LanguageService service;
        public CreateUpdateLanguageWindow(EWindowStatus status, Language language = null)
        {
            InitializeComponent();
            this.status = status;
            this.language = language;
            service = new LanguageService();
            MakeWindowChangesBasedByStatus();
            InitializeTextBoxValues();
        }

        private void MakeWindowChangesBasedByStatus()
        {
            if (status.Equals(EWindowStatus.CREATE))
            {
                this.Title = "Novi jezik";
                btnSubmit.Content = "Kreiraj";
            }
            else
            {
                this.Title = "Azuriranje jezika";
                btnSubmit.Content = "Azuriraj";
            }
        }

        private void InitializeTextBoxValues()
        {
            if (language == null)
            {
                return;
            }
            txtName.Text = language.LanguageName;
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (status.Equals(EWindowStatus.CREATE))
            {
                CreateNewLanguage();
                this.DialogResult = true;
            }
            else
            {
                UpdateLanguage();
            }
        }

        private void CreateNewLanguage()
        {
            service.CreateLanguage(txtName.Text);
        }

        private void UpdateLanguage()
        {
            service.UpdateLanguage(language.Id, txtName.Text);
        }
    }
}
