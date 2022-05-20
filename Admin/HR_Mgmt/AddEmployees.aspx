<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostBack="true"  MasterPageFile="~/Admin/HR_Mgmt/HR.Master" AutoEventWireup="true" CodeBehind="AddEmployees.aspx.cs" Inherits="AttendanceKantipur.Admin.HR_Mgmt.AddEmployees" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
       <div class="content">
    <div class="container">
        <div class="row">
			<div class="col-xs-12">
				<div class="page-title-box">
                    <h4 class="page-title">HR Management </h4>
                    <ol class="breadcrumb p-0 m-0">
                        <li>
                            <a href="../Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>
                            <a href="Employees.aspx">Employees  List</a>
                        </li>
                        <li class="active">
                            Add Employees
                        </li>
                    </ol>
                    <div class="clearfix"></div>
                </div>
			</div>
		</div>
        <!-- end row -->
        <div class="row">
            <div class="col-md-12">
                <div class="card-box">
				    <form id="form1" class="form-horizontal" runat="server">
                          <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
                               
                                <h3 class="panel-title" style="color: red;">* Denotes Mandatory Fields</h3>
                                <div class="well">
                                    <h3 style="color:darkblue;">1. Personal Information</h3>
                                     <div class="form-group">
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtpid" Visible="false" runat="server"></asp:TextBox>
                                        </div>                                      
                                        <div class="col-md-3 pull-right">  
                                                    <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>                            
                                                    <asp:Image ID="Image1" class="blah"  runat="server" style="height: 150px; width: 150px ;border-style: ridge; border-width: 5px ;" src="http://avighnatechnology.com/images/dummyselect.jpg"/> 
                                                <asp:FileUpload ID="FileUpload1"  onchange="readURL(this);"  runat="server" Height="22px" accept=".png,.jpg,.jpeg,.gif" /><br /> 
                                   
                                        </div>                                       
                                    </div>
                                    
                                     <div class="form-group">                                          
                                          <div class="col-md-14">
                                            <label class="control-label col-md-5">Staff ID <span style="color:red">*</span></label>
                                            <div class="col-md-1">
                                                <asp:TextBox ID="txtEmployeeId" CssClass="form-control" runat="server" OnTextChanged="txtEmployeeId_TextChanged"></asp:TextBox>
                                            </div> 
                                              </div>                                                      
                                        </div>
                               
                                     <div class="form-group">
                                            <label class="control-label col-md-2">Full Name <span style="color:red">*</span></label>
                                            <div class="col-md-2">
                                                <asp:DropDownList ID="EMP_TITLE" CssClass="form-control" runat="server">
                                                    <asp:ListItem Enabled="true" Text="Select" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                                    <asp:ListItem Text="Ms." Value="Ms."></asp:ListItem>
                                                    <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                                     <asp:ListItem Text="Dr." Value="Dr."></asp:ListItem>
                                                       <asp:ListItem Text="Er." Value="Er."></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="EMP_FIRSTNAME" CssClass="form-control" placeholder="FIRSTNAME" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="EMP_MIDDLENAME" CssClass="form-control" placeholder="MIDDLENAME"  runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="EMP_LASTNAME" CssClass="form-control" placeholder="LASTNAME" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                     <div class="form-group">
                                            <label class="control-label col-md-2"> DOB <span style="color:red">*</span></label>
                                            <div class="col-md-2">
                                                    <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate1" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtStartDate"  CssClass="form-control englishDate1" AutoComplete="off" placeholder="English Date"  runat="server"></asp:TextBox>
                                            </div>
                                    
                                            <label class="control-label col-md-2">First Join Date <span style="color:red">*</span></label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtjoin" CssClass="form-control nepaliDate2" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">
                                               <asp:TextBox ID="txtJoindate"  CssClass="form-control englishDate2" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                     <div class="form-group">
                                          <label class="control-label col-md-2"> Sex <span style="color:red">*</span></label>
                                            <div class="col-md-3">
                                                <asp:RadioButton GroupName="Gender" ID="Gender1"  value="F" runat="server" /> Female
                                                <asp:RadioButton GroupName="Gender" ID="Gender2" Checked="true" value="M" runat="server" /> Male
                                                <asp:RadioButton GroupName="Gender" ID="Gender3"  value="Oth" runat="server" /> Others
                                            </div>
                                         <label class="control-label col-md-3">Ethnicity <span style="color:red">*</span> </label>
                                             <div class="col-md-4">
                                                <asp:DropDownList ID="CmbEthnicity" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Ethnicity List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item"></asp:DropDownList>
                                            </div>
                                    </div>
                                     <div class="form-group">
                                            <label class="control-label col-md-2">Relationship-Status <span style="color:red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:RadioButton GroupName="Relationship" Checked="true" ID="Relationship1" value="S" runat="server" /> Single
                                                <asp:RadioButton GroupName="Relationship" ID="Relationship2" value="M" runat="server" /> Married
                                                 <asp:RadioButton GroupName="Relationship" ID="RadioButton4" value="Sep" runat="server" /> Separated
                                                <asp:RadioButton GroupName="Relationship" ID="Relationship3" value="D" runat="server" /> Divorced
                                            </div>
                                             <label class="control-label col-md-2">Religion</label>
                                        <div class="col-md-4">   
                                             <asp:DropDownList ID="CmbReligion" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Religion List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item"></asp:DropDownList>
                                         
                                        </div>
                                        </div>
                                     <div class="form-group">
                                            <label class="control-label col-md-2"> Father's Name</label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtFather" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                             <label class="control-label col-md-2">Father's Occupation </label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtOccupation" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        </div>
                                     <div class="form-group">
                                            <label class="control-label col-md-2">Number of Children</label>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="txtChildren" autocomplete="off" Type="number" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                      <%--  <label class="control-label col-md-1">Daughter</label>
                                            <div class="col-md-1">
                                                <asp:TextBox ID="txtDaughter" autocomplete="off" Type="number" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>--%>
                                             <label class="control-label col-md-3">Spouse's Name</label>
                                           <div class="col-md-4">
                                            <asp:TextBox ID="txtSpouse" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                         </div>
                                      <div class="form-group">
                                            <label class="control-label col-md-2"> Mother's Name</label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtMother" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                             <label class="control-label col-md-2">GrandFather's Name </label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtGrand" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        </div>
                                       <div class="form-group"> 
                                            <label class="control-label col-md-2">Citizenship No <span style="color:red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="EMP_CITIZENSHIPNO" autocomplete="off" Cssclass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                             <label class="control-label col-md-3">Citizenship Issued District <span style="color:red">*</span></label>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="CmbIssueDistrict" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="District List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item"></asp:DropDownList>
                                            </div>
                                        </div>
                                      
                                         <asp:UpdatePanel ID="UpdatePanel2" runat="server"  UpdateMode="Conditional">    
                                         <ContentTemplate>
                                       <div class="form-group">
                                            <label class="control-label col-md-2">E mail </label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtPemail" Autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                           
                                            <label class="control-label col-md-1">Mobile <span style="color:red">*</span></label>
                                            <div class="col-sm-3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-phone"></i>
                                                    </span>
                                                    <asp:TextBox ID="EMP_MOBILE" TextMode="Number" autocomplete="off" Cssclass="form-control" Type="Integer" runat="server"></asp:TextBox>
                                                </div>                                       
                                            </div>
                                                                    
                                            <label class="control-label col-md-1">Telephone </label>
                                            <div class="col-sm-3">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-phone"></i>
                                                    </span>
                                
                                                    <asp:TextBox ID="EMP_PHONE" autocomplete="off" Cssclass="form-control" runat="server"></asp:TextBox>
                                                </div>                                       
                                            </div>
                                        </div>
                                      

                                         <div class="form-group">
                                            <label class="control-label col-md-2"> Permanent Address <span style="color: red">*</span> </label>                                              
                                        </div>
                                          <div class="form-group">    
                                            <label class="control-label col-md-2">Provinces <span style="color: red">*</span></label> 
                                            <div class="col-md-2">
                                                 <asp:DropDownList ID="CmbPState" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Provinces List" AutoPostBack="true" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbPState_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                             <label class="control-label col-md-2"> District </label> 
                                            <div class="col-md-2">
                                                <asp:DropDownList ID="CmbPDistrict" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="District List" AutoPostBack="true" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbPDistrict_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                             <label class="control-label col-md-2"> City</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="PSTREET" autocomplete="off" Cssclass="form-control" Placeholder="City" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                          <div class="form-group">
                                            <label class="control-label col-md-2"> VDC/muncipality </label> 
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtMun1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                             <label class="control-label col-md-2"> Ward No.</label> 
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtWard1" CssClass="form-control" Type="number" runat="server"></asp:TextBox>
                                            </div>
                                             <label class="control-label col-md-2">Village/Tole </label> 
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtVillage1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                              
                                        <div class="form-group">
                                            <label class="control-label col-md-2"> Temporary Address</label>
                                             <label class="control-label col-md-2"> Copy Address</label>
                                        <div class="col-md-1">
                                            <asp:CheckBox ID="chkCopy" runat="server" AutoPostBack="true" OnCheckedChanged="chkCopy_CheckedChanged" />
                                        </div>
                                        </div>

                                        <div class="form-group">
                                              <label class="control-label col-md-2"> Provinces </label> 
                                            <div class="col-md-2">
                                                 <asp:DropDownList ID="CmbTState" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Provinces List" AutoPostBack="true" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbState_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <label class="control-label col-md-2"> District </label> 
                                            <div class="col-md-2">
                                                <asp:DropDownList ID="CmbTDistrict" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="District List" AutoPostBack="true" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item"></asp:DropDownList>
                                            </div>
                                            <label class="control-label col-md-2"> City</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="TSTREET" autocomplete="off" Cssclass="form-control" Placeholder="City" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2"> VDC/muncipality </label> 
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtMun" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                             <label class="control-label col-md-2"> Ward No.</label> 
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtWard" CssClass="form-control" Type="number" runat="server"></asp:TextBox>
                                            </div>
                                             <label class="control-label col-md-2">Village/Tole </label> 
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtVillage" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                          <div class="form-group">
                                            <label class="control-label col-md-2">Age</label>
                                         <div class="col-md-4">
                                            <asp:TextBox ID="txtAge" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                          
                                        <label class="control-label col-md-2">Passport No.</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtPassport" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                     </div>
                                   
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                                         
                                <div class="well">
                                  <asp:UpdatePanel ID="UpdatePanel3" runat="server"  UpdateMode="Conditional">    
                                <ContentTemplate>
                                    <h3 style="color:darkblue">2. Personal Health</h3>
                                    <div class="form-group">
                                        <label class="control-label col-md-2">Blood Group </label>
                                         <div class="col-md-4">
                                             <asp:DropDownList ID="CmbBlood" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Blood List" AutoPostBack="true" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item"></asp:DropDownList>
                                        </div>
                                         <label class="control-label col-md-2">Allergy</label>
                                          <div class="col-md-2">
                                             <asp:CheckBox ID="chkAllrg" AutoPostBack="true" runat="server" OnCheckedChanged="chkAllrg_CheckedChanged" />
                                        </div>
                                          <div class="col-md-4">
                                         <asp:TextBox ID="txtAlrg" autocomplete="off" Cssclass="form-control" Placeholder="IF Yes, Specify" runat="server"></asp:TextBox> 
                                     </div>
                                   </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2">Medical Condition </label>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="MED_CON" placeholder="Any Medical condiion like Epilepsy,Migaraine etc" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2">Doctor</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="DOCTOR" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label class="control-label col-md-2">Contact</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="DOCTOR_CONTACT" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2">Doctor</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="DOCTOR1" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label class="control-label col-md-2">Contact</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="DOCTOR_CONTACT1" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>

                                <div class="well">
                                    <h3 style="color:darkblue;">3. Emergency Contact Person</h3>
                                    <div class="form-group">
                                     <div class="col-md-3 pull-right">
                                           <asp:UpdatePanel ID="UpdatePanel7" runat="server"  UpdateMode="Conditional">    
                                            <ContentTemplate> 
                                                <asp:Label ID="lblerrorRep" runat="server" Text=""></asp:Label>  
                                                    <asp:Image ID="Image2" class="Emergency"  runat="server" style="height: 150px; width: 150px ;border-style: ridge; border-width: 5px ;" src="http://avighnatechnology.com/images/dummyselect.jpg"/> 
                                                <asp:FileUpload ID="FileUpload2"  onchange="Relative(this);"  runat="server" Height="22px" accept=".png,.jpg,.jpeg,.gif" /><br/>
                                        </ContentTemplate>    
                                        </asp:UpdatePanel> 
                                        </div>
                                         </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-2">Name </label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="Emergency_Name" autocomplete="off" Cssclass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label class="control-label col-md-2">Relation </label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="Emergency_Relation" CssClass="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-2"> Address </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="Emergency_Address" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label class="control-label col-md-1"> Telephone </label>
                                        <div class="col-sm-3">
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="ace-icon fa fa-phone"></i>
                                                </span>
                                                <asp:TextBox ID="Emergency_Contact"  autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                    
                                            </div>                                       
                                        </div> 
                                         <label class="control-label col-md-1"> Mobile </label>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtEmgMobile" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>                                      
                                    </div>
                                </div>

                           
                            <div class="well">
                                     <asp:UpdatePanel ID="UpdatePanel4" runat="server"  UpdateMode="Conditional">    
                                <ContentTemplate>
                                    <h3 style="color:darkblue";>4. Official Information</h3>
                                    <div class="form-group">
                                        <label class="control-label col-md-2">Project <span style="color: red">*</span></label>
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="CmbBranch" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Project List" AutoPostBack="true" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbBranch_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                         </div>
                                     <div class="form-group">
                                         <label class="control-label col-md-2"> Project District <span style="color: red">*</span></label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="CmbProjectDistrict" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="District List" AutoPostBack="true" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item"></asp:DropDownList>
                                        </div>
                                        <label class="control-label col-md-2"> Department <span style="color:red">*</span></label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Department List" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true"  AllowCustomText="true" InitialValue="Unselectable Item" ></asp:DropDownList> 
                                        </div>
                                   </div>
                                    <div class="form-group">                                           
                                        <label class="control-label col-md-2"> Valid From</label>
                                           <div class="col-md-4">
                                             
                                            <asp:TextBox ID="txtValidFrom"  CssClass="form-control" ReadOnly="true"  runat="server"></asp:TextBox>
                                        </div>
                                     <label class="control-label col-md-2"> Valid To</label>
                                       <div class="col-md-4">
                                          
                                            <asp:TextBox ID="txtValidTo"  CssClass="form-control" ReadOnly="true"  runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-2" for="userName">User ID</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtUserid"  CssClass="form-control"  AutoPostBack="true"  runat="server" ></asp:TextBox>
                                        </div>
                                        <label class="control-label col-md-2">Password <span style="color:red">*</span></label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="EMP_PASSWORD" Autocomplete="off" value="123" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-2">User Type <span style="color:red">*</span></label>
                                        <div class="col-md-4"> 
                                            <asp:DropDownList ID="CmbUsertype" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    
                                    </div>
                                    <div class="form-group"> 
                                            <label class="control-label col-md-2"> Designation <span style="color:red">*</span></label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="CmbDesignation" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Designation List" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true"  AllowCustomText="true" InitialValue="Unselectable Item" ></asp:DropDownList>
                                        </div>
                                      <label class="control-label col-md-2">Basic Salary <span style="color:red">*</span></label>
                                           <div class="col-md-4">
                                            <asp:TextBox ID="txtSalary"  CssClass="form-control"  runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group"> 
                                         <label class="control-label col-md-2">Status <span style="color:red">*</span></label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="CmbStatus"  CssClass="form-control" runat="server" AutoPostBack="true" CausesValidation="True" ToolTip="Status List" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true"  AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbStatus_SelectedIndexChanged" ></asp:DropDownList>
                                        </div>                                              
                                           <div class="col-md-3">
                                            <asp:TextBox ID="txtstadate"  CssClass="form-control col-md-2" placeholder="From Date (yyyy-MM-dd)" runat="server"></asp:TextBox>
                                        </div>
                                         <div class="col-md-3">
                                            <asp:TextBox ID="txtstaToDate"  CssClass="form-control col-md-2" placeholder="To Date (yyyy-MM-dd)" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-group">
                                         <asp:Label ID="lblremarks" runat="server" CssClass="control-label col-md-2" Text="Remarks"></asp:Label>                                            
                                        <div class="col-md-7">
                                            <asp:TextBox ID="txtremarks"  CssClass="form-control col-md-4" placeholder="" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                     <div class="form-group">
                                        <label class="control-label col-md-2">Grade <span style="color:red">*</span></label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="CmbGrade" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Grade List" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true"  AllowCustomText="true" InitialValue="Unselectable Item"></asp:DropDownList>
                                        </div>
                                        <label class="control-label col-md-2">Type <span style="color:red">*</span></label>
                                        <div class="col-md-4">
                                             <asp:DropDownList ID="CmbType" CssClass="form-control" runat="server" AutoPostBack="true" CausesValidation="True" ToolTip="Type List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbType_SelectedIndexChanged1"></asp:DropDownList>
                                         
                                        </div>
                                    </div>

                                     <div class="form-group">
                                        <label class="control-label col-md-2">Payment Mode</label>
                                        <div class="col-md-4">
                                            <asp:RadioButton GroupName="Mode" Checked="true" ID="rbCash" value="0" runat="server" Autopostback="true" OnCheckedChanged="rbCash_CheckedChanged"/> Cash
                                             <asp:RadioButton GroupName="Mode" ID="rbBank" value="1" runat="server" Autopostback="true" OnCheckedChanged="rbBank_CheckedChanged"/> Bank
                                        </div>
                                        
                                        <div class="col-md-3">
                                             <asp:TextBox ID="txtFrom" Autocomplete="off" CssClass="form-control"  placeholder="From Date (yyyy-MM-dd)" runat="server"></asp:TextBox> 
                                        </div>
                                        <div class="col-md-3">
                                             <asp:TextBox ID="txtTo" Autocomplete="off" CssClass="form-control"  placeholder="To Date (yyyy-MM-dd)" runat="server"></asp:TextBox>        
                                        </div>
                                    </div>
                                     <div class="form-group"> 
                                          <asp:Label ID="lblBank" CssClass="control-label col-md-2" runat="server" Text="Bank"></asp:Label>                          
                                       <div class="col-md-4">
                                            <asp:DropDownList ID="CmbBank" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Bank List" AutoPostBack="true" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbBank_SelectedIndexChanged"></asp:DropDownList> 
                                        </div>
                                           <asp:Label ID="lblAccount" CssClass="control-label col-md-2" runat="server" Text="Account No."></asp:Label>   
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtAccno" Autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                   
                                     <div class="form-group">
                                        <label class="control-label col-md-2"> Gratuity</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtGratuity" Autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                            <label class="control-label col-md-2"> Social Security</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtSecurity" Autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                         <label class="control-label col-md-2"> Severance No.</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtSev" Autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div> 
                                        
                                    </div> 

                                     <div class="form-group">
                                        <label class="control-label col-md-2"> PF NO. </label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="pf_number" Autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label class="control-label col-md-1"> EPAN</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="epan_number" Autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label class="control-label col-sm-1"> CIT NO.</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="cit_number" Autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                       
                                    </div>
                                     <div class="form-group">
                                        <label class="control-label col-md-2">Official Email</label>
                                       <div class="col-md-4">
                                            <asp:TextBox ID="txtOfcEmail"  CssClass="form-control"  runat="server"></asp:TextBox>
                                        </div>
                                         <label class="control-label col-md-1"> OverTime</label>
                                        <div class="col-md-1">
                                            <asp:CheckBox ID="chkTime" runat="server" />
                                        </div>
                                          <label class="control-label col-md-1"> Attendance</label>
                                        <div class="col-md-1">
                                            <asp:CheckBox ID="chkAttn" runat="server" />
                                        </div>
                                    </div> 
                                     <div class="form-group">
                                          <label class="control-label col-md-2">Life Insurance</label>
                                        <div class="col-md-4">
                                            <asp:RadioButton GroupName="Insurance"  ID="RadioButton1" value="0" runat="server" Autopostback="true" OnCheckedChanged="RadioButton1_CheckedChanged"/> Yes
                                             <asp:RadioButton GroupName="Insurance" Checked="true" ID="RadioButton2" value="1" runat="server" Autopostback="true" OnCheckedChanged="RadioButton2_CheckedChanged"/> No
                                        </div>
                                         <asp:Label ID="lblPrmAmt" CssClass="col-md-2" runat="server" Text="Premium Amount"></asp:Label>
                                        <div class="col-md-3">
                                            <asp:TextBox ID="txtAmount" Autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                         </div>
                                     <div class="form-group">
                                          <label class="control-label col-md-2">Digital signature </label>
                                        <div class="col-md-4">
                                           <asp:UpdatePanel ID="upnlsig" runat="server"  UpdateMode="Conditional">    
                                                <ContentTemplate>     
                                                      <asp:Label ID="lbldig" runat="server" Text=""></asp:Label> 
                                                    <asp:Image ID="Image3" class="Signature"  runat="server" style="height: 150px; width: 150px ;border-style: ridge; border-width: 5px ;" src="http://avighnatechnology.com/images/dummyselect.jpg"/> 
                                                <asp:FileUpload ID="FileuploadSig"  onchange="Digital(this);"  runat="server" Height="22px" accept=".png,.jpg,.jpeg,.gif" /><br />
                                        </ContentTemplate>  
                                        </asp:UpdatePanel> 
                                        </div> 
                                      </div>
                                      </ContentTemplate>
                                    </asp:UpdatePanel>                                
                                </div>                                            
                            <div class="well">
                         <asp:UpdatePanel ID="UpdatePaneledu" runat="server"  UpdateMode="Conditional">    
                                <ContentTemplate>
                            <div class="table-responsive">
                                <h3 style="color:darkblue;">5. Education Information</h3>
                                        <asp:GridView ID="grvStudentDetails" runat="server" CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"  AutoGenerateColumns="False" CellPadding="3" OnRowDeleting="grvStudentDetails_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="grvStudentDetails_SelectedIndexChanged" OnRowCommand="grvStudentDetails_RowCommand" OnRowDataBound="grvStudentDetails_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="RowNumber" HeaderText="SNo"/>
                                                        <asp:TemplateField HeaderText="Name of Institution">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Degree Earned">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtDegree" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Major/Specialization">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtMajor" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Board">
                                                            <ItemTemplate>
                                                                 <asp:TextBox ID="txtPercentage" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Year Of Passing">
                                                            <ItemTemplate>
                                                                 <asp:TextBox ID="txtEnd"  CssClass="form-control" Type="number" runat="server"></asp:TextBox> 
                                                            </ItemTemplate>
                                                              <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="File Name">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="col-md-4 form-control"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Upload">
                                                            <ItemTemplate>
                                                                <asp:FileUpload ID="fuUpload"   runat="server" accept=".pdf,.png,.jpg,.jpeg"/>
                                                                <asp:HiddenField ID="hfFileByte" runat="server"/>                                                            
                                                            </ItemTemplate>           
                                                        </asp:TemplateField>
                                                           
                                                        <asp:CommandField ShowDeleteButton="True"/>
                                                         
                                                    </Columns>
                                                     <FooterStyle BackColor="White" ForeColor="#000066" />
                                                     <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                     <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                     <RowStyle ForeColor="#000066" />
                                                     <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                     <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                     <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>
                                <asp:Button ID="UploadImage" runat="server" CssClass="btn btn-info" Text="Upload File" CommandName="save" OnClick="UploadImage_Click" />
                                <div class="col-md-10">
                                    <asp:Button ID="ButtonAdd" runat="server" CssClass="btn btn-info" Text="+" OnClick="ButtonAdd_Click" />
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            </ContentTemplate>
                                <Triggers>
                               <asp:PostBackTrigger ControlID="UploadImage" />
                            </Triggers>
                              </asp:UpdatePanel>  
                       </div>
                                
                        <div class="well">           
                             <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                                 <ContentTemplate>
                            <div class="table-responsive">
                                <h3 style="color:darkblue;">6. Training History</h3>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                    <asp:BoundField DataField="RowNumber" HeaderText="SNo" />
                                    <asp:TemplateField HeaderText="Title">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Organized by">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtOrganize" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Place of Training">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPlace" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Number of Days">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDays" CssClass="form-control" Type="number"   runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Start Date">
                                        <ItemTemplate>
                                             <asp:TextBox ID="txtStart" placeholder="YYYY-MM-DD" CssClass="form-control" runat="server"></asp:TextBox>  
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="End Date">
                                        <ItemTemplate>
                                             <asp:TextBox ID="txtEnd" placeholder="YYYY-MM-DD" CssClass="form-control" runat="server"></asp:TextBox> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="File Name">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtFilename" runat="server" CssClass="col-md-4 form-control"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Upload">
                                            <ItemTemplate>
                                                <asp:FileUpload ID="TUpload" runat="server" accept=".pdf,.png,.jpg,.jpeg"/>
                                                <asp:HiddenField ID="TFileByte" runat="server" /> 
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True"/>
                                </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                               
                                <asp:Button ID="btnTrImage" runat="server" CssClass="btn btn-info" Text="Upload File" OnClick="btnTrImage_Click" />
                                <div class="col-md-10">
                                     <asp:Button ID="BtnAddRow" runat="server" CssClass="btn btn-info" Text="+" OnClick="BtnAddRow_Click" />
                                </div>
                            </div>
                            </ContentTemplate>
                                <Triggers>
                               <asp:PostBackTrigger ControlID="btnTrImage" />
                            </Triggers>
                              </asp:UpdatePanel>  
                        </div>
                           
                        <div class="well">
                              <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                                 <ContentTemplate>
                            <div class="table-responsive">
                                <h3 style="color:darkblue;">7.Past Work History</h3>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"  OnRowDeleting="GridView2_RowDeleting" OnRowDataBound="GridView2_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="RowNumber" HeaderText="SNo"/>
                                        <asp:TemplateField HeaderText="Name of organization">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtOrganization" CssClass="form-control" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exact Title of your Post">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date">
                                            <ItemTemplate>
                                                  <asp:TextBox ID="txtStart" placeholder="YYYY-MM-DD" CssClass="form-control" runat="server"></asp:TextBox> 
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date">
                                            <ItemTemplate>
                                                 <asp:TextBox ID="txtEnd" placeholder="YYYY-MM-DD" CssClass="form-control" runat="server"></asp:TextBox>   
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Salary Per Month(Basic)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSalary" CssClass="form-control" Type="number"  runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Referees Email/Contact no.">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtContact" CssClass="form-control" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>  
                                         <asp:TemplateField HeaderText="File Name">
                                            <ItemTemplate>
                                                <asp:TextBox ID="Filename" runat="server" CssClass="col-md-4 form-control"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Upload">
                                            <ItemTemplate>
                                                <asp:FileUpload ID="PWUpload" runat="server" accept=".pdf,.png,.jpg,.jpeg"/>
                                                <asp:HiddenField ID="PWFileByte" runat="server"/> 
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:CommandField ShowDeleteButton="True" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                               
                           <asp:Button ID="btnWorkImage" runat="server" CssClass="btn btn-info" Text="Upload File" OnClick="btnWorkImage_Click" />
                                <div class="col-md-10">
                                     <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-info" Text="+" OnClick="btnAdd_Click" />
                                </div>
                            </div>
                            </ContentTemplate>
                                <Triggers>
                               <asp:PostBackTrigger ControlID="btnWorkImage" />
                            </Triggers>
                              </asp:UpdatePanel>  
                        </div>
                      
                        <div class="well"> 
                                <asp:UpdatePanel ID="UpdatePanel8" UpdateMode="Conditional" runat="server">
                                 <ContentTemplate>
                            <div class="table-responsive">
                                <h3 style="color:darkblue;">8.Work History with CEAPRED</h3>
                                <div class="form-group">
                                    <label class="control-label col-md-3">Checked for Ceapred Work History</label>
                                    <div class="col-md-3">
                                        <asp:CheckBox ID="chkHistory" runat="server" AutoPostBack="true" OnCheckedChanged="chkHistory_CheckedChanged1" />
                                    </div>
                                </div>
                             
                                <br />
                                     <asp:GridView ID="grvceapHistory" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"  OnRowDeleting="grvceapHistory_RowDeleting" OnRowDataBound="grvceapHistory_RowDataBound">
                                    <Columns>
                                         
                                        <asp:BoundField DataField="RowNumber" HeaderText="SNo"/>
                                        
                                         <asp:TemplateField HeaderText="Project Title">
                                            <ItemTemplate>
                                                  <asp:DropDownList ID="CmbProject" runat="server"  CssClass="col-md-2 form-control"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true"   AllowCustomText="true" OnSelectedIndexChanged="CmbProject_SelectedIndexChanged">                        
                                            </asp:DropDownList>
                                           
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Project District">
                                            <ItemTemplate>
                                                  <asp:DropDownList ID="CmbProjectDistrict"  runat="server" CssClass="col-md-2 form-control"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true"   AllowCustomText="true" OnSelectedIndexChanged="CmbProjectDistrict_SelectedIndexChanged">                        
                                       </asp:DropDownList>
                                           
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Title of your post">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltest" runat="server" Text=""></asp:Label>
                                                  <asp:DropDownList ID="CmbPostTitle" runat="server" CssClass="col-md-2 form-control"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true"   AllowCustomText="true" >                        
                                       </asp:DropDownList>
                                           
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtFromDate" CssClass="col-md-2 form-control" placeholder="YYYY-MM-DD" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To Date">
                                            <ItemTemplate>
                                                  <asp:TextBox ID="txtToDate" placeholder="YYYY-MM-DD" CssClass="col-md-2 form-control" runat="server"></asp:TextBox> 
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Salaries">
                                            <ItemTemplate>
                                                 <asp:TextBox ID="txtSalaries"  CssClass="col-md-2 form-control" Type="number"  runat="server"></asp:TextBox>   
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Immediate Supervisor">
                                            <ItemTemplate>
                                                 <asp:TextBox ID="txtSupervisor"  CssClass="col-md-2 form-control"  runat="server"></asp:TextBox>   
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Reason Of Leaving">
                                            <ItemTemplate>
                                               <asp:TextBox ID="txtReason"  CssClass="col-md-3 form-control" TextMode="MultiLine"  runat="server"></asp:TextBox>   
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True"/>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                                   <asp:Button ID="btnAddhistory" runat="server" CssClass="btn btn-info" Text="+" OnClick="btnAddhistory_Click"/>                                   
                            </div> 
                                </ContentTemplate>
                              </asp:UpdatePanel>    
                             
                        </div>
                         
                        <div class="well">
                            <div class="table-responsive">
                                <h3 style="color:darkblue;">9.Leave Management</h3>
                                    <asp:GridView ID="GVLeave" runat="server"
                                        Font-Size="Small"
                                        AutoGenerateColumns="False"                            
                                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                        EmptyDataText="No Records has been added." OnRowDataBound="GVLeave_RowDataBound">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                             <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>

                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Leave Id">
                                            <ItemTemplate>
                                                <asp:Label ID="txtLeaveId" runat="server"  Text='<%# Eval("LEAVE_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                           </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Leave Name">
                                            <ItemTemplate>
                                                <asp:Label ID="txtLeaveName" runat="server"  Text='<%# Eval("LEAVE_NAME") %>'></asp:Label>
                                            </ItemTemplate>
                                           </asp:TemplateField>
                                           
                                                <asp:TemplateField HeaderText="Permission">
                                                    <ItemTemplate>
                                                        <asp:RadioButton ID="rbPer" GroupName="rbPer" Checked="true" runat="server" /> Yes
                                                        <asp:RadioButton ID="rbPer1" GroupName="rbPer"  runat="server" /> No
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                  
                                        </Columns>
                                        <EditRowStyle/>
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />

                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                            </div>

                            <div class="col-md-8 col-md-offset-4">
                            <div class="col-md-3">
                                <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click"/>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel"/>
                            </div>
                        </div>  
                        </div>
                       
                       
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>

    <script type="text/javascript">
    
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.blah')
                    .attr('src', e.target.result)
                    .width(150)
                    .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
        function Relative(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.Emergency')
                    .attr('src', e.target.result)
                    .width(150)
                    .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
        function Digital(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.Signature')
                    .attr('src', e.target.result)
                    .width(150)
                    .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
</script>

</asp:Content>
