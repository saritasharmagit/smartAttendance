using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.HR_Mgmt
{
    public partial class AddPromotion : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadBranch();
                loadDesignation();


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
            CmbNewProject.DataSource = dt;
            CmbNewProject.DataTextField = "BRANCH_Name";
            CmbNewProject.DataValueField = "BRANCH_ID";
            CmbNewProject.DataBind();
            CmbNewProject.Items.Insert(0, "Select Project");
        }
        //public void loadBranch()
        //{
        //    DataTable dt = blu.GetProjectAssign();
        //    CmbNewProject.DataSource = dt;
        //    CmbNewProject.DataTextField = "ProjectName";
        //    CmbNewProject.DataValueField = "ProjectId";
        //    CmbNewProject.DataBind();
        //   // CmbNewProject.Items.Insert(0, "Select Project");
        //}
        public void loadDesignation()
        {
            DataTable dt = blu.GetDesignationInfo();
            CmbDesignation.DataSource = dt;
            CmbDesignation.DataTextField = "DEG_NAME";
            CmbDesignation.DataValueField = "DEG_ID";
            CmbDesignation.DataBind();
            CmbDesignation.Items.Insert(0, "Select Designation");
        }
        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            int emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
 
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["emp_fullname"].ToString();
                txtProject.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                txtProjectid.Text = dt.Rows[0]["BRANCH_ID"].ToString();
                txtDistrict.Text = dt.Rows[0]["ProjectDistrict"].ToString();
                txtDistrictid.Text = dt.Rows[0]["ProjectDistrictID"].ToString();
                txtOldSalary.Text = dt.Rows[0]["BSALARY"].ToString();

                DateTime result = Convert.ToDateTime(dt.Rows[0]["EMP_JOINDATE"].ToString());
                txtStartDate.Text = result.ToString("yyyy-MM-dd");

                if (dt.Rows[0]["Type_fromDate"].ToString() != "" || dt.Rows[0]["Type_toDate"].ToString() != "")
                {
                    DateTime resultF = Convert.ToDateTime(dt.Rows[0]["Type_fromDate"].ToString());
                    txtContractFrom.Text = resultF.ToString("yyyy-MM-dd");

                    DateTime resultT = Convert.ToDateTime(dt.Rows[0]["Type_toDate"].ToString());
                    txtContractTo.Text = resultT.ToString("yyyy-MM-dd");
                }
                else
                {

                }

                if (blu.CheckEmptyEmployeePromotion(emp_id))//if  employee has promoted -exists
                {

                    DataTable dt1 = blu.GetPromotionDetails(emp_id);
                    if (dt1.Rows.Count > 0)
                    {
                        txtDegid.Text = dt1.Rows[0]["DEG_ID"].ToString();
                        txtDesignation.Text = dt1.Rows[0]["DEG_NAME"].ToString();

                    }
                }
                   
                else
                {
                    txtDesignation.Text = dt.Rows[0]["DEG_NAME"].ToString();
                    txtDegid.Text = dt.Rows[0]["DEG_ID"].ToString();

                }
                DataTable dt3 = blu.GetDesignationList(emp_id);
                if (dt3.Rows.Count > 0)
                {
                    CmbDesignation.DataSource = dt3;
                    CmbDesignation.DataTextField = "DEG_NAME";
                    CmbDesignation.DataValueField = "DEG_ID";
                    CmbDesignation.DataBind();
                    CmbDesignation.Items.Insert(0, "Select Designation");
                }

            }


            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscript", "swal('Ooops!','No Employee Available with that ID !!!','warning')", true);
                txtEmpId.Text = " ";
            }
            int projectid = int.Parse(txtProjectid.Text);

            DataTable dt2 = blu.GetProjectAssignView(projectid);
            CmbnewDistrict.DataSource = dt2;
            CmbnewDistrict.DataTextField = "DistrictName";
            CmbnewDistrict.DataValueField = "DistrictId";
            CmbnewDistrict.DataBind();
        }
       
        int desgid;
        int department;
        int department1;
        string admin = "Admin";
      
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbDesignation.SelectedItem.Text == "Select Designation" || txtNewSalary.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Fill Required Field!','warning')</script>");
                return;
            }
            string designation = CmbDesignation.SelectedItem.Text;
            desgid =Convert.ToInt32(CmbDesignation.SelectedValue);
            if (txtDate.Text == "" || nepaliDate2.Text == "")
          {
              Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Select Date Format!','warning')</script>");
              return;
          }
            DateTime todayDate = DateTime.Now;
            DateTime promotion =Convert.ToDateTime(txtDate.Text);
            if (promotion > todayDate)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Format greater than today date!','warning')</script>");
                return;
            }
           
            else
            {
                int currentbranch = Convert.ToInt32(txtProjectid.Text);
                DataTable dt = blu.getDepartmentBranch(currentbranch);
                if (dt.Rows.Count > 0)
                {
                   department = Convert.ToInt32(dt.Rows[0]["DEPT_ID"].ToString());
                }
                DataTable dt1 = blu.getDepartmentInfo();
                if (dt1.Rows.Count > 0)
                {
                    department1 = Convert.ToInt32(dt1.Rows[0]["DEPT_ID"].ToString());
                }
                string projectname = (CmbNewProject.SelectedItem).ToString();
                int projectid = int.Parse(CmbNewProject.SelectedValue);

                string newdistrict=(CmbnewDistrict.SelectedItem.Text);
                int newdistrictid = Convert.ToInt32(CmbnewDistrict.SelectedValue);
                txtnewDistrictid.Text = newdistrictid.ToString();

                string Contractfromdate=(txtNewContract.Text);
                string ContractTodate = (txtNewContractTo.Text);

                if (txtProject.Text == CmbNewProject.SelectedItem.Text && txtDistrict.Text==CmbnewDistrict.SelectedItem.Text)
                    {
                        if (!chkContract.Checked)
                        {
                            flag = 0;
                            blu.CreatePromotion(txtEmpId.Text, Convert.ToDateTime(txtDate.Text), txtDescription.Text, 1, desgid, 1, 1, Convert.ToInt32(txtDegid.Text), Convert.ToInt32(txtOldSalary.Text), Convert.ToInt32(txtNewSalary.Text), Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtDate.Text), Convert.ToInt32(txtProjectid.Text), projectid, Convert.ToInt32(txtDistrictid.Text), Convert.ToInt32(txtnewDistrictid.Text), txtProject.Text, projectname, txtDistrict.Text, newdistrict, Contractfromdate, ContractTodate, flag);
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
                                blu.CreatePromotion(txtEmpId.Text, Convert.ToDateTime(txtDate.Text), txtDescription.Text, 1, desgid, 1, 1, Convert.ToInt32(txtDegid.Text), Convert.ToInt32(txtOldSalary.Text), Convert.ToInt32(txtNewSalary.Text), Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtDate.Text), Convert.ToInt32(txtProjectid.Text), projectid, Convert.ToInt32(txtDistrictid.Text), Convert.ToInt32(txtnewDistrictid.Text), txtProject.Text, projectname, txtDistrict.Text, newdistrict, Contractfromdate, ContractTodate, flag);
                            }
                           
                        }

                    }
                else if (txtProject.Text == CmbNewProject.SelectedItem.Text && txtDistrict.Text != CmbnewDistrict.SelectedItem.Text)
                {
                    if (!chkContract.Checked)
                    {
                        flag = 0;
                        blu.CreateTransfer(Convert.ToDateTime(txtDate.Text), txtDescription.Text, chkPromotion.Checked ? 1 : 0, txtEmpId.Text, int.Parse(CmbNewProject.SelectedValue), department, department1, 1, Convert.ToInt32(txtProjectid.Text), department, 1, txtDistrict.Text, CmbnewDistrict.SelectedItem.ToString(), Convert.ToInt32(txtDistrictid.Text), Convert.ToInt32(CmbnewDistrict.SelectedValue), designation, txtDesignation.Text, Convert.ToInt32(txtnewdegid.Text), Convert.ToInt32(txtDegid.Text), txtOldSalary.Text, txtNewSalary.Text, Contractfromdate, ContractTodate,flag);
                        blu.CreatePromotion(txtEmpId.Text, Convert.ToDateTime(txtDate.Text), txtDescription.Text, 1, desgid, 1, 1, Convert.ToInt32(txtDegid.Text), Convert.ToInt32(txtOldSalary.Text), Convert.ToInt32(txtNewSalary.Text), Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtDate.Text), Convert.ToInt32(txtProjectid.Text), projectid, Convert.ToInt32(txtDistrictid.Text), newdistrictid, txtProject.Text, projectname, txtDistrict.Text, newdistrict, Contractfromdate, ContractTodate, flag);
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
                            blu.CreateTransfer(Convert.ToDateTime(txtDate.Text), txtDescription.Text, chkPromotion.Checked ? 1 : 0, txtEmpId.Text, int.Parse(CmbNewProject.SelectedValue), department, department1, 1, Convert.ToInt32(txtProjectid.Text), department, 1, txtDistrict.Text, CmbnewDistrict.SelectedItem.ToString(), Convert.ToInt32(txtDistrictid.Text), Convert.ToInt32(CmbnewDistrict.SelectedValue), designation, txtDesignation.Text, Convert.ToInt32(txtnewdegid.Text), Convert.ToInt32(txtDegid.Text), txtOldSalary.Text, txtNewSalary.Text, Contractfromdate, ContractTodate, flag);
                            blu.CreatePromotion(txtEmpId.Text, Convert.ToDateTime(txtDate.Text), txtDescription.Text, 1, desgid, 1, 1, Convert.ToInt32(txtDegid.Text), Convert.ToInt32(txtOldSalary.Text), Convert.ToInt32(txtNewSalary.Text), Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtDate.Text), Convert.ToInt32(txtProjectid.Text), projectid, Convert.ToInt32(txtDistrictid.Text), newdistrictid, txtProject.Text, projectname, txtDistrict.Text, newdistrict, Contractfromdate, ContractTodate, flag);
                        }    
                    }
                }

                else
                {
                    if (!chkContract.Checked)
                    {
                      
                        flag = 0;
                        blu.CreateTransfer(Convert.ToDateTime(txtDate.Text), txtDescription.Text, chkPromotion.Checked ? 1 : 0, txtEmpId.Text, int.Parse(CmbNewProject.SelectedValue), department, department1, 1, Convert.ToInt32(txtProjectid.Text), department, 1, txtDistrict.Text, CmbnewDistrict.SelectedItem.ToString(), Convert.ToInt32(txtDistrictid.Text), Convert.ToInt32(CmbnewDistrict.SelectedValue), designation, txtDesignation.Text, Convert.ToInt32(txtnewdegid.Text), Convert.ToInt32(txtDegid.Text), txtOldSalary.Text, txtNewSalary.Text, Contractfromdate, ContractTodate, flag);
                        blu.CreatePromotion(txtEmpId.Text, Convert.ToDateTime(txtDate.Text), txtDescription.Text, 1, desgid, 1, 1, Convert.ToInt32(txtDegid.Text), Convert.ToInt32(txtOldSalary.Text), Convert.ToInt32(txtNewSalary.Text), Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtDate.Text), Convert.ToInt32(txtProjectid.Text), projectid, Convert.ToInt32(txtDistrictid.Text), newdistrictid, txtProject.Text, projectname, txtDistrict.Text, newdistrict, Contractfromdate, ContractTodate, flag);
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
                            blu.CreateTransfer(Convert.ToDateTime(txtDate.Text), txtDescription.Text, chkPromotion.Checked ? 1 : 0, txtEmpId.Text, int.Parse(CmbNewProject.SelectedValue), department, department1, 1, Convert.ToInt32(txtProjectid.Text), department, 1, txtDistrict.Text, CmbnewDistrict.SelectedItem.ToString(), Convert.ToInt32(txtDistrictid.Text), Convert.ToInt32(CmbnewDistrict.SelectedValue), designation, txtDesignation.Text, Convert.ToInt32(txtnewdegid.Text), Convert.ToInt32(txtDegid.Text), txtOldSalary.Text, txtNewSalary.Text, Contractfromdate, ContractTodate, flag);
                            blu.CreatePromotion(txtEmpId.Text, Convert.ToDateTime(txtDate.Text), txtDescription.Text, 1, desgid, 1, 1, Convert.ToInt32(txtDegid.Text), Convert.ToInt32(txtOldSalary.Text), Convert.ToInt32(txtNewSalary.Text), Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtDate.Text), Convert.ToInt32(txtProjectid.Text), projectid, Convert.ToInt32(txtDistrictid.Text), newdistrictid, txtProject.Text, projectname, txtDistrict.Text, newdistrict, Contractfromdate, ContractTodate, flag);
                        }
                       
                    }
                    
                }
                int empid = Convert.ToInt32(txtEmpId.Text);
                DataTable dtP = blu.getPid(empid);
                int pid = Convert.ToInt32(dtP.Rows[0]["PID"].ToString());

                string fromdate = txtContractFrom.Text;
               // string todate = txtContractTo.Text;
                string date = (txtDate.Text);
                DateTime d = Convert.ToDateTime(date);
                DateTime d1 = d.AddDays(-1);
                string todate = d1.ToString();
                blu.insertceapworkHistory(pid, int.Parse(txtDistrictid.Text), txtDistrict.Text, int.Parse(txtProjectid.Text), txtProject.Text, int.Parse(txtDegid.Text), txtDesignation.Text, fromdate, todate, txtOldSalary.Text, 0, admin, txtDescription.Text);
            }
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Promotion saved Successfully').then((value) => { window.location ='Promotion.aspx'; });", true);
            }
        }

        protected void CmbNewProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string projectname = (CmbNewProject.SelectedItem).ToString();
            int projectid = int.Parse(CmbNewProject.SelectedValue);

           DataTable dt = blu.GetProjectAssignView(projectid);
           CmbnewDistrict.DataSource = dt;
           CmbnewDistrict.DataTextField = "DistrictName";
           CmbnewDistrict.DataValueField = "DistrictId";
           CmbnewDistrict.DataBind();
        }

        protected void CmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newdegid = Convert.ToInt32(CmbDesignation.SelectedValue);
            txtnewdegid.Text = newdegid.ToString();
        }

        protected void CmbnewDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newdistrictid = Convert.ToInt32(CmbnewDistrict.SelectedValue);
            txtnewDistrictid.Text = newdistrictid.ToString();
        }
        int flag;
        protected void chkContract_CheckedChanged(object sender, EventArgs e)
        {
               if(chkContract.Checked)
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