using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class Company : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = blu.GetAllOrg(); 
            if (dt.Rows.Count == 0)
            {
                Response.Redirect("AddCompany.aspx");
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
     
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Company.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            Response.Redirect("EditCompany.aspx?Org_Id=" + gr.Cells[1].Text + "&Org_Name=" + gr.Cells[2].Text + "&Org_Address=" + gr.Cells[3].Text + "&Org_Address2=" + gr.Cells[4].Text + "&Org_Phone=" + gr.Cells[5].Text + "&Org_Fax=" + gr.Cells[6].Text + "&Org_Email=" + gr.Cells[7].Text + "&Org_Website=" + gr.Cells[8].Text);
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCompany.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {    
            e.Row.Cells[1].Visible = false;
           // e.Row.Cells[4].Visible = false;
        }
    }
}
