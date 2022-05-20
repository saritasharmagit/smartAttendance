using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class EditGrade : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int stat = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int gradeid = Convert.ToInt32(Request.QueryString["GRADE_ID"].ToString());
                HiddenField1.Value = gradeid.ToString();
                DataTable dta = blu.GetGradebygradeId(gradeid);
                txtGradename.Text = Request.QueryString["GRADE_NAME"].ToString();
                txtGradetype.Text = Request.QueryString["GRADE_TYPE"].ToString();
                stat = Convert.ToInt32(Request.QueryString["sta"].ToString());
                if (stat == 1)
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
        string fldtype = "";
        int serialno = 0;
        int level = 0;
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            blu.UpdateGrade(txtGradename.Text, txtGradetype.Text, level, fldtype, serialno, rbStatus.Checked ? 1 : 0, Convert.ToInt32(HiddenField1.Value));
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Grade updated Successfully').then((value) => { window.location ='Grade.aspx'; });", true);
                txtGradename.Text = "";
                txtGradetype.Text = "";
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("Grade.aspx");
        }
    }
}