using Elex.Instances;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elex.Queries
{
    internal class WorkerQueries: Connect
    {
        public Worker auth(string phone, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM workers WHERE phone = @Phone AND password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Worker worker = new Worker
                            {
                                Id = Convert.ToInt32(reader["workerId"].ToString()),
                                Firstname = reader["firstname"].ToString(),
                                Lastname = reader["lastname"].ToString(),
                                Secondname = reader["secondname"].ToString(),
                                Phone = reader["phone"].ToString(),
                                RoleId = Convert.ToInt32(reader["roleId"]),
                            };

                            return worker;
                        }
                    }
                }
            }
            return new Worker();
        }
    }
}
