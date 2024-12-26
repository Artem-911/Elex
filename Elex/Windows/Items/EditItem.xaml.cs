using Elex.Instances;
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

namespace Elex.Windows.Items
{
    /// <summary>
    /// Interaction logic for EditItem.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        private int id;
        private CategoryQueries categoryQuery = new CategoryQueries();
        private SuppliersQuery suppliersQuery = new SuppliersQuery();
        private ItemQueries itemQueries = new ItemQueries();
        public EditItem(int id)
        {
            this.id = id;
            InitializeComponent();
            Item oldItem = itemQueries.getItemById(id);
            List<Category> categories = categoryQuery.getAllCategories();
            List<Supplier> suppliers = suppliersQuery.getAllSuppliers();
            
            for (int i = 0; i < categories.Count; i++)
            {
                categoryCombo.Items.Add(categories[i].Name);
                if (categories[i].Id == oldItem.Id)
                {
                    categoryCombo.SelectedIndex = i;
                }
            }
         

            for (int i = 0; i < suppliers.Count; i++)
            {
                supplierCombo.Items.Add(suppliers[i].Name);
                if (suppliers[i].Id == oldItem.SupplierId)
                {
                    supplierCombo.SelectedIndex = i;
                }
            }

            nameBox.Text = oldItem.Name;
            descriptionBox.Text = oldItem.Description;
            priceBox.Text = oldItem.Price.ToString();
            quantityBox.Text = oldItem.Quantity.ToString();   
        }

        private void back()
        {
            Items items = new Items();
            items.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            back();
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

            if (name == "" || description == "" || price == "" || quantity == "")
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
                itemQueries.updateItem(id, name, description, supplierId, categoryId, Convert.ToInt32(price), Convert.ToInt32(quantity));
            }
            catch (Exception ex)
            {
                showError("Ошибка при сохранении!");
                return;
            }
        }
    }
}
