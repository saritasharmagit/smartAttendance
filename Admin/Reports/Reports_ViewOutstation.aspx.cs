using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_ViewOutstation : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        DataTable dt;
        int eid;
        protected void Page_Load(object sender, EventArgs e)
        {
            labeloutstation.Visible = false; 
          DateTime sdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["start_date"].ToString()));
          DateTime edate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["end_date"].ToString()));

          lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
          lblEndDate.Text = edate.ToString("yyyy-MM-dd");
          if (Server.UrlDecode(Request.QueryString["emp_name"]) == "" || Convert.ToInt32(Server.UrlDecode(Request.QueryString["eid"].ToString())) == 0)
          {
               dt = blu.GetOutstationReport(0, sdate, edate);
              GridView1.DataSource = dt;
              GridView1.DataBind();
          }
          else
          {
               eid = Convert.ToInt32(Server.UrlDecode(Request.QueryString["eid"].ToString()));
               dt = blu.GetOutstationReport(eid, sdate, edate);
              GridView1.DataSource = dt;
              GridView1.DataBind();
          }
            }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_Outstation.aspx");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labeloutstation.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewOutstation.xls");
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