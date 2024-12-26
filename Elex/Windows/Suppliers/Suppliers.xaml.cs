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
using Elex.Instances;
using Elex.Queries;

namespace Elex.Windows.Suppliers
{
    /// <summary>
    /// Interaction logic for Suppliers.xaml
    /// </summary>
    public partial class Suppliers : Window
    {
        private SuppliersQuery query = new SuppliersQuery();
        public Suppliers()
        {
            InitializeComponent();

            
            List<Supplier> supliers = query.getAllSuppliers();
            dataGrid.ItemsSource = supliers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddSupplier add = new AddSupplier();
            add.Show();
            this.Close();
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Supplier).Id;
                EditSupplier edit = new EditSupplier(id);
                edit.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите данные для редактирования!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Supplier).Id;
                query.deleteSupplier(id);
                dataGrid.ItemsSource = null;
                List<Supplier> supliers = query.getAllSuppliers();
                dataGrid.ItemsSource = supliers;
            }
            else
            {
                MessageBox.Show("Выберите данные для удаления!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
