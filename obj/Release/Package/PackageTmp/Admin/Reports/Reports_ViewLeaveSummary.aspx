<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Reports/Reports.Master" AutoEventWireup="true" CodeBehind="Reports_ViewLeaveSummary.aspx.cs" Inherits="AttendanceKantipur.Admin.Reports.Reports_ViewLeaveSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="blue">Leave Reports</li>
                            <li class="active">
                                View Leave Summary Report
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
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-2" runat="server" Text="New" OnClick="BtnNew_Click"/>
                        <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2 " runat="server" Text="Excel" OnClick="BtnExport_Click"/>
                    </div>
                   
               <asp:Panel ID="Panel1" runat="server">
                <div style="font-weight : bold;" class="col-md-6 form-group">
                    <div style="font-weight: bold; font-size: large">
                        <asp:Label ID="labelleaveSum" runat="server" Text="CEAPRED Leave Summary Report"></asp:Label>
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
                              EmptyDataText="No records has been added." OnRowDataBound="GridView1_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                               
                                <Columns>
                                
                                      <asp:BoundField DataField="emp_fullname" HeaderText="Employee Name"/>
                                     <%-- <asp:TemplateField HeaderText="Employee (ID)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("emp_fullname")+ " " +"("+ Eval("EMP_ID") +")"%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                      <asp:BoundField DataField="LEAVE_NAME" HeaderText="Leave Name"/>
                                    <asp:BoundField DataField="GIVEN" HeaderText="Given"/>
                                      <asp:BoundField DataField="TAKEN" HeaderText="Taken"/>
                                   <asp:BoundField DataField="BALANCE" HeaderText="Balance"/>
                                    
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
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>
