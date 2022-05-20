using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_ViewLeaveInformation : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            labelleave.Visible = false;
            if (Server.UrlDecode(Request.QueryString["emp_name"]) == "" || int.Parse(Server.UrlDecode(Request.QueryString["EMPID"].ToString()))==0)
            {
                DataTable dt = blu.LeaveInformation(0, 0, 0);
                GridView1.DataSource = dt;
                GridView1.DataBind();

              
            }
            else
            {
                string emp_name = Server.UrlDecode(Request.QueryString["emp_name"]);
                int EMPID = int.Parse(Server.UrlDecode(Request.QueryString["EMPID"].ToString()));

                //lblEmployee.Text = emp_name.ToString();
                //lblEmployeeID.Text = EMPID.ToString();

                DataTable dt = blu.LeaveInformation(0, 0, EMPID);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
          
        }
        protected void GridView1_DataBound(object sender, System.EventArgs e)
        {
            

            //for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            //{
            //    GridViewRow gvRow = GridView1.Rows[rowIndex];
            //    GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];
            //    for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
            //    {
            //        if (gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text)
            //        {
            //            if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
            //            {
            //                gvRow.Cells[cellCount].RowSpan = 2;
            //            }
            //            else
            //            {
            //                gvRow.Cells[cellCount].RowSpan =
            //                    gvPreviousRow.Cells[cellCount].RowSpan + 1;
            //            }
            //            gvPreviousRow.Cells[cellCount].Visible = false;
            //        }
            //    }
            //}
        }
        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_LeaveInformation.aspx");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labelleave.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewLeaveInformation.xls");
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

                if (dRow.Row["LEAVE_DATE"].ToString() == "")
                {
                    string taken = (e.Row.Cells[4].Text);
                    decimal tak = Convert.ToDecimal(taken);
                    string given = (e.Row.Cells[3].Text);
                    decimal giv = Convert.ToDecimal(given);
                    string openflg = (e.Row.Cells[2].Text);
                    decimal OP = Convert.ToDecimal(openflg);

                    decimal balance = ((OP + giv) - tak);
                    e.Row.Cells[5].Text = balance.ToString();
                }
                else
                {
                    e.Row.Cells[5].Text = "";
                }
            }


            for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = GridView1.Rows[rowIndex];
                GridViewRow previousRow = GridView1.Rows[rowIndex + 1];


                if (row.Cells[0].Text == previousRow.Cells[0].Text && row.Cells[1].Text == previousRow.Cells[1].Text)
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                           previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;


                    row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 :
                                          previousRow.Cells[1].RowSpan + 1;
                    previousRow.Cells[1].Visible = false;
                }
                else if (row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                         previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;
                }

            }
           
        }
    }
}