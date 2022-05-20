using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddBranch : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        int isoutbranch = 0;
        int serialno = 0;
        string BType = "";
        int IsExtend = 0;
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (blu.CheckDuplicate(BRANCH_NAME.Text))
              {
                  Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Already exists!','warning')</script>");
                  return;
              }
            else
            {
                int i = blu.CreateBranch(BRANCH_CODE.Text, isoutbranch, serialno, BRANCH_NAME.Text, rbsta.Checked ? 1 : 0, BType, Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text), IsExtend,txtAbbr.Text);
                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Project saved Successfully').then((value) => { window.location ='BranchSetup.aspx'; });", true);
                }
            }
           
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BranchSetup.aspx");
        }
    }
}