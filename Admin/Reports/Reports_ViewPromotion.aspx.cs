using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_ViewPromotion : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            labelPromotion.Visible = false;
            if(!IsPostBack)
            {
                int year = DateTime.Now.Year;
                for (int i = year - 25; i <= year + 25; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    CmbYear.Items.Add(li);
                }
                CmbYear.Items.FindByText(year.ToString()).Selected = true;

                loadBranch();
            }
        }
        public void loadBranch()
        {
            DataTable dt = blu.getBranchList();
            CmbProject.DataSource = dt;
            CmbProject.DataTextField = "BRANCH_Name";
            CmbProject.DataValueField = "BRANCH_ID";
            CmbProject.DataBind();
            CmbProject.Items.Insert(0, "Select Project");
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_Promotion.aspx");
        }
        protected void CmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            int projectid = int.Parse(CmbProject.SelectedValue);
            string date = CmbYear.SelectedItem.ToString();
            DataTable dt = blu.getPromotionReport(projectid, date);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow value in dt.Rows)
                {
                    DateTime tdate = Convert.ToDateTime(value["TDATE"].ToString());

                    String yy = tdate.Year.ToString();
                    if (yy == date)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Enter Valid Date in Year !!!','warning')", true);
                    }
                }
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Employee are not Promoted in this project and year!!!','warning')", true);
                GridView1.Visible = false;
            }
        }

        protected void CmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProject.SelectedItem.Text == "Select Project")
            {

            }
            else
            {
                int projectid = int.Parse(CmbProject.SelectedValue);
                string date = CmbYear.SelectedItem.ToString();
                DataTable dt = blu.getPromotionReport(projectid, date);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow value in dt.Rows)
                    {
                        DateTime tdate = Convert.ToDateTime(value["TDATE"].ToString());

                        String yy = tdate.Year.ToString();
                        if (yy == date)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Valid Date in Year !!!','warning')", true);
                        }
                    }
                   
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Employee are not Promoted in this project and year!!!','warning')", true);
                    GridView1.Visible = false;
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = GridView1.Rows[rowIndex];
                GridViewRow previousRow = GridView1.Rows[rowIndex + 1];

                if (row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                           previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;
                }
            }
        }

        protected void BtnExport_Click1(object sender, EventArgs e)
        {
            labelPromotion.Visible = true;
             Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewPromotion.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
           
            Panel1.RenderControl(htw);
            GridView1.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
            public override void VerifyRenderingInServerForm(Control control)
            {
            }
        }
    }
