using SkolaJezika.resources.managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace SkolaJezika.utilities.fill_data_grid
{
    class FillDataGrid
    {

        public static void SetAttributesForDataGrid(DataGrid info, ICollectionView view)
        {
            info.ItemsSource = view;
            info.IsSynchronizedWithCurrentItem = true;
            info.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        public static void FillDataGridAddresses(DataGrid dataAddress)
        {
            ICollectionView viewAddresses = CollectionViewSource.GetDefaultView(AddressManager.GetInstance().AllAddresses);
            SetAttributesForDataGrid(dataAddress, viewAddresses);
        }

        public static void FillDataGridLanguages(DataGrid dataGrid)
        {
            ICollectionView viewLanguages = CollectionViewSource.GetDefaultView(LanguageManager.GetInstance().AllLanguages);
            SetAttributesForDataGrid(dataGrid, viewLanguages);
        }

        public static void FillDataGridSchool(DataGrid dataGrid)
        {
            ICollectionView viewSchools = CollectionViewSource.GetDefaultView(SchoolManager.GetInstance().AllSchools);
            SetAttributesForDataGrid(dataGrid, viewSchools);
        }
    }
}
