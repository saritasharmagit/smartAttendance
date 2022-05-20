using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_QuickAttendance : System.Web.UI.Page
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
        string emp_name;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            int eid = 0; DateTime sdate, edate;

            if (txtStartDate.Text == "" || txtEndDate.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
                return;
            }
           
            if (CmbEmployee.SelectedItem.Text == "Select Employee" || CmbEmployee.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Employee !!!!','warning')", true);
                return;
            }
            sdate = Convert.ToDateTime(txtStartDate.Text);
            edate = Convert.ToDateTime(txtEndDate.Text);
            //eid = Convert.ToInt32(txtEmpId.Text);
            //emp_name = CmbEmployee.SelectedItem.Text;
            int Aflag = 0;
            DataTable dt = blu.getEmployeebyAtten();
            if (Chkemp.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eid = int.Parse(dt.Rows[i]["EMP_ID"].ToString());
                    emp_name = dt.Rows[i]["Fullname"].ToString();
                    blu.QuickAttnReport(eid, sdate, edate, Aflag);
                    Aflag = 1;
                }
            }
            else
            {
                eid = Convert.ToInt32(txtEmpId.Text);
                emp_name = CmbEmployee.SelectedItem.Text;
                blu.QuickAttnReport(eid, sdate, edate, Aflag);
             }
                Response.Redirect(String.Format("Reports_ViewQuickAttendance.aspx?sdate={0}&edate={1}&eid={2}&emp_name={3}", Server.UrlEncode(sdate.ToString()), Server.UrlEncode(edate.ToString()), Server.UrlEncode(eid.ToString()), Server.UrlEncode(emp_name.ToString())));
          
            }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_QuickAttendance.aspx");
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

        protected void Chkemp_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkemp.Checked)
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