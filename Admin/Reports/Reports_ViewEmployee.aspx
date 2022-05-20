<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Reports/Reports.Master" AutoEventWireup="true" CodeBehind="Reports_ViewEmployee.aspx.cs" Inherits="AttendanceKantipur.Admin.Reports.Reports_ViewEmployee" %>
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
                                View Employee Report
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
                        <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2 " runat="server" Text="Excel" OnClick="BtnExport_Click" />
                    </div>

                       <asp:Panel ID="Panel1" runat="server">
                    <div style="font-weight:bold;" class="col-md-6">
                        <div style="font-weight: bold; font-size: large">
                            <asp:Label ID="labelEmployeeSta" runat="server" Text="CEAPRED Employee Status Report"></asp:Label>
                        </div>
                      
                    </div>
                    </asp:Panel>
                </div>
                 
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                                 <asp:GridView ID="GridView1" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added." OnRowDataBound="GridView1_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                               <Columns>
                                   <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee (ID)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Fullname")+ " " +"("+ Eval("EMP_ID") +")"%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                
                                    <asp:BoundField DataField="DEG_NAME" HeaderText="Corporate Title" />
                                    <asp:BoundField DataField="DEPT_NAME" HeaderText="Department"/>
                                    <asp:BoundField DataField="GRADE_TYPE" HeaderText="Grade"/>
                                    <asp:BoundField DataField="EMP_MOBILE" HeaderText="Mobile No"/>
                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("EMP_TDISTRICT")+ "," + Eval("EMP_TZONE")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GENDER" HeaderText="Sex"/>
                              
                                    <asp:BoundField DataField="STATUS_NAME" HeaderText="Status"/>
                                      <asp:BoundField DataField="Retired_Date" HeaderText="Date"/>
                                 <%--   <asp:BoundField DataField="MARITALSTATUS" HeaderText="MARITAL STATUS"/>--%>
                                    <asp:BoundField DataField="EMP_PEMAIL" HeaderText="Email"/> 
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
                           <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ClientIDMode="Predictable" Width="294px" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" Height="169px">
                                <Columns>
                                    <asp:BoundField DataField="EMP_ID" HeaderText="Emp Id" />
                                    <asp:BoundField DataField="emp_Fullname" HeaderText="Full Name" />
                                    <asp:BoundField DataField="DEG_NAME" HeaderText="Corporate Title" />
                                    <asp:BoundField DataField="DEPT_NAME" HeaderText="Department"/>
                                    <asp:BoundField DataField="GRADE_TYPE" HeaderText="Grade"/>
                                    <asp:BoundField DataField="EMP_MOBILE" HeaderText="Mobile No"/>
                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("EMP_TADD")+ "," + Eval("EMP_TSTREET")+ "," + Eval("EMP_TDISTRICT")+ "," + Eval("EMP_TZONE")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GENDER" HeaderText="Sex"/>
                                    <asp:BoundField DataField="STATUS_ID" HeaderText="Status"/>
                                    <asp:BoundField DataField="MARITALSTATUS" HeaderText="Married"/>
                                    <asp:BoundField DataField="EMP_PEMAIL" HeaderText="Email"/> 
                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
                            </asp:GridView>--%>
                        
                        </div>
                    </div>
                </div>
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>
