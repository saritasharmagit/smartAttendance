using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class EditDepartment : System.Web.UI.Page
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
                stat = Convert.ToInt32(Request.QueryString["sta"].ToString());
               // oldsec = Request.QueryString["DEPT_NAME"].ToString();
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

                //CmbDepartment.Visible = false;
                //txtSecname.Visible = false;

                //loadDepartment();
            }
        }
        public void loadDepartment()
        {
            //DataTable dt = blu.getDepartment();
            //CmbDepartment.DataSource = dt;
            //CmbDepartment.DataTextField = "DEPT_Name";
            //CmbDepartment.DataValueField = "DEPT_ID";
            //CmbDepartment.DataBind();
            //CmbDepartment.Items.Insert(0, "Select Department");
            //cmbBranch.Items[0].Attributes.Add("disabled", "disabled");
        }
        int dept = 0;
        DataTable dt;
        // int Flag = 0;
        protected void chkbxGroup_CheckedChanged1(object sender, EventArgs e)
        {
            //if (chkbxGroup.Checked == true)
            //{
            //    //int Flag = 1;
            //    CmbDepartment.Visible = true;
            //    CmbDepartment.SelectedItem.Text = txtDeptname.Text;
            //    chkbxSection.Enabled = false;
            //    //dt = blu.Department(txtDeptname.Text, txtSecname.Text, Flag, olddept);

            //}
            //else
            //{
            //    //int Flag = 0;
            //    CmbDepartment.Visible = false;
            //    chkbxSection.Enabled = true;
            //    //dt = blu.Department(txtDeptname.Text, txtSecname.Text, Flag, olddept);
            //}
        }

        protected void chkbxSection_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkbxSection.Checked == true)
            //{
            //    //int Flag = 2;
            //    txtSecname.Visible = true;
            //    txtSecname.Text = txtDeptname.Text + " Sec ";
            //    chkbxGroup.Enabled = false;
            //    //dt = blu.Department(txtDeptname.Text, txtSecname.Text, Flag, olddept);
            //}
            //else
            //{
            //    // int Flag = 0;
            //    txtSecname.Visible = false;
            //    chkbxGroup.Enabled = true;
            //    // dt = blu.Department(txtDeptname.Text, txtSecname.Text, Flag, olddept);
            //}
        }
        string olddept = "";
        int stat1 = 0;
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string sst = olddept;
            olddept = Request.QueryString["olddept"].ToString();
            blu.Department("Main", txtDeptname.Text, 0, olddept, rbStatus.Checked ? 1 : 0);
            {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Department Updated Successfully').then((value) => { window.location ='Department.aspx'; });", true);

            }
            //if (!chkbxGroup.Checked && CmbDepartment.SelectedIndex == -1)
            //{
            // if (chkbxSection.Checked && txtSecname.Text != string.Empty)
            //    {
            //        dt = blu.Department(txtDeptname.Text,txtSecname.Text, 2, olddept);
            //    }
            //    else
            //        dt = blu.Department("Main", txtDeptname.Text, 0, olddept);
            //}
           
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Department.aspx");
        }
    }
}