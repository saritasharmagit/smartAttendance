using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Attendance_Mgmt
{
    public partial class Attendance_mgmt : System.Web.UI.MasterPage
    {
        LoginClass bli = new LoginClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == "" || Session["username"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            else
            {
                string EMP_ID = Session["username"].ToString();
                string EMP_PASSWORD = Session["password"].ToString();
                // string userTypeId = Session["usertype"].ToString();
                DataTable dt = bli.Authenticate(EMP_ID, EMP_PASSWORD);
                if (dt.Rows.Count > 0)
                {
                    //lblEmployee.Text = dt.Rows[0]["EMP_FIRSTNAME"].ToString();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }

            }
        }
    }
}