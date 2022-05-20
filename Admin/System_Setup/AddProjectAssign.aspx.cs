using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin.System_Setup
{
    public partial class AddProjectAssign : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)//getBranch
        {
            if (!IsPostBack)
            {
                loadBranch();
                loadState();
                rbDistrict.Checked = true;
                CmbState.Visible = false;
                lblState.Visible = false;
            }
        }
        public void loadBranch()
        {
            DataTable dt = blu.getBranch();
            CmbProjectTitle.DataSource = dt;
            CmbProjectTitle.DataTextField = "BRANCH_Name";
            CmbProjectTitle.DataValueField = "BRANCH_ID";
            CmbProjectTitle.DataBind();
            CmbProjectTitle.Items.Insert(0, "Select Project");
        }
        public void loadState()
        {
            DataTable dt = blu.getStateList();
            CmbState.DataSource = dt;
            CmbState.DataTextField = "StateName";
            CmbState.DataValueField = "StateId";
            CmbState.DataBind();
            //CmbState.Items.Insert(0, "Select Province");
        }

        protected void rbDistrict_CheckedChanged(object sender, EventArgs e)
        {
            int ProjectTitleId = Convert.ToInt32(CmbProjectTitle.SelectedValue);

            DataTable dt = blu.getDistrictList();
            grvDistrict.DataSource = dt;
            grvDistrict.DataBind();

            if (rbDistrict.Checked)
            {
                foreach (GridViewRow row in grvDistrict.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string districtname = (row.Cells[2].Text);
                        if (blu.CheckDuplicateProjectDistrict(ProjectTitleId, districtname))
                        {

                            DataTable dt1 = blu.GetProjectAssign();
                            if (dt1.Rows.Count > 0)
                            {
                                (row.FindControl("CheckBox2") as CheckBox).Checked = true;
                            }
                        }

                    }


                }
                CmbState.Visible = false;
                lblState.Visible = false;


            }
            else
            {
                CmbState.Visible = true;
                lblState.Visible = true;
            }
        }

        protected void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProjectTitleId = Convert.ToInt32(CmbProjectTitle.SelectedValue);


            int StateId = Convert.ToInt32(CmbState.SelectedValue);
            DataTable dt = blu.getDistrict(StateId);
            grvDistrict.DataSource = dt;
            grvDistrict.DataBind();

            foreach (GridViewRow row in grvDistrict.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string districtname = (row.Cells[2].Text);
                    if (blu.CheckDuplicateProjectDistrict(ProjectTitleId, districtname))
                    {

                        DataTable dt1 = blu.GetProjectAssign();
                        if (dt1.Rows.Count > 0)
                        {
                            (row.FindControl("CheckBox2") as CheckBox).Checked = true;
                        }
                    }

                }


            }
        }

        protected void rbState_CheckedChanged(object sender, EventArgs e)
        {
            int ProjectTitleId = Convert.ToInt32(CmbProjectTitle.SelectedValue);

            if (rbState.Checked)
            {
                CmbState.Visible = true;
                lblState.Visible = true;

                int StateId = Convert.ToInt32(CmbState.SelectedValue);
                DataTable dt = blu.getDistrict(StateId);
                grvDistrict.DataSource = dt;
                grvDistrict.DataBind();
                foreach (GridViewRow row in grvDistrict.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string districtname = (row.Cells[2].Text);
                        if (blu.CheckDuplicateProjectDistrict(ProjectTitleId, districtname))
                        {

                            DataTable dt1 = blu.GetProjectAssign();
                            if (dt1.Rows.Count > 0)
                            {
                                (row.FindControl("CheckBox2") as CheckBox).Checked = true;
                            }
                        }

                    }

                    //ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Alresdy Exists district !!!','warning')", true);
                    //return;
                }
            }
            else
            {
                CmbState.Visible = false;
                lblState.Visible = false;

                DataTable dt = blu.getDistrictList();
                grvDistrict.DataSource = dt;
                grvDistrict.DataBind();
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectAssign.aspx");
        }

        protected void BtnAssign_Click(object sender, EventArgs e)
        {
            int ProjectTitleId = Convert.ToInt32(CmbProjectTitle.SelectedValue);
            string projecttitlename = (CmbProjectTitle.SelectedItem).ToString();


            if (rbState.Checked)
            {
                int stateid = Convert.ToInt32(CmbState.SelectedValue);
                int j = blu.DeleteProjectAssignBystate(ProjectTitleId, stateid);//for delete previous data by state and then selected value insert
            }
            else
            {
                int j = blu.DeleteProjectAssign(ProjectTitleId);//for delete previous data and then selected value insert 
            }

            foreach (GridViewRow row in grvDistrict.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CheckBox2") as CheckBox);

                    if (chkRow.Checked)
                    {
                        string districtid = (row.Cells[1].Text);
                        int id = int.Parse(districtid);
                        string districtname = (row.Cells[2].Text);
                        string stateid = (row.Cells[3].Text);
                        int statid = int.Parse(stateid);

                        int i = blu.CreateProjectAssign(ProjectTitleId, projecttitlename, statid, id, districtname);

                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Project Assign saved Successfully').then((value) => { window.location ='ProjectAssign.aspx'; });", true);
        }

        protected void CmbProjectTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProjectTitleId = Convert.ToInt32(CmbProjectTitle.SelectedValue);

            if (rbState.Checked)
            {
                CmbState.Visible = true;
                lblState.Visible = true;

                int StateId = Convert.ToInt32(CmbState.SelectedValue);
                DataTable dt = blu.getDistrict(StateId);
                grvDistrict.DataSource = dt;
                grvDistrict.DataBind();
                foreach (GridViewRow row in grvDistrict.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string districtname = (row.Cells[2].Text);
                        if (blu.CheckDuplicateProjectDistrict(ProjectTitleId, districtname))
                        {

                            DataTable dt1 = blu.GetProjectAssign();
                            if (dt1.Rows.Count > 0)
                            {
                                (row.FindControl("CheckBox2") as CheckBox).Checked = true;
                            }
                        }

                    }
                }
            }
            DataTable dt3 = blu.getDistrictList();
            grvDistrict.DataSource = dt3;
            grvDistrict.DataBind();

            if (rbDistrict.Checked)
            {
                foreach (GridViewRow row in grvDistrict.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        string districtname = (row.Cells[2].Text);
                        if (blu.CheckDuplicateProjectDistrict(ProjectTitleId, districtname))
                        {

                            DataTable dt2 = blu.GetProjectAssign();
                            if (dt2.Rows.Count > 0)
                            {
                                (row.FindControl("CheckBox2") as CheckBox).Checked = true;
                            }
                        }

                    }


                }
                CmbState.Visible = false;
                lblState.Visible = false;


            }
            else
            {
                //grvDistrict.Visible = false;
            }
        }

        protected void grvDistrict_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
        }
    }
}