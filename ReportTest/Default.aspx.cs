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

namespace ReportTest
{
    public partial class _Default : Page
    {
        SqlConnection con = new SqlConnection("Data Source=sql7005.site4now.net;Initial Catalog=DB_A429E2_FoodDelivery;User Id=DB_A429E2_FoodDelivery_admin; Password=Admin@123;MultipleActiveResultSets=true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if(Request.QueryString[0] != null)
                //txtName.Text = Request.QueryString[0].ToString() + " & " + Request.QueryString[1].ToString();

               
            }
            
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
                        dgvData.DataSource = dt;
                        dgvData.DataBind();
                        ReportDataSet reportDataSet = new ReportDataSet();                        
                        reportDataSet.Tables["Product"].Merge(dt);
                        ReportViewer1.ProcessingMode = ProcessingMode.Local;
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("ProductReport.rdlc");
                        ReportDataSource dataSource = new ReportDataSource("ReportDataSet", reportDataSet.Tables["Product"]);

                        //ReportParameterCollection reportParameters = new ReportParameterCollection();
                        //reportParameters.Add(new ReportParameter("@Account", Request.QueryString[1].ToString()));
                        //ReportViewer1.LocalReport.SetParameters(reportParameters);
                        //ReportParameter p1 = new ReportParameter("Account", "Test Account");
                        //ReportViewer1.ShowParameterPrompts = true;
                        //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(dataSource);
                        ReportViewer1.LocalReport.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            showReport();
        }
    }
}