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
    public partial class Reports_ViewQuickAttendance : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        int eid, Aflag;
        DateTime sdate, edate;
     
        protected void Page_Load(object sender, EventArgs e)
        {

            labelquick.Visible = false;

            eid = int.Parse(Server.UrlDecode(Request.QueryString["eid"].ToString()));
            sdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["sdate"].ToString()));
            edate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["edate"].ToString()));
            sdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["sdate"].ToString()));
            edate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["edate"].ToString()));
            Aflag = 0;

            DataTable dataTable2 = new DataTable();
            dataTable2.Columns.Add("Emp_Id");

            dataTable2.Columns.Add("Tdate");
            dataTable2.Columns.Add("InTime");
            dataTable2.Columns.Add("Inremark");
            dataTable2.Columns.Add("Indiff");
            dataTable2.Columns.Add("Inmode");
            dataTable2.Columns.Add("Outtime");
            dataTable2.Columns.Add("Outremark");
           // dataTable2.Columns.Add("Outdiff");
            dataTable2.Columns.Add("Outmode");
            dataTable2.Columns.Add("worked_hrs");
            dataTable2.Columns.Add("Remarks");
            dataTable2.Columns.Add("Shift");
            dataTable2.Columns.Add("flag");
            string a = "0";
            string b;

            DataTable dt = blu.getQuickAttendanceData();

            foreach (DataRow value in dt.Rows)
            {

                b = value["Emp_Id"].ToString();

                DataTable dtid = blu.EmployeeDetailInformation(int.Parse(b));
                string empname = dtid.Rows[0]["emp_fullname"].ToString();
                if (a == b)
                {
                    DateTime result = Convert.ToDateTime(value["Tdate"].ToString());
                    string tdate = result.ToString("MM-dd");
                    dataTable2.Rows.Add(new string[] { value["Emp_Id"].ToString(), tdate, value["InTime"].ToString(), value["Inremark"].ToString(), value["Indiff"].ToString(), value["Inmode"].ToString(), value["Outtime"].ToString(), value["Outremark"].ToString(), /*value["Outdiff"].ToString(),*/ value["Outmode"].ToString(), value["worked_hrs"].ToString(), value["Remarks"].ToString(), value["Shift"].ToString(), value["flag"].ToString() });
                  
                }
                else
                {
                    DateTime result = Convert.ToDateTime(value["Tdate"].ToString());
                   string tdate = result.ToString("MM-dd");

                    dataTable2.Rows.Add(new string[] { "empname ", value["emp_fullname"].ToString() });

                    //if (!String.IsNullOrEmpty(value["Emp_Id"].ToString()) && String.IsNullOrEmpty(value["InTime"].ToString()))
                    //    {
                    //        value["Emp_Id"] = value["InTime"].ToString(); //assign value of column 4 to column1 
                    //    }

                    //dataTable2.Columns.Remove("InTime"); //delete column 4
                    dataTable2.Rows.Add(new string[] { value["Emp_Id"].ToString(), tdate, value["InTime"].ToString(), value["Inremark"].ToString(), value["Indiff"].ToString(), value["Inmode"].ToString(), value["Outtime"].ToString(), value["Outremark"].ToString(), /*value["Outdiff"].ToString(),*/ value["Outmode"].ToString(), value["worked_hrs"].ToString(), value["Remarks"].ToString(), value["Shift"].ToString(), value["flag"].ToString() });
 
                    
                }
                a = value["Emp_Id"].ToString();
            }

            GridView1.DataSource = dataTable2;
            GridView1.DataBind();
          
            string emp_name = Server.UrlDecode(Request.QueryString["emp_name"]);

          
            lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = edate.ToString("yyyy-MM-dd");
        }

      
        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_QuickAttendance.aspx");
        }

        protected void gvEmployee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Date";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");  
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "In Time";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Remarks";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Difference";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "InMode";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Out Time";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Remarks";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                //HeaderCell2 = new TableCell();
                //HeaderCell2.Text = "Difference";
                //HeaderCell2.Font.Size = 10;
                //HeaderCell2.BackColor = Color.FromName("#507CD1");
                //HeaderCell2.ForeColor = Color.FromName("White"); 
                //HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "OutMode";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Worked Hour";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Remarks";
                HeaderCell2.Font.Size = 10;
                HeaderCell2.BackColor = Color.FromName("#507CD1");
                HeaderCell2.ForeColor = Color.FromName("White"); 
    
                HeaderRow.Cells.Add(HeaderCell2);

                GridView1.Controls[0].Controls.AddAt(0, HeaderRow);

                HeaderRow.Attributes.Add("class", "header");

            }
        }
        int j;
        //private bool _alternate = false;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                if (e.Row.Cells[5].Text.CompareTo("") == 0)
                {
                    for (j = 5; j <= 11; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                        e.Row.Cells[j].BackColor = Color.FromName("#f2656f");
                    }
                    e.Row.Cells[10].Text = "No Out";
                }

                if (e.Row.Cells[11].Text.CompareTo("wee") == 0)
                {
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[10].Attributes.Add("colspan", "10");
                    e.Row.Cells[10].BackColor = Color.FromName("#37CE8A");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;

                }
                else if (e.Row.Cells[11].Text.CompareTo("woh") == 0)
                {
                    for (j = 1; j <= 10; j++)
                    {
                        e.Row.Cells[j].BackColor = Color.FromName("#37CE8A");
                    }
                }
                else if (e.Row.Cells[11].Text.CompareTo("abs") == 0)
                {
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Attributes.Add("colspan", "10");
                    e.Row.Cells[10].BackColor = Color.FromName("#ff8080");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[11].Text.CompareTo("hol") == 0)
                {
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Attributes.Add("colspan", "10");
                    e.Row.Cells[10].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[11].Text.CompareTo("out") == 0)
                {
                    e.Row.Cells[10].Attributes.Add("colspan", "10");
                    e.Row.Cells[10].BackColor = Color.FromName("#aeabd6");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[11].Text.CompareTo("woph") == 0)
                {
                    for (j = 1; j <= 10; j++)
                    {
                        e.Row.Cells[j].BackColor = Color.FromName("#35abd6");

                    }
                }
                else if (e.Row.Cells[11].Text.CompareTo("lev") == 0)
                {
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Attributes.Add("colspan", "10");
                    e.Row.Cells[10].BackColor = Color.FromName("#d68b0a");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[11].Text.CompareTo("Half") == 0)
                {
                    e.Row.Cells[10].Attributes.Add("colspan", "1");
                    e.Row.Cells[10].BackColor = Color.FromName("#d68b0a");
                    e.Row.Cells[10].Font.Size = 10;
                    e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                }
                Label lblremark = (Label)e.Row.FindControl("lblRemarks");
                if (lblremark.Text == "Early In")
                {
                    lblremark.Style.Add("Color", "Green");
                }
                else if (lblremark.Text == "Late In")
                {
                    lblremark.Style.Add("Color", "Red");
                }

                Label lblOutRemark = (Label)e.Row.FindControl("lblOutRemarks");
                if (lblOutRemark.Text == "Late Out")
                {
                    lblOutRemark.Style.Add("Color", "Green");
                }
                else if (lblOutRemark.Text == "Early Out")
                {
                    lblOutRemark.Style.Add("Color", "Red");
                }
            }
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            labelquick.Visible = true;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewQuickAttendance.xls");
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