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

namespace Elex.Windows.Categories
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        private CategoryQueries query = new CategoryQueries();
        public AddCategory()
        {
            InitializeComponent();
            
        }

        public void showError(string message)
        {
            errorBox.Text = message;
            errorBox.Visibility = Visibility.Visible;
        }

        private void back()
        {
            Categories categories = new Categories();
            categories.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            back();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text.Trim();
            if(name == "")
            {
                showError("Заполните поле!");
                return;
            }
            try
            {
                query.addCategory(name);
            }
            catch (Exception ex) {
                showError("Ошибка при сохранении!");
                return;
            }

            back();
        }
    }
}
