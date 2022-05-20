<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/HR_Mgmt/HR.Master" AutoEventWireup="true" CodeBehind="ShowDetails.aspx.cs" Inherits="AttendanceKantipur.Admin.HR_Mgmt.ShowDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="Dashboard.aspx">Home</a></li>
                            <li class="blue"><a href="Employees.aspx">Employee List</a></li>
                            <li class="active">View Details
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->
            <form runat="server" role="form" class="form-horizontal">
                <div class="col-md-12 form-group">
                    <div class="col-md-6 button-list">
                        <asp:Button ID="btnBack" CssClass="btn btn-success col-md-2" runat="server" Text="Back" OnClick="btnBack_Click" />
                        <asp:Button ID="btnEdit" CssClass="btn btn-primary col-md-2" runat="server"  Text="Edit" OnClick="btnEdit_Click1"/>
                    </div>
                </div>
              
                 <div class="col-md-12 form-group">
                <div class="col-md-6">      
                         <asp:Label ID="Label58" CssClass="col-md-3" runat="server" Text=""></asp:Label>
                        <div class="col-md-8">
                            <asp:Image ID="PersImage" runat="server" style="height: 150px; width: 150px ;border-style: ridge; border-width: 5px ;" />
                        </div>
                  
                     </div>  
                     </div>
                 <div class="col-md-12 form-group">
                     <div class="col-md-6">
                    <h3 style="color: darkblue;">General Information</h3>
                    <div class="form-group">
                        <asp:Label ID="Label1" CssClass="col-md-4" runat="server" Text="Employee Id :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblid" runat="server"></asp:Label>
                        </div>

                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label2" CssClass="col-md-4" runat="server" Text="Full Name :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblname" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" CssClass="col-md-4" runat="server" Text="Sex :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblgender" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label37" CssClass="col-md-4" runat="server" Text="Ethnicity :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblEthnicity" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label38" CssClass="col-md-4" runat="server" Text="Religion :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblReligion" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label39" CssClass="col-md-4" runat="server" Text="Father's Name :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblFather" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label40" CssClass="col-md-4" runat="server" Text="Father's Occupation :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblFatherOccu" runat="server"></asp:Label>
                        </div>
                    </div>
                      <div class="form-group">
                        <asp:Label ID="Label41" CssClass="col-md-4" runat="server" Text="Number of Children :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblChildren" runat="server"></asp:Label>
                        </div>
                    </div>
                    <%-- <div class="form-group">
                        <asp:Label ID="Label42" CssClass="col-md-3" runat="server" Text="Daughter :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblDaughter" runat="server"></asp:Label>
                        </div>
                    </div>--%>
                      <div class="form-group">
                        <asp:Label ID="Label43" CssClass="col-md-4" runat="server" Text="Spouse's Name :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblSpouse" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label44" CssClass="col-md-4" runat="server" Text="Mother's Name :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblMother" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label45" CssClass="col-md-4" runat="server" Text="GrandFather's Name :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblgrand" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label47" CssClass="col-md-4" runat="server" Text="CitizenShip Issue District:-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblCitizenDist" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label4" CssClass="col-md-4" runat="server" Text="Relationship-Status :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblRelation" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label5" CssClass="col-md-4" runat="server" Text="Date Of Birth :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lbldob" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" CssClass="col-md-4" runat="server" Text="First Join Date :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lbldate" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label7" CssClass="col-md-4" runat="server" Text="Mobile :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblmob" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label48" CssClass="col-md-4" runat="server" Text="Telephone :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label8" CssClass="col-md-4" runat="server" Text="Email :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblemail" runat="server"></asp:Label>
                        </div>
                    </div>
                  
                   
                    <div class="form-group">
                        <asp:Label ID="Label36" CssClass="col-md-4" style="color: darkblue;" runat="server" Text="Permanent Address"></asp:Label>
                    </div>
                    <div class="form-group">
                            <asp:Label ID="Label35" CssClass="col-md-4" runat="server" Text="Province:-"></asp:Label>
                      
                        <div class="col-md-5">
                            <asp:Label ID="lblPProvince" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                       
                            <asp:Label ID="Labeldist" CssClass="col-md-4" runat="server" Text="District:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblPDistrict" runat="server"></asp:Label>
                            </div>
                       
                    </div>
                    <div class="form-group">
                       
                            <asp:Label ID="Labelcity" CssClass="col-md-4" runat="server" Text="City:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblPCity" runat="server"></asp:Label>
                            </div>
                      
                    </div>
                    <div class="form-group">
                       
                            <asp:Label ID="Labelvdc" CssClass="col-md-4" runat="server" Text="VDC/municipality:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblPmun" runat="server"></asp:Label>
                            </div>
                      
                    </div>
                    <div class="form-group">
                            <asp:Label ID="Labelward" CssClass="col-md-4" runat="server" Text="Ward No.:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblPWard" runat="server"></asp:Label>
                            </div>
                    </div>
                    <div class="form-group">  
                            <asp:Label ID="Labelvilg" CssClass="col-md-4" runat="server" Text="Village/Tole:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblPVillage" runat="server"></asp:Label>
                            </div>   
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label11" CssClass="col-md-4" style="color: darkblue;" runat="server" Text="Temporary Address"></asp:Label>
                    </div>
                    <div class="form-group">
                            <asp:Label ID="Label15" CssClass="col-md-4" runat="server" Text="Province:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblTprov" runat="server"></asp:Label>
                            </div>
                       
                    </div>
                    <div class="form-group">
                            <asp:Label ID="Label19" CssClass="col-md-4" runat="server" Text="District:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblTDist" runat="server"></asp:Label>
                            </div>
                       
                    </div>
                    <div class="form-group">
                            <asp:Label ID="Label23" CssClass="col-md-4" runat="server" Text="City:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblTCity" runat="server"></asp:Label>
                            </div>
                      
                    </div>
                    <div class="form-group">
                            <asp:Label ID="Label27" CssClass="col-md-4" runat="server" Text="VDC/municipality:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblTmun" runat="server"></asp:Label>
                            </div>
                      
                    </div>
                    <div class="form-group">
                            <asp:Label ID="Label31" CssClass="col-md-4" runat="server" Text="Ward No.:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblTWard" runat="server"></asp:Label>
                            </div>
                     
                    </div>
                    <div class="form-group">
                            <asp:Label ID="Label33" CssClass="col-md-4" runat="server" Text="Village/Tole:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblTVillage" runat="server"></asp:Label>
                            </div>
                       
                    </div>
                      <div class="form-group">
                        <asp:Label ID="Label49" CssClass="col-md-4" runat="server" Text="Passport Number :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblPassport" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
             
                <div class="col-md-6">
                    <h3 style="color: darkblue;">Official Information</h3>
                      <div class="form-group">
                        <asp:Label ID="Label9" CssClass="col-md-4" runat="server" Text="User Id :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblusrid" runat="server"></asp:Label>
                        </div>
                    </div>
                      <div class="form-group">
                        <asp:Label ID="Label20" CssClass="col-md-4" runat="server" Text="Project :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblbranch" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label46" CssClass="col-md-4" runat="server" Text="Project District :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblProjectDist" runat="server"></asp:Label>
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <asp:Label ID="Label10" CssClass="col-md-4" runat="server" Text="Password :-"></asp:Label>
                        <div class="col-md-5">
                          <%--  <asp:TextBox ID="lblpassword" TextMode="Password" CssClass="form-control"  runat="server"></asp:TextBox>--%>
                            <asp:Label ID="lblpassword"  TextMode="Password"  runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label12" CssClass="col-md-4" runat="server" Text="Designation :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblDeg" runat="server"></asp:Label>
                        </div>
                        <asp:Label ID="lblPromotedDate" CssClass="col-md-3" runat="server" Text=""></asp:Label>
                        
                    </div>
                  
                    <div class="form-group">
                        <asp:Label ID="Label16" CssClass="col-md-4" runat="server" Text="Status :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblFromstatus" CssClass="col-md-4" runat="server" Text="From Date :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblfromdate" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblTostatus" CssClass="col-md-4" runat="server" Text="To Date :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblTodate" runat="server"></asp:Label>
                        </div>
                    </div>

                      <div class="form-group">
                        <asp:Label ID="Label14" CssClass="col-md-4" runat="server" Text="Type :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblType" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="lblTypefromdate" CssClass="col-md-4" runat="server" Text="Type From :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lbltypeFrom" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="lblTypeTodate" CssClass="col-md-4" runat="server" Text="Type To:-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lbltypeTo" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label18" CssClass="col-md-4" runat="server" Text="Department :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lbldept" runat="server"></asp:Label>
                        </div>
                    </div>
                  
                    <div class="form-group">
                        <asp:Label ID="Label22" CssClass="col-md-4" runat="server" Text="User Type :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblUsertype" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label24" CssClass="col-md-4" runat="server" Text="Grade :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblgrade" runat="server"></asp:Label>
                        </div>
                    </div>
                       <div class="form-group">
                        <asp:Label ID="Label50" CssClass="col-md-4" runat="server" Text="Basic Salary :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblSalary" runat="server"></asp:Label>
                        </div>
                    </div>
                  
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                     <div class="form-group">
                        <asp:Label ID="Label52" CssClass="col-md-4" runat="server" Text="Bank :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblBank" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label53" CssClass="col-md-4" runat="server" Text="Bank Account :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblAccount" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label26" CssClass="col-md-4" runat="server" Text="PF No. :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblPF" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label28" CssClass="col-md-4" runat="server" Text="CIT No. :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblCIT" runat="server"></asp:Label>

                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label30" CssClass="col-md-4" runat="server" Text="Citizenship No. :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblCitizen" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label32" CssClass="col-md-4" runat="server" Text="Gratuity :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblgratuity" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label34" CssClass="col-md-4" runat="server" Text="Social Security :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblsecurity" runat="server"></asp:Label>
                        </div>
                    </div>
                      <div class="form-group">
                        <asp:Label ID="Label54" CssClass="col-md-4" runat="server" Text="Severance No. :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblSev" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label55" CssClass="col-md-4" runat="server" Text="EPAN. :-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblEpan" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label56" CssClass="col-md-4" runat="server" Text="Official Email:-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblOffEmail" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label57" CssClass="col-md-4" runat="server" Text="Attendance:-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblAttendance" runat="server"></asp:Label>
                        </div>
                    </div>
                      <div class="form-group">
                        <asp:Label ID="Label51" CssClass="col-md-4" runat="server" Text="Premium Amount:-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Label ID="lblPremium" runat="server"></asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                         <asp:Label ID="Label59" CssClass="col-md-4" runat="server" Text="Digital Signature:-"></asp:Label>
                        <div class="col-md-5">
                            <asp:Image ID="Imageofc" runat="server" style="height: 150px; width: 150px ;border-style: ridge; border-width: 5px ;" />
                        </div>
                  
                          </div>
                </div>
                </div>
                 <div class="col-md-6">
                        <h3 style="color: darkblue;">Personal Health</h3>
                        <div class="form-group">
                            <asp:Label ID="Label13" CssClass="col-md-4" runat="server" Text="Blood Group :-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblGroup" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label17" CssClass="col-md-4" runat="server" Text="Allergy :-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblAllergy" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label21" CssClass="col-md-4" runat="server" Text="Medical Condition :-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblMedical" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label25" CssClass="col-md-4" runat="server" Text="Doctor :-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblDoct" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label29" CssClass="col-md-4" runat="server" Text="Contact Number:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblContact" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                 <div class="col-md-6">
                        <h3 style="color: darkblue;">Emergency Contact Information</h3>
                      <div class="form-group">
                         <asp:Label ID="Label60" CssClass="col-md-4" runat="server" Text=""></asp:Label>
                        <div class="col-md-5">
                            <asp:Image ID="Imageemg" runat="server" style="height: 150px; width: 150px ;border-style: ridge; border-width: 5px ;" />
                        </div>
                  
                          </div>
                        <div class="form-group">
                            <asp:Label ID="Label68" CssClass="col-md-4" runat="server" Text="Contact Person :-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblContperson" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label70" CssClass="col-md-4" runat="server" Text="Relation :-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="Labelrelation" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label72" CssClass="col-md-4" runat="server" Text="Address :-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label74" CssClass="col-md-4" runat="server" Text="Contact Number:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblContactnumber" runat="server"></asp:Label>
                            </div>
                        </div>
                      <div class="form-group">
                            <asp:Label ID="Label61" CssClass="col-md-4" runat="server" Text="Mobile Number:-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblMobile" runat="server"></asp:Label>
                            </div>
                        </div>
                      
                    </div>
 
                <div class="col-md-12">
                    <h3 style="color: darkblue;">Employee Education</h3>
                    <asp:GridView ID="grvEducation" runat="server"
                        Font-Size="Small"
                        AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info" OnRowDataBound="grvEducation_RowDataBound" OnSelectedIndexChanged="grvEducation_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="SNO" HeaderText="SNO"/>
                            <asp:BoundField DataField="schoolCollege" HeaderText="Name and Address of institution"/>
                            <asp:BoundField DataField="degree" HeaderText=" degree Earned" />
                            <asp:BoundField DataField="division" HeaderText="Board" />
                            <asp:BoundField DataField="date" HeaderText="year of passing" DataFormatString="{0:yyyy/MM/dd}"/>
                            <asp:BoundField DataField="majorSubject" HeaderText="Specialization" />
                        
                            <asp:TemplateField HeaderText="Document">
                                <ItemTemplate>
                               <%--   <asp:LinkButton ID="lnkView" runat="server" Text="View" OnClick="lnkView_Click" CommandArgument='<%# Eval("SNO") %>'></asp:LinkButton>--%>

                                     <asp:Image ID="ImgDoc" runat="server" target="_blank"  style="height: 50px; width: 50px ;border-style: ridge; border-width: 5px ;" ImageUrl='<%# (Eval("Image") != System.DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image")) : "../../Assets/images/PDF_logo.png") %>'/>
                              
                                  <button class="btn-rounded">
                                       <asp:LinkButton ID="OpenDocument" CommandArgument='<%# Eval("SNO") %>' Text="Download"  runat="server"  OnClick = "OpenDocument_Click"></asp:LinkButton>
                                  </button>
                                </ItemTemplate>
                            </asp:TemplateField>
                     
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
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
           
                <div class="col-md-12">
                    <h3 style="color: darkblue;">Employee Training</h3>
                    <asp:GridView ID="grvTraining" runat="server"
                        Font-Size="Small"
                        AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:BoundField DataField="Title" HeaderText="Title"/>
                            <asp:BoundField DataField="organization" HeaderText="Organized By" />
                            <asp:BoundField DataField="place" HeaderText="Place of Training" />
                            <asp:BoundField DataField="startDate" HeaderText="Start Date" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField DataField="endDate" HeaderText="End Date" DataFormatString="{0:yyyy/MM/dd}" />                         
                            <asp:BoundField DataField="Days" HeaderText="number of days"/>
                            
                             <asp:TemplateField HeaderText="Document">
                                <ItemTemplate>
                                   <asp:Image ID="ImgDocTr" runat="server"  style="height: 50px; width: 50px ;border-style: ridge; border-width: 5px ;" ImageUrl='<%# (Eval("Image") != System.DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image")) : "../../Assets/images/PDF_logo.png") %>'  />
                             <%--  <asp:LinkButton ID="PastWorkDownload" Text = "Download" runat="server" OnClick = "PastWorkDownload_Click"></asp:LinkButton>--%>
                                    <button class="btn-rounded">
                                    <asp:LinkButton ID="DocumentTraining" CommandArgument='<%# Eval("SNO") %>' Text="Download" runat="server"  OnClick = "DocumentTraining_Click"></asp:LinkButton>
                                </button>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
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

                <div class="col-md-12">
                    <h3 style="color: darkblue;">Past Work History</h3>
                    <asp:GridView ID="grvworkexperience" runat="server"
                        Font-Size="Small"
                        AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="organization" HeaderText="Name of Organization" />

                            <asp:BoundField DataField="designation" HeaderText="Post Title" />
                            <asp:BoundField DataField="startDate" HeaderText="Start Date" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField DataField="endDate" HeaderText="End Date" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField DataField="Salary" HeaderText="Salary" />
                            <asp:BoundField DataField="Contact" HeaderText="Contact" />
                         
                              <asp:TemplateField HeaderText="Document">
                                <ItemTemplate>
                                       <asp:Image ID="ImgDocPW" runat="server"  style="height: 50px; width: 50px ;border-style: ridge; border-width: 5px ;" ImageUrl='<%# (Eval("Image") != System.DBNull.Value ? "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("Image")) : "../../Assets/images/PDF_logo.png") %>'  />
                                 <%-- <asp:Image ID="ImgDocPW" runat="server" style="height: 150px; width: 150px ;border-style: ridge; border-width: 5px ;" />--%>
                                <button class="btn-rounded">
                                     <asp:LinkButton ID="DocumentWork" CommandArgument='<%# Eval("SNO") %>' Text="Download" runat="server"  OnClick = "DocumentWork_Click"></asp:LinkButton>
                                </button>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />

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

                <div class="col-md-12">
                    <h3 style="color: darkblue;">Work History with CEAPRED</h3>
                    <asp:GridView ID="grvHistory" runat="server"
                        Font-Size="Small"
                        AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:BoundField DataField="Project_Name" HeaderText="Project"/>
                             <asp:BoundField DataField="ProjectDistrict_Name" HeaderText="Project District"/>
                             <asp:BoundField DataField="Designation_Name" HeaderText="Post Title"/>
                             <asp:BoundField DataField="From_Date" HeaderText=" From Date"  DataFormatString="{0:yyyy/MM/dd}"/>
                             <asp:BoundField DataField="To_Date" HeaderText="To Date"  DataFormatString="{0:yyyy/MM/dd}"/>
                             <asp:BoundField DataField="Salaries" HeaderText="Salary" />
                            <asp:BoundField DataField="ImmediateSupervisor_Name" HeaderText="Immediate SuperVisor"/>
                          
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
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

              
               
                   <div class="col-md-12">
                    <h3 style="color: darkblue;">Leave Management</h3>
                    <asp:GridView ID="grvLeave" runat="server"
                        Font-Size="Small"
                        AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="LEAVE_NAME" HeaderText="Leave Name" />
                           <%-- <asp:BoundField DataField="DAYS" HeaderText="Leave Days" />
                             <asp:BoundField DataField="MAXDAYS" HeaderText="MAximum Leave Days" />--%>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
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

            </form>
        </div>
        <!-- container -->
    </div>
</asp:Content>
