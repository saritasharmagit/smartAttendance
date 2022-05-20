<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="EditBankBranch.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.EditBankBranch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
            <div class="container">
                <div class="row">
					<div class="col-xs-12">
						<div class="page-title-box">
                         
                            <ol class="breadcrumb p-0 m-0">
                                <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                                <li class="blue"><a href="BankBranch.aspx">Bank Branch List</a></li>
                                <li class="active">
                                     Edit Bank Branch
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
                  
                    <div class="well">
                          <asp:TextBox ID="BRANCH_ID" runat="server" Visible="False"></asp:TextBox>
                         <div class="form-group">
                            <label class="control-label col-md-2">Bank Name <span style="color:red">*</span></label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtBankname" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox> 
                            </div>
                           </div>
                        <div class="form-group">                                           
                        <label class="control-label col-md-2">Branch <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAddress1" CssClass="form-control" Placeholder="Address1" AutoComplete="off"  runat="server"></asp:TextBox> 
                        </div>
                         <div class="col-md-4">
                            <asp:TextBox ID="txtAddress2" CssClass="form-control" Placeholder="Address2" AutoComplete="off"  runat="server"></asp:TextBox> 
                        </div>
                    </div>
                    </div>
                    <div class="col-md-8 col-md-offset-4">
                        <div class="col-md-3">
                            <asp:Button ID="BtnUpdate" CssClass="btn btn-success col-md-12" runat="server" Text="Update" OnClick="BtnUpdate_Click"/>
                        </div>
                        <asp:HiddenField ID="HiddenField1" runat="server" />               
                        <div class="col-md-3">
                             <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel"/>  
                            
                        </div>
                    </div> 
                        
                </form>
            </div> <!-- container -->
        </div> <!-- content -->
</asp:Content>
