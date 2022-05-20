using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Attendance_Mgmt
{
    public partial class ForceAttendance : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(rbIn.Checked)
                {
                    lblIntime.Visible = true;
                    txtTimeIn.Visible = true;
                    TextInRemark.Visible = true;
                    lblInRemark.Visible = true;

                    txtTimeOut.Visible = false;
                    lblOutTime.Visible = false;
                    TextOutRemark.Visible = false;
                    lblOutRemark.Visible = false;
                }
                else
                {
                    lblIntime.Visible = false;
                    txtTimeIn.Visible = false;
                    TextInRemark.Visible = false;
                    lblInRemark.Visible = false;

                    txtTimeOut.Visible = true;
                    lblOutTime.Visible = true;
                    TextOutRemark.Visible = true;
                    lblOutRemark.Visible = true;
                }
            }
        }
        protected void TxtId_TextChanged(object sender, EventArgs e)
        {
            int emp_id = int.Parse(TxtId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0)
            {
                TxtEmp.Text = dt.Rows[0]["Fullname"].ToString();
                TxtSection.Text = dt.Rows[0]["section_name"].ToString();
                TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Available with that ID !!!','warning')", true);
                TxtId.Text = " ";
            }
        }

        //protected void plus_Click(object sender, EventArgs e)
        //{

        //    if (TxtId.Text == "")
        //    {
        //        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Enter Employee ID !!!','warning')", true);
        //        return;
        //    }
               
        //        if (txtNepaliDate.Text == "")
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
        //            return;
        //        }
        //        //if (TextInRemark.Text == "")
        //        //{
        //        //    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Please Fill Remarks Fields !!!','warning')", true);
        //        //    return;
        //        //}

        //        DateTime Startdate = Convert.ToDateTime(txtStartDate.Text);
        //        DateTime Enddate = Convert.ToDateTime(txtStartDate.Text);

        //        TimeSpan ts = Enddate - Startdate;
        //        int numberOfDays = (ts.Days) + 1;

        //        DateTime currentDate;
        //        for (int j = 0; j <= numberOfDays - 1; j++)
        //        {

        //            DataTable dt2 = new DataTable();
        //            dt2.Columns.Add("Date");
        //            dt2.Columns.Add("LEAVE_NAME");
        //            DataRow dr = null;
        //            if (ViewState["emp"] != null)
        //            {
        //                for (int i = 0; i < 1; i++)
        //                {
        //                    dt2 = (DataTable)ViewState["emp"];
        //                    if (dt2.Rows.Count > 0)
        //                    {
        //                        dr = dt2.NewRow();
        //                        currentDate = Convert.ToDateTime(txtStartDate.Text);
        //                        currentDate = currentDate.AddDays(1);
        //                        txtStartDate.Text = currentDate.ToString("yyyy/MM/dd");
        //                        dr["Date"] = txtStartDate.Text;
        //                        dt2.Rows.Add(dr);
        //                        GridView1.DataSource = dt2;
        //                        GridView1.DataBind();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                dr = dt2.NewRow();
        //                dr["Date"] = txtStartDate.Text;
        //                dt2.Rows.Add(dr);

        //                GridView1.DataSource = dt2;
        //                GridView1.DataBind();
        //            }
        //            ViewState["emp"] = dt2;
        //            plus.Visible = false;
        //            BtnSave.Enabled = true;
        //    }
        //}

        int flag = 0;
        string intime="";
        string inremark="";
        string outtime="";
        string outremark="";
        int empid;
        DateTime date;
       
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string startdate = txtStartDate.Text;
            string Admin = "admin";
          
            if (rbIn.Checked)
            {
                if (txtTimeIn.Text=="" || TextInRemark.Text=="")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "alertscipt", "swal('Ooops!','InTime and InRemark Field can not be emptied !!!','warning')", true);
                  return;
                }
                else
                {
                     empid=Convert.ToInt32(TxtId.Text);
                     date=Convert.ToDateTime(txtStartDate.Text);
                   //  int InOutMode = 0;
                     DataTable dt = blu.getoutTime_ForceAttn(empid, date);
                        if(dt.Rows.Count>0)
                        {
                            outtime = dt.Rows[0]["LogTime"].ToString();
                        }
                        else
                        {
                            outtime = "";
                        }

                    intime = txtTimeIn.Text;
                    inremark = TextInRemark.Text;
                    flag = 0;
                    blu.ForceAttendance((TxtId.Text).ToString(), Convert.ToDateTime(startdate), (txtTimeIn.Text), inremark, Admin, Convert.ToDateTime(startdate), (outtime), Admin, outremark, flag, 0, 0);
                }
                
            }
            else
            {
                if (txtTimeOut.Text == "" || TextOutRemark.Text=="")
                {
                    ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "alertscipt", "swal('Ooops!','OutTime and OutRemark Field can not be emptied !!!','warning')", true);
                    return;
                }
                else
                {
                    empid = Convert.ToInt32(TxtId.Text);
                    date = Convert.ToDateTime(txtStartDate.Text);
                 //   int InOutMode = 1;
                    DataTable dt = blu.getoutTime_ForceAttn(empid, date);
                    if (dt.Rows.Count > 0)
                    {
                        intime = dt.Rows[0]["LogTime"].ToString();
                    }
                    else
                    {
                        intime = "";
                    }

                    //check intime first 
                   // outtime = txtTimeOut.Text;
                    outremark = TextOutRemark.Text;
                    flag = 0;
                    blu.ForceAttendance((TxtId.Text).ToString(), Convert.ToDateTime(startdate), (intime), inremark, Admin, Convert.ToDateTime(startdate), (txtTimeOut.Text), Admin, outremark, flag, 0, 0);
                }
              
            }
          
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Force Attendance Saved Successfully').then((value) => { window.location ='ForceAttendance.aspx'; });", true);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForceAttendance.aspx");
        }

        protected void rbIn_CheckedChanged(object sender, EventArgs e)
        {
            if(rbIn.Checked)
            {
                lblIntime.Visible = true;
                txtTimeIn.Visible = true;
                TextInRemark.Visible = true;
                lblInRemark.Visible = true;

                txtTimeOut.Visible = false;
                lblOutTime.Visible = false;
                TextOutRemark.Visible = false;
                lblOutRemark.Visible = false;
            }
            else
            {
                lblIntime.Visible = false;
                txtTimeIn.Visible = false;
                TextInRemark.Visible = false;
                lblInRemark.Visible = false;

                txtTimeOut.Visible = true;
                lblOutTime.Visible = true;
                TextOutRemark.Visible = true;
                lblOutRemark.Visible = true;
            }

        }

        protected void rbOut_CheckedChanged(object sender, EventArgs e)
        {
            if(rbOut.Checked)
            {
                lblIntime.Visible = false;
                txtTimeIn.Visible = false;
                TextInRemark.Visible = false;
                lblInRemark.Visible = false;

                txtTimeOut.Visible = true;
                lblOutTime.Visible = true;
                TextOutRemark.Visible = true;
                lblOutRemark.Visible = true;
            }
            else
            {
                lblIntime.Visible = true;
                txtTimeIn.Visible = true;
                TextInRemark.Visible = true;
                lblInRemark.Visible = true;

                txtTimeOut.Visible = false;
                lblOutTime.Visible = false;
                TextOutRemark.Visible = false;
                lblOutRemark.Visible = false;
            }
        }
    }
}