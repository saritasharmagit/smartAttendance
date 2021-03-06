<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="EditBank.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.EditBank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
            <div class="container">
                <div class="row">
					<div class="col-xs-12">
						<div class="page-title-box">
                         
                            <ol class="breadcrumb p-0 m-0">
                                <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                                <li class="blue"><a href="Bank.aspx">Bank List</a></li>
                                <li class="active">
                                     Edit Bank 
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
                          <asp:TextBox ID="BANK_ID" runat="server" Visible="False"></asp:TextBox>
                         <div class="form-group">
                            <label class="control-label col-md-2"> Bank Code <span style="color:red">*</span></label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtBankcode" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>
                           </div>
                       
                        <div class="form-group">
                            <label class="control-label col-md-2"> Bank Name <span style="color: red">*</span></label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtBankname" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>    
                         </div> 
                        
                         <div class="form-group">
                            <label class="control-label col-md-2">Account Number <span style="color:red">*</span></label>
                            <div class="col-md-2">
                                 <asp:TextBox ID="txtAccnumber" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>                                                                                  
                        </div>
                    </div>
                    <div class="col-md-8 col-md-offset-4">
                        <div class="col-md-3">
                            <asp:Button ID="BtnUpdate" CssClass="btn btn-success col-md-12" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
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
