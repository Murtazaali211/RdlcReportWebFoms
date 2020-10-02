using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;

namespace ReportTest.Reports
{
    public partial class Products : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=sql7005.site4now.net;Initial Catalog=DB_A429E2_FoodDelivery;User Id=DB_A429E2_FoodDelivery_admin; Password=Admin@123;MultipleActiveResultSets=true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtName.Text = Request.QueryString["Id"].ToString() + " " + Request.QueryString["Name"].ToString();
                showReport();
            }

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            showReport();
        }

        private void showReport()
        {
            try
            {
                string query = "Select * from Product";// where Product_Name = '" + txtName.Text +"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        //GridView1.DataSource = dt;
                        //GridView1.DataBind();

                        //ReportParameterCollection reportParameters = new ReportParameterCollection();                        
                        //reportParameters.Add(new ReportParameter("Name", "test"));
                                                              
                        ReportDataSet reportDataSet = new ReportDataSet();

                        reportDataSet.Tables["Product"].Merge(dt);
                        ReportViewer1.ProcessingMode = ProcessingMode.Local;
                        //ReportViewer1.LocalReport.ReportEmbeddedResource = "~/Reports/NewProductReport.rdlc";
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/NewProductReport.rdlc");
                        //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/ProdReport.rdlc");
                        ReportDataSource dataSource = new ReportDataSource("ReportDataSet", reportDataSet.Tables["Product"]);
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(dataSource);
                        //ReportViewer1.LocalReport.SetParameters(reportParameters);
                        this.ReportViewer1.LocalReport.Refresh();

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}