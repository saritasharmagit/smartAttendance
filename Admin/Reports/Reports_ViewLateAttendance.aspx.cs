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
    public partial class Reports_ViewLateAttendance : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            labelmonthly.Visible = false;
            int eid = Convert.ToInt32(Server.UrlDecode(Request.QueryString["eid"].ToString()));
            string emp_name = (Server.UrlDecode(Request.QueryString["emp_name"].ToString()));
            DateTime date_from = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["date_from"].ToString()));
            DateTime date_to = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["date_to"].ToString()));
            int condition = int.Parse(Server.UrlDecode(Request.QueryString["con"].ToString()));
           
            dt = blu.Report_LateAttendance(0, 0, date_from, date_to, condition);
            GridView1.DataSource = dt;
            GridView1.DataBind();

           
            lblStartDate.Text = date_from.ToString("yyyy-MM-dd");
            lblEndDate.Text = date_to.ToString("yyyy-MM-dd");
        }
        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dRow = (DataRowView)e.Row.DataItem;
                int condition = int.Parse(Server.UrlDecode(Request.QueryString["con"].ToString()));

                if (condition == 0)
                {
                    e.Row.Cells[4].Text = dRow.Row["intime"].ToString();
                    e.Row.Cells[6].Text = "Early Sign In Records";

                }
                if (condition == 1)
                {
                    e.Row.Cells[4].Text = dRow.Row["intime"].ToString();
                    e.Row.Cells[6].Text = "Late Sign In Records";
                }
                if (condition == 2)
                {
                    e.Row.Cells[4].Text = dRow.Row["outtime"].ToString();
                    e.Row.Cells[6].Text = "Early Sign Out Records";
                }
                if (condition == 3)
                {
                    e.Row.Cells[4].Text = dRow.Row["outtime"].ToString();
                    e.Row.Cells[6].Text = "Late Sign Out Records";
                }
            }
        }

        protected void GV_DataBound(object sender, System.EventArgs e)
        {
            for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow gvRow = GridView1.Rows[rowIndex];
                GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];
                if (gvRow.Cells[0].Text == gvPreviousRow.Cells[0].Text)
                {
                    if (gvPreviousRow.Cells[0].RowSpan < 2)
                    {
                        gvRow.Cells[0].RowSpan = 2;
                    }
                    else
                    {
                        gvRow.Cells[0].RowSpan = gvPreviousRow.Cells[0].RowSpan + 1;
                    }
                    gvPreviousRow.Cells[0].Visible = false;
                }
            }
        }
        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_LateAttendance.aspx");
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labelmonthly.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Late Attendance Report.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 10px; PADDING-LEFT: 10px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");

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

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DataTable dt = (e.Row.DataItem as DataRowView).DataView.Table;
            //    DateTime date = Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["Tdate"]);

            //    if (date > Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["Tdate"]))
            //    {
            //        e.Row.Cells[1].BackColor = Color.FromName("#4CA543");
            //        //if (e.Row.RowIndex > 0)
            //        //{
            //        //    for (int i = subTotalRowIndex; i < e.Row.RowIndex; i++)
            //        //    {
            //        //        subTotal = 0;
            //        //    }
            //        //   // this.AddTotalRow("Sub Total", subTotal.ToString("N2"));
            //        //    subTotalRowIndex = e.Row.RowIndex;
            //        //}
            //        currentdate = date;
            //    }
            //}
        }
    }
}