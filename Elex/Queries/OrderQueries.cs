using Elex.Instances;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Elex.Queries
{
    internal class OrderQueries: Connect
    {
        public List<Order> getAllOrders()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM orders";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Order> orders = new List<Order>();
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                Id = Convert.ToInt32(reader["orderId"].ToString()),
                                ItemId = Convert.ToInt32(reader["itemId"]),
                                CustomerId = Convert.ToInt32(reader["customerId"]),
                                Price = Convert.ToInt32(reader["price"]),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                                OrderDate = Convert.ToDateTime(reader["orderDate"]),
                            };

                            orders.Add(order);
                        }

                        return orders;
                    }
                }
            }
        }
        public Order getOrderById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM orders WHERE orderId = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Order order = new Order
                            {
                                Id = Convert.ToInt32(reader["orderId"].ToString()),
                                ItemId = Convert.ToInt32(reader["itemId"]),
                                CustomerId = Convert.ToInt32(reader["customerId"]),
                                Price = Convert.ToInt32(reader["price"]),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                                OrderDate = Convert.ToDateTime(reader["orderDate"]),
                            };

                            return order;
                        }
                    }
                }
            }
            return new Order();
        }

        public void updateOrder(int id, int itemId, int customerId, int price, int quantity, DateTime orderDate, int workerId)
        {
            string query = "UPDATE orders SET itemId = @ItemId, customerId = @CustomerId, price = @Price, quantity = @Quantity, orderDate = @OrderDate, workerId=@WorkerId WHERE orderId = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@ItemId", itemId);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@WorkerId", workerId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@OrderDate", orderDate);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!");
                    Console.Write(ex.ToString());
                }
            }
        }

        public void deleteOrder(int id)
        {
            string query = "DELETE FROM orders WHERE orderId=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }

        public void addOrder(int itemId, int customerId, int price, int quantity, DateTime orderDate, int workerId)
        {
            string query = "INSERT INTO orders (itemId, customerId, price, quantity, orderDate, workerId) VALUES (@ItemId, @CustomerId, @Price, @Quantity, @OrderDate, @WorkerId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemId", itemId);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@WorkerId", workerId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@OrderDate", orderDate);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!");
                    Console.Write(ex.ToString());

                }
            }
        }
    }
}
