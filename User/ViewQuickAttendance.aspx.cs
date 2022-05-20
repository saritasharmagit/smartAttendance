using AttendanceKantipur;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.User
{
    public partial class ViewQuickAttendance : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int emp_id, Aflag;
        DateTime sdate, edate;
        DataTable dt, dt1;

        protected void Page_Load(object sender, EventArgs e)
        {
            labelquick.Visible = false;
            emp_id = int.Parse(Server.UrlDecode(Request.QueryString["emp_id"].ToString()));
            sdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["sdate"].ToString()));
            edate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["edate"].ToString()));
            Aflag = 0;

            blu.QuickAttnReport(emp_id, sdate, edate, Aflag);
            DataTable dt = blu.getQuickAttendanceData();
            GridView1.DataSource = dt;
            GridView1.DataBind();

            dt1 = blu.getAllInfo(emp_id);

            lblEmployee.Text = dt.Rows[0]["emp_Fullname"].ToString();
            lblEmployeeID.Text = emp_id.ToString();
          
            lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = edate.ToString("yyyy-MM-dd");

        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuickAttendanceReport.aspx");
        }

        protected void gvEmployee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Date";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "In Time";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Remarks";
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

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "InMode";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Out Time";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Remarks";
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

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "OutMode";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Worked Hour";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Remarks";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White");

                HeaderRow.Cells.Add(HeaderCell2);

                GridView1.Controls[0].Controls.AddAt(0, HeaderRow);

                HeaderRow.Attributes.Add("class", "header");

            }
        }
        int j;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[5].Text.CompareTo("") == 0)
                {
                    for (j = 5; j <= 11; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                        e.Row.Cells[j].BackColor = Color.FromName("#f2656f");
                    }
                    e.Row.Cells[10].Text = "No Out";
                }

                if (e.Row.Cells[11].Text.CompareTo("wee") == 0)
                {
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[10].Attributes.Add("colspan", "10");
                    e.Row.Cells[10].BackColor = Color.FromName("#37CE8A");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;

                }
                else if (e.Row.Cells[11].Text.CompareTo("woh") == 0)
                {
                    for (j = 1; j <= 10; j++)
                    {
                        e.Row.Cells[j].BackColor = Color.FromName("#37CE8A");
                    }
                }
                else if (e.Row.Cells[11].Text.CompareTo("abs") == 0)
                {
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Attributes.Add("colspan", "10");
                    e.Row.Cells[10].BackColor = Color.FromName("#ff8080");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[11].Text.CompareTo("hol") == 0)
                {
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Attributes.Add("colspan", "10");
                    e.Row.Cells[10].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[11].Text.CompareTo("out") == 0)
                {
                    e.Row.Cells[10].Attributes.Add("colspan", "10");
                    e.Row.Cells[10].BackColor = Color.FromName("#aeabd6");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[11].Text.CompareTo("woph") == 0)
                {
                    for (j = 1; j <= 10; j++)
                    {
                        e.Row.Cells[j].BackColor = Color.FromName("#35abd6");

                    }
                }
                else if (e.Row.Cells[11].Text.CompareTo("lev") == 0)
                {
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Attributes.Add("colspan", "10");
                    e.Row.Cells[10].BackColor = Color.FromName("#d68b0a");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[11].Text.CompareTo("Half") == 0)
                {
                    e.Row.Cells[10].Attributes.Add("colspan", "10");
                    e.Row.Cells[10].BackColor = Color.FromName("#d68b0a");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                }
                Label lblremark = (Label)e.Row.FindControl("lblRemarks");
                if (lblremark.Text == "Early In")
                {
                    lblremark.Style.Add("Color", "Green");
                }
                else if (lblremark.Text == "Late In")
                {
                    lblremark.Style.Add("Color", "Red");
                }

                Label lblOutRemark = (Label)e.Row.FindControl("lblOutRemarks");
                if (lblOutRemark.Text == "Late Out")
                {
                    lblOutRemark.Style.Add("Color", "Green");
                }
                else if (lblOutRemark.Text == "Early Out")
                {
                    lblOutRemark.Style.Add("Color", "Red");
                }
            }
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labelquick.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewQuickAttendance.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            panel1.RenderControl(htw);

            GridView1.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}