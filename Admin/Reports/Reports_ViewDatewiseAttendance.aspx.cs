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
    public partial class Reports_ViewDatewiseAttendance : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        DateTime sdate, edate;
        int Aflag;
        protected void Page_Load(object sender, EventArgs e)
        {
            labeldatewise.Visible = false;
            sdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["start_date"].ToString()));
            edate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["end_date"].ToString()));
            int eid = Convert.ToInt32(Server.UrlDecode(Request.QueryString["eid"].ToString()));
            string emp_name = (Server.UrlDecode(Request.QueryString["emp_name"].ToString()));

            lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = edate.ToString("yyyy-MM-dd");
            Aflag = 0;


            DataTable dt1 = blu.DatewiseAttendanceReport();

            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
        protected void GridView1_DataBound(object sender, System.EventArgs e)
        {


            for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow gvRow = GridView1.Rows[rowIndex];
                GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];
                for (int cellCount = 0; cellCount < 2; cellCount++)
                {
                    if (gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text)
                    {
                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;
                    }
                }
            }
        }


        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_DateWiseAttendance.aspx");
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labeldatewise.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewDateWiseAttendance.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel1.RenderControl(htw);
            GridView1.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

            //    TableCell HeaderCell2 = new TableCell();
            //    HeaderCell2.Text = "Emp Id";
            //    HeaderRow.Cells.Add(HeaderCell2);

            //    HeaderCell2 = new TableCell();
            //    HeaderCell2.Text = "Employee Name";
            //    HeaderRow.Cells.Add(HeaderCell2);

            //    HeaderCell2 = new TableCell();
            //    HeaderCell2.Text = "";
            //    HeaderRow.Cells.Add(HeaderCell2);

            //    HeaderCell2 = new TableCell();
            //    HeaderCell2.Text = "";
            //    HeaderRow.Cells.Add(HeaderCell2);

            //    GridView1.Controls[0].Controls.AddAt(0, HeaderRow);


            //    GridViewRow HeaderRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            //    TableCell HeaderCell = new TableCell();
            //    HeaderCell.Text = "";
            //    HeaderRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "";
            //    HeaderRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "intime";
            //    HeaderRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "outime";
            //    HeaderRow1.Cells.Add(HeaderCell);

            //    GridView1.Controls[0].Controls.AddAt(1, HeaderRow1);

            //    HeaderRow.Attributes.Add("class", "header");
            //    HeaderRow1.Attributes.Add("class", "header");

            //}
        }
        int j;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[6].Visible = false;
          
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                if (e.Row.Cells[6].Text.CompareTo("wee") == 0)
                {
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                   
                    e.Row.Cells[5].Attributes.Add("colspan", "3");
                    e.Row.Cells[5].BackColor = Color.FromName("#37CE8A");
                    e.Row.Cells[5].Font.Size = 10;
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;

                }
                else if (e.Row.Cells[6].Text.CompareTo("lev") == 0)
                {
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;

                    e.Row.Cells[5].Attributes.Add("colspan", "3");
                    e.Row.Cells[5].BackColor = Color.FromName("#d68b0a");
                    e.Row.Cells[5].Font.Size = 10;
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[6].Text.CompareTo("abs") == 0)
                {
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                   
                    e.Row.Cells[5].Attributes.Add("colspan", "3");
                    e.Row.Cells[5].BackColor = Color.FromName("#ff8080");
                    e.Row.Cells[5].Font.Size = 10;
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[6].Text.CompareTo("hol") == 0)
                {
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    
                    e.Row.Cells[5].Attributes.Add("colspan", "3");
                    e.Row.Cells[5].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[5].Font.Size = 10;
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }

            }
        }
    }
}