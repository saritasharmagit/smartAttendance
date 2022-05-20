<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ViewQuickAttendance.aspx.cs" Inherits="AttendanceKantipur.User.ViewQuickAttendance" %>
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
                            <li class="blue">Quick Attendance</li>
                            <li class="active">View Quick Attendance Report
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
                    <asp:Panel ID="panel1" runat="server">
                        <div style="font-weight: bold;" class="col-md-6 form-group">
                            <div style="font-weight: bold; font-size: large">
                                <asp:Label ID="labelquick" runat="server" Text="CEAPRED Quick Attendance Report"></asp:Label>
                            </div>
                        </div>
                        <div style="font-weight: bold;">
                            From :
                                <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                            To :
                                <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>

                        </div>

                        <div style="font-weight: bold;">
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
                                OnRowCreated="gvEmployee_RowCreated"
                                Font-Size="Small" ShowHeader="False"
                                AutoGenerateColumns="False"
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No records has been added."
                                OnRowDataBound="GridView1_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                           
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Tdate","{0:dd}")+ "," + Eval("Shift")+ "<br>"%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                  <%--  <asp:BoundField DataField="Duty_roster" HeaderText="Duty Roster"/>--%>
                                    <asp:BoundField DataField="Intime" HeaderText="InTime"/>

                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Inremark") %>'></asp:Label>
                                       </ItemTemplate>                                       
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Indiff" HeaderText="Difference"/>
                                    <asp:BoundField DataField="Inmode" HeaderText="Mode"/>
                                    <asp:BoundField DataField="Outtime" HeaderText="Out Time"/>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOutRemarks" runat="server" Text='<%#Eval("Outremark") %>'></asp:Label>
                                       </ItemTemplate>                                       
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Outdiff" HeaderText="Difference"/>
                                    <asp:BoundField DataField="Outmode" HeaderText="Mode"/>
                                    <asp:BoundField DataField="worked_hrs" HeaderText="Worked Hour" />
                                      
                                     <asp:BoundField DataField="Remarks" HeaderText="Remarks"/>
                                   <asp:BoundField DataField="flag"/>
                                     <asp:BoundField DataField="Emp_Id"/>
                                
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
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>