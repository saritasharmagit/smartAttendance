using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddLeaveSetup : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int leavetype;
        int maxacc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtAccumulation.Enabled = false;
            }
        }
           protected void rbExpire_CheckedChanged(object sender, EventArgs e)
        {
            txtAccumulation.Enabled = false;
        }

        protected void rbAccu_CheckedChanged(object sender, EventArgs e)
        {
            txtAccumulation.Enabled = true;
        }

        protected void rbService_CheckedChanged(object sender, EventArgs e)
        {
            txtAccumulation.Enabled = false;
        }
        
        protected void BtnSave_Click(object sender, EventArgs e)
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
          
           
            string leavename = txtLeaveName.Text;
            
            int leavedays = Convert.ToInt32(txtDays.Text);
            if (rbAccu.Checked)
            {
                maxacc = Convert.ToInt32(txtAccumulation.Text);
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
            int monthly = chkOthers.Checked ? 1 : 0;

            int maxdays = Convert.ToInt32(txtMaxDays.Text);
            //int iscashable = 0;
            //if (rbCashable.Checked)
            //{
            //    iscashable = 1;
            //}
            //else
            //{
            //    iscashable = 0;
            //}
            int iscashable = rbCashable.Checked ? 1 : 0;
            int service = Convert.ToInt32(txtService.Text);
            int must_all_leave = chkOthers1.Checked ? 1 : 0;
            int leave_id = 0;
            int status =  rbStatus.Checked ? 1 : 0;

            int i = blu.SaveLeave(leavename, leavetype, leavedays, maxacc, monthly, maxdays, iscashable, service, must_all_leave, leave_id, status);
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Leave saved Successfully').then((value) => { window.location ='LeaveSetup.aspx'; });", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLeaveSetup.aspx");
        }
    }
}
   