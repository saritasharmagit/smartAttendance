using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace AttendanceKantipur
{
    public class BLLSmart
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        SqlConnection conn;
        public bool Connect()
        {
            try
            {
                con = new SqlConnection(WebConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
                //  _sqlcon.ConnectionString = ConnectionString;

                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {

                }

                return true;
            }
            catch
            {
                return false;
            }

        }
        public DataTable getUserInfo()
        {
            string sql = "select count('Branch') as Branch from tbl_comp_branch";
            con.Open();
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
        //public DataTable Authenticate(string username, string password, int userTypeId)
        //{
        //    string sql = "select * from view_emp_info where EMP_USERID=@username and EMP_PASSWORD=@password and userTypeId=@userTypeId";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@username", username);
        //    cmd.Parameters.AddWithValue("@password", password);
        //    cmd.Parameters.AddWithValue("@userTypeId", userTypeId);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        public int updatePassword(int EMP_ID, string newPassword)
        {
            string sql = "update Tbl_Emp_Info set EMP_PASSWORD=@newPassword  where EMP_ID=@EMP_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable getUserTypeList(int UserTypeId)
        {
            string sql = "select emp_Fullname, EMP_ID, DEG_NAME, DEPT_NAME, BRANCH_NAME,STATUS_NAME,MODE_NAME from view_emp_info where UserTypeId = @UserTypeId";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@UserTypeId", UserTypeId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable countBranch()
        {
            string sql = "select COUNT(BRANCH_ID) as Branch from Tbl_Comp_Branch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable countdepartment()
        {
            string sql = "select COUNT(DEPT_ID) as dept from Tbl_Org_Dept where FLDTYPE='D'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countEmployeeMale()
        {
            string sql = "select COUNT(EMP_ID) as emp from view_Emp_Info where STATUS_ID=1 and EMP_GENDER='M'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable countEmployeeFemale()
        {
            string sql = "select COUNT(EMP_ID) as emp from view_Emp_Info where STATUS_ID=1 and EMP_GENDER='F'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
      
        //public DataTable getEvents()
        //{
        //    string sql = "Select * from Tbl_Org_event";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        public DataTable birthday()
        {
            string sql = "select EMP_ID,emp_Fullname, DEG_NAME, BRANCH_NAME, sect_name, DEPT_NAME, EMP_DOB,EMP_PHOTO from view_emp_info where month(EMP_DOB) = month(getdate()) and day(EMP_DOB) >= day(getdate()) ORDER BY day(EMP_DOB)";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable notification()
        {
            string sql = "select EMP_ID, EMP_TITLE, emp_Fullname, NOTIFICATION_STATUS, ADDED_TIME, BRANCH_ID, EMP_JOINDATE from view_emp_info";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //system setup//
        public DataTable GetAllOrg()
        {
            string sql = "select Org_Id,Org_Address,Org_Address2,Org_Code,Org_Email,Org_Fax,Org_Logo,Org_Name,Org_Phone,Org_Website,Org_Prefix, Org_Address + case when Org_Address2='' then '' else','+Org_Address2 end as Full_Address from Tbl_Org";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public int CreateCompany(string Org_Name, string Org_Address, string Org_Address2, string Org_Phone, string Org_Fax, string Org_Email, string Org_Website)
        {
            string sql = "insert into Tbl_Org (Org_Name,Org_Address,Org_Address2,Org_Phone,Org_Fax,Org_Email,Org_Website) values(@Org_Name,@Org_Address,@Org_Address2, @Org_Phone,@Org_Fax,@Org_Email,@Org_Website)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Org_Name", Org_Name);
            cmd.Parameters.AddWithValue("@Org_Address", Org_Address);
            cmd.Parameters.AddWithValue("@Org_Address2", Org_Address2);
            cmd.Parameters.AddWithValue("@Org_Phone", Org_Phone);
            cmd.Parameters.AddWithValue("@Org_Fax", Org_Fax);
            cmd.Parameters.AddWithValue("@Org_Email", Org_Email);
            cmd.Parameters.AddWithValue("@Org_Website", Org_Website);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int UpdateCompany(string Org_Name, string Org_Address, string Org_Address2, string Org_Phone, string Org_Fax, string Org_Email, string Org_Website, int Org_Id)
        {
            string sql = "update Tbl_Org set Org_Name=@Org_Name, Org_Address=@Org_Address, Org_Address2=@Org_Address2,Org_Phone=@Org_Phone,Org_Fax=@Org_Fax,Org_Email=@Org_Email,Org_Website=@Org_Website where Org_Id=@Org_Id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Org_Name", Org_Name);
            cmd.Parameters.AddWithValue("@Org_Address", Org_Address);
            cmd.Parameters.AddWithValue("@Org_Address2", Org_Address2);
            cmd.Parameters.AddWithValue("@Org_Phone", Org_Phone);
            cmd.Parameters.AddWithValue("@Org_Fax", Org_Fax);
            cmd.Parameters.AddWithValue("@Org_Email", Org_Email);
            cmd.Parameters.AddWithValue("@Org_Website", Org_Website);
            cmd.Parameters.AddWithValue("@Org_Id", Org_Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable GetOrgbyOrgId(int Org_Id)
        {
            string sql = "select *from Tbl_Org  where Org_Id=@Org_Id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Org_Id", Org_Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataTable getBranch()
        {
            string sql = "Select BRANCH_ID,BRANCH_NAME,BRANCH_CODE,ValidFrom,ValidTo,ExtendDate,sta,ABBREVIATION  from tbl_comp_branch order by BRANCH_NAME asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int CreateBranch(string BRANCH_CODE, int ISOUTBRANCH, int serial_no, string BRANCH_NAME, int sta, string BType, DateTime ValidFrom, DateTime ValidTo, int IsExtend, string ABBREVIATION)
        {
            try
            {
                con.Open();
                string sql = "insert into Tbl_Comp_Branch (BRANCH_CODE,ISOUTBRANCH,serial_no,BRANCH_NAME,sta,BType,ValidFrom,ValidTo,IsExtend,ABBREVIATION) values(@BRANCH_CODE,@ISOUTBRANCH,@serial_no,@BRANCH_NAME,@sta,@BType,@ValidFrom,@ValidTo,@IsExtend,@ABBREVIATION)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BRANCH_CODE", BRANCH_CODE);
                cmd.Parameters.AddWithValue("@ISOUTBRANCH", 0);
                cmd.Parameters.AddWithValue("@serial_no", serial_no);
                cmd.Parameters.AddWithValue("@BRANCH_NAME", BRANCH_NAME);
                cmd.Parameters.AddWithValue("@sta", sta);
                cmd.Parameters.AddWithValue("@BType", "Null");
                cmd.Parameters.AddWithValue("@ValidFrom", ValidFrom);
                cmd.Parameters.AddWithValue("@ValidTo", ValidTo);
                cmd.Parameters.AddWithValue("@IsExtend", IsExtend);
                cmd.Parameters.AddWithValue("@ABBREVIATION", ABBREVIATION);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CreateEmpProjectHistory(int EmpId, int ProjectId, DateTime ValidFrom, DateTime ValidTo, int IsCurrent)
        {
            con.Open();
            string sql = "insert into tbl_emp_project_history (EmpId,ProjectId,ValidFrom,ValidTo,IsCurrent) values(@EmpId,@ProjectId,@ValidFrom,@ValidTo,@IsCurrent)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@ValidFrom", ValidFrom);
            cmd.Parameters.AddWithValue("@ValidTo", ValidTo);
            cmd.Parameters.AddWithValue("@IsCurrent", IsCurrent);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void UpdateBranchSetup(string BRANCH_NAME, int ISOUTBRANCH, int serial_no, string BRANCH_CODE, int sta, string BType, DateTime ValidFrom, DateTime ValidTo, int IsExtend, DateTime ExtendDate, int branchid, string ABBREVIATION)
        {
            try
            {
                con.Open();
                string sql = "update Tbl_Comp_Branch set BRANCH_NAME=@BRANCH_NAME, ISOUTBRANCH=@ISOUTBRANCH, serial_no=@serial_no,BRANCH_CODE=@BRANCH_CODE,sta=@sta,BType=@BType,ValidFrom=@ValidFrom,ValidTo=@ValidTo,IsExtend=@IsExtend,ExtendDate=@ExtendDate,ABBREVIATION=@ABBREVIATION where BRANCH_ID=@branchid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BRANCH_NAME", BRANCH_NAME);
                cmd.Parameters.AddWithValue("@ISOUTBRANCH", ISOUTBRANCH);
                cmd.Parameters.AddWithValue("@serial_no", serial_no);
                cmd.Parameters.AddWithValue("@BRANCH_CODE", BRANCH_CODE);
                cmd.Parameters.AddWithValue("@sta", sta);
                cmd.Parameters.AddWithValue("@BType", BType);
                cmd.Parameters.AddWithValue("@ValidFrom", ValidFrom);
                cmd.Parameters.AddWithValue("@ValidTo", ValidTo);
                cmd.Parameters.AddWithValue("@branchid", branchid);
                cmd.Parameters.AddWithValue("@IsExtend", IsExtend);
                cmd.Parameters.AddWithValue("@ExtendDate", ExtendDate);
                cmd.Parameters.AddWithValue("@ABBREVIATION", ABBREVIATION);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateBranchSetupWithoutExtend(string BRANCH_NAME, int ISOUTBRANCH, int serial_no, string BRANCH_CODE, int sta, string BType, DateTime ValidFrom, DateTime ValidTo, int IsExtend, int branchid, string ABBREVIATION)
        {
            try
            {
                con.Open();
                string sql = "update Tbl_Comp_Branch set BRANCH_NAME=@BRANCH_NAME, ISOUTBRANCH=@ISOUTBRANCH, serial_no=@serial_no,BRANCH_CODE=@BRANCH_CODE,sta=@sta,BType=@BType,ValidFrom=@ValidFrom,ValidTo=@ValidTo,IsExtend=@IsExtend,ABBREVIATION=@ABBREVIATION where BRANCH_ID=@branchid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BRANCH_NAME", BRANCH_NAME);
                cmd.Parameters.AddWithValue("@ISOUTBRANCH", ISOUTBRANCH);
                cmd.Parameters.AddWithValue("@serial_no", serial_no);
                cmd.Parameters.AddWithValue("@BRANCH_CODE", BRANCH_CODE);
                cmd.Parameters.AddWithValue("@sta", sta);
                cmd.Parameters.AddWithValue("@BType", BType);
                cmd.Parameters.AddWithValue("@ValidFrom", ValidFrom);
                cmd.Parameters.AddWithValue("@ValidTo", ValidTo);
                cmd.Parameters.AddWithValue("@branchid", branchid);
                cmd.Parameters.AddWithValue("@IsExtend", IsExtend);
                //cmd.Parameters.AddWithValue("@ExtendDate",null);
                cmd.Parameters.AddWithValue("@ABBREVIATION", ABBREVIATION);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckDuplicate(string BRANCH_NAME)
        {
            {
                con.Open();
                string sql = "select 1 from tbl_comp_branch where BRANCH_NAME=@BRANCH_NAME";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BRANCH_NAME", BRANCH_NAME);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;

            }

        }
        public bool CheckEmptyEmployeetransfer(int Emp_id)
        {
            {
                con.Open();
                string sql = "select 1 from Tbl_Emp_Transfer_Detail where Emp_id=@Emp_id and isCurrent=1";
                SqlCommand cmd = new SqlCommand(sql, con);
                //  cmd.Parameters.AddWithValue("@District_From", District_From);
                cmd.Parameters.AddWithValue("@Emp_id", Emp_id);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;

            }

        }
        public bool CheckEmptyEmployeePromotion(int Emp_Id)
        {
            {
                con.Open();
                string sql = "select 1 from Tbl_Emp_Promotion_Detail where Emp_Id=@Emp_Id and isCurrent=1";
                SqlCommand cmd = new SqlCommand(sql, con);
                //  cmd.Parameters.AddWithValue("@District_From", District_From);
                cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;

            }

        }
        public DataTable GetPromotionDetail(int Emp_Id)
        {

            string sql = "select *from Tbl_Emp_Promotion_Detail where Emp_Id=@Emp_Id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable GetbranchbybranchId(int branchid)
        {

            string sql = "select *from Tbl_Comp_Branch where BRANCH_ID=@branchid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@branchid", branchid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable getEthnicity()
        {
            string sql = "Select * from  Tbl_emp_Ethnicity";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int CreateEthnicity(string Ethnicity_Name, int Status)
        {
            try
            {
                con.Open();
                string sql = "insert into Tbl_emp_Ethnicity (Ethnicity_Name,Status) values(@Ethnicity_Name,@Status)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ethnicity_Name", Ethnicity_Name);
                cmd.Parameters.AddWithValue("@Status", Status);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckDuplicateEthnicity(string Ethnicity_Name)
        {
            {
                con.Open();
                string sql = "select 1 from Tbl_emp_Ethnicity where Ethnicity_Name=@Ethnicity_Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ethnicity_Name", Ethnicity_Name);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;
            }

        }
        public DataTable GetethnicitybyId(int ethnicityid)
        {

            string sql = "select *from Tbl_emp_Ethnicity where Ethnicity_Id=@ethnicityid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ethnicityid", ethnicityid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public void UpdateEthnicity(string Ethnicity_Name, int Status, int ethnicityid)
        {
            try
            {
                con.Open();
                string sql = "update Tbl_emp_Ethnicity set Ethnicity_Name=@Ethnicity_Name, Status=@Status where Ethnicity_Id=@ethnicityid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ethnicity_Name", Ethnicity_Name);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@ethnicityid", ethnicityid);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getGradeList()
        {
            string sql = "select * from Tbl_Org_Grade order by GRADE_NAME asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void CreateGrade(string GRADE_NAME, string GRADE_TYPE, int LEVEL, string FLDTYPE, int SERIAL_NO, int sta)
        {
            con.Open();
            string sql = "insert into Tbl_Org_Grade (GRADE_NAME,GRADE_TYPE,LEVEL,FLDTYPE,SERIAL_NO,sta) values(@GRADE_NAME,@GRADE_TYPE,@LEVEL,@FLDTYPE,@SERIAL_NO,@sta)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@GRADE_NAME", GRADE_NAME);
            cmd.Parameters.AddWithValue("@GRADE_TYPE", GRADE_TYPE);
            cmd.Parameters.AddWithValue("@LEVEL", LEVEL);
            cmd.Parameters.AddWithValue("@FLDTYPE", FLDTYPE);
            cmd.Parameters.AddWithValue("@SERIAL_NO", SERIAL_NO);
            cmd.Parameters.AddWithValue("@sta", sta);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void UpdateGrade(string GRADE_NAME, string GRADE_TYPE, int LEVEL, string FLDTYPE, int SERIAL_NO, int sta, int gradeid)
        {
            con.Open();
            string sql = "update Tbl_Org_Grade set GRADE_NAME=@GRADE_NAME, GRADE_TYPE=@GRADE_TYPE, LEVEL=@LEVEL,FLDTYPE=@FLDTYPE,SERIAL_NO=@SERIAL_NO,sta=@sta where GRADE_ID=@gradeid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@GRADE_NAME", GRADE_NAME);
            cmd.Parameters.AddWithValue("@GRADE_TYPE", GRADE_TYPE);
            cmd.Parameters.AddWithValue("@LEVEL", LEVEL);
            cmd.Parameters.AddWithValue("@FLDTYPE", FLDTYPE);
            cmd.Parameters.AddWithValue("@SERIAL_NO", SERIAL_NO);
            cmd.Parameters.AddWithValue("@sta", sta);
            cmd.Parameters.AddWithValue("@gradeid", gradeid);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataTable GetGradebygradeId(int gradeid)
        {
            string sql = "select *from Tbl_Org_Grade where GRADE_ID=@gradeid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@gradeid", gradeid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getDesignationList()
        {
            string sql = "select * from tbl_org_desg  order by DEG_NAME asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void CreateDesignation(string DEG_PARENT, string DEG_NAME, int level, int serial_no, int sta, int Priority)
        {
            con.Open();
            string sql = "insert into Tbl_Org_Desg (DEG_PARENT,DEG_NAME,level,serial_no,sta,Priority) values(@DEG_PARENT,@DEG_NAME,@level,@serial_no,@sta,@Priority)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@DEG_PARENT", DEG_PARENT);
            cmd.Parameters.AddWithValue("@DEG_NAME", DEG_NAME);
            cmd.Parameters.AddWithValue("@level", level);
            cmd.Parameters.AddWithValue("@serial_no", serial_no);
            cmd.Parameters.AddWithValue("@Priority", Priority);
            cmd.Parameters.AddWithValue("@sta", sta);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void UpdateDesignation(string DEG_PARENT, string DEG_NAME, int level, int serial_no, int sta, int Priority, int degid)
        {
            con.Open();
            string sql = "update Tbl_Org_Desg set DEG_PARENT=@DEG_PARENT, DEG_NAME=@DEG_NAME, level=@level,serial_no=@serial_no,sta=@sta,Priority=@Priority where DEG_ID=@degid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@DEG_PARENT", DEG_PARENT);
            cmd.Parameters.AddWithValue("@DEG_NAME", DEG_NAME);
            cmd.Parameters.AddWithValue("@level", level);
            cmd.Parameters.AddWithValue("@serial_no", serial_no);
            cmd.Parameters.AddWithValue("@Priority", Priority);
            cmd.Parameters.AddWithValue("@sta", sta);
            cmd.Parameters.AddWithValue("@degid", degid);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataTable GetDesignationbyId(int degid)
        {
            string sql = "select *from Tbl_Org_Desg where DEG_ID=@degid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@degid", degid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetDepartment()
        {
            string sql = "Select * from Tbl_Org_Dept where LEVEL=1 order by DEPT_NAME asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetDepartmentList(string DEPT_NAME)
        {
            string sql = "select * from Tbl_Org_Dept where DEPT_PARENT = @DEPT_NAME";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@DEPT_NAME", DEPT_NAME);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void Department(string deptparent, string deptname, int FLAG, string selectednode, int sta)
        {
            string sql = "Proc_managedept";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deptparent", deptparent);
            cmd.Parameters.AddWithValue("@deptname", deptname);
            cmd.Parameters.AddWithValue("@FLAG", FLAG);
            cmd.Parameters.AddWithValue("@selectednode", selectednode);
            cmd.Parameters.AddWithValue("@sta", sta);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable GetdepartmentbydepartmentId(int departmentid)
        {
            string sql = "select *from Tbl_Org_Dept where DEPT_ID=@departmentid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@departmentid", departmentid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getLeaveSetup()
        {
            string sql = "select t.*,(case when t.LEAVE_TYPE='1' then 'Expire Yearly' when t.LEAVE_TYPE='2' then 'Accumulative' else 'Service Period' end) as TYPE from Tbl_Org_Leave_info t order by LEAVE_NAME asc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //public int CreateLeaveSetup(string LEAVE_NAME, int LEAVE_DAYS, int LEAVE_TYPE, int LEAVE_MAX, int ISPAIDLEAVE, int MAX_DAYS_AT_A_TIME, int ISCashable, int service_period, int mustexhaustotherleaves, int LEAVE_PREFIXING, int sta, int others, string Leave_Category)
        //{
        //    con.Open();
        //    string sql = "insert into Tbl_Org_Leave_info (LEAVE_NAME,LEAVE_DAYS,LEAVE_TYPE,LEAVE_MAX,ISPAIDLEAVE,MAX_DAYS_AT_A_TIME,ISCashable,service_period,mustexhaustotherleaves,LEAVE_PREFIXING,sta,others,Leave_Category) values(@LEAVE_NAME,@LEAVE_DAYS,@LEAVE_TYPE,@LEAVE_MAX,@ISPAIDLEAVE,@MAX_DAYS_AT_A_TIME,@ISCashable,@service_period,@mustexhaustotherleaves,@LEAVE_PREFIXING,@sta,@others,@Leave_Category)";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@LEAVE_NAME", LEAVE_NAME);
        //    cmd.Parameters.AddWithValue("@LEAVE_DAYS", LEAVE_DAYS);
        //    cmd.Parameters.AddWithValue("@LEAVE_TYPE", LEAVE_TYPE);
        //    cmd.Parameters.AddWithValue("@LEAVE_MAX", LEAVE_MAX);
        //    cmd.Parameters.AddWithValue("@ISPAIDLEAVE", ISPAIDLEAVE);
        //    cmd.Parameters.AddWithValue("@MAX_DAYS_AT_A_TIME", MAX_DAYS_AT_A_TIME);
        //    cmd.Parameters.AddWithValue("@ISCashable", ISCashable);
        //    cmd.Parameters.AddWithValue("@service_period", service_period);
        //    cmd.Parameters.AddWithValue("@mustexhaustotherleaves", mustexhaustotherleaves);
        //    cmd.Parameters.AddWithValue("@LEAVE_PREFIXING", 0);
        //    cmd.Parameters.AddWithValue("@sta", sta);
        //    cmd.Parameters.AddWithValue("@others", others);
        //    cmd.Parameters.AddWithValue("@Leave_Category", Leave_Category);
        //    int i = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return i;
        //}
        //public int UpdateLeaveSetup(string LEAVE_NAME, int LEAVE_DAYS, int LEAVE_TYPE, int LEAVE_MAX, int ISPAIDLEAVE, int MAX_DAYS_AT_A_TIME, int ISCashable, int service_period, int mustexhaustotherleaves, int LEAVE_PREFIXING, int sta, int others, string Leave_Category, int leaveid)
        //{
        //    con.Open();
        //    string sql = "update Tbl_Org_Leave_info set LEAVE_NAME=@LEAVE_NAME, LEAVE_DAYS=@LEAVE_DAYS, LEAVE_TYPE=@LEAVE_TYPE,LEAVE_MAX=@LEAVE_MAX,ISPAIDLEAVE=@ISPAIDLEAVE,MAX_DAYS_AT_A_TIME=@MAX_DAYS_AT_A_TIME,ISCashable=@ISCashable,service_period=@service_period,mustexhaustotherleaves=@mustexhaustotherleaves,LEAVE_PREFIXING=@LEAVE_PREFIXING,sta=@sta,others=@others,Leave_Category=@Leave_Category where LEAVE_ID=@leaveid";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@LEAVE_NAME", LEAVE_NAME);
        //    cmd.Parameters.AddWithValue("@LEAVE_DAYS", LEAVE_DAYS);
        //    cmd.Parameters.AddWithValue("@LEAVE_TYPE", LEAVE_TYPE);
        //    cmd.Parameters.AddWithValue("@LEAVE_MAX", LEAVE_MAX);
        //    cmd.Parameters.AddWithValue("@ISPAIDLEAVE", ISPAIDLEAVE);
        //    cmd.Parameters.AddWithValue("@MAX_DAYS_AT_A_TIME", MAX_DAYS_AT_A_TIME);
        //    cmd.Parameters.AddWithValue("@ISCashable", ISCashable);
        //    cmd.Parameters.AddWithValue("@service_period", service_period);
        //    cmd.Parameters.AddWithValue("@mustexhaustotherleaves", mustexhaustotherleaves);
        //    cmd.Parameters.AddWithValue("@LEAVE_PREFIXING", 0);
        //    cmd.Parameters.AddWithValue("@sta", sta);
        //    cmd.Parameters.AddWithValue("@others", others);
        //    cmd.Parameters.AddWithValue("@Leave_Category", Leave_Category);
        //    cmd.Parameters.AddWithValue("@leaveid", leaveid);
        //    int i = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return i;
        //}
        public int SaveLeave(string leavename, int leavetype, int leavedays, int maxacc, int monthly, int maxdays, int iscashable, int service, int must_all_leave, int leave_id, int status)
        {
            string sql = "proc_AddUpdateLeave_web";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@leavename", leavename);
            cmd.Parameters.AddWithValue("@leavetype", leavetype);
            cmd.Parameters.AddWithValue("@leavedays", leavedays);
            cmd.Parameters.AddWithValue("@maxacc", maxacc);
            cmd.Parameters.AddWithValue("@monthly", monthly);
            cmd.Parameters.AddWithValue("@maxdays", maxdays);
            cmd.Parameters.AddWithValue("@iscashable", iscashable);
            cmd.Parameters.AddWithValue("@service", service);
            cmd.Parameters.AddWithValue("@must_all_leave", must_all_leave);
            cmd.Parameters.AddWithValue("@leave_id", leave_id);
            cmd.Parameters.AddWithValue("@Status", status);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable GetLeavebyleaveId(int leaveid)
        {
            string sql = "select *from Tbl_Org_Leave_info where LEAVE_ID=@leaveid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@leaveid", leaveid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getholidaysetup()
        {
            string sql = "select t.*,(case when t.holidayType='1' then 'Standard' when t.holidayType='2' then 'Specific' else 'Unofficial' end) as TYPE from Tbl_Org_Holiday t order by HOLIDAY_NAME asc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int CreateHolidaySetup(string HOLIDAY_NAME, DateTime HOLIDAY_DATE, int HOLIDAY_QTY, int holidayType, int sta, int Female_Only)
        {
            con.Open();
            string sql = "insert into Tbl_Org_Holiday (HOLIDAY_NAME,HOLIDAY_DATE,HOLIDAY_QTY,holidayType,sta,Female_Only) values(@HOLIDAY_NAME,@HOLIDAY_DATE,@HOLIDAY_QTY,@holidayType,@sta,@Female_Only)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@HOLIDAY_NAME", HOLIDAY_NAME);
            cmd.Parameters.AddWithValue("@HOLIDAY_DATE", HOLIDAY_DATE);
            cmd.Parameters.AddWithValue("@HOLIDAY_QTY", HOLIDAY_QTY);
            cmd.Parameters.AddWithValue("@holidayType", holidayType);
            cmd.Parameters.AddWithValue("@sta", sta);
            cmd.Parameters.AddWithValue("@Female_Only", Female_Only);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable GetHolidaysetupbyholidayId(int holidayid)
        {
            string sql = "select *from Tbl_Org_Holiday where HOLIDAY_ID=@holidayid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@holidayid", holidayid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int UpdateHolidaySetup(string HOLIDAY_NAME, DateTime HOLIDAY_DATE, int HOLIDAY_QTY, int holidayType, int sta, int Female_Only, int holidayid)
        {
            con.Open();
            string sql = "update Tbl_Org_Holiday set HOLIDAY_NAME=@HOLIDAY_NAME, HOLIDAY_DATE=@HOLIDAY_DATE, HOLIDAY_QTY=@HOLIDAY_QTY,holidayType=@holidayType,sta=@sta,Female_Only=@Female_Only where HOLIDAY_ID=@holidayid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@HOLIDAY_NAME", HOLIDAY_NAME);
            cmd.Parameters.AddWithValue("@HOLIDAY_DATE", HOLIDAY_DATE);
            cmd.Parameters.AddWithValue("@HOLIDAY_QTY", HOLIDAY_QTY);
            cmd.Parameters.AddWithValue("@holidayType", holidayType);
            cmd.Parameters.AddWithValue("@sta", sta);
            cmd.Parameters.AddWithValue("@holidayid", holidayid);
            cmd.Parameters.AddWithValue("@Female_Only", Female_Only);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable getBranchSetupdata()
        {
            string sql = "select * from Tbl_Comp_Branch order by BRANCH_NAME asc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getHolidayList()
        {

            string sql = "select HOLIDAY_ID,HOLIDAY_NAME from Tbl_Org_Holiday where sta = 1 order by HOLIDAY_NAME asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAllHoliday(int HOLIDAY_ID)
        {
            string sql = "select HOLIDAY_NAME,HOLIDAY_DATE,HOLIDAY_QTY,holidayType,Female_Only from Tbl_Org_Holiday where HOLIDAY_ID=@HOLIDAY_ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@HOLIDAY_ID", HOLIDAY_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getEmployeeIdByGender(int BranchID, int flag)
        {
            string sql;
            SqlDataAdapter da;
            SqlCommand cmd;
            if (flag == 0)//Male
            {
                sql = "select emp_fullname,EMP_ID from view_Emp_Info where STATUS_ID = 1 and BRANCH_ID=@branch";
                con.Open();
                cmd = new SqlCommand(sql, con);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@branch", BranchID);
            }
            else//Female
            {

                sql = "select emp_fullname,EMP_ID from view_Emp_Info where STATUS_ID = 1 and BRANCH_ID=@branch and GENDER=@Gender";
                con.Open();
                cmd = new SqlCommand(sql, con);
                da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@branch", BranchID);
                cmd.Parameters.AddWithValue("@Gender", "Female");
            }

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int CreateHolidayAssign(string flag, string OldHoliday, string holidayname, DateTime holidaydate, string holidaytype, string remark, int branchid, int checkflag, int HOLIDAYID, int EMP_ID)
        {
            string sql = "proc_SaveBranchwiseHoliday";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", flag);
            cmd.Parameters.AddWithValue("@OldHoliday", OldHoliday);
            cmd.Parameters.AddWithValue("@holidayname", holidayname);
            cmd.Parameters.AddWithValue("@holidaydate", holidaydate);
            cmd.Parameters.AddWithValue("@holidaytype", holidaytype);
            cmd.Parameters.AddWithValue("@remark", remark);
            cmd.Parameters.AddWithValue("@branchid", branchid);
            cmd.Parameters.AddWithValue("@checkflag", checkflag);
            cmd.Parameters.AddWithValue("@HOLIDAYID", HOLIDAYID);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable MgmtWorkingHour(int group_id)
        {
            con.Open();
            string sql = "proc_WorkHourWithGroup";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@groupid", 0);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetworkId(int WORK_ID)
        {

            string sql = "select *from Tbl_Org_Working_Hrs where WORK_ID=@WORK_ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@WORK_ID", WORK_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public int ManageWeekend(int EmpId, DateTime StartDate, DateTime EndDate, DateTime CurDate, int Flag)
        {
            con.Open();
            string sql = "proc_ManageWeekend";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@CurDate", CurDate);
            cmd.Parameters.AddWithValue("@Flag", Flag);
            int j = cmd.ExecuteNonQuery();
            con.Close();
            return j;
        }
        public int ManageOpenRoosteroff(int EmpId, DateTime date, int groupid)
        {
            con.Open();
            string sql = "proc_ManageOpenRoster_off";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@groupid", groupid);
            int k = cmd.ExecuteNonQuery();
            con.Close();
            return k;
        }
        public int ManageOpenRooster(int empid, DateTime date, int groupid)
        {
            con.Open();
            string sql = "proc_ManageOpenRoster";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@groupid", groupid);
            int j = cmd.ExecuteNonQuery();
            con.Close();
            return j;
        }
        public DataTable getweekday()
        {
            con.Open();
            string sql = "select * from Tbl_weekday";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void CreateWorkingHour(int AFlag, int ID, string instart, string inend, string outstart, string outend, int hour, int minute, int lunch, int Shift, int DefaultWorkId, int sta, string GroupName)
        {
            con.Open();
            string sql = "proc_SaveWorkingShift_Group";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AFlag", 0);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@instart", instart);
            cmd.Parameters.AddWithValue("@inend", inend);
            cmd.Parameters.AddWithValue("@outstart", outstart);
            cmd.Parameters.AddWithValue("@outend", outend);
            cmd.Parameters.AddWithValue("@hour", hour);
            cmd.Parameters.AddWithValue("@minute", minute);
            cmd.Parameters.AddWithValue("@lunch", lunch);
            cmd.Parameters.AddWithValue("@Shift", Shift);
            cmd.Parameters.AddWithValue("@DefaultWorkId", DefaultWorkId);
            cmd.Parameters.AddWithValue("@sta", sta);
            cmd.Parameters.AddWithValue("@GroupName", GroupName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable GetProjectAssign()
        {
            string sql = "select distinct ProjectId,ProjectName from Tbl_Comp_ProjectAssign order by ProjectName asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetProjectAssignView(int ProjectId)
        {
            string sql = "select  ProjectName,DistrictName,DistrictId from Tbl_Comp_ProjectAssign where ProjectId=@ProjectId";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int CreateProjectAssign(int ProjectId, string ProjectName, int StateId, int DistrictId, string DistrictName)
        {
            con.Open();
            string sql = "insert into Tbl_Comp_ProjectAssign (ProjectId,ProjectName,StateId,DistrictId,DistrictName) values(@ProjectId,@ProjectName,@StateId,@DistrictId,@DistrictName)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@ProjectName", ProjectName);
            cmd.Parameters.AddWithValue("@StateId", StateId);
            cmd.Parameters.AddWithValue("@DistrictId", DistrictId);
            cmd.Parameters.AddWithValue("@DistrictName", DistrictName);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int DeleteProjectAssign(int ProjectId)
        {
            con.Open();
            string sql = "delete from Tbl_Comp_ProjectAssign where ProjectId=@ProjectId";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int DeleteProjectAssignBystate(int ProjectId, int state)
        {
            con.Open();
            string sql = "delete from Tbl_Comp_ProjectAssign where ProjectId=@ProjectId and StateId=@state";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@state", state);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        //public DataTable ProjectAssignBystate(int ProjectId, int StateId)
        //{
        //    con.Open();
        //    string sql = "select * from Tbl_Comp_ProjectAssign where ProjectId=@ProjectId and StateId=@StateId";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        //    cmd.Parameters.AddWithValue("@StateId", StateId);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;

        //}
        public bool CheckDuplicateProjectDistrict(int ProjectId, string DistrictName)
        {
            {
                con.Open();
                string sql = "select 1 from Tbl_Comp_ProjectAssign where ProjectId=@ProjectId and DistrictName=@DistrictName";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
                cmd.Parameters.AddWithValue("@DistrictName", DistrictName);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;

            }

        }
        //*************** HR Management *****************//
        public DataTable GetUserType()
        {
            string sql = "select * from Tbl_UserTypes";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Getworkhistorycpred()
        {
            string sql = "select DEG_NAME,EMP_JOINDATE,BSALARY from view_emp_Info";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetPromotionDetails(int Emp_Id)
        {
            string sql = "select * from view_emp_Info where Emp_Id=@Emp_Id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool CheckDuplicateEmpid(int Emp_Id)
        {
            {
                con.Open();
                string sql = "select 1 from Tbl_Emp_Promotion_Detail where Emp_Id=@Emp_Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;
            }

        }

        public void CreatePromotion(string EMP_ID, DateTime date, string PromotionalTitle, int FNC_ID, int DEG_ID, int Iscurrent, int P_FNC_ID, int P_DEG_ID, int Old_Salary, int New_Salary, DateTime From_Date, DateTime To_Date, int PrevProject_Id, int CurrentProject_Id, int PrevProjectDistrict_Id, int CurrentProjectDistrict_Id, string PrevProject_Name, string CurrentProject_Name, string PrevProjectDistrict_Name, string CurrentProjectDistrict_Name, string NewContract_From, string NewContract_To, int flag)
        {
            try
            {
                con.Open();
                string sql = "Proc_Promotion_Info";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@PromotionalTitle", PromotionalTitle);
                cmd.Parameters.AddWithValue("@FNC_ID", FNC_ID);
                cmd.Parameters.AddWithValue("@DEG_ID", DEG_ID);
                cmd.Parameters.AddWithValue("@Iscurrent", Iscurrent);
                cmd.Parameters.AddWithValue("@P_FNC_ID", P_FNC_ID);
                cmd.Parameters.AddWithValue("@P_DEG_ID", P_DEG_ID);
                cmd.Parameters.AddWithValue("@Old_Salary", Old_Salary);
                cmd.Parameters.AddWithValue("@New_Salary", New_Salary);

                cmd.Parameters.AddWithValue("@From_Date", From_Date);
                cmd.Parameters.AddWithValue("@To_Date", To_Date);
                cmd.Parameters.AddWithValue("@PrevProject_Id", PrevProject_Id);
                cmd.Parameters.AddWithValue("@CurrentProject_Id", CurrentProject_Id);
                cmd.Parameters.AddWithValue("@PrevProjectDistrict_Id", PrevProjectDistrict_Id);

                cmd.Parameters.AddWithValue("@CurrentProjectDistrict_Id", CurrentProjectDistrict_Id);
                cmd.Parameters.AddWithValue("@PrevProject_Name", PrevProject_Name);
                cmd.Parameters.AddWithValue("@CurrentProject_Name", CurrentProject_Name);
                cmd.Parameters.AddWithValue("@PrevProjectDistrict_Name", PrevProjectDistrict_Name);
                cmd.Parameters.AddWithValue("@CurrentProjectDistrict_Name", CurrentProjectDistrict_Name);

                cmd.Parameters.AddWithValue("@NewContract_From", NewContract_From);
                cmd.Parameters.AddWithValue("@NewContract_To", NewContract_To);

                cmd.Parameters.AddWithValue("@flag", flag);
                cmd.ExecuteNonQuery();
                con.Close();
                // return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CreateTransfer(DateTime tDate, string Trans_desc, int Iscurrent, string Eid, int Branch_ID_To, int DEPT_ID, int Section_ID_To, int Function_ID_To, int Branch_id_from, int Section_id_From, int FNC_ID_From, string District_From, string District_To, int District_FromID, int District_ToID, string Desg_To, string Desg_From, int Desg_ToID, int Desg_FromID, string Old_Salary, string New_Salary, string NewContract_From, string NewContract_To, int flag)
        {
            try
            {
                con.Open();
                string sql = "Proc_Transfer_Info";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tDate", tDate);
                cmd.Parameters.AddWithValue("@Trans_desc", Trans_desc);
                cmd.Parameters.AddWithValue("@Iscurrent", Iscurrent);
                cmd.Parameters.AddWithValue("@Eid", Eid);
                cmd.Parameters.AddWithValue("@Branch_ID_To", Branch_ID_To);
                cmd.Parameters.AddWithValue("@DEPT_ID", DEPT_ID);
                cmd.Parameters.AddWithValue("@Section_ID_To", Section_ID_To);
                cmd.Parameters.AddWithValue("@Function_ID_To", Function_ID_To);
                cmd.Parameters.AddWithValue("@Branch_id_from", Branch_id_from);
                cmd.Parameters.AddWithValue("@Section_id_From", Section_id_From);
                cmd.Parameters.AddWithValue("@FNC_ID_From", FNC_ID_From);
                cmd.Parameters.AddWithValue("@District_From", District_From);
                cmd.Parameters.AddWithValue("@District_To", District_To);
                cmd.Parameters.AddWithValue("@District_FromID", District_FromID);
                cmd.Parameters.AddWithValue("@District_ToID", District_ToID);
                cmd.Parameters.AddWithValue("@Desg_To", Desg_To);
                cmd.Parameters.AddWithValue("@Desg_From", Desg_From);
                cmd.Parameters.AddWithValue("@Desg_ToID", Desg_ToID);
                cmd.Parameters.AddWithValue("@Desg_FromID", Desg_FromID);

                cmd.Parameters.AddWithValue("@Old_Salary", Old_Salary);
                cmd.Parameters.AddWithValue("@New_Salary", New_Salary);

                cmd.Parameters.AddWithValue("@NewContract_From", NewContract_From);
                cmd.Parameters.AddWithValue("@NewContract_To", NewContract_To);
                cmd.Parameters.AddWithValue("@flag", flag);
                cmd.ExecuteNonQuery();
                con.Close();
                // return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetTransferDetails(int emp_id)
        {
            string sql = "select * from Tbl_Emp_Transfer_Detail where isCurrent=1 and Emp_id=@emp_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getDepartmentBranch(int BranchID)
        {
            string sql = "select distinct DEPT_ID, DEPT_NAME from view_Emp_Info where BRANCH_ID=@branch";
            //string sql = "Select DEPT_ID,DEPT_NAME from Tbl_Org_Dept where LEVEL=1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@branch", BranchID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getDepartmentInfo()
        {
            string sql = "Select DEPT_ID,DEPT_NAME from Tbl_Org_Dept where LEVEL=1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getWorkhistory()
        {
            string sql = "select ve.EMP_ID,vep.DEG_NAME,vet.New_Salary,vep.TDATE from view_Emp_Info ve inner join Tbl_Emp_Promotion_Detail vet on ve.EMP_ID=vet.Emp_Id inner join view_emp_promotion_details vep on ve.EMP_ID=vep.Emp_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.AddWithValue("@LEAVE_ID", leaveid);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getAllEmployeesList()
        {
            try
            {

                string sql = "select * from view_emp_info order by EMP_ID asc";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getPromotionList()
        {
            try
            {

                string sql = "select * from view_emp_promotion_details  where  IsCurrent=1";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable imagee(int empIdd)
        {
            string sql = "select EMP_IMAGE,Digital_Signature,IMAGE from view_emp_info where emp_id = " + empIdd;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getEmpLeave(int PID)
        {
            string sql = "select Tbl_Emp_Leave.PID,LEAVEID, Tbl_Emp_Leave.DAYS, Tbl_Emp_Leave.LEAVEBY, Tbl_Emp_Leave.MAXDAYS,Tbl_Org_Leave_Info.LEAVE_NAME  from Tbl_Emp_Leave INNER JOIN Tbl_Org_Leave_Info on Tbl_Emp_Leave.LEAVEID = Tbl_Org_Leave_Info.LEAVE_ID  where PID=@PID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataSet LoadPhoto(int EMP_ID)
        {
            try
            {
                string sql = "Select EMP_PHOTO from Tbl_Emp_Info where EMP_ID=@EMP_ID";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda = new SqlDataAdapter(cmd);
                sda.TableMappings.Add("Table", "Photo");
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.Dispose();
                sda.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            finally
            {
                con.Close();
            }
        }
        public DataSet LoadRelativePhoto(int EMP_ID)
        {
            try
            {
                string sql = "Select IMAGE from Tbl_Emp_Rep where EMP_ID=@EMP_ID";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda = new SqlDataAdapter(cmd);
                sda.TableMappings.Add("Table", "IMAGE");
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.Dispose();
                sda.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            finally
            {
                con.Close();
            }
        }

        public DataSet LoadDigitalSignature(int PID)
        {
            try
            {
                string sql = "Select Digital_Signature from Tbl_Emp_Off_Info where PID=@PID";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@PID", PID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda = new SqlDataAdapter(cmd);
                sda.TableMappings.Add("Table", "Signature");
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.Dispose();
                sda.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            finally
            {
                con.Close();
            }
        }

        //public DataTable digitalsig(int empId)
        //{
        //    string sql = "select Digital_Signature from view_emp_info where emp_id = " + empId;
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        //public DataTable emergencyImg(int empid1)
        //{
        //    string sql = "select IMAGE from view_emp_info where emp_id = " + empid1;
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        public DataTable getPromotion(int Emp_Id)
        {
            try
            {

                string sql = "select * from view_emp_promotion_details where Emp_Id=@Emp_Id";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Emp_Id", Emp_Id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDesignationInfo()
        {
            string sql = "SELECT * from Tbl_Org_Desg";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetDesignationList(int EMP_ID)
        {

            string sql = "SELECT DEG_ID, DEG_NAME from Tbl_Org_Desg where DEG_ID not in (select DEG_ID from Tbl_Emp_Off_Info where EMP_ID=@EMP_ID)";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getTransferList()
        {
            try
            {

                string sql = "select * from view_emp_transfer_details where isCurrent=1";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //cmd.Parameters.AddWithValue("@Emp_id", Emp_id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getTransferList(int Emp_id)
        {
            try
            {

                string sql = "select * from view_emp_transfer_details where Emp_id=@Emp_id";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Emp_id", Emp_id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getDesignation()
        {
            string sql = "SELECT DEG_ID, DEG_NAME from Tbl_Org_Desg order by DEG_NAME asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getSectionBranch(int BranchID)
        {
            string sql = "select distinct SECT_ID, section_name from view_Emp_Info where BRANCH_ID=@branch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@branch", BranchID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getValidDate(int BranchID)
        {
            string sql = "select distinct ValidFrom, ValidTo,ExtendDate from tbl_comp_branch where BRANCH_ID=@branch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@branch", BranchID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //public DataTable getdistrictfromproject(int BRANCH_ID)
        //{
        //    string sql = "select ProjectDistrictID,ProjectDistrict from view_Emp_Info where BRANCH_ID=@BRANCH_ID";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    cmd.Parameters.AddWithValue("@BRANCH_ID", BRANCH_ID);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        public DataTable getdistrictfromproject(int ProjectId)
        {
            string sql = "select distinct ProjectId,ProjectName,DistrictName,DistrictId,ABBREVIATION from Tbl_Comp_ProjectAssign  where ProjectId=@ProjectId";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getEthnicityList()
        {
            string sql = "select * from Tbl_emp_Ethnicity";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetBank()
        {
            string sql = "select * from Tbl_Bank_Info order by BANK_NAME asc";
            // string sql = "select * from Tbl_Bank_Info order by BANK_NAME asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetbankbybankId(int bankid)
        {

            string sql = "select *from Tbl_Bank_Info where BANK_ID=@bankid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@bankid", bankid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void UpdateBank(string BANK_CODE, string BANK_NAME, string Account_Id, int bankid)
        {
            try
            {
                con.Open();
                string sql = "update Tbl_Bank_Info set BANK_CODE=@BANK_CODE, BANK_NAME=@BANK_NAME, Account_Id=@Account_Id where BANK_ID=@bankid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@BANK_CODE", BANK_CODE);
                cmd.Parameters.AddWithValue("@BANK_NAME", BANK_NAME);
                cmd.Parameters.AddWithValue("@Account_Id", Account_Id);
                cmd.Parameters.AddWithValue("@bankid", bankid);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetbankbranchbyId(int Branch_Id)
        {

            string sql = "select *from Tbl_Bank_Branch where Branch_Id=@Branch_Id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Branch_Id", Branch_Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void UpdateBankBranch(string Address1, string Address2, int Branch_Id)
        {
            try
            {
                con.Open();
                string sql = "update Tbl_Bank_Branch set Address1=@Address1,Address2=@Address2 where Branch_Id=@Branch_Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Address1", Address1);
                cmd.Parameters.AddWithValue("@Address2", Address2);
                cmd.Parameters.AddWithValue("@Branch_Id", Branch_Id);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getBankBranch(int Bank_Id)
        {
            // string sql = "select Bank_Id,Branch_Id,  Address1 + case when Address2='' then '' else',' + Address2 end as Address1 from Tbl_Bank_Branch where Bank_Id=@Bank_Id";
            string sql = "select * from Tbl_Bank_Branch where Bank_Id=@Bank_Id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Bank_Id", Bank_Id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getMaxId(int BRANCH_ID)
        {
            string sql = "select (MAX(EMP_ID)+1) from view_emp_info where BRANCH_ID=@branch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@branch", BRANCH_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getMaxTravelid()
        {
            con.Open();
            string sql = "select ISNULL(MAX(VNO) + 1, 1) as travel_id from Tbl_Emp_Outstation;";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getMaxPid()
        {
            con.Open();
            string sql = "select (MAX(PID)+1) from Tbl_Emp_DBID";
            SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getPid(int EMP_ID)
        {
            con.Open();
            string sql = "select * from Tbl_Emp_DBID where EMP_ID=@EMP_ID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getLeaveInfo()
        {
            string sql = "select LEAVE_ID,LEAVE_NAME,LEAVE_DAYS,LEAVE_MAX from Tbl_Org_Leave_Info";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getLeaveInfobyId(int PID)
        {
            string sql = "SELECT Tbl_Emp_Leave.LEAVEID,Tbl_Emp_Leave.DAYS,Tbl_Emp_Leave.MAXDAYS, Tbl_Org_Leave_info.LEAVE_NAME FROM Tbl_Emp_Leave INNER JOIN Tbl_Org_Leave_info ON Tbl_Emp_Leave.LEAVEID = Tbl_Org_Leave_info.LEAVE_ID where PID =@PID";
            //string sql = "select * from Tbl_Emp_Leave where PID =@PID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@PID", PID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getLeavebyId(int PID, int LEAVEID)
        {

            string sql = "select * from Tbl_Emp_Leave where PID =@PID and LEAVEID=@LEAVEID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@LEAVEID", LEAVEID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getStateList()
        {
            string sql = "select StateName,StateId from Tbl_Org_State";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getDistrictList()
        {
            string sql = "select DistrictId,DistrictName,StateId from  Tbl_org_state_district  order by DistrictName asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getDistrict(int StateId)
        {
            string sql = "select distinct DistrictId, DistrictName,StateId from Tbl_org_state_district where StateId=@StateId";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@StateId", StateId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getBloodgroup()
        {
            string sql = "select * from tbl_blood_group";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getHODList()
        {
            string sql = "select emp_id, emp_fullname from view_emp_info where UserTypeId = 4";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getDepartment()
        {
            string sql = "Select DEPT_ID,DEPT_NAME from Tbl_Org_Dept where LEVEL=1 order by DEPT_NAME asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getBankBranch()
        {
            string sql = "SELECT Tbl_Bank_Info.BANK_ID, Tbl_Bank_Info.BANK_NAME, Tbl_Bank_Branch.Address1,Tbl_Bank_Branch.Address2,Tbl_Bank_Branch.Branch_Id FROM Tbl_Bank_Info INNER JOIN Tbl_Bank_Branch ON Tbl_Bank_Info.BANK_ID=Tbl_Bank_Branch.Bank_Id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int CreateBankBranch(int Bank_Id, string Address1, string Address2)
        {
            try
            {
                con.Open();
                string sql = "insert into Tbl_Bank_Branch (Bank_Id,Address1,Address2) values(@Bank_Id,@Address1,@Address2)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Bank_Id", Bank_Id);
                //cmd.Parameters.AddWithValue("@Branch_Id", Branch_Id);
                cmd.Parameters.AddWithValue("@Address1", Address1);
                cmd.Parameters.AddWithValue("@Address2", Address2);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CreateBank(string BANK_CODE, string BANK_NAME, string Account_Id)
        {
            try
            {
                con.Open();
                string sql = "insert into Tbl_Bank_Info (BANK_CODE,BANK_NAME,Account_Id) values(@BANK_CODE,@BANK_NAME,@Account_Id)";
                SqlCommand cmd = new SqlCommand(sql, con);
                //cmd.Parameters.AddWithValue("@BANK_ID", BANK_ID);
                cmd.Parameters.AddWithValue("@BANK_CODE", BANK_CODE);
                cmd.Parameters.AddWithValue("@BANK_NAME", BANK_NAME);
                cmd.Parameters.AddWithValue("@Account_Id", Account_Id);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckPID(string pid)
        {
            {
                con.Open();
                string sql = "select 1 from tblEmpEducation where pid=@pid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pid", pid);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;
            }

        }
        public bool CheckTrainingPid(string pid)
        {
            {
                con.Open();
                string sql = "select 1 from tblEmpTraining where pid=@pid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pid", pid);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;
            }

        }
        public bool CheckPastWorkPid(string pid)
        {
            {
                con.Open();
                string sql = "select 1 from tblEmpJobExperience where pid=@pid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pid", pid);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;
            }

        }
        public bool CheckSerialNumber(string SNO)
        {
            {
                con.Open();
                string sql = "select 1 from tblEmpEducation where SNO=@SNO";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@SNO", SNO);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;
            }

        }
        public bool CheckTrainingSerialNumber(string SNO)
        {
            {
                con.Open();
                string sql = "select 1 from tblEmpTraining where SNO=@SNO";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@SNO", SNO);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;
            }

        }
        public bool CheckPWSerialNumber(string SNO)
        {
            {
                con.Open();
                string sql = "select 1 from tblEmpJobExperience where SNO=@SNO";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@SNO", SNO);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;
            }

        }
        public bool CheckDuplicateEmpId(string EMP_ID)
        {
            {
                con.Open();
                string sql = "select 1 from Tbl_Emp_Info where EMP_ID=@EMP_ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;
            }

        }

        public bool CheckDuplicatePId(string PID)
        {
            {
                con.Open();
                string sql = "select 1 from Tbl_Emp_DBID where PID=@PID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@PID", PID);
                SqlDataReader reader = cmd.ExecuteReader();

                int cn = 0;
                while (reader.Read())
                {
                    cn = int.Parse(reader.GetValue(0).ToString());

                }
                cmd.Dispose();
                con.Close();
                if (cn == 1)
                    return true;
                return false;
            }

        }
        public void CreateEmpGeneralInfo(string EMP_ID, string EMP_IMAGE, string EMP_TITLE, string FNAME, string MNAME, string LNAME,
            string GENDER, string MSTATUS, DateTime DATE, DateTime JOINDATE, string MOBILE, string PHONE, string CITIZENNO, string EMAIL,
            string USERID, string PASSWORD, string PADD, string TSTREET, string TDISTRICT, string TZONE, string PSTREET, string PDISTRICT,
            string PZONE, string PCOUNTRY, string BLOOD_GROUP, string ALLERGY, string MED_CON, string DOCTOR, string DOCTOR_CONTACT,
            string DOCTOR1, string DOCTOR_CONTACT1, string PVDC_municipality, string PWard_Number, string PVillage_Tole, string TVDC_municipality,
            string TWard_Number, string TVillage_Tole, string Ethnicity, string CitizenshipDistrict, string Spouse_Name, string Children_Number,
            string Father_Name, string Mother_Name, string Grandfather_Name, string Father_Occupation, string Son_Number, string Daughter_Number,
            string Religion, int Religion_Id, string Age, string Passport_Number, int Ethnicity_Id, int DistrictId, int PState_Id, int PDistrict_Id, int TState_Id, int TDistrict_Id, int BloodGroup_Id)
        {
            string fileName = string.Empty;
            string filePath = string.Empty;

            con.Open();
            string sql = "proc_manage_Emp_info";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@EMP_TITLE", EMP_TITLE);
            //cmd.Parameters.AddWithValue("@Emp_Salutation", Emp_Salutation);
            cmd.Parameters.AddWithValue("@FNAME", FNAME);
            cmd.Parameters.AddWithValue("@MNAME", MNAME);
            cmd.Parameters.AddWithValue("@LNAME", LNAME);
            cmd.Parameters.AddWithValue("@GENDER", GENDER);
            cmd.Parameters.AddWithValue("@MSTATUS", MSTATUS);
            cmd.Parameters.AddWithValue("@DATE", DATE);
            cmd.Parameters.AddWithValue("@JOINDATE", JOINDATE);
            cmd.Parameters.AddWithValue("@MOBILE", MOBILE);
            cmd.Parameters.AddWithValue("@PHONE", PHONE);
            cmd.Parameters.AddWithValue("@CITIZENNO", CITIZENNO);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@USERID", USERID);
            cmd.Parameters.AddWithValue("@PASSWORD", PASSWORD);
            cmd.Parameters.AddWithValue("@PADD", PADD);
            cmd.Parameters.AddWithValue("@TSTREET", TSTREET);
            cmd.Parameters.AddWithValue("@TDISTRICT", TDISTRICT);
            cmd.Parameters.AddWithValue("@TZONE", TZONE);
            cmd.Parameters.AddWithValue("@PSTREET", PSTREET);
            cmd.Parameters.AddWithValue("@PDISTRICT", PDISTRICT);
            cmd.Parameters.AddWithValue("@PZONE", PZONE);
            cmd.Parameters.AddWithValue("@PCOUNTRY", PCOUNTRY);
            cmd.Parameters.AddWithValue("@BLOOD_GROUP", BLOOD_GROUP);
            cmd.Parameters.AddWithValue("@ALLERGY", ALLERGY);
            cmd.Parameters.AddWithValue("@MED_CON", MED_CON);
            cmd.Parameters.AddWithValue("@DOCTOR", DOCTOR);
            cmd.Parameters.AddWithValue("@DOCTOR_CONTACT", DOCTOR_CONTACT);
            cmd.Parameters.AddWithValue("@DOCTOR1", DOCTOR1);
            cmd.Parameters.AddWithValue("@DOCTOR_CONTACT1", DOCTOR_CONTACT1);

            cmd.Parameters.AddWithValue("@PVDC_municipality", PVDC_municipality);
            cmd.Parameters.AddWithValue("@PWard_Number", PWard_Number);
            cmd.Parameters.AddWithValue("@PVillage_Tole", PVillage_Tole);
            cmd.Parameters.AddWithValue("@TVDC_municipality", TVDC_municipality);
            cmd.Parameters.AddWithValue("@TWard_Number", TWard_Number);
            cmd.Parameters.AddWithValue("@TVillage_Tole", TVillage_Tole);

            cmd.Parameters.AddWithValue("@Ethnicity", Ethnicity);
            cmd.Parameters.AddWithValue("@CitizenshipDistrict", CitizenshipDistrict);
            cmd.Parameters.AddWithValue("@Spouse_Name", Spouse_Name);
            cmd.Parameters.AddWithValue("@Children_Number", Children_Number);
            cmd.Parameters.AddWithValue("@Father_Name", Father_Name);
            cmd.Parameters.AddWithValue("@Mother_Name", Mother_Name);
            cmd.Parameters.AddWithValue("@Grandfather_Name", Grandfather_Name);

            cmd.Parameters.AddWithValue("@Father_Occupation", Father_Occupation);
            cmd.Parameters.AddWithValue("@Son_Number", Son_Number);
            cmd.Parameters.AddWithValue("@Daughter_Number", Daughter_Number);
            cmd.Parameters.AddWithValue("@Religion", Religion);
            cmd.Parameters.AddWithValue("@Religion_Id", Religion_Id);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@Passport_Number", Passport_Number);
            cmd.Parameters.AddWithValue("@Ethnicity_Id", Ethnicity_Id);
            cmd.Parameters.AddWithValue("@DistrictId", DistrictId);

            cmd.Parameters.AddWithValue("@PState_Id", PState_Id);
            cmd.Parameters.AddWithValue("@PDistrict_Id", PDistrict_Id);
            cmd.Parameters.AddWithValue("@TState_Id", TState_Id);
            cmd.Parameters.AddWithValue("@TDistrict_Id", TDistrict_Id);
            cmd.Parameters.AddWithValue("@BloodGroup_Id", BloodGroup_Id);
            cmd.ExecuteNonQuery();
            con.Close();
            //return i;
            if (EMP_IMAGE != string.Empty)
            {
                SavePhoto(EMP_IMAGE, EMP_ID.ToString(), 1);
            }

        }
        //flag 1 for general photo,flag 2 digital signature ,flag 3 Relative photo
        public void SavePhoto(string image, string Emp_id, int flag)
        {
            try
            {
                byte[] img = null;
                string query;
                string sql;
                SqlCommand cmd;

                //  SqlCommand cmd = new SqlCommand(sql, con);
                if (flag == 1)
                {
                    con.Open();
                    if (image != string.Empty && image != "Not Required")
                    {
                        img = File.ReadAllBytes(image);
                        //resizeImage(127, 133, textBox1.Text);
                        query = "update tbl_emp_info set EMP_PHOTO=@image where EMP_ID=@empid";
                        //cmd = new SqlCommand(sql, con);
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Image", img);
                    }
                    else if (image == "Not Required")
                    {
                        return;
                    }
                    else
                    {
                        query = "update tbl_emp_info set EMP_PHOTO=NULL where EMP_ID=@empid";
                        cmd = new SqlCommand(query, con);
                    }

                    cmd.Parameters.AddWithValue("@empid", Emp_id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                }
                else if (flag == 2)
                {
                    con.Open();
                    if (image != string.Empty && image != "Not Required")
                    {
                        img = File.ReadAllBytes(image);
                        //resizeImage(127, 133, textBox1.Text);
                        query = "update tbl_emp_off_info set Digital_Signature=@image where PID=@empid";
                        // cmd = new SqlCommand(sql, con);
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Image", img);
                    }
                    else if (image == "Not Required")
                    {
                        return;
                    }
                    else
                    {
                        query = "update tbl_emp_off_info set Digital_Signature=NULL where PID=@empid";
                        cmd = new SqlCommand(query, con);
                    }

                    cmd.Parameters.AddWithValue("@empid", Emp_id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                }
                else if (flag == 3)
                {
                    con.Open();
                    if (image != string.Empty && image != "Not Required")
                    {
                        img = File.ReadAllBytes(image);
                        //resizeImage(127, 133, textBox1.Text);
                        query = "update Tbl_Emp_Rep set IMAGE=@image where EMP_ID=@empid";
                        // cmd = new SqlCommand(sql, con);
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Image", img);
                    }
                    else if (image == "Not Required")
                    {
                        return;
                    }
                    else
                    {
                        query = "update Tbl_Emp_Rep set IMAGE=NULL where EMP_ID=@empid";
                        cmd = new SqlCommand(query, con);
                    }

                    cmd.Parameters.AddWithValue("@empid", Emp_id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                }
                else
                {
                    con.Open();
                    if (image != string.Empty && image != "Not Required")
                    {
                        img = File.ReadAllBytes(image);
                        //resizeImage(127, 133, textBox1.Text);
                        query = "update tbl_emp_off_info set Digital_Signature=@image where EMP_ID=@empid";
                        // cmd = new SqlCommand(sql, con);
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Image", img);
                    }
                    else if (image == "Not Required")
                    {
                        return;
                    }
                    else
                    {
                        query = "update tbl_emp_off_info set Digital_Signature=NULL where EMP_ID=@empid";
                        cmd = new SqlCommand(query, con);
                    }

                    cmd.Parameters.AddWithValue("@empid", Emp_id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                con.Close();
            }
        }

        public void CreateOfficialInfo(int deg_id, int mode_id, int dept_id, int branch_id, int status_id, int Grade_id, string roomno, string offemail, string extno, string cardno, string vehicleno, DateTime cardExpirydate, DateTime licenceexpirydate, string licenceno, string permanentdate, string Resigndate, DateTime probationdfrom, DateTime probationdTo, string probationMFrom, string probationMTo, string emp_id, string cit_number, string epan_number, string pf_number, int checkWebLogin, int PID, int IsOT, string Fileno, int bank_id, string BANK_NAME, int BankbranchId, string bankAC, DateTime suspensionFrom, DateTime suspensionTo, DateTime dischargeDate, DateTime dissmissDate, DateTime contractFrom, DateTime contractTo, DateTime traineeFrom, DateTime traineeTo, string Basic_Salary, string Resigned_Laidoff, string Severance_No, string Social_Security, int IsAttendance, string Premium_Amount, string Digital_Signature, string ProjectDistrict, int UserType_Id, string UserType_Name, string Retired_Date, string Retired_DateTo, string Retired_Remarks, string Gratuity, string Type_fromDate, string Type_toDate, string EmployeeType_Name, int EmployeeType_Id)
        {
            string fileName = string.Empty;
            string filePath = string.Empty;
            con.Open();
            string sql = "proc_manage_Official_info";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deg_id", deg_id);
            cmd.Parameters.AddWithValue("@mode_id", mode_id);
            cmd.Parameters.AddWithValue("@dept_id", dept_id);
            cmd.Parameters.AddWithValue("@branch_id", branch_id);
            cmd.Parameters.AddWithValue("@status_id", status_id);
            cmd.Parameters.AddWithValue("@Grade_id", Grade_id);
            cmd.Parameters.AddWithValue("@roomno", "Null");
            cmd.Parameters.AddWithValue("@offemail", offemail);
            cmd.Parameters.AddWithValue("@extno", "Null");
            cmd.Parameters.AddWithValue("@cardno", "Null");
            cmd.Parameters.AddWithValue("@vehicleno", "Null");
            cmd.Parameters.AddWithValue("@cardExpirydate", cardExpirydate);
            cmd.Parameters.AddWithValue("@licenceexpirydate", licenceexpirydate);
            cmd.Parameters.AddWithValue("@licenceno", "Null");
            cmd.Parameters.AddWithValue("@permanentdate", permanentdate);
            cmd.Parameters.AddWithValue("@Resigndate", Resigndate);
            cmd.Parameters.AddWithValue("@probationdfrom", probationdfrom);
            cmd.Parameters.AddWithValue("@probationdTo", probationdTo);
            cmd.Parameters.AddWithValue("@probationMFrom", probationMFrom);
            cmd.Parameters.AddWithValue("@probationMTo", probationMTo);
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            cmd.Parameters.AddWithValue("@cit_number", cit_number);
            cmd.Parameters.AddWithValue("@epan_number", epan_number);
            cmd.Parameters.AddWithValue("@pf_number", pf_number);
            cmd.Parameters.AddWithValue("@checkWebLogin", checkWebLogin);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@IsOT", IsOT);
            cmd.Parameters.AddWithValue("@Fileno", Fileno);
            cmd.Parameters.AddWithValue("@bank_id", bank_id);
            cmd.Parameters.AddWithValue("@BANK_NAME", BANK_NAME);
            cmd.Parameters.AddWithValue("@BankbranchId", BankbranchId);
            cmd.Parameters.AddWithValue("@bankAC", bankAC);
            cmd.Parameters.AddWithValue("@suspensionFrom", suspensionFrom);
            cmd.Parameters.AddWithValue("@suspensionTo", suspensionTo);
            cmd.Parameters.AddWithValue("@dischargeDate", dischargeDate);
            cmd.Parameters.AddWithValue("@dissmissDate", dissmissDate);
            cmd.Parameters.AddWithValue("@contractFrom", contractFrom);
            cmd.Parameters.AddWithValue("@contractTo", contractTo);
            cmd.Parameters.AddWithValue("@traineeFrom", traineeFrom);
            cmd.Parameters.AddWithValue("@traineeTo", traineeTo);

            cmd.Parameters.AddWithValue("@Basic_Salary", Convert.ToDouble(Basic_Salary));
            cmd.Parameters.AddWithValue("@Resigned_Laidoff", Resigned_Laidoff);
            cmd.Parameters.AddWithValue("@Severance_No", Severance_No);

            cmd.Parameters.AddWithValue("@Social_Security", Social_Security);
            cmd.Parameters.AddWithValue("@IsAttendance", IsAttendance);
            cmd.Parameters.AddWithValue("@Premium_Amount", Premium_Amount);
            //cmd.Parameters.AddWithValue("@Digital_Signature", Digital_Signature);
            cmd.Parameters.AddWithValue("@ProjectDistrict", ProjectDistrict);
            cmd.Parameters.AddWithValue("@UserType_Id", UserType_Id);
            cmd.Parameters.AddWithValue("@UserType_Name", UserType_Name);
            cmd.Parameters.AddWithValue("@Retired_Date", Retired_Date);
            cmd.Parameters.AddWithValue("@Retired_DateTo", Retired_DateTo);
            cmd.Parameters.AddWithValue("@Retired_Remarks", Retired_Remarks);
            cmd.Parameters.AddWithValue("@Gratuity", Gratuity);
            cmd.Parameters.AddWithValue("@Type_fromDate", Type_fromDate);
            cmd.Parameters.AddWithValue("@Type_toDate", Type_toDate);
            cmd.Parameters.AddWithValue("@EmployeeType_Name", EmployeeType_Name);
            cmd.Parameters.AddWithValue("@EmployeeType_Id", EmployeeType_Id);

            cmd.ExecuteNonQuery();
            con.Close();
            if (Digital_Signature != string.Empty)
            {
                SavePhoto(Digital_Signature, PID.ToString(), 2);
            }

            //return j;
        }
        /// <summary>
        /// //Image working
        /// </summary>
        /// <param name="EMP_ID"></param>
        ///TO RENDER PHOTO
        public void SaveEducationPhoto(int Employee_Id, string Image_Name)
        {
            string sql = "insert into tbl_Education_Image (Employee_Id,Image_Name) values(@Employee_Id,@Image_Name)";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Employee_Id", Employee_Id);
            cmd.Parameters.AddWithValue("@Image_Name", Image_Name);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable Education(int PID)
        {
            string sql = "select * from tblEmpEducation  where PID=@PID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable Educationc(int SNO)
        {
            string sql = "select * from tblEmpEducation  where SNO=@SNO";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SNO", SNO);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable TrainingDocument(int SNO)
        {
            string sql = "select * from tblEmpTraining  where SNO=@SNO";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SNO", SNO);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable WorkDocument(int SNO)
        {
            string sql = "select * from tblEmpJobExperience  where SNO=@SNO";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SNO", SNO);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataSet EducationDoc(int PID)
        {
            try
            {
                string sql = "select Image,Image_Name from tblEmpEducation  where PID=@PID";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@PID", PID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda = new SqlDataAdapter(cmd);
                sda.TableMappings.Add("Table", "EducationDoc");
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.Dispose();
                sda.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            finally
            {
                con.Close();
            }
        }


        public DataTable Training(int PID)
        {
            string sql = "select * from tblEmpTraining  where PID=@PID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataSet TrainingDoc1(int PID)
        {
            try
            {
                string sql = "select Image,TrImage_Name from tblEmpTraining  where PID=@PID";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@PID", PID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda = new SqlDataAdapter(cmd);
                sda.TableMappings.Add("Table", "TrainingDoc");
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.Dispose();
                sda.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            finally
            {
                con.Close();
            }
        }
        public DataTable TrainingDoc(int PID)
        {
            try
            {
                string sql = "select Image,TrImage_Name from tblEmpTraining  where PID=@PID";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@PID", PID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda = new SqlDataAdapter(cmd);
                //sda.TableMappings.Add("Table", "TrainingDoc");
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            finally
            {
                con.Close();
            }
        }
        public DataTable jobexperience(int PID)
        {
            string sql = "select * from tblEmpJobExperience  where PID=@PID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataSet WorkExpDoc(int PID)
        {
            try
            {
                string sql = "select Image,PWImage_Name from tblEmpJobExperience  where PID=@PID";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@PID", PID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda = new SqlDataAdapter(cmd);
                sda.TableMappings.Add("Table", "WorkExpDoc");
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmd.Dispose();
                sda.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            finally
            {
                con.Close();
            }
        }

        public void InsertEmpRelativeInfo(string EMP_ID, string NAME, string ADDRESS, string RELATION, string CONTACT, string IMAGE, string MOBILE)
        {
            string fileName = string.Empty;
            string filePath = string.Empty;

            con.Open();
            string sql = "proc_manage_relative_info";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@NAME", NAME);
            cmd.Parameters.AddWithValue("@ADDRESS", ADDRESS);
            cmd.Parameters.AddWithValue("@RELATION", RELATION);
            cmd.Parameters.AddWithValue("@CONTACT ", CONTACT);

            //cmd.Parameters.AddWithValue("@IMAGE", IMAGE);
            cmd.Parameters.AddWithValue("@MOBILE ", MOBILE);
            cmd.ExecuteNonQuery();
            con.Close();

            if (IMAGE != string.Empty)
            {
                SavePhoto(IMAGE, EMP_ID.ToString(), 3);
            }
        }

        public void insertedu(int pid, string schoolCollege, string degree, string division, string percentage, string date, string majorSubject, string Image_Name, string Image, string EXT)
        {
            con.Open();
            byte[] img = { 0 };
            SqlCommand cmd;
            if (EXT == ".pdf" || EXT == ".PDF")//.PDF
            {

                string sql = " insert into tblEmpEducation (pid,schoolCollege,majorSubject,division,percentage,date,degree,PDF_Name,PDF,EXT) values(@pid,@schoolCollege,@majorSubject,@division,@percentage,@date,@degree,@PDF_Name,@PDF,@EXT)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@schoolCollege", schoolCollege);
                cmd.Parameters.AddWithValue("@degree", degree);
                cmd.Parameters.AddWithValue("@division", division);
                cmd.Parameters.AddWithValue("@percentage", percentage);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@majorSubject", majorSubject);

                if (Image != string.Empty)
                {
                    FileStream fStream = File.OpenRead(Image);
                    byte[] contents = new byte[fStream.Length];
                    fStream.Read(contents, 0, (int)fStream.Length);
                    fStream.Close();
                    cmd.Parameters.AddWithValue("@PDF", contents);
                    cmd.Parameters.AddWithValue("@PDF_Name", Image_Name);
                    cmd.Parameters.AddWithValue("@EXT", EXT);
                }
                else
                {
                    Image_Name = "";
                    EXT = "";
                    cmd.Parameters.AddWithValue("@PDF", SqlDbType.Image).Value = img;
                    cmd.Parameters.AddWithValue("@PDF_Name", Image_Name);
                    cmd.Parameters.AddWithValue("@EXT", EXT);
                }


            }
            else
            {
                string sql = " insert into tblEmpEducation (pid,schoolCollege,majorSubject,division,percentage,date,degree,Image_Name,Image,EXT) values(@pid,@schoolCollege,@majorSubject,@division,@percentage,@date,@degree,@Image_Name,@Image,@EXT)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@schoolCollege", schoolCollege);
                cmd.Parameters.AddWithValue("@degree", degree);
                cmd.Parameters.AddWithValue("@division", division);
                cmd.Parameters.AddWithValue("@percentage", percentage);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@majorSubject", majorSubject);
                cmd.Parameters.AddWithValue("@Image_Name", Image_Name);


                if (Image != string.Empty && Image != "Not Required")
                {
                    img = File.ReadAllBytes(Image);
                    cmd.Parameters.AddWithValue("@Image", img);
                    cmd.Parameters.AddWithValue("@EXT", EXT);

                }
                else if (Image == "Not Required")
                {
                    return;
                }


                else
                {
                    Image_Name = "";
                    EXT = "";
                    cmd.Parameters.AddWithValue("@Image", SqlDbType.Image).Value = img;
                    cmd.Parameters.AddWithValue("@PDF_Name", Image_Name);
                    cmd.Parameters.AddWithValue("@EXT", EXT);
                }
            }


            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateEdu(int pid, string schoolCollege, string degree, string division, string percentage, string date, string majorSubject, int SNO)
        {
            con.Open();

            string sql = "update tblEmpEducation set pid=@pid,schoolCollege=@schoolCollege,degree=@degree,division=@division,percentage=@percentage,date=@date,majorSubject=@majorSubject where SNO=@SNO";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@schoolCollege", schoolCollege);
            cmd.Parameters.AddWithValue("@degree", degree);
            cmd.Parameters.AddWithValue("@division", division);
            cmd.Parameters.AddWithValue("@percentage", percentage);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@majorSubject", majorSubject);
            cmd.Parameters.AddWithValue("@SNO", SNO);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        //public void updateEduWithImage(int pid, string schoolCollege, string degree, string division, string percentage, string date, string majorSubject,  string Image_Name, string Image, string EXT,int SNO)
        //{
        //    con.Open();
        //    byte[] img = { 0 };
        //    SqlCommand cmd;
        //    if (EXT == ".pdf" || EXT == ".PDF")//.PDF
        //    {
        //        string sql = "update tblEmpEducation set pid=@pid,schoolCollege=@schoolCollege,degree=@degree,division=@division,percentage=@percentage,date=@date,majorSubject=@majorSubject,PDF_Name=@PDF_Name,PDF=@PDF,EXT=@EXT  where SNO=@SNO";
        //        cmd = new SqlCommand(sql, con);
        //        cmd.Parameters.AddWithValue("@pid", pid);
        //        cmd.Parameters.AddWithValue("@schoolCollege", schoolCollege);
        //        cmd.Parameters.AddWithValue("@degree", degree);
        //        cmd.Parameters.AddWithValue("@division", division);
        //        cmd.Parameters.AddWithValue("@percentage", percentage);
        //        cmd.Parameters.AddWithValue("@date", date);
        //        cmd.Parameters.AddWithValue("@majorSubject", majorSubject);
        //        cmd.Parameters.AddWithValue("@SNO", SNO);

        //        if (Image != string.Empty)
        //        {
        //            FileStream fStream = File.OpenRead(Image);
        //            byte[] contents = new byte[fStream.Length];
        //            fStream.Read(contents, 0, (int)fStream.Length);
        //            fStream.Close();
        //            cmd.Parameters.AddWithValue("@PDF", contents);
        //            cmd.Parameters.AddWithValue("@PDF_Name", Image_Name);
        //            cmd.Parameters.AddWithValue("@EXT", EXT);
        //        }
        //        else
        //        {
        //            Image_Name = "";
        //            EXT = "";
        //            cmd.Parameters.AddWithValue("@PDF", SqlDbType.Image).Value = img;
        //            cmd.Parameters.AddWithValue("@PDF_Name", Image_Name);
        //            cmd.Parameters.AddWithValue("@EXT", EXT);
        //        }


        //    }
        //    else
        //    {
        //        string sql = "update tblEmpEducation set pid=@pid,schoolCollege=@schoolCollege,degree=@degree,division=@division,percentage=@percentage,date=@date,majorSubject=@majorSubject,Image_Name=@Image_Name where SNO=@SNO";
        //         cmd = new SqlCommand(sql, con);
        //        cmd.Parameters.AddWithValue("@pid", pid);
        //        cmd.Parameters.AddWithValue("@schoolCollege", schoolCollege);
        //        cmd.Parameters.AddWithValue("@degree", degree);
        //        cmd.Parameters.AddWithValue("@division", division);
        //        cmd.Parameters.AddWithValue("@percentage", percentage);
        //        cmd.Parameters.AddWithValue("@date", date);
        //        cmd.Parameters.AddWithValue("@majorSubject", majorSubject);
        //        cmd.Parameters.AddWithValue("@Image_Name", Image_Name);
        //        cmd.Parameters.AddWithValue("@SNO", SNO);

        //        if (Image != string.Empty && Image != "Not Required")
        //        {
        //            img = File.ReadAllBytes(Image);
        //            cmd.Parameters.AddWithValue("@Image", img);
        //            cmd.Parameters.AddWithValue("@EXT", EXT);

        //        }
        //        else if (Image == "Not Required")
        //        {
        //            return;
        //        }


        //        else
        //        {
        //            Image_Name = "";
        //            EXT = "";
        //            cmd.Parameters.AddWithValue("@Image", SqlDbType.Image).Value = img;
        //            cmd.Parameters.AddWithValue("@Image_Name", Image_Name);
        //            cmd.Parameters.AddWithValue("@EXT", EXT);
        //        }
        //    }


        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    }

        public void updateTraining(int pid, string organization, string place, string startDate, string endDate, string Title, string Days, int SNO)
        {
            con.Open();

            string sql = "update tblEmpTraining set pid=@pid,organization=@organization,place=@place,startDate=@startDate,endDate=@endDate,Title=@Title,Days=@Days where SNO=@SNO";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@organization", organization);
            cmd.Parameters.AddWithValue("@place", place);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Days", Days);
            cmd.Parameters.AddWithValue("@SNO", SNO);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateJobExperience(int pid, string organization, string designation, string startDate, string endDate, string Salary, string Contact, int SNO)
        {
            con.Open();

            string sql = "update tblEmpJobExperience set pid=@pid,organization=@organization,designation=@designation,startDate=@startDate,endDate=@endDate,Salary=@Salary,Contact=@Contact where SNO=@SNO";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@organization", organization);
            cmd.Parameters.AddWithValue("@designation", designation);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            cmd.Parameters.AddWithValue("@Salary", Salary);
            cmd.Parameters.AddWithValue("@Contact", Contact);
            cmd.Parameters.AddWithValue("@SNO", SNO);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteEducation(int SNO)
        {
            con.Open();
            string sql = "delete from tblEmpEducation where SNO=@SNO";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SNO", SNO);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void insertTraining(int pid, string organization, string place, string startDate, string endDate, string Title, string Days, string TrImage_Name, string Image, string EXT)
        {
            con.Open();
            byte[] imgTr = { 0 };
            SqlCommand cmd;
            if (EXT == ".pdf" || EXT == ".PDF")//.PDF
            {
                string sql = "insert into tblEmpTraining (pid,organization,place,startDate,endDate,Title,Days,PDF_Name,PDF,EXT) values(@pid,@organization,@place,@startDate,@endDate,@Title,@Days,@PDF_Name,@PDF,@EXT)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@organization", organization);
                cmd.Parameters.AddWithValue("@place", place);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@Days", Days);
                cmd.Parameters.AddWithValue("@TrImage_Name", TrImage_Name);

                if (Image != string.Empty)
                {
                    FileStream fStream = File.OpenRead(Image);
                    byte[] contents = new byte[fStream.Length];
                    fStream.Read(contents, 0, (int)fStream.Length);
                    fStream.Close();
                    cmd.Parameters.AddWithValue("@PDF", contents);
                    cmd.Parameters.AddWithValue("@PDF_Name", TrImage_Name);
                    cmd.Parameters.AddWithValue("@EXT", EXT);
                }
                else
                {
                    TrImage_Name = "";
                    EXT = "";
                    cmd.Parameters.AddWithValue("@PDF", SqlDbType.Image).Value = imgTr;
                    cmd.Parameters.AddWithValue("@PDF_Name", TrImage_Name);
                    cmd.Parameters.AddWithValue("@EXT", EXT);
                }

            }
            else
            {
                string sql = "insert into tblEmpTraining (pid,organization,place,startDate,endDate,Title,Days,TrImage_Name,Image,EXT) values(@pid,@organization,@place,@startDate,@endDate,@Title,@Days,@TrImage_Name,@Image,@EXT)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@organization", organization);
                cmd.Parameters.AddWithValue("@place", place);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@Days", Days);
                cmd.Parameters.AddWithValue("@TrImage_Name", TrImage_Name);


                if (Image != string.Empty && Image != "Not Required")
                {
                    imgTr = File.ReadAllBytes(Image);
                    cmd.Parameters.AddWithValue("@Image", imgTr);
                    cmd.Parameters.AddWithValue("@EXT", EXT);

                }
                else if (Image == "Not Required")
                {
                    return;
                }


                else
                {
                    TrImage_Name = "";
                    EXT = "";
                    cmd.Parameters.AddWithValue("@Image", SqlDbType.Image).Value = imgTr;
                    cmd.Parameters.AddWithValue("@PDF_Name", TrImage_Name);
                    cmd.Parameters.AddWithValue("@EXT", EXT);
                }
            }


            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteTraining(int SNO)
        {
            con.Open();
            string sql = "delete from tblEmpTraining where SNO=@SNO";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SNO", SNO);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void insertJobExperience(int pid, string organization, string designation, string startDate, string endDate, string Salary, string Contact, string PWImage_Name, string Image, string EXT)
        {
            con.Open();
            byte[] imgPW = { 0 };
            SqlCommand cmd;
            if (EXT == ".pdf" || EXT == ".PDF")//.PDF
            {
                string sql = "insert into tblEmpJobExperience (pid,organization,designation,startDate,endDate,Salary,Contact,PDF_Name,PDF,EXT) values(@pid,@organization,@designation,@startDate,@endDate,@Salary,@Contact,@PDF_Name,@PDF,@EXT)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@organization", organization);
                cmd.Parameters.AddWithValue("@designation", designation);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@Salary", Salary);
                cmd.Parameters.AddWithValue("@Contact", Contact);
                //cmd.Parameters.AddWithValue("@PWImage_Name", PWImage_Name);

                if (Image != string.Empty)
                {
                    FileStream fStream = File.OpenRead(Image);
                    byte[] contents = new byte[fStream.Length];
                    fStream.Read(contents, 0, (int)fStream.Length);
                    fStream.Close();
                    cmd.Parameters.AddWithValue("@PDF", contents);
                    cmd.Parameters.AddWithValue("@PDF_Name", PWImage_Name);
                    cmd.Parameters.AddWithValue("@EXT", EXT);
                }
                else
                {
                    PWImage_Name = "";
                    EXT = "";
                    cmd.Parameters.AddWithValue("@PDF", SqlDbType.Image).Value = imgPW;
                    cmd.Parameters.AddWithValue("@PDF_Name", PWImage_Name);
                    cmd.Parameters.AddWithValue("@EXT", EXT);
                }
            }
            else
            {
                string sql = "insert into tblEmpJobExperience (pid,organization,designation,startDate,endDate,Salary,Contact,PWImage_Name,Image,EXT) values(@pid,@organization,@designation,@startDate,@endDate,@Salary,@Contact,@PWImage_Name,@Image,@EXT)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@organization", organization);
                cmd.Parameters.AddWithValue("@designation", designation);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@Salary", Salary);
                cmd.Parameters.AddWithValue("@Contact", Contact);
                cmd.Parameters.AddWithValue("@PWImage_Name", PWImage_Name);


                if (Image != string.Empty && Image != "Not Required")
                {
                    imgPW = File.ReadAllBytes(Image);
                    cmd.Parameters.AddWithValue("@Image", imgPW);
                    //cmd.Parameters.AddWithValue("@PWImage_Name", PWImage_Name);
                    cmd.Parameters.AddWithValue("@EXT", EXT);

                }
                else if (Image == "Not Required")
                {
                    return;
                }

                else
                {
                    PWImage_Name = "";
                    EXT = "";
                    cmd.Parameters.AddWithValue("@Image", SqlDbType.Image).Value = imgPW;
                    cmd.Parameters.AddWithValue("@PDF_Name", PWImage_Name);
                    cmd.Parameters.AddWithValue("@EXT", EXT);

                }
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteWorkExp(int SNO)
        {
            con.Open();
            string sql = "delete from tblEmpJobExperience  where SNO=@SNO";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SNO", SNO);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteLeavemanagement(int pid)
        {
            con.Open();
            string sql = "delete from Tbl_Emp_Leave  where pid=@pid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable getCeaphistory(int pid)
        {
            try
            {

                string sql = "select * from Tbl_WorkingHistory_Ceapred where pid=@pid order by CPID desc";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@pid", pid);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insertceapworkHistory(int pid, int ProjectDistrict_Id, string ProjectDistrict_Name, int Project_Id, string Project_Name, int Designation_Id, string Designation_Name, string From_Date, string To_Date, string Salaries, int ImmediateSupervisor_Id, string ImmediateSupervisor_Name, string Reason_Leaving)
        {
            con.Open();
            string sql = "insert into Tbl_WorkingHistory_Ceapred (Pid,ProjectDistrict_Id,ProjectDistrict_Name,Project_Id,Project_Name,Designation_Id,Designation_Name,From_Date,To_Date,Salaries,ImmediateSupervisor_Id,ImmediateSupervisor_Name,Reason_Leaving) values(@Pid,@ProjectDistrict_Id,@ProjectDistrict_Name,@Project_Id,@Project_Name,@Designation_Id,@Designation_Name,@From_Date,@To_Date,@Salaries,@ImmediateSupervisor_Id,@ImmediateSupervisor_Name,@Reason_Leaving)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@ProjectDistrict_Id", ProjectDistrict_Id);
            cmd.Parameters.AddWithValue("@ProjectDistrict_Name", ProjectDistrict_Name);
            cmd.Parameters.AddWithValue("@Project_Id", Project_Id);
            cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
            cmd.Parameters.AddWithValue("@Designation_Id", Designation_Id);
            cmd.Parameters.AddWithValue("@Designation_Name", Designation_Name);
            cmd.Parameters.AddWithValue("@From_Date", From_Date);
            cmd.Parameters.AddWithValue("@To_Date", To_Date);
            cmd.Parameters.AddWithValue("@Salaries", Salaries);
            cmd.Parameters.AddWithValue("@ImmediateSupervisor_Id", ImmediateSupervisor_Id);
            cmd.Parameters.AddWithValue("@ImmediateSupervisor_Name", ImmediateSupervisor_Name);
            cmd.Parameters.AddWithValue("@Reason_Leaving", Reason_Leaving);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        //public void updateceapworkHistory(int ProjectDistrict_Id, string ProjectDistrict_Name, int Project_Id, string Project_Name, int Designation_Id, string Designation_Name, string From_Date, string To_Date, string Salaries, int ImmediateSupervisor_Id, string ImmediateSupervisor_Name, string Reason_Leaving, int pid)
        //{
        //    con.Open();
        //    string sql = "update Tbl_WorkingHistory_Ceapred  set ProjectDistrict_Id=@ProjectDistrict_Id,ProjectDistrict_Name=@ProjectDistrict_Name,Project_Id=@Project_Id,Project_Name=@Project_Name,Designation_Id=@Designation_Id,Designation_Name=@Designation_Name,From_Date=@From_Date,To_Date=@To_Date,Salaries=@Salaries,ImmediateSupervisor_Id=@ImmediateSupervisor_Id,ImmediateSupervisor_Name=@ImmediateSupervisor_Name,Reason_Leaving=@Reason_Leaving where pid=@pid ";
        //    SqlCommand cmd = new SqlCommand(sql, con);
           
        //    cmd.Parameters.AddWithValue("@ProjectDistrict_Id", ProjectDistrict_Id);
        //    cmd.Parameters.AddWithValue("@ProjectDistrict_Name", ProjectDistrict_Name);
        //    cmd.Parameters.AddWithValue("@Project_Id", Project_Id);
        //    cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
        //    cmd.Parameters.AddWithValue("@Designation_Id", Designation_Id);
        //    cmd.Parameters.AddWithValue("@Designation_Name", Designation_Name);
        //    cmd.Parameters.AddWithValue("@From_Date", From_Date);
        //    cmd.Parameters.AddWithValue("@To_Date", To_Date);
        //    cmd.Parameters.AddWithValue("@Salaries", Salaries);
        //    cmd.Parameters.AddWithValue("@ImmediateSupervisor_Id", ImmediateSupervisor_Id);
        //    cmd.Parameters.AddWithValue("@ImmediateSupervisor_Name", ImmediateSupervisor_Name);
        //    cmd.Parameters.AddWithValue("@Reason_Leaving", Reason_Leaving);
        //    cmd.Parameters.AddWithValue("@pid", pid);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        public void deleteceaphist(int pid)
        {
            con.Open();
            string sql = "delete from Tbl_WorkingHistory_Ceapred  where pid=@pid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void insertLeaveManagement(int PID, int Leaveid, int Days, int MaxDays)
        {
            con.Open();
            string sql = "Proc_Insert_Tbl_Emp_Leave";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", Leaveid);
            cmd.Parameters.AddWithValue("@Days", Days);
            cmd.Parameters.AddWithValue("@MaxDays", MaxDays);
            cmd.ExecuteNonQuery();
            con.Close();
        }
     
        public void CreateOfcInfo(DateTime date, string EMP_ID, string PID)
        {
            con.Open();
            string sql = "Proc_Insert_Tbl_DBID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@PID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable GetEmpbyId(int empid)
        {

            string sql = "select *from view_emp_info where EMP_ID=@empid";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@empid", empid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void CreateLeaveMgmt(int LEAVE_ID, int Days, int MaxDays, int PID)
        {
            con.Open();
            string sql = "Proc_Insert_Tbl_Emp_Leave";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@Days", Days);
            cmd.Parameters.AddWithValue("@MaxDays", MaxDays);
            cmd.Parameters.AddWithValue("@PID", PID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable GetEmpbyName(string EMP_FIRSTNAME)
        {
            string sql = "select *from  view_emp_info where EMP_FIRSTNAME=@EMP_FIRSTNAME";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@EMP_FIRSTNAME", EMP_FIRSTNAME);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //public DataTable getProjectAssignHistory()
        //{
        //    string sql = "Select * from Tbl_Project_AssignHistory";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        public void insertProjectAssign(string Designation_Id, DateTime Start_Date, DateTime End_Date, string Salaries, string Immediate_Supervisor, string Project_Id, string Designation_Name, string Project_Name)
        {
            con.Open();
            string sql = "insert into Tbl_Project_AssignHistory (Designation_Id,Start_Date,End_Date,Salaries,Immediate_Supervisor,Project_Id,Designation_Name,Project_Name) values(@Designation_Id,@Start_Date,@End_Date,@Salaries,@Immediate_Supervisor,@Project_Id,@Designation_Name,@Project_Name)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Designation_Id", Designation_Id);
            cmd.Parameters.AddWithValue("@Start_Date", Start_Date);
            cmd.Parameters.AddWithValue("@End_Date", End_Date);
            cmd.Parameters.AddWithValue("@Salaries", Convert.ToDouble(Salaries));
            cmd.Parameters.AddWithValue("@Immediate_Supervisor", Immediate_Supervisor);
            cmd.Parameters.AddWithValue("@Project_Id", Project_Id);
            cmd.Parameters.AddWithValue("@Designation_Name", Designation_Name);
            cmd.Parameters.AddWithValue("@Project_Name", Project_Name);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //*************** Attendance Management **************//
        //public DataTable getempemail(string emp_Fullname)
        //{
        //    string sql = "select * from view_emp_info where emp_Fullname = @emp_Fullname";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    cmd.Parameters.AddWithValue("@emp_Fullname", emp_Fullname);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        
        public DataTable getLeaveApplication()
        {
            string sql = "select * from Tbl_Org_leave_log";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getLeaveApplicationList()
        {
            string sql = "select Tbl_org_Leave_Approval_Log.*,Tbl_Org_Leave_Info.LEAVE_NAME, dbo. fn_Getempname(Tbl_org_Leave_Approval_Log.EMP_ID) as EmpName ,dbo. fn_Getempname(Tbl_org_Leave_Approval_Log.ApprovedBy)as ApprovedName from Tbl_org_Leave_Approval_Log inner join Tbl_Org_Leave_Info on Tbl_org_Leave_Approval_Log.LEAVE_ID=Tbl_Org_Leave_Info.LEAVE_ID where Tbl_org_Leave_Approval_Log.status = 1 and Leave_Date is not null";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int updateLeaveApplication(int status, int SNo)
        {
            string sql = "update Tbl_org_Leave_Approval_Log set status = @status  where SNo=@SNo";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SNo", SNo);
            cmd.Parameters.AddWithValue("@status", status);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable getLeaveDate(int EMP_ID)
        {
            string sql = "select Leave_Date from tbl_org_leave_log where EMP_ID = @EMP_ID and Leave_Date is not null";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void CreateLeaveApplication(DateTime DATE, string EMP_ID, int LEAVE_ID, string TAKEN, string REMARKS, string Senior_EMP_ID, string DAYPART, string LEAVETYPE, int status)
        {
            con.Open();
            string sql = "Proc_Insert_Tbl_Org_Leave_Log";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DATE", DATE);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@TAKEN", TAKEN);
            cmd.Parameters.AddWithValue("@REMARKS", REMARKS);
            cmd.Parameters.AddWithValue("@Senior_EMP_ID", Senior_EMP_ID);
            cmd.Parameters.AddWithValue("@DAYPART", DAYPART);
            cmd.Parameters.AddWithValue("@LEAVETYPE", LEAVETYPE);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void LeaveApplicationApproval(DateTime DATE, string EMP_ID, int LEAVE_ID, string TAKEN, string REMARKS, string Senior_EMP_ID, string DAYPART, string LEAVETYPE, int status)
        {
            con.Open();
            string sql = "Proc_Insert_Tbl_Org_Leave_Approval_Log";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DATE", DATE);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@TAKEN", TAKEN);
            cmd.Parameters.AddWithValue("@REMARKS", REMARKS);
            cmd.Parameters.AddWithValue("@Senior_EMP_ID", Senior_EMP_ID);
            cmd.Parameters.AddWithValue("@DAYPART", DAYPART);
            cmd.Parameters.AddWithValue("@LEAVETYPE", LEAVETYPE);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //public void LeaveApplication(DateTime DATE, string EMP_ID, int LEAVE_ID, string TAKEN, string REMARKS, string Senior_EMP_ID, string DAYPART, string LEAVETYPE, int STATUS)
        //{
        //    con.Open();
        //    string sql = "Proc_Insert_Tbl_Org_Leave_Log";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@DATE", DATE);
        //    cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
        //    cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
        //    cmd.Parameters.AddWithValue("@TAKEN", TAKEN);
        //    cmd.Parameters.AddWithValue("@REMARKS", REMARKS);
        //    cmd.Parameters.AddWithValue("@Senior_EMP_ID", Senior_EMP_ID);
        //    cmd.Parameters.AddWithValue("@DAYPART", DAYPART);
        //    cmd.Parameters.AddWithValue("@LEAVETYPE", LEAVETYPE);
        //    cmd.Parameters.AddWithValue("@STATUS", STATUS);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        public void ForceAttendance(string EMP_ID, DateTime TDATE, string INTIME, string INREMARKS, string INMODE, DateTime TDATE_OUT, string OUTTIME, string OUTMODE, string OUTREMARKS, int flag, int manualin, int manualout)
        {
            con.Open();
            string sql = "Proc_Manage_EMP_Attn";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@TDATE", TDATE);
            cmd.Parameters.AddWithValue("@INTIME", INTIME);
            cmd.Parameters.AddWithValue("@INREMARKS", INREMARKS);
            cmd.Parameters.AddWithValue("@INMODE", INMODE);
            cmd.Parameters.AddWithValue("@TDATE_OUT", TDATE_OUT);
            cmd.Parameters.AddWithValue("@OUTTIME", OUTTIME);
            cmd.Parameters.AddWithValue("@OUTMODE", OUTMODE);
            cmd.Parameters.AddWithValue("@OUTREMARKS", OUTREMARKS);
            cmd.Parameters.AddWithValue("@flag", flag);
            cmd.Parameters.AddWithValue("@manualin", 0);
            cmd.Parameters.AddWithValue("@manualout", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable getoutTime_ForceAttn(int EMP_ID, DateTime LogDate/*, int InOutMode*/)
        {
            string sql = "select * from  Tbl_DeviceAttenLog  where Emp_ID=@Emp_ID and LogDate=@LogDate   order by LogTime desc ";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@LogDate", LogDate);
           // cmd.Parameters.AddWithValue("@InOutMode", InOutMode);
          
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable proc_AllDepartment(DateTime date, string branch, string time, int mode)
        {
            string sql = "proc_AllDepartment";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@branch", branch);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@mode", mode);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable proc_forcebatch(DateTime date, string branch, string department, string time, int mode)
        {
            string sql = "proc_forcebatch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@branch", branch);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@mode", mode);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Proc_Get_Default_Time(int EMP_ID, DateTime date)
        {
            string sql = "Proc_Get_Default_Time";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@date", date);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int proc_Getworkid(int empid, DateTime date, string time, string remark, int mode)
        {
            con.Open();
            string sql = "proc_Getworkid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@remark", remark);
            cmd.Parameters.AddWithValue("@mode", mode);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable getMonthList()
        {
            string sql = "select MONTH_ID,MONTH_NAME from Tbl_english_month";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable proc_LeaveShow(int empid, int year, int month, int date_type)
        {
            con.Open();
            string sql = "proc_LeaveShow";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@date_type", date_type);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void deleterow(int SNo)
        {
            string sql = "Delete from tbl_org_leave_log where SNo=@SNo";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SNo", SNo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void CreateForceLeaveAssign(int ActionFlag, int SNo, int LEAVE_ID, decimal GIVEN, int GIVENMONTH, int GIVENYEAR, int APPROVEDBY, string IsOpening, int EMP_ID)
        {
            con.Open();
            string sql = "Proc_Manage_Opening_Leave";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActionFlag", ActionFlag);
            cmd.Parameters.AddWithValue("@SNo", SNo);
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@GIVEN", GIVEN);
            cmd.Parameters.AddWithValue("@GIVENMONTH", GIVENMONTH);
            cmd.Parameters.AddWithValue("@GIVENYEAR", GIVENYEAR);
            cmd.Parameters.AddWithValue("@APPROVEDBY", APPROVEDBY);
            cmd.Parameters.AddWithValue("@IsOpening", IsOpening);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable getLeaveEmployeeList(int leaveid)
        {
            string sql = "select EMP_ID , emp_Fullname,Fullname from view_Emp_Info ve inner join tbl_emp_leave tel on ve.PID=tel.PID where tel.LEAVEID=@LEAVE_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@LEAVE_ID", leaveid);
          
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getNepaliMonthList()
        {
            string sql = "select MONTH_ID,MONTH_NAME from tbl_nepali_month";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getReligion()
        {
            string sql = "select * from Tbl_Org_Religion";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getSalutation()
        {
            string sql = "select * from tbl_emp_salutation";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getType()
        {
            string sql = "select * from Tbl_Emp_Type";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //************** Reports*******************//
        public DataTable getBranchList()
        {
            string sql = "select BRANCH_ID,BRANCH_NAME from Tbl_Comp_Branch where sta = 1 order by BRANCH_NAME asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getDepartmentList()
        {
            string sql = "select distinct DEPT_NAME, DEPT_ID from view_Emp_Info where  STATUS_ID = 1 ";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getDepartmentList(int BranchID)
        {
            string sql = "select distinct DEPT_ID, DEPT_NAME from view_Emp_Info where BRANCH_ID=@branch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@branch", BranchID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetEmployeeList(int BranchID)
        {
            string sql = "select emp_fullname, EMP_ID from view_Emp_Info where STATUS_ID = 1 and BRANCH_ID=@branch";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@branch", BranchID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getBranch_DepartmentList(int branch_id)
        {
            string sql = "select distinct DEPT_ID, DEPT_NAME from view_Emp_Info where STATUS_ID = 1 and BRANCH_ID=@branch order by DEPT_NAME ASC";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@branch", branch_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getDept_EmployeeList(int dept_id)
        {
            string sql = "select emp_fullname,EMP_ID from view_Emp_Info where DEPT_ID=@department order by emp_id asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@department", dept_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getDept_EmployeeList(int dept_id, int branch_id)
        {
            string sql = "select emp_fullname,EMP_ID from view_Emp_Info where DEPT_ID=@department and BRANCH_ID =@branch and STATUS_ID = 1 order by emp_id asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@department", dept_id);
            cmd.Parameters.AddWithValue("@branch", branch_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getAllInfo(int emp_id)
        {
            string sql = "select * from view_Emp_Info where EMP_ID=@EMP_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getEmployeebyAtten()
        {
            string sql = "select * from view_Emp_Info  where IsAttendance=1 order by EMP_ID asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable QuickAttnReport(int emp_id, DateTime date_from, DateTime date_to, int Aflag)
        {
            string sql = "proc_Atten_month_Report";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            cmd.Parameters.AddWithValue("@date_from", date_from);
            cmd.Parameters.AddWithValue("@date_to", date_to);
            cmd.Parameters.AddWithValue("@Aflag", Aflag);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getQuickAttendanceData()
        {
            string sql = "select * from rpt_attendance_data";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable Monthlyattendance(int EmpId, int br_id, int dept_id, DateTime date_from, DateTime date_to)
        {
            con.Open();
            string sql = "proc_emp_summary_WithOverTime";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            cmd.Parameters.AddWithValue("@br_id", br_id);
            cmd.Parameters.AddWithValue("@dept_id", dept_id);
            cmd.Parameters.AddWithValue("@from_date", date_from);
            cmd.Parameters.AddWithValue("@to_date", date_to);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LeaveTakenDetail(DateTime sdate, DateTime edate, int EMP_ID, int LEAVE_ID, int BRANCH_ID, int DEPT_ID)
        {
            con.Open();
            string sql = "Proc_leave_monthly_report ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@BRANCH_ID", BRANCH_ID);
            cmd.Parameters.AddWithValue("@DEPT_ID", DEPT_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getDatewiseData()
        {
            string sql = "select * from rpt_attendance_data_daywise";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
       
        public DataTable getleave_emp(int EMP_ID)
        {
            con.Open();
            string sql = "proc_load_leavename_emp";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }
        public DataTable getLeaveList()
        {
            string sql = "SELECT LEAVE_ID, LEAVE_NAME from Tbl_Org_Leave_Info where status = 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //public DataTable getLeave()
        //{
        //    string sql = "SELECT LEAVE_ID, LEAVE_NAME from Tbl_Org_Leave_Info";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        public DataTable proc_Pay_LeaveLog_web(int empid, int LvType)
        {
            con.Open();
            string sql = "proc_Pay_LeaveLog_web";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@LvType", LvType);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getEmployees()
        {
            string sql = "SELECT EMP_ID, emp_fullname,Fullname from view_emp_info";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getHODEmployees()
        {
            string sql = "SELECT distinct HOD_ID, HOD_NAME from view_emp_info";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getRooster(int emp_id, DateTime date)
        {
            string sql = "Proc_workHrs";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            cmd.Parameters.AddWithValue("@date", date);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LeaveInformation(int BRANCHID, int DEPTID, int EMPID)
        {
            con.Open();
            string sql = "proc_Pay_LeaveLog";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BRANCHID", BRANCHID);
            cmd.Parameters.AddWithValue("@DEPTID", DEPTID);
            cmd.Parameters.AddWithValue("@EMPID", EMPID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LeaveSummary(int EMP_ID, int LEAVE_ID, int FLAG)
        {
            con.Open();
            string sql = "proc_LeaveBalanceSummary";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@FLAG", FLAG);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetOutstationReport(int EMP_ID,DateTime Fromdate,DateTime Todate)
        {
            string sql;
            if(EMP_ID==0)
            {
                sql = "select *,dbo.fn_Getempname(Tbl_Emp_Outstation.emp_id) as emp_fullname, dbo.fn_Getempname(dbo.Tbl_Emp_Outstation.APPROVED_BY) as approver_name  from Tbl_Emp_Outstation WHERE SDATE between @Fromdate and @Todate order by SDATE desc";
            }
            else
            {
                sql = "select *,dbo.fn_Getempname(Tbl_Emp_Outstation.emp_id) as emp_fullname, dbo.fn_Getempname(dbo.Tbl_Emp_Outstation.APPROVED_BY) as approver_name  from Tbl_Emp_Outstation WHERE SDATE between @Fromdate and @Todate and EMP_ID=@EMP_ID order by SDATE desc";
            }
         
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
          
            cmd.Parameters.AddWithValue("@Fromdate", Fromdate);
            cmd.Parameters.AddWithValue("@Todate", Todate);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LeaveMonthlyreport(DateTime sdate, DateTime edate, int EMP_ID, int LEAVE_ID, int BRANCH_ID, int DEPT_ID)
        {
            con.Open();
            string sql = "Proc_leave_monthly_report";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            cmd.Parameters.AddWithValue("@LEAVE_ID", LEAVE_ID);
            cmd.Parameters.AddWithValue("@BRANCH_ID", BRANCH_ID);
            cmd.Parameters.AddWithValue("@DEPT_ID", DEPT_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Getstatus()
        {
            string sql = "select * from Tbl_stat  where STATUS_ID NOT IN (4)";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable EmployeeReport(int branch_id, int dept_id,string Retired_Date, int STATUS_ID)
        {
           // string sql = "select * from view_emp_info where STATUS_ID=@STATUS_ID order by emp_id asc";
            string sql = " select * from view_Emp_Info WHERE year(Retired_Date)=@Retired_Date and STATUS_ID=@STATUS_ID order by emp_id asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@branch_id", branch_id);
            cmd.Parameters.AddWithValue("@dept_id", dept_id);
            cmd.Parameters.AddWithValue("@Retired_Date", Retired_Date);
            cmd.Parameters.AddWithValue("@STATUS_ID", STATUS_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable EmployeeReportwithmonthly(int STATUS_ID,string fromdate,string todate)
        {
            string sql = "select * from view_Emp_Info where STATUS_ID =@STATUS_ID and Retired_Date between '" + fromdate + "' and '" + todate + "' order by emp_id asc";
           
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           
           // cmd.Parameters.AddWithValue("@Retired_Date", Retired_Date);
            cmd.Parameters.AddWithValue("@STATUS_ID", STATUS_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Gender_Project()
        {
            string sql = "select view_Emp_Info.BRANCH_ID, view_Emp_Info.BRANCH_NAME, sum(case when EMP_GENDER = 'M' then 1 else 0 end ) as Male, sum(case when EMP_GENDER = 'F' then 1 else 0 end ) as Female, count(*) as Total,convert(numeric(9,2), (sum(case when EMP_GENDER = 'M' then 1 else 0 end )*100.0/count(*))) as mpc, convert(numeric(9,2),(sum(case when EMP_GENDER = 'F' then 1 else 0 end )*100.0/count(*))) as fpc from view_Emp_Info inner join Tbl_Comp_Branch on view_Emp_Info.BRANCH_ID = Tbl_Comp_Branch.BRANCH_ID group by view_Emp_Info.BRANCH_NAME,view_Emp_Info.BRANCH_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.AddWithValue("@BRANCH_NAME", BRANCH_NAME);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
       
        public DataTable Position_ProjectReport()
        {
            string sql = "select view_Emp_Info.BRANCH_ID, view_Emp_Info.BRANCH_NAME,sum(case when GRADE_NAME = 'Manager' then 1 else 0 end ) as Manager, sum(case when GRADE_NAME = 'Officer' then 1 else 0 end ) as Officer,sum(case when GRADE_NAME = 'Assistant' then 1 else 0 end ) as Assistant,sum(case when GRADE_NAME = 'Support' then 1 else 0 end ) as Support, count(*) as Total from view_Emp_Info inner join Tbl_Comp_Branch on view_Emp_Info.BRANCH_ID = Tbl_Comp_Branch.BRANCH_ID group by view_Emp_Info.BRANCH_NAME,view_Emp_Info.BRANCH_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Gender_Ethnicity()
        {
            string sql = "select view_Emp_Info.Ethnicity_Id, view_Emp_Info.Ethnicity,sum(case when EMP_GENDER = 'M' then 1 else 0 end ) as Male, sum(case when EMP_GENDER = 'F' then 1 else 0 end ) as Female, count(*) as Total,convert(numeric(9,2),(sum(case when EMP_GENDER = 'M' then 1 else 0 end )*100.0/count(*))) as mpc,convert(numeric(9,2),(sum(case when EMP_GENDER = 'F' then 1 else 0 end )*100.0/count(*))) as fpc from view_Emp_Info inner join Tbl_emp_Ethnicity on view_Emp_Info.Ethnicity_Id = Tbl_emp_Ethnicity.Ethnicity_Id group by view_Emp_Info.Ethnicity,view_Emp_Info.Ethnicity_Id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Position_Gender()
        {
            string sql = "select view_Emp_Info.GRADE_ID, view_Emp_Info.GRADE_NAME,sum(case when EMP_GENDER = 'M' then 1 else 0 end ) as Male, sum(case when EMP_GENDER = 'F' then 1 else 0 end ) as Female, count(*) as Total, convert(numeric(9,2), (sum(case when EMP_GENDER = 'M' then 1 else 0 end )*100.0/count(*))) as mpc,convert(numeric(9,2),(sum(case when EMP_GENDER = 'F' then 1 else 0 end )*100.0/count(*))) as fpc from view_Emp_Info inner join Tbl_Org_Grade on view_Emp_Info.GRADE_ID = Tbl_Org_Grade.GRADE_ID group by view_Emp_Info.GRADE_NAME,view_Emp_Info.GRADE_ID";

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
      
        public DataTable Project_Position_Gender()
        {
            string sql = "select view_Emp_Info.BRANCH_ID,view_Emp_Info.BRANCH_NAME,sum(case when GRADE_NAME = 'Manager' and EMP_GENDER = 'M' then 1 else 0 end ) as ManagerMale,sum(case when GRADE_NAME = 'Manager' and EMP_GENDER = 'F' then 1 else 0 end ) as ManagerFemale,sum(case when GRADE_NAME = 'Officer' and EMP_GENDER = 'M' then 1 else 0 end ) as OfficerMale,sum(case when GRADE_NAME = 'Officer' and EMP_GENDER = 'F' then 1 else 0 end ) as OfficerFemale,sum(case when GRADE_NAME = 'Assistant' and EMP_GENDER = 'M' then 1 else 0 end ) as AssistantMale,sum(case when GRADE_NAME = 'Assistant' and EMP_GENDER = 'F' then 1 else 0 end ) as AssistantFemale,sum(case when GRADE_NAME = 'Support' and EMP_GENDER = 'M' then 1 else 0 end ) as SupportMale, sum(case when GRADE_NAME = 'Support' and EMP_GENDER = 'F' then 1 else 0 end ) as SupportFemale, (sum(case when EMP_GENDER = 'M' and GRADE_NAME = 'Manager' then 1 else 0 end ) + sum(case when EMP_GENDER = 'M' and GRADE_NAME = 'Officer' then 1 else 0 end )+ sum(case when EMP_GENDER = 'M' and GRADE_NAME = 'Assistant' then 1 else 0 end )+ sum(case when EMP_GENDER = 'M' and GRADE_NAME = 'Support' then 1 else 0 end )) as Maletotal,(sum(case when EMP_GENDER = 'F' and GRADE_NAME = 'Manager' then 1 else 0 end ) + sum(case when EMP_GENDER = 'F' and GRADE_NAME = 'Officer' then 1 else 0 end )+ sum(case when EMP_GENDER = 'F' and GRADE_NAME = 'Assistant' then 1 else 0 end )+ sum(case when EMP_GENDER = 'F' and GRADE_NAME = 'Support' then 1 else 0 end )) as Femaletotal from view_Emp_Info inner join Tbl_Comp_Branch on view_Emp_Info.BRANCH_ID = Tbl_Comp_Branch.BRANCH_ID group by view_Emp_Info.BRANCH_NAME, view_Emp_Info.BRANCH_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Gender_ProjectwithStatus(int STATUS_ID)
        {
            string sql = "select view_Emp_Info.BRANCH_ID, view_Emp_Info.BRANCH_NAME, sum(case when EMP_GENDER = 'M' and  STATUS_ID=@STATUS_ID then 1 else 0 end ) as Male, sum(case when EMP_GENDER = 'F' and STATUS_ID=@STATUS_ID then 1 else 0 end ) as Female, (sum(case when EMP_GENDER = 'M' and STATUS_ID=@STATUS_ID then 1 else 0 end ) + sum(case when EMP_GENDER = 'F' and STATUS_ID=@STATUS_ID then 1 else 0 end ))as Total, convert(numeric(9,2),(sum(case when EMP_GENDER = 'M' and STATUS_ID=@STATUS_ID then 1 else 0 end )*100.0/count(*))) as mpc, convert(numeric(9,2),(sum(case when EMP_GENDER = 'F' and STATUS_ID=@STATUS_ID then 1 else 0 end )*100.0/count(*))) as fpc from view_Emp_Info inner join Tbl_Comp_Branch on view_Emp_Info.BRANCH_ID = Tbl_Comp_Branch.BRANCH_ID group by view_Emp_Info.BRANCH_NAME,view_Emp_Info.BRANCH_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@STATUS_ID", STATUS_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Position_ProjectwithStatus(int STATUS_ID)
        {
            string sql = "select view_Emp_Info.BRANCH_ID, view_Emp_Info.BRANCH_NAME,sum(case when GRADE_NAME = 'Manager' and STATUS_ID=@STATUS_ID then 1 else 0 end ) as Manager, sum(case when GRADE_NAME = 'Officer' and STATUS_ID=@STATUS_ID then 1 else 0 end ) as Officer,sum(case when GRADE_NAME = 'Assistant' and STATUS_ID=@STATUS_ID then 1 else 0 end ) as Assistant,sum(case when GRADE_NAME = 'Support' and STATUS_ID=@STATUS_ID then 1 else 0 end ) as Support, (sum(case when GRADE_NAME = 'Manager' and STATUS_ID=@STATUS_ID then 1 else 0 end ) + sum(case when GRADE_NAME = 'Officer' and STATUS_ID=@STATUS_ID then 1 else 0 end ) + sum(case when GRADE_NAME = 'Assistant' and STATUS_ID=@STATUS_ID then 1 else 0 end ) + sum(case when GRADE_NAME = 'Support' and STATUS_ID=@STATUS_ID then 1 else 0 end )) as Total from view_Emp_Info inner join Tbl_Comp_Branch on view_Emp_Info.BRANCH_ID = Tbl_Comp_Branch.BRANCH_ID group by view_Emp_Info.BRANCH_NAME,view_Emp_Info.BRANCH_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@STATUS_ID", STATUS_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Gender_EthnicitywithStatus(int STATUS_ID)
        {
            string sql = "select view_Emp_Info.Ethnicity_Id, view_Emp_Info.Ethnicity,sum(case when EMP_GENDER = 'M' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as Male, sum(case when EMP_GENDER = 'F' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as Female, (sum(case when EMP_GENDER = 'M' and STATUS_ID =@STATUS_ID then 1 else 0 end ) + sum(case when EMP_GENDER = 'F' and STATUS_ID =@STATUS_ID then 1 else 0 end )) as Total,convert(numeric(9,2),(sum(case when EMP_GENDER = 'M' and STATUS_ID =@STATUS_ID then 1 else 0 end )*100.0/count(*))) as mpc,convert(numeric(9,2),(sum(case when EMP_GENDER = 'F' and STATUS_ID =@STATUS_ID then 1 else 0 end )*100.0/count(*))) as fpc from view_Emp_Info inner join Tbl_emp_Ethnicity on view_Emp_Info.Ethnicity_Id = Tbl_emp_Ethnicity.Ethnicity_Id group by view_Emp_Info.Ethnicity,view_Emp_Info.Ethnicity_Id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@STATUS_ID", STATUS_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Position_GenderwithStatus(int STATUS_ID)
        {
            string sql = "select view_Emp_Info.GRADE_ID, view_Emp_Info.GRADE_NAME,sum(case when EMP_GENDER = 'M' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as Male, sum(case when EMP_GENDER = 'F' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as Female, (sum(case when EMP_GENDER = 'M' and STATUS_ID =@STATUS_ID then 1 else 0 end ) + sum(case when EMP_GENDER = 'F' and STATUS_ID =@STATUS_ID then 1 else 0 end )) as Total, convert(numeric(9,2), (sum(case when EMP_GENDER = 'M' and STATUS_ID =@STATUS_ID then 1 else 0 end )*100.0/count(*))) as mpc,convert(numeric(9,2),(sum(case when EMP_GENDER = 'F' and STATUS_ID =@STATUS_ID then 1 else 0 end )*100.0/count(*))) as fpc from view_Emp_Info inner join Tbl_Org_Grade on view_Emp_Info.GRADE_ID = Tbl_Org_Grade.GRADE_ID group by view_Emp_Info.GRADE_NAME,view_Emp_Info.GRADE_ID";

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@STATUS_ID", STATUS_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //public DataTable Project_Position_GenderwithStatus(int STATUS_ID)
        //{
        //    string sql = "SELECT  einfo.branch_name,einfo.GRADE_NAME,einfo.GENDER, count(einfo.emp_id) as totalemp FROM dbo.view_emp_info einfo where einfo.STATUS_ID =@STATUS_ID group by einfo.branch_name,einfo.GRADE_NAME,einfo.GENDER";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    cmd.Parameters.AddWithValue("@STATUS_ID", STATUS_ID);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}

        public DataTable Project_Position_GenderwithStatus(int STATUS_ID)
        {
            string sql = "select view_Emp_Info.BRANCH_ID, view_Emp_Info.BRANCH_NAME,sum(case when GRADE_NAME = 'Manager' and EMP_GENDER = 'M' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as ManagerMale,sum(case when GRADE_NAME = 'Manager' and EMP_GENDER = 'F' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as ManagerFemale,sum(case when GRADE_NAME = 'Officer' and EMP_GENDER = 'M' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as OfficerMale,sum(case when GRADE_NAME = 'Officer' and EMP_GENDER = 'F' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as OfficerFemale,sum(case when GRADE_NAME = 'Assistant' and EMP_GENDER = 'M' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as AssistantMale,sum(case when GRADE_NAME = 'Assistant' and EMP_GENDER = 'F' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as AssistantFemale,sum(case when GRADE_NAME = 'Support' and EMP_GENDER = 'M' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as SupportMale, sum(case when GRADE_NAME = 'Support' and EMP_GENDER = 'F' and STATUS_ID =@STATUS_ID then 1 else 0 end ) as SupportFemale, (sum(case when EMP_GENDER = 'M' and GRADE_NAME = 'Manager' and STATUS_ID =@STATUS_ID then 1 else 0 end ) + sum(case when EMP_GENDER = 'M' and GRADE_NAME = 'Officer' and STATUS_ID =@STATUS_ID then 1 else 0 end )+ sum(case when EMP_GENDER = 'M' and GRADE_NAME = 'Assistant' and STATUS_ID =@STATUS_ID then 1 else 0 end )+ sum(case when EMP_GENDER = 'M' and GRADE_NAME = 'Support' and STATUS_ID =@STATUS_ID then 1 else 0 end )) as Maletotal,(sum(case when EMP_GENDER = 'F' and GRADE_NAME = 'Manager' and STATUS_ID =@STATUS_ID then 1 else 0 end ) + sum(case when EMP_GENDER = 'F' and GRADE_NAME = 'Officer' and STATUS_ID =@STATUS_ID then 1 else 0 end )+ sum(case when EMP_GENDER = 'F' and GRADE_NAME = 'Assistant' and STATUS_ID =@STATUS_ID then 1 else 0 end )+ sum(case when EMP_GENDER = 'F' and GRADE_NAME = 'Support' and STATUS_ID =@STATUS_ID then 1 else 0 end )) as Femaletotal from view_Emp_Info inner join Tbl_Comp_Branch on view_Emp_Info.BRANCH_ID = Tbl_Comp_Branch.BRANCH_ID group by view_Emp_Info.BRANCH_NAME, view_Emp_Info.BRANCH_ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@STATUS_ID", STATUS_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable EmployeesListwithStatus(int STATUS_ID)
        {
            try
            {

                string sql = "select * from view_emp_info where STATUS_ID=@STATUS_ID order by EMP_ID asc";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@STATUS_ID", STATUS_ID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ResignedYearlyReport(string Retired_Date)
        {
            string sql = "select * from view_Emp_Info WHERE year(Retired_Date)=@Retired_Date order by emp_id asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Retired_Date", Retired_Date);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable workingemployeeReport(int STATUS_ID)
        {
            string sql = "select * from view_Emp_Info WHERE STATUS_ID=1 order by emp_id asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@STATUS_ID", STATUS_ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getTransferReport(int Branch_ID_To, string TDATE)
        {
            string sql = "select * from view_emp_transfer_details WHERE year(TDATE)=@TDATE and Branch_ID_To=@Branch_ID_To order by emp_id asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Branch_ID_To", Branch_ID_To);
            cmd.Parameters.AddWithValue("@TDATE", TDATE);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getPromotionReport(int CurrentProject_Id, string TDATE)
        {
            string sql = "select * from view_emp_promotion_details WHERE year(TDATE)=@TDATE and CurrentProject_Id=@CurrentProject_Id order by emp_id asc";
           
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@CurrentProject_Id", CurrentProject_Id);
            cmd.Parameters.AddWithValue("@TDATE", TDATE);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getTransfer()
        {
            string sql = "select * from tbl_Emp_Transfer_Detail order by emp_id asc";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //Datewise Report
        public DataTable DatewiseAttendance(int emp_id, DateTime date_from, DateTime date_to, int Aflag)
        {
            con.Open();
            string sql = "proc_Datewise_Report";
            SqlCommand cmd1 = new SqlCommand(sql, con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@emp_id", emp_id);
            cmd1.Parameters.AddWithValue("@date_from", date_from);
            cmd1.Parameters.AddWithValue("@date_to", date_to);
            cmd1.Parameters.AddWithValue("@Aflag", Aflag);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable DatewiseAttendanceReport()
        {
            string sql = "select * from rpt_attendance_data_Monthly";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //OverTimeSummary
        public DataTable OverTimeSummary(int EID, DateTime DT1, DateTime DT2, int FLG, int branch_id, int dept_id)
        {
            con.Open();
            string sql = "proc_OverTime_Monthly";
            SqlCommand cmd1 = new SqlCommand(sql, con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@EID", EID);
            cmd1.Parameters.AddWithValue("@DT1", DT1);
            cmd1.Parameters.AddWithValue("@DT2", DT2);
            cmd1.Parameters.AddWithValue("@FLG", FLG);
            cmd1.Parameters.AddWithValue("@branch", branch_id);
            cmd1.Parameters.AddWithValue("@dept", dept_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable DailyAbsent(string branch, string department, DateTime date)
        {
            con.Open();
            string sql = "proc_report_Daily_Absent";
            SqlCommand cmd1 = new SqlCommand(sql, con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@branch", branch);
            cmd1.Parameters.AddWithValue("@department", department);
            cmd1.Parameters.AddWithValue("@date", date);
            // cmd1.Parameters.AddWithValue("@emp_id", emp_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable EmployeeDetailInformation(int emp_id)
        {
            string sql = "select * from view_emp_info where EMP_ID=@emp_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Report_LateAttendance(int branch, int department, DateTime date_from, DateTime date_to, int condition)
        {
            con.Open();
            string sql = "proc_late_Record";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@branch", branch);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@date_from", date_from);
            cmd.Parameters.AddWithValue("@date_to", date_to);
            cmd.Parameters.AddWithValue("@condition", condition);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //Rooster Shift Report
        public void Report_RoosterShift(DateTime startdate, DateTime tilldate, int empid, int flag)
        {
            string sql = "proc_rptRosterShiftInfo";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@startdate", startdate);
            cmd.Parameters.AddWithValue("@tilldate", tilldate);
            cmd.Parameters.AddWithValue("@empid", empid);
            cmd.Parameters.AddWithValue("@flag", flag);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable Report_Promotion(DateTime sdate, DateTime edate, int branch_id, int dept_id, int EMP_ID)
        {
            string sql = "proc_Promotion_report";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@branch_id", branch_id);
            cmd.Parameters.AddWithValue("@dept_id", dept_id);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Report_Transfer(DateTime sdate, DateTime edate, int EMP_ID)
        {
            string sql = "proc_transfer_report";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", sdate);
            cmd.Parameters.AddWithValue("@edate", edate);
            cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void shiftChange(DateTime tdate, int emp_id, int approver_id, int prev_rooser_id, DateTime rooster_date, int current_rooster_id, int status, int session_id, int flag)
        {
            string sql = "Org_ShiftChange";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tdate", tdate);
            cmd.Parameters.AddWithValue("@emp_id", emp_id);
            cmd.Parameters.AddWithValue("@approver_id", approver_id);
            cmd.Parameters.AddWithValue("@prev_rooster_id", prev_rooser_id);
            cmd.Parameters.AddWithValue("@rooster_date", rooster_date);
            cmd.Parameters.AddWithValue("@current_rooster_id", current_rooster_id);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@session_id", session_id);
            cmd.Parameters.AddWithValue("@flag", flag);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable GetRoosterData()
        {
            string sql = "select * from tbl_rptRosterShift";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //public DataTable getEvent()
        //{
        //    string sql = "select * from Tbl_Org_Event";
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}

        public DataTable getEvents(int flag)
        {
            if (flag == 1)
            {
                DateTime tdate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                string sql = "Select * from Tbl_Org_event where Date >= @tdate order by Date";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@tdate", tdate);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            else
            {
                string sql = "Select * from Tbl_Org_event order by Date";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

        public int CreateEvent(string Title, string Description, DateTime Date)
        {
            con.Open();
            string sql = "insert into Tbl_Org_Event (Title,Description,Date) values(@Title,@Description,@Date)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Date", Date);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataTable GetEventbyId(int eventid)
        {

            string sql = "select *from Tbl_Org_Event where EventId=@eventid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@eventid", eventid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void UpdateEvent(string Title, string Description, DateTime Date, int eventid)
        {

            con.Open();
            string sql = "update Tbl_Org_Event set Title=@Title, Description=@Description,Date=@Date where EventId=@eventid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@eventid", eventid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void CreateOutStation(int VNO, int EMP_ID, DateTime TDATE, int DEPARTMENTID, int DESIGNATIONID, string STATION, DateTime SDATE, DateTime EDATE, int DAYS, string PURPOSE, int APPROVED_BY, int status)
        {
            con.Open();
            string sql = "proc_insert_emp_outstation";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VNO", VNO);
            cmd.Parameters.AddWithValue("@EMPID", EMP_ID);
            //cmd.Parameters.AddWithValue("@TDATE", TDATE);
            cmd.Parameters.AddWithValue("@DEPARTMENTID", DEPARTMENTID);
            cmd.Parameters.AddWithValue("@DESIGNATIONID", DESIGNATIONID);
            cmd.Parameters.AddWithValue("@STATION", STATION);
            cmd.Parameters.AddWithValue("@SDATE", SDATE);
            cmd.Parameters.AddWithValue("@EDATE", EDATE);
            cmd.Parameters.AddWithValue("@DAYS", DAYS);
            cmd.Parameters.AddWithValue("@PURPOSE", PURPOSE);
            cmd.Parameters.AddWithValue("@APPROVED_BY", APPROVED_BY);
            //cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void CreateoutstationAttendance(int EMP_ID, DateTime SDATE, DateTime EDATE, string location, int VNO, string PURPOSE)
        {
            con.Open();
            string sql = "proc_outstation_atten";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", EMP_ID);
            cmd.Parameters.AddWithValue("@date_from", SDATE);
            cmd.Parameters.AddWithValue("@date_to", EDATE);
            cmd.Parameters.AddWithValue("@travelid", VNO);
            cmd.Parameters.AddWithValue("@remarks", location);
            cmd.Parameters.AddWithValue("@PURPOSE", PURPOSE);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable GetOutstation()
        {

            string sql = "SELECT *,emp_Fullname FROM Tbl_Emp_Outstation LEFT JOIN view_Emp_Info ON Tbl_Emp_Outstation.EMP_ID = view_Emp_Info.EMP_ID order by SDATE desc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetOutstationbyId(int VNO)
        {

            string sql = "select *from Tbl_Emp_Outstation where VNO=@VNO";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@VNO", VNO);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //public void UpdateOutstation(int EMP_ID, DateTime TDATE, int DEPARTMENTID, int DESIGNATIONID, string STATION, DateTime SDATE, DateTime EDATE, int DAYS, string PURPOSE, int APPROVED_BY, int status, int VNO)
        //{
        //    try
        //    {
        //        con.Open();
        //        string sql = "update Tbl_Emp_Outstation set EMP_ID=@EMP_ID, TDATE=@TDATE, DEPARTMENTID=@DEPARTMENTID,DESIGNATIONID=@DESIGNATIONID,STATION=@STATION,SDATE=@SDATE,EDATE=@EDATE,DAYS=@DAYS,PURPOSE=@PURPOSE,APPROVED_BY=@APPROVED_BY,status=@status where VNO=@VNO";
        //        SqlCommand cmd = new SqlCommand(sql, con);
        //        cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
        //        cmd.Parameters.AddWithValue("@TDATE", TDATE);
        //        cmd.Parameters.AddWithValue("@DEPARTMENTID", DEPARTMENTID);
        //        cmd.Parameters.AddWithValue("@DESIGNATIONID", DESIGNATIONID);
        //        cmd.Parameters.AddWithValue("@STATION", STATION);
        //        cmd.Parameters.AddWithValue("@SDATE", SDATE);
        //        cmd.Parameters.AddWithValue("@EDATE", EDATE);
        //        cmd.Parameters.AddWithValue("@DAYS", DAYS);
        //        cmd.Parameters.AddWithValue("@PURPOSE", PURPOSE);
        //        cmd.Parameters.AddWithValue("@APPROVED_BY", APPROVED_BY);
        //        cmd.Parameters.AddWithValue("@status", status);
        //        cmd.Parameters.AddWithValue("@VNO", VNO);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}