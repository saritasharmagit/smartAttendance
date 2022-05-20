<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="AddDesignation.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.AddDesignation" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
 <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                            <li class="blue"><a href="Designation.aspx">Designation List</a></li>
                            <li class="active">
                                Add New Designation
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
                    <asp:TextBox ID="DEG_ID" CssClass="form-control hidden" runat="server"></asp:TextBox>
                    <div class="form-group">
                        <label class="control-label col-md-2"> Designation Name <span style="color:red">*</span></label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDesignation" CssClass="form-control" AutoComplete="off"  runat="server"></asp:TextBox> 
                        </div>
                    </div>
                   
                    <div class="form-group">                                           
                        <label class="control-label col-md-2"> Status <span style="color: red">*</span></label>
                        <div class="col-md-5">
                            <asp:RadioButton ID="rbStatus" Checked="true" GroupName="rbStatus" runat="server"/> Active
                            <asp:RadioButton ID="rbStatus1" GroupName="rbStatus" runat="server"/> InActive
                        </div>
                    </div>
                </div>

                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click"/>  
                    </div>
                </div>
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>

