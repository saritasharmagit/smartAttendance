using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Events
{
    public partial class AddEvent : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
         protected void BtnSave_Click(object sender, EventArgs e)
        {
            if(txtStartDate.Text==""||txtTitle.Text==""||txtdescription.Text=="")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','plz Fill required Field !!!','warning')</script>");
                return;
            }
            int i = blu.CreateEvent(txtTitle.Text, txtdescription.Text, Convert.ToDateTime(txtStartDate.Text));
            if(i > 0)
            {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Event saved Successfully').then((value) => { window.location ='Event.aspx'; });", true);
            }
        }
    }
}