using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_ViewDailyAbsent : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        DateTime sdate;
        string branch = "";
        string department = "";
        int eid;
        protected void Page_Load(object sender, EventArgs e)
        {
            labelabsent.Visible = false;
            sdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["date"].ToString()));

            DataTable dt = blu.DailyAbsent(branch, department, sdate);
            GridView1.DataSource = dt;
            GridView1.DataBind();
          
           
         
            lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labelabsent.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewDailyAbsent.xls");
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

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_DailyAbsent.aspx");
        }
    }
}