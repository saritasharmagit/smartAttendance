using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_RoosterShiftInfo : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int branch_id, dept_id, emp_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                loadEmployee();
            }
        }
        public void loadEmployee()
        {
            DataTable dt = blu.getEmployeebyAtten();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "Fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
        }
        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
        }
        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            int employee = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(employee);
            if (dt.Rows.Count > 0)
            {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();

                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "Fullname";
                CmbEmployee.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID!!!!','warning')", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','No Employee with this ID !!!','warning')</script>");
            }
        }
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (txtNepaliDate.Text == "" || nepaliDate2.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
                return;
            }
          
            if (CmbEmployee.SelectedItem.Text == "Select Employee")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','PlZ Select Employee!!!!','warning')", true);
                return;
            }
            DateTime startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime tilldate = Convert.ToDateTime(txtEndDate.Text);
          
            string emp_name = CmbEmployee.SelectedItem.Text;

            int eid = int.Parse(txtEmpId.Text);

            Response.Redirect(String.Format("Reports_ViewRoosterShiftInfo.aspx?startdate={0}&tilldate={1}&eid={2}&emp_name={3}", Server.UrlEncode(startdate.ToString()), Server.UrlEncode(tilldate.ToString()), Server.UrlEncode(eid.ToString()),Server.UrlEncode(emp_name.ToString())));
        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_RoosterShiftInfo.aspx");
        }
    }
}