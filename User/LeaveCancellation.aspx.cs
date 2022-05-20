using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.User
{
    public partial class LeaveCancellation : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadMonth();
                btnDelete.Visible = false;

                string EMP_ID = Session["username"].ToString();
                int emp_id = Convert.ToInt32(EMP_ID);
                DataTable dt = blu.getAllInfo(emp_id);
                if (dt.Rows.Count > 0)
                {
                    TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                    TxtDesg.Text = dt.Rows[0]["DEG_NAME"].ToString();
                    TxtEmp.Text = dt.Rows[0]["emp_fullname"].ToString();
                    TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                }
            }
        }
        public void loadMonth()
        {
           DataTable dt = blu.getMonthList();
            DDLMonth.DataSource = dt;
            DDLMonth.DataTextField = "MONTH_NAME";
            DDLMonth.DataValueField = "MONTH_ID";
            DDLMonth.DataBind();

            DDLMonth.Items.Insert(0, "Select Month");
            // DDLMonth.Items[0].Attributes["Disabled"] = "Disabled";
        }
        int emp_id, year, month;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
           
            if (DDLMonth.SelectedIndex == 0 || DDLMonth.SelectedItem.Text == "Select Month")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Month first.!!!','warning')", true);
                return;
                
            }
            string EMP_ID = Session["username"].ToString();
             emp_id = Convert.ToInt32(EMP_ID);
            year = Convert.ToInt32(TxtYear.Text);
            month = Convert.ToInt32(DDLMonth.SelectedValue);
            int date_type = 0;

            DataTable dt1 = blu.proc_LeaveShow(emp_id, year, month, date_type);
            if (dt1.Rows.Count > 0)
            {
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                btnDelete.Visible = true;

                GridView1.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave add with this EmployeeId.!!!','warning')", true);
                return;
            }
            btnDelete.Visible = true;
        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    int SNo = Convert.ToInt32(row.Cells[1].Text);

                    CheckBox chkRow = (row.Cells[0].FindControl("CheckBox2") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string leavename = ((row.Cells[2].FindControl("txtLeaveName") as Label).Text);
                        string takendate = (row.Cells[3].FindControl("txtDate") as Label).Text;
                        string remarks = (row.Cells[4].FindControl("txtRemarks") as Label).Text;
                        string approvedby = (row.Cells[5].FindControl("txtApproved") as Label).Text;
                        blu.deleterow(SNo);

                        string EMP_ID = Session["username"].ToString();
                        emp_id = Convert.ToInt32(EMP_ID);
                        year = Convert.ToInt32(TxtYear.Text);
                        month = Convert.ToInt32(DDLMonth.SelectedValue);
                        int date_type = 0;

                        DataTable dt1 = blu.proc_LeaveShow(emp_id, year, month, date_type);
                        if (dt1.Rows.Count > 0)
                        {
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','select Leave Deleted !!!','warning')</script>");
                            return;
                        }
                        else
                        {
                            GridView1.Visible = false;
                            btnDelete.Visible = false;

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','All Leave Deleted !!!','warning')</script>");
                            return;
                        }
                    }
                  
                }
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','please select table data !!!','warning')</script>");
           
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveCancellation.aspx");
        }
    }
}