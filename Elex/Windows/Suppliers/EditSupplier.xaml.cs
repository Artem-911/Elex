using Elex.Queries;
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

namespace Elex.Windows.Suppliers
{
    /// <summary>
    /// Interaction logic for EditSupplier.xaml
    /// </summary>
    public partial class EditSupplier : Window
    {
        private int id;
        private SuppliersQuery query = new SuppliersQuery();
        public EditSupplier(int id)
        {
            this.id = id;
            InitializeComponent();
            Supplier old = query.getSupplierById(id);
            nameBox.Text = old.Name;
            phoneBox.Text = old.Phone;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            suppliers.Show();
            this.Close();
        }
        public void showError(string message)
        {
            errorBox.Text = message;
            errorBox.Visibility = Visibility.Visible;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string supplierName = nameBox.Text.Trim();
            string supplierPhone = phoneBox.Text.Trim();
            if(supplierName == "" || supplierPhone == "")
            {
                showError("Заполните поля!");
                return;
            }
            try
            {
                query.updateSupplier(id, supplierName, supplierPhone);
            }catch(Exception ex)
            {
                showError("Ошибка при сохранении!");
                return;
            }

            Suppliers suppliers = new Suppliers();
            suppliers.Show();
            this.Close();

        }
    }
}
