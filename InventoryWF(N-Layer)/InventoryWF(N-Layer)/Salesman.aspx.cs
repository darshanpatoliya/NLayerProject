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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        private void BindGridView()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            try
            {
                conn.Open();
                string selectQuery = "SELECT * FROM salesman;";
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    gvSalesman.DataSource = dt;
                    gvSalesman.DataBind();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var nameOfSalesman = txtSalesmanName.Text;
            var cityOfSalesman = txtCity.Text;
            var commissionOfSalesman = decimal.Parse(txtCommission.Text);

            SalesmanBO newSalesman = new SalesmanBO()
            {
                NameOfSalesman = nameOfSalesman,
                CityOfSalesman = cityOfSalesman,
                CommissionOfSalesman = commissionOfSalesman
            };

            SalesmanBL logicOfSalesman = new SalesmanBL();
            int result = logicOfSalesman.InsertNewSalesman(newSalesman);

            ClearFields();
            BindGridView();

        }

        private void ClearFields()
        {
            txtCity.Text = string.Empty;
            txtCommission.Text = string.Empty;
            txtSalesmanName.Text = string.Empty;
        }
    }
}