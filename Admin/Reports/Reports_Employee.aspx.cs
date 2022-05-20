using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_Employee : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txttoengdate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                int year = DateTime.Now.Year;
                for (int i = year - 25; i <= year + 25; i++)
                {
                    ListItem li = new ListItem(i.ToString());
                    CmbYear.Items.Add(li);
                }
                CmbYear.Items.FindByText(year.ToString()).Selected = true;

                loadStatus();
            }
        }
      
        public void loadStatus()
        {
            DataTable dt = blu.Getstatus();
            CmbStatus.DataSource = dt;
            CmbStatus.DataTextField = "STATUS_NAME";
            CmbStatus.DataValueField = "STATUS_ID";
            CmbStatus.DataBind();
            CmbStatus.Items.Insert(0, "Select Status");
            CmbStatus.SelectedIndex = 0;
        }

        string dateyearly="";
        string monthlyfrom;
        string monthlyto;
        int status_id;
        string status_name;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
           
            if (CmbStatus.SelectedItem.Text == "Select Status")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Ooops!','Select Status !!!!','warning')", true); 
                return;
            }
            if (CmbStatus.SelectedItem.Text == "Working")
            {
                 status_id = Convert.ToInt32(CmbStatus.SelectedValue);
                 status_name = CmbStatus.SelectedValue.ToString();
                 Response.Redirect(String.Format("Reports_ViewEmployee.aspx?status_id={0}&status_name={1}", Server.UrlEncode(status_id.ToString()), Server.UrlEncode(status_name.ToString())));
            }
            if (CmbDatetype.SelectedItem.Text == "Select Date Type")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Ooops!','Select Date Type !!!!','warning')", true);
                return;
            }
             status_id = Convert.ToInt32(CmbStatus.SelectedValue);
             status_name = CmbStatus.SelectedValue.ToString();

            if(CmbDatetype.SelectedItem.Text=="Yearly")
            {
                 dateyearly = (CmbYear.SelectedValue).ToString();
                 Response.Redirect(String.Format("Reports_ViewEmployee.aspx?status_id={0}&status_name={1}&dateyearly={2}", Server.UrlEncode(status_id.ToString()), Server.UrlEncode(status_name.ToString()), Server.UrlEncode(dateyearly.ToString())));
            }
            else
            {
                 monthlyfrom = (txtStartDate.Text);
                 monthlyto = (txttoengdate.Text);
                 Response.Redirect(String.Format("Reports_ViewEmployee.aspx?status_id={0}&status_name={1}&monthlyfrom={2}&monthlyto={3}&dateyearly={4}", Server.UrlEncode(status_id.ToString()), Server.UrlEncode(status_name.ToString()), Server.UrlEncode(monthlyfrom.ToString()), Server.UrlEncode(monthlyto.ToString()), Server.UrlEncode(dateyearly.ToString())));
            }

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reports_Employee.aspx");
        }

        protected void DDLDateType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}