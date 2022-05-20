using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
      public partial class Reports_EmployeeDetailInformation : System.Web.UI.Page
  
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
            DataTable dt = blu.getAllEmployeesList();
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
        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
          
            if (CmbEmployee.SelectedItem.Text=="Select Employee")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','PlZ Select Employee!!!!','warning')", true);
                return;
            }
            int emp_id = int.Parse(txtEmpId.Text);
            Response.Redirect(String.Format("Reports_ViewEmployeeDetailInformation.aspx?emp_id={0}", Server.UrlEncode(emp_id.ToString())));
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_EmployeeDetailInformation.aspx");
        }
    }
}