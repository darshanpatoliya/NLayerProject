using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Linq;

namespace DataAccess
{
    public class CustomerDA
    {
        SqlConnection _connection;

        public CustomerDA()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        public int InsertCustomer(CustomerBO customer)
        {
            var storedProcedure = "SP_CustomerEntry";
            try
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cust_name", customer.NameOfCustomer);
                cmd.Parameters.AddWithValue("@city", customer.CityOfCustomer);
                cmd.Parameters.AddWithValue("@grade", customer.GradeOfCustomer);
                cmd.Parameters.AddWithValue("@salesman_id", customer.IdOfSalesman);

                _connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                _connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message, ex);
            }
        }
    }
}
