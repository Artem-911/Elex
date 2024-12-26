using Elex.Instances;
using Elex.Windows.Categories;
using Elex.Windows.Clients;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Elex.Queries;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Markup;

namespace Elex.Windows.Orders
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        private OrderQueries query = new OrderQueries();
        private CustomerQueries customerQuery = new CustomerQueries();
        private ItemQueries itemQuery = new ItemQueries();
        public Orders()
        {
            InitializeComponent();
            List<Order> orders = query.getAllOrders();
            dataGrid.ItemsSource = orders;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddOrder add = new AddOrder();
            add.Show();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int selectedIdx = dataGrid.SelectedIndex;
            if (selectedIdx >= 0)
            {
                var selectedItem = dataGrid.Items[selectedIdx];
                int id = (selectedItem as Order).Id;
                EditOrder edit = new EditOrder(id);
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
                int id = (selectedItem as Order).Id;
                query.deleteOrder(id);
                dataGrid.ItemsSource = null;
                List<Order> orders = query.getAllOrders();
                dataGrid.ItemsSource = orders;
            }
            else
            {
                MessageBox.Show("Выберите данные для удаления!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow2 main = new MainWindow2();
            main.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("Report.pdf", FileMode.Create));

           
            BaseFont bf = BaseFont.CreateFont("Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font font = new Font(bf, 12, Font.NORMAL);

            document.Open();
    
            document.Add(new Paragraph("Отчет", font));

            PdfPTable table = new PdfPTable(4); 

            table.AddCell(new Paragraph("Товар", font));
            table.AddCell(new Paragraph("Покупатель", font));
            table.AddCell(new Paragraph("Цена", font));
            table.AddCell(new Paragraph("Дата", font));

            List<Order> orders = query.getAllOrders();
            foreach (var order in orders)
            {
                Customer customer = customerQuery.getCustomerById(order.CustomerId);
                Item item = itemQuery.getItemById(order.ItemId);
                string fullName = customer.Lastname + " " + customer.Firstname + " " + customer.Secondname;

                table.AddCell(new Paragraph(item.Name, font));
                table.AddCell(new Paragraph(fullName, font));
                table.AddCell(new Paragraph(order.Price.ToString(), font));
                table.AddCell(new Paragraph(order.OrderDate.ToString(), font));
            }

            document.Add(table);
            document.Close();
        }

    }
}
