using SkolaJezika.resources.models;
using SkolaJezika.resources.services;
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

namespace SkolaJezika.resources.views.Sessions
{
    /// <summary>
    /// Interaction logic for SessionsWindow.xaml
    /// </summary>
    public partial class SessionsWindow : Window
    {
        private SessionService service;
        private ICollectionView view;
        public SessionsWindow()
        {
            InitializeComponent();
            service = new SessionService();
            view = CollectionViewSource.GetDefaultView(service.GetAllSessions());
            dataSessions.ItemsSource = view;
            dataSessions.IsSynchronizedWithCurrentItem = true;
            dataSessions.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateUpdateSession cus = new CreateUpdateSession(enums.EWindowStatus.CREATE);
            if (cus.ShowDialog() == true)
            {
                view.Refresh();
                dataSessions.ItemsSource = service.GetAllSessions();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(dataSessions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Prvo oznacite polje!");
                return;
            }
            CreateUpdateSession cus = new CreateUpdateSession(enums.EWindowStatus.UPDATE, (Session) dataSessions.SelectedItem);
            cus.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataSessions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Prvo oznacite polje!");
                return;
            }
            Session session = (Session)dataSessions.SelectedItem;
            service.Delete(session.Id);
            dataSessions.ItemsSource = service.GetAllSessions();
        }
    }
}
