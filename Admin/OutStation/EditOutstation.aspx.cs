using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.OutStation
{
    public partial class EditOutstation : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int stat = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int vno = Convert.ToInt32(Request.QueryString["VNO"].ToString());
                HiddenField1.Value = vno.ToString();
                DataTable dta = blu.GetOutstationbyId(vno);

                txtTravelid.Text = dta.Rows[0]["VNO"].ToString();
                txtemployeeid.Text = dta.Rows[0]["EMP_ID"].ToString();
                txtdays.Text = dta.Rows[0]["DAYS"].ToString();
                txtlocation.Text = dta.Rows[0]["STATION"].ToString();
                txtStartDate.Text = (Request.QueryString["SDATE"].ToString());
                txtEndDate.Text = (Request.QueryString["EDATE"].ToString());

            
                txtdescription.Text = dta.Rows[0]["PURPOSE"].ToString();
                CmbApproval.SelectedValue = (dta.Rows[0]["APPROVED_BY"].ToString());
                CmbEmployee.SelectedValue = (dta.Rows[0]["EMP_ID"].ToString());
                //stat = Convert.ToInt32(dta.Rows[0]["status"].ToString());
                if (stat == 1)
                {
                    rbStatus.Checked = true;
                    rbInActive.Checked = false;
                }
                else
                {
                    rbStatus.Checked = false;
                    rbInActive.Checked = true;
                }
                loadEmployee();
                loadApproval();
            }
        }
        public void loadEmployee()
        {
            DataTable dt = blu.getEmployeebyAtten();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "emp_fullname";
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

        protected void BtnUpdate_Click(object sender, EventArgs e)
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
            if (txtStartDate.Text == "" || txtEndDate.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Oops!','Date Field can not be emptied!','warning')</script>");
                return;
            }
            if (CmbApproval.SelectedItem.Text == "Select Approval" || CmbApproval.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alertscipt", "swal('Oops!','Please Select Approver !!!','warning')", true);
                return;
            }
            DateTime Startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime Enddate = Convert.ToDateTime(txtEndDate.Text);

            TimeSpan ts = Enddate - Startdate;
            txtdays.Text = ((ts.Days) + 1).ToString();



             int approverid = int.Parse(CmbApproval.SelectedValue);
            int empid=int.Parse(CmbEmployee.SelectedValue);

            blu.CreateOutStation(int.Parse(txtTravelid.Text), int.Parse(txtemployeeid.Text), DateTime.Now, 0, 0, (txtlocation.Text), Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text), int.Parse(txtdays.Text), txtdescription.Text, approverid, rbStatus.Checked ? 1 : 0);
            blu.CreateoutstationAttendance(int.Parse(txtemployeeid.Text), Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text), (txtlocation.Text), int.Parse(txtTravelid.Text), txtdescription.Text);
            //blu.UpdateOutstation(empid, DateTime.Now, 0, 0, txtlocation.Text, Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text), int.Parse(txtdays.Text), txtdescription.Text, approverid, rbStatus.Checked ? 1 : 0, int.Parse(txtTravelid.Text));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Operation Updated Successfully').then((value) => { window.location ='Outstation.aspx'; });", true);
        }

        protected void CmbApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DateTime Startdate = Convert.ToDateTime(txtStartDate.Text);
            //DateTime Enddate = Convert.ToDateTime(txtEndDate.Text);

            //TimeSpan ts = Enddate - Startdate;
            //txtdays.Text = ((ts.Days) + 1).ToString();
        }
    }
}