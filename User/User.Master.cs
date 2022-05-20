using AttendanceKantipur;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] as string == "" || Session["username"] as string == null)
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                string EMP_ID = Session["username"].ToString();
                string EMP_PASSWORD = Session["password"].ToString();
                int userTypeId = 5;
                DataTable dt = blu.Authenticate(EMP_ID, EMP_PASSWORD);
                if (dt.Rows.Count > 0)
                {
                    emp_name.Text = dt.Rows[0]["EMP_FIRSTNAME"].ToString();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }

            }
        }
    }
}