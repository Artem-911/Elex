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

namespace Elex.Windows.Items
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {

        private CategoryQueries categoryQuery = new CategoryQueries();
        private SuppliersQuery suppliersQuery = new SuppliersQuery();
        private ItemQueries itemQueries = new ItemQueries();
        public AddItem()
        {
            InitializeComponent();
            List<Category> categories = categoryQuery.getAllCategories();
            List<Supplier> suppliers = suppliersQuery.getAllSuppliers();
            foreach(var category in categories)
            {
                categoryCombo.Items.Add(category.Name);
            }
            categoryCombo.SelectedIndex = 0;

            foreach(var supplier in suppliers)
            {
                supplierCombo.Items.Add(supplier.Name);
            }
            supplierCombo.SelectedIndex = 0;
            quantityBox.Text = "1";
        }

        private void showError(string message)
        {
            errorBox.Visibility = Visibility.Visible;
            errorBox.Text = message;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text.Trim();
            string description = descriptionBox.Text.Trim();
            string price = priceBox.Text.Trim();
            string quantity = quantityBox.Text.Trim();
            string categoryName = categoryCombo.SelectedValue.ToString();
            string supplierName = supplierCombo.SelectedValue.ToString();

            if(name == "" || description == "" || price == "" || quantity == "")
            {
                showError("Заполните поля!");
                return;
            }

            try
            {
                if (Convert.ToInt32(quantity) <= 0)
                {
                    showError("Неверный формат поля Количество!");
                    return;
                }
                int categoryId = categoryQuery.getCategoryByName(categoryName).Id;
                int supplierId = suppliersQuery.getSupplierByName(supplierName).Id;
                itemQueries.addItem(name, description, categoryId, supplierId, Convert.ToInt32(price), Convert.ToInt32(quantity));
            }
            catch (Exception ex)
            {
                showError("Ошибка при сохранении!");
                return;
            }

            back();

        }

        private void back()
        {
            Items items = new Items();
            items.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Items items = new Items();
            items.Show();
            this.Close();
        }
    }
}
