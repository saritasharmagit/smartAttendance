using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur
{
    public partial class Default : System.Web.UI.Page
    {
        LoginClass blu = new LoginClass();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
       
          protected void BtnLogin_Click(object sender, EventArgs e)
            {
            DataTable dt = blu.Authenticate(TxtUserName.Text, TxtPassword.Text);
            if (dt.Rows.Count > 0)
            {
                int userTypeId = int.Parse(dt.Rows[0]["UserType_Id"].ToString());
                if (userTypeId == 2)
                {
                    Session["username"] = TxtUserName.Text;
                    Session["password"] = TxtPassword.Text;
                    Response.Redirect("Admin/Dashboard.aspx");
                }
                else if (userTypeId == 4)
                {
                    Session["username"] = TxtUserName.Text;
                    Session["password"] = TxtPassword.Text;
                    Response.Redirect("Supervisor/Dashboard.aspx");
                }
                else if (userTypeId == 5)
                {
                    Session["username"] = TxtUserName.Text;
                    Session["password"] = TxtPassword.Text;
                    Response.Redirect("User/Dashboard.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Check Your Credentials!','warning')</script>");
                Response.Redirect("Default.aspx");
            }

        }
    }
}
   