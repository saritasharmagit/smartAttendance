using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_Outstation : System.Web.UI.Page
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
        int eid;
        string emp_name = "";
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (txtStartDate.Text == "" || txtEndDate.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
                return;
            }
            if (CmbEmployee.SelectedItem.Text == "Select Employee")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Select Employee !!!','warning')</script>");
                return;
            }
            DateTime start_date = Convert.ToDateTime(txtStartDate.Text);
            DateTime end_date = Convert.ToDateTime(txtEndDate.Text);
        
            DataTable dt = blu.getEmployeebyAtten();
            if (ChkAllemp.Checked)
            {
                eid = 0;
                emp_name = "";

            }

            else
            {
                 eid = Convert.ToInt32(txtEmpId.Text);
                emp_name = CmbEmployee.SelectedItem.Text;

            }
            Response.Redirect(String.Format("Reports_ViewOutstation.aspx?start_date={0}&end_date={1}&eid={2}&emp_name={3}", Server.UrlEncode(start_date.ToString()), Server.UrlEncode(end_date.ToString()), Server.UrlEncode(eid.ToString()), Server.UrlEncode(emp_name.ToString())));

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
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_Outstation.aspx");
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
        }
       
    }
}