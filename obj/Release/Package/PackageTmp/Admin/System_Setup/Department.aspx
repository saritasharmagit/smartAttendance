<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.Department" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
        <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                     
                            <li class="active">
                                Department List
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
			    </div>
		    </div>
            <!-- end row -->
            <form runat="server" role="form" class="form-horizontal">
                    <div class="well col-md-6">
                <div class="form-group">
                    <div class="col-md-6 button-list">
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-3" runat="server" Text="ADD" OnClick="BtnNew_Click" />
                         <%-- <asp:Button ID="btnBack" CssClass="btn btn-primary col-md-3" runat="server" Text="Back" OnClick="btnBack_Click1"/>--%>
                    </div>
                   
                </div>
                        <div class="table-responsive">
                               <asp:GridView ID="GridView2" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added."
                                 OnSelectedIndexChanged="GridView2_SelectedIndexChanged1" OnRowDataBound="GridView2_RowDataBound" OnRowCommand="GridView2_RowCommand" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                                <AlternatingRowStyle BackColor="White"/>
                                <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="DEPT_ID" HeaderText="Department ID"/>
                                    <%--  <asp:BoundField DataField="DEPT_PARENT" HeaderText="Department "/>--%>
                                    <asp:BoundField DataField="DEPT_NAME" HeaderText="Department Name"/>
                                   
                                      <asp:BoundField DataField="sta"/>
                                     <asp:TemplateField HeaderText="Status">
                                                  <ItemTemplate>
                                                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("sta").ToString() =="1" ? "Active" : "InActive" %>'></asp:Label>
                                                 </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:ButtonField HeaderText="" CommandName="Edit" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Edit" >
                                    <ControlStyle CssClass=" btn btn-primary"></ControlStyle>
                                     <ItemStyle HorizontalAlign="Center" />
                                     </asp:ButtonField>
                                     <asp:ButtonField HeaderText="" CommandName="Section" Text="Section"  ControlStyle-CssClass="btn btn-info"  ButtonType="Button" >
                                   
                                    <ControlStyle CssClass="btn btn-info"></ControlStyle>
                                     <ItemStyle HorizontalAlign="Center" />
                                     </asp:ButtonField>
                                   
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
                            <div class="col-md-6">
                               <asp:Label ID="lblid" Visible="false" runat="server"  Text="Label"></asp:Label>
                            <asp:Label ID="lblname" Visible="false" runat="server"  Text="Label"></asp:Label>
                             <div style="font-weight:bold;" class="col-md-12 form-group">
                        <div class="col-md-8">
                             <asp:Label ID="lblDept" CssClass="control-label col-md-8" runat="server" Text=""></asp:Label>
                             </div>
                         </div>
                       <asp:GridView ID="GridView1" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added."  OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="DEPT_ID" HeaderText="Department ID"/>
                                      <asp:BoundField DataField="DEPT_PARENT" HeaderText="Department Parent "/>
                                    <asp:BoundField DataField="DEPT_NAME" HeaderText="Section Name"/>
                                   
                                      <asp:BoundField DataField="sta"/>
                                     <asp:TemplateField HeaderText="Status">
                                                  <ItemTemplate>
                                                      <asp:Label ID="Label1" runat="server" Text='<%# Eval("sta").ToString() =="1" ? "Active" : "InActive" %>'></asp:Label>
                                                 </ItemTemplate>
                                     </asp:TemplateField>
                                      <asp:CommandField ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-primary"  SelectText="Edit" HeaderText="Action" >

                                     <ItemStyle HorizontalAlign="Center" />
                                     </asp:CommandField>
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
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>


