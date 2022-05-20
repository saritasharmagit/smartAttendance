using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddGrade : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string fldtype = "";
        int serialno = 0;
        int level = 0;
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            blu.CreateGrade(txtGradename.Text, txtGradetype.Text, level, fldtype, serialno, rbStatus.Checked ? 1 : 0);
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Grade saved Successfully').then((value) => { window.location ='Grade.aspx'; });", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Grade.aspx");
        }
    }
}