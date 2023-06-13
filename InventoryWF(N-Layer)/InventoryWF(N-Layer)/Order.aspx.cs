using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlTypes;
using System.Drawing;

namespace InventoryWF_N_Layer_
{
    public partial class Order : System.Web.UI.Page
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack) 
            {
                BindDropdownList();
                GridViewOfOrders.DataBind();
                BindGridView();

                SqlConnection conn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("select * from orders", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
            }
            //Required for jQuery DataTables to work.
            GridViewOfOrders.UseAccessibleHeader = true;
            GridViewOfOrders.HeaderRow.TableSection = TableRowSection.TableHeader;

        }
        
        private void BindGridView()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            try
            {
                conn.Open();
                string selectQuery = "SELECT order_no, FORMAT(purch_amt, 'N2') AS purch_amt, FORMAT (ord_date, 'yyyy-MM-dd') AS ord_date, customer_id, salesman_id FROM orders;";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    GridViewOfOrders.DataSource = dt;
                    GridViewOfOrders.DataBind();
                }

                
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message, ex);
            }
            finally
            {
                conn.Close();
            }
        }
        private void BindDropdownList()
        {
            SqlConnection conn = new SqlConnection(_connectionString);

            SqlCommand com = new SqlCommand("select * from customer", conn);
            SqlCommand com2 = new SqlCommand("select * from salesman", conn);

            SqlDataAdapter da = new SqlDataAdapter(com);
            SqlDataAdapter da2 = new SqlDataAdapter(com2);
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            da.Fill(ds);
            da2.Fill(ds2);
            dropDownListOfCustomers.DataTextField = ds.Tables[0].Columns["cust_name"].ToString();
            dropDownListOfCustomers.DataValueField = ds.Tables[0].Columns["customer_id"].ToString();
            dropDownListOfCustomers.DataSource = ds.Tables[0];
            dropDownListOfCustomers.DataBind();

            dropDownListOfSalesman.DataTextField = ds2.Tables[0].Columns["name"].ToString();
            dropDownListOfSalesman.DataValueField = ds2.Tables[0].Columns["salesman_id"].ToString();

            dropDownListOfSalesman.DataSource = ds2.Tables[0];
            dropDownListOfSalesman.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var purchaseAmountOfOrder = SqlMoney.Parse(txtPurchaseAmount.Text);
            var dateOfOrder = DateTime.Parse(orderDateCalendar.SelectedDate.ToString("yyyy-MM-dd"));
            var idOfCustomer = int.Parse(dropDownListOfCustomers.SelectedValue);
            var idOfSalesman = int.Parse(dropDownListOfSalesman.SelectedValue);

            OrderBO newOrder= new OrderBO()
            {
                PurchaseAmountOfOrder = purchaseAmountOfOrder,
                DateOfOrder = dateOfOrder,
                IdOfCustomer = idOfCustomer,
                IdOfSalesman = idOfSalesman
            };

            OrderBL logicOfOrder = new OrderBL();
            int result = logicOfOrder.InsertNewOrder(newOrder);
            ClearFields();
            GridViewOfOrders.DataBind();
            BindGridView();
        }


        private void ClearFields()
        {
            txtPurchaseAmount.Text = string.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("select * from orders where order_no=" + DropDownList1.SelectedItem.Value, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}