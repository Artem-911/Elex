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
    internal class CategoryQueries: Connect
    {
        // Categories
        public List<Category> getAllCategories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM categories";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Category> categories = new List<Category>();
                        while (reader.Read())
                        {
                            Category category = new Category
                            {
                                Id = Convert.ToInt32(reader["categoryId"].ToString()),
                                Name = reader["name"].ToString(),
                            };

                            categories.Add(category);
                        }

                        return categories;
                    }
                }
            }
        }
        public Category getCategoryById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM categories WHERE categoryId = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Category category = new Category
                            {
                                Id = Convert.ToInt32(reader["categoryId"].ToString()),
                                Name = reader["name"].ToString(),
                            };

                            return category;
                        }
                    }
                }
            }
            return new Category();
        }

        public Category getCategoryByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM categories WHERE name = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Category category = new Category
                            {
                                Id = Convert.ToInt32(reader["categoryId"].ToString()),
                                Name = reader["name"].ToString(),
                            };

                            return category;
                        }
                    }
                }
            }
            return new Category();
        }


        public void updateCategory(int id, string name)
        {
            string query = "UPDATE categories SET name = @Name WHERE categoryId = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);

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

        public void deleteCategory(int id)
        {
            string query = "DELETE FROM categories WHERE categoryId=@id";

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

        public void addCategory(string name)
        {
            string query = "INSERT INTO categories (name) VALUES (@Name)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);

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
