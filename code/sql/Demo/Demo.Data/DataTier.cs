using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Domain;
using MySql.Data.MySqlClient;

namespace Demo.Data
{
    public class DataTier
    {
        private const string ConnectionString = "server=localhost;" +
                                           "user id=OpenEHS_admin;" +
                                           "password=password;" +
                                           "database=OpenEHS_database;" +
                                           "pooling=false;";

        public void InsertProduct(Products prod)
        {
            string procName = "sp_insertProducts";
            string connectionString = "Server=localhost;Database=OpenEHS_database;Uid=OpenEHS_admin;Pwd=password;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(procName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("Name", prod.Name));
                    cmd.Parameters.Add(new MySqlParameter("Unit", prod.Unit));
                    cmd.Parameters.Add(new MySqlParameter("Catagory", prod.Catagory));
                    cmd.Parameters.Add(new MySqlParameter("ProductCost", prod.ProductCost));
                    cmd.Parameters.Add(new MySqlParameter("QuantityOnHand", prod.QuantityOnHand));

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
