using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class LeaveSetup : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = blu.getLeaveSetup();
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            else
            {
                Response.Redirect("AddLeaveSetup.aspx");
            }

          
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            Response.Redirect("EditLeaveSetup.aspx?LEAVE_ID=" + gr.Cells[1].Text);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dRow = (DataRowView)e.Row.DataItem;

                if (dRow.Row["status"].ToString() == "0")
                {
                    e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.Cells[10].ForeColor = System.Drawing.Color.Green;
                }

                if(dRow.Row["LEAVE_TYPE"].ToString() == "0")
                {
                    e.Row.Cells[3].Text = "Expire Yearly";
                }
                else if (dRow.Row["LEAVE_TYPE"].ToString() == "1")
                {
                    e.Row.Cells[3].Text = "Accumulative";
                }
                else
                {
                    e.Row.Cells[3].Text = "Service Period";
                }
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLeaveSetup.aspx");
        }
    }
}
   