using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddCompany : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int i = blu.CreateCompany(Org_Name.Text, Org_Address.Text, Org_Address2.Text, Org_Phone.Text, Org_Fax.Text, Org_Email.Text, Org_Website.Text);
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Company saved Successfully').then((value) => { window.location ='Company.aspx'; });", true);
                Org_Name.Text = "";
                Org_Address.Text = "";
                Org_Phone.Text = "";
                Org_Email.Text = "";
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Company.aspx");
        }
    }
}