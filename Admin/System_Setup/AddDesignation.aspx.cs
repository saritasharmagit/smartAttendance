using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddDesignation : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string degparent = "";
        int level = 0;
        int serialno = 0;
        int priority = 0;
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            blu.CreateDesignation(degparent, txtDesignation.Text, level, serialno, rbStatus.Checked ? 1 : 0, priority);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Designation saved Successfully').then((value) => { window.location ='Designation.aspx'; });", true);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Designation.aspx");
        }
    }
}