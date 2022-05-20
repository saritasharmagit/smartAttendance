 <%@ Page Title="" Language="C#" MasterPageFile="~/Admin/HR_Mgmt/HR.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="AttendanceKantipur.Admin.HR_Mgmt.Employees" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
  
     <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">HR Management </h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="active">Employees List
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
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-2" runat="server" Text="ADD" OnClick="BtnNew_Click1" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <table id="datatable" class="table table-striped table-bordered table-hover table-responsive table-colored table-primary">
                            <thead>
                                <tr>
                                    <th>S.no  </th>
                                    <th>Full Name (ID) </th>
                                    <th>Designation </th>
                                    <th>Grade </th>
                                    <th>Department </th>
                                    <th>Branch</th>
                                    <th>Status </th>
                                    <th>Actions </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="tableBody" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
     

   <%--   <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="active">
                                Employees List
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
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-2" runat="server" Text="ADD" OnClick="BtnNew_Click1" />
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
                                OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                                <AlternatingRowStyle BackColor="White" />
                        
                                <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:BoundField DataField="emp_Fullname" HeaderText="Employee Name"/>
                                     <asp:BoundField DataField="EMP_ID" HeaderText="EMP ID"/>
                                    <asp:BoundField DataField="DEG_NAME" HeaderText="Designation"/>
                                    <asp:BoundField DataField="DEPT_NAME" HeaderText="Department"/>
                                   
                                    <asp:BoundField DataField="BRANCH_NAME" HeaderText="Project"/>
                                    <asp:BoundField DataField="STATUS_NAME" HeaderText="Status"/>

                                  
                                      <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="View Details" ControlStyle-CssClass="btn btn-primary"  HeaderText="Action" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF"/>
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
    </div>--%> <!-- content -->
</asp:Content>
