using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_LateAttendance : System.Web.UI.Page
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
      
        protected void condition_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtdept_id.Text = CmbDepartment.SelectedValue.ToString();
        }
        string emp_name;
        int flag = 0;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (txtNepaliDate.Text == "" || nepaliDate2.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
                return;
            }
          
            if (condition.SelectedItem.Text == "Select Any" || condition.SelectedItem.Text=="")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Any Record from dropdown !!!!','warning')", true);
                return;
            }
            DateTime date_from = Convert.ToDateTime(txtStartDate.Text);
            DateTime date_to = Convert.ToDateTime(txtEndDate.Text);
          
            int con = Convert.ToInt32(condition.SelectedValue);
            DataTable dt = blu.getEmployeebyAtten();
            int eid = 0;
          

            if (Chkemp.Checked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eid = int.Parse(dt.Rows[i]["EMP_ID"].ToString());
                    emp_name = (dt.Rows[i]["Fullname"].ToString());
                    flag = 1;
                }
            }
            else
            {
                eid = Convert.ToInt32(txtEmpId.Text);
                emp_name = CmbEmployee.SelectedItem.Text;
            }


            Response.Redirect(String.Format("Reports_ViewLateAttendance.aspx?date_from={0}&date_to={1}&con={2}&eid={3}&emp_name={4}", Server.UrlEncode(date_from.ToString()), Server.UrlEncode(date_to.ToString()), Server.UrlEncode(con.ToString()),Server.UrlEncode(eid.ToString()),Server.UrlEncode(emp_name.ToString())));
        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_LateAttendance.aspx");
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
        }

        protected void Chkemp_CheckedChanged(object sender, EventArgs e)
        {
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