using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressDetailsforSQLqueries
    {
        public static string connectionString = @"Data Source=DESKTOP-SC0MR56\SQLEXPRESS;Initial Catalog=AddressBookSystem_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public List<AddressModelforSQL> addressModelforSQLs = new List <AddressModelforSQL>();
        public void GetAllDetails()
        {
            try
            {
                AddressModelforSQL addressModelforSQL = new AddressModelforSQL();
                string query = @"Select * from AddressBookSystem;";
                SqlCommand cmd = new SqlCommand(query, this.connection);
                this.connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Console.WriteLine("\tID\tFirstName\tLastName\tAddress");
                    Console.WriteLine("\t--\t---------\t--------\t-------");
                    while (dr.Read())
                    {
                        addressModelforSQL.ID = dr.GetString(0);
                        addressModelforSQL.firstName = dr.GetString(1);
                        addressModelforSQL.lastName = dr.GetString(2);
                        addressModelforSQL.address = dr.GetString(3);
                        
                        Console.WriteLine("\t" + addressModelforSQL.ID + "\t" + addressModelforSQL.firstName + "\t" + addressModelforSQL.lastName + "\t\t" + addressModelforSQL.address);
                    }
                }
                else
                {
                    Console.WriteLine("No data found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
