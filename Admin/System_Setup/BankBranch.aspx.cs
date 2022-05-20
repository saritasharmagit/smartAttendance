using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class BankBranch : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = blu.getBankBranch();
                if (dt.Rows.Count == 0)
                {
                    Response.Redirect("AddBankBranch.aspx");
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
            Response.Redirect("AddBankBranch.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            Response.Redirect("EditBankBranch.aspx?Branch_Id=" + gr.Cells[1].Text + "&BANK_NAME=" + gr.Cells[2].Text + "&Address1=" + gr.Cells[3].Text + "&Address2=" + gr.Cells[4].Text);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }
    }
}