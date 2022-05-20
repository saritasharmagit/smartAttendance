using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Attendance_Mgmt
{
    public partial class ForceAttendanceBatch : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int branch;
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnSave.Visible = false;
        }
       
        protected void DefTime_CheckedChanged(object sender, EventArgs e)
        {
            if (DefTime.Checked)
            {
                TxtTime.Enabled = false;
                TxtTime.Text = "";
            }
            else
            {
                TxtTime.Enabled = true;
                TxtTime.Focus();
            }
        }
        DataTable dt2, dt, dtt;
        string time;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (rbsta.Checked != true && rbsta1.Checked != true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Select Type !!!','warning')</script>");
                return;
            }
           
            if (txtEndDate.Text == "")
            {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Select Date !!!','warning')</script>");
                return;
            }

            if (TxtTime.Text == "" && DefTime.Checked != true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Select Time !!!','warning')</script>");
                return;
            }

            if (TxtRemarks.Text == "")
            {
               
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Remarks cannot be emptied !!!','warning')</script>");
                return;
            }

            DataTable dtA = blu.getEmployeebyAtten();
            GridView1.DataSource = dtA;
            GridView1.DataBind();

            BtnSave.Visible = true;

        }

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            BtnSave.Visible = true;
            CheckBox chkAll = (CheckBox)GridView1.HeaderRow.FindControl("chkAll");
            if (chkAll.Checked == true)
            {
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    CheckBox chk2 = (CheckBox)gvRow.FindControl("chk");
                    chk2.Checked = true;
                    BtnSave.Visible = true;
                }
            }
            else
            {
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    CheckBox chk2 = (CheckBox)gvRow.FindControl("chk");
                    chk2.Checked = false;

                }
                BtnSave.Visible = true;

            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
           
            int empid = 0;
            string date = txtEndDate.Text;
            string Status = string.Empty;
            string time = "";
            string remark = TxtRemarks.Text;
            int mode = rbsta.Checked ? 1 : 0;
           // string branch="";
            //  string branch = CmbBranch.SelectedItem.ToString();

            foreach (GridViewRow gvRow in GridView1.Rows)
            {
               
                    if (DefTime.Checked)
                    {
                      
                        for (int j = 0; j < GridView1.Rows.Count; j++)
                        {
                            CheckBox chk = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("chk");
                            if (chk.Checked)
                            {
                                empid = Convert.ToInt32(GridView1.Rows[j].Cells[1].Text);
                                dtt = blu.Proc_Get_Default_Time(empid, Convert.ToDateTime(date));
                                if (mode==1)
                                {
                                    if (dtt.Rows[0]["IN_START"].ToString() != "")
                                    {
                                        time = dtt.Rows[0]["IN_START"].ToString();
                                    }
                                    else
                                    {
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','No Rooster Assign With This Id !!!','warning')</script>");
                                        return;
                                    }
                                }
                                else
                                {
                                    if (dtt.Rows[0]["OUT_START"].ToString() != "")
                                    {
                                        time = dtt.Rows[0]["OUT_START"].ToString();
                                    }
                                    else
                                    {
                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','No Rooster Assign With This Id !!!','warning')</script>");
                                        return;
                                    }
                                }  
                              
                                int i = blu.proc_Getworkid(empid, Convert.ToDateTime(txtEndDate.Text), time, remark, mode);
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Force Attendacne Batch saved Successfully').then((value) => { window.location ='ForceAttendanceBatch.aspx'; });", true);
                                //return;
                            }

                        }

                    }
                    else
                    {

                        string Time = TxtTime.Text;
                        for (int k = 0; k < GridView1.Rows.Count; k++)
                        {
                            CheckBox chk = (CheckBox)GridView1.Rows[k].Cells[0].FindControl("chk");
                            if (chk.Checked)
                            {
                                empid = Convert.ToInt32(GridView1.Rows[k].Cells[1].Text);
                                int i = blu.proc_Getworkid(empid, Convert.ToDateTime(txtEndDate.Text), Time, remark, mode);
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Force Attendacne Batch saved Successfully').then((value) => { window.location ='ForceAttendanceBatch.aspx'; });", true);
                                //return;
                            }

                        }
                    }
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Force Attendacne Batch saved Successfully').then((value) => { window.location ='ForceAttendanceBatch.aspx'; });", true);
                }
        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForceAttendanceBatch.aspx");
        }
    }
}