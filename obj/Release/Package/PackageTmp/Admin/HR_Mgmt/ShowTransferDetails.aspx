<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/HR_Mgmt/HR.Master" AutoEventWireup="true" CodeBehind="ShowTransferDetails.aspx.cs" Inherits="AttendanceKantipur.Admin.HR_Mgmt.ShowTransferDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="Dashboard.aspx">Home</a></li>
                            <li class="blue"><a href="Transfer.aspx">Transfer List</a></li>
                            <li class="active">View Transfer Details
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
                        <asp:Button ID="btnBack" CssClass="btn btn-success col-md-2" runat="server" Text="Back" OnClick="btnBack_Click"/>
                    </div>
                </div>
              
                <div class="col-md-12">
                   
                    <h3 style="color: darkblue;">Transfer Details</h3>
                      <div class="col-md-12">
                          <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:GridView ID="grvTransfer" runat="server"
                        Font-Size="Small"
                        AutoGenerateColumns="False"
                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Emp_id" HeaderText="Employee Id"/>
                            <asp:BoundField DataField="Fullname" HeaderText="Employee Name"/>
                            <asp:BoundField DataField="BRANCH_NAME" HeaderText="Current Project"/>
                            <asp:BoundField DataField="branch_name_from" HeaderText="Previous Project"/>
                            <asp:BoundField DataField="dept_name_to" HeaderText="Current Department"/>
                            <asp:BoundField DataField="dept_name_from" HeaderText="Previous Department"/>
                              <asp:BoundField DataField="District_To" HeaderText="Current District"/>
                            <asp:BoundField DataField="District_from" HeaderText="Previous District"/>
                             <asp:BoundField DataField="Desg_To" HeaderText="Current Designation"/>
                              <asp:BoundField DataField="Desg_From" HeaderText="Previous Designation"/>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
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
             
            </form>
        </div>
        <!-- container -->
    </div>
</asp:Content>
