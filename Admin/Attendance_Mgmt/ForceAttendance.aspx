<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Attendance_Mgmt/Attendance_mgmt.Master" AutoEventWireup="true" CodeBehind="ForceAttendance.aspx.cs" Inherits="AttendanceKantipur.Admin.Attendance_Mgmt.ForceAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
        <div class="container">
            <div class="row">
				<div class="col-xs-12">
					<div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                             <li class="blue">Attendance Management</li>
                              <li class="active">
                                Force Attendance
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
				</div>
			</div>
            <!-- end row -->

            <div class="panel-heading">
                <h3 class="panel-title" style="color: red;">* Denotes Mandatory Fields</h3>
            </div>

            <form runat="server" role="form" class="form-horizontal">
                <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>

                        <div class="well">
                    <div class="form-group">
                        <label class="control-label col-md-6"> Employee ID <span style="color:red">*</span></label>
                        <div class="col-md-2">
                            <div class="input-group">
                                <asp:TextBox ID="TxtId" CssClass="form-control" Type="number" AutoComplete="off" AutoPostBack="true" runat="server" OnTextChanged="TxtId_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label CssClass="control-label col-md-2" runat="server">Employee Name</asp:Label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtEmp" CssClass="form-control" AutoComplete ="off" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Label CssClass="control-label col-md-2" runat="server">Section</asp:Label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtSection" CssClass="form-control" AutoComplete ="off" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label CssClass="control-label col-md-2" runat="server">Department</asp:Label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtDept" CssClass="form-control" AutoComplete ="off" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Label CssClass="control-label col-md-2" runat="server">Project</asp:Label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtBranch" CssClass="form-control" AutoComplete ="off" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                 </ContentTemplate>
                 </asp:UpdatePanel>     
                  
                <div class="well">
                  
                    <div class="form-group">
                        <label class="control-label col-md-2"> Date <span style="color:red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate1" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtStartDate"  CssClass="form-control englishDate1" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>                                      
                        </div>                                   
                    </div>

                      <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" >
                   <ContentTemplate>
                    <div class="form-group">
                            <label class="control-label col-md-2">Mode <span style="color:red">*</span></label>
                            <div class="col-md-2">
                                <asp:RadioButton ID="rbIn" runat="server" Text="Sign In" AutoPostBack="true" GroupName="rbMode" Checked="True" OnCheckedChanged="rbIn_CheckedChanged" />

                                <asp:RadioButton ID="rbOut" runat="server" Text="Sign Out" AutoPostBack="true" GroupName="rbMode" OnCheckedChanged="rbOut_CheckedChanged"/>
                                
                            </div>                                                                                  
                        </div>

                    <div class="form-group">
                        <asp:Label ID="lblIntime" CssClass="control-label col-md-2" runat="server" Text="In Time"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtTimeIn" CssClass="form-control" runat="server" Text="09:30:00"></asp:TextBox>
                        </div>
                     <asp:Label ID="lblInRemark" CssClass="control-label col-md-2" runat="server" Text="In Remark"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="TextInRemark" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblOutTime" runat="server"  CssClass="control-label col-md-2" Text="Out Time"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtTimeOut" CssClass="form-control" runat="server" Text="17:00:00"></asp:TextBox>
                        </div>
                       <asp:Label ID="lblOutRemark" runat="server"  CssClass="control-label col-md-2" Text="Out Remark"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="TextOutRemark" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                          
                    </div>
                         </ContentTemplate>
                      </asp:UpdatePanel>
                    </div>
                
                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click"/>
                    </div>
                                            
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />  
                    </div>
                </div> 
                     
            </form>
           </div><!-- container -->
        </div> <!-- content -->
    
     <script type = "text/javascript">
         function checkAll(objRef) {

             var GridView = objRef.parentNode.parentNode.parentNode;

             var inputList = GridView.getElementsByTagName("input");

             for (var i = 0; i < inputList.length; i++) {

                 var row = inputList[i].parentNode.parentNode;

                 if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                     if (objRef.checked) {

                         inputList[i].checked = true;

                     }

                     else {
                         inputList[i].checked = false;

                     }

                 }

             }

         }

</script> 
</asp:Content>
