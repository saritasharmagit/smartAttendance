<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Reports/Reports.Master" AutoEventWireup="true" CodeBehind="Reports_StaffDetails.aspx.cs" Inherits="AttendanceKantipur.Admin.Reports.Reports_StaffDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="active">Staff Details Report
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
                 <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true" >
                  <ContentTemplate>

                <div class="form-group">
                    <label class="control-label col-md-2">Status <span style="color:red";>*</span></label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="CmbStatus" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Status List" AutoPostBack="true" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbStatus_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                     <div class="col-sm-3">
                            <asp:CheckBox ID="Chkemp" AutoPostBack="True" runat="server" OnCheckedChanged="Chkemp_CheckedChanged"/><span class="lbl">All Employee</span>
                        </div> 
                </div>
                    </ContentTemplate>
                   </asp:UpdatePanel>
                       </div>
                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click"/>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel"/>
                    </div>
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
</asp:Content>
