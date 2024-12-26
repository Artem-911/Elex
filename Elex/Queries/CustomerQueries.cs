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
    internal class CustomerQueries: Connect
    {
        // Customers
        public List<Customer> getAllCustomers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM customers";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Customer> customers = new List<Customer>();
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                Id = Convert.ToInt32(reader["customerId"].ToString()),
                                Firstname = reader["firstname"].ToString(),
                                Lastname = reader["lastname"].ToString(),
                                Secondname = reader["secondname"].ToString(),
                                Phone = reader["phone"].ToString(),
                                RegistrationDate = Convert.ToDateTime(reader["registrationDate"]),
                            };

                            customers.Add(customer);
                        }

                        return customers;
                    }
                }
            }
        }
        public Customer getCustomerById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM customers WHERE customerId = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                Id = Convert.ToInt32(reader["customerId"].ToString()),
                                Firstname = reader["firstname"].ToString(),
                                Lastname = reader["lastname"].ToString(),
                                Secondname = reader["secondname"].ToString(),
                                Phone = reader["phone"].ToString(),
                                RegistrationDate = Convert.ToDateTime(reader["registrationDate"]),
                            };

                            return customer;
                        }
                    }
                }
            }
            return new Customer();
        }

        public Customer getCustomerByName(string firstname, string lastname)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM customers WHERE firstname = @firstname AND lastname = @Lastname";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Firstname", firstname);
                    command.Parameters.AddWithValue("@Lastname", lastname);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                Id = Convert.ToInt32(reader["customerId"].ToString()),
                                Firstname = reader["firstname"].ToString(),
                                Lastname = reader["lastname"].ToString(),
                                Secondname = reader["secondname"].ToString(),
                                Phone = reader["phone"].ToString(),
                                RegistrationDate = Convert.ToDateTime(reader["registrationDate"]),
                            };

                            return customer;
                        }
                    }
                }
            }
            return new Customer();
        }

        public void updateCustomer(int id, string firstname, string secondname, string lastname, string phone, DateTime registrationDate)
        {
            string query = "UPDATE customers SET firstname = @Firstname, secondname = @Secondname, lastname = @Lastname, phone = @Phone, registrationDate = @RegistrationDate WHERE customerId = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Firstname", firstname);
                command.Parameters.AddWithValue("@Secondname", secondname);
                command.Parameters.AddWithValue("@Lastname", lastname);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@RegistrationDate", registrationDate);

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

        public void deleteCustomer(int id)
        {
            string query = "DELETE FROM customers WHERE customerId=@id";

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

        public void addCustomer(string firstname, string secondname, string lastname, string phone, DateTime registrationDate)
        {
            string query = "INSERT INTO customers (firstname, secondname, lastname, phone, registrationDate) VALUES (@Firstname, @Secondname, @Lastname, @Phone, @RegistrationDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Firstname", firstname);
                command.Parameters.AddWithValue("@Secondname", secondname);
                command.Parameters.AddWithValue("@Lastname", lastname);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@RegistrationDate", registrationDate);

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
