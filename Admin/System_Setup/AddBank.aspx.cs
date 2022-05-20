using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddBank : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string account = "";
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int i = blu.CreateBank(txtBankcode.Text, txtBankname.Text, account);
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Bank saved Successfully').then((value) => { window.location ='Bank.aspx'; });", true);
            }
        }
    }
}