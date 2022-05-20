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
    public partial class LeaveInformationReport : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int branch, department, empid;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string EMP_ID = Session["username"].ToString();
                int emp_id = Convert.ToInt32(EMP_ID);
                DataTable dt = blu.getAllInfo(emp_id);
                if (dt.Rows.Count > 0)
                {
                  
                    TxtEmp.Text = dt.Rows[0]["emp_Fullname"].ToString();
                    txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                }
            }
        }

        int EMPID = 0;
        string emp_name = "";
        protected void BtnLoadMonthlyAttendance_Click(object sender, EventArgs e)
        {
          
            EMPID = Convert.ToInt32(txtEmpId.Text);
            emp_name = TxtEmp.Text;

            Response.Redirect(String.Format("ViewLeaveInformationReport.aspx?EMPID={0}&emp_name={1}", Server.UrlEncode(EMPID.ToString()), Server.UrlEncode(emp_name.ToString())));
        }

        protected void BtnCancelMonthlyAttendance_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveInformationReport.aspx");
        }
    }
}