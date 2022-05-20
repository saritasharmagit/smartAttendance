using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class Grade : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = blu.getGradeList();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[4].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //GridView1.Columns[1].Visible = false;
                //GridView1.Columns[4].Visible = false;
                DataRowView dRow = (DataRowView)e.Row.DataItem;

                if (dRow.Row["sta"].ToString() == "0")
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddGrade.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;

            Response.Redirect("EditGrade.aspx?GRADE_ID=" + gr.Cells[1].Text + "&GRADE_NAME=" + gr.Cells[2].Text + "&GRADE_TYPE=" + gr.Cells[3].Text + "&sta=" + gr.Cells[4].Text);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GridView1.PageIndex = e.NewPageIndex;
            //GridView1.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}