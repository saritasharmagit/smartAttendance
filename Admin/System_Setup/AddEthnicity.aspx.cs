using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddEthnicity : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (blu.CheckDuplicateEthnicity(txtEthnicity.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Already exists!','warning')</script>");

            }
            else
            {
                int i = blu.CreateEthnicity(txtEthnicity.Text, rbsta.Checked ? 1 : 0);
                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Ethnicity saved Successfully').then((value) => { window.location ='Ethnicity.aspx'; });", true);
                }
            }
           
        }
    }
}