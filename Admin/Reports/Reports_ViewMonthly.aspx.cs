using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_ViewMonthly : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int eid, flag;
        DateTime Startdate, Enddate;
        protected void Page_Load(object sender, EventArgs e)
        {
            labelmonthly.Visible = false;
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
            Response.Redirect("Reports_MonthlyAttendance.aspx");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labelmonthly.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewMonthlyAttendance.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
           Panel1.RenderControl(htw);

            GridView1.RenderControl(htw);
            Response.Write(stringWriter.ToString());

            pnlNote.RenderControl(htw);
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
                HeaderCell2.Text = "Absent Days";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Home";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Sick";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Kriya";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Maternity";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Paternity";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Festival";
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
                HeaderCell2.Text = "Present Days";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Worked On Weekend";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Worked On PH";
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

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Assigned Hours";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Difference";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                GridView1.Controls[0].Controls.AddAt(0, HeaderRow);


                GridViewRow HeaderRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = " ";
                HeaderCell.ColumnSpan = 6;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Leave";
                HeaderCell.ColumnSpan = 7;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 4;
                HeaderCell.Text = "";
                HeaderRow1.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.ColumnSpan = 5;
                //HeaderCell.Text = "Attendance";
                //HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 3;
                HeaderCell.Text = "";
                HeaderRow1.Cells.Add(HeaderCell);

                GridView1.Controls[0].Controls.AddAt(1, HeaderRow1);

                HeaderRow.Attributes.Add("class", "header");
                HeaderRow1.Attributes.Add("class", "header");

            }
        }
    }
}