<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Attendance_Mgmt/Attendance_mgmt.Master" AutoEventWireup="true" CodeBehind="ForceLeaveAssignment.aspx.cs" Inherits="AttendanceKantipur.Admin.Attendance_Mgmt.ForceLeaveAssignment" %>

  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Attendance Management</li>
                            <li class="active">Leave Assignment
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
                                <label class="control-label col-md-2">Leave Name <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbLeavename" CssClass="form-control" runat="server" CausesValidation="True" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbLeavename_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <label class="control-label col-md-3">No. of Days <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtDays" CssClass="form-control" Type="number" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Employee <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <label class="control-label col-md-1">ID <span style="color: red">*</span></label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEMPID" ReadOnly="true" CssClass="form-control" Type="number" AutoPostBack="True" runat="server" OnTextChanged="txtEMPID_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-sm-2">
                                    <asp:CheckBox ID="Chkemp" AutoPostBack="True" runat="server" OnCheckedChanged="Chkemp_CheckedChanged1" />All Employee
                                </div>

                            </div>
                        
                          
                           <%-- <div class="form-group">
                                <label class="control-label col-md-2">Approved By <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbApproved" CssClass="form-control" runat="server" CausesValidation="True" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbApproved_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <label class="control-label col-md-2">Date Type <span style="color: red">*</span></label>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="DDLLeaveType" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDLLeaveType_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Select Type</asp:ListItem>
                                        <asp:ListItem Value="1">English</asp:ListItem>
                                        <asp:ListItem Value="2">Nepali</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <label class="control-label col-md-1">Month <span style="color: red">*</span></label>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="CmbMonth" CssClass="form-control" AutoPostBack="true" runat="server" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Date <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtDate" CssClass="form-control" runat="server" type="number"></asp:TextBox>
                                </div>
                                <label class="control-label col-md-2">Is Opening <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:CheckBox ID="ChkOpen" runat="server" />
                                </div>
                            </div>
                        </div>
                     <%--   <div class="col-md-5 col-md-offset-4">
                            <div class="col-md-4">
                                <asp:Button ID="btnLoad" CssClass="btn btn-success col-md-6" runat="server" Text="Load" OnClick="btnLoad_Click" />
                            </div>
                        </div>--%>
                       <%-- <div class="col-md-12 table-responsive">
                            <asp:GridView ID="GridView1" runat="server"
                                Font-Size="Small"
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added.">
                                <AlternatingRowStyle BackColor="White" />

                                <EditRowStyle />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />

                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>

                        </div>--%>
                        <div class="col-md-8 col-md-offset-6">
                            <div class="col-md-4">
                                <asp:Button ID="btnSave" CssClass="btn btn-success col-md-6" runat="server" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>



