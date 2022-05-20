using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class Bank : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 DataTable dt = blu.GetBank();
                if(dt.Rows.Count==0)
                {
                    Response.Redirect("AddBank.aspx");
                }
                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBank.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            //e.Row.Cells[7].Visible = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            Response.Redirect("EditBank.aspx?BANK_ID=" + gr.Cells[1].Text + "&BANK_CODE=" + gr.Cells[2].Text + "&BANK_NAME=" + gr.Cells[3].Text + "&Account_Id=" + gr.Cells[4].Text);
        }
    }
}