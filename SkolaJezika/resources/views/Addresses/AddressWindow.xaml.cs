using SkolaJezika.resources.enums;
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

namespace SkolaJezika.resources.views.Addresses
{
    /// <summary>
    /// Interaction logic for AddressWindow.xaml
    /// </summary>
    public partial class AddressWindow : Window
    {
        private AddressService service = new AddressService();
        private ICollectionView view;
        public AddressWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(service.GetAllAddresses());
            InitializeData();
        }

        private void InitializeData()
        {
            dataAddresses.ItemsSource = view;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateUpdateAddressWindow cuaw = new CreateUpdateAddressWindow(EWindowStatus.CREATE);
            if (cuaw.ShowDialog() == true)
            {
                view.Refresh();
            }
            dataAddresses.ItemsSource = service.GetAllAddresses();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataAddresses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Prvo oznacite polje!");
                return;
            }
            Address address = (Address)dataAddresses.SelectedItem;
            CreateUpdateAddressWindow cuaw = new CreateUpdateAddressWindow(EWindowStatus.UPDATE, address);
            cuaw.ShowDialog();
            dataAddresses.ItemsSource = service.GetAllAddresses();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataAddresses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Prvo oznacite polje!");
                return;
            }
            Address address = (Address)dataAddresses.SelectedItem;
            service.DeleteAddress(address.Id);
            dataAddresses.ItemsSource = service.GetAllAddresses();
        }
    }
}
