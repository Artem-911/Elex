using Elex.Instances;
using Elex.Queries;
using Elex.Windows.Suppliers;
using System;
using System.Collections;
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

namespace Elex.Windows.Categories
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : Window
    {
        private CategoryQueries query = new CategoryQueries();
        public Categories()
        {
            InitializeComponent();
            List<Category> categories = query.getAllCategories();
            dataGrid.ItemsSource = categories;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCategory add = new AddCategory();
            add.Show();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Category).Id;
                EditCategory edit = new EditCategory(id);
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
                int id = (selectedItem as Category).Id;
                query.deleteCategory(id);
                dataGrid.ItemsSource = null;
                List<Category> categories = query.getAllCategories();
                dataGrid.ItemsSource = categories;
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
