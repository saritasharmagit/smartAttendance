using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class EditEthnicity : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int ethnicityid = Convert.ToInt32(Request.QueryString["Ethnicity_Id"].ToString());
                HiddenField1.Value = ethnicityid.ToString();
                DataTable dta = blu.GetethnicitybyId(ethnicityid);

                txtEthnicity.Text = Request.QueryString["Ethnicity_Name"].ToString();
                int Status = Convert.ToInt32(Request.QueryString["Status"].ToString());


                if (Status == 1)
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

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            blu.UpdateEthnicity(txtEthnicity.Text, rbStatus.Checked ? 1 : 0, Convert.ToInt32(HiddenField1.Value));
            
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Ethnicity Updated Successfully').then((value) => { window.location ='Ethnicity.aspx'; });", true);
            }
        }
    }
}