using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class HolidaySetup : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        { DataTable dt = blu.getholidaysetup();
        if (dt.Rows.Count == 0)
        {
            Response.Redirect("AddHolidaySetup.aspx");
        }
        else
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
           
        }
        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddHolidaySetup.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[9].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dRow = (DataRowView)e.Row.DataItem;

                if (dRow.Row["sta"].ToString() == "0")
                {
                    e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.Cells[10].ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            Response.Redirect("EditHolidaySetup.aspx?HOLIDAY_ID=" + gr.Cells[1].Text + "&HOLIDAY_NAME=" + gr.Cells[2].Text + "&HOLIDAY_DATE=" + gr.Cells[3].Text + "&HOLIDAY_QTY=" + gr.Cells[4].Text + "&holidayType=" + gr.Cells[5].Text + "&Female_Only=" + gr.Cells[7].Text + "&sta=" + gr.Cells[9].Text);
        }
    }
}