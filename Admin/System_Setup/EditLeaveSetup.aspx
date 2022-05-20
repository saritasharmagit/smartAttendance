<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="EditLeaveSetup.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.EditLeaveSetup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="Dashboard.aspx">Home</a></li>
                            <li class="blue"><a href="LeaveList.aspx">Leave List</a></li>
                            <li class="active">Edit Leave 
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
                <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
                <div class="well">
                    <asp:TextBox ID="LEAVE_ID" runat="server" Visible="False"></asp:TextBox>
                    <div class="form-group">
                        <label class="control-label col-md-2">Leave Name <span style="color: red">*</span></label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtLeaveName" CssClass="form-control" required="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Days <span style="color: red">*</span></label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDays" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Cashable <span style="color: red">*</span></label>
                        <div class="col-md-2">
                            <asp:RadioButton ID="rbCashable" runat="server" Text="" GroupName="rbCashable" />
                            Yes

                            <asp:RadioButton ID="rbCashable1" runat="server" Text="" GroupName="rbCashable" />
                            No

                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">Max. Days at Time <span style="color: red">*</span></label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtMaxDays" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <asp:UpdatePanel ID="Updtpnl" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <label class="control-label col-md-2">Leave Type <span style="color: red">*</span></label>
                                <div class="col-md-6">
                                    <asp:RadioButton ID="rbExpire" runat="server" Text="" AutoPostBack="true" GroupName="LeaveType" OnCheckedChanged="rbExpire_CheckedChanged" />Expire Yearly
                                    <asp:RadioButton ID="rbAccu" runat="server" Text="" AutoPostBack="true" GroupName="LeaveType" OnCheckedChanged="rbAccu_CheckedChanged" />
                                    Accumulative
                                    <asp:RadioButton ID="rbService" runat="server" Text="" AutoPostBack="true" GroupName="LeaveType" OnCheckedChanged="rbService_CheckedChanged" /> Service Period
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="lblAccm" class="control-label col-md-2" runat="server" Text="Max. Accumulation Days"></asp:Label>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAccumulation" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <asp:Label ID="lblService" class="control-label col-md-2" runat="server" Text="Service Period in a Year"></asp:Label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtService" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Others <span style="color: red">*</span></label>
                        <div class="col-md-6">
                            <asp:CheckBox ID="chkOthers" GroupName="chkOthers" runat="server" />
                            Monthly Earning
                            <asp:CheckBox ID="chkOthers1" GroupName="chkOthers" runat="server" />
                            Must Exhaust All Leaves
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">Status <span style="color: red">*</span></label>
                        <div class="col-md-2">
                            <asp:RadioButton ID="rbStatus" runat="server" GroupName="rbStatus" />
                            Active
                            <asp:RadioButton ID="rbStatus1" runat="server" GroupName="rbStatus" />
                            Inactive
                        </div>
                    </div>
                </div>
                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnUpdate" CssClass="btn btn-success col-md-12" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
                    </div>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />

                    </div>
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->

</asp:Content>




