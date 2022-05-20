using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class EditBankBranch : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int branchid = Convert.ToInt32(Request.QueryString["Branch_Id"].ToString());
                HiddenField1.Value = branchid.ToString();
                DataTable dta = blu.GetbankbranchbyId(branchid);

                txtBankname.Text = Request.QueryString["Bank_NAME"].ToString();
                txtAddress1.Text = Request.QueryString["Address1"].ToString();
                txtAddress2.Text = Request.QueryString["Address2"].ToString();

            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            blu.UpdateBankBranch(txtAddress1.Text, txtAddress2.Text, Convert.ToInt32(HiddenField1.Value));
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Bank Branch Updated Successfully').then((value) => { window.location ='BankBranch.aspx'; });", true);
            }
        }
    }
}