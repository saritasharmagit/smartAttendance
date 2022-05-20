<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="EditCompany.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.EditCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
            <div class="container">
                <div class="row">
					<div class="col-xs-12">
						<div class="page-title-box">
                         
                            <ol class="breadcrumb p-0 m-0">
                                <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                                <li class="blue"><a href="Company.aspx">Company List</a></li>
                                <li class="active">
                                     Edit Company
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
                            <asp:TextBox ID="Org_Id" CssClass="form-control hidden" runat="server"></asp:TextBox>
                            <div class="form-group">
                                <label class="control-label col-md-2"> Company Name <span style="color:red">*</span></label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="Org_Name" CssClass="form-control" runat="server"></asp:TextBox> 
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2"> Address <span style="color: red">*</span></label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="Org_Address" CssClass="form-control" runat="server"></asp:TextBox> 
                                </div> 
                                <div class="col-md-5">
                                    <asp:TextBox ID="Org_Address2" CssClass="form-control" runat="server"></asp:TextBox> 
                                </div>                                                                                   
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2"> Telephone <span style="color:red">*</span></label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="Org_Phone" CssClass="form-control" runat="server"></asp:TextBox> 
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2"> Fax <span style="color: red">*</span></label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="Org_Fax" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2"> Email <span style="color: red">*</span></label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="Org_Email" CssClass="form-control" runat="server"></asp:TextBox>  
                                </div>
                            </div>
                            <div class="form-group">                                           
                                <label class="control-label col-md-2"> Website <span style="color: red">*</span></label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="Org_Website" CssClass="form-control" runat="server" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true"  AllowCustomText="true" ></asp:TextBox> 
                                </div>
                            </div>
                    </div>            
                          
                    <div class="col-md-8 col-md-offset-4">
                        <div class="col-md-3">
                            <asp:Button ID="BtnUpdate" CssClass="btn btn-success col-md-12" runat="server" Text="Update" OnClick="BtnUpdate_Click"/>
                        </div>
                        <asp:HiddenField ID="HiddenField1" runat="server" />               
                        <div class="col-md-3">
                             <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click"/>  
                            
                        </div>
                    </div>       
                </form>
            </div> <!-- container -->
        </div> <!-- content -->
</asp:Content>
