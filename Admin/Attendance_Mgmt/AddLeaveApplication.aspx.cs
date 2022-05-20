using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Attendance_Mgmt
{
    public partial class AddLeaveApplication : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadEmployee();
                BtnSave.Enabled = false;
                btnLoad.Visible = true;
            }
        }
        public void loadEmployee()
        {
            DataTable dt = blu.getEmployeebyAtten();
            DDLEMP.DataSource = dt;
            DDLEMP.DataTextField = "Fullname";
            DDLEMP.DataValueField = "EMP_ID";
            DDLEMP.DataBind();

            DDLEMP.Items.Insert(0, "Select Approver");
            DDLEMP.Items[0].Selected = true;
            DDLEMP.Items[0].Attributes["Disabled"] = "Disabled";
        }
        protected void TxtId_TextChanged(object sender, EventArgs e)
        {
            int emp_id = int.Parse(TxtId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0)
            {
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtEmp.Text = dt.Rows[0]["Fullname"].ToString();
                TxtDesignation.Text = dt.Rows[0]["DEG_NAME"].ToString();

                DataTable dt1 = blu.getleave_emp(emp_id);
                DDLLeaveName.DataSource = dt1;
                DDLLeaveName.DataTextField = "LEAVE_NAME";
                DDLLeaveName.DataValueField = "LEAVE_ID";
                DDLLeaveName.DataBind();

                DDLLeaveName.Items.Insert(0, "Select Name");
                DDLLeaveName.Items[0].Selected = true;
                DDLLeaveName.Items[0].Attributes["Disabled"] = "Disabled";
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Available with that ID !!!','warning')", true);
                TxtId.Text = " ";
            }
        }

        protected void DDLLeaveName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int empid = Convert.ToInt32(TxtId.Text);
            if (DDLLeaveName.SelectedValue == "Select Name")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Leave First !!!','warning')", true);
                DDLLeaveName.Items.Clear();
                DDLLeaveName.Focus();
            }
            int LvType = Convert.ToInt32(DDLLeaveName.SelectedValue);
            dt = blu.proc_Pay_LeaveLog_web(empid, LvType);
            if (dt.Rows.Count > 0)
            {
                leaveApproved.Text = dt.Rows[0]["Given"].ToString();
                leaveUsed.Text = dt.Rows[0]["Taken"].ToString();
                available.Text = dt.Rows[0]["bal"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Approved,Used and Available !!!','warning')", true);
                return;
            }
        }

        protected void DDLEMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            emp_id.Text = DDLEMP.SelectedValue.ToString();
        }
        decimal balance;
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Enter EmployeeId!!!','warning')", true);
                return;
            }
            if (DDLLeaveName.SelectedItem.Text == "Select Name")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Selected !!!','warning')", true);
                return;
            }

            if (DDLLeaveType.SelectedItem.Text == "Select Type")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Type Selected !!!','warning')", true);
                return;
            }

            if (DDLDAy.SelectedItem.Text == "Select Day")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Day Selected !!!','warning')", true);
                return;
            }

            if (DDLEMP.SelectedItem.Text == "Select Approver")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Leave Approver Not Selected !!!','warning')", true);
                return;
            }
           
            if (txtNepaliDate.Text == "" || nepaliDate2.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Date Field cannot be emptied !!!','warning')", true);
                return;
            }
           
            //int gvHasRows = GridView1.Rows.Count;
            //if (gvHasRows > 0)
            //{
            //    GridView1.Columns.Clear();
            //    GridView1.DataBind();
            //}
           
            DateTime Startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime Enddate = Convert.ToDateTime(txtEndDate.Text);

            TimeSpan ts = Enddate - Startdate;
            int numberOfDays = (ts.Days) + 1;

            string asas = (available.Text);
           
            if (DDLDAy.SelectedItem.Text == "Half Day")
            {
                leaveApplied.Text = "0.5";
                decimal leaves = Convert.ToDecimal(leaveApplied.Text);
                balance = Convert.ToDecimal(available.Text);
                if (leaves > balance)
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Leave Applied is greater than leave balance Available !!!','warning')", true);
                    return;
                }
            }
            else
            {
                leaveApplied.Text = numberOfDays.ToString();
                leave = int.Parse(leaveApplied.Text);
                 balance = Convert.ToDecimal(available.Text);
            }
           

            if (leave > balance)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Leave Applied is greater than leave balance Available !!!','warning')", true);
                return;
            }
            else
            {
                DateTime currentDate;
                for (int j = 0; j <= numberOfDays - 1; j++)
                {
                    DataTable dt2 = new DataTable();
                    dt2.Columns.Add("Date");
                    dt2.Columns.Add("LEAVE_NAME");
                    dt2.Columns.Add("Remarks");
                    DataRow dr = null;
                    if (ViewState["emp"] != null)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            dt2 = (DataTable)ViewState["emp"];
                            if (dt2.Rows.Count > 0)
                            {
                                dr = dt2.NewRow();
                                currentDate = Convert.ToDateTime(txtStartDate.Text);
                                currentDate = currentDate.AddDays(1);
                                txtStartDate.Text = currentDate.ToString("yyyy-MM-dd");
                                dr["Date"] = txtStartDate.Text;
                                dr["LEAVE_NAME"] = DDLLeaveName.SelectedItem.ToString();
                                dr["Remarks"] = Remarks.Text;

                                dt2.Rows.Add(dr);
                                GridView1.DataSource = dt2;
                                GridView1.DataBind();
                            }
                        }
                       
                    }
                    else
                    {
                        dr = dt2.NewRow();
                        dr["Date"] = txtStartDate.Text;
                        dr["LEAVE_NAME"] = DDLLeaveName.SelectedItem.ToString();
                        dr["Remarks"] = Remarks.Text;
                        dt2.Rows.Add(dr);

                        GridView1.DataSource = dt2;
                        GridView1.DataBind();
                    }
                    ViewState["emp"] = dt2;
                    BtnSave.Enabled = true;
                    //btnLoad.Visible = false;


                    //txtStartDate.Enabled = false;
                    //txtEndDate.Enabled = false;
                }
                ViewState.Remove("emp");
            }
           
        }
        string Taken;
        int empid;
        int leave_id;
        int leave = 0;
        int status = 1;
       // decimal availablevalue = 0;
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            empid = int.Parse(TxtId.Text);//for check available and leave used
            string Id = TxtId.Text;//for save
            leave_id = Convert.ToInt32(DDLLeaveName.SelectedValue);

            if(DDLDAy.SelectedItem.Text=="Half Day")
            {
                Taken = "0.5";
            }
            else
            {
                Taken = "1.00";
            }
            
            string Seniorid = (DDLEMP.SelectedValue);
            DateTime date1 = Convert.ToDateTime(txtStartDate.Text);
           // string day =(DDLDAy.SelectedValue);
            string leavename = (DDLLeaveName.SelectedValue);
            int LvType = Convert.ToInt32(DDLLeaveName.SelectedValue);
            string Leavetype = DDLLeaveType.SelectedItem.ToString();
            string daypart = "1";


            DataTable dt = blu.proc_Pay_LeaveLog_web(empid, LvType);
            int empid1 = int.Parse(TxtId.Text);
            DataTable dt2 = blu.getLeaveDate(empid1);
            int count = dt2.Rows.Count;

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string dtItem = (dt2.Rows[i]["Leave_Date"].ToString());
                DateTime aa = Convert.ToDateTime(dtItem);
                dtItem = aa.ToString("yyyy-MM-dd");
                DateTime currentDate = Convert.ToDateTime(txtStartDate.Text);

                txtStartDate.Text = currentDate.ToString("yyyy-MM-dd");

                if (dtItem == txtStartDate.Text)
                {
                    ScriptManager.RegisterStartupScript(upPnl1, this.GetType(), "alertscipt", "swal('Ooops!','No leave day Available in same day please select another date !!!','warning')", true);
                    txtNepaliDate.Text = string.Empty;
                    txtStartDate.Text = string.Empty;
                    nepaliDate2.Text = string.Empty;
                    txtEndDate.Text = string.Empty;
                    return;
                }
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                string date = ((row.Cells[1].FindControl("gvdate") as Label).Text);
                blu.LeaveApplicationApproval(Convert.ToDateTime(date), Id, leave_id, Taken, Remarks.Text, Seniorid, daypart, Leavetype, status);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Leave Application saved Successfully').then((value) => { window.location ='LeaveApplication.aspx'; });", true);
            return;
        }


        protected void BtnCancel_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("AddLeaveApplication.aspx");
            //int gvHasRows = GridView1.Rows.Count;
            //if (gvHasRows > 0)
            //{
            //GridView1.Columns.Clear();
            //GridView1.DataBind();
               
            //}

        }

        protected void emp_id_TextChanged(object sender, EventArgs e)
        {

            DDLEMP.SelectedValue = emp_id.Text;
        }
    }
}