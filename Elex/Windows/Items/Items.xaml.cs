using Elex.Instances;
using Elex.Windows.Categories;
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
using Elex.Queries;

namespace Elex.Windows.Items
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : Window
    {
        private ItemQueries query = new ItemQueries();
        public Items()
        {
            InitializeComponent();
            List<Item> items = query.getAllItems();
            dataGrid.ItemsSource = items;
         
            dataGrid.Loaded += DataGrid_Loaded;

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // Получаем ссылку на DataGrid
            DataGrid dataGrid = sender as DataGrid;

            // Устанавливаем ширину второго столбца
            if (dataGrid != null && dataGrid.Columns.Count > 1)
            {
                dataGrid.Columns[2].Width = 200; 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddItem add = new AddItem();
            add.Show();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Item).Id;
                EditItem edit = new EditItem(id);
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
                int id = (selectedItem as Item).Id;
                query.deleteItem(id);
                dataGrid.ItemsSource = null;
                List<Item> items = query.getAllItems();
                dataGrid.ItemsSource = items;
                if (dataGrid != null && dataGrid.Columns.Count > 1)
                {
                    dataGrid.Columns[2].Width = 200;
                }
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
