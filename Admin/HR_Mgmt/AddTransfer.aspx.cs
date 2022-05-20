using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.HR_Mgmt
{
    public partial class AddTransfer : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBranch();
               // loadDistrict();
                loadDepartment();

                txtNewContractFromNepali.Visible = false;
                txtNewContract.Visible = false;
                txtNewContractToNepali.Visible = false;
                txtNewContractTo.Visible = false;
                lblnewContractfrom.Visible = false;
                lblNewContractTo.Visible = false;
            }
        }

        public void loadBranch()
        {
            DataTable dt = blu.getBranch();
            CmbBranch.DataSource = dt;
            CmbBranch.DataTextField = "BRANCH_Name";
            CmbBranch.DataValueField = "BRANCH_ID";
            CmbBranch.DataBind();
            CmbBranch.Items.Insert(0, "Select Project");
        }
      
        public void loadDepartment()
        {
            DataTable dt = blu.getDepartment();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
            CmbDepartment.Items.Insert(0, "Select Department");
        }
        string district = "";
        int branchidTo = 0;
        string branch = "";
        int department1;
        int department;
        string designation = "";
        string admin = "Admin";
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int currentbranch = Convert.ToInt32(txtProjectid.Text);
            DataTable dt = blu.getDepartmentBranch(currentbranch);
            if(dt.Rows.Count > 0)
            {
                 department = Convert.ToInt32(dt.Rows[0]["DEPT_ID"].ToString());
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','No Department!','warning')</script>");
                return;
            }

            branch = CmbBranch.SelectedItem.Text;
            branchidTo = Convert.ToInt32(CmbBranch.SelectedValue);

            int newbranch = Convert.ToInt32(txtnewbranchid.Text);
            DataTable dt1 = blu.getDepartmentInfo();
            if (dt1.Rows.Count > 0)
            {
                department1 = Convert.ToInt32(dt1.Rows[0]["DEPT_ID"].ToString());
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','No Department!','warning')</script>");
                return;
            }
            district = CmbnewDistrict.SelectedItem.Text;
            if (txtDate.Text == "" || nepaliDate.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Select Date Format!','warning')</script>");
                return;
            }
            int designationid = Convert.ToInt32(txtnewdegid.Text);
            string designationname = (CmbDesignation.SelectedItem.Text);
            string Contractfromdate = (txtNewContract.Text);
            string ContractTodate = (txtNewContractTo.Text);
            if (!chkContract.Checked)
            {
                flag = 0;
                blu.CreateTransfer(Convert.ToDateTime(txtDate.Text), txtDescription.Text, chkTransfer.Checked ? 1 : 0, txtEmpId.Text, branchidTo, department, department1, 1, Convert.ToInt32(txtProjectid.Text), department, 1, txtCurDistrict.Text, district, Convert.ToInt32(txtCurDistrictid.Text), Convert.ToInt32(CmbnewDistrict.SelectedValue), designationname, txtDesignation.Text, designationid, Convert.ToInt32(txtDegid.Text), txtOldSalary.Text, txtNewSalary.Text, Contractfromdate, ContractTodate, flag);
            }
            else
            {
                if (txtNewContract.Text == "" || txtNewContractTo.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Please Fill New Contract Date!','warning')</script>");
                    return;
                }
                else
                {
                    flag = 1;
                    blu.CreateTransfer(Convert.ToDateTime(txtDate.Text), txtDescription.Text, chkTransfer.Checked ? 1 : 0, txtEmpId.Text, branchidTo, department, department1, 1, Convert.ToInt32(txtProjectid.Text), department, 1, txtCurDistrict.Text, district, Convert.ToInt32(txtCurDistrictid.Text), Convert.ToInt32(CmbnewDistrict.SelectedValue), designationname, txtDesignation.Text, designationid, Convert.ToInt32(txtDegid.Text), txtOldSalary.Text, txtNewSalary.Text, Contractfromdate, ContractTodate, flag);
                }
                 }
           
            
            int empid = Convert.ToInt32(txtEmpId.Text);
            DataTable dtP = blu.getPid(empid);
            int pid = Convert.ToInt32(dtP.Rows[0]["PID"].ToString());

            string fromdate;
            string todate;
            if (txtContractFrom.Text != "" || txtContractTo.Text!="")
            {
                fromdate = txtContractFrom.Text;
                string date = (txtDate.Text);
                DateTime d = Convert.ToDateTime(date);
                DateTime d1 = d.AddDays(-1);
                todate = d1.ToString();
            }
            else
            {
                fromdate = (DateTime.Now).ToString();
                todate = (DateTime.Now).ToString();
            }
            

            blu.insertceapworkHistory(pid, int.Parse(txtCurDistrictid.Text), txtCurDistrict.Text, int.Parse(txtProjectid.Text), txtcurrProject.Text, Convert.ToInt32(txtDegid.Text), txtDesignation.Text, fromdate, todate, txtOldSalary.Text, 0, admin, txtDescription.Text);
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Transfer saved Successfully').then((value) => { window.location ='Transfer.aspx'; });", true);
            }
        }
        int ProjectDistrictID = 0;
        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            int emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
           
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["emp_fullname"].ToString();
                txtcurrProject.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                txtCurDepartment.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                txtProjectid.Text = dt.Rows[0]["BRANCH_ID"].ToString();
                CmbDepartment.SelectedItem.Text = txtCurDepartment.Text;
                txtCurDistrictid.Text = dt.Rows[0]["ProjectDistrictID"].ToString();
                DateTime result = Convert.ToDateTime(dt.Rows[0]["EMP_JOINDATE"].ToString());
                txtStartDate.Text = result.ToString("yyyy-MM-dd");

                if(dt.Rows[0]["Type_fromDate"].ToString()!="")
                {
                    DateTime resultF = Convert.ToDateTime(dt.Rows[0]["Type_fromDate"].ToString());
                    txtContractFrom.Text = resultF.ToString("yyyy-MM-dd");

                    DateTime resultT = Convert.ToDateTime(dt.Rows[0]["Type_toDate"].ToString());
                    txtContractTo.Text = resultT.ToString("yyyy-MM-dd");
                }
                else
                {

                }
               

                txtOldSalary.Text = dt.Rows[0]["BSALARY"].ToString();

                txtDesignation.Text = dt.Rows[0]["DEG_NAME"].ToString();
                txtDegid.Text = dt.Rows[0]["DEG_ID"].ToString();

                DataTable dt3 = blu.GetDesignationInfo();
               // DataTable dt3 = blu.GetDesignationList(emp_id);
                if (dt3.Rows.Count > 0)
                {
                    CmbDesignation.DataSource = dt3;
                    CmbDesignation.DataTextField = "DEG_NAME";
                    CmbDesignation.DataValueField = "DEG_ID";
                    CmbDesignation.DataBind();
                    CmbDesignation.Items.Insert(0, "Select Designation");
                }

                if( blu.CheckEmptyEmployeetransfer(emp_id))
                {

                    DataTable dt1 = blu.GetTransferDetails(emp_id);
                    if (dt1.Rows.Count > 0)
                    {
                        txtCurDistrict.Text = dt1.Rows[0]["District_To"].ToString();
                        ProjectDistrictID = int.Parse(dt1.Rows[0]["District_ToID"].ToString());

                    }
                }
                else
                {
                    txtCurDistrict.Text = dt.Rows[0]["ProjectDistrict"].ToString();
                    ProjectDistrictID = int.Parse(dt.Rows[0]["ProjectDistrictID"].ToString());
                } 
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Available with that ID !!!','warning')", true);
                txtEmpId.Text = " ";
            }
          
        }

        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string branchname =(CmbBranch.SelectedItem).ToString();
            int branchid = Convert.ToInt32(CmbBranch.SelectedValue);
            txtnewbranchid.Text = branchid.ToString();

            DataTable dt = blu.GetProjectAssignView(branchid);
            CmbnewDistrict.DataSource = dt;
            CmbnewDistrict.DataTextField = "DistrictName";
            CmbnewDistrict.DataValueField = "DistrictId";
            CmbnewDistrict.DataBind();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transfer.aspx");
        }

        protected void CmbnewDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newdistrictid = Convert.ToInt32(CmbnewDistrict.SelectedValue);
            txtNewDistrictid.Text = newdistrictid.ToString();
        }

        protected void CmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newdegid = Convert.ToInt32(CmbDesignation.SelectedValue);
            txtnewdegid.Text = newdegid.ToString();
        }
        int flag;
        protected void chkContract_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContract.Checked)
            {
                flag = 1;
                txtNewContractFromNepali.Visible = true;
                txtNewContract.Visible = true;
                txtNewContractToNepali.Visible = true;
                txtNewContractTo.Visible = true;
                lblnewContractfrom.Visible = true;
                lblNewContractTo.Visible = true;

            }
            else
            {
                flag = 0;
                txtNewContractFromNepali.Visible = false;
                txtNewContract.Visible = false;
                txtNewContractToNepali.Visible = false;
                txtNewContractTo.Visible = false;
                lblnewContractfrom.Visible = false;
                lblNewContractTo.Visible = false;
            }
        }
    }
}