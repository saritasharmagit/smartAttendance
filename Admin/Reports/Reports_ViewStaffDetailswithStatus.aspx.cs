using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_ViewStaffDetailswithStatus : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int statusid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lblDetails.Visible = false;
                labelstaffdetails.Visible = false;
                lblProject_position.Visible = false;
                lblgender_ethnicity.Visible = false;
                lblPosition_gender.Visible = false;
                lblP_P_G.Visible = false;

                if (int.Parse(Request.QueryString["status"]) != null)
                {
                    statusid = int.Parse(Request.QueryString["status"]);
                    DataTable dt = blu.EmployeesListwithStatus(statusid);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = false;
                GridView5.Visible = false;
                GridView6.Visible = false;

                BtnExport.Visible = true;
                btnExpposition_gender.Visible = false;
                btnExpposition_project.Visible = false;
                btnExpproject_gender.Visible = false;
                btnExpgender_ethnicity.Visible = false;
                btnExpPr_Po_Ge.Visible = false;
            }
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            lblDetails.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewStaffDetails.xls");
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

        protected void btnProject_Gender_Click(object sender, EventArgs e)
        {


            GridView1.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = false;
            GridView5.Visible = false;
            GridView6.Visible = false;
            GridView2.Visible = true;

            if (int.Parse(Request.QueryString["status"]) != null)
            {
                statusid = int.Parse(Request.QueryString["status"]);
                DataTable dt = blu.Gender_ProjectwithStatus(statusid);

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }



            BtnExport.Visible = false;
            btnExpposition_gender.Visible = false;
            btnExpposition_project.Visible = false;
            btnExpproject_gender.Visible = true;
            btnExpgender_ethnicity.Visible = false;
            btnExpPr_Po_Ge.Visible = false;
        }

        protected void btnPosition_Project_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView4.Visible = false;
            GridView5.Visible = false;
            GridView6.Visible = false;
            GridView3.Visible = true;

            if (int.Parse(Request.QueryString["status"]) != null)
            {
                statusid = int.Parse(Request.QueryString["status"]);
                DataTable dt = blu.Position_ProjectwithStatus(statusid);
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }

            BtnExport.Visible = false;
            btnExpposition_gender.Visible = false;
            btnExpposition_project.Visible = true;
            btnExpproject_gender.Visible = false;
            btnExpgender_ethnicity.Visible = false;
            btnExpPr_Po_Ge.Visible = false;
        }

        protected void btnGender_Ethnicity_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView5.Visible = false;
            GridView6.Visible = false;
            GridView4.Visible = true;

            if (int.Parse(Request.QueryString["status"]) != null)
            {
                statusid = int.Parse(Request.QueryString["status"]);
                DataTable dt = blu.Gender_EthnicitywithStatus(statusid);
                GridView4.DataSource = dt;
                GridView4.DataBind();
            }
            BtnExport.Visible = false;
            btnExpposition_gender.Visible = false;
            btnExpposition_project.Visible = false;
            btnExpproject_gender.Visible = false;
            btnExpgender_ethnicity.Visible = true;
            btnExpPr_Po_Ge.Visible = false;
        }

        protected void btnPosition_Gender_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = false;
            GridView6.Visible = false;
            GridView5.Visible = true;

            if (int.Parse(Request.QueryString["status"]) != null)
            {
                statusid = int.Parse(Request.QueryString["status"]);
                DataTable dt = blu.Position_GenderwithStatus(statusid);
                GridView5.DataSource = dt;
                GridView5.DataBind();
            }

            BtnExport.Visible = false;
            btnExpposition_gender.Visible = true;
            btnExpposition_project.Visible = false;
            btnExpproject_gender.Visible = false;
            btnExpgender_ethnicity.Visible = false;
            btnExpPr_Po_Ge.Visible = false;
        }

        protected void btnProject_Position_Gender_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = false;
            GridView5.Visible = false;
            GridView6.Visible = true;

            if (int.Parse(Request.QueryString["status"]) != null)
            {
                statusid = int.Parse(Request.QueryString["status"]);
                DataTable dt = blu.Project_Position_GenderwithStatus(statusid);
                GridView6.DataSource = dt;
                GridView6.DataBind();
            }

            BtnExport.Visible = false;
            btnExpposition_gender.Visible = false;
            btnExpposition_project.Visible = false;
            btnExpproject_gender.Visible = false;
            btnExpgender_ethnicity.Visible = false;
            btnExpPr_Po_Ge.Visible = true;
        }
        int totalM = 0;
        int totalF = 0;
        int total = 0;
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalM += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Male"));
                totalF += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Female"));
                total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Total"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = totalM.ToString();
                e.Row.Cells[3].Text = totalF.ToString();
                e.Row.Cells[4].Text = total.ToString();
            }
        }
        int Total = 0;
        int manager = 0;
        int officer = 0;
        int assistant = 0;
        int support = 0;
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                manager += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Manager"));
                officer += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Officer"));
                assistant += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Assistant"));
                support += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Support"));
                Total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Total"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = manager.ToString();
                e.Row.Cells[3].Text = officer.ToString();
                e.Row.Cells[4].Text = assistant.ToString();
                e.Row.Cells[5].Text = support.ToString();
                e.Row.Cells[6].Text = Total.ToString();
            }
        }
        int TotalM = 0;
        int TotalF = 0;
        int totalemp = 0;
        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalM += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Male"));
                TotalF += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Female"));
                totalemp += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Total"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = TotalM.ToString();
                e.Row.Cells[3].Text = TotalF.ToString();
                e.Row.Cells[4].Text = totalemp.ToString();
            }
        }
        int Tmale = 0;
        int Tfemale = 0;
        int Temp = 0;
        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Tmale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Male"));
                Tfemale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Female"));
                Temp += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Total"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = Tmale.ToString();
                e.Row.Cells[3].Text = Tfemale.ToString();
                e.Row.Cells[4].Text = Temp.ToString();
            }

        }
        int mngmale = 0;
        int mngfemale = 0;
        int ofcmale = 0;
        int ofcfemale = 0;
        int astmale = 0;
        int astfemale = 0;
        int spmale = 0;
        int spfemale = 0;
        int TMale = 0;
        int TFemale = 0;
        protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                mngmale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ManagerMale"));
                mngfemale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ManagerFemale"));
                ofcmale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OfficerMale"));
                ofcfemale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OfficerFemale"));
                astmale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AssistantMale"));
                astfemale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AssistantFemale"));

                spmale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SupportMale"));
                spfemale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SupportFemale"));

                TMale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Maletotal"));
                TFemale += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Femaletotal"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = mngmale.ToString();
                e.Row.Cells[3].Text = mngfemale.ToString();
                e.Row.Cells[4].Text = ofcmale.ToString();
                e.Row.Cells[5].Text = ofcfemale.ToString();
                e.Row.Cells[6].Text = astmale.ToString();
                e.Row.Cells[7].Text = astfemale.ToString();
                e.Row.Cells[8].Text = spmale.ToString();
                e.Row.Cells[9].Text = spfemale.ToString();
                e.Row.Cells[10].Text = TMale.ToString();
                e.Row.Cells[11].Text = TFemale.ToString();
            }
        }

        protected void btnExpproject_gender_Click(object sender, EventArgs e)
        {
            labelstaffdetails.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewDetailsProject_Gender.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");

            Panel1.RenderControl(htw);
            GridView2.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        protected void btnExpposition_project_Click(object sender, EventArgs e)
        {
            lblProject_position.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewDetailsByProject_Position.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");

            Panel1.RenderControl(htw);
            GridView3.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        protected void btnExpgender_ethnicity_Click(object sender, EventArgs e)
        {
            lblgender_ethnicity.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewDetailsByethnicity_Gender.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");

            Panel1.RenderControl(htw);
            GridView4.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        protected void btnExpposition_gender_Click(object sender, EventArgs e)
        {
            lblPosition_gender.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewDetailsByPosition_Gender.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");

            Panel1.RenderControl(htw);
            GridView5.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        protected void btnExpPr_Po_Ge_Click(object sender, EventArgs e)
        {
            lblP_P_G.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewDetailsByProject_Position_Gender.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");

            Panel1.RenderControl(htw);
            GridView6.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        protected void btnNew_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Reports_StaffDetails.aspx");
        }

        protected void GridView6_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow HeaderRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "S.N";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.BackColor = Color.FromName("#507CD1");
                HeaderCell.ForeColor = Color.FromName("White");
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Project Name";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.BackColor = Color.FromName("#507CD1");
                HeaderCell.ForeColor = Color.FromName("White");
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Manager";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.BackColor = Color.FromName("#507CD1");
                HeaderCell.ForeColor = Color.FromName("White");
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Officer";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.BackColor = Color.FromName("#507CD1");
                HeaderCell.ForeColor = Color.FromName("White");
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 2;
                HeaderCell.BackColor = Color.FromName("#507CD1");
                HeaderCell.ForeColor = Color.FromName("White");
                HeaderCell.Text = "Assistant";
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 2;
                HeaderCell.BackColor = Color.FromName("#507CD1");
                HeaderCell.ForeColor = Color.FromName("White");
                HeaderCell.Text = "Support";
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 2;
                HeaderCell.BackColor = Color.FromName("#507CD1");
                HeaderCell.ForeColor = Color.FromName("White");
                HeaderCell.Text = "Total";
                HeaderRow1.Cells.Add(HeaderCell);

                GridView6.Controls[0].Controls.AddAt(0, HeaderRow1);


                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell2 = new TableCell();
                HeaderCell2.Text = "";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Male";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Female";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Male";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Female";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Male";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Female";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Male";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Female";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Male";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Female";
                HeaderCell2.Font.Size = 10;
                HeaderRow.Cells.Add(HeaderCell2);

                GridView6.Controls[0].Controls.AddAt(1, HeaderRow);

                HeaderRow.Attributes.Add("class", "header");
                HeaderRow1.Attributes.Add("class", "header");
            }
        }
    }
}