<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="WorkingHours.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.WorkingHours" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
            <div class="container">
                <div class="row">
					<div class="col-xs-12">
						<div class="page-title-box">
                            <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                            <li class="active">
                               Working Hour List
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
                       <asp:Button ID="btnworking" CssClass="btn btn-primary col-md-2" runat="server" Text="ADD" OnClick="btnworking_Click"/>
                      
                    </div>
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
                                            <asp:BoundField DataField="Group_ID" HeaderText="WORK ID"/>
                                            <asp:BoundField DataField="Group_Name" HeaderText="Group Name"/>
                                            <asp:BoundField DataField="IN_START" HeaderText="Start Time"/>
                                            <asp:BoundField DataField="IN_END" HeaderText="Late In By"/>
                                            <asp:BoundField DataField="WORK_HOUR" HeaderText="Total Hour"/>
                                            <asp:BoundField DataField="LUNCHTIME" HeaderText="Lunch Time"/>
                                            <asp:BoundField DataField="OUT_START" HeaderText="End Time"/>
                                            <asp:BoundField DataField="OUT_END" HeaderText="Late Out By"/>
                                          <%--  <asp:BoundField DataField="IS_DEFAULTSHIFT" HeaderText="Default Shift"/>--%>
                                         <asp:TemplateField HeaderText="Shift">
                                                  <ItemTemplate>
                                                      <asp:Label ID="lbl" runat="server" Text='<%# Eval("IS_NIGHTSHIFT").ToString() =="True" ? "Night" : "Day" %>'></asp:Label>
                                                 </ItemTemplate>
                                            </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Status">
                                                  <ItemTemplate>
                                                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("status").ToString() =="1" ? "Active" : "InActive" %>'></asp:Label>
                                                 </ItemTemplate>
                                            </asp:TemplateField>
                                       
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
