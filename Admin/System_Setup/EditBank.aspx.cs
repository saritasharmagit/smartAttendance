using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class EditBank : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int bankid = Convert.ToInt32(Request.QueryString["BANK_ID"].ToString());
                HiddenField1.Value = bankid.ToString();
                DataTable dta = blu.GetbankbybankId(bankid);

                txtBankcode.Text = Request.QueryString["BANK_CODE"].ToString();
                txtBankname.Text = Request.QueryString["BANK_NAME"].ToString();
                txtAccnumber.Text = Request.QueryString["Account_Id"].ToString();
               
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            blu.UpdateBank(txtBankcode.Text,txtBankname.Text,txtAccnumber.Text, Convert.ToInt32(HiddenField1.Value));
            
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Bank Updated Successfully').then((value) => { window.location ='Bank.aspx'; });", true);
            }
        }
    }
}