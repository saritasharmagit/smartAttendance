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
    public partial class MonthlyAttendanceReport : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtStartDate.Text = DateTime.Now.ToString("yyyy-MM-01");
                TxtEndDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                int emp_id = Convert.ToInt32(Session["username"].ToString());
                DataTable dt = blu.getAllInfo(emp_id);
                if (dt.Rows.Count > 0)
                {
                   
                    TxtEmployee.Text = dt.Rows[0]["emp_Fullname"].ToString();
                    txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                }
            }
        }

        
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            DateTime Startdate = Convert.ToDateTime(TxtStartDate.Text);
            DateTime Enddate = Convert.ToDateTime(TxtEndDate.Text);
           
            string emp_name = TxtEmployee.Text;
            string emp_id = txtEmpId.Text;

            Response.Redirect(String.Format("ViewMonthlyAttendanceReport.aspx?Startdate={0}&Enddate={1}&emp_id={2}&emp_name={3}", Server.UrlEncode(Startdate.ToString()), Server.UrlEncode(Enddate.ToString()), Server.UrlEncode(emp_id.ToString()), Server.UrlEncode(emp_name.ToString()) ));
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("MonthlyAttendanceReport.aspx");
        }
    }
}