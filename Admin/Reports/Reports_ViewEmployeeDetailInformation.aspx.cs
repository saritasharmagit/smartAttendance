using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_ViewEmployeeDetailInformation : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            int emp_id = int.Parse(Server.UrlDecode(Request.QueryString["emp_id"].ToString()));
            lblid.Text = emp_id.ToString();


            int empIdd = Convert.ToInt32(emp_id);//for image

            int empid = Convert.ToInt32(emp_id);
            DataTable dt = blu.getPid(empid);
            int pid = Convert.ToInt32(dt.Rows[0]["PID"].ToString());

            DataSet ds = blu.LoadPhoto(empIdd);
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

                        PersImage.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);

                    }
                    else
                    {
                        PersImage.ImageUrl = null;
                    }
                }
                else
                {
                    PersImage.ImageUrl = null;
                }
            }
            ds.Tables.Clear();

            DataSet dsI = blu.LoadRelativePhoto(empIdd);
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

                        Imageemg.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);

                    }
                    else
                    {
                        Imageemg.ImageUrl = null;
                    }
                }
                else
                {
                    Imageemg.ImageUrl = null;
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

                        Imageofc.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);

                    }
                    else
                    {
                        Imageofc.ImageUrl = null;
                    }
                }
                else
                {
                    Imageofc.ImageUrl = null;
                }
            }
            dsO.Tables.Clear();


            DataTable dt1 = blu.Education(pid);//for education
            if (dt1.Rows.Count == 0)
            {

            }
            else
            {
                grvEducation.DataSource = dt1;
                grvEducation.DataBind();
            }



            DataTable dt2 = blu.Training(pid);
            grvTraining.DataSource = dt2;
            grvTraining.DataBind();

            DataTable dt3 = blu.jobexperience(pid);
            grvworkexperience.DataSource = dt3;
            grvworkexperience.DataBind();

            DataTable dtl = blu.getLeaveInfobyId(pid);//for leave management
            if (dtl.Rows.Count > 0)
            {
                grvLeave.DataSource = dtl;
                grvLeave.DataBind();
            }
            else
            {

            }

            DataTable dt4 = blu.getCeaphistory(pid);//for ceapred history
            grvHistory.DataSource = dt4;
            grvHistory.DataBind();


            DataTable dt6 = blu.GetEmpbyId(empid);
            // lblid.Text = dt6.Rows[0]["EMP_ID"].ToString();
            lblname.Text = dt6.Rows[0]["emp_Fullname"].ToString();
            lblgender.Text = dt6.Rows[0]["GENDER"].ToString();
            lblRelation.Text = dt6.Rows[0]["MARITALSTATUS"].ToString();
            lblChildren.Text = dt6.Rows[0]["Children_Number"].ToString();
            lblmob.Text = dt6.Rows[0]["EMP_MOBILE"].ToString();
            lblemail.Text = dt6.Rows[0]["EMP_PEMAIL"].ToString();

            DateTime result = Convert.ToDateTime(dt6.Rows[0]["EMP_DOB"].ToString());
            lbldob.Text = result.ToString("yyyy-MM-dd");

            DateTime result1 = Convert.ToDateTime(dt6.Rows[0]["EMP_JOINDATE"].ToString());
            lbldate.Text = result1.ToString("yyyy-MM-dd");

            lblpassword.Text = dt6.Rows[0]["EMP_PASSWORD"].ToString();
            string pass = lblpassword.Text;//for hide password
            lblpassword.Text = "";
            foreach (char ch in pass)
            {
                lblpassword.Text += "*";
            }

            lblContperson.Text = dt6.Rows[0]["NAME"].ToString();
            Labelrelation.Text = dt6.Rows[0]["RELATION"].ToString();
            lblAddress.Text = dt6.Rows[0]["ADDRESS"].ToString();
            lblContactnumber.Text = dt6.Rows[0]["Emergency_Contact"].ToString();
            lblMobile.Text = dt6.Rows[0]["MOBILE"].ToString();

            lblTprov.Text = dt6.Rows[0]["EMP_TZONE"].ToString();
            lblTDist.Text = dt6.Rows[0]["EMP_TDISTRICT"].ToString();
            lblTCity.Text = dt6.Rows[0]["EMP_TSTREET"].ToString();
            lblTmun.Text = dt6.Rows[0]["TVDC_municipality"].ToString();
            lblTWard.Text = dt6.Rows[0]["TWard_Number"].ToString();
            lblTVillage.Text = dt6.Rows[0]["TVillage_Tole"].ToString();

            lblPProvince.Text = dt6.Rows[0]["EMP_PZONE"].ToString();
            lblPDistrict.Text = dt6.Rows[0]["EMP_PDISTRICT"].ToString();
            lblPCity.Text = dt6.Rows[0]["EMP_PSTREET"].ToString();
            lblPmun.Text = dt6.Rows[0]["PVDC_municipality"].ToString();
            lblPWard.Text = dt6.Rows[0]["PWard_Number"].ToString();
            lblPVillage.Text = dt6.Rows[0]["PVillage_Tole"].ToString();
            lblEthnicity.Text = dt6.Rows[0]["Ethnicity"].ToString();

            lblReligion.Text = dt6.Rows[0]["Religion"].ToString();
            lblFather.Text = dt6.Rows[0]["Father_Name"].ToString();
            lblFatherOccu.Text = dt6.Rows[0]["Father_Occupation"].ToString();
            //lblSon.Text = dt6.Rows[0]["Son_Number"].ToString();
            //lblDaughter.Text = dt6.Rows[0]["Daughter_Number"].ToString();
            lblSpouse.Text = dt6.Rows[0]["Spouse_Name"].ToString();
            lblMother.Text = dt6.Rows[0]["Mother_Name"].ToString();
            lblgrand.Text = dt6.Rows[0]["Grandfather_Name"].ToString();
            lblCitizenDist.Text = dt6.Rows[0]["CitizenshipDistrict"].ToString();
            lblPassport.Text = dt6.Rows[0]["Passport_Number"].ToString();
            lblTelephone.Text = dt6.Rows[0]["EMP_PHONE"].ToString();
            lblDeg.Text = dt6.Rows[0]["DEG_NAME"].ToString();

            lbltypeFrom.Text = dt6.Rows[0]["Type_fromDate"].ToString();
            lbltypeTo.Text = dt6.Rows[0]["Type_toDate"].ToString();

            lblType.Text = dt6.Rows[0]["EmployeeType_Name"].ToString();
            if (lblType.Text == "Permanent")
            {
                lbltypeFrom.Visible = true;
                lbltypeTo.Visible = false;
                lblTypefromdate.Visible = true;
                lblTypeTodate.Visible = false;
            }
            else if (lblType.Text == "Temporary")
            {
                lbltypeFrom.Visible = false;
                lbltypeTo.Visible = false;
                lblTypefromdate.Visible = false;
                lblTypeTodate.Visible = false;
            }
            else if (lblType.Text == "Contract")
            {
                lbltypeFrom.Visible = true;
                lbltypeTo.Visible = true;
                lblTypefromdate.Visible = true;
                lblTypeTodate.Visible = true;
            }
            else if (lblType.Text == "Casual")
            {
                lbltypeFrom.Visible = true;
                lbltypeTo.Visible = true;
                lblTypefromdate.Visible = true;
                lblTypeTodate.Visible = true;
            }
            else if (lblType.Text == "Trainee")
            {
                lbltypeFrom.Visible = true;
                lbltypeTo.Visible = true;
                lblTypefromdate.Visible = true;
                lblTypeTodate.Visible = true;
            }
            else if (lblType.Text == "Probation")
            {
                lbltypeFrom.Visible = true;
                lbltypeTo.Visible = true;
                lblTypefromdate.Visible = true;
                lblTypeTodate.Visible = true;
            }


            lblfromdate.Text = dt6.Rows[0]["Retired_Date"].ToString();
            lblTodate.Text = dt6.Rows[0]["Retired_DateTo"].ToString();

            if (Convert.ToInt32(dt6.Rows[0]["STATUS_ID"].ToString()) == 0)
            {
                lblStatus.Text = "Retired";
                lblFromstatus.Visible = true;
                lblTostatus.Visible = false;
                lblfromdate.Visible = true;
                lblTodate.Visible = false;
            }
            else if (Convert.ToInt32(dt6.Rows[0]["STATUS_ID"].ToString()) == 1)
            {
                lblStatus.Text = "Working";
                lblFromstatus.Visible = false;
                lblTostatus.Visible = false;
            }
            else if (Convert.ToInt32(dt6.Rows[0]["STATUS_ID"].ToString()) == 2)
            {
                lblStatus.Text = "Suspension";
                lblFromstatus.Visible = true;
                lblTostatus.Visible = true;
                lblfromdate.Visible = true;
                lblTodate.Visible = true;
            }
            else if (Convert.ToInt32(dt6.Rows[0]["STATUS_ID"].ToString()) == 3)
            {
                lblStatus.Text = "Termination";
                lblFromstatus.Visible = true;
                lblTostatus.Visible = false;
                lblfromdate.Visible = true;
                lblTodate.Visible = false;

            }
            else if (Convert.ToInt32(dt6.Rows[0]["STATUS_ID"].ToString()) == 4)
            {
                lblStatus.Text = "Dismissed";
                lblFromstatus.Visible = true;
                lblTostatus.Visible = false;
                lblfromdate.Visible = true;
                lblTodate.Visible = false;

            }
            else if (Convert.ToInt32(dt6.Rows[0]["STATUS_ID"].ToString()) == 5)
            {
                lblStatus.Text = "Resigned";
                lblFromstatus.Visible = true;
                lblTostatus.Visible = false;
                lblfromdate.Visible = true;
                lblTodate.Visible = false;
            }
            else if (Convert.ToInt32(dt6.Rows[0]["STATUS_ID"].ToString()) == 6)
            {
                lblStatus.Text = "Laid_off";
                lblFromstatus.Visible = true;
                lblTostatus.Visible = false;
                lblfromdate.Visible = true;
                lblTodate.Visible = false;
            }

            lbldept.Text = dt6.Rows[0]["DEPT_NAME"].ToString();
            lblbranch.Text = dt6.Rows[0]["BRANCH_NAME"].ToString();
            lblUsertype.Text = dt6.Rows[0]["UserType_Name"].ToString();

            lblgrade.Text = dt6.Rows[0]["GRADE_NAME"].ToString();
            lblCitizen.Text = dt6.Rows[0]["EMP_CITIZENSHIPNO"].ToString();
            lblGroup.Text = dt6.Rows[0]["BLOOD_GROUP"].ToString();
            lblMedical.Text = dt6.Rows[0]["MED_CON"].ToString();
            lblDoct.Text = dt6.Rows[0]["DOCTOR"].ToString();
            lblContact.Text = dt6.Rows[0]["DOCTOR_Contact"].ToString();
            lblAllergy.Text = dt6.Rows[0]["ALLERGY"].ToString();
            lblProjectDist.Text = dt6.Rows[0]["ProjectDistrict"].ToString();
            lblSalary.Text = dt6.Rows[0]["BSALARY"].ToString();


            HiddenField1.Value = dt6.Rows[0]["BANK_ID"].ToString();
            if (dt6.Rows[0]["BANK_ID"].ToString() == "Select Bank" || Convert.ToInt32(dt6.Rows[0]["BANK_ID"].ToString()) == 0)
            {
                lblBank.Text = "Cash";
            }
            else
            {
                lblBank.Text = dt6.Rows[0]["BANK_NAME"].ToString();
            }
            lblPF.Text = dt6.Rows[0]["pf_number"].ToString();
            lblCIT.Text = dt6.Rows[0]["cit_number"].ToString();
            lblgratuity.Text = dt6.Rows[0]["Gratuity"].ToString();
            lblAccount.Text = dt6.Rows[0]["bankAC"].ToString();
            lblsecurity.Text = dt6.Rows[0]["Social_Security"].ToString();
            lblSev.Text = dt6.Rows[0]["Severance_No"].ToString();
            lblEpan.Text = dt6.Rows[0]["epan_number"].ToString();
            lblOffEmail.Text = dt6.Rows[0]["OFFEMAIL"].ToString();
            lblusrid.Text = dt6.Rows[0]["EMP_USERID"].ToString();
            lblPremium.Text = dt6.Rows[0]["Premium_Amount"].ToString();

            if (Convert.ToInt32(dt6.Rows[0]["IsAttendance"].ToString()) == 1)
            {
                lblAttendance.Text = "Yes";
            }
            else
            {
                lblAttendance.Text = "No";
            }

            DataTable dta = blu.getPromotion(empid);//getTransferList
            if (dta.Rows.Count > 0)
            {
                DataRow thisRow = (DataRow)dta.Rows[dta.Rows.Count - 1];
                lblPromotedDate.Text = Convert.ToString(thisRow["TDATE"]);
            }
            else
            {
                //Convert.ToDateTime(dt6.Rows[0]["EMP_JOINDATE"].ToString());
                //lblPromotedDate.Text = result1.ToString("yyyy-MM-dd");
            }
            DataTable dtTr = blu.getTransferList(empid);
            if (dtTr.Rows.Count > 0)
            {
                DataRow thisRow = (DataRow)dtTr.Rows[dtTr.Rows.Count - 1];
                lblPromotedDate.Text = Convert.ToString(thisRow["TDATE"]);
            }
            else
            {
                //Convert.ToDateTime(dt6.Rows[0]["EMP_JOINDATE"].ToString());
                //lblPromotedDate.Text = result1.ToString("yyyy-MM-dd");
            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_EmployeeDetailInformation.aspx");
        }
          
        protected void BtnExport_Click(object sender, EventArgs e)
        {
              Response.ClearContent();
                Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewEmployeeDetails.xls");
                Response.ContentType = "application/excel";
                System.IO.StringWriter stringWriter = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

                htw.Write("<div style='PADDING-RIGHT: 10px; PADDING-LEFT: 10px; text-align:left; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
                Panel2.RenderControl(htw);
               // Panel1.RenderControl(htw);
               //divExport.RenderControl(htw);

                grvEducation.RenderControl(htw);
                grvTraining.RenderControl(htw);
                grvworkexperience.RenderControl(htw);
                grvHistory.RenderControl(htw);
                grvLeave.RenderControl(htw);

               // Response.Output.Write(stringWriter.ToString());
                Response.Write(stringWriter.ToString());
                Response.End();
            }
            public override void VerifyRenderingInServerForm(Control control)
            {
            }

        }
    }

