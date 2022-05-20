using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_DailyAbsent : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
              
            }
        }
     
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (txtNepaliDate.Text == ""||txtStartDate.Text=="")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
                return;
            }
           
            DateTime date = Convert.ToDateTime(txtStartDate.Text);
            DataTable dt = blu.getEmployeebyAtten();

            Response.Redirect(String.Format("Reports_ViewDailyAbsent.aspx?date={0}",Server.UrlEncode(date.ToString())));
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
        }

        protected void Chkemp_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}