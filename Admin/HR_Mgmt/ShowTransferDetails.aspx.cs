using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.HR_Mgmt
{
    public partial class ShowTransferDetails : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            int empid = Convert.ToInt32(Request.QueryString["Emp_id"].ToString());
            HiddenField1.Value = empid.ToString();
            DataTable dta = blu.getTransferList(empid);
            grvTransfer.DataSource = dta;
            grvTransfer.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transfer.aspx");
        }
    }
}