using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class EditHolidaySetup : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int holidaytype = 0;
        int stat = 0;
        int female = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int holidayid = Convert.ToInt32(Request.QueryString["HOLIDAY_ID"].ToString());
                HiddenField1.Value = holidayid.ToString();
                DataTable dta = blu.GetHolidaysetupbyholidayId(holidayid);
                txtHolidayname.Text = Request.QueryString["HOLIDAY_NAME"].ToString();
                txtStartDate.Text = Request.QueryString["HOLIDAY_DATE"].ToString();
                txtnumber.Text = Request.QueryString["HOLIDAY_QTY"].ToString();

                holidaytype = Convert.ToInt32(Request.QueryString["holidayType"].ToString());
                if (holidaytype == 1)
                {
                    rbStandard.Checked = true;
                    rbSpecific.Checked = false;
                    rbUnofficial.Checked = false;
                }
                else if (holidaytype == 2)
                {
                    rbStandard.Checked = false;
                    rbSpecific.Checked = true;
                    rbUnofficial.Checked = false;
                }
                else if (holidaytype == 0)
                {
                    rbStandard.Checked = false;
                    rbSpecific.Checked = false;
                    rbUnofficial.Checked = true;
                }
                stat = Convert.ToInt32(Request.QueryString["sta"].ToString());
                if (stat == 1)
                {
                    rbStatus.Checked = true;
                    rbInActive.Checked = false;
                }
                else
                {
                    rbStatus.Checked = false;
                    rbInActive.Checked = true;
                }
                female = Convert.ToInt32(Request.QueryString["Female_Only"].ToString());
                if (female == 1)
                {
                    chkFemale.Checked = true;
                }
                else
                {
                    chkFemale.Checked = false;
                }
            }
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (rbStandard.Checked == true)
            {
                Holidaytype = 1;
                rbSpecific.Checked = false;
                rbUnofficial.Checked = false;
            }
            else if (rbSpecific.Checked == true)
            {
                Holidaytype = 2;
                rbStandard.Checked = false;
                rbUnofficial.Checked = false;
            }
            else
            {
                Holidaytype = 0;
                rbStandard.Checked = false;
                rbSpecific.Checked = false;
            }

            int i = blu.UpdateHolidaySetup(txtHolidayname.Text, Convert.ToDateTime(txtStartDate.Text), Convert.ToInt32(txtnumber.Text), Holidaytype, rbStatus.Checked ? 1 : 0, chkFemale.Checked ? 1 : 0, Convert.ToInt32(HiddenField1.Value));
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Holiday Setup updated Successfully').then((value) => { window.location ='HolidaySetup.aspx'; });", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HolidaySetup.aspx");
        }
        int Holidaytype;
        protected void rbStandard_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStandard.Checked == true)
            {
                Holidaytype = 1;
                rbSpecific.Checked = false;
                rbUnofficial.Checked = false;
            }
        }

        protected void rbSpecific_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSpecific.Checked == true)
            {
                Holidaytype = 2;
                rbStandard.Checked = false;
                rbUnofficial.Checked = false;
            }
        }

        protected void rbUnofficial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnofficial.Checked == true)
            {
                Holidaytype = 0;
                rbStandard.Checked = false;
                rbSpecific.Checked = false;
            }
        }
    }
}