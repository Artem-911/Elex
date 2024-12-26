using Elex.Instances;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Elex.Queries
{
    internal class ItemQueries: Connect
    {
        // Items
        public List<Item> getAllItems()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM items";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Item> items = new List<Item>();
                        while (reader.Read())
                        {
                            Item item = new Item
                            {
                                Id = Convert.ToInt32(reader["itemId"].ToString()),
                                Name = reader["name"].ToString(),
                                Description = reader["description"].ToString(),
                                SupplierId = Convert.ToInt32(reader["supplierId"]),
                                CategoryId = Convert.ToInt32(reader["categoryId"]),
                                Price = Convert.ToInt32(reader["price"]),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                            };

                            items.Add(item);
                        }

                        return items;
                    }
                }
            }
        }
        public Item getItemById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM items WHERE itemId= @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Item item = new Item
                            {
                                Id = Convert.ToInt32(reader["itemId"].ToString()),
                                Name = reader["name"].ToString(),
                                Description = reader["description"].ToString(),
                                SupplierId = Convert.ToInt32(reader["supplierId"]),
                                CategoryId = Convert.ToInt32(reader["categoryId"]),
                                Price = Convert.ToInt32(reader["price"]),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                            };

                            return item;
                        }
                    }
                }
            }
            return new Item();
        }

        public Item getItemByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM items WHERE name = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Item item = new Item
                            {
                                Id = Convert.ToInt32(reader["itemId"].ToString()),
                                Name = reader["name"].ToString(),
                                Description = reader["description"].ToString(),
                                SupplierId = Convert.ToInt32(reader["supplierId"]),
                                CategoryId = Convert.ToInt32(reader["categoryId"]),
                                Price = Convert.ToInt32(reader["price"]),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                            };

                            return item;
                        }
                    }
                }
            }
            return new Item();
        }

        public void updateItem(int id, string name, string description, int supplierId, int categoryId, int price, int quantity)
        {
            string query = "UPDATE items SET name = @Name, description=@Description, supplierId = @SupplierId, categoryId = @CategoryId, price=@Price, quantity=@Quantity WHERE itemId= @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@SupplierId", supplierId);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Quantity", quantity);

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

        public void deleteItem(int id)
        {
            string query = "DELETE FROM items WHERE itemId=@id";

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

        public void addItem(string name, string description, int categoryId, int supplierId, int price, int quantity)
        {
            string query = "INSERT INTO items (name, description, categoryId, supplierId, price, quantity) VALUES (@Name, @Description, @CategoryId, @SupplierId, @Price, @Quantity)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@SupplierId", supplierId);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Quantity", quantity);

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
    }
}
