using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.OutStation
{
    public partial class AddOutstation : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int trid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = blu.getMaxTravelid();
                txtTravelid.Text = dt.Rows[0]["travel_id"].ToString();


                loadEmployee();
                loadApproval();
            }

        }
        public void loadEmployee()
        {
            DataTable dt = blu.getEmployeebyAtten();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "Fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
        }
        public void loadApproval()
        {
            DataTable dt = blu.getEmployeebyAtten();
            CmbApproval.DataSource = dt;
            CmbApproval.DataTextField = "emp_fullname";
            CmbApproval.DataValueField = "EMP_ID";
            CmbApproval.DataBind();
            CmbApproval.Items.Insert(0, "Select Approval");
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtemployeeid.Text = CmbEmployee.SelectedValue.ToString();
        }

        protected void txtemployeeid_TextChanged(object sender, EventArgs e)
        {
            //int employee = int.Parse(txtemployeeid.Text);
            //DataTable dt = blu.getAllInfo(employee);
            //if (dt.Rows.Count > 0)
            //{
            //    txtemployeeid.Text = dt.Rows[0]["EMP_ID"].ToString();

            //    CmbEmployee.DataSource = dt;
            //    CmbEmployee.DataTextField = "emp_fullname";
            //    CmbEmployee.DataBind();
            //}
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbEmployee.SelectedItem.Text == "Select Employee" || txtemployeeid.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Oops!','PLz Select Employee !!!','warning')", true);
                return;
            }
            if (txtdays.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Oops!','Days can not be emptied!','warning')</script>");
                return;
            }
            if (TextBox4.Text == "" || TextBox6.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Oops!','Date Field can not be emptied!','warning')</script>");
                return;
            }
            if (CmbApproval.SelectedItem.Text == "Select Approval" || CmbApproval.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alertscipt", "swal('Oops!','Please Select Approver !!!','warning')", true);
                return;
            }

            //DataTable dt = blu.getMaxTravelid();

            //txtTravelid.Text = dt.Rows[0]["travel_id"].ToString();
            trid = Convert.ToInt32(txtTravelid.Text);
            int approverid = int.Parse(CmbApproval.SelectedValue);
            blu.CreateOutStation(trid, int.Parse(txtemployeeid.Text), DateTime.Now, 0, 0, (txtlocation.Text), Convert.ToDateTime(TextBox4.Text), Convert.ToDateTime(TextBox6.Text), int.Parse(txtdays.Text), txtdescription.Text, approverid, rbStatus.Checked ? 1 : 0);
            blu.CreateoutstationAttendance(int.Parse(txtemployeeid.Text), Convert.ToDateTime(TextBox4.Text), Convert.ToDateTime(TextBox6.Text), (txtlocation.Text), trid, txtdescription.Text);


            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Operation Performed Successfully').then((value) => { window.location ='Outstation.aspx'; });", true);
        }
        protected void CmbApproval_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DateTime Startdate = Convert.ToDateTime(TextBox4.Text);
            DateTime Enddate = Convert.ToDateTime(TextBox6.Text);

            TimeSpan ts = Enddate - Startdate;
            txtdays.Text = ((ts.Days) + 1).ToString();
        }

    }
}