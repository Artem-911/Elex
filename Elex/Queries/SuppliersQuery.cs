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
    internal class SuppliersQuery: Connect
    {
        public List<Supplier> getAllSuppliers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM suppliers";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Supplier> suppliers = new List<Supplier>();
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier
                            {
                                Id = Convert.ToInt32(reader["supplierId"].ToString()),
                                Name = reader["name"].ToString(),
                                Phone = reader["phone"].ToString(),
                            };

                            suppliers.Add(supplier);
                        }

                        return suppliers;
                    }
                }
            }
        }
        public Supplier getSupplierById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM suppliers WHERE supplierId= @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Supplier supplier = new Supplier
                            {
                                Id = Convert.ToInt32(reader["supplierId"].ToString()),
                                Name = reader["name"].ToString(),
                                Phone = reader["phone"].ToString(),
                            };

                            return supplier;
                        }
                    }
                }
            }
            return new Supplier();
        }

        public Supplier getSupplierByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM suppliers WHERE name = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Supplier supplier = new Supplier
                            {
                                Id = Convert.ToInt32(reader["supplierId"].ToString()),
                                Name = reader["name"].ToString(),
                            };

                            return supplier;
                        }
                    }
                }
            }
            return new Supplier();
        }

        public void updateSupplier(int id, string name, string phone)
        {
            string query = "UPDATE suppliers SET name = @Name, phone=@Phone WHERE supplierId = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Phone", phone);

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

        public void deleteSupplier(int id)
        {
            string query = "DELETE FROM suppliers WHERE supplierId=@id";

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

        public void addSupplier(string name, string phone)
        {
            string query = "INSERT INTO suppliers (name, phone) VALUES (@Name, @Phone)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Phone", phone);

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
