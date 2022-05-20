using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Attendance_Mgmt
{
    public partial class ForceLeaveAssignment : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int emp_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = blu.getLeaveList();
                CmbLeavename.DataSource = dt;
                CmbLeavename.DataTextField = "LEAVE_NAME";
                CmbLeavename.DataValueField = "LEAVE_ID";
                CmbLeavename.DataBind();
                CmbLeavename.Items.Insert(0, "Select Leave");


                //DataTable dt1 = blu.getEmployeebyAtten();
                //CmbApproved.DataSource = dt1;
                //CmbApproved.DataTextField = "Fullname";
                //CmbApproved.DataValueField = "EMP_ID";
                //CmbApproved.DataBind();
                //CmbApproved.Items.Insert(0, "Select Approver");

              
            }
        }
     
        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
           emp_id = Convert.ToInt32(CmbEmployee.SelectedValue);
            txtEMPID.Text = CmbEmployee.SelectedValue;

            //DataTable dt1 = blu.getEmployeebyAtten();
            //CmbApproved.DataSource = dt1;
            //CmbApproved.DataTextField = "Fullname";
            //CmbApproved.DataValueField = "EMP_ID";
            //CmbApproved.DataBind();
            //CmbApproved.Items.Insert(0, "Select Approver");

          

        }
        protected void CmbApproved_SelectedIndexChanged(object sender, EventArgs e)
        {
            int UserTypeId = 2;
            DataTable dt = blu.getUserTypeList(UserTypeId);

        }
        //protected void btnLoad_Click(object sender, EventArgs e)
        //{

        //    if (CmbEmployee.SelectedItem.Text == "Select Employee")
        //    {
        //        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Employee !!!','warning')", true);
        //        return;
        //    }
        //    if (CmbLeavename.SelectedItem.Text == "Select Leave")
        //    {
        //        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Leave Name !!!','warning')", true);
        //        return;
        //    }
        //    if (txtDays.Text == "")
        //    {
        //        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Leave Days !!!','warning')", true);
        //        return;
        //    }
        //    //if (CmbApproved.SelectedItem.Text == "Select Approving officer")
        //    //{
        //    //    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Approver !!!','warning')", true);
        //    //    return;
        //    //}
        //    if (CmbMonth.SelectedItem.Text == "Select Month")
        //    {
        //        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Month!!!','warning')", true);
        //        return;
        //    }
        //    DataTable dt2 = new DataTable();
        //    dt2.Columns.Add("Employee Name");
        //    dt2.Columns.Add("Leave");
        //    dt2.Columns.Add("Year");
        //    dt2.Columns.Add("Month");
        //    dt2.Columns.Add("No. of Days");
        //    dt2.Columns.Add("Approved By");

        //    DataRow dr = null;
        //    if (ViewState["emp"] != null)
        //    {
        //        for (int i = 0; i < 1; i++)
        //        {
        //            dt2 = (DataTable)ViewState["emp"];
        //            if (dt2.Rows.Count > 0)
        //            {
        //                dr = dt2.NewRow();
        //                dr["Employee Name"] = CmbEmployee.SelectedItem;
        //                dr["Leave"] = CmbLeavename.SelectedItem;
        //                dr["Year"] = txtDate.Text;
        //                dr["Month"] = CmbMonth.SelectedItem;
        //                dr["No. of Days"] = txtDays.Text;
        //                dr["Approved By"] = CmbApproved.SelectedItem;
        //                dt2.Rows.Add(dr);
        //                GridView1.DataSource = dt2;
        //                GridView1.DataBind();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        dr = dt2.NewRow();
        //        dr["Employee Name"] = CmbEmployee.SelectedItem;
        //        dr["Leave"] = CmbLeavename.SelectedItem;
        //        dr["Year"] = txtDate.Text;
        //        dr["Month"] = CmbMonth.SelectedItem;
        //        dr["No. of Days"] = txtDays.Text;
        //        dr["Approved By"] = CmbApproved.SelectedItem;
        //        dt2.Rows.Add(dr);
        //        GridView1.DataSource = dt2;
        //        GridView1.DataBind();
        //        btnSave.Visible = true;
        //    }
        //    ViewState["emp"] = dt2;
        //    btnLoad.Visible = false;
        //}
        int Actionflag = 0;
        int sno = 0;
        decimal given = 0;
        int eid = 0;
        string emp_name = "";
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CmbEmployee.SelectedItem.Text == "Select Employee")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Employee !!!','warning')", true);
                return;
            }
            if (CmbLeavename.SelectedItem.Text == "Select Leave")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Leave Name !!!','warning')", true);
                return;
            }
            if (txtDays.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Leave Days !!!','warning')", true);
                return;
            }
            //if (CmbApproved.SelectedItem.Text == "Select Approver")
            //{
            //    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Approver !!!','warning')", true);
            //    return;
            //}
            if (DDLLeaveType.SelectedItem.Text == "Select Type")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Date Type!!!','warning')", true);
                return;
            }
            if (CmbMonth.SelectedItem.Text == "Select Month")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Month!!!','warning')", true);
                return;
            }

            given = Convert.ToDecimal(txtDays.Text);
            int leaveid = Convert.ToInt32(CmbLeavename.SelectedValue);
            int month = Convert.ToInt32(CmbMonth.SelectedValue);
           // int ApprovedBy = Convert.ToInt32(CmbApproved.SelectedValue);
            int date = Convert.ToInt32(txtDate.Text);

            if (Chkemp.Checked)
            {
                DataTable dt = blu.getEmployeebyAtten();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eid = int.Parse(dt.Rows[i]["EMP_ID"].ToString());
                    emp_name = dt.Rows[i]["Fullname"].ToString();
                    blu.CreateForceLeaveAssign(Actionflag, sno, leaveid, Convert.ToDecimal(given), month, date, 0, ChkOpen.Checked ? "true" : "false", eid);
                }
            }
            else
            {
                int empid = Convert.ToInt32(CmbEmployee.SelectedValue);

                blu.CreateForceLeaveAssign(Actionflag, sno, leaveid, Convert.ToDecimal(given), month, date, 0, ChkOpen.Checked ? "true" : "false", empid);
            }
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Leave Assignment Save Successfully').then((value) => { window.location ='ForceLeaveAssignment.aspx'; });", true);
            }
        }



        protected void DDLLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLLeaveType.SelectedIndex == 1)
            {
                DataTable dt = blu.getMonthList();
                CmbMonth.DataSource = dt;
                CmbMonth.DataTextField = "MONTH_Name";
                CmbMonth.DataValueField = "MONTH_ID";
                CmbMonth.DataBind();
                CmbMonth.Items.Insert(0, "Select Month");
                txtDate.Text = "2019";
            }
            if (DDLLeaveType.SelectedIndex == 2)
            {
                DataTable dt = blu.getNepaliMonthList();
                CmbMonth.DataSource = dt;
                CmbMonth.DataTextField = "MONTH_Name";
                CmbMonth.DataValueField = "MONTH_ID";
                CmbMonth.DataBind();
                CmbMonth.Items.Insert(0, "Select Month");
                txtDate.Text = "2076";
            }

        }
       
        protected void CmbLeavename_SelectedIndexChanged(object sender, EventArgs e)
        {
            int leaveid = Convert.ToInt32(CmbLeavename.SelectedValue);
            DataTable dt = blu.getLeaveEmployeeList(leaveid);
            if(dt.Rows.Count>0)
            {
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "Fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();

                txtEMPID.Text = (CmbEmployee.SelectedValue).ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Assigned. !!!','warning')", true);
            }
           
        }

        protected void txtEMPID_TextChanged(object sender, EventArgs e)
        {
            //int employee = int.Parse(txtEMPID.Text);
            //DataTable dt = blu.getAllInfo(employee);
            //if (dt.Rows.Count > 0)
            //{
            //    txtEMPID.Text = dt.Rows[0]["EMP_ID"].ToString();

            //    CmbEmployee.DataSource = dt;
            //    CmbEmployee.DataTextField = "Fullname";
            //    CmbEmployee.DataBind();


            //    DataTable dt2 = blu.getEmployeebyAtten();
            //    CmbApproved.DataSource = dt2;
            //    CmbApproved.DataTextField = "Fullname";
            //    CmbApproved.DataValueField = "EMP_ID";
            //    CmbApproved.DataBind();
            //    CmbApproved.Items.Insert(0, "Select Approver");


           // }
        }

        protected void Chkemp_CheckedChanged1(object sender, EventArgs e)
        {
            if (Chkemp.Checked)
            {

                CmbEmployee.Enabled = false;

                DataTable dt = blu.getEmployeebyAtten();
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataBind();
                txtEMPID.Enabled = false;
                txtEMPID.Text = "";
            }
            else
            {
                CmbEmployee.Enabled = true;

                DataTable dt = blu.getEmployeebyAtten();
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "Fullname";
                CmbEmployee.DataBind();

                txtEMPID.Text = CmbEmployee.SelectedValue.ToString();
            }
        }
    }
}