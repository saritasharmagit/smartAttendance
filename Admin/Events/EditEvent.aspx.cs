using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Events
{
    public partial class EditEvent : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int eventid = Convert.ToInt32(Request.QueryString["EventId"].ToString());
                HiddenField1.Value = eventid.ToString();
                DataTable dta = blu.GetEventbyId(eventid);

                txtTitle.Text = Request.QueryString["Title"].ToString();
                txtdescription.Text = Request.QueryString["Description"].ToString();
                txtStartDate.Text = Request.QueryString["Date"].ToString();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            blu.UpdateEvent(txtTitle.Text, txtdescription.Text, Convert.ToDateTime(txtStartDate.Text), Convert.ToInt32(HiddenField1.Value));
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Event Updated Successfully').then((value) => { window.location ='Event.aspx'; });", true);
            }
        }
    }
}