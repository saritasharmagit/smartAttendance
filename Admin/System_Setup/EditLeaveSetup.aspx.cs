using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class EditLeaveSetup : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int stat = 0;
        int leavetype = 0;
        int cashable = 0;
        int other = 0;
        int Leavetype;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int leaveid = Convert.ToInt32(Request.QueryString["LEAVE_ID"].ToString());
                HiddenField1.Value = leaveid.ToString();
                DataTable dta = blu.GetLeavebyleaveId(leaveid);
                txtLeaveName.Text = dta.Rows[0]["LEAVE_NAME"].ToString();
                txtDays.Text = dta.Rows[0]["LEAVE_DAYS"].ToString();
                txtMaxDays.Text = dta.Rows[0]["MAX_DAYS_AT_A_TIME"].ToString();
                txtService.Text = dta.Rows[0]["service_period"].ToString();

                leavetype = Convert.ToInt32(dta.Rows[0]["LEAVE_TYPE"].ToString());
                if (leavetype == 0)
                {
                    rbExpire.Checked = true;
                    rbAccu.Checked = false;
                    rbService.Checked = false;
                    txtAccumulation.Enabled = false;
                }
                else if (leavetype == 1)
                {
                    rbExpire.Checked = false;
                    rbAccu.Checked = true;
                    rbService.Checked = false;
                    txtAccumulation.Enabled = true;
                    txtAccumulation.Text = dta.Rows[0]["Leave_Max"].ToString();
                }
                else
                {
                    rbExpire.Checked = false;
                    rbAccu.Checked = false;
                    rbService.Checked = true;
                    txtAccumulation.Enabled = false;

                }
                cashable = Convert.ToInt32(dta.Rows[0]["ISCashable"].ToString());
                if (cashable == 1)
                {
                    rbCashable.Checked = true;
                    rbCashable1.Checked = false;
                }
                else
                {
                    rbCashable.Checked = false;
                    rbCashable1.Checked = true;
                }
                other = Convert.ToInt32(dta.Rows[0]["mustexhaustotherleaves"].ToString());//for 0 or 1 value pass in others
                if (other == 1)
                {
                    chkOthers.Checked = true;
                    chkOthers1.Checked = false;
                }
                else if (other == 0)
                {
                    chkOthers.Checked = false;
                    chkOthers1.Checked = true;
                }
                else
                {
                    chkOthers.Checked = false;
                    chkOthers1.Checked = false;
                }
                stat = Convert.ToInt32(dta.Rows[0]["status"].ToString());
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

        protected void rbExpire_CheckedChanged(object sender, EventArgs e)
        {
            Leavetype = 1;
            rbAccu.Checked = false;
            rbService.Checked = false;
            txtAccumulation.Enabled = false;
        }

        protected void rbAccu_CheckedChanged(object sender, EventArgs e)
        {
            Leavetype = 2;
            rbExpire.Checked = false;
            rbService.Checked = false;
            txtAccumulation.Enabled = true;
        }

        protected void rbService_CheckedChanged(object sender, EventArgs e)
        {

            Leavetype = 3;
            rbExpire.Checked = false;
            rbAccu.Checked = false;
            txtAccumulation.Enabled = false;
        }


        int maxacc;

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (txtLeaveName.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(Updtpnl.GetType(), "Scripts", "<script>swal('Ooops !!!','Leave Name Cannot Be Empty ','warning')</script>");
                return;
            }
            if (txtMaxDays.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(Updtpnl.GetType(), "Scripts", "<script>swal('Ooops !!!','Max Days At A Time  Cannot Be Empty ','warning')</script>");
                return;
            }
            if (rbAccu.Checked)
            {
                if (txtAccumulation.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Updtpnl, this.GetType(), "alertscipt", "swal('Ooops !!!','Accumulation Days Cannot be Empty after selecting Accumulative in Leave Type.','warning')", true);
                    return;
                }
                else
                {
                    maxacc = Convert.ToInt32(txtAccumulation.Text);
                }
                leavetype = 1;
            }
            else if (rbExpire.Checked)
            {
                maxacc = 0;
                leavetype = 0;
            }
            else
            {
                maxacc = 0;
                leavetype = 2;

            }
            string leavename = (txtLeaveName.Text).ToString();
            int days = Convert.ToInt32(txtDays.Text);
            int monthly = chkOthers.Checked ? 1 : 0;
            int maxdays = Convert.ToInt32(txtMaxDays.Text);
            int iscashable = rbCashable.Checked ? 1 : 0;
            int service = Convert.ToInt32(txtService.Text);
            int must_all_leave = chkOthers1.Checked ? 1 : 0;
            int leave_id = Convert.ToInt32(HiddenField1.Value);
            int status = rbStatus.Checked ? 1 : 0;


            int i = blu.SaveLeave(leavename, leavetype, days, maxacc, monthly, maxdays, iscashable, service, must_all_leave, leave_id, status);
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('LeaveSetup Updated Successfully').then((value) => { window.location ='LeaveSetup.aspx'; });", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveSetup.aspx");
        }
    }
}