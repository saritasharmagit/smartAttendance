<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="AddBankBranch.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.AddBankBranch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                             <li class="blue">Home</li>
                            <li class="blue"><a href="BankBranch.aspx">Bank List</a></li>
                            <li class="active">
                                Add New Bank Branch
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
                    <div class="form-group">
                        <label class="control-label col-md-2"> Bank Name <span style="color: red">*</span></label>
                        <div class="col-md-4">
                             <asp:DropDownList ID="CmbBankName" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="District List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item"></asp:DropDownList> 
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
                        <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click"/>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel"/>  
                    </div>
                </div>
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>
