using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddBankBranch : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadBank();
            }
        }
        public void loadBank()
        {
            DataTable dt = blu.GetBank();
            CmbBankName.DataSource = dt;
            CmbBankName.DataTextField = "BANK_NAME";
            CmbBankName.DataValueField = "BANK_ID";
            CmbBankName.DataBind();
            CmbBankName.Items.Insert(0, "Select Bank");

        }
       
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbBankName.SelectedItem.Text == "Select Bank")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','PLZ Select Bank Name !!!','warning')</script>");
                return;
            }
            if(txtAddress1.Text=="")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','PLZ Fill Bank Address !!!','warning')</script>");
                return;
            }
            int i = blu.CreateBankBranch(Convert.ToInt32(CmbBankName.SelectedValue), txtAddress1.Text, txtAddress2.Text);
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Bank Branch saved Successfully').then((value) => { window.location ='BankBranch.aspx'; });", true);
            }
        }
    }
}