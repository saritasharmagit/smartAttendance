using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Globalization;

namespace AttendanceKantipur.Admin.HR_Mgmt
{
    public partial class AddEmployees : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
                loadBranch();
                loadDesignation();
                loadStatus();
                loadGrade();
                loadUsertype();
                loadState();
                loadState1();
                loadBloodgroup();
                loadHOD();
                loadDistrict();
                loadEthnicity();
                loadDepartment();
                loadBank();
                loadReligion();
                loadType();

                DataTable dt = blu.getLeaveInfo();
                GVLeave.DataSource = dt;
                GVLeave.DataBind();

                txtAlrg.Visible = false;
                txtFrom.Visible = false;
                txtTo.Visible = false;
                CmbBank.Visible = false;
                txtAccno.Visible = false;
                lblBank.Visible = false;
                lblAccount.Visible = false;

                lblPrmAmt.Visible = false;
                txtAmount.Visible = false;

                DataTable dt1 = new DataTable();//for education
                DataRow dr = null;
                dt1.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dt1.Columns.Add(new DataColumn("Col1", typeof(string)));
                dt1.Columns.Add(new DataColumn("Col2", typeof(string)));
                dt1.Columns.Add(new DataColumn("Col3", typeof(string)));
                dt1.Columns.Add(new DataColumn("Col4", typeof(string)));
                dt1.Columns.Add(new DataColumn("Col5", typeof(string)));
                dt1.Columns.Add(new DataColumn("Col6", typeof(string)));
                dt1.Columns.Add(new DataColumn("Col7", typeof(byte[])));
                dr = dt1.NewRow();

                dr["RowNumber"] = 1;
                dr["Col1"] = string.Empty;
                dr["Col2"] = string.Empty;
                dr["Col3"] = string.Empty;
                dr["Col4"] = string.Empty;
                dr["Col5"] = string.Empty;
                dr["Col6"] = string.Empty;
                dr["Col7"] = null;
                dt1.Rows.Add(dr);

                ViewState["CurrentTable"] = dt1;
                grvStudentDetails.DataSource = dt1;
                grvStudentDetails.DataBind();

                DataTable dt2 = new DataTable();//for training
                DataRow dr1 = null;
                dt2.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dt2.Columns.Add(new DataColumn("Col1", typeof(string)));
                dt2.Columns.Add(new DataColumn("Col2", typeof(string)));
                dt2.Columns.Add(new DataColumn("Col3", typeof(string)));
                dt2.Columns.Add(new DataColumn("Col4", typeof(string)));
                dt2.Columns.Add(new DataColumn("Col5", typeof(string)));
                dt2.Columns.Add(new DataColumn("Col6", typeof(string)));

                dt2.Columns.Add(new DataColumn("Col7", typeof(string)));
                dt2.Columns.Add(new DataColumn("Col8", typeof(byte[])));

                dr1 = dt2.NewRow();
                dr1["RowNumber"] = 1;
                dr1["Col1"] = string.Empty;
                dr1["Col2"] = string.Empty;
                dr1["Col3"] = string.Empty;
                dr1["Col4"] = string.Empty;
                dr1["Col5"] = string.Empty;
                dr1["Col6"] = string.Empty;

                dr1["Col7"] = string.Empty;
                dr1["Col8"] = null;

                dt2.Rows.Add(dr1);

                ViewState["CurrentTable1"] = dt2;
                GridView1.DataSource = dt2;
                GridView1.DataBind();

                DataTable dt3 = new DataTable();//for past work history 
                DataRow dr2 = null;
                dt3.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dt3.Columns.Add(new DataColumn("Colmn1", typeof(string)));
                dt3.Columns.Add(new DataColumn("Colmn2", typeof(string)));
                dt3.Columns.Add(new DataColumn("Colmn3", typeof(string)));
                dt3.Columns.Add(new DataColumn("Colmn4", typeof(string)));
                dt3.Columns.Add(new DataColumn("Colmn5", typeof(string)));
                dt3.Columns.Add(new DataColumn("Colmn6", typeof(string)));

                dt3.Columns.Add(new DataColumn("Colmn7", typeof(string)));
                dt3.Columns.Add(new DataColumn("Colmn8", typeof(byte[])));

                dr2 = dt3.NewRow();
                dr2["RowNumber"] = 1;
                dr2["Colmn1"] = string.Empty;
                dr2["Colmn2"] = string.Empty;
                dr2["Colmn3"] = string.Empty;
                dr2["Colmn4"] = string.Empty;
                dr2["Colmn5"] = string.Empty;
                dr2["Colmn6"] = string.Empty;

                dr2["Colmn7"] = string.Empty;
                dr2["Colmn8"] = null;

                dt3.Rows.Add(dr2);


                ViewState["CurrentTable2"] = dt3;
                GridView2.DataSource = dt3;
                GridView2.DataBind();


                DataTable dt4 = new DataTable();//for ceapred history
                DataRow dr3 = null;
                dt4.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dt4.Columns.Add(new DataColumn("Colmn1", typeof(string)));
                dt4.Columns.Add(new DataColumn("Colmn2", typeof(string)));
                dt4.Columns.Add(new DataColumn("Colmn3", typeof(string)));
                dt4.Columns.Add(new DataColumn("Colmn4", typeof(string)));
                dt4.Columns.Add(new DataColumn("Colmn5", typeof(string)));
                dt4.Columns.Add(new DataColumn("Colmn6", typeof(string)));
                dt4.Columns.Add(new DataColumn("Colmn7", typeof(string)));
                dt4.Columns.Add(new DataColumn("Colmn8", typeof(string)));


                dr3 = dt4.NewRow();
                dr3["RowNumber"] = 1;
                dr3["Colmn1"] = string.Empty;
                dr3["Colmn2"] = string.Empty;
                dr3["Colmn3"] = string.Empty;
                dr3["Colmn4"] = string.Empty;
                dr3["Colmn5"] = string.Empty;
                dr3["Colmn6"] = string.Empty;
                dr3["Colmn7"] = string.Empty;
                dr3["Colmn8"] = string.Empty;

                dt4.Rows.Add(dr3);


                ViewState["CurrentTable3"] = dt4;
                grvceapHistory.DataSource = dt4;
                grvceapHistory.DataBind();

                grvceapHistory.Enabled = false;

                txtstadate.Visible = false;
                txtstaToDate.Visible = false;

                lblremarks.Visible = false;
                txtremarks.Visible = false;

               
                
            }
        }
        
        public void loadReligion()
        {
            DataTable dt = blu.getReligion();
            CmbReligion.DataSource = dt;
            CmbReligion.DataTextField = "Religion_Name";
            CmbReligion.DataValueField = "Religion_Id";
            CmbReligion.DataBind();
            // CmbReligion.Items.Insert(0, "Select Religion");
        }
        public void loadType()
        {
            DataTable dt = blu.getType();
            CmbType.DataSource = dt;
            CmbType.DataTextField = "EmployeeType_Name";
            CmbType.DataValueField = "EmployeeType_Id";
            CmbType.DataBind();
            CmbType.Items.Insert(0, "Select Type");
        }
        public void loadBranch()
        {
            DataTable dt = blu.getBranch();
            CmbBranch.DataSource = dt;
            CmbBranch.DataTextField = "BRANCH_Name";
            CmbBranch.DataValueField = "BRANCH_ID";
            CmbBranch.DataBind();
            CmbBranch.Items.Insert(0, "Select Project");
            CmbBranch.Items[0].Attributes.Add("disabled", "disabled");
        }

        public void loadEthnicity()
        {
            DataTable dt = blu.getEthnicityList();
            CmbEthnicity.DataSource = dt;
            CmbEthnicity.DataTextField = "Ethnicity_Name";
            CmbEthnicity.DataValueField = "Ethnicity_Id";
            CmbEthnicity.DataBind();
            CmbEthnicity.Items.Insert(0, "Select Ethnicity");

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
        public void loadDesignation()
        {
            DataTable dt = blu.getDesignation();
            CmbDesignation.DataSource = dt;
            CmbDesignation.DataTextField = "DEG_NAME";
            CmbDesignation.DataValueField = "DEG_ID";
            CmbDesignation.DataBind();
            CmbDesignation.Items.Insert(0, "Select Designation");
        }

        public void loadStatus()
        {
            DataTable dt = blu.Getstatus();
            CmbStatus.DataSource = dt;
            CmbStatus.DataTextField = "STATUS_NAME";
            CmbStatus.DataValueField = "STATUS_ID";
            CmbStatus.DataBind();
            CmbStatus.SelectedValue = "1";
        }
        public void loadBank()
        {
            DataTable dt = blu.GetBank();
            CmbBank.DataSource = dt;
            CmbBank.DataTextField = "BANK_NAME";
            CmbBank.DataValueField = "BANK_ID";
            CmbBank.DataBind();
            CmbBank.Items.Insert(0, "Select Bank");
        }
        public void loadUsertype()
        {
            DataTable dt = blu.GetUserType();
            CmbUsertype.DataSource = dt;
            CmbUsertype.DataTextField = "TypeName";
            CmbUsertype.DataValueField = "id";
            CmbUsertype.DataBind();
            CmbUsertype.Items.Insert(0, "Select");
        }
        public void loadGrade()
        {
            DataTable dt = blu.getGradeList();
            CmbGrade.DataSource = dt;
            CmbGrade.DataTextField = "GRADE_NAME";
            CmbGrade.DataValueField = "GRADE_ID";
            CmbGrade.DataBind();
            CmbGrade.Items.Insert(0, "Select Grade");
        }
        public void loadDistrict()
        {
            DataTable dt = blu.getDistrictList();
            CmbIssueDistrict.DataSource = dt;
            CmbIssueDistrict.DataTextField = "DistrictName";
            CmbIssueDistrict.DataValueField = "DistrictId";
            CmbIssueDistrict.DataBind();
            CmbIssueDistrict.Items.Insert(0, "Select District");
        }

        public void loadState()
        {
            DataTable dt = blu.getStateList();
            CmbTState.DataSource = dt;
            CmbTState.DataTextField = "StateName";
            CmbTState.DataValueField = "StateId";
            CmbTState.DataBind();
            CmbTState.Items.Insert(0, "Select Province");
        }
        public void loadState1()
        {
            DataTable dt = blu.getStateList();
            CmbPState.DataSource = dt;
            CmbPState.DataTextField = "StateName";
            CmbPState.DataValueField = "StateId";
            CmbPState.DataBind();
            CmbPState.Items.Insert(0, "Select Province");

        }
        public void loadBloodgroup()
        {
            DataTable dt = blu.getBloodgroup();
            CmbBlood.DataSource = dt;
            CmbBlood.DataTextField = "Blood_Type";
            CmbBlood.DataValueField = "Blood_Id";
            CmbBlood.DataBind();
        }
        public void loadHOD()
        {
            //DataTable dt = blu.getHODList();
            //CmbHOD.DataSource = dt;
            //CmbHOD.DataTextField = "emp_fullname";
            //CmbHOD.DataValueField = "emp_id";
            //CmbHOD.DataBind();
            //CmbHOD.Items.Insert(0, "No HOD");
        }
      
        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserid.Text = txtEmployeeId.Text;

            int BranchID = Convert.ToInt32(CmbBranch.SelectedValue);

            DataTable dtd = blu.getdistrictfromproject(BranchID);
            if (dtd.Rows.Count > 0)
            {
                CmbProjectDistrict.DataSource = dtd;
                CmbProjectDistrict.DataTextField = "DistrictName";
                CmbProjectDistrict.DataValueField = "DistrictId";
                CmbProjectDistrict.DataBind();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','No project district Available with this Project!','warning')</script>");
            }

            DataTable dt = blu.getDepartment();
            DataTable dt2 = blu.getValidDate(BranchID);
            if (dt2.Rows[0]["ValidFrom"].ToString() == "")
            {

            }
            else
            {
                DateTime result = Convert.ToDateTime(dt2.Rows[0]["ValidFrom"].ToString());
                txtValidFrom.Text = result.ToString("yyyy-MM-dd");
                DateTime result1 = Convert.ToDateTime(dt2.Rows[0]["ValidTo"].ToString());
                txtValidTo.Text = result1.ToString("yyyy-MM-dd");
            }
            if (dt.Rows.Count > 0)
            {
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");

            }

            else
            {
                CmbDepartment.Items.Clear();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','No department Available!','warning')</script>");
            }
        }

        string filePathimage;
        string filePathRelation;
        string filePathSignature;
       
        string Son = "";
        string Daughter = "";
        string working = "";
        string Resign_Date = "";
        string StatusDate = "";
        string StatusDateTo = "";
        string Permanent = "";
        string TypeDateFrom = "";
        string TypeDateTo = "";
        DateTime Probation = DateTime.Now;
        DateTime Probation1 = DateTime.Now;
        DateTime Temporary = DateTime.Now;
        DateTime Trainee = DateTime.Now;
        DateTime Trainee1 = DateTime.Now;
        DateTime Contract = DateTime.Now;
        DateTime Contract1 = DateTime.Now;
        DateTime Casual = DateTime.Now;
        int modeid = 0;
        string roomno = "";
        string extno = "";
        string cardno = "";
        string vehicleno = "";
        string licenceno = "";
        int bankid = 0;
        int BankbranchId = 0;
        string bankAC = "";
        string probationMFrom = ""; string probationMTo = ""; string bloodgrp = "";
        int checkWebLogin = 0;
        int isOT = 0;
        int isAttendance = 0;
        int Pid;
        string pid = "";
        int bloodgroupid;
        int Tstateid;
        int TDistrictid;
        string fileno = "";
        string Laid_off = "";
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Oops!','Enter Employee Id!','warning')</script>");
                txtEmployeeId.Focus();
                return;
            }
            else
            {
                if (blu.CheckDuplicateEmpId(txtEmployeeId.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Already exists EmployeeId!','warning')</script>");
                    return;
                }
                if (EMP_TITLE.SelectedItem.Text == "Select")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "alertscipt", "swal('Oops!','Please Select  Salutation!!!','warning')", true);
                    return;
                }
                if (EMP_FIRSTNAME.Text == "" || EMP_LASTNAME.Text == "")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "alertscipt", "swal('Oops!','Please Fill Full Name!!!','warning')", true);
                    return;
                }
                if (txtStartDate.Text == "" || txtJoindate.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Oops!',' Please Date Field Select!','warning')</script>");
                    return;
                }

                if (EMP_MOBILE.Text == "")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "alertscipt", "swal('Oops!','Please Fill Mobile Number!!!','warning')", true);
                    return;
                }
                if (CmbEthnicity.SelectedItem.Text == "Select Ethnicity")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "alertscipt", "swal('Oops!','Please Select Ethnicity!!!','warning')", true);
                    return;
                }
                if (CmbIssueDistrict.SelectedItem.Text == "Select District")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "alertscipt", "swal('Oops!','Please Select Citizenship Issue District!!!','warning')", true);
                    return;
                }

                if (CmbPState.SelectedItem.Text == "Select Province")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "alertscipt", "swal('Oops!','Please Fill required Permanent address !!!','warning')", true);
                    return;
                }
                if (CmbBranch.SelectedItem.Text == "Select Project")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','Please Select required Project in Official Information !!!','warning')", true);
                    return;
                }
                if (CmbProjectDistrict.SelectedItem.Text == "Select ProjectDistrict")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','Please Select required ProjectDistrict in Official Information !!!','warning')", true);
                    return;
                }
                if (CmbDepartment.SelectedItem.Text == "Select Department")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','Please Select required Department in Official Information !!!','warning')", true);
                    return;
                }
                if (CmbUsertype.SelectedItem.Text == "Select")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','Please Select required UserType in Official Information !!!','warning')", true);
                    return;
                }
                if (CmbDesignation.SelectedItem.Text == "Select Designation")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','Please Select required Designation in Official Information !!!','warning')", true);
                    return;
                }
                if (txtSalary.Text == "")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','Please Fill required Basic Salary in Official Information !!!','warning')", true);
                    return;
                }
                if (CmbGrade.SelectedItem.Text == "Select Grade")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','Please Select required Grade in Official Information !!!','warning')", true);
                    return;
                }
                if (CmbType.SelectedItem.Text == "Select Type")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','Please Select required Type in Official Information !!!','warning')", true);
                    return;
                }
                if (CmbType.SelectedItem.Text == "Permanent")
                {
                    if (txtFrom.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','PLz Fill Permanent Date format in type !!!','warning')", true);
                        return;
                    }

                }
                if (CmbType.SelectedItem.Text == "Contract")
                {
                    if (txtFrom.Text == "" || txtTo.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','PLz Fill Contract Date format in type !!!','warning')", true);
                        return;
                    }
                }
                if (CmbType.SelectedItem.Text == "Trainee")
                {
                    if (txtFrom.Text == "" || txtTo.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','PLz Fill Trainee Date format in type !!!','warning')", true);
                        return;
                    }

                }
                if (CmbType.SelectedItem.Text == "Probation")
                {
                    if (txtFrom.Text == "" || txtTo.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','PLz Fill Probation Date format in type !!!','warning')", true);
                        return;
                    }
                }
                if (CmbStatus.SelectedItem.Text == "Retired")
                {
                    if (txtstadate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','PLz Fill Retired Date format in Status !!!','warning')", true);
                        return;
                    }
                }
                if (CmbStatus.SelectedItem.Text == "Suspension")
                {
                    if (txtstadate.Text == "" || txtstaToDate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','PLz Fill Suspension Date format in Status !!!','warning')", true);
                        return;
                    }
                }
                if (CmbStatus.SelectedItem.Text == "Termination")
                {
                    if (txtstadate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','PLz Fill Termination Date format in Status !!!','warning')", true);
                        return;
                    }
                }
                if (CmbStatus.SelectedItem.Text == "Dismissed")
                {
                    if (txtstadate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','PLz Fill Dismissed Date format in Status !!!','warning')", true);
                        return;
                    }
                }
                if (CmbStatus.SelectedItem.Text == "Resigned")
                {
                    if (txtstadate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','PLz Fill Resigned Date format in Status !!!','warning')", true);
                        return;
                    }
                }
                if (CmbStatus.SelectedItem.Text == "Laid_off")
                {
                    if (txtstadate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','PLz Fill Laid off Date format in Status !!!','warning')", true);
                        return;
                    }
                }

                DateTime cardExpirydate = DateTime.Now;
                DateTime licenceexpirydate = DateTime.Now;

                DateTime suspensionFrom = DateTime.Now;
                DateTime suspensionTo = DateTime.Now;
                DateTime dischargeDate = DateTime.Now;
                DateTime dissmissDate = DateTime.Now;

                int degid = Convert.ToInt32(CmbDesignation.SelectedValue);
                int ethnicityid = Convert.ToInt32(CmbEthnicity.SelectedValue);
                int branchid = Convert.ToInt32(CmbBranch.SelectedValue);
                int deptid = Convert.ToInt32(CmbDepartment.SelectedValue);
                int statid = Convert.ToInt32(CmbStatus.SelectedValue);
                string status = CmbStatus.SelectedItem.Text;

                if (CmbStatus.SelectedIndex == 0)
                {
                    StatusDate = txtstadate.Text;
                    StatusDateTo = "";

                }
                else if (CmbStatus.SelectedIndex == 1)
                {
                    working = "";

                }
                else if (CmbStatus.SelectedIndex == 2)
                {
                    StatusDate = txtstadate.Text;
                    StatusDateTo = txtstaToDate.Text;

                }
                else if (CmbStatus.SelectedIndex == 3)
                {
                    StatusDate = txtstadate.Text;
                    StatusDateTo = "";

                }
                else if (CmbStatus.SelectedIndex == 4)
                {
                    StatusDate = txtstadate.Text;
                    StatusDateTo = "";

                }
                else if (CmbStatus.SelectedIndex == 5)
                {
                    StatusDate = txtstadate.Text;
                    StatusDateTo = "";

                }
                else if (CmbStatus.SelectedIndex == 6)
                {
                    StatusDate = txtstadate.Text;
                    StatusDateTo = "";

                }

                int gradeid = Convert.ToInt32(CmbGrade.SelectedValue);
                string citnum = cit_number.Text;
                string epan = epan_number.Text;
                string pfnum = pf_number.Text;

               
                if (rbBank.Checked)
                {
                   // bankid = 1;
                    bankid = Convert.ToInt32(CmbBank.SelectedValue);
                    bankAC = txtAccno.Text;
                }
                else
                {
                    bankid = 0;
                    BankbranchId = 0;
                    bankAC = "";
                }
                string TDistrict = "";
                string TState = "";
                string PDistrict = (CmbPDistrict.SelectedItem).ToString();
                string PState = (CmbPState.SelectedItem).ToString();
                if (CmbTState.SelectedItem.Text == "Select Province")
                {
                    TDistrict = "";
                    TState = "";
                }
                else
                {
                    TDistrict = (CmbTDistrict.SelectedItem).ToString();
                    TState = (CmbTState.SelectedItem).ToString();

                }

                if ((CmbBlood.SelectedItem).ToString() == "Select Group")
                {
                    bloodgrp = "";
                }
                else
                {
                    bloodgrp = (CmbBlood.SelectedItem).ToString();
                }
                string Religion;
                int Religionid;
                if (CmbReligion.SelectedItem.Text == "Select")
                {
                    Religion = "";
                }
                else
                {
                    Religion = (CmbReligion.SelectedItem).ToString();
                }
                if (CmbReligion.SelectedValue == "Select Religion")
                {
                    Religionid = 0;
                }
                else
                {
                    Religionid = Convert.ToInt32(CmbReligion.SelectedValue);
                }
                string Ethnicity = (CmbEthnicity.SelectedItem).ToString();
              
                string issueDistrict = (CmbIssueDistrict.SelectedItem).ToString();
                int issuedistrictid = Convert.ToInt32(CmbIssueDistrict.SelectedValue);

                int Pstateid = Convert.ToInt32(CmbPState.SelectedValue);
                int PDistrictid = Convert.ToInt32(CmbPDistrict.SelectedValue);
                if (chkCopy.Checked)
                {
                    Tstateid = Pstateid;
                    TDistrictid = PDistrictid;
                }
                else
                {
                    if (CmbTState.SelectedItem.Text == "Select Province" || CmbTState.SelectedItem.Text=="")
                    {
                        Tstateid = 0;
                        TDistrictid = 0;
                    }
                    else
                    {
                        Tstateid = Convert.ToInt32(CmbTState.SelectedValue);
                        TDistrictid = Convert.ToInt32(CmbTDistrict.SelectedValue);
                    }
                    }


                    if (CmbBlood.SelectedItem.Text == "Select Group")
                    {
                        bloodgroupid = 0;
                    }
                    else
                    {
                        bloodgroupid = Convert.ToInt32(CmbBlood.SelectedValue);
                    }
                    string spouse = txtSpouse.Text;

                    string fathername = txtFather.Text;
                    string mothername = txtMother.Text;
                    string grandname = txtGrand.Text;

                    if (chkTime.Checked)//for overtime
                    {
                        isOT = 1;
                    }
                    else
                    {
                        isOT = 0;
                    }
                    if (chkAttn.Checked)
                    {
                        isAttendance = 1;
                    }
                    else
                    {
                        isAttendance = 0;
                    }
                    string title = (EMP_TITLE.SelectedItem).ToString();
                   
                    string padd = "";
                    string pcountry = "Nepal";
                    string gender = "";
                    if (Gender1.Checked)
                    {
                        gender = "F";
                    }
                    else
                    {
                        gender = "M";
                    }
                    string Mstatus = "";
                    if (Relationship1.Checked)
                    {
                        Mstatus = "S";
                    }
                    else if (Relationship2.Checked)
                    {
                        Mstatus = "M";
                    }
                    else if (Relationship3.Checked)
                    {
                        Mstatus = "D";
                    }
                    else
                    {
                        Mstatus = "Sep";
                    }

                    int typeid = Convert.ToInt32(CmbType.SelectedValue);
                    if (typeid == 1)
                    {
                        TypeDateFrom = txtFrom.Text;
                        TypeDateTo = "";
                        Permanent = txtFrom.Text;
                    }
                    else if (typeid == 2)
                    {
                        TypeDateFrom = "";
                        TypeDateTo = "";
                    }
                    else if (typeid == 3)
                    {
                        TypeDateFrom = txtFrom.Text;
                        TypeDateTo = txtTo.Text;
                    }
                    else if (typeid == 4)
                    {
                        TypeDateFrom = txtFrom.Text;
                        TypeDateTo = txtTo.Text;
                    }
                    else if (typeid == 5)
                    {
                        TypeDateFrom = txtFrom.Text;
                        TypeDateTo = txtTo.Text;
                    }
                    else if (CmbType.SelectedIndex == 6)
                    {
                        TypeDateFrom = txtFrom.Text;
                        TypeDateTo = txtTo.Text;
                    }
                   
                    if (FileUpload1.HasFile)
                    {
                        string fileName = FileUpload1.FileName;
                        filePathimage = Server.MapPath("../../images/" + System.Guid.NewGuid() + fileName);
                        FileUpload1.SaveAs(filePathimage);

                        FileStream fs = new FileStream(filePathimage, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                        br.Close();
                        fs.Close();
                    }
                    else
                    {
                        lblerrorRep.Visible = true;
                        lblerrorRep.Text = "Couldn't upload the file! Please try latter.";
                        filePathimage = "";
                    }

                    if (FileUpload2.HasFile)
                    {
                        string fileName = FileUpload2.FileName;
                        filePathRelation = Server.MapPath("../../images/" + System.Guid.NewGuid() + fileName);
                        FileUpload2.SaveAs(filePathRelation);

                        FileStream fs = new FileStream(filePathRelation, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                        br.Close();
                        fs.Close();
                    }

                    else
                    {
                        lblerrorRep.Visible = true;
                        lblerrorRep.Text = "Couldn't upload the file! Please try latter.";
                        filePathRelation = "";
                    }
                    if (FileuploadSig.HasFile)
                    {
                        string fileName = FileuploadSig.FileName;
                        filePathSignature = Server.MapPath("../../images/" + System.Guid.NewGuid() + fileName);
                        FileuploadSig.SaveAs(filePathSignature);

                        FileStream fs = new FileStream(filePathSignature, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                        br.Close();
                        fs.Close();
                    }

                    else
                    {
                        lbldig.Visible = true;
                        lbldig.Text = "Couldn't upload the file! Please try latter.";
                        filePathSignature = "";
                    }

                    DataTable dt = blu.getMaxPid();//for maxmium pid
                    if (dt.Rows[0]["Column1"].ToString() == "")
                    {
                        blu.CreateOfcInfo(Convert.ToDateTime(txtJoindate.Text), txtEmployeeId.Text, pid);

                    }
                    else
                    {
                        txtpid.Text = dt.Rows[0]["Column1"].ToString();
                        pid = (txtpid.Text);
                        Pid = Convert.ToInt32(pid);
                        blu.CreateOfcInfo(Convert.ToDateTime(txtJoindate.Text), txtEmployeeId.Text, pid);
                    }

                  

                    foreach (GridViewRow row in grvStudentDetails.Rows)//for education save
                    {
                        string clgname = (row.Cells[1].FindControl("txtName") as TextBox).Text;
                        string degree = (row.Cells[2].FindControl("txtDegree") as TextBox).Text;
                        string majorSubject = (row.Cells[3].FindControl("txtMajor") as TextBox).Text;
                        string percent = (row.Cells[4].FindControl("txtPercentage") as TextBox).Text;
                        string edudate = ((row.Cells[6].FindControl("txtEnd") as TextBox).Text);

                        string fileName = (row.FindControl("TextBox3") as TextBox).Text;//for image name
                        string base64String = (row.FindControl("hfFileByte") as HiddenField).Value;
                        byte[] bytes = Convert.FromBase64String(base64String);

                        string filePath = Server.MapPath("../../images/" + System.Guid.NewGuid() + fileName);


                        String EXT = System.IO.Path.GetExtension(filePath);//get file extension
                      
                            if (!string.IsNullOrEmpty(fileName) && bytes != null)
                            {
                                File.WriteAllBytes(filePath, bytes);
                                blu.insertedu(Pid, clgname, degree, percent, percent, edudate, majorSubject, fileName, filePath, EXT);
                            }
                            else
                            {

                                fileName = "";
                                filePath = "";
                                blu.insertedu(Pid, clgname, degree, percent, percent, edudate, majorSubject, fileName, filePath, EXT);
                            }
                     
                    }
                    foreach (GridViewRow row in GridView1.Rows)//for Training save
                    {
                        string Title = (row.Cells[1].FindControl("txtTitle") as TextBox).Text;
                        string organization = (row.Cells[2].FindControl("txtOrganize") as TextBox).Text;
                        string place = ((row.Cells[3].FindControl("txtPlace") as TextBox).Text);
                        string days = ((row.Cells[4].FindControl("txtDays") as TextBox).Text);
                        string enddate = ((row.Cells[5].FindControl("txtEnd") as TextBox).Text);
                        string startdate = ((row.Cells[6].FindControl("txtStart") as TextBox).Text);

                        string fileNameT = (row.FindControl("txtFilename") as TextBox).Text;//for image name

                        string base64String = (row.FindControl("TFileByte") as HiddenField).Value;
                        byte[] Trbytes = Convert.FromBase64String(base64String);
                        string filePathT = Server.MapPath("../../images/" + System.Guid.NewGuid() + fileNameT);

                        String EXT = System.IO.Path.GetExtension(filePathT);//get file extension

                        if (!string.IsNullOrEmpty(fileNameT) && Trbytes != null)
                        {
                            File.WriteAllBytes(filePathT, Trbytes);
                            blu.insertTraining(Pid, organization, place, startdate, enddate, Title, days, fileNameT, filePathT, EXT);
                        }
                        else
                        {
                          
                            fileNameT = "";
                            filePathT = "";
                            blu.insertTraining(Pid, organization, place, startdate, enddate, Title, days, fileNameT, filePathT, EXT);
                        }


                    }
                    foreach (GridViewRow row in GridView2.Rows)//for past workhistory save
                    {
                        string organization = (row.Cells[1].FindControl("txtOrganization") as TextBox).Text;
                        string designation = (row.Cells[2].FindControl("txtDesignation") as TextBox).Text;
                        string enddate = ((row.Cells[3].FindControl("txtEnd") as TextBox).Text);
                        string startdate = ((row.Cells[4].FindControl("txtStart") as TextBox).Text);
                        string Salary = ((row.Cells[5].FindControl("txtSalary") as TextBox).Text);
                        string Contact = ((row.Cells[6].FindControl("txtContact") as TextBox).Text);

                        string fileNamew = (row.FindControl("Filename") as TextBox).Text;//for image name

                        string base64String = (row.FindControl("PWFileByte") as HiddenField).Value;
                        byte[] PWbytes = Convert.FromBase64String(base64String);
                        string filePathPW = Server.MapPath("../../images/" + System.Guid.NewGuid() + fileNamew);

                        String EXT = System.IO.Path.GetExtension(filePathPW);//get file extension

                        if (!string.IsNullOrEmpty(fileNamew) && PWbytes != null)
                        {
                            File.WriteAllBytes(filePathPW, PWbytes);
                            blu.insertJobExperience(Pid, organization, designation, startdate, enddate, Salary, Contact, fileNamew, filePathPW, EXT);
                        }
                        else
                        {
                           
                            fileNamew = "";
                            filePathPW = "";
                            blu.insertJobExperience(Pid, organization, designation, startdate, enddate, Salary, Contact, fileNamew, filePathPW, EXT);
                        }

                    }

                    if (chkHistory.Checked)//for ceapred workhistory save
                    {
                        foreach (GridViewRow row in grvceapHistory.Rows)
                        {
                            string projectdistrict = (row.Cells[2].FindControl("CmbProjectDistrict") as DropDownList).SelectedItem.Text;
                            int projectdistrictid = Convert.ToInt32((row.Cells[2].FindControl("CmbProjectDistrict") as DropDownList).SelectedValue);
                            string project = (row.Cells[1].FindControl("CmbProject") as DropDownList).SelectedItem.Text;
                            int projectid = Convert.ToInt32((row.Cells[1].FindControl("CmbProject") as DropDownList).SelectedValue);
                            string posttitle = (row.Cells[3].FindControl("CmbPostTitle") as DropDownList).SelectedItem.Text;
                            int posttitleid = Convert.ToInt32((row.Cells[3].FindControl("CmbPostTitle") as DropDownList).SelectedValue);

                            string fromdate = (row.Cells[4].FindControl("txtFromDate") as TextBox).Text;
                            string todate = ((row.Cells[5].FindControl("txtToDate") as TextBox).Text);
                            string salaries = ((row.Cells[6].FindControl("txtSalaries") as TextBox).Text);
                            string supervisor = ((row.Cells[7].FindControl("txtSupervisor") as TextBox).Text);
                            string reason = ((row.Cells[8].FindControl("txtReason") as TextBox).Text);
                            blu.insertceapworkHistory(Pid, projectdistrictid, projectdistrict, projectid, project, posttitleid, posttitle, fromdate, todate, salaries, 0, supervisor, reason);
                        }

                    }

                    else
                    {

                    }


                    foreach (GridViewRow row in GVLeave.Rows)//for leave management
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            RadioButton rbRow = (row.Cells[2].FindControl("rbPer") as RadioButton);
                            if (rbRow.Checked)
                            {
                                string leaveid = ((row.Cells[1].FindControl("txtLeaveId") as Label).Text);
                                int id = Convert.ToInt32(leaveid);

                                blu.insertLeaveManagement(Pid, id, 0, 0);
                            }
                            else
                            {

                            }
                        }
                    }

                    blu.CreateEmpGeneralInfo(txtEmployeeId.Text, filePathimage, title, EMP_FIRSTNAME.Text, EMP_MIDDLENAME.Text, EMP_LASTNAME.Text, gender, Mstatus, Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtJoindate.Text), EMP_MOBILE.Text, EMP_PHONE.Text, EMP_CITIZENSHIPNO.Text, txtPemail.Text, txtEmployeeId.Text, EMP_PASSWORD.Text, padd, TSTREET.Text, TDistrict, TState, PSTREET.Text, PDistrict, PState, pcountry, bloodgrp, txtAlrg.Text, MED_CON.Text, DOCTOR.Text, DOCTOR_CONTACT.Text, DOCTOR1.Text, DOCTOR_CONTACT1.Text, txtMun1.Text, txtWard1.Text, txtVillage1.Text, txtMun.Text, txtWard.Text, txtVillage.Text, Ethnicity, issueDistrict, spouse, txtChildren.Text, fathername, mothername, grandname, txtOccupation.Text, Son, Daughter, Religion, Religionid, txtAge.Text, txtPassport.Text, ethnicityid, issuedistrictid, Pstateid, PDistrictid, Tstateid, TDistrictid, bloodgroupid);
                    blu.InsertEmpRelativeInfo(txtEmployeeId.Text, Emergency_Name.Text, Emergency_Address.Text, Emergency_Relation.Text, Emergency_Contact.Text, filePathRelation, txtEmgMobile.Text);
                    blu.CreateOfficialInfo(degid, modeid, deptid, branchid, statid, gradeid, roomno, txtOfcEmail.Text, extno, cardno, vehicleno, cardExpirydate, licenceexpirydate, licenceno, Permanent, Resign_Date, Probation, Probation1, probationMFrom, probationMTo, txtEmployeeId.Text, citnum, epan, pfnum, checkWebLogin, Pid, isOT, fileno, bankid, (CmbBank.SelectedItem.ToString()), BankbranchId, bankAC, suspensionFrom, suspensionTo, dischargeDate, dissmissDate, Contract, Contract1, Trainee, Trainee1, txtSalary.Text, Laid_off, txtSev.Text, txtSecurity.Text, isAttendance, txtAmount.Text, filePathSignature, CmbProjectDistrict.SelectedItem.ToString(), Convert.ToInt32(CmbUsertype.SelectedValue), (CmbUsertype.SelectedItem.ToString()), StatusDate, StatusDateTo, txtremarks.Text, txtGratuity.Text, TypeDateFrom, TypeDateTo, (CmbType.SelectedItem.ToString()), typeid);


                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Employee saved Successfully').then((value) => { window.location ='Employees.aspx'; });", true);
                    }
                }
           
        }
        protected void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            int StateId = Convert.ToInt32(CmbTState.SelectedValue);
            DataTable dt = blu.getDistrict(StateId);
            if (dt.Rows.Count > 0)
            {
                CmbTDistrict.DataSource = dt;
                CmbTDistrict.DataTextField = "DistrictName";
                CmbTDistrict.DataValueField = "DistrictId";
                CmbTDistrict.DataBind();

            }
        }

        protected void grvStudentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    grvStudentDetails.DataSource = dt;
                    grvStudentDetails.DataBind();

                    for (int i = 0; i < grvStudentDetails.Rows.Count - 1; i++)
                    {
                        grvStudentDetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
            }
        }//for education
        private void SetRowData()
        {

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox TextBoxName = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtName");
                        TextBox TextBoxDegree = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtDegree");
                        TextBox TextBoxMajor = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("txtMajor");
                        TextBox txtPercentage = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("txtPercentage");
                        TextBox txtEnd = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("txtEnd");


                        TextBox box3 = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("TextBox3");
                        HiddenField hfFile = (HiddenField)grvStudentDetails.Rows[rowIndex].Cells[7].FindControl("hfFileByte");
                        FileUpload fuUpload = (FileUpload)grvStudentDetails.Rows[rowIndex].Cells[7].FindControl("fuUpload");
                        byte[] bytes = null;
                        if (fuUpload.HasFile)
                        {
                            BinaryReader br = new BinaryReader(fuUpload.PostedFile.InputStream);
                            bytes = br.ReadBytes((int)fuUpload.PostedFile.InputStream.Length);
                            hfFile.Value = Convert.ToBase64String(bytes);
                        }

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Col1"] = TextBoxName.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextBoxDegree.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextBoxMajor.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = txtPercentage.Text;
                        dtCurrentTable.Rows[i - 1]["Col5"] = txtEnd.Text;

                        dtCurrentTable.Rows[i - 1]["Col6"] = fuUpload.HasFile ? Path.GetFileName(fuUpload.PostedFile.FileName) : box3.Text;
                        dtCurrentTable.Rows[i - 1]["Col7"] = fuUpload.HasFile ? bytes : Convert.FromBase64String(hfFile.Value);

                      
                        rowIndex++;
                    }
                    // dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    //grvStudentDetails.DataSource = dtCurrentTable;
                    //grvStudentDetails.DataBind();

                }
            }
            else
            {

            }
            // SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox TextBoxName = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtName");
                        TextBox TextBoxDegree = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtDegree");
                        TextBox TextBoxMajor = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("txtMajor");
                        TextBox txtPercentage = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("txtPercentage");
                        TextBox txtEnd = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("txtEnd");

                        TextBox box3 = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("TextBox3");
                        HiddenField hfFile = (HiddenField)grvStudentDetails.Rows[rowIndex].Cells[7].FindControl("hfFileByte");

                        TextBoxName.Text = dt.Rows[i]["Col1"].ToString();
                        TextBoxDegree.Text = dt.Rows[i]["Col2"].ToString();
                        TextBoxMajor.Text = dt.Rows[i]["Col3"].ToString();
                        txtPercentage.Text = dt.Rows[i]["Col4"].ToString();
                        txtEnd.Text = dt.Rows[i]["Col5"].ToString();

                        box3.Text = dt.Rows[i]["Col6"].ToString();
                        hfFile.Value = !Convert.IsDBNull(dt.Rows[i]["Col7"]) ? Convert.ToBase64String((byte[])dt.Rows[i]["Col7"]) : "";

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)//for education row
        {
            int rowIndex = 0;
            SetRowData();

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox TextBoxName = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtName");
                        TextBox TextBoxDegree = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtDegree");
                        TextBox TextBoxMajor = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("txtMajor");
                        TextBox TextBoxPercent = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("txtPercentage");
                        TextBox TextBoxEnd = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("txtEnd");

                        TextBox box3 = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("TextBox3");
                        HiddenField hfFile = (HiddenField)grvStudentDetails.Rows[rowIndex].Cells[7].FindControl("hfFileByte");
                        FileUpload fuUpload = (FileUpload)grvStudentDetails.Rows[rowIndex].Cells[7].FindControl("fuUpload");
                        byte[] bytes = null;
                        if (fuUpload.HasFile)
                        {
                            BinaryReader br = new BinaryReader(fuUpload.PostedFile.InputStream);
                            bytes = br.ReadBytes((int)fuUpload.PostedFile.InputStream.Length);
                            hfFile.Value = Convert.ToBase64String(bytes);
                        }

                      

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Col1"] = TextBoxName.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextBoxDegree.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextBoxMajor.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = TextBoxPercent.Text;
                        dtCurrentTable.Rows[i - 1]["Col5"] = TextBoxEnd.Text;

                        dtCurrentTable.Rows[i - 1]["Col6"] = fuUpload.HasFile ? Path.GetFileName(fuUpload.PostedFile.FileName) : box3.Text;
                        dtCurrentTable.Rows[i - 1]["Col7"] = fuUpload.HasFile ? bytes : Convert.FromBase64String(hfFile.Value);

                      
                        rowIndex++;
                        SetRowData();
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    grvStudentDetails.DataSource = dtCurrentTable;
                    grvStudentDetails.DataBind();
                }
            }
            else
            {
                //Response.Write("ViewState is null");
            }
            SetPreviousData();

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)//for Training
        {
            // SetRowDataTraining();
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt2 = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow1 = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt2.Rows.Count > 1)
                {
                    dt2.Rows.Remove(dt2.Rows[rowIndex]);
                    drCurrentRow1 = dt2.NewRow();
                    ViewState["CurrentTable1"] = dt2;
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();

                    for (int j = 0; j < GridView1.Rows.Count - 1; j++)
                    {
                        GridView1.Rows[j].Cells[0].Text = Convert.ToString(j + 1);
                    }
                    SetPreviousDataTraining();
                }
            }
        }
        private void SetRowDataTraining()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dtCurrentTable1 = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow1 = null;
                if (dtCurrentTable1.Rows.Count > 0)
                {
                    for (int j = 1; j <= dtCurrentTable1.Rows.Count; j++)
                    {
                        TextBox TextBoxTitle = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("txtTitle");
                        TextBox TextBoxOrganize = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtOrganize");
                        TextBox TextBoxPlace = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtPlace");
                        TextBox TextBoxDays = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtDays");
                        TextBox TextBoxEnd = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtEnd");
                        TextBox TextBoxStart = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtStart");

                     
                        TextBox txtFilename = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txtFilename");
                        HiddenField TFileByte = (HiddenField)GridView1.Rows[rowIndex].Cells[8].FindControl("TFileByte");
                        FileUpload TUpload = (FileUpload)GridView1.Rows[rowIndex].Cells[8].FindControl("TUpload");
                        byte[] bytes = null;
                        if (TUpload.HasFile)
                        {
                            BinaryReader br = new BinaryReader(TUpload.PostedFile.InputStream);
                            bytes = br.ReadBytes((int)TUpload.PostedFile.InputStream.Length);
                            TFileByte.Value = Convert.ToBase64String(bytes);
                        }

                        drCurrentRow1 = dtCurrentTable1.NewRow();
                        drCurrentRow1["RowNumber"] = j + 1;

                        dtCurrentTable1.Rows[j - 1]["Col1"] = TextBoxTitle.Text;
                        dtCurrentTable1.Rows[j - 1]["Col2"] = TextBoxOrganize.Text;
                        dtCurrentTable1.Rows[j - 1]["Col3"] = TextBoxPlace.Text;
                        dtCurrentTable1.Rows[j - 1]["Col4"] = TextBoxDays.Text;
                        dtCurrentTable1.Rows[j - 1]["Col5"] = TextBoxEnd.Text;
                        dtCurrentTable1.Rows[j - 1]["Col6"] = TextBoxStart.Text;
                        // dtCurrentTable1.Rows[j - 1]["Col7"] = FileUploadtr.FileName;


                        dtCurrentTable1.Rows[j - 1]["Col7"] = TUpload.HasFile ? Path.GetFileName(TUpload.PostedFile.FileName) : txtFilename.Text;
                        dtCurrentTable1.Rows[j - 1]["Col8"] = TUpload.HasFile ? bytes : Convert.FromBase64String(TFileByte.Value);
                        rowIndex++;
                    }
                   // dtCurrentTable1.Rows.Add(drCurrentRow1);
                    ViewState["CurrentTable1"] = dtCurrentTable1;

                    //GridView1.DataSource = dtCurrentTable1;
                    //GridView1.DataBind();
                }
            }
            else
            {
                //Response.Write("ViewState is null");
            }
            //SetPreviousDataTraining();
        }
        private void SetPreviousDataTraining()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt2 = (DataTable)ViewState["CurrentTable1"];
                if (dt2.Rows.Count > 0)
                {
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        TextBox TextBoxTitle = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("txtTitle");
                        TextBox TextBoxOrganize = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtOrganize");
                        TextBox TextBoxPlace = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtPlace");
                        TextBox TextBoxDays = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtDays");
                        TextBox TextBoxEnd = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtEnd");
                        TextBox TextBoxStart = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtStart");

                        TextBox txtFilename = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txtFilename");
                        HiddenField TFileByte = (HiddenField)GridView1.Rows[rowIndex].Cells[8].FindControl("TFileByte");

                        TextBoxTitle.Text = dt2.Rows[j]["Col1"].ToString();
                        TextBoxOrganize.Text = dt2.Rows[j]["Col2"].ToString();
                        TextBoxPlace.Text = dt2.Rows[j]["Col3"].ToString();
                        TextBoxDays.Text = dt2.Rows[j]["Col4"].ToString();
                        TextBoxEnd.Text = dt2.Rows[j]["Col5"].ToString();
                        TextBoxStart.Text = dt2.Rows[j]["Col6"].ToString();

                     
                        txtFilename.Text = dt2.Rows[j]["Col7"].ToString();
                        TFileByte.Value = !Convert.IsDBNull(dt2.Rows[j]["Col8"]) ? Convert.ToBase64String((byte[])dt2.Rows[j]["Col8"]) : "";
                        rowIndex++;
                    }
                }
            }
        }
        protected void BtnAddRow_Click(object sender, EventArgs e)//for training row
        {
            int rowIndex = 0;
            SetRowDataTraining();
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dtCurrentTable1 = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow1 = null;
                if (dtCurrentTable1.Rows.Count > 0)
                {
                    for (int j = 1; j <= dtCurrentTable1.Rows.Count; j++)
                    {
                        TextBox TextBoxTitle = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("txtTitle");
                        TextBox TextBoxOrganize = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtOrganize");
                        TextBox TextBoxPlace = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtPlace");
                        TextBox TextBoxDays = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtDays");
                        TextBox TextBoxEnd = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtEnd");
                        TextBox TextBoxStart = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtStart");

                        TextBox txtFilename = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txtFilename");
                        HiddenField TFileByte = (HiddenField)GridView1.Rows[rowIndex].Cells[8].FindControl("TFileByte");
                        FileUpload TUpload = (FileUpload)GridView1.Rows[rowIndex].Cells[8].FindControl("TUpload");
                        byte[] bytes = null;
                        if (TUpload.HasFile)
                        {
                            BinaryReader br = new BinaryReader(TUpload.PostedFile.InputStream);
                            bytes = br.ReadBytes((int)TUpload.PostedFile.InputStream.Length);
                            TFileByte.Value = Convert.ToBase64String(bytes);
                        }

                        drCurrentRow1 = dtCurrentTable1.NewRow();
                        drCurrentRow1["RowNumber"] = j + 1;
                        dtCurrentTable1.Rows[j - 1]["Col1"] = TextBoxTitle.Text;
                        dtCurrentTable1.Rows[j - 1]["Col2"] = TextBoxOrganize.Text;
                        dtCurrentTable1.Rows[j - 1]["Col3"] = TextBoxPlace.Text;
                        dtCurrentTable1.Rows[j - 1]["Col4"] = TextBoxDays.Text;
                        dtCurrentTable1.Rows[j - 1]["Col5"] = TextBoxEnd.Text;
                        dtCurrentTable1.Rows[j - 1]["Col6"] = TextBoxStart.Text;

                        dtCurrentTable1.Rows[j - 1]["Col7"] = TUpload.HasFile ? Path.GetFileName(TUpload.PostedFile.FileName) : txtFilename.Text;
                        dtCurrentTable1.Rows[j - 1]["Col8"] = TUpload.HasFile ? bytes : Convert.FromBase64String(TFileByte.Value);
                        rowIndex++;
                        SetRowDataTraining();
                    }
                    dtCurrentTable1.Rows.Add(drCurrentRow1);
                    ViewState["CurrentTable1"] = dtCurrentTable1;

                    GridView1.DataSource = dtCurrentTable1;
                    GridView1.DataBind();
                }
            }
            else
            {
                //Response.Write("ViewState is null");
            }
            SetPreviousDataTraining();

        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // SetRowDataExp();
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt3 = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow2 = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt3.Rows.Count > 1)
                {
                    dt3.Rows.Remove(dt3.Rows[rowIndex]);
                    drCurrentRow2 = dt3.NewRow();
                    ViewState["CurrentTable2"] = dt3;
                    GridView2.DataSource = dt3;
                    GridView2.DataBind();

                    for (int k = 0; k < GridView2.Rows.Count - 1; k++)
                    {
                        GridView2.Rows[k].Cells[0].Text = Convert.ToString(k + 1);
                    }
                    SetPreviousDataExp();
                }
            }
        }//for experience
        private void SetRowDataExp()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dtCurrentTable2 = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow2 = null;
                if (dtCurrentTable2.Rows.Count > 0)
                {
                    for (int k = 1; k <= dtCurrentTable2.Rows.Count; k++)
                    {
                        TextBox TextBoxOrganization = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("txtOrganization");
                        TextBox TextBoxDesignation = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("txtDesignation");
                        TextBox TextBoxEnd1 = (TextBox)GridView2.Rows[rowIndex].Cells[3].FindControl("txtEnd");
                        TextBox TextBoxStart1 = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtStart");
                        TextBox TextBoxSalary = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("txtSalary");
                        TextBox TextBoxContact = (TextBox)GridView2.Rows[rowIndex].Cells[6].FindControl("txtContact");

                        TextBox Filename = (TextBox)GridView2.Rows[rowIndex].Cells[7].FindControl("Filename");
                        HiddenField PWFileByte = (HiddenField)GridView2.Rows[rowIndex].Cells[8].FindControl("PWFileByte");
                        FileUpload PWUpload = (FileUpload)GridView2.Rows[rowIndex].Cells[8].FindControl("PWUpload");
                        byte[] bytes = null;
                        if (PWUpload.HasFile)
                        {
                            BinaryReader br = new BinaryReader(PWUpload.PostedFile.InputStream);
                            bytes = br.ReadBytes((int)PWUpload.PostedFile.InputStream.Length);
                            PWFileByte.Value = Convert.ToBase64String(bytes);
                        }


                        drCurrentRow2 = dtCurrentTable2.NewRow();
                        drCurrentRow2["RowNumber"] = k + 1;
                        dtCurrentTable2.Rows[k - 1]["Colmn1"] = TextBoxOrganization.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn2"] = TextBoxDesignation.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn3"] = TextBoxEnd1.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn4"] = TextBoxStart1.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn5"] = TextBoxSalary.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn6"] = TextBoxContact.Text;

                        dtCurrentTable2.Rows[k - 1]["Colmn7"] = PWUpload.HasFile ? Path.GetFileName(PWUpload.PostedFile.FileName) : Filename.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn8"] = PWUpload.HasFile ? bytes : Convert.FromBase64String(PWFileByte.Value);
                        rowIndex++;
                    }
                   // dtCurrentTable2.Rows.Add(drCurrentRow2);
                    ViewState["CurrentTable2"] = dtCurrentTable2;

                    //GridView2.DataSource = dtCurrentTable2;
                    //GridView2.DataBind();
                }
            }
            else
            {
                //Response.Write("ViewState is null");
            }
            //SetPreviousDataExp();
        }
        private void SetPreviousDataExp()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt3 = (DataTable)ViewState["CurrentTable2"];
                if (dt3.Rows.Count > 0)
                {
                    for (int k = 0; k < dt3.Rows.Count; k++)
                    {
                        TextBox TextBoxOrganization = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("txtOrganization");
                        TextBox TextBoxDesignation = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("txtDesignation");
                        TextBox TextBoxEnd1 = (TextBox)GridView2.Rows[rowIndex].Cells[3].FindControl("txtEnd");
                        TextBox TextBoxStart1 = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtStart");
                        TextBox TextBoxSalary = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("txtSalary");
                        TextBox TextBoxContact = (TextBox)GridView2.Rows[rowIndex].Cells[6].FindControl("txtContact");

                        TextBox Filename = (TextBox)GridView2.Rows[rowIndex].Cells[7].FindControl("Filename");
                        HiddenField PWFileByte = (HiddenField)GridView2.Rows[rowIndex].Cells[8].FindControl("PWFileByte");

                        TextBoxOrganization.Text = dt3.Rows[k]["Colmn1"].ToString();
                        TextBoxDesignation.Text = dt3.Rows[k]["Colmn2"].ToString();
                        TextBoxEnd1.Text = dt3.Rows[k]["Colmn3"].ToString();
                        TextBoxStart1.Text = dt3.Rows[k]["Colmn4"].ToString();
                        TextBoxSalary.Text = dt3.Rows[k]["Colmn5"].ToString();
                        TextBoxContact.Text = dt3.Rows[k]["Colmn6"].ToString();

                        Filename.Text = dt3.Rows[k]["Colmn7"].ToString();
                        PWFileByte.Value = !Convert.IsDBNull(dt3.Rows[k]["Colmn8"]) ? Convert.ToBase64String((byte[])dt3.Rows[k]["Colmn8"]) : "";
                        rowIndex++;
                    }
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)//for experience
        {
            int rowIndex = 0;
            SetRowDataExp();
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dtCurrentTable2 = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow2 = null;
                if (dtCurrentTable2.Rows.Count > 0)
                {
                    for (int k = 1; k <= dtCurrentTable2.Rows.Count; k++)
                    {
                        TextBox TextBoxOrganization = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("txtOrganization");
                        TextBox TextBoxDesignation = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("txtDesignation");
                        TextBox TextBoxEnd1 = (TextBox)GridView2.Rows[rowIndex].Cells[3].FindControl("txtEnd");
                        TextBox TextBoxStart1 = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtStart");
                        TextBox TextBoxSalary = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("txtSalary");
                        TextBox TextBoxContact = (TextBox)GridView2.Rows[rowIndex].Cells[6].FindControl("txtContact");

                        TextBox Filename = (TextBox)GridView2.Rows[rowIndex].Cells[7].FindControl("Filename");
                        HiddenField PWFileByte = (HiddenField)GridView2.Rows[rowIndex].Cells[8].FindControl("PWFileByte");
                        FileUpload PWUpload = (FileUpload)GridView2.Rows[rowIndex].Cells[8].FindControl("PWUpload");
                        byte[] bytes = null;
                        if (PWUpload.HasFile)
                        {
                            BinaryReader br = new BinaryReader(PWUpload.PostedFile.InputStream);
                            bytes = br.ReadBytes((int)PWUpload.PostedFile.InputStream.Length);
                            PWFileByte.Value = Convert.ToBase64String(bytes);
                        }

                        drCurrentRow2 = dtCurrentTable2.NewRow();
                        drCurrentRow2["RowNumber"] = k + 1;

                        dtCurrentTable2.Rows[k - 1]["Colmn1"] = TextBoxOrganization.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn2"] = TextBoxDesignation.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn3"] = TextBoxEnd1.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn4"] = TextBoxStart1.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn5"] = TextBoxSalary.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn6"] = TextBoxContact.Text;

                        dtCurrentTable2.Rows[k - 1]["Colmn7"] = PWUpload.HasFile ? Path.GetFileName(PWUpload.PostedFile.FileName) : Filename.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn8"] = PWUpload.HasFile ? bytes : Convert.FromBase64String(PWFileByte.Value);
                        rowIndex++;
                        SetRowDataExp();
                    }
                    dtCurrentTable2.Rows.Add(drCurrentRow2);
                    ViewState["CurrentTable2"] = dtCurrentTable2;

                    GridView2.DataSource = dtCurrentTable2;
                    GridView2.DataBind();
                }
            }
            else
            {
                //Response.Write("ViewState is null");
            }
            SetPreviousDataExp();

        }
        protected void grvceapHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)////for ceapred Workhistory
        {
            SetRowDataWorkHistory();
            if (ViewState["CurrentTable3"] != null)
            {
                DataTable dt4 = (DataTable)ViewState["CurrentTable3"];
                DataRow drCurrentRow3 = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt4.Rows.Count > 1)
                {
                    dt4.Rows.Remove(dt4.Rows[rowIndex]);
                    drCurrentRow3 = dt4.NewRow();
                    ViewState["CurrentTable3"] = dt4;
                    grvceapHistory.DataSource = dt4;
                    grvceapHistory.DataBind();

                    for (int k = 0; k < grvceapHistory.Rows.Count - 1; k++)
                    {
                        grvceapHistory.Rows[k].Cells[0].Text = Convert.ToString(k + 1);
                    }
                    SetPreviousDataWorkHistory();
                }
            }
        }
        private void SetRowDataWorkHistory()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable3"] != null)
            {
                DataTable dtCurrentTable3 = (DataTable)ViewState["CurrentTable3"];
                DataRow drCurrentRow3 = null;
                if (dtCurrentTable3.Rows.Count > 0)
                {
                    for (int k = 1; k <= dtCurrentTable3.Rows.Count; k++)
                    {

                        DropDownList dropProject = (DropDownList)grvceapHistory.Rows[rowIndex].Cells[1].FindControl("CmbProject");
                        DropDownList DropDistrict = (DropDownList)grvceapHistory.Rows[rowIndex].Cells[2].FindControl("CmbProjectDistrict");
                        DropDownList TextBoxPostTitle = (DropDownList)grvceapHistory.Rows[rowIndex].Cells[3].FindControl("CmbPostTitle");
                        TextBox TextBoxFromDate = (TextBox)grvceapHistory.Rows[rowIndex].Cells[4].FindControl("txtFromDate");
                        TextBox TextBoxToDate = (TextBox)grvceapHistory.Rows[rowIndex].Cells[5].FindControl("txtToDate");
                        TextBox TextBoxSalaries = (TextBox)grvceapHistory.Rows[rowIndex].Cells[6].FindControl("txtSalaries");
                        TextBox TextBoxSupervisor = (TextBox)grvceapHistory.Rows[rowIndex].Cells[7].FindControl("txtSupervisor");
                        TextBox TextBoxReason = (TextBox)grvceapHistory.Rows[rowIndex].Cells[8].FindControl("txtReason");

                        drCurrentRow3 = dtCurrentTable3.NewRow();
                        drCurrentRow3["RowNumber"] = k + 1;
                        dtCurrentTable3.Rows[k - 1]["Colmn1"] = dropProject.SelectedValue;
                        dtCurrentTable3.Rows[k - 1]["Colmn2"] = DropDistrict.SelectedValue;
                        dtCurrentTable3.Rows[k - 1]["Colmn3"] = TextBoxPostTitle.SelectedValue;
                        dtCurrentTable3.Rows[k - 1]["Colmn4"] = TextBoxFromDate.Text;
                        dtCurrentTable3.Rows[k - 1]["Colmn5"] = TextBoxToDate.Text;
                        dtCurrentTable3.Rows[k - 1]["Colmn6"] = TextBoxSalaries.Text;
                        dtCurrentTable3.Rows[k - 1]["Colmn7"] = TextBoxSupervisor.Text;
                        dtCurrentTable3.Rows[k - 1]["Colmn8"] = TextBoxReason.Text;

                        rowIndex++;
                    }

                    ViewState["CurrentTable3"] = dtCurrentTable3;
                }
            }
            else
            {
                //Response.Write("ViewState is null");
            }
        }
        private void SetPreviousDataWorkHistory()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable3"] != null)
            {
                DataTable dt4 = (DataTable)ViewState["CurrentTable3"];
                if (dt4.Rows.Count > 0)
                {
                    for (int k = 0; k < dt4.Rows.Count; k++)
                    {

                        DropDownList dropProject = (DropDownList)grvceapHistory.Rows[rowIndex].Cells[1].FindControl("CmbProject");
                        DropDownList DropDistrict = (DropDownList)grvceapHistory.Rows[rowIndex].Cells[2].FindControl("CmbProjectDistrict");
                        DropDownList TextBoxPostTitle = (DropDownList)grvceapHistory.Rows[rowIndex].Cells[3].FindControl("CmbPostTitle");
                        TextBox TextBoxFromDate = (TextBox)grvceapHistory.Rows[rowIndex].Cells[4].FindControl("txtFromDate");
                        TextBox TextBoxToDate = (TextBox)grvceapHistory.Rows[rowIndex].Cells[5].FindControl("txtToDate");
                        TextBox TextBoxSalaries = (TextBox)grvceapHistory.Rows[rowIndex].Cells[6].FindControl("txtSalaries");
                        TextBox TextBoxSupervisor = (TextBox)grvceapHistory.Rows[rowIndex].Cells[7].FindControl("txtSupervisor");
                        TextBox TextBoxReason = (TextBox)grvceapHistory.Rows[rowIndex].Cells[8].FindControl("txtReason");


                        dropProject.SelectedValue = dt4.Rows[k]["Colmn1"].ToString();
                        DropDistrict.SelectedValue = dt4.Rows[k]["Colmn2"].ToString();
                        TextBoxPostTitle.SelectedValue = dt4.Rows[k]["Colmn3"].ToString();
                        TextBoxFromDate.Text = dt4.Rows[k]["Colmn4"].ToString();
                        TextBoxToDate.Text = dt4.Rows[k]["Colmn5"].ToString();
                        TextBoxSalaries.Text = dt4.Rows[k]["Colmn6"].ToString();
                        TextBoxSupervisor.Text = dt4.Rows[k]["Colmn7"].ToString();
                        TextBoxReason.Text = dt4.Rows[k]["Colmn8"].ToString();

                        rowIndex++;

                    }
                }
            }
        }

        protected void btnAddhistory_Click(object sender, EventArgs e)//ceapred workhistory add row
        {

            int rowIndex = 0;
            SetRowDataWorkHistory();
            if (ViewState["CurrentTable3"] != null)
            {
                DataTable dtCurrentTable3 = (DataTable)ViewState["CurrentTable3"];
                DataRow drCurrentRow3 = null;
                if (dtCurrentTable3.Rows.Count > 0)
                {
                    for (int k = 1; k <= dtCurrentTable3.Rows.Count; k++)
                    {

                        DropDownList dropProject = (DropDownList)grvceapHistory.Rows[rowIndex].Cells[1].FindControl("CmbProject");
                        DropDownList DropDistrict = (DropDownList)grvceapHistory.Rows[rowIndex].Cells[2].FindControl("CmbProjectDistrict");
                        DropDownList TextBoxPostTitle = (DropDownList)grvceapHistory.Rows[rowIndex].Cells[3].FindControl("CmbPostTitle");
                        TextBox TextBoxFromDate = (TextBox)grvceapHistory.Rows[rowIndex].Cells[4].FindControl("txtFromDate");
                        TextBox TextBoxToDate = (TextBox)grvceapHistory.Rows[rowIndex].Cells[5].FindControl("txtToDate");
                        TextBox TextBoxSalaries = (TextBox)grvceapHistory.Rows[rowIndex].Cells[6].FindControl("txtSalaries");
                        TextBox TextBoxSupervisor = (TextBox)grvceapHistory.Rows[rowIndex].Cells[7].FindControl("txtSupervisor");
                        TextBox TextBoxReason = (TextBox)grvceapHistory.Rows[rowIndex].Cells[8].FindControl("txtReason");


                        drCurrentRow3 = dtCurrentTable3.NewRow();
                        drCurrentRow3["RowNumber"] = k + 1;

                        dtCurrentTable3.Rows[k - 1]["Colmn1"] = dropProject.SelectedValue;
                        dtCurrentTable3.Rows[k - 1]["Colmn2"] = DropDistrict.SelectedValue;
                        dtCurrentTable3.Rows[k - 1]["Colmn3"] = TextBoxPostTitle.SelectedValue;
                        dtCurrentTable3.Rows[k - 1]["Colmn4"] = TextBoxFromDate.Text;
                        dtCurrentTable3.Rows[k - 1]["Colmn5"] = TextBoxToDate.Text;
                        dtCurrentTable3.Rows[k - 1]["Colmn6"] = TextBoxSalaries.Text;
                        dtCurrentTable3.Rows[k - 1]["Colmn7"] = TextBoxSupervisor.Text;
                        dtCurrentTable3.Rows[k - 1]["Colmn8"] = TextBoxReason.Text;


                        rowIndex++;
                        SetRowDataWorkHistory();
                    }
                    dtCurrentTable3.Rows.Add(drCurrentRow3);

                    ViewState["CurrentTable3"] = dtCurrentTable3;

                    //ViewState["CurrentTable3"] = dtCurrentTable3;

                    grvceapHistory.DataSource = dtCurrentTable3;
                    grvceapHistory.DataBind();
                }
            }
            else
            {
                //Response.Write("ViewState is null");
            }
            SetPreviousDataWorkHistory();

        }

        protected void chkAllrg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllrg.Checked == true)
            {
                txtAlrg.Visible = true;
            }
            else
            {
                txtAlrg.Visible = false;
            }
        }

        protected void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
      
        protected void btnUpload_Click(object sender, EventArgs e)
        {
        }

        protected void CmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void rbBank_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBank.Checked)
            {
                CmbBank.Visible = true;
                txtAccno.Visible = true;
                lblBank.Visible = true;
                lblAccount.Visible = true;

            }

        }

        protected void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCash.Checked)
            {
                CmbBank.Visible = false;
                txtAccno.Visible = false;
                lblBank.Visible = false;
                lblAccount.Visible = false;
                //CmbBankBranch.Visible = false;
                //lblBankBranch.Visible = false;
            }

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                lblPrmAmt.Visible = true;
                txtAmount.Visible = true;
            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked)
            {
                lblPrmAmt.Visible = false;
                txtAmount.Visible = false;
            }
        }

        protected void chkCopy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCopy.Checked)
            {
                if (CmbPState.SelectedItem.Text == "Select Province")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel4, this.GetType(), "alertscipt", "swal('Oops!','PLz Select Permanent Province !!!','warning')", true);
                    return;
                }
                else
                {


                    TSTREET.Text = PSTREET.Text;
                    txtMun.Text = txtMun1.Text;
                    txtWard.Text = txtWard1.Text;
                    txtVillage.Text = txtVillage1.Text;

                    CmbTState.SelectedItem.Text = CmbPState.SelectedItem.ToString();


                    int StateId = Convert.ToInt32(CmbPState.SelectedValue);
                    DataTable dt = blu.getDistrict(StateId);
                    CmbTDistrict.DataSource = dt;
                    CmbTDistrict.DataTextField = "DistrictName";
                    CmbTDistrict.DataValueField = "DistrictId";
                    CmbTDistrict.DataBind();

                    CmbTDistrict.SelectedItem.Text = CmbPDistrict.SelectedItem.ToString();

                    CmbTState.Enabled = false;
                    CmbTDistrict.Enabled = false;
                }
            }
            else
            {
                TSTREET.Text = "";
                txtMun.Text = "";
                txtWard.Text = "";
                txtVillage.Text = "";
                CmbTState.SelectedItem.Text = "";
                CmbTDistrict.SelectedItem.Text = "";

                CmbTState.Enabled = true;
                CmbTDistrict.Enabled = true;
            }
        }
        public class CalculateDateDifference
        {
            private int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            private DateTime fromDate;
            private DateTime toDate;
            private int year;
            private int month;
            private int day;

            public CalculateDateDifference(DateTime d1, DateTime d2)
            {
                int increment;
                //To Date must be greater
                if (d1 > d2)
                {
                    this.fromDate = d2;
                    this.toDate = d1;
                }
                else
                {
                    this.fromDate = d1;
                    this.toDate = d2;
                }
                increment = 0;
                if (this.fromDate.Day > this.toDate.Day)
                {
                    increment = this.monthDay[this.fromDate.Month - 1];
                }
                if (increment == -1)
                {
                    if (DateTime.IsLeapYear(this.fromDate.Year))
                    {
                        increment = 29;
                    }
                    else
                    {
                        increment = 28;
                    }
                }
                if (increment != 0)
                {
                    day = (this.toDate.Day + increment) - this.fromDate.Day;
                    increment = 1;
                }
                else
                {
                    day = this.toDate.Day - this.fromDate.Day;
                }
                if ((this.fromDate.Month + increment) > this.toDate.Month)
                {

                    this.month = (this.toDate.Month + 12) - (this.fromDate.Month + increment);

                    increment = 1;

                }

                else
                {

                    this.month = (this.toDate.Month) - (this.fromDate.Month + increment);

                    increment = 0;

                }


                ///

                /// year calculation

                ///

                this.year = this.toDate.Year - (this.fromDate.Year + increment);


            }


            public override string ToString()
            {

                //return base.ToString();

                return this.year + " Year(s), " + this.month + " month(s), " + this.day + " day(s)";

            }


            public int Years
            {

                get
                {

                    return this.year;

                }

            }


            public int Months
            {
                get
                {
                    return this.month;
                }
            }


            public int Days
            {

                get
                {

                    return this.day;

                }

            }


        }

        protected void btnUpEmg_Click(object sender, EventArgs e)
        {
        }

        protected void btnSignature_Click(object sender, EventArgs e)
        {
        }
        protected void txtEmployeeId_TextChanged(object sender, EventArgs e)//getWorkhistory
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvStudentDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void CmbPState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtStartDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "alertscipt", "swal('Ooops!','Date can not be emptied !!!','warning')", true);
                return;
            }
            else
            {
                DateTime dt1 = DateTime.Parse(txtStartDate.Text);
                DateTime dt2 = DateTime.Today;
                //Initializing object and then calling constructor
                CalculateDateDifference dateDiff = new CalculateDateDifference(dt1, dt2);
                int totalMonths = dateDiff.Months;
                int totalDays = dateDiff.Days;
                int totalYears = dateDiff.Years;
                txtAge.Text = totalYears.ToString() + " Years," + totalMonths.ToString() + " Months," + totalDays.ToString() + " Days";
            }


            int StateId = Convert.ToInt32(CmbPState.SelectedValue);
            DataTable dt = blu.getDistrict(StateId);

            CmbPDistrict.DataSource = dt;
            CmbPDistrict.DataTextField = "DistrictName";
            CmbPDistrict.DataValueField = "DistrictId";
            CmbPDistrict.DataBind();
            if (chkCopy.Checked)
            {
                CmbTState.SelectedItem.Text = CmbPState.SelectedItem.Text;
                DataTable dt4 = blu.getDistrict(StateId);

                CmbTDistrict.DataSource = dt4;
                CmbTDistrict.DataTextField = "DistrictName";
                CmbTDistrict.DataValueField = "DistrictId";
                CmbTDistrict.DataBind();
            }


        }

        protected void CmbPDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkCopy.Checked)
            {
                CmbTDistrict.SelectedItem.Text = CmbPDistrict.SelectedItem.Text;
            }
            else
            {

            }
        }

        protected void grvhist_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void grvceapHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in grvceapHistory.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList CmbProject = (DropDownList)row.FindControl("CmbProject");//for Project
                    DataTable dtP = blu.getBranch();
                    CmbProject.DataSource = dtP;

                    CmbProject.DataTextField = "BRANCH_NAME";
                    CmbProject.DataValueField = "BRANCH_ID";
                    CmbProject.DataBind();

                    DropDownList CmbPostTitle = (DropDownList)row.FindControl("CmbPostTitle");//for designation
                    DataTable dt = blu.getDesignation();
                    CmbPostTitle.DataSource = dt;

                    CmbPostTitle.DataTextField = "DEG_NAME";
                    CmbPostTitle.DataValueField = "DEG_ID";
                    CmbPostTitle.DataBind();

                    DropDownList CmbProjectDistrict = (DropDownList)row.FindControl("CmbProjectDistrict");//for district

                    DataTable dtd = blu.getDistrictList();
                    CmbProjectDistrict.DataSource = dtd;
                    CmbProjectDistrict.DataTextField = "DistrictName";
                    CmbProjectDistrict.DataValueField = "DistrictId";
                    CmbProjectDistrict.DataBind();
                    //CmbProjectDistrict.Items.Insert(0, "Select District");


                    //DropDownList Projectname = (DropDownList)row.FindControl("CmbProject");
                    //int BranchID = Convert.ToInt32(CmbProject.SelectedValue);


                    //   // DataTable dtd = blu.getdistrictfromproject(BranchID);
                    ////    if (dtd.Rows.Count > 0)
                    ////    {
                    ////        CmbProjectDistrict.DataSource = dtd;
                    ////        CmbProjectDistrict.DataTextField = "DistrictName";
                    ////        CmbProjectDistrict.DataValueField = "DistrictId";
                    ////        CmbProjectDistrict.DataBind();



                }
            }
        }

        protected void chkHistory_CheckedChanged1(object sender, EventArgs e)
        {
            if (chkHistory.Checked)
            {
                grvceapHistory.Enabled = true;

            }
            else
            {
                grvceapHistory.Enabled = false;

            }
        }

        protected void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbStatus.SelectedItem.Text == "Retired" || CmbStatus.SelectedItem.Text == "Termination" || CmbStatus.SelectedItem.Text == "Dismissed" || CmbStatus.SelectedItem.Text == "Resigned" || CmbStatus.SelectedItem.Text == "Laid_off")
            {
                txtstadate.Visible = true;
                txtstaToDate.Visible = false;

                lblremarks.Visible = true;
                txtremarks.Visible = true;
            }
            else if (CmbStatus.SelectedItem.Text == "Suspension")
            {
                txtstadate.Visible = true;
                txtstaToDate.Visible = true;

                lblremarks.Visible = true;
                txtremarks.Visible = true;
            }
            else if (CmbStatus.SelectedItem.Text == "Working")
            {
                txtstadate.Visible = false;
                txtstaToDate.Visible = false;

                lblremarks.Visible = false;
                txtremarks.Visible = false;
            }
        }

        protected void CmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (GridViewRow row in grvceapHistory.Rows)
            //{
            //    DropDownList ddl1 = (DropDownList)row.FindControl("CmbProject");

            //    if (row != null)
            //    {
            //        DropDownList ddl2 = (DropDownList)row.FindControl("CmbProjectDistrict");

            //        ddl2.DataSource = blu.getdistrictfromproject(Convert.ToInt32(ddl1.SelectedValue));
            //        ddl2.DataTextField = "DistrictName";
            //        ddl2.DataValueField = "DistrictId";
            //        ddl2.DataBind();

            //    }
            //}

        }
        protected void CmbProjectDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CmbProjectDistrict.SelectedValue = CmbProjectDistrict.SelectedItem.Value;
            //foreach (GridViewRow row in grvceapHistory.Rows)
            //{
            //    DropDownList ddl1 = (DropDownList)row.FindControl("CmbProject");

            //    if (row != null)
            //    {
            //        DropDownList ddl2 = (DropDownList)row.FindControl("CmbProjectDistrict");

            //        ddl2.DataSource = blu.getdistrictfromproject(Convert.ToInt32(ddl1.SelectedValue));
            //        //ddl2.DataTextField = "DistrictName";
            //        //ddl2.DataValueField = "DistrictId";
            //        //ddl2.DataBind();

            //        CmbProjectDistrict.SelectedValue = ddl2.SelectedValue;

            //    }
            //}

        }
        protected void CmbType_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int typeid = Convert.ToInt32(CmbType.SelectedValue);
            if (typeid == 1)
            {
                txtFrom.Visible = true;
                txtTo.Visible = false;
            }
            else if (typeid == 2)
            {
                txtFrom.Visible = false;
                txtTo.Visible = false;
            }
            else if (typeid == 3 || typeid == 5 || typeid == 6 || typeid == 4)
            {
                txtFrom.Visible = true;
                txtTo.Visible = true;
            }

        }

        protected void grvStudentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void grvStudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    TextBox txtbox = e.Row.FindControl("TextBox3") as TextBox;
            //    txtbox.Enabled = false; 
            //}

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    if (e.Row.RowState.Equals(DataControlRowState.Edit))
            //    {
            //        Button btnUpload = e.Row.FindControl("UploadImage") as Button;
            //        ScriptManager.GetCurrent(this).RegisterPostBackControl(btnUpload);
            //    }
            //}
        }
        protected void UploadImage_Click(object sender, EventArgs e)
        {
            SetRowData();
            SetPreviousData();

            FileUpload fileUpload = (FileUpload)grvStudentDetails.Rows[0].FindControl("fuUpload");


            System.IO.Stream stream = fileUpload.PostedFile.InputStream;
            int length = fileUpload.PostedFile.ContentLength;

            if (length > 2097152)
            {
                Label1.Text = "File size is Too Large";
                return;
            }
            else
            {
                //SetRowData();
                //SetPreviousData();
            }
            byte[] data = new byte[length];
            stream.Read(data, 0, length);


                    //String extension = System.IO.Path.GetExtension(fileUpload.PostedFile.FileName);
                    //if (extension.ToLower() != ".pdf" && extension.ToLower() != ".jpg")
                    //{
                    //    Label1.Text = "only pdf,png, jpeg,gif, jpg files are  allowed";
                    //    Label1.ForeColor = System.Drawing.Color.Red;
                    //    return;
                    //}
                    //else
                    //{
                    //    SetRowData();
                    //    SetPreviousData();
                    //}
               // }
           // }
        }
        protected void btnTrImage_Click(object sender, EventArgs e)
        {
            SetRowDataTraining();
            SetPreviousDataTraining();


            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    TextBox Filename = row.FindControl("txtFilename") as TextBox;
            //    Filename.Enabled = true;
            //}
        }
        protected void btnWorkImage_Click(object sender, EventArgs e)
        {
            SetRowDataExp();
            SetPreviousDataExp();

            //foreach (GridViewRow row in GridView2.Rows)
            //{
            //    TextBox filenameW = row.FindControl("Filename") as TextBox;
            //    filenameW.Enabled = true;
            //}
        }
        protected void grvStudentDetails_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //SetRowData();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    TextBox Filename = e.Row.FindControl("txtFilename") as TextBox;
            //    Filename.Enabled = false;
            //}
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    TextBox filenameW = e.Row.FindControl("Filename") as TextBox;
            //    filenameW.Enabled = false;
            //}
        }

        protected void GVLeave_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dt = blu.getLeaveInfo();
            if (dt.Rows.Count == 0)
            {
               
            }
            else
            {
                e.Row.Cells[1].Visible = false;
            }
           
        }

    }
}


