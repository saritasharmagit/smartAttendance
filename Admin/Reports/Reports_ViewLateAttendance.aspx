<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Reports/Reports.Master" AutoEventWireup="true" CodeBehind="Reports_ViewLateAttendance.aspx.cs" Inherits="AttendanceKantipur.Admin.Reports.Reports_ViewLateAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="blue">Attendacne Reports</li>
                            <li class="active">
                                View Attendance Details Report
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
			    </div>
		    </div>
            <!-- end row -->
            <form runat="server" role="form" class="form-horizontal">
                <div class="col-md-12 form-group">
                    <div class="col-md-6 button-list">
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-2" runat="server" Text="New" OnClick="BtnNew_Click" />
                        <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2" runat="server" Text="Excel" OnClick="BtnExport_Click" />
                    </div>
                     
                     <asp:Panel ID="Panel1" runat="server">
                    <div style="font-weight:bold;" class="col-md-6">
                        <div style="font-weight: bold; font-size: large">
                            <asp:Label ID="labelmonthly" runat="server" Text="CEAPRED Attendance Details Report"></asp:Label>
                        </div>
                        From : <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label> To : <asp:Label ID="lblEndDate" runat="server" Text="Label"></asp:Label>
                    </div>
                   </asp:Panel>
                     </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server"
                                ShowHeader="true"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No records has been added."
                                OnRowDataBound="GV_RowDataBound" OnRowCreated="GridView1_RowCreated">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Tdate","{0:yyyy-MM-dd}")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="emp_id" HeaderText="EMP ID"/>
                                    <asp:BoundField DataField="emp_name" HeaderText="Employee Name"/>
                                    <asp:TemplateField HeaderText="DutyRoster">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("instart")+ "-" + Eval("outstart")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="" HeaderText="In Time / Out Time"/>
                                    <asp:BoundField DataField="Indiff_Hour" HeaderText="Time"/>
                                    <asp:BoundField DataField="" HeaderText="Remarks"/>
                                </Columns>
                                <EditRowStyle/>
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
                        </div>
                    </div>
                </div>
            </form>
        </div> <!-- container-->
    </div>
</asp:Content>
