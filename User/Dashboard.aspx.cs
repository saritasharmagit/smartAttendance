using AttendanceKantipur;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceKantipur.User
{
    public partial class Dashboard : System.Web.UI.Page
    {
        BLLSmart blu = new BLLSmart();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = blu.countBranch();
            string Branch = dt.Rows[0]["Branch"].ToString();
            countBranch.Text = Branch;

            DataTable dt3 = blu.countdepartment();
            string department = dt3.Rows[0]["dept"].ToString();
            countDepartment.Text = department;

            DataTable dt10 = blu.countEmployeeMale();
            string maleEmployee = dt10.Rows[0]["emp"].ToString();
            countEmployeeMale.Text = maleEmployee;

            DataTable dt11 = blu.countEmployeeFemale();
            string femaleEmployee = dt11.Rows[0]["emp"].ToString();
            countEmployeeFemale.Text = femaleEmployee;

            int flag = 1;
            DataTable dt13 = blu.getEvents(flag);//Getting Events
            var stacks = "";
            foreach (DataRow row in dt13.Rows)
            {
                var foreachloopStack = "<div class='inbox-item'><p class='inbox-item-author'>" + row["Title"].ToString() + "</p><p class='inbox-item-text'>" + row["Description"].ToString() + "</p><p class='inbox-item-date'>" + row["Date"].ToString() + "</p></div>";
                stacks = stacks + foreachloopStack;
            }
            Events.Text = stacks;

            DataTable dt115 = blu.birthday();//Getting Birthdays
            var stack = "";

            var todayDate = DateTime.Now.ToString("yyyy-mm-dd");
            var todayMonthOnly = DateTime.Now.ToString("MMMM");
            var todayDateOnly = DateTime.Now.ToString("dd");
            var happyBirthday = "";
            foreach (DataRow row in dt115.Rows)
            {
                var birth = Convert.ToDateTime(row["EMP_DOB"].ToString());
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
                //string emp_image = row["EMP_PHOTO"].ToString();
                var foreachloopStack = "<div class='inbox-item'><div class='inbox-item-img'><img src='../Assets/images/users/blank_man1.jpeg' class='img-circle' alt='img'></div><p class='inbox-item-author'>" + row["emp_Fullname"].ToString() + "</p><p class='inbox-item-text'>" + happyBirthday + "</p><p class='inbox-item-date'>" + birthDate + " " + birthMonth + "</p></div>";
                stack = stack + foreachloopStack;
            }
            birthdays.Text = stack;
        }
    }
}