using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace AttendanceKantipur
{
    public class LoginClass
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);

         public DataTable GetUserList()
         
         {
       
        string sql = "select * from Tbl_UserTypes";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
         public DataTable Authenticate(string username, string password)
         {
             string sql = "select * from view_emp_info where EMP_USERID=@username and EMP_PASSWORD=@password";
             con.Open();
             SqlCommand cmd = new SqlCommand(sql, con);
             cmd.Parameters.AddWithValue("@username", username);
             cmd.Parameters.AddWithValue("@password", password);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;
         }
    public DataTable authenticate(string username, string password, string usertype)
    {
     
        string sql = "select * from Tbl_UserList where LoginName=@username and Password=@password and UserTypeId=@usertype";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        cmd.Parameters.AddWithValue("@usertype", usertype);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }

    public DataTable AuthenticateUser(string username, string password, string usertype)
    {
        //SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=kantipurpublication2019;User ID=sa;Password=123;");
        string sql = "select * from Tbl_Emp_Info where EMP_USERID=@EMP_USERID and EMP_PASSWORD=@EMP_PASSWORD and UserTypeId=@UserTypeId";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@EMP_USERID", username);
        cmd.Parameters.AddWithValue("@EMP_PASSWORD", password);
        cmd.Parameters.AddWithValue("@UserTypeId", usertype);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
   }
 }