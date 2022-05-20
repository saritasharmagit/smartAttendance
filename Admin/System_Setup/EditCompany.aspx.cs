using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class EditCompany : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int orgid = Convert.ToInt32(Request.QueryString["Org_Id"].ToString());
                HiddenField1.Value = orgid.ToString();
                DataTable dta = blu.GetOrgbyOrgId(orgid);
                Org_Name.Text = Request.QueryString["Org_Name"].ToString();
                Org_Address.Text = Request.QueryString["Org_Address"].ToString();
                Org_Address2.Text = Request.QueryString["Org_Address2"].ToString();
                Org_Phone.Text = Request.QueryString["Org_Phone"].ToString();
                Org_Email.Text = Request.QueryString["Org_Email"].ToString();
                Org_Fax.Text = Request.QueryString["Org_Fax"].ToString();
                Org_Website.Text = Request.QueryString["Org_Website"].ToString();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int i = blu.UpdateCompany(Org_Name.Text, Org_Address.Text, Org_Address2.Text, Org_Phone.Text, Org_Fax.Text, Org_Email.Text, Org_Website.Text, Convert.ToInt32(HiddenField1.Value));
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Company Updated Successfully').then((value) => { window.location ='Company.aspx'; });", true);
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