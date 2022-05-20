<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Reports/Reports.Master" AutoEventWireup="true" CodeBehind="Reports_LeaveSummary.aspx.cs" Inherits="AttendanceKantipur.Admin.Reports.Reports_LeaveSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
				<div class="col-xs-12">
					<div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="active">
                                Leave Information Report
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
              
                 <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true" >
                  <ContentTemplate>
                <div class="well">
                  
                    <div class="form-group">
                        <label class="control-label col-md-2"> Employee <span style="color: red">*</span></label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Employee List" AutoPostBack="true"
                            EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true"  AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtEmpId" CssClass="form-control" type="number" AutoComplete="off" AutoPostBack="true"  runat="server" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox> 
                        </div>
                        
                        <div class="col-sm-3">
                            <asp:CheckBox ID="ChkAllemp" AutoPostBack="True" runat="server" OnCheckedChanged="ChkAllemp_CheckedChanged1"/><span class="lbl"> All Employees</span>
                        </div> 
                            
                    </div>
                 </div>
                 </ContentTemplate>
             </asp:UpdatePanel>
                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnLoadLeaveSummary" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoadLeaveSummary_Click"/>
                    </div>
                                            
                    <div class="col-md-3">
                        <asp:Button ID="BtnLeaveSummary" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnLeaveSummary_Click"/>  
                    </div>
                </div>         
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>
