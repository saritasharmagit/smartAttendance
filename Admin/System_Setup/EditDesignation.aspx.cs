using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class EditDesignation : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int stat = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int degid = Convert.ToInt32(Request.QueryString["DEG_ID"].ToString());
                HiddenField1.Value = degid.ToString();
                DataTable dta = blu.GetDesignationbyId(degid);
                txtDesignationemp.Text = Request.QueryString["DEG_NAME"].ToString();
                stat = Convert.ToInt32(Request.QueryString["sta"].ToString());
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
        string degparent = "";
        int level = 0;
        int serialno = 0;
        int priority = 0;
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            blu.UpdateDesignation(degparent, txtDesignationemp.Text, level, serialno, rbStatus.Checked ? 1 : 0, priority, Convert.ToInt32(HiddenField1.Value));
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Designation Updated Successfully').then((value) => { window.location ='Designation.aspx'; });", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Designation.aspx");
        }
    }
}