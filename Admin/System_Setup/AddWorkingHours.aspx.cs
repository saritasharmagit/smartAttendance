using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddWorkingHours : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        int wrkid = 0;
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if(txtGroupname.Text=="")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Enter Group Name !!!','warning')", true);
                return;
            }
            if(txtIntime.Text==""||txtOuttime.Text=="")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Time fiels can not emptied !!!','warning')", true);
                return;
            }
            if (txtLunch.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Lunch Time can not emptied !!!','warning')", true);
                return;
            }
            int Aflag = 0;
            string intime = (txtIntime.Text);
            string intime1 = (txtIntime1.Text);
            string outtime = (txtOuttime.Text);
            string outtime1 = (txtOuttime1.Text);
            int workinghr = int.Parse(txtworking.Text);
            int workingmn = int.Parse(txtworkingMn.Text);
            int lunch = int.Parse(txtLunch.Text);

            blu.CreateWorkingHour(Aflag, wrkid, intime, intime1, outtime, outtime1, workinghr, workingmn, lunch, rbNsh.Checked ? 1 : 0, rbdef.Checked ? 1 : 0, rbsta.Checked ? 1 : 0, txtGroupname.Text);
            // blu.CreateWorkingHour(Aflag, wrkid, intime, intime1, outtime,outtime1, Convert.ToInt32(txtworking.Text), Convert.ToInt32(txtworkingMn.Text), Convert.ToInt32(txtLunch.Text), rbNsh.Checked ? 1 : 0, rbdef.Checked ? 1 : 0, rbsta.Checked ? 1 : 0, txtGroupname.Text);
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Working Hour Saved Successfully').then((value) => { window.location ='WorkingHours.aspx'; });", true);
            }
        }
        protected void txtOuttime_TextChanged(object sender, EventArgs e)
        {
            DateTime strt = Convert.ToDateTime(txtIntime.Text);
            DateTime end = Convert.ToDateTime(txtOuttime.Text);
            TimeSpan ts = (end - strt);
            // txtworking.Text = (ts).ToString();
            txtworking.Text = string.Format("{0:00}", ts.Hours);
            txtworkingMn.Text = string.Format("{0:00}", ts.Minutes);
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkingHours.aspx");
        }
    }
}