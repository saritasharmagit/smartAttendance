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
    public partial class Reports_ViewRoosterShiftInfo : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int empid, flag;
        DateTime startdate, tilldate;
        protected void Page_Load(object sender, EventArgs e)
        {
            labelrooster.Visible = false;
            empid = int.Parse(Server.UrlDecode(Request.QueryString["eid"].ToString()));
            startdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["startdate"].ToString()));
            tilldate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["tilldate"].ToString()));
            flag = 0;

            blu.Report_RoosterShift(startdate, tilldate, empid, flag);
            DataTable dt = blu.GetRoosterData();
            GridView1.DataSource = dt;
            GridView1.DataBind();

           
            string emp_name = Server.UrlDecode(Request.QueryString["emp_name"]);

            lblEmployee.Text = emp_name.ToString();
           
            lblStartDate.Text = startdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = tilldate.ToString("yyyy-MM-dd");
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text.CompareTo("Weekned") == 0)
                {
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Attributes.Add("colspan", "5");
                    e.Row.Cells[5].BackColor = Color.FromName("#4CA543");
                    e.Row.Cells[5].Font.Size = 11;
                    e.Row.Cells[5].Text = "Weekend Holiday";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_RoosterShiftInfo.aspx");
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labelrooster.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=RoosterShiftInfo Report.xls");
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

    }
}