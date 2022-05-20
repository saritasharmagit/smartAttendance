using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.HR_Mgmt
{
    public partial class EditEmployees : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int Stateid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int empid = Convert.ToInt32(Request.QueryString["EMP_ID"].ToString());
                HiddenField1.Value = empid.ToString();
                DataTable dta = blu.GetEmpbyId(empid);

               // int empIdd = Convert.ToInt16(empid);//for image

                int Empid = Convert.ToInt32(empid);
                DataTable dtP = blu.getPid(Empid);
                int pid = Convert.ToInt32(dtP.Rows[0]["PID"].ToString());

                DataSet ds = blu.LoadPhoto(Empid);////for image
                int c = ds.Tables[0].Rows.Count;
                foreach (DataRow row in ds.Tables["Photo"].Rows)
                {
                    if (ds.Tables["Photo"].Rows.Count > 0)
                    {
                        byte[] bytedata = new byte[0];
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            bytedata = (byte[])(ds.Tables[0].Rows[0][0]);
                            MemoryStream stmphoto = new MemoryStream(bytedata);

                            string PROFILE_PIC = Convert.ToBase64String(bytedata);
                           
                            ImgPersonal.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);

                        }
                        else
                        {
                            ImgPersonal.ImageUrl = null;
                        }
                    }
                    else
                    {
                        ImgPersonal.ImageUrl = null;
                    }
                }
                ds.Tables.Clear();

                DataSet dsI = blu.LoadRelativePhoto(Empid);
                int cI = dsI.Tables[0].Rows.Count;
                foreach (DataRow row in dsI.Tables["IMAGE"].Rows)
                {
                    if (dsI.Tables["IMAGE"].Rows.Count > 0)
                    {
                        byte[] bytedata = new byte[0];
                        if (dsI.Tables[0].Rows[0][0].ToString() != "")
                        {
                            bytedata = (byte[])(dsI.Tables[0].Rows[0][0]);
                            MemoryStream stmphoto = new MemoryStream(bytedata);

                            string PROFILE_PIC = Convert.ToBase64String(bytedata);

                            Image2.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);

                        }
                        else
                        {
                            Image2.ImageUrl = null;
                        }
                    }
                    else
                    {
                        Image2.ImageUrl = null;
                    }
                }
                dsI.Tables.Clear();

                DataSet dsO = blu.LoadDigitalSignature(pid);
                int cO = dsO.Tables[0].Rows.Count;
                foreach (DataRow row in dsO.Tables["Signature"].Rows)
                {
                    if (dsO.Tables["Signature"].Rows.Count > 0)
                    {
                        byte[] bytedata = new byte[0];
                        if (dsO.Tables[0].Rows[0][0].ToString() != "")
                        {
                            bytedata = (byte[])(dsO.Tables[0].Rows[0][0]);
                            MemoryStream stmphoto = new MemoryStream(bytedata);

                            string PROFILE_PIC = Convert.ToBase64String(bytedata);

                            Image3.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);

                        }
                        else
                        {
                            Image3.ImageUrl = null;
                        }
                    }
                    else
                    {
                        Image3.ImageUrl = null;
                    }
                }
                dsO.Tables.Clear();
           

                txtEmployeeId.Text = Request.QueryString["EMP_ID"].ToString();
                EMP_TITLE.SelectedItem.Text = dta.Rows[0]["EMP_TITLE"].ToString();
              
                EMP_MIDDLENAME.Text = dta.Rows[0]["EMP_MIDDLENAME"].ToString();
                EMP_FIRSTNAME.Text = dta.Rows[0]["EMP_FIRSTNAME"].ToString();
                EMP_LASTNAME.Text = dta.Rows[0]["EMP_LASTNAME"].ToString();
                txtStartDate.Text = dta.Rows[0]["EMP_DOB"].ToString();
                txtJoindate.Text = dta.Rows[0]["EMP_JOINDATE"].ToString();


                DateTime result = Convert.ToDateTime(dta.Rows[0]["EMP_DOB"].ToString());
                txtStartDate.Text = result.ToString("yyyy-MM-dd");

                DateTime result1 = Convert.ToDateTime(dta.Rows[0]["EMP_JOINDATE"].ToString());
                txtJoindate.Text = result1.ToString("yyyy-MM-dd");

                EMP_MOBILE.Text = dta.Rows[0]["EMP_MOBILE"].ToString();
                txtFather.Text = dta.Rows[0]["Father_Name"].ToString();
                txtOccupation.Text = dta.Rows[0]["Father_Occupation"].ToString();
                txtChildren.Text = dta.Rows[0]["Children_Number"].ToString();
                //txtSon.Text = dta.Rows[0]["Son_Number"].ToString();
                //txtDaughter.Text = dta.Rows[0]["Daughter_Number"].ToString();
                txtSpouse.Text = dta.Rows[0]["Spouse_Name"].ToString();
                txtMother.Text = dta.Rows[0]["Mother_Name"].ToString();
                txtGrand.Text = dta.Rows[0]["Grandfather_Name"].ToString();
                EMP_CITIZENSHIPNO.Text = dta.Rows[0]["EMP_CITIZENSHIPNO"].ToString();

                txtPemail.Text = dta.Rows[0]["EMP_PEMAIL"].ToString();
                EMP_PHONE.Text = dta.Rows[0]["EMP_PHONE"].ToString();

                PSTREET.Text = dta.Rows[0]["EMP_PSTREET"].ToString();
                txtMun1.Text = dta.Rows[0]["PVDC_municipality"].ToString();
                txtWard1.Text = dta.Rows[0]["PWard_Number"].ToString();
                txtVillage1.Text = dta.Rows[0]["PVillage_Tole"].ToString();

                TSTREET.Text = dta.Rows[0]["EMP_TSTREET"].ToString();
                txtMun.Text = dta.Rows[0]["TVDC_municipality"].ToString();
                txtWard.Text = dta.Rows[0]["TWard_Number"].ToString();
                txtVillage.Text = dta.Rows[0]["TVillage_Tole"].ToString();
                txtPassport.Text = dta.Rows[0]["Passport_Number"].ToString();

                
                if(dta.Rows[0]["ALLERGY"].ToString()!="")
                {
                    chkAllrg.Checked = true;
                    txtAlrg.Text = dta.Rows[0]["ALLERGY"].ToString();
                }
                else
                {
                    chkAllrg.Checked = false;
                    txtAlrg.Visible = false;
                }
                MED_CON.Text = dta.Rows[0]["MED_CON"].ToString();
                DOCTOR.Text = dta.Rows[0]["DOCTOR"].ToString();
                DOCTOR_CONTACT.Text = dta.Rows[0]["DOCTOR_CONTACT"].ToString();
                DOCTOR1.Text = dta.Rows[0]["DOCTOR1"].ToString();
                DOCTOR_CONTACT1.Text = dta.Rows[0]["DOCTOR_CONTACT1"].ToString();

                Emergency_Name.Text = dta.Rows[0]["NAME"].ToString();
                Emergency_Relation.Text = dta.Rows[0]["RELATION"].ToString();
                Emergency_Address.Text = dta.Rows[0]["ADDRESS"].ToString();
                Emergency_Contact.Text = dta.Rows[0]["Emergency_Contact"].ToString();
                txtEmgMobile.Text = dta.Rows[0]["MOBILE"].ToString();

                if (dta.Rows[0]["BloodGroup_Id"].ToString() == "" || (dta.Rows[0]["BloodGroup_Id"].ToString() =="0"))
                {
                    
                }
                else
                {
                    CmbBlood.SelectedValue = dta.Rows[0]["BloodGroup_Id"].ToString();
                }
                txtUserid.Text = dta.Rows[0]["EMP_USERID"].ToString();
                EMP_PASSWORD.Text = dta.Rows[0]["EMP_PASSWORD"].ToString();

                txtSalary.Text = dta.Rows[0]["BSALARY"].ToString();

                txtAccno.Text = dta.Rows[0]["bankAC"].ToString();
                txtGratuity.Text = dta.Rows[0]["Gratuity"].ToString();
                txtSecurity.Text = dta.Rows[0]["Social_Security"].ToString();
                txtSev.Text = dta.Rows[0]["Severance_No"].ToString();
                pf_number.Text = dta.Rows[0]["pf_number"].ToString();
                epan_number.Text = dta.Rows[0]["epan_number"].ToString();
                cit_number.Text = dta.Rows[0]["cit_number"].ToString();
                txtOfcEmail.Text = dta.Rows[0]["OFFEMAIL"].ToString();

                CmbEthnicity.SelectedValue = (dta.Rows[0]["Ethnicity_Id"].ToString());
                CmbIssueDistrict.SelectedValue = (dta.Rows[0]["DistrictId"].ToString());
            
                if( dta.Rows[0]["PState_Id"].ToString()=="")
                {

                }
                else
                {
                    CmbPState.SelectedValue = dta.Rows[0]["PState_Id"].ToString();
                }
              
                if(dta.Rows[0]["PDistrict_Id"].ToString()=="")
                {

                }
                else
                {
                    CmbPDistrict.SelectedValue = dta.Rows[0]["PDistrict_Id"].ToString();
                }
                if (dta.Rows[0]["TState_Id"].ToString() == "0" || dta.Rows[0]["TState_Id"].ToString() == "")
                {
                    DataTable dt1 = blu.getStateList();
                    CmbTState.DataSource = dt1;
                    CmbTState.DataTextField = "StateName";
                    CmbTState.DataValueField = "StateId";
                    CmbTState.DataBind();

                    Stateid = Convert.ToInt32(CmbTState.SelectedValue);//for temp state
                    DataTable dtTD = blu.getDistrict(Stateid);
                    CmbTDistrict.DataSource = dtTD;
                    CmbTDistrict.DataTextField = "DistrictName";
                    CmbTDistrict.DataValueField = "DistrictId";
                    CmbTDistrict.DataBind();
                    CmbTDistrict.Items.Insert(0, "Select District");
                }
                else
                {
                    CmbTState.SelectedValue = dta.Rows[0]["TState_Id"].ToString();
                    CmbTDistrict.SelectedValue = dta.Rows[0]["TDistrict_Id"].ToString();
                  

                    HiddenField3.Value = dta.Rows[0]["TState_Id"].ToString();//for temp district load
                    int id = Convert.ToInt32(HiddenField3.Value);
                   
                    DataTable dtTD = blu.getDistrict(id);
                    CmbTDistrict.DataSource = dtTD;
                    CmbTDistrict.DataTextField = "DistrictName";
                    CmbTDistrict.DataValueField = "DistrictId";
                    CmbTDistrict.DataBind();
                    CmbTDistrict.Items.Insert(0, "Select District");

                }
                CmbTDistrict.SelectedValue = dta.Rows[0]["TDistrict_Id"].ToString();

                CmbBranch.SelectedValue = dta.Rows[0]["BRANCH_ID"].ToString();
                HiddenField4.Value = dta.Rows[0]["BRANCH_ID"].ToString();
                int BranchID = Convert.ToInt32(HiddenField4.Value);
                DataTable dtd = blu.getdistrictfromproject(BranchID);
                if (dtd.Rows.Count > 0)
                {
                    CmbProjectDistrict.DataSource = dtd;
                    CmbProjectDistrict.DataTextField = "DistrictName";
                    CmbProjectDistrict.DataValueField = "DistrictId";
                    CmbProjectDistrict.DataBind();

                }

                CmbProjectDistrict.SelectedValue = dta.Rows[0]["ProjectDistrictID"].ToString();
                CmbDepartment.SelectedValue = dta.Rows[0]["DEPT_ID"].ToString();
                CmbUsertype.SelectedValue = dta.Rows[0]["UserType_Id"].ToString();
                CmbStatus.SelectedValue = dta.Rows[0]["STATUS_ID"].ToString();
                CmbGrade.SelectedValue = dta.Rows[0]["GRADE_ID"].ToString();
                CmbDesignation.SelectedValue = dta.Rows[0]["DEG_ID"].ToString();
                CmbReligion.SelectedValue = dta.Rows[0]["Religion_Id"].ToString();
               
               
                if (Convert.ToInt32(dta.Rows[0]["IsAttendance"].ToString()) == 1)
                {
                    chkAttn.Checked = true;
                }
                else
                {
                    chkAttn.Checked = false;
                }
                if (dta.Rows[0]["MARITALSTATUS"].ToString() == "Single")
                {
                    Relationship1.Checked = true;
                    Relationship2.Checked = false;
                    Relationship3.Checked = false;
                }
                else if (dta.Rows[0]["MARITALSTATUS"].ToString() == "Married")
                {
                    Relationship1.Checked = false;
                    Relationship2.Checked = true;
                    Relationship3.Checked = false;
                }
                else if (dta.Rows[0]["MARITALSTATUS"].ToString() == "Divorcee")
                {
                    Relationship1.Checked = false;
                    Relationship2.Checked = false;
                    Relationship3.Checked = true;
                }
                if (dta.Rows[0]["GENDER"].ToString() == "Male")
                {
                    Gender1.Checked = false;
                    Gender2.Checked = true;
                    Gender3.Checked = false;
                }
                else if (dta.Rows[0]["GENDER"].ToString() == "Female")
                {
                    Gender1.Checked = true;
                    Gender2.Checked = false;
                    Gender3.Checked = false;
                }
                else if (dta.Rows[0]["GENDER"].ToString() == "Others")
                {
                    Gender1.Checked = false;
                    Gender2.Checked = false;
                    Gender3.Checked = true;
                }
              
                CmbType.SelectedValue = dta.Rows[0]["EmployeeType_Id"].ToString();
                if (dta.Rows[0]["EmployeeType_Id"].ToString() == "3" || dta.Rows[0]["EmployeeType_Id"].ToString() == "4" || dta.Rows[0]["EmployeeType_Id"].ToString() == "5" || dta.Rows[0]["EmployeeType_Id"].ToString() == "6")
                {
                    txtFrom.Visible = true;
                    txtTo.Visible = true;
                    txtFrom.Text = dta.Rows[0]["Type_fromDate"].ToString();
                    txtTo.Text = dta.Rows[0]["Type_toDate"].ToString();
                }
                else if (dta.Rows[0]["EmployeeType_Id"].ToString() == "2")
                {
                    txtFrom.Visible = false;
                    txtTo.Visible = false;
                }
                else if (dta.Rows[0]["EmployeeType_Id"].ToString() == "1")
                {
                    txtFrom.Visible = true;
                    txtTo.Visible = false;
                    txtFrom.Text = dta.Rows[0]["Type_fromDate"].ToString();
                }
            
                if ((dta.Rows[0]["BANK_ID"].ToString()) == "0")
                {
                    rbCash.Checked = true;
                    CmbBank.Visible = false;
                    txtAccno.Visible = false;
                    lblBank.Visible = false;
                    lblAccount.Visible = false;

                }
                else
                {
                    rbBank.Checked = true;
                    CmbBank.Visible = true;
                    txtAccno.Visible = true;
                    lblBank.Visible = true;
                    lblAccount.Visible = true;
                    CmbBank.SelectedValue = dta.Rows[0]["BANK_ID"].ToString();
                }
                if(dta.Rows[0]["Premium_Amount"].ToString()!="")
                {
                    txtAmount.Visible = true;
                    lblPrmAmt.Visible = true;
                    RadioButton1.Checked = true;
                    txtAmount.Text = dta.Rows[0]["Premium_Amount"].ToString();
                }
                else
                {
                    txtAmount.Visible = false;
                    lblPrmAmt.Visible = false;
                    RadioButton1.Checked = false;
                    RadioButton2.Checked = true;
                }

               


                DataTable dt = blu.getLeaveInfo();//for leave management
                GVLeave.DataSource = dt;
                GVLeave.DataBind();

                

                loadBloodgroup();
                loadProject();
                loadDesignation();
                loadStatus();
                loadUsertype();
                loadGrade();
                loadPState();
                loadTState();
                loadDistrict();
                loadEthnicity();
                loadProjectDistrict();
                loadDepartment();
                loadBank();
                loadReligion();
                loadType();


                bool Pid = blu.CheckPID(pid.ToString());//for education table
                DataTable dtEd = blu.Education(pid);
                if (Pid == true)
                {
                 
                    dtEd.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col1", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col2", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col3", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col4", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col5", typeof(string)));

                    dtEd.Columns.Add(new DataColumn("Col6", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col7", typeof(byte[])));
                    dtEd.Columns.Add(new DataColumn("Col8", typeof(string)));

                    ViewState["CurrentTable"] = dtEd;
                    grvStudentDetails.DataSource = dtEd;
                    grvStudentDetails.DataBind();
                }
                else
                {

                    DataRow dr = null;
                    dtEd.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col1", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col2", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col3", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col4", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col5", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col6", typeof(string)));
                    dtEd.Columns.Add(new DataColumn("Col7", typeof(byte[])));
                    dtEd.Columns.Add(new DataColumn("Col8", typeof(string)));
                    dr = dtEd.NewRow();

                    dr["RowNumber"] = 1;
                    dr["Col1"] = string.Empty;
                    dr["Col2"] = string.Empty;
                    dr["Col3"] = string.Empty;
                    dr["Col4"] = string.Empty;
                    dr["Col5"] = string.Empty;
                    dr["Col6"] = string.Empty;
                    dr["Col7"] = null;
                    dr["Col8"] = string.Empty;
                    dtEd.Rows.Add(dr);

                    ViewState["CurrentTable"] = dtEd;
                    grvStudentDetails.DataSource = dtEd;
                    grvStudentDetails.DataBind();
                }

                bool TrainingPid = blu.CheckTrainingPid(pid.ToString());//for training table
                DataTable dtT = blu.Training(pid);
                if (TrainingPid == true)
                {
                   
                    dtT.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column1", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column2", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column3", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column4", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column5", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column6", typeof(string)));

                    dtT.Columns.Add(new DataColumn("Column7", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column8", typeof(byte[])));
                    dtT.Columns.Add(new DataColumn("Column9", typeof(string)));

                    ViewState["CurrentTable1"] = dtT;
                    GridView1.DataSource = dtT;
                    GridView1.DataBind();
                }
                else
                {
                    DataRow dr = null;
                    dtT.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column1", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column2", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column3", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column4", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column5", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column6", typeof(string)));

                    dtT.Columns.Add(new DataColumn("Column7", typeof(string)));
                    dtT.Columns.Add(new DataColumn("Column8", typeof(byte[])));
                    dtT.Columns.Add(new DataColumn("Column9", typeof(string)));

                    dr = dtT.NewRow();

                    dr["RowNumber"] = 1;
                    dr["Column1"] = string.Empty;
                    dr["Column2"] = string.Empty;
                    dr["Column3"] = string.Empty;
                    dr["Column4"] = string.Empty;
                    dr["Column5"] = string.Empty;
                    dr["Column6"] = string.Empty;
                    dr["Column7"] = string.Empty;
                    dr["Column8"] = null;
                    dr["Column9"] = string.Empty;

                    dtT.Rows.Add(dr);

                    ViewState["CurrentTable1"] = dtT;
                    GridView1.DataSource = dtT;
                    GridView1.DataBind();
                }

                bool PastworkPid = blu.CheckPastWorkPid(pid.ToString());//for work history
                DataTable dtw = blu.jobexperience(pid);
                if (PastworkPid == true)
                {
                    dtw.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn1", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn2", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn3", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn4", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn5", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn6", typeof(string)));

                    dtw.Columns.Add(new DataColumn("Colmn7", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn8", typeof(byte[])));

                    ViewState["CurrentTable2"] = dtw;
                    GridView2.DataSource = dtw;
                    GridView2.DataBind();
                }
                else
                {
                    DataRow dr = null;
                    dtw.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn1", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn2", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn3", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn4", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn5", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn6", typeof(string)));

                    dtw.Columns.Add(new DataColumn("Colmn7", typeof(string)));
                    dtw.Columns.Add(new DataColumn("Colmn8", typeof(byte[])));

                    dr = dtw.NewRow();

                    dr["RowNumber"] = 1;
                    dr["Colmn1"] = string.Empty;
                    dr["Colmn2"] = string.Empty;
                    dr["Colmn3"] = string.Empty;
                    dr["Colmn4"] = string.Empty;
                    dr["Colmn5"] = string.Empty;
                    dr["Colmn6"] = string.Empty;
                    dr["Colmn7"] = string.Empty;
                    dr["Colmn8"] = null;

                    dtw.Rows.Add(dr);

                    ViewState["CurrentTable2"] = dtw;
                    GridView2.DataSource = dtw;
                    GridView2.DataBind();
                }


                DataTable dtc = blu.getCeaphistory(pid); //for ceapred work history
                dtc.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dtc.Columns.Add(new DataColumn("ColmnP", typeof(string)));
                dtc.Columns.Add(new DataColumn("Colmnsd", typeof(string)));
                dtc.Columns.Add(new DataColumn("Colmned", typeof(string)));
                dtc.Columns.Add(new DataColumn("Colmns", typeof(string)));
                dtc.Columns.Add(new DataColumn("Colmnsu", typeof(string)));

                ViewState["CurrentTable3"] = dtc;
                grvceapHistory.DataSource = dtc;
                grvceapHistory.DataBind();
              
                int StateId = Convert.ToInt32(CmbPState.SelectedValue);//for permanent state
                DataTable dtpd = blu.getDistrict(StateId);

                CmbPDistrict.DataSource = dtpd;
                CmbPDistrict.DataTextField = "DistrictName";
                CmbPDistrict.DataValueField = "DistrictId";
                CmbPDistrict.DataBind();

                if (CmbStatus.SelectedItem.Text == "Retired" || CmbStatus.SelectedItem.Text == "Termination" || CmbStatus.SelectedItem.Text == "Dismissed" || CmbStatus.SelectedItem.Text == "Resigned" || CmbStatus.SelectedItem.Text == "Laid_off")
                {
                    txtstadate.Visible = true;
                    txtstaToDate.Visible = false;

                    lblremarks.Visible = true;
                    txtremarks.Visible = true;

                    txtstadate.Text= dta.Rows[0]["Retired_Date"].ToString();
                    txtremarks.Text = dta.Rows[0]["Retired_Remarks"].ToString();
                    return;
                }
                else if (CmbStatus.SelectedItem.Text == "Suspension")
                {
                    txtstadate.Visible = true;
                    txtstaToDate.Visible = true;

                    lblremarks.Visible = true;
                    txtremarks.Visible = true;

                    txtstadate.Text = dta.Rows[0]["Retired_Date"].ToString();             
                    txtstaToDate.Text = dta.Rows[0]["Retired_DateTo"].ToString();
                    txtremarks.Text = dta.Rows[0]["Retired_Remarks"].ToString();

                    return;
                }
                else if (CmbStatus.SelectedItem.Text == "Working")
                {
                    txtstadate.Visible = false;
                    txtstaToDate.Visible = false;

                    lblremarks.Visible = false;
                    txtremarks.Visible = false;
                    return;
                }
               
                txtstadate.Visible = false;
                txtstaToDate.Visible = false;

             
            }
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
        public void loadReligion()
        {
            DataTable dt = blu.getReligion();
            CmbReligion.DataSource = dt;
            CmbReligion.DataTextField = "Religion_Name";
            CmbReligion.DataValueField = "Religion_Id";
            CmbReligion.DataBind();
            //CmbReligion.Items.Insert(0, "Select Religion");
        }
        public void loadProject()
        {
            DataTable dt = blu.getBranchList();
            CmbBranch.DataSource = dt;
            CmbBranch.DataTextField = "BRANCH_Name";
            CmbBranch.DataValueField = "BRANCH_ID";
            CmbBranch.DataBind();
            CmbProjectDistrict.Items.Insert(0, "Select Project");
        }
        public void loadProjectDistrict()
        {
            DataTable dt = blu.getDistrictList();
            CmbProjectDistrict.DataSource = dt;
            CmbProjectDistrict.DataTextField = "DistrictName";
            CmbProjectDistrict.DataValueField = "DistrictId";
            CmbProjectDistrict.DataBind();
            CmbProjectDistrict.Items.Insert(0, "Select ProjectDistrict");
        }
        public void loadDesignation()
        {
            DataTable dt = blu.getDesignation();
            CmbDesignation.DataSource = dt;
            CmbDesignation.DataTextField = "DEG_NAME";
            CmbDesignation.DataValueField = "DEG_ID";
            CmbDesignation.DataBind();
        }

        public void loadStatus()
        {
            DataTable dt = blu.Getstatus();
            CmbStatus.DataSource = dt;
            CmbStatus.DataTextField = "STATUS_NAME";
            CmbStatus.DataValueField = "STATUS_ID";
            CmbStatus.DataBind();
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
            CmbGrade.Items.Insert(0, "Select Grade ");
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
        public void loadDistrict()
        {
            DataTable dt = blu.getDistrictList();
            CmbIssueDistrict.DataSource = dt;
            CmbIssueDistrict.DataTextField = "DistrictName";
            CmbIssueDistrict.DataValueField = "DistrictId";
            CmbIssueDistrict.DataBind();
            CmbIssueDistrict.Items.Insert(0, "Select District");
        }
        public void loadPState()
        {
            DataTable dt = blu.getStateList();
            CmbPState.DataSource = dt;
            CmbPState.DataTextField = "StateName";
            CmbPState.DataValueField = "StateId";
            CmbPState.DataBind();
            CmbPState.Items.Insert(0, "Select Province");
        }
        public void loadTState()
        {
            DataTable dt = blu.getStateList();
            CmbTState.DataSource = dt;
            CmbTState.DataTextField = "StateName";
            CmbTState.DataValueField = "StateId";
            CmbTState.DataBind();
            CmbTState.Items.Insert(0, "Select Province");
        }
        public void loadBloodgroup()
        {
            DataTable dt = blu.getBloodgroup();
            CmbBlood.DataSource = dt;
            CmbBlood.DataTextField = "Blood_Type";
            CmbBlood.DataValueField = "Blood_Id";
            CmbBlood.DataBind();
            CmbBlood.Items.Insert(0, "Select Group");
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
        public void loadBank()
        {
            DataTable dt = blu.GetBank();
            CmbBank.DataSource = dt;
            CmbBank.DataTextField = "BANK_NAME";
            CmbBank.DataValueField = "BANK_ID";
            CmbBank.DataBind();
            CmbBank.Items.Insert(0, "Select Bank");
        }

        protected void grvStudentDetails_RowDeleting1(object sender, GridViewDeleteEventArgs e)//for education
        {
            SetRowData();
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
        }
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
                        TextBox TextBoxName = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtSchool");
                        TextBox TextBoxDegree = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtdegree");
                        TextBox TextDivision = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("txtdivision");
                        TextBox txtMajor = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("txtmajor");
                        TextBox txtYear = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("txtyear");

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

                       // Image image = (Image)grvStudentDetails.Rows[rowIndex].Cells[8].FindControl("ImgDoc");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Col1"] = TextBoxName.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextBoxDegree.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextDivision.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = txtMajor.Text;
                        dtCurrentTable.Rows[i - 1]["Col5"] = txtYear.Text;

                        dtCurrentTable.Rows[i - 1]["Col6"] = fuUpload.HasFile ? Path.GetFileName(fuUpload.PostedFile.FileName) : box3.Text; 
                        dtCurrentTable.Rows[i - 1]["Col7"] = fuUpload.HasFile ? bytes : Convert.FromBase64String(hfFile.Value);

                       // dtCurrentTable.Rows[i - 1]["Col8"] = image.ImageUrl;
                        rowIndex++;
                    }
                   // dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

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
                        TextBox TextBoxName = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtSchool");
                        TextBox TextBoxDegree = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtdegree");
                        TextBox TextDivision = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("txtdivision");
                        TextBox txtMajor = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("txtmajor");
                        TextBox txtYear = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("txtyear");

                        TextBox box3 = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("TextBox3");

                        HiddenField hfFile = (HiddenField)grvStudentDetails.Rows[rowIndex].Cells[7].FindControl("hfFileByte");

                      //  Image image = (Image)grvStudentDetails.Rows[rowIndex].Cells[8].FindControl("ImgDoc");

                        TextBoxName.Text = dt.Rows[i]["Col1"].ToString();
                        TextBoxDegree.Text = dt.Rows[i]["Col2"].ToString();
                        TextDivision.Text = dt.Rows[i]["Col3"].ToString();
                        txtMajor.Text = dt.Rows[i]["Col4"].ToString();
                        txtYear.Text = dt.Rows[i]["Col5"].ToString();

                        box3.Text = dt.Rows[i]["Col6"].ToString();
                     
                        hfFile.Value = !Convert.IsDBNull(dt.Rows[i]["Col7"]) ? Convert.ToBase64String((byte[])dt.Rows[i]["Col7"]) : "";

                        //image.ImageUrl = dt.Rows[i]["Col8"].ToString();
                        rowIndex++;
                    }
                }
            }
        }

     
        protected void ButtonAdd_Click(object sender, EventArgs e)
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
                        TextBox TextBoxName = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtSchool");
                        TextBox TextBoxDegree = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtdegree");
                        TextBox TextDivision = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("txtdivision");
                        TextBox txtMajor = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("txtmajor");
                        TextBox txtYear = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("txtyear");

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

                       // Image image = (Image)grvStudentDetails.Rows[rowIndex].Cells[8].FindControl("ImgDoc");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Col1"] = TextBoxName.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextBoxDegree.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextDivision.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = txtMajor.Text;
                        dtCurrentTable.Rows[i - 1]["Col5"] = txtYear.Text;

                        dtCurrentTable.Rows[i - 1]["Col6"] = fuUpload.HasFile ? Path.GetFileName(fuUpload.PostedFile.FileName) : box3.Text;
 
                        dtCurrentTable.Rows[i - 1]["Col7"] = fuUpload.HasFile ? bytes : Convert.FromBase64String(hfFile.Value);

                       // dtCurrentTable.Rows[i - 1]["Col8"] = image.ImageUrl;
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)//for training
        {
            SetRowDataTraining();
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
                        TextBox TextBoxTitle = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("txttitle");
                        TextBox TextBoxOrg = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtorganization");
                        TextBox TextBoxPlace = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtplace");
                        TextBox TextBoxDays = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtdays");
                        TextBox TextBoxStart = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtstartdate");
                        TextBox TextBoxEnd = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtenddate");

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

                        dtCurrentTable1.Rows[j - 1]["Column1"] = TextBoxTitle.Text;
                        dtCurrentTable1.Rows[j - 1]["Column2"] = TextBoxOrg.Text;
                        dtCurrentTable1.Rows[j - 1]["Column3"] = TextBoxPlace.Text;
                        dtCurrentTable1.Rows[j - 1]["Column4"] = TextBoxDays.Text;
                        dtCurrentTable1.Rows[j - 1]["Column5"] = TextBoxStart.Text;
                        dtCurrentTable1.Rows[j - 1]["Column6"] = TextBoxEnd.Text;

                        dtCurrentTable1.Rows[j - 1]["Column7"] = TUpload.HasFile ? Path.GetFileName(TUpload.PostedFile.FileName) : txtFilename.Text;
                        dtCurrentTable1.Rows[j - 1]["Column8"] = TUpload.HasFile ? bytes : Convert.FromBase64String(TFileByte.Value);
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
                        TextBox TextBoxTitle = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("txttitle");
                        TextBox TextBoxOrg = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtorganization");
                        TextBox TextBoxPlace = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtplace");
                        TextBox TextBoxDays = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtdays");
                        TextBox TextBoxStart = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtstartdate");
                        TextBox TextBoxEnd = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtenddate");

                        TextBox txtFilename = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("txtFilename");
                        HiddenField TFileByte = (HiddenField)GridView1.Rows[rowIndex].Cells[8].FindControl("TFileByte");

                        TextBoxTitle.Text = dt2.Rows[j]["Column1"].ToString();
                        TextBoxOrg.Text = dt2.Rows[j]["Column2"].ToString();
                        TextBoxPlace.Text = dt2.Rows[j]["Column3"].ToString();
                        TextBoxDays.Text = dt2.Rows[j]["Column4"].ToString();
                        TextBoxStart.Text = dt2.Rows[j]["Column5"].ToString();
                        TextBoxEnd.Text = dt2.Rows[j]["Column6"].ToString();

                        txtFilename.Text = dt2.Rows[j]["Column7"].ToString();
                        TFileByte.Value = !Convert.IsDBNull(dt2.Rows[j]["Column8"]) ? Convert.ToBase64String((byte[])dt2.Rows[j]["Column8"]) : "";
                        rowIndex++;
                    }
                }
            }
        }

        protected void BtnAddRow_Click(object sender, EventArgs e)
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
                        TextBox TextBoxTitle = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("txttitle");
                        TextBox TextBoxOrg = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtorganization");
                        TextBox TextBoxPlace = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtplace");
                        TextBox TextBoxDays = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtdays");
                        TextBox TextBoxStart = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtstartdate");
                        TextBox TextBoxEnd = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("txtenddate");

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
                        dtCurrentTable1.Rows[j - 1]["Column1"] = TextBoxTitle.Text;
                        dtCurrentTable1.Rows[j - 1]["Column2"] = TextBoxOrg.Text;
                        dtCurrentTable1.Rows[j - 1]["Column3"] = TextBoxPlace.Text;
                        dtCurrentTable1.Rows[j - 1]["Column4"] = TextBoxDays.Text;
                        dtCurrentTable1.Rows[j - 1]["Column5"] = TextBoxStart.Text;
                        dtCurrentTable1.Rows[j - 1]["Column6"] = TextBoxEnd.Text;

                        dtCurrentTable1.Rows[j - 1]["Column7"] = TUpload.HasFile ? Path.GetFileName(TUpload.PostedFile.FileName) : txtFilename.Text;
                        dtCurrentTable1.Rows[j - 1]["Column8"] = TUpload.HasFile ? bytes : Convert.FromBase64String(TFileByte.Value);
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
            SetRowDataExp();
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
        }//for past workhistory
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
                        TextBox TextBoxOrganization = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("txtorganization");
                        TextBox TextBoxDesignation = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("txtPost");
                        TextBox TextBoxSalary = (TextBox)GridView2.Rows[rowIndex].Cells[3].FindControl("txtSalary");
                        TextBox TextBoxStart = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtstartdate");
                        TextBox TextBoxEnd = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("txtenddate");
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
                        dtCurrentTable2.Rows[k - 1]["Colmn3"] = TextBoxSalary.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn4"] = TextBoxStart.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn5"] = TextBoxEnd.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn6"] = TextBoxContact.Text;

                        dtCurrentTable2.Rows[k - 1]["Colmn7"] = PWUpload.HasFile ? Path.GetFileName(PWUpload.PostedFile.FileName) : Filename.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn8"] = PWUpload.HasFile ? bytes : Convert.FromBase64String(PWFileByte.Value);

                        rowIndex++;
                    }
                    //dtCurrentTable2.Rows.Add(drCurrentRow2);
                    ViewState["CurrentTable2"] = dtCurrentTable2;

                    //GridView2.DataSource = dtCurrentTable2;
                    //GridView2.DataBind();

                }
            }
            else
            {
                //Response.Write("ViewState is null");
            }
           // SetPreviousDataExp();
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
                        TextBox TextBoxOrganization = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("txtorganization");
                        TextBox TextBoxDesignation = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("txtPost");
                        TextBox TextBoxSalary = (TextBox)GridView2.Rows[rowIndex].Cells[3].FindControl("txtSalary");
                        TextBox TextBoxStart = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtstartdate");
                        TextBox TextBoxEnd = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("txtenddate");
                        TextBox TextBoxContact = (TextBox)GridView2.Rows[rowIndex].Cells[6].FindControl("txtContact");

                        TextBox Filename = (TextBox)GridView2.Rows[rowIndex].Cells[7].FindControl("Filename");
                        HiddenField PWFileByte = (HiddenField)GridView2.Rows[rowIndex].Cells[8].FindControl("PWFileByte");

                        TextBoxOrganization.Text = dt3.Rows[k]["Colmn1"].ToString();
                        TextBoxDesignation.Text = dt3.Rows[k]["Colmn2"].ToString();
                        TextBoxSalary.Text = dt3.Rows[k]["Colmn3"].ToString();
                        TextBoxStart.Text = dt3.Rows[k]["Colmn4"].ToString();
                        TextBoxEnd.Text = dt3.Rows[k]["Colmn5"].ToString();
                        TextBoxContact.Text = dt3.Rows[k]["Colmn6"].ToString();

                        Filename.Text = dt3.Rows[k]["Colmn7"].ToString();
                        PWFileByte.Value = !Convert.IsDBNull(dt3.Rows[k]["Colmn8"]) ? Convert.ToBase64String((byte[])dt3.Rows[k]["Colmn8"]) : "";

                        rowIndex++;
                    }
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
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
                        TextBox TextBoxOrganization = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("txtorganization");
                        TextBox TextBoxDesignation = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("txtPost");
                        TextBox TextBoxSalary = (TextBox)GridView2.Rows[rowIndex].Cells[3].FindControl("txtSalary");
                        TextBox TextBoxStart = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("txtstartdate");
                        TextBox TextBoxEnd = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("txtenddate");
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
                        dtCurrentTable2.Rows[k - 1]["Colmn3"] = TextBoxSalary.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn4"] = TextBoxStart.Text;
                        dtCurrentTable2.Rows[k - 1]["Colmn5"] = TextBoxEnd.Text;
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

        protected void grvceapHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)//for ceaored work history
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
                        TextBox TextBoxSalaries = (TextBox)grvceapHistory.Rows[rowIndex].Cells[4].FindControl("txtSalaries");
                        TextBox TextBoxSupervisor = (TextBox)grvceapHistory.Rows[rowIndex].Cells[5].FindControl("txtSupervisor");
                        TextBox TextBoxReason = (TextBox)grvceapHistory.Rows[rowIndex].Cells[6].FindControl("txtReason");

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
                        TextBox TextBoxSalaries = (TextBox)grvceapHistory.Rows[rowIndex].Cells[4].FindControl("txtSalaries");
                        TextBox TextBoxSupervisor = (TextBox)grvceapHistory.Rows[rowIndex].Cells[5].FindControl("txtSupervisor");
                        TextBox TextBoxReason = (TextBox)grvceapHistory.Rows[rowIndex].Cells[6].FindControl("txtReason");

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

        protected void btnAddhistory_Click(object sender, EventArgs e)
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
                        TextBox TextBoxSalaries = (TextBox)grvceapHistory.Rows[rowIndex].Cells[4].FindControl("txtSalaries");
                        TextBox TextBoxSupervisor = (TextBox)grvceapHistory.Rows[rowIndex].Cells[5].FindControl("txtSupervisor");
                        TextBox TextBoxReason = (TextBox)grvceapHistory.Rows[rowIndex].Cells[6].FindControl("txtReason");

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

        protected void grvceapHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           

            //foreach (GridViewRow row in grvceapHistory.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {

            //        DropDownList CmbPostTitle = (DropDownList)row.FindControl("CmbPostTitle");//for designation
            //        DataTable dt = blu.getDesignation();
            //        CmbPostTitle.DataSource = dt;

            //        CmbPostTitle.DataTextField = "DEG_NAME";
            //        CmbPostTitle.DataValueField = "DEG_ID";
            //        CmbPostTitle.DataBind();


            //        DropDownList CmbProjectDistrict = (DropDownList)row.FindControl("CmbProjectDistrict");//for district
            //        DataTable dtd = blu.getDistrictList();
            //        CmbProjectDistrict.DataSource = dtd;

            //        CmbProjectDistrict.DataTextField = "DistrictName";
            //        CmbProjectDistrict.DataValueField = "DistrictId";
            //        CmbProjectDistrict.DataBind();

            //       // string selectedCity =(DataBinder.Eval(e.Row.DataItem, "ProjectDistrict_Name").ToString());
            //       //CmbProjectDistrict.Items.FindByValue(selectedCity).Selected= true;
            //        //DataRowView dr = e.Row.DataItem as DataRowView;
            //        //CmbProjectDistrict.SelectedValue = dr["ProjectDistrict_Id"].ToString();


            //        DropDownList CmbProject = (DropDownList)row.FindControl("CmbProject");//for Project
            //        DataTable dtP = blu.getBranch();
            //        CmbProject.DataSource = dtP;

            //        CmbProject.DataTextField = "BRANCH_Name";
            //        CmbProject.DataValueField = "BRANCH_ID";
            //        CmbProject.DataBind();
                    
            //        int Empid = Convert.ToInt32(txtEmployeeId.Text);
            //        DataTable dtPd = blu.getPid(Empid);
            //        int pid = Convert.ToInt32(dtPd.Rows[0]["PID"].ToString());

            //        DataTable dtc = blu.getCeaphistory(pid);
                   
            //        for (int i = 0; i < dtc.Rows.Count; i++)
            //        {


            //            CmbProjectDistrict.SelectedValue = dtc.Rows[i]["ProjectDistrict_Id"].ToString();
            //            //CmbProjectDistrict.DataBind();

            //            CmbProject.SelectedValue = dtc.Rows[i]["Project_Id"].ToString();
            //            CmbPostTitle.SelectedValue = dtc.Rows[i]["Designation_Id"].ToString();

                       
            //        }
                   
                   
            //    }
            //}
        }
        string path;
        string filePathimage;
        string filePathRelation;
        string filePathSignature;
         string Son="";
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
        string Age = "";
        int ReligionId;
      
        protected void BtnSave_Click1(object sender, EventArgs e)
        {

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
                } if (CmbPState.SelectedItem.Text == "Select Province")
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
              
                if (CmbReligion.SelectedValue == "0")
                {
                    ReligionId = 0;
                }
                else
                {
                    ReligionId = Convert.ToInt32(CmbReligion.SelectedValue);
                }
               
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

                DataTable dt = blu.getPid(int.Parse(txtEmployeeId.Text));
                if (dt.Rows[0]["PID"].ToString() == "")
                {
                    blu.CreateOfcInfo(Convert.ToDateTime(txtJoindate.Text), txtEmployeeId.Text, pid);
                }
                else
                {
                    txtpid.Text = dt.Rows[0]["PID"].ToString();
                    pid = (txtpid.Text);
                    Pid = Convert.ToInt32(pid);
                    blu.CreateOfcInfo(Convert.ToDateTime(txtJoindate.Text), txtEmployeeId.Text, pid);
                }
                if (rbBank.Checked)
                {
                    //bankid = 1;
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
                if (CmbTState.SelectedItem.Text == "Select Province" || CmbTState.SelectedItem.Text=="")
                {
                    TDistrict = "";
                    TState = "";
                }
                else
                {
                    TDistrict = (CmbTDistrict.SelectedItem).ToString();
                    TState = (CmbTState.SelectedItem).ToString();

                }
              
                string PDistrict = (CmbPDistrict.SelectedItem).ToString();
                string PState = (CmbPState.SelectedItem).ToString();
                if ((CmbBlood.SelectedItem).ToString() == "Select Group")
                {
                    bloodgrp = "";
                }
                else
                {
                    bloodgrp = (CmbBlood.SelectedItem).ToString();
                }
                string Religion;
                if (CmbReligion.SelectedItem.Text == "Select")
                {
                    Religion = "";
                }
                else
                {
                    Religion = (CmbReligion.SelectedItem).ToString();
                }
                string Ethnicity = (CmbEthnicity.SelectedItem).ToString();
                string issueDistrict = (CmbIssueDistrict.SelectedItem).ToString();
                int issuedistrictid = Convert.ToInt32(CmbIssueDistrict.SelectedValue);
                int Pstateid = Convert.ToInt32(CmbPState.SelectedValue);
                int PDistrictid = Convert.ToInt32(CmbPDistrict.SelectedValue);

                if (CmbTState.SelectedItem.Text == "Select Province" || CmbTState.SelectedItem.Text == "")
                {
                    Tstateid = 0;
                    TDistrictid = 0;
                }
                else
                {
                    Tstateid = Convert.ToInt32(CmbTState.SelectedValue);
                    TDistrictid = Convert.ToInt32(CmbTDistrict.SelectedValue);
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
                   // lblerrorRep.Text = "Couldn't upload the file! Please try latter.";

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
                   // lblerrorRep.Text = "Couldn't upload the file! Please try latter.";
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
                   // lbldig.Text = "Couldn't upload the file! Please try latter.";
                    filePathSignature = "";
                }



                foreach (GridViewRow row in grvStudentDetails.Rows) //for education
                {

                    string clgname = (row.Cells[1].FindControl("txtSchool") as TextBox).Text;
                    string degree = (row.Cells[2].FindControl("txtdegree") as TextBox).Text;
                    string percent = (row.Cells[3].FindControl("txtdivision") as TextBox).Text;
                    string majorSubject = (row.Cells[4].FindControl("txtmajor") as TextBox).Text;
                    string edudate = ((row.Cells[5].FindControl("txtyear") as TextBox).Text);

                     string fileName = (row.FindControl("TextBox3") as TextBox).Text;//for image name
                    string base64String = (row.FindControl("hfFileByte") as HiddenField).Value;
                    byte[] bytes = Convert.FromBase64String(base64String);

                    FileUpload fu = (FileUpload)row.FindControl("fuUpload");
                    string imagepath = Server.MapPath("../../images/" + System.Guid.NewGuid() +  fileName);

                    //fu.SaveAs(imagepath);
                  
                    string imagepath1 = Convert.ToBase64String(bytes);
                    string hidden = imagepath1;

                    String EXT = System.IO.Path.GetExtension(imagepath);//get file extension

                    string srno = ((row.Cells[8].FindControl("txtSerial") as TextBox).Text);
                    bool SNO = blu.CheckSerialNumber(srno);
                  
                    if (hidden != string.Empty)
                    {
                            if (SNO != true)
                            {
                               
                                File.WriteAllBytes(imagepath, bytes);
                                blu.insertedu(Pid, clgname, degree, percent, percent, edudate, majorSubject, fileName, imagepath, EXT);
                            }
                            else
                            {
                                blu.deleteEducation(int.Parse(srno));

                                File.WriteAllBytes(imagepath, bytes);
                                blu.insertedu(Pid, clgname, degree, percent, percent, edudate, majorSubject, fileName, imagepath, EXT);
                            }
                    }
                    else
                    {
                            if (clgname == "" && degree == "" && percent == "" && percent == "" && edudate == "" && majorSubject == "" && fileName == "" && EXT == "")
                            {

                            }
                            else if (hidden == string.Empty)
                            {
                                if (SNO != true)
                                {

                                    imagepath = "";
                                    fileName = "";
                                    EXT = "";
                                    blu.insertedu(Pid, clgname, degree, percent, percent, edudate, majorSubject, fileName, imagepath, EXT);
                                }
                                else
                                {
                                    blu.updateEdu(Pid, clgname, degree, percent, percent, edudate, majorSubject, int.Parse(srno));
                                }
                            }
                    }
                }


                foreach (GridViewRow row in GridView1.Rows)//for training
                {
                    string Title = (row.Cells[1].FindControl("txttitle") as TextBox).Text;
                    string organization = (row.Cells[2].FindControl("txtorganization") as TextBox).Text;
                    string place = ((row.Cells[3].FindControl("txtplace") as TextBox).Text);
                    string days = ((row.Cells[4].FindControl("txtdays") as TextBox).Text);
                    string startdate = ((row.Cells[5].FindControl("txtstartdate") as TextBox).Text);
                    string enddate = ((row.Cells[6].FindControl("txtenddate") as TextBox).Text);

                    string serialno = ((row.Cells[9].FindControl("txtserial") as TextBox).Text);
                    bool SNO = blu.CheckTrainingSerialNumber(serialno);

                    string fileNameT = (row.FindControl("txtFilename") as TextBox).Text;//for image name

                    string base64String = (row.FindControl("TFileByte") as HiddenField).Value;
                    byte[] bytes = Convert.FromBase64String(base64String);
                    string imagepath = Server.MapPath("../../images/" + System.Guid.NewGuid() + fileNameT);

                    String EXT = System.IO.Path.GetExtension(imagepath);//get file extension

                    string imagepath1 = Convert.ToBase64String(bytes);
                    string hidden = imagepath1;
                    if (hidden != string.Empty)
                    {
                        if (SNO != true)
                        {
                            File.WriteAllBytes(imagepath, bytes);
                            blu.insertTraining(Pid, organization, place, startdate, enddate, Title, days, fileNameT, imagepath, EXT);
                        }
                        else
                        {
                            blu.deleteTraining(int.Parse(serialno));
                            File.WriteAllBytes(imagepath, bytes);
                            blu.insertTraining(Pid, organization, place, startdate, enddate, Title, days, fileNameT, imagepath, EXT);
                        }

                    }
                    else
                    {
                            if (organization == "" && place == "" && startdate == "" && enddate == "" && Title == "" && days == "" && fileNameT == "" && EXT == "")
                            {

                            }
                            else if (hidden == string.Empty)
                            {
                                    if (SNO != true)
                                    {
                                        fileNameT = "";
                                        imagepath = "";
                                        EXT = "";
                                        blu.insertTraining(Pid, organization, place, startdate, enddate, Title, days, fileNameT, imagepath, EXT);
                                    }
                                    else
                                    {
                                        blu.updateTraining(Pid, organization, place, startdate, enddate, Title, days, int.Parse(serialno));
                                    }
                             }
                    }
                }
              
                foreach (GridViewRow row in GridView2.Rows)//for past work 
                {
                    string organization = (row.Cells[1].FindControl("txtorganization") as TextBox).Text;
                    string designation = (row.Cells[2].FindControl("txtPost") as TextBox).Text;
                    string salary = ((row.Cells[3].FindControl("txtSalary") as TextBox).Text);
                    string startdate = ((row.Cells[4].FindControl("txtstartdate") as TextBox).Text);
                    string enddate = ((row.Cells[5].FindControl("txtenddate") as TextBox).Text);
                    string Contact = ((row.Cells[6].FindControl("txtContact") as TextBox).Text);

                     string SNo = ((row.Cells[9].FindControl("txtserial") as TextBox).Text);
                     bool SNO = blu.CheckPWSerialNumber(SNo);

                    string fileNamew = (row.FindControl("Filename") as TextBox).Text;//for image name

                    string base64String = (row.FindControl("PWFileByte") as HiddenField).Value;
                    byte[] bytes = Convert.FromBase64String(base64String);
                    string imagepath = Server.MapPath("../../images/" + System.Guid.NewGuid() + fileNamew);

                    String EXT = System.IO.Path.GetExtension(imagepath);//get file extension

                    string imagepath1 = Convert.ToBase64String(bytes);
                    string hidden = imagepath1;

                    if (hidden != string.Empty)
                    {
                            if (SNO != true)
                            {
                                File.WriteAllBytes(imagepath, bytes);
                                blu.insertJobExperience(Pid, organization, designation, startdate, enddate, salary, Contact, fileNamew, imagepath, EXT);
                            }
                            else
                            {
                                blu.deleteWorkExp(int.Parse(SNo));
                                File.WriteAllBytes(imagepath, bytes);
                                blu.insertJobExperience(Pid, organization, designation, startdate, enddate, salary, Contact, fileNamew, imagepath, EXT);
                            }
                    }
                    else
                    {
                        if (organization == "" && designation == "" && startdate == "" && enddate == "" && salary == "" && Contact == "" && fileNamew == "" && EXT=="")
                            {

                            }
                            else if (hidden == string.Empty)
                            {
                                if (SNO != true)
                                {
                                    fileNamew = "";
                                    imagepath = "";
                                    EXT = "";
                                    blu.insertJobExperience(Pid, organization, designation, startdate, enddate, salary, Contact, fileNamew, imagepath, EXT);
                                }
                                else
                                {
                                    blu.updateJobExperience(Pid, organization, designation, startdate, enddate, salary, Contact, int.Parse(SNo));
                                }

                            }  
                    }
                   
                }
                string admin = "admin";
                string description = "";
                blu.CreateEmpGeneralInfo(txtEmployeeId.Text, filePathimage, title, EMP_FIRSTNAME.Text, EMP_MIDDLENAME.Text, EMP_LASTNAME.Text, gender, Mstatus, Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtJoindate.Text), EMP_MOBILE.Text, EMP_PHONE.Text, EMP_CITIZENSHIPNO.Text, txtPemail.Text, txtEmployeeId.Text, EMP_PASSWORD.Text, padd, TSTREET.Text, TDistrict, TState, PSTREET.Text, PDistrict, PState, pcountry, bloodgrp, txtAlrg.Text, MED_CON.Text, DOCTOR.Text, DOCTOR_CONTACT.Text, DOCTOR1.Text, DOCTOR_CONTACT1.Text, txtMun1.Text, txtWard1.Text, txtVillage1.Text, txtMun.Text, txtWard.Text, txtVillage.Text, Ethnicity, issueDistrict, spouse, txtChildren.Text, fathername, mothername, grandname, txtOccupation.Text, Son, Daughter, Religion, ReligionId, Age, txtPassport.Text, ethnicityid, issuedistrictid, Pstateid, PDistrictid, Tstateid, TDistrictid, bloodgroupid);
                blu.InsertEmpRelativeInfo(txtEmployeeId.Text, Emergency_Name.Text, Emergency_Address.Text, Emergency_Relation.Text, Emergency_Contact.Text, filePathRelation, txtEmgMobile.Text);
                blu.CreateOfficialInfo(degid, modeid, deptid, branchid, statid, gradeid, roomno, txtOfcEmail.Text, extno, cardno, vehicleno, cardExpirydate, licenceexpirydate, licenceno, Permanent, Resign_Date, Probation, Probation1, probationMFrom, probationMTo, txtEmployeeId.Text, citnum, epan, pfnum, checkWebLogin, Pid, isOT, fileno, bankid, (CmbBank.SelectedItem.ToString()), BankbranchId, bankAC, suspensionFrom, suspensionTo, dischargeDate, dissmissDate, Contract, Contract1, Trainee, Trainee1, txtSalary.Text, Laid_off, txtSev.Text, txtSecurity.Text, isAttendance, txtAmount.Text, filePathSignature, CmbProjectDistrict.SelectedItem.ToString(), Convert.ToInt32(CmbUsertype.SelectedValue), (CmbUsertype.SelectedItem.ToString()), StatusDate, StatusDateTo, txtremarks.Text, txtGratuity.Text, TypeDateFrom, TypeDateTo, (CmbType.SelectedItem.ToString()), typeid);

                if (CmbStatus.SelectedItem.Text == "Retired" ||CmbStatus.SelectedItem.Text == "Suspension"|| CmbStatus.SelectedItem.Text == "Termination" || CmbStatus.SelectedItem.Text == "Dismissed" || CmbStatus.SelectedItem.Text == "Resigned" || CmbStatus.SelectedItem.Text == "Laid_off")
                {
                    if(StatusDateTo=="")
                    {
                        StatusDateTo = DateTime.Now.ToString();
                        blu.insertceapworkHistory(Pid, Convert.ToInt32(CmbProjectDistrict.SelectedValue), (CmbProjectDistrict.SelectedItem.ToString()), branchid, (CmbBranch.SelectedItem.ToString()), degid, (CmbDesignation.SelectedItem.ToString()), StatusDate, StatusDateTo, txtSalary.Text, 0, admin, description);
                    }
                    else
                    {
                        blu.insertceapworkHistory(Pid, Convert.ToInt32(CmbProjectDistrict.SelectedValue), (CmbProjectDistrict.SelectedItem.ToString()), branchid, (CmbBranch.SelectedItem.ToString()), degid, (CmbDesignation.SelectedItem.ToString()), StatusDate, StatusDateTo, txtSalary.Text, 0, admin, description);
                    }
                  
                   
                }
                else
                {

                }
                blu.deleteLeavemanagement(Pid);
                foreach (GridViewRow row in GVLeave.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        RadioButton rbRow = (row.Cells[2].FindControl("rbPer") as RadioButton);
                        if (rbRow.Checked)
                        {
                            string leaveid = ((row.Cells[0].FindControl("txtLeaveId") as Label).Text);
                            int id = Convert.ToInt32(leaveid);
                           
                            blu.insertLeaveManagement(Pid, id, 0, 0);
                        }
                        else
                        {

                        }
                    }
                }
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Employee Updated Successfully').then((value) => { window.location ='Employees.aspx'; });", true);
                }
          
        }

        protected void CmbPState_SelectedIndexChanged(object sender, EventArgs e)
        {
            int StateId = Convert.ToInt32(CmbPState.SelectedValue);
            DataTable dt = blu.getDistrict(StateId);

            CmbPDistrict.DataSource = dt;
            CmbPDistrict.DataTextField = "DistrictName";
            CmbPDistrict.DataValueField = "DistrictId";
            CmbPDistrict.DataBind();
        }

        protected void CmbTState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbTState.SelectedItem.Text=="Select Province")
            {
                CmbTDistrict.SelectedItem.Text = "Select District";
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "alertscipt", "swal('Oops!','No district with that Province !!!','warning')", true);
                return;
            }
            else
            {

                //CmbTDistrict.Enabled = true;
            int Stateid = Convert.ToInt32(CmbTState.SelectedValue);
            DataTable dtTD = blu.getDistrict(Stateid);
            if (dtTD.Rows.Count > 0)
            {
                CmbTDistrict.DataSource = dtTD;
                CmbTDistrict.DataTextField = "DistrictName";
                CmbTDistrict.DataValueField = "DistrictId";
                CmbTDistrict.DataBind();
               //CmbTDistrict.Items.Insert(0, "Select District");
            }
         }
        }

        protected void chkCopy_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbType.SelectedItem.Text == "Permanent")
            {
                txtFrom.Visible = true;
                txtTo.Visible = false;
            }
            else if (CmbType.SelectedItem.Text == "Contract" || CmbType.SelectedItem.Text == "Trainee" || CmbType.SelectedItem.Text == "Probation")
            {
                txtFrom.Visible = true;
                txtTo.Visible = true;
            }
            else if (CmbType.SelectedItem.Text == "Temporary" || CmbType.SelectedItem.Text == "Casual")
            {
                txtFrom.Visible = false;
                txtTo.Visible = false;
            }
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
            else
            {
                CmbBank.Visible = false;
                txtAccno.Visible = false;
                lblBank.Visible = false;
                lblAccount.Visible = false;
            }
        }

       
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                lblPrmAmt.Visible = true;
                txtAmount.Visible = true;
            }
            else
            {
                lblPrmAmt.Visible = false;
                txtAmount.Visible = false;
            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked)
            {
                lblPrmAmt.Visible = false;
                txtAmount.Visible = false;
            }
            else
            {
                lblPrmAmt.Visible = true;
                txtAmount.Visible = true;

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

        protected void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCash.Checked)
            {
                CmbBank.Visible = false;
                txtAccno.Visible = false;
                lblBank.Visible = false;
                lblAccount.Visible = false;

            }
            else
            {
                CmbBank.Visible = true;
                txtAccno.Visible = true;
                lblBank.Visible = true;
                lblAccount.Visible = true;
            }
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

        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
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
           
        }
      
        protected void UploadImage_Click(object sender, EventArgs e)
        {
           
            SetRowData();
            SetPreviousData();
          
        }
        protected void btnTrImage_Click(object sender, EventArgs e)
        {
            SetRowDataTraining();
            SetPreviousDataTraining();
        }
        protected void btnWorkImage_Click(object sender, EventArgs e)
        {
            SetRowDataExp();
            SetPreviousDataExp();
        }

        protected void GVLeave_RowDataBound(object sender, GridViewRowEventArgs e)
        {

                int Empid = Convert.ToInt32(txtEmployeeId.Text);
                DataTable dtP = blu.getPid(Empid);
                int pid = Convert.ToInt32(dtP.Rows[0]["PID"].ToString());
               
                    foreach (GridViewRow row in GVLeave.Rows)
                    {
                        string leaveid = ((row.Cells[0].FindControl("txtLeaveId") as Label).Text);
                        DataTable dtL = blu.getLeavebyId(pid, int.Parse(leaveid));
                        if(dtL.Rows.Count>0)
                        {
                            RadioButton rbRow = (row.Cells[2].FindControl("rbPer") as RadioButton);
                           rbRow.Checked = true;
                        }
                        else
                        {
                            RadioButton rbRow1 = (row.Cells[2].FindControl("rbPer1") as RadioButton);
                           rbRow1.Checked = true;
                        }



                        //if (row.RowType == DataControlRowType.DataRow)
                        //{

                        //    DataTable dt = blu.getLeaveInfo();
                        //    DataTable dtL = blu.getLeavebyId(pid);

                        //    string leaveid = dt.Rows[i]["LEAVE_ID"].ToString();
                        //    string LeaveId = dtL.Rows[i]["LEAVEID"].ToString();

                        //    if (leaveid == LeaveId)
                        //    {

                        //        RadioButton rbRow = (row.Cells[2].FindControl("rbPer") as RadioButton);
                        //        rbRow.Checked = true;
                        //    }
                        //    else
                        //    {
                        //        RadioButton rbRow1 = (row.Cells[2].FindControl("rbPer1") as RadioButton);
                        //        rbRow1.Checked = true;
                        //    }
                        //    //}
                        //}
                        //else
                        //{

                        //}
                   // }
                }
        }

        protected void grvStudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[9].Visible = false;
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[10].Visible = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[10].Visible = false;
        }
    }
}
