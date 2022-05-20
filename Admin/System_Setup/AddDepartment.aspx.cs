using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddDepartment : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CmbDepartment.Visible = false;
                txtSecname.Visible = false;
                loadDepartment();
            }
        }
        public void loadDepartment()
        {
            DataTable dt = blu.getDepartment();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
            CmbDepartment.Items.Insert(0, "Select Department");
            CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");
        }

        //int LEVEL = 0;
        //string FLDTYPE = "";
        //string DEPT_PARENT = "";
        //int Serial_No = 0;
        //string department_code = "";
        //string department_name = "";
        //int flag = 0;
        DataTable dt;
        string olddept = "";
        int stat = 0;
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            //if (!chkbxGroup.Checked && CmbDepartment.SelectedIndex == -1)
            //{
            if (chkbxSection.Checked == true)
            {
                blu.Department(txtDeptname.Text, txtSecname.Text, 2, olddept, rbStatus.Checked ? 1 : 0);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Department saved Successfully').then((value) => { window.location ='Department.aspx'; });", true);
            }
            else if(chkbxGroup.Checked==true)
            {
                string cmbdeptname = CmbDepartment.SelectedItem.ToString();
                blu.Department(cmbdeptname, txtDeptname.Text, 1, olddept, rbStatus.Checked ? 1 : 0);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Department saved Successfully').then((value) => { window.location ='Department.aspx'; });", true);
               
            }
            else
            {
                blu.Department("Main", txtDeptname.Text, 0, olddept, stat);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Department saved Successfully').then((value) => { window.location ='Department.aspx'; });", true);
            }
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Department.aspx");
        }
        protected void chkbxSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxSection.Checked == true)
            {
                txtSecname.Visible = true;
                txtSecname.Text = txtDeptname.Text + " Sec ";
                chkbxGroup.Enabled = false;
            }
            else
            {
                txtSecname.Visible = false;
                chkbxGroup.Enabled = true;
            }


        }
        int Flag = 0;
        protected void chkbxGroup_CheckedChanged1(object sender, EventArgs e)
        {
            if (chkbxGroup.Checked == true)
            {
                CmbDepartment.Visible = true;
                txtDeptname.Text = txtDeptname.Text + "Sec";
                chkbxSection.Enabled = false;
            }
            else
            {
                CmbDepartment.Visible = false;
                chkbxSection.Enabled = true;
            }
        }

        protected void rbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStatus.Checked == true)
            {
                // Response.Redirect("Department.aspx?sta=" + gr.Cells[3].Text
            }
        }
    }
}