using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class BranchSetup : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = blu.getBranch();
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[8].Visible = false;
          
        }
        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBranch.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            Response.Redirect("EditBranchSetup.aspx?BRANCH_ID=" + gr.Cells[1].Text + "&BRANCH_CODE=" + gr.Cells[2].Text + "&ABBREVIATION=" + gr.Cells[3].Text + "&BRANCH_NAME=" + gr.Cells[4].Text + "&ValidFrom=" + gr.Cells[5].Text + "&ValidTo=" + gr.Cells[6].Text + "&sta=" + gr.Cells[8].Text + "&ExtendDate=" + gr.Cells[7].Text);
        }
      
    }
}
