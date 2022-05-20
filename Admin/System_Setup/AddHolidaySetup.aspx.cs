using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddHolidaySetup : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HolidaySetup.aspx");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtStartDate.Text == "" || txtHolidayname.Text == "" || txtnumber.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Field cannot be emptied !!!','warning')</script>");
                return;
            }

            int i = blu.CreateHolidaySetup(txtHolidayname.Text, Convert.ToDateTime(txtStartDate.Text), Convert.ToInt32(txtnumber.Text), holidaytype, rbStatus.Checked ? 1 : 0, chkFemale.Checked ? 1 : 0);
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Holiday Setup saved Successfully').then((value) => { window.location ='HolidaySetup.aspx'; });", true);
            }
        }
        int holidaytype;
        protected void rbStandard_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStandard.Checked == true)
            {
                holidaytype = 1;
                rbSpecific.Checked = false;
                rbUnofficial.Checked = false;
            }
        }

        protected void rbSpecific_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSpecific.Checked == true)
            {
                holidaytype = 2;
                rbStandard.Checked = false;
                rbUnofficial.Checked = false;
            }
        }

        protected void rbUnofficial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnofficial.Checked == true)
            {
                holidaytype = 0;
                rbSpecific.Checked = false;
                rbStandard.Checked = false;
            }
        }
    }
}