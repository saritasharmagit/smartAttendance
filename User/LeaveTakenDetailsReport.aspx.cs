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
    public partial class LeaveTakenDetailsReport : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        DateTime sdate, edate;
        int emp_id;
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
                   
                    TxtEmp.Text = dt.Rows[0]["emp_Fullname"].ToString();
                    TxtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                }
                loadLeave();
            }
        }
        public void loadLeave()
        {
            int emp_id = Convert.ToInt32(Session["username"].ToString());
            DataTable dt = blu.getleave_emp(emp_id);
            CmbLeave.DataSource = dt;
            CmbLeave.DataTextField = "LEAVE_NAME";
            CmbLeave.DataValueField = "LEAVE_ID";
            CmbLeave.DataBind();
            CmbLeave.Items.Insert(0, "Select Leave");
            CmbLeave.Items[0].Selected = true;
            CmbLeave.Items[0].Attributes["disabled"] = "disabled";
        }


        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (CmbLeave.SelectedItem.Text == "Select Leave" || CmbLeave.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','PlZ Select Leave !!!!','warning')", true);
                return;
            }

            sdate = Convert.ToDateTime(TxtStartDate.Text);
            edate = Convert.ToDateTime(TxtEndDate.Text);
           
            string emp_name = TxtEmp.Text;
            string leave_name = CmbLeave.SelectedItem.Text;

            emp_id = int.Parse(TxtEmpId.Text);
          
            string leave = (CmbLeave.SelectedItem.Text);
            int leavemp_id = Convert.ToInt32(CmbLeave.SelectedValue);

            Response.Redirect(String.Format("ViewLeaveTakenDetailsReport.aspx?sdate={0}&edate={1}&emp_id={2}&emp_name={3}&leave_name={4}&leavemp_id={5}", Server.UrlEncode(sdate.ToString()), Server.UrlEncode(edate.ToString()), Server.UrlEncode(emp_id.ToString()), Server.UrlEncode(emp_name.ToString()), Server.UrlEncode(leave_name.ToString()), Server.UrlEncode(leavemp_id.ToString()) ));
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveTakenDetailsReport.aspx");
        }
    }
}