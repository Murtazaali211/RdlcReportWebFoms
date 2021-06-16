using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoApp
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string SaveToDo(object obj)
        {
            string request = obj.ToString();
            
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Dictionary<string, object> data = jss.Deserialize<Dictionary<string, object>>(request);
            
            SqlConnection con = new SqlConnection("");
            //using (
            SqlCommand cmd = new SqlCommand("");//)
            //{
            cmd.Connection.Open();
             cmd.Parameters.AddWithValue("Message", SqlDbType.VarChar).Value = data["Message"].ToString();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_insert";
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            //};

           return data["Message"].ToString();
        }
    }
}