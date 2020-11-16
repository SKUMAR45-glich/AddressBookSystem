using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public bool addAddressDetails()
        {
            AddressModelforSQL addressModelforSQL = new AddressModelforSQL();
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddinAddressDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", addressModelforSQL.firstName);
                    command.Parameters.AddWithValue("@LastName", addressModelforSQL.lastName);
                    command.Parameters.AddWithValue("@Address", addressModelforSQL.address);
                    command.Parameters.AddWithValue("@City", addressModelforSQL.city);
                    command.Parameters.AddWithValue("@State", addressModelforSQL.state);
                    command.Parameters.AddWithValue("@Zip", addressModelforSQL.zip);
                    command.Parameters.AddWithValue("@PhoneNumber", addressModelforSQL.phoneNumber);
                    command.Parameters.AddWithValue("@Email", addressModelforSQL.email);
                    command.Parameters.AddWithValue("@ContactName", addressModelforSQL.contactName);
                    command.Parameters.AddWithValue("@ContactType", addressModelforSQL.contactType);
                    command.Parameters.AddWithValue("@DateofJoining", addressModelforSQL.dateOfJoining);


                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }

        public static List<DataRow> ContactDetailsBetweenDateRange(DateTime startDate, DateTime endDate)
        {
            DataSet dataSet = RetrieveDataFromTable();

            var contactInDateRange = from data in dataSet.Tables["AddressBookSystem"].AsEnumerable()
                                     where data.Field<DateTime>("StartDate") >= startDate
                                     && data.Field<DateTime>("EndDate") <= endDate
                                     select data;

            return contactInDateRange.ToList();
        }

        public static Dictionary<string,int> retrieveCountByState() 
        {
            DataSet dataSet = RetrieveDataFromTable();

            var countofContactsinState = (from data in dataSet.Tables["AddressBookSystem"].AsEnumerable()
                                      group data by data.Field<string>("state"))
                                     .ToDictionary(stateData => stateData.Key, stateData => stateData.Count());

            return countofContactsinState;
        }

        public static DataSet RetrieveDataFromTable()
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"select * from AddressBookSystem;");
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet, "AddressBookSystem");
            }

            return dataSet;
        }
    }

    
}
