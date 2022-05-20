using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class RoosterAssign : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
             
                loadShift();

                DataTable dt = blu.getEmployeebyAtten();
                GridView2.DataSource = dt;
                GridView2.DataBind();

              //  loadBranch();
               // BtnSaveRoosterMgmt.Enabled = false;
                //BtnCancel.Enabled = false;
            }
           // CmbBranch.Items[0].Attributes["disabled"] = "disabled";
            CmbDefaultSG.Items[0].Attributes["disabled"] = "disabled";

        }
        //public void loadBranch()
        //{
        //    CmbDepartment.Enabled = true;
        //    DataTable dt = blu.getBranchList();
        //    CmbBranch.DataSource = dt;
        //    CmbBranch.DataBind();
        //    CmbBranch.DataTextField = "BRANCH_NAME";
        //    CmbBranch.DataValueField = "BRANCH_ID";
        //    CmbBranch.DataBind();
        //    CmbBranch.Items.Insert(0, "Select Project");
        //}

        //protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (CmbBranch.SelectedIndex != 0)
        //    {
        //        branch = Convert.ToInt32(CmbBranch.SelectedValue);
        //        dt = blu.getDepartmentList(branch);
        //        if (dt.Rows.Count > 0)
        //        {
        //            CmbDepartment.DataSource = dt;
        //            CmbDepartment.DataBind();
        //            CmbDepartment.DataTextField = "DEPT_NAME";
        //            CmbDepartment.DataValueField = "DEPT_ID";
        //            CmbDepartment.DataBind();
        //            CmbDepartment.Items.Insert(0, "Select Department");
        //            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available on selected Project !!!','warning')", true);
        //            loadBranch();
        //            CmbDepartment.Items.Clear();
        //        }

        //    }

        //}
        //protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CmbDepartment.Items[0].Attributes["disabled"] = "disabled";

        //    dept = Convert.ToInt32(CmbDepartment.SelectedValue);
        //    dt = blu.getDept_EmployeeList(dept);
        //    if (dt.Rows.Count > 0)
        //    {

        //        GridView2.DataSource = dt;
        //        GridView2.DataBind();
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Available on selected Department !!!','warning')", true);
        //    }
        //}

        public void loadShift()
        {
            CmbDefaultSG.Enabled = true;
            DataTable dt = blu.MgmtWorkingHour(0);
            CmbDefaultSG.DataSource = dt;
            CmbDefaultSG.DataBind();
            CmbDefaultSG.DataTextField = "Group_Name";
            CmbDefaultSG.DataValueField = "Group_ID";
            CmbDefaultSG.DataBind();
            CmbDefaultSG.Items.Insert(0, "Select Default Shift");
        }

        protected void CmbDefaultSG_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BtnSaveRoosterMgmt.Enabled = true;
            //BtnCancel.Enabled = true;

            if (CmbDefaultSG.SelectedIndex != 0)
            {
                DataTable dt = blu.getweekday();//weekdays data bind
                GVShift.DataSource = dt;
                GVShift.DataBind();
                CmbDefaultSG.DataTextField = "Group_Name";
                CmbDefaultSG.DataValueField = "Group_ID";

            }

        }


        protected void GVShift_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList CmbAssignedG = (DropDownList)e.Row.FindControl("CmbAssignedG");
                DataTable dt = blu.MgmtWorkingHour(0);
                CmbAssignedG.DataSource = dt;
                CmbAssignedG.DataBind();
                CmbAssignedG.DataTextField = "Group_Name";
                CmbAssignedG.DataValueField = "Group_ID";
                CmbAssignedG.DataBind();
                CmbAssignedG.ClearSelection();
                CmbAssignedG.SelectedValue = CmbDefaultSG.SelectedValue.ToString();
                CmbAssignedG.Items.Add("Day-off");

            }
        }

        int branch = 0;
        int dept = 0;
        string date1;
        protected void BtnSaveRoosterMgmt_Click(object sender, EventArgs e)
        {
            if(txtStartDate.Text==""||txtEndDate.Text=="")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('oops!','Date field cannot be emptied!')</script>");
                return;
            }
            //if (CmbBranch.SelectedItem.Text=="Select Project")
            //{
            //    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Oops!','Please Select  Project!!!','warning')", true);
            //    return;
            //}
            //if (CmbDepartment.SelectedItem.Text == "Select Department")
            //{
            //    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Oops!','Please Select  Department!!!','warning')", true);
            //    return;
            //}
            date1 = txtStartDate.Text;
            if (CmbDefaultSG.SelectedItem.Text == "Select Default Shift")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('oops!','Default Shift Group  cannot be emptied!')</script>");
                return;
            }
            int eid = 0;
            int groupid = 0;

            DateTime currentdate = DateTime.Parse(date1.ToString());
            bool result = false;
            if (CmbDefaultSG.SelectedValue == "Select Default Shift")
            {
                for (int i = 0; i < GVShift.Rows.Count; i++)
                {
                    if (Convert.ToInt32(GVShift.Rows[i].Cells[2].Text) == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Please select weekday shift').then((value) => { window.location ='RoosterAssign.aspx'; });", true);
                        break;
                    }
                }

            }
            foreach (GridViewRow row in GridView2.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                    if (chkRow.Checked)
                    {
                       // BtnSaveRoosterMgmt.Enabled = true;
                        eid = int.Parse(row.Cells[2].Text);


                        int Flag = 0;/*The Flag use in proc_ManageWeekend to delete 
                              * the existing weekend in the selected date interval*/
                        for (DateTime Date = Convert.ToDateTime(txtStartDate.Text); Date <= Convert.ToDateTime(txtEndDate.Text); )
                        {
                            int i = (int)(Date.DayOfWeek);

                            /*======================================================
                                 Group Id "0" value is used for None Group
                             ======================================================*/
                            //string aa = GVShift.Rows[i].Cells[2].Text;

                            DropDownList CmbAssignedG = GVShift.Rows[i].FindControl("CmbAssignedG") as DropDownList;
                            string days = CmbAssignedG.SelectedValue;
                            if (days == "Day-off")
                            {
                                groupid = 0;
                            }
                            else
                            {
                                groupid = Convert.ToInt32(CmbAssignedG.SelectedValue);
                            }

                            /*=========================================================
                                       Group Id "0" is for Day-Off
                             =========================================================*/
                            if (groupid == 0)
                            {
                                blu.ManageWeekend(eid, Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text), Date, Flag);
                                blu.ManageOpenRoosteroff(eid, Date, groupid);
                                Flag = 1;
                            }
                            else
                            {
                                blu.ManageOpenRooster(eid, Date, groupid);
                                result = true;
                            }
                            Date = Date.AddDays(1);
                        }
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "alertscipt", "swal('Oops!','Please Select  Employee!!!','warning')", true);
                        // return;
                    }
                }
            }
           
            if (result == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('operation is performed successfully').then((value) => { window.location ='RoosterAssign.aspx'; });", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoosterAssign.aspx");
        }
    }
}