using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Events
{
    public partial class Event1 : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int flag = 0;
                DataTable dt = blu.getEvents(flag);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    Response.Redirect("AddEvent.aspx");
                }

            }
            //DataTable dt = blu.getEvent();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }
        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEvent.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            Response.Redirect("EditEvent.aspx?EventId=" + gr.Cells[1].Text + "&Title=" + gr.Cells[2].Text + "&Description=" + gr.Cells[3].Text + "&Date=" + gr.Cells[4].Text);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }
    }
}