using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDA
    {
        SqlConnection _connection;

        public OrderDA()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        public int InsertOrder(OrderBO order)
        {
            var storedProcedure = "SP_OrderEntry";
            try
            {
                SqlCommand cmd = new SqlCommand(storedProcedure, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@purch_amt", order.PurchaseAmountOfOrder);
                cmd.Parameters.AddWithValue("@date", order.DateOfOrder);
                cmd.Parameters.AddWithValue("@customer_id", order.IdOfCustomer);
                cmd.Parameters.AddWithValue("@salesman_id", order.IdOfSalesman);

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
