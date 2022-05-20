using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.OutStation
{
    public partial class Outstation : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable dt = blu.GetOutstation();
                if(dt.Rows.Count>0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    Response.Redirect("AddOutstation.aspx");
                }
            }
           
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddOutstation.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
             GridViewRow gr = GridView1.SelectedRow;
             Response.Redirect("EditOutstation.aspx?VNO=" + gr.Cells[6].Text  + "&SDATE=" + gr.Cells[3].Text + "&EDATE=" + gr.Cells[4].Text);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[6].Visible = false;
        }
    }
}