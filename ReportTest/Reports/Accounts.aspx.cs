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
    public partial class Accounts : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=sql7005.site4now.net;Initial Catalog=DB_A429E2_FoodDelivery;User Id=DB_A429E2_FoodDelivery_admin; Password=Admin@123;MultipleActiveResultSets=true;");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string query = "SELECT a.Id,a.Account_Id,a.Name, d.Name as Account FROM AccountChart a inner join AccountDescription d on d.Account_Id = a.Account_Id";
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    //dgvData.DataSource = dt;
                    //dgvData.DataBind();
                    ReportDataSet reportDataSet = new ReportDataSet();

                    reportDataSet.Tables["Account"].Merge(dt);
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("AccountReport.rdlc");
                    ReportDataSource dataSource = new ReportDataSource("ReportDataSet", reportDataSet.Tables["Account"]);                    
                    ReportViewer1.LocalReport.EnableHyperlinks = true;
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(dataSource);
                    ReportViewer1.LocalReport.Refresh();

                }
            }
        }
    }
}