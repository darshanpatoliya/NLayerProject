using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess
{
    public class SalesmanDA
    {
        SqlConnection _connection;

        public SalesmanDA()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        public int InsertSalesman(SalesmanBO salesman)
        {
            var storedProcedure = "SP_SalesmanEntry";
            try
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", salesman.NameOfSalesman);
                cmd.Parameters.AddWithValue("@city", salesman.CityOfSalesman);
                cmd.Parameters.AddWithValue("@commision", salesman.CommissionOfSalesman);

                _connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                _connection.Close();

                return result;
            }
            catch ( Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message, ex);
            }
        }
    }
}
