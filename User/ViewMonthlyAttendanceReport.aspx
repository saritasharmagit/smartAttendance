<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ViewMonthlyAttendanceReport.aspx.cs" Inherits="AttendanceKantipur.User.ViewMonthlyAttendanceReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="blue">Attendance Reports</li>
                            <li class="blue">Monthly Attendance Report</li>
                            <li class="active">View Monthly Attendance Report
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
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-2" runat="server" Text="Back" OnClick="BtnNew_Click" />
                        <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2" runat="server" Text="Excel" OnClick="BtnExport_Click" />
                    </div>
                      <asp:Panel ID="panel2" runat="server">
                            <div style="font-weight : bold;" class="col-md-6 form-group">
                    <div style="font-weight: bold; font-size: large">
                        <asp:Label ID="labelmonthly" runat="server" Text="CEAPRED Monthly Attendance Report"></asp:Label>
                    </div>
                        </div>
                    <div style="font-weight: bold;" class="col-md-6 form-group">
                        From :
                            <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                        To :
                            <asp:Label ID="lblEndDate" runat="server" Text="Label"></asp:Label>
                    </div>
             
                    <div class="col-md-12 form-group" style="font-weight: bold;">
                        <div class="col-md-6">
                            Employee :
                            <asp:Label ID="lblEmployee" runat="server" Text=""></asp:Label>
                            (<asp:Label ID="lblEmployeeID" runat="server" Text=""></asp:Label>)
                        </div>

                    </div>
                </asp:Panel>
                  </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server"
                                Font-Size="Small" ShowHeader="False"
                                AutoGenerateColumns="False"
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No records has been added." OnRowCreated="GridView1_RowCreated">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Employee (ID)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Fullname")+ " " +"("+ Eval("EMP_ID") +")"%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TotalDays" HeaderText="TotalDays" />
                                    <asp:BoundField DataField="Weekend" HeaderText="Weekend" />
                                     <asp:BoundField DataField="PH" HeaderText="Public Holiday" />
                                    <asp:BoundField DataField="WorkingDay" HeaderText="WorkingDay" />
                                     <asp:BoundField DataField="AbsentDays" HeaderText="Absent Days" />

                                    <asp:BoundField DataField="HL" HeaderText="Home" />
                                      <asp:BoundField DataField="SL" HeaderText="Sick" />
                                       <asp:BoundField DataField="KL" HeaderText="Kriya" />
                                      <asp:BoundField DataField="ML" HeaderText="Maternity" />
                                      <asp:BoundField DataField="PL" HeaderText="Paternity" />
                                      <asp:BoundField DataField="FL" HeaderText="Festival" />

                                    <asp:BoundField DataField="LeaveDays" HeaderText="Total Leave Days" />
                                      <asp:BoundField DataField="PresentDays" HeaderText="Present Days" />
                                      <asp:BoundField DataField="WOW" HeaderText="Worked On Weekend" />
                                      <asp:BoundField DataField="WOPH" HeaderText="Worked On PH" />
                                      <asp:BoundField DataField="TotalPresentDays" HeaderText="Total Present Days" />


                                      <asp:BoundField DataField="TotalWHrs" HeaderText="Worked Hours" />
                                     <asp:BoundField DataField="assigned_Hrs" HeaderText="Assigned Hours" />
                                    <asp:BoundField DataField="OT" HeaderText="Difference" />
                                </Columns>
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
                        </div>
                    </div>
                    <div class="col-md-12">
                        <asp:Panel ID="pnlNote" runat="server">
                            <div class="form-group">
                                <div class="col-md-5">
                                    Total Days - Weekends - Public Holiday = Working Days
                                </div>
                            </div>
                            <div class="form-group">
                                Working Days - Absent Days - Total Leave = Present Days
                            </div>
                            <div class="form-group">
                                Present Days + Worked on Weekends + Worked on Public Holidays = Total Present Days
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>