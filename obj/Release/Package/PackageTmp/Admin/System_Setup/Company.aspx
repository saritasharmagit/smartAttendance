<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.Company" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">System Setup</li>
                            <li class="active">
                                Company Information List
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
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-2" runat="server" Text="ADD" OnClick="BtnNew_Click"/>
                    </div>
                </div>
                              <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive"> 
                                    <asp:GridView ID="GridView1" runat="server"
                                            Font-Size="Small"
                                            AutoGenerateColumns="False"                            
                                            CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                            EmptyDataText="No Employees Records has been added."
                                              OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
                                            <AlternatingRowStyle BackColor="White" />
                                           <Columns>
                                                  <asp:TemplateField HeaderText="S.N">
                                                    <ItemTemplate>
                                                         <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:BoundField DataField="Org_Id"/>
                                                    <asp:BoundField DataField="Org_Name" HeaderText="Name" /> 
                                                    <asp:BoundField DataField="Org_Address" HeaderText="Address" />
                                                    <asp:BoundField DataField="Org_Address2" HeaderText="Address2"/>
                                                    <asp:BoundField DataField="Org_Phone" HeaderText="Phone" />
                                                    <asp:BoundField DataField="Org_Fax" HeaderText="Fax" />
                                                    <asp:BoundField DataField="Org_Email" HeaderText="Email" />
                                                    <asp:BoundField DataField="Org_Website" HeaderText="Website" />
                                                 <asp:CommandField ShowSelectButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-primary"  SelectText="Edit" HeaderText="Action" />
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
