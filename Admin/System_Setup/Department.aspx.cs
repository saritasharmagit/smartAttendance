using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class Department : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = blu.GetDepartment();
                GridView2.DataSource = dt;
                GridView2.DataBind();

               // btnBack.Enabled = false;
            }
        }
        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDepartment.aspx");
        }

        DataTable dt1;
        protected void GridView2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //lblid.Text = GridView2.SelectedRow.Cells[1].Text;
            //lblname.Text = GridView2.SelectedRow.Cells[2].Text;
            //string deptparent = lblname.Text;
            //dt1 = blu.GetDepartmentList(deptparent);

            //GridView1.DataSource = dt1;
            //GridView1.DataBind();
        }
  
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dRow = (DataRowView)e.Row.DataItem;

                if (dRow.Row["sta"].ToString() == "0")
                {
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                }
            }
        }
       
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Section")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView2.Rows[index];
                TableCell id = selectedRow.Cells[1];
                TableCell Name = selectedRow.Cells[2];
                TableCell Status = selectedRow.Cells[3];
                string department = Name.Text;
                int sta = int.Parse(Status.Text);
               
                dt1 = blu.GetDepartmentList(department);
                if(dt1.Rows.Count>0)
                {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    lblDept.Text = department.ToString()+" " +"Department";

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','No section with this Department!','warning')</script>");
                }
                //GridView1.DataSource = dt1;
                //GridView1.DataBind();

               // GridView2.Visible = false;
               // btnBack.Enabled = true;
                //GridView1.Visible = true;
            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView2.Rows[index];
                TableCell id = selectedRow.Cells[1];
                TableCell Name = selectedRow.Cells[2];

                TableCell Sta = selectedRow.Cells[3];
                int deptid = int.Parse(id.Text);
                string depname = Name.Text;
                int sta = int.Parse(Sta.Text);
                string olddept = Name.Text;
                Response.Redirect("EditDepartment.aspx?DEPT_ID=" + deptid + "&DEPT_NAME=" + depname + "&sta=" + sta + "&olddept=" + olddept);

            }
        }
        string olddept = "";
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            olddept = gr.Cells[3].Text;
            Response.Redirect("EditSection.aspx?DEPT_ID=" + gr.Cells[1].Text + "&DEPT_NAME=" + gr.Cells[2].Text + "&sta=" + gr.Cells[4].Text + "&olddept=" + olddept);
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
             e.Row.Cells[4].Visible = false;
        }
    }
}