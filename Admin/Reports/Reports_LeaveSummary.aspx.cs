using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_LeaveSummary : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

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
        protected void ChkAllemp_CheckedChanged1(object sender, EventArgs e)
        {
            if (ChkAllemp.Checked)
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
        int EMPID = 0;
        string emp_name = "";
        protected void BtnLoadLeaveSummary_Click(object sender, EventArgs e)
        {
            if (CmbEmployee.SelectedItem.Text == "Select Employee")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','PlZ Select Employee!!!!','warning')", true);
                return;
            }
            DataTable dt = blu.getEmployeebyAtten();
            if (ChkAllemp.Checked)
            {
                EMPID = 0;
                emp_name = "";

            }
            else
            {
                EMPID = Convert.ToInt32(txtEmpId.Text);
                emp_name = CmbEmployee.SelectedItem.Text;

            }

            Response.Redirect(String.Format("Reports_ViewLeaveSummary.aspx?EMPID={0}", Server.UrlEncode(EMPID.ToString())));
        }

        protected void BtnLeaveSummary_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_LeaveSummary.aspx");
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
    }
}