using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class Designation : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = blu.getDesignationList();
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

                if (dRow.Row["sta"].ToString() == "0")
                {
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDesignation.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;

            Response.Redirect("EditDesignation.aspx?DEG_ID=" + gr.Cells[1].Text  + "&DEG_NAME=" + gr.Cells[2].Text + "&sta=" + gr.Cells[3].Text);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GridView1.PageIndex = e.NewPageIndex;
            //GridView1.DataBind();
        }
    }
}