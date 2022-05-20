using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_ViewEmployee : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        string yearlydate;
        string monthlyfrom;
        string monthlyto;
        protected void Page_Load(object sender, EventArgs e)
        {
            labelEmployeeSta.Visible = false;
            int status = int.Parse(Server.UrlDecode(Request.QueryString["status_name"].ToString()));
            if (status == 1)
            {
                DataTable dt = blu.workingemployeeReport(status);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                yearlydate = (Server.UrlDecode(Request.QueryString["dateyearly"].ToString()));

                if (yearlydate == "" || yearlydate == null)
                {
                    monthlyfrom = (Server.UrlDecode(Request.QueryString["monthlyfrom"].ToString()));
                    monthlyto = (Server.UrlDecode(Request.QueryString["monthlyto"].ToString()));

                    DataTable dt = blu.EmployeeReportwithmonthly(status, monthlyfrom, monthlyto);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                }
                else
                {
                    DataTable dt = blu.EmployeeReport(0, 0, yearlydate, status);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                } 
            }
            
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_Employee.aspx");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labelEmployeeSta.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewEmployeeStatus.xls");
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dRow = (DataRowView)e.Row.DataItem;
                int status = int.Parse(Server.UrlDecode(Request.QueryString["status_name"].ToString()));

                if (status == 0)
                {
                    e.Row.Cells[8].Text = "Retired";

                }
                if (status == 1)
                {
                    e.Row.Cells[8].Text = "Working"; 
                }
                if (status == 2)
                {
                    e.Row.Cells[8].Text = "Suspension";

                }
                if (status == 3)
                {
                    e.Row.Cells[8].Text = "Termination";
                }
                if (status == 5)
                {
                    e.Row.Cells[8].Text = "Resigned";
                }
                if (status == 6)
                {
                    e.Row.Cells[8].Text = "Laid_off";
                }
            }
        }
    }
}