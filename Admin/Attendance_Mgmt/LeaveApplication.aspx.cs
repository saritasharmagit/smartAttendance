using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Attendance_Mgmt
{
    public partial class LeaveApplication : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //string EMP_ID = Session["username"].ToString();
                DataTable dt = blu.getLeaveApplicationList();
                if(dt.Rows.Count>0)
                {
                    GridView.DataSource = dt;
                    GridView.DataBind();
                }
                else
                {
                    Response.Redirect("AddLeaveApplication.aspx");
                }
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLeaveApplication.aspx");
        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[12].Visible = false;
      
            e.Row.Cells[14].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dRow = (DataRowView)e.Row.DataItem;

                if (dRow.Row["LEAVETYPE"].ToString() == "N    ")
                {
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[11].Text = "Normal Leave";
                }
                else if (dRow.Row["LEAVETYPE"].ToString() == "F    ")
                {
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.Blue;
                    e.Row.Cells[11].Text = "Force Leave";
                }
                else if (dRow.Row["LEAVETYPE"].ToString() == "G    ")
                {
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[11].Text = "Negative Leave";
                }
                else if (dRow.Row["LEAVETYPE"].ToString() == "U    ")
                {
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[11].Text = "Urgent Leave";
                }

                if (dRow.Row["status"].ToString() == "1")
                {
                    e.Row.Cells[13].ForeColor = System.Drawing.Color.Blue;
                    e.Row.Cells[13].Text = "Pending";
                }
                else if (dRow.Row["status"].ToString() == "2")
                {
                    e.Row.Cells[13].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[13].Text = "Approved";
                }
                else
                {
                    e.Row.Cells[13].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[13].Text = "DisApproved";
                }
            }
        }

        protected void GridView_Merge_Header_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //Build custom header.
                GridView oGridView = (GridView)sender;
                GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell oTableCell = new TableCell();
                oTableCell.Text = "S.No";
                oTableCell.Font.Size = 11;
                oTableCell.BackColor = Color.FromName("#507CD1");
                oTableCell.ForeColor = Color.FromName("White"); 
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Employee";
                oTableCell.Font.Size = 11;
                oTableCell.BackColor = Color.FromName("#507CD1");
                oTableCell.ForeColor = Color.FromName("White"); 
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Date";
                oTableCell.Font.Size = 11;
                oTableCell.BackColor = Color.FromName("#507CD1");
                oTableCell.ForeColor = Color.FromName("White"); 
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Leave Name";
                oTableCell.Font.Size = 11;
                oTableCell.BackColor = Color.FromName("#507CD1");
                oTableCell.ForeColor = Color.FromName("White"); 
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Taken";
                oTableCell.Font.Size = 11;
                oTableCell.BackColor = Color.FromName("#507CD1");
                oTableCell.ForeColor = Color.FromName("White"); 
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Remarks";
                oTableCell.Font.Size = 11;
                oTableCell.BackColor = Color.FromName("#507CD1");
                oTableCell.ForeColor = Color.FromName("White"); 
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

             
                oTableCell = new TableCell();
                oTableCell.Text = "Approved Name";
                oTableCell.Font.Size = 11;
                oTableCell.BackColor = Color.FromName("#507CD1");
                oTableCell.ForeColor = Color.FromName("White");
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

              

                oTableCell = new TableCell();
                oTableCell.Text = "Leave Type";
                oTableCell.Font.Size = 11;
                oTableCell.BackColor = Color.FromName("#507CD1");
                oTableCell.ForeColor = Color.FromName("White"); 
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");


                oTableCell = new TableCell();
                oTableCell.Text = "Status";
                oTableCell.Font.Size = 11;
                oTableCell.BackColor = Color.FromName("#507CD1");
                oTableCell.ForeColor = Color.FromName("White"); 
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Actions";
                oTableCell.Font.Size = 11;
                oTableCell.BackColor = Color.FromName("#507CD1");
                oTableCell.ForeColor = Color.FromName("White"); 
                oTableCell.ColumnSpan = 2;
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell.Attributes.Add("class", "header");
                oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);
            }
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView.Rows[index];
                TableCell id = selectedRow.Cells[1];
                int sNO = int.Parse(id.Text);

                int status = 2;
                int i = blu.updateLeaveApplication(status, sNO);
                TableCell DATE1 = selectedRow.Cells[3];
                //DateTime date1 = DateTime.Now;
                DateTime date = Convert.ToDateTime(DATE1.Text);
                TableCell EMP_ID1 = selectedRow.Cells[14];
                string EMP_ID = (EMP_ID1.Text);
                TableCell LEAVE_ID1 = selectedRow.Cells[4];
                int LEAVE_ID = Convert.ToInt32(LEAVE_ID1.Text);
                TableCell TAKEN1 = selectedRow.Cells[6];
                string TAKEN = (TAKEN1.Text);
                TableCell REMARKS1 = selectedRow.Cells[7];
                string REMARKS = (REMARKS1.Text);
                TableCell Senior_EMP_ID1 = selectedRow.Cells[8];
                string Senior_EMP_ID = (Senior_EMP_ID1.Text);
                TableCell DAYPART1 = selectedRow.Cells[12];
                string DAYPART =(DAYPART1.Text);
                TableCell LEAVETYPE1 = selectedRow.Cells[11];
                string LEAVETYPE = (LEAVETYPE1.Text);
                

                blu.CreateLeaveApplication(date, EMP_ID, LEAVE_ID, TAKEN, REMARKS, Senior_EMP_ID, DAYPART, LEAVETYPE, status);
                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Leave Approved Successfully','success').then((value) => { window.location ='LeaveApplication.aspx'; });", true);
                }
            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView.Rows[index];
                TableCell id = selectedRow.Cells[1];
                int sNO = int.Parse(id.Text);
                int status = 3;
                int i = blu.updateLeaveApplication(status, sNO);

                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Good job!','Leave DisApproved Successfully','success').then((value) => { window.location ='LeaveApplication.aspx'; });", true);

                }
            }
        }

       
    }
}