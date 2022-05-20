using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_AttendanceSummarySheet : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
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

        protected void Chkemp_CheckedChanged(object sender, EventArgs e)
        {
            //int deptid= Convert.ToInt32(CmbDepartment.SelectedValue);

            if (Chkemp.Checked)
            {

                CmbEmployee.Enabled = false;

                DataTable dt = blu.getEmployeebyAtten();
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataBind();
                //CmbEmployee.Items.Clear();
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

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (txtNepaliDate.Text == "" || nepaliDate2.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
                return;
            }

            if (CmbEmployee.SelectedItem.Text == "Select Employee")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Plz Select Employee !!!','warning')", true);
                return;
            }

            //BtnExport.Visible = true;
            DateTime Startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime Enddate = Convert.ToDateTime(txtEndDate.Text);

            string emp_name = CmbEmployee.SelectedItem.Text;

            //DataTable dt = blu.getDept_EmployeeList(dept_id);
            //string employeename = "";
            DataTable dt = blu.getEmployeebyAtten();
            int eid = 0;
            int flag = 0;
            if (Chkemp.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eid = int.Parse(dt.Rows[i]["EMP_ID"].ToString());
                    blu.QuickAttnReport(eid, Startdate, Enddate, flag);
                    flag = 1;
                }
            }
            else
            {
                eid = Convert.ToInt32(txtEmpId.Text);
                blu.QuickAttnReport(eid, Startdate, Enddate, flag);
                //blu.proc_Attn_Mon_General(eid, Startdate, Enddate, flag);
            }
            Response.Redirect(String.Format("Reports_ViewAttendanceSummarySheet.aspx?Startdate={0}&Enddate={1}&eid={2}&emp_name={3}", Server.UrlEncode(Startdate.ToString()), Server.UrlEncode(Enddate.ToString()), Server.UrlEncode(eid.ToString()), Server.UrlEncode(emp_name.ToString())));
        }


        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_AttendanceSummarySheet.aspx");
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