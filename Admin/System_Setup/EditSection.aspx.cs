using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class EditSection : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int stat = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int departmentid = Convert.ToInt32(Request.QueryString["DEPT_ID"].ToString());
                HiddenField1.Value = departmentid.ToString();
                DataTable dta = blu.GetdepartmentbydepartmentId(departmentid);
                txtDeptname.Text = Request.QueryString["DEPT_NAME"].ToString();
                txtSecname.Text = Request.QueryString["olddept"].ToString();
                stat = Convert.ToInt32(Request.QueryString["sta"].ToString());

                if (stat == 1)
                {
                    rbStatus.Checked = true;
                    rbStatus1.Checked = false;
                }
                else
                {
                    rbStatus.Checked = false;
                    rbStatus1.Checked = true;
                }
            }
        }
        int flag = 1;
        string olddept = "";
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            olddept = Request.QueryString["olddept"].ToString();
            blu.Department(txtDeptname.Text, txtSecname.Text, flag, olddept, rbStatus.Checked ? 1 : 0);
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Section Updated Successfully').then((value) => { window.location ='Department.aspx'; });", true);
               
            }
        }
    }
}