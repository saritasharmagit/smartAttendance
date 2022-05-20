<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="EditBranchSetup.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.EditBranchSetup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
            <div class="container">
                <div class="row">
					<div class="col-xs-12">
						<div class="page-title-box">
                         
                            <ol class="breadcrumb p-0 m-0">
                                <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                                <li class="blue"><a href="BranchSetup.aspx">Project List</a></li>
                                <li class="active">
                                     Edit Project Setup
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
                 <%--   <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>--%>
              
                    <div class="well">
                          <asp:TextBox ID="BRANCH_ID" runat="server" Visible="False"></asp:TextBox>
                         <div class="form-group">
                            <label class="control-label col-md-2"> Project Code <span style="color:red">*</span></label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtBranchCode" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>
                           </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">Abbreviation <span style="color: red">*</span></label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtAbbr" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>
                            </div>
                        <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server"  UpdateMode="Conditional">    
                        <ContentTemplate>--%>
                        <div class="form-group">
                            <label class="control-label col-md-2"> Project Name <span style="color: red">*</span></label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtBranchName" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>
                          
                              <label class="control-label col-md-2">IsExtend <span style="color: red">*</span></label>
                            <div class="col-md-2">
                            <asp:CheckBox ID="chkExtend" runat="server" AutoPostBack="true" OnCheckedChanged="chkExtend_CheckedChanged1"/>
                          </div>
                         </div> 
                             <div class="form-group">
                        <label class="control-label col-md-2"> Valid From <span style="color:red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate1"  AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtStartDate"  CssClass="form-control englishDate1" AutoComplete="off"  placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>                                      
                        </div>                                   
                    </div>

                         <div class="form-group">
                        <label class="control-label col-md-2"> Valid To <span style="color:red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate2" autocomplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtEndDate" CssClass="form-control englishDate2"  AutoComplete="off" placeholder="English Date"  runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>                                       
                        </div>                                            
                    </div> 
                            <%-- </ContentTemplate>
                        </asp:UpdatePanel>   --%>
                         <div class="form-group">
                            <label class="control-label col-md-2">Status <span style="color:red">*</span></label>
                            <div class="col-md-2">
                                <asp:RadioButton ID="rbStatus" runat="server" Text="Active" GroupName="rbStatus" />

                                <asp:RadioButton ID="rbStatus1" runat="server" Text="InActive" GroupName="rbStatus"/>
                            </div>                                                                                  
                        </div>
                    </div>
                    <div class="col-md-8 col-md-offset-4">
                        <div class="col-md-3">
                            <asp:Button ID="BtnUpdate" CssClass="btn btn-success col-md-12" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
                        </div>
                        <asp:HiddenField ID="HiddenField1" runat="server" />               
                        <div class="col-md-3">
                             <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click1"/>  
                            
                        </div>
                    </div> 
                        
                </form>
            </div> <!-- container -->
        </div> <!-- content -->
    
</asp:Content>
