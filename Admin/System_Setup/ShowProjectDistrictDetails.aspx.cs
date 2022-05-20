using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class ShowProjectDistrictDetails : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            int projectid = Convert.ToInt32(Request.QueryString["ProjectId"].ToString());
            HiddenField1.Value = projectid.ToString();
            DataTable dta = blu.GetProjectAssignView(projectid);
            if(dta.Rows.Count > 0)
            {
                grvProjectDistrict.DataSource = dta;
                grvProjectDistrict.DataBind();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','No project District Assign!','warning')</script>");
            }
           
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectAssign.aspx");
        }
    }
}