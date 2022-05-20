using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.HR_Mgmt
{
    public partial class Employees : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable employeeList = blu.getAllEmployeesList();
            string tableRow = "";
            int i = 1;
            tableRow = "<tr>";
            foreach (DataRow value in employeeList.Rows)
            {

                tableRow += "<td>" + i + "</td>";
                tableRow += "<td>" + value["emp_Fullname"] + " " + "(" + value["EMP_ID"] + ")" + "</td>";
                tableRow += "<td>" + value["DEG_NAME"] + "</td>";
                tableRow += "<td>" + value["GRADE_NAME"] + "</td>";
                tableRow += "<td>" + value["DEPT_NAME"] + "</td>";
                tableRow += "<td>" + value["BRANCH_NAME"] + "</td>";
                tableRow += "<td>" + value["STATUS_NAME"] + "</td>";
                tableRow += "<td><div class='button-list'><a href='ShowDetails.aspx?EMP_ID=" + value["EMP_ID"] + "' onserverclick='' runat='server' class='btn btn-primary waves-effect w-md waves-light'>View Details </a></div></td>";
                 tableRow += "</tr>";
                i++;
            }
            tableBody.Text = tableRow;
        }
      
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow gr = GridView1.SelectedRow;
            //Response.Redirect("ShowDetails.aspx?EMP_ID=" + gr.Cells[2].Text);
        }
     
        protected void BtnNew_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployees.aspx");
        }
    }
}