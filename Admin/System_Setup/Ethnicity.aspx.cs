using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class Ethnicity : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = blu.getEthnicity();
            if(dt.Rows.Count==0)
            {
                Response.Redirect("AddEthnicity.aspx");               
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataRowView dRow = (DataRowView)e.Row.DataItem;

                if (dRow.Row["Status"].ToString() == "0")
                {
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            Response.Redirect("EditEthnicity.aspx?Ethnicity_Id=" + gr.Cells[1].Text + "&Ethnicity_Name=" + gr.Cells[2].Text + "&Status=" + gr.Cells[3].Text);
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEthnicity.aspx");
        }
    }
}