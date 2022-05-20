<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OutStation/OutStation.Master" AutoEventWireup="true" CodeBehind="Outstation.aspx.cs" Inherits="AttendanceKantipur.Admin.OutStation.Outstation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="active">
                                Outstation List
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
                                EmptyDataText="No Employees Records has been added." OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Employee (ID)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("emp_Fullname")+ " " +"("+ Eval("EMP_ID") +")"%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:BoundField DataField="emp_Fullname" HeaderText="Employee Name"/>
                                    <asp:BoundField DataField="EMP_ID" HeaderText="Emp ID"/>--%>
                                     <asp:BoundField DataField="STATION" HeaderText="Location"/>
                                    <asp:BoundField DataField="SDATE" HeaderText="Start Date" DataFormatString="{0:yyyy/MM/dd}"/>
                                       <asp:BoundField DataField="EDATE" HeaderText="End Date" DataFormatString="{0:yyyy/MM/dd}"/>
                                     <asp:BoundField DataField="DAYS" HeaderText="Days"/>
                                   
                                       <asp:BoundField DataField="VNO" HeaderText="VNO"/>
                                      <asp:BoundField DataField="PURPOSE" HeaderText="Journey Of Purpose"/>
                                   
                                     <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Edit" ControlStyle-CssClass="btn btn-primary"  HeaderText="Action" />  
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
    </div> <!-- content -->
</asp:Content>
