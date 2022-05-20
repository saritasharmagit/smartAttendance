using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class EditBranchSetup : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int stat = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int branchid = Convert.ToInt32(Request.QueryString["BRANCH_ID"].ToString());
                HiddenField1.Value = branchid.ToString();
                DataTable dta = blu.GetbranchbybranchId(branchid);

                txtBranchCode.Text = Request.QueryString["BRANCH_CODE"].ToString();
                txtBranchName.Text = Request.QueryString["BRANCH_NAME"].ToString();
                txtStartDate.Text = Request.QueryString["ValidFrom"].ToString();
                txtEndDate.Text = Request.QueryString["ValidTo"].ToString();
                txtAbbr.Text = Request.QueryString["ABBREVIATION"].ToString();
                stat = Convert.ToInt32(Request.QueryString["sta"].ToString());

                DateTime oldvalidDate = Convert.ToDateTime(txtEndDate.Text);

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
                //txtEndDate.Enabled = true;
                //nepaliDate2.Enabled = true;
                //txtNepaliDate.Enabled = true;
                //txtStartDate.Enabled = true;
            }
        }
        int isoutbranch = 0;
        int serialno = 0;
        string BType = "";
      
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string oldvalidDate = Request.QueryString["ValidTo"].ToString();
            string newvalidDate = txtEndDate.Text;

            if (!chkExtend.Checked)
            
            //if (oldvalidDate == newvalidDate)
            {
                int IsExtend = 0;

                blu.UpdateBranchSetupWithoutExtend(txtBranchName.Text, isoutbranch, serialno, txtBranchCode.Text, rbStatus.Checked ? 1 : 0, BType, Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text), IsExtend, Convert.ToInt32(HiddenField1.Value), txtAbbr.Text);
            }
            else
            {
                int IsExtend = 1;
                blu.UpdateBranchSetup(txtBranchName.Text, isoutbranch, serialno, txtBranchCode.Text, rbStatus.Checked ? 1 : 0, BType, Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(oldvalidDate), IsExtend, Convert.ToDateTime(newvalidDate), Convert.ToInt32(HiddenField1.Value),txtAbbr.Text);
            }
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Project Updated Successfully').then((value) => { window.location ='BranchSetup.aspx'; });", true);
            }
        }

        protected void BtnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("BranchSetup.aspx");
        }

        protected void chkExtend_CheckedChanged1(object sender, EventArgs e)
        {
            DateTime oldvalidDate = Convert.ToDateTime(txtEndDate.Text);
            if (chkExtend.Checked)
            {
                txtNepaliDate.Enabled = false;
                txtStartDate.Enabled = false;
                txtEndDate.Enabled = true;
                nepaliDate2.Enabled = true;
               
            }
            else
            {
                txtNepaliDate.Enabled = true;
                txtStartDate.Enabled = true;
                txtEndDate.Enabled = true;
                nepaliDate2.Enabled = true;
               
            }
        }
        }
        }
    
