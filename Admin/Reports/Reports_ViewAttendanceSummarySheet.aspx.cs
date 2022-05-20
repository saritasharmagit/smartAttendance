using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_ViewAttendanceSummarySheet : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int eid, flag;
        DateTime Startdate, Enddate;
        protected void Page_Load(object sender, EventArgs e)
        {
            labelsummary.Visible = false;
            eid = int.Parse(Server.UrlDecode(Request.QueryString["eid"].ToString()));
            Startdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["Startdate"].ToString()));
            Enddate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["Enddate"].ToString()));

            string emp_name = Server.UrlDecode(Request.QueryString["emp_name"]);

            lblStartDate.Text = Startdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = Enddate.ToString("yyyy-MM-dd");


            flag = 0;

            DataTable dt = blu.Monthlyattendance(0, 0, 0, Startdate, Enddate);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_AttendanceSummarySheet.aspx");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labelsummary.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewAttendanceSummarySheet.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel1.RenderControl(htw);

            GridView1.RenderControl(htw);
            Response.Write(stringWriter.ToString());

            //pnlNote.RenderControl(htw);
            Response.End();


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Employee (ID)";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "TotalDays";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Weekend";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Public Holiday";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "WorkingDay";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Total Working Hours";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2); 

              

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Total Leave Days";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Leave Hours";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Office Adjustment(Hours)";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Total Present Days";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Worked Hours";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                GridView1.Controls[0].Controls.AddAt(0, HeaderRow);


                HeaderRow.Attributes.Add("class", "header");

            }
        }
        decimal fridayhrs = 0;
        decimal workinghour = 0;
        int cntfriday = 0;
        int workingday = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[6].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dRow = (DataRowView)e.Row.DataItem;
                 if (e.Row.Cells[7].Text == "" || e.Row.Cells[7].Text == "&nbsp;")
                {
                   
                }
                else
                 {
                     string leavetaken = (e.Row.Cells[7].Text);
                     decimal leave = Convert.ToDecimal(leavetaken);
                     if (leave < 3)
                     {
                         e.Row.Cells[9].Text = "4.00";
                     }
                     else if (leave >= 4 && leave<=9)//between operator
                     {
                         e.Row.Cells[9].Text = "3.00";
                     }
                     else if (leave >= 10 && leave <= 15)
                     {
                         e.Row.Cells[9].Text = "2.00";
                     }
                     else if (leave >= 16 && leave <= 21)
                     {
                         e.Row.Cells[9].Text = "1.00";
                     }
                     else if (leave >= 21 && leave <= 27)
                     {
                         e.Row.Cells[9].Text = "1.00";
                     }
                 }
                if (e.Row.Cells[7].Text == "" || e.Row.Cells[7].Text == "&nbsp;")
                {
                   
                }
                else
                {
                    decimal totalLeavedays = Convert.ToDecimal(e.Row.Cells[7].Text);
                    var values = totalLeavedays.ToString(CultureInfo.InvariantCulture).Split('.');

                    // int secondValue = int.Parse(values[1]);

                    if((values[1]=="50"))
                    {
                        int firstValue = int.Parse(values[0]);
                        decimal secondValue = totalLeavedays - (int)totalLeavedays; //4.012308 - 4 = 0.012308
                        decimal multplier = Convert.ToDecimal(3.3);//for half leave
                        decimal leavefirstval = Convert.ToDecimal(firstValue * 7);
                        decimal leavesecondval = Convert.ToDecimal(multplier);
                        decimal totalLeaveHours = Convert.ToDecimal(leavefirstval + leavesecondval);
                      (e.Row.Cells[8].Text) = (totalLeaveHours.ToString());

                    }
                    else
                    {
                        int firstValue = int.Parse(values[0]);
                       // decimal secondValue = totalLeavedays - (int)totalLeavedays; //4.012308 - 4 = 0.012308
                       // decimal multplier = Convert.ToDecimal(3.5);//for half leave
                        decimal leavefirstval = Convert.ToDecimal(firstValue * 7);
                       
                        decimal totalLeaveHours = Convert.ToDecimal(leavefirstval);
                        e.Row.Cells[8].Text = totalLeaveHours.ToString();
                    }
                   

                   
                }
                if (dRow.Row["cntFday"].ToString() != null)
                {
                     cntfriday = int.Parse(e.Row.Cells[6].Text);

                     workingday = int.Parse(e.Row.Cells[4].Text);

                    int balance = (workingday - cntfriday);
                    workinghour = Convert.ToDecimal(balance * 7);
                    fridayhrs = Convert.ToDecimal(cntfriday * 5);

                    decimal totalworkinghour = Convert.ToDecimal(workinghour + fridayhrs);

                    e.Row.Cells[5].Text = totalworkinghour.ToString();
                }
                else
                {
                    workingday = int.Parse(e.Row.Cells[4].Text);
                    workinghour = Convert.ToDecimal(workingday * 7);

                    e.Row.Cells[5].Text = workinghour.ToString();
                }
            }
        }
    }
}