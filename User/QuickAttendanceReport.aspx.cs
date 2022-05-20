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
    public partial class QuickAttendanceReport : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-01");
                txtEndDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                string EMP_ID = Session["username"].ToString();
                int emp_id = Convert.ToInt32(EMP_ID);
                DataTable dt = blu.getAllInfo(emp_id);
                if (dt.Rows.Count > 0)
                {
                   
                    TxtEmployee.Text = dt.Rows[0]["emp_Fullname"].ToString();
                    txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                }
            }
        }

        DateTime sdate, edate;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            sdate = Convert.ToDateTime(txtStartDate.Text);
            edate = Convert.ToDateTime(txtEndDate.Text);
           
            string emp_id = txtEmpId.Text;

            Response.Redirect(String.Format("ViewQuickAttendance.aspx?sdate={0}&edate={1}&emp_id={2}", Server.UrlEncode(sdate.ToString()), Server.UrlEncode(edate.ToString()), Server.UrlEncode(emp_id.ToString()) ));
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuickAttendanceReport.aspx");
        }
    }
}