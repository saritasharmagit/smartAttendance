using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.Reports
{
    public partial class Reports_StaffDetails : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        protected void Chkemp_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkemp.Checked)
            {

                CmbStatus.Enabled = false;

                //DataTable dt = blu.getEmployeebyAtten();
                //CmbEmployee.DataSource = dt;
                //CmbEmployee.DataBind();
                //txtEmpId.Enabled = false;
                //txtEmpId.Text = "";
            }
            else
            {
                CmbStatus.Enabled = true;

                //DataTable dt = blu.getEmployeebyAtten();
                //CmbEmployee.DataSource = dt;
                //CmbEmployee.DataTextField = "Fullname";
                //CmbEmployee.DataBind();

                //txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
            }
        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if(Chkemp.Checked)
            {
                Response.Redirect("Reports_ViewStaffDetails.aspx");
            }
            else
            {
                if (CmbStatus.SelectedItem.Text == "Retired")
                {
                    int statusid = int.Parse(CmbStatus.SelectedValue);
                    Response.Redirect(string.Format("Reports_ViewStaffDetailswithStatus.aspx?status={0}", statusid));


                }
                else if (CmbStatus.SelectedItem.Text == "Working")
                {
                    int statusid = int.Parse(CmbStatus.SelectedValue);
                    Response.Redirect(string.Format("Reports_ViewStaffDetailswithStatus.aspx?status={0}", statusid));
                }
                else if (CmbStatus.SelectedItem.Text == "Suspension")
                {
                    int statusid = int.Parse(CmbStatus.SelectedValue);
                    Response.Redirect(string.Format("Reports_ViewStaffDetailswithStatus.aspx?status={0}", statusid));
                }
                else if (CmbStatus.SelectedItem.Text == "Termination")
                {
                    int statusid = int.Parse(CmbStatus.SelectedValue);
                    Response.Redirect(string.Format("Reports_ViewStaffDetailswithStatus.aspx?status={0}", statusid));
                }
                else if (CmbStatus.SelectedItem.Text == "Dismissed")
                {
                    int statusid = int.Parse(CmbStatus.SelectedValue);
                    Response.Redirect(string.Format("Reports_ViewStaffDetailswithStatus.aspx?status={0}", statusid));
                }
                else if (CmbStatus.SelectedItem.Text == "Resigned")
                {
                    int statusid = int.Parse(CmbStatus.SelectedValue);
                    Response.Redirect(string.Format("Reports_ViewStaffDetailswithStatus.aspx?status={0}", statusid));
                }
                else if (CmbStatus.SelectedItem.Text == "Laid_off")
                {
                    int statusid = int.Parse(CmbStatus.SelectedValue);
                    Response.Redirect(string.Format("Reports_ViewStaffDetailswithStatus.aspx?status={0}", statusid));
                   
                }
            }
        }

        protected void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbStatus.SelectedItem.Text!="")
            {
                Chkemp.Enabled = false;
            }
            else
            {
                Chkemp.Enabled = true;
            }
          
        }
    }
}