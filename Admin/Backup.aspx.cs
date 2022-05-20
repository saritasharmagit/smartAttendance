using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web.Configuration;

namespace AttendanceKantipur.Admin
{
    public partial class Backup : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
           // con.ConnectionString = @"Data Source=.;Initial Catalog=smart;User Id=sa;Password=123";
             con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
            string backupDIR = "D:\\BackupDB";
            if (!System.IO.Directory.Exists(backupDIR))
            {
                System.IO.Directory.CreateDirectory(backupDIR);
            }
            try
            {
                con.Open();
                sqlcmd = new SqlCommand("backup database smart to disk='" + backupDIR + "\\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'", con);
                sqlcmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Backup database successfully.";
               
                
            }
            catch (Exception ex)
            {
                Label1.Text = "Error Occured During DB backup process !<br>" + ex.ToString();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
       
    }
}