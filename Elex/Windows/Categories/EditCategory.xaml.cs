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

namespace Elex.Windows.Categories
{
    /// <summary>
    /// Interaction logic for EditCategory.xaml
    /// </summary>
    public partial class EditCategory : Window
    {
        private int id;
        private CategoryQueries query = new CategoryQueries();
        public EditCategory(int id)
        {
            this.id = id;
            InitializeComponent();
            Category category = query.getCategoryById(id);
            nameBox.Text = category.Name;
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

        private void showError(string message)
        {
            errorBox.Visibility = Visibility.Visible;
            errorBox.Text = message;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text.Trim();
            if(name == "")
            {
                showError("Заполните поле");
                return;
            }
            try
            {
                query.updateCategory(id, name);
                
            }catch(Exception ex)
            {
                showError("Ошибка при сохранении!");
                return;
            }
            back();
        }
    }
}
