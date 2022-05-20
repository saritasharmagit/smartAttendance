using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.HR_Mgmt
{
    public partial class Promotion : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = blu.getPromotionList();
                if (dt.Rows.Count == 0)
                {
                    Response.Redirect("AddPromotion.aspx");
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
            Response.Redirect("AddPromotion.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
             GridViewRow gr = GridView1.SelectedRow;
             Response.Redirect("ShowPromotionDetails.aspx?EMP_ID=" + gr.Cells[5].Text);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
        }
    }
}