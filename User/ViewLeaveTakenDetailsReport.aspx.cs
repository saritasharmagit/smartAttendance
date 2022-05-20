﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.User
{
    public partial class ViewLeaveTakenDetailsReport : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int emp_id;
        DateTime sdate, edate;
        protected void Page_Load(object sender, EventArgs e)
        {
            labeltaken.Visible = false;
            emp_id = int.Parse(Server.UrlDecode(Request.QueryString["emp_id"].ToString()));
            sdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["sdate"].ToString()));
            edate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["edate"].ToString()));
           
            int leavemp_id = int.Parse(Server.UrlDecode(Request.QueryString["leavemp_id"].ToString()));
            string emp_name = Server.UrlDecode(Request.QueryString["emp_name"]);
            string leave_name = Server.UrlDecode(Request.QueryString["leave_name"]);

            DataTable dt = blu.LeaveTakenDetail(sdate, edate, emp_id, leavemp_id, 0, 0);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            lblLeavename.Text = leave_name.ToString();

            lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = edate.ToString("yyyy-MM-dd");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveTakenDetailsReport.aspx");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labeltaken.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewLeaveTaken.xls");
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = GridView1.Rows[rowIndex];
                GridViewRow previousRow = GridView1.Rows[rowIndex + 1];


                if (row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                           previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;
                }

            }
        }
    }
}