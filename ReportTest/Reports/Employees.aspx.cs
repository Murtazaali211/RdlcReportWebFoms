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
    public partial class Employees : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-R7NV9T9;Initial Catalog=TimeAX;User Id=sa; Password=admin@123;MultipleActiveResultSets=true;");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            //string query = "SELECT a.Id,a.Account_Id,a.Name, d.Name as Account FROM AccountChart a inner join AccountDescription d on d.Account_Id = a.Account_Id";
            string query = @"SELECT TOP 500 [EmployeeNo]    
                            ,[EmployeeName]
                            ,[FatherName]
                            ,[Gender]
                            ,[HouseNo]
                            ,[Area]
                            ,[City]
                            ,[Designation]     
                            ,[NIC]    
                            ,[PhoneNo]
                            ,[MobileNo]
                            ,[Email]
                            ,[Nationality]
                            ,[MaritalStatus]
                            ,[AppointmentDate]
                            ,[ConfirmationDate]
                            ,[BirthDate]          
                            ,[Department]
                            ,[RosterType]                            
                            ,[TransportMode]
                          FROM [TimeAX].[dbo].[HRTEmployee]";
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

                    reportDataSet.Tables["Employee"].Merge(dt);
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/EmployeesReport.rdlc");
                    ReportDataSource dataSource = new ReportDataSource("ReportDataSet", reportDataSet.Tables["Employee"]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(dataSource);
                                        
                }
            }
        }
    }
}