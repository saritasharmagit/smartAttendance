using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = blu.countBranch();
            string branch = dt.Rows[0]["Branch"].ToString();
            Branch.Text = branch;
          
            DataTable dt1 = blu.countdepartment();
            string deptname = dt1.Rows[0]["dept"].ToString();
            Department.Text = deptname;
          
            DataTable dt2 = blu.countEmployeeMale();
            string employee = dt2.Rows[0]["emp"].ToString();
            MaleEmployee.Text = employee;

            int flag = 1;
            DataTable dt4 = blu.getEvents(flag);//Getting Events
            var stacks = "";

            foreach (DataRow row in dt4.Rows)
            {
                var date = Convert.ToDateTime(row["Date"].ToString());
                var evdate = date.ToString("yyyy-MM-dd");

                var foreachloopStack = "<div class='inbox-item'><p class='inbox-item-author'>" + row["Title"].ToString() + "</p><p class='inbox-item-text'>" + row["Description"].ToString() + "</p><p class='inbox-item-date'>" + evdate + "</p></div>";
                stacks = stacks + foreachloopStack;
            }
            Events.Text = stacks;


            DataTable dt3 = blu.countEmployeeFemale();//female employee
            string female = dt3.Rows[0]["emp"].ToString();
            FemleEmployee.Text = female;
         
            DataTable dt6 = blu.birthday();//Getting Birthdays
            var stack = "";

           
            var todayDate = DateTime.Now.ToString("yyyy-mm-dd");
            var todayMonthOnly = DateTime.Now.ToString("MMMM");
            var todayDateOnly = DateTime.Now.ToString("dd");
            var happyBirthday = "";
            foreach (DataRow row in dt6.Rows)
            {
                //int empIdd = int.Parse(dt6.Rows[0]["EMP_ID"].ToString());
                //DataSet ds = blu.LoadPhoto(empIdd);
                //int c = ds.Tables[0].Rows.Count;
                //foreach (DataRow row1 in ds.Tables["Photo"].Rows)
                //{
                //    if (ds.Tables["Photo"].Rows.Count > 0)
                //    {
                //        byte[] bytedata = new byte[0];
                //        if (ds.Tables[0].Rows[0][0].ToString() != "")
                //        {
                //            bytedata = (byte[])(ds.Tables[0].Rows[0][0]);
                //            MemoryStream stmphoto = new MemoryStream(bytedata);

                //            string PROFILE_PIC = Convert.ToBase64String(bytedata);

                //            PersImage.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);

                //        }
                //        else
                //        {
                //            PersImage.ImageUrl = null;
                //        }
                //    }
                //    else
                //    {
                //        PersImage.ImageUrl = null;
                //    }
                //}
                //ds.Tables.Clear();

                var birth = Convert.ToDateTime(row["EMP_DOB"].ToString());
                var photo = (row["EMP_PHOTO"].ToString());
                var birthMonth = birth.ToString("MMMM");
                var birthDate = birth.ToString("dd");
                var dayLeft = int.Parse(birthDate) - int.Parse(todayDateOnly);
                if (todayMonthOnly == birthMonth)
                {
                    if (todayDateOnly == birthDate)
                    {
                        happyBirthday = "Happy Birthday !!!";
                    }
                    else
                    {
                        if (dayLeft == 1)
                        {
                            happyBirthday = dayLeft + " day left";
                        }
                        else
                        {
                            happyBirthday = dayLeft + " days left";
                        }
                    }
                }
                var foreachloopStack = "<div class='inbox-item'><div class='inbox-item-img'><img src='../Assets/images/users/blank_man1.jpeg' class='img-circle' alt=''></div><p class='inbox-item-author'>" +row["emp_Fullname"].ToString() + "</p><p class='inbox-item-text'>" + happyBirthday + "</p><p class='inbox-item-date'>" + birthDate + " " + birthMonth + "</p></div>";
                stack = stack + foreachloopStack;
            }
            birthdays.Text = stack;
        }
    }
}