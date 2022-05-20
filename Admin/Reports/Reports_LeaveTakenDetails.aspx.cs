using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_LeaveTakenDetails : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int emp_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                loadEmployee();
                loadLeave();
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
        public void loadLeave()
        {
            DataTable dt = blu.getLeaveList();
           // DataTable dt = blu.getLeave();
            CmbLeave.DataSource = dt;
            CmbLeave.DataTextField = "LEAVE_NAME";
            CmbLeave.DataValueField = "LEAVE_ID";
            CmbLeave.DataBind();
            CmbLeave.Items.Insert(0, "Select Leave");
           
        }
     
        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
        }
        string emp_name = "";
        int eid;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            int eid = 0; DateTime sdate, edate;

            if (txtStartDate.Text == "" || txtEndDate.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
                return;
            }
           
            if (CmbEmployee.SelectedItem.Text=="Select Employee")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Employee !!!!','warning')", true);
                return;
            }
            if (CmbLeave.SelectedItem.Text == "Select Leave" || CmbLeave.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','PlZ Select Leave !!!!','warning')", true);
                return;
            }
            sdate = Convert.ToDateTime(txtStartDate.Text);
            edate = Convert.ToDateTime(txtEndDate.Text);
            string leave_name = CmbLeave.SelectedItem.Text;
            string leave = (CmbLeave.SelectedItem.Text);
            int leaveid = Convert.ToInt32(CmbLeave.SelectedValue);

            if (ChkAllEmployee.Checked)
            {
                eid = 0;
                emp_name = "";

            }
            else
            {
                emp_name = CmbEmployee.SelectedItem.Text;
                eid = int.Parse(txtEmpId.Text);

            }
            Response.Redirect(String.Format("Reports_ViewLeaveTakenDetails.aspx?sdate={0}&edate={1}&eid={2}&emp_name={3}&leave_name={4}&leaveid={5}", Server.UrlEncode(sdate.ToString()), Server.UrlEncode(edate.ToString()), Server.UrlEncode(eid.ToString()), Server.UrlEncode(emp_name.ToString()), Server.UrlEncode(leave_name.ToString()), Server.UrlEncode(leaveid.ToString())));
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
        }

        protected void ChkAllEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAllEmployee.Checked)
            {

                CmbEmployee.Enabled = false;

                DataTable dt = blu.getEmployeebyAtten();
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataBind();
                txtEmpId.Enabled = false;
                txtEmpId.Text = "";
            }
            else
            {
                CmbEmployee.Enabled = true;

                DataTable dt = blu.getEmployeebyAtten();
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "Fullname";
                CmbEmployee.DataBind();

                txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
            }
        }
    }
}