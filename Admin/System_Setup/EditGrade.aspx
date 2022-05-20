<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="EditGrade.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.EditGrade" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
            <div class="container">
                <div class="row">
					<div class="col-xs-12">
						<div class="page-title-box">
                         
                            <ol class="breadcrumb p-0 m-0">
                                <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                                <li class="blue"><a href="Grade.aspx">Grade List</a></li>
                                <li class="active">
                                     Edit Grade
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
                          <asp:TextBox ID="GRADE_ID" runat="server" Visible="False"></asp:TextBox>
                         <div class="form-group">
                            <label class="control-label col-md-2"> Grade Name <span style="color:red">*</span></label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtGradename" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>
                           </div>
                        <div class="form-group">
                            <label class="control-label col-md-2"> Grade Type <span style="color: red">*</span></label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtGradetype" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>
                         </div> 
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
