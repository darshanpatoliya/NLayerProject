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

namespace InventoryWF_N_Layer_
{
    public partial class Customer : System.Web.UI.Page
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                BindDropdownList();
            }
        }
        private void BindGridView()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            try
            {
                conn.Open();
                string selectQuery = "select * from customer";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    gvCustomer.DataSource = dt;
                    gvCustomer.DataBind();
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

            SqlCommand com = new SqlCommand("select * from salesman", conn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DropDownListOfSalesmanId.DataTextField = ds.Tables[0].Columns["name"].ToString();
            DropDownListOfSalesmanId.DataValueField = ds.Tables[0].Columns["salesman_id"].ToString();

            DropDownListOfSalesmanId.DataSource = ds.Tables[0];
            DropDownListOfSalesmanId.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var nameOfCustomer = txtCustomerName.Text;
            var cityOfCustomer = txtcityOfCustomer.Text;
            var gradeOfCustomer = int.Parse(txtGrade.Text);
            var idOfSalesman = int.Parse(DropDownListOfSalesmanId.SelectedValue);

            CustomerBO newCustomer = new CustomerBO()
            {
                NameOfCustomer= nameOfCustomer,
                CityOfCustomer= cityOfCustomer,
                GradeOfCustomer = gradeOfCustomer,
                IdOfSalesman= idOfSalesman
            };

            CustomerBL logicOfCustomer = new CustomerBL();
            int result = logicOfCustomer.InsertNewCustomer(newCustomer);

            BindGridView();
            ClearFields();
        }

        private void ClearFields()
        {
            txtCustomerName.Text = string.Empty;
            txtcityOfCustomer.Text = string.Empty;
            txtGrade.Text = string.Empty;
        }
    }
}