﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="HolidaySetup.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.HolidaySetup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                            <li class="active">
                                Holiday List
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
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-2" runat="server" Text="ADD" OnClick="BtnNew_Click" />
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
                              OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                             <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                             </ItemTemplate>
                                </asp:TemplateField>
                                             <asp:BoundField DataField="HOLIDAY_ID">
                                               <ItemStyle HorizontalAlign="Center" />
                                             </asp:BoundField>
                                               <asp:BoundField DataField="HOLIDAY_NAME" HeaderText="Holiday Name" />
                                            <asp:BoundField DataField="HOLIDAY_DATE" HeaderText="Holiday Date" DataFormatString="{0:yyyy/MM/dd}" />
                                              <asp:BoundField DataField="HOLIDAY_QTY" HeaderText="Number of Holiday" >
                                             <HeaderStyle HorizontalAlign="Center" />
                                             </asp:BoundField>
                                             <asp:BoundField DataField="holidayType"/>
                                                    <asp:BoundField DataField="Type" HeaderText="Holiday Type"/>
                                            <asp:BoundField  DataField="Female_Only" />
                                             <asp:TemplateField HeaderText="Female Only">
                                                  <ItemTemplate>
                                                       <asp:Label ID="lblFemale" runat="server" Text='<%# Eval("Female_Only").ToString() =="1" ? "Yes" : "No" %>'></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                               <asp:BoundField  DataField="sta" />
                                             <asp:TemplateField HeaderText="Status">
                                                  <ItemTemplate>
                                                       <asp:Label ID="Label1" runat="server" Text='<%# Eval("sta").ToString() =="1" ? "Active" : "InActive" %>'></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
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
