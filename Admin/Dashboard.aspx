<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Dashboard.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AttendanceKantipur.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
				<div class="col-xs-12">
					<div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="active">
                                Dashboard
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
				</div>
			</div>
            <!-- end row -->
            <div class="row">
                <div class="col-lg-3 col-md-6">
                    <div class="card-box widget-box-two widget-two-info">
                        <i class="mdi mdi-bank widget-two-icon"></i>
                        <div class="wigdet-two-content text-white">
                            <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="Branch">Projects</p>
                            <h2 class="text-white"><span data-plugin="counterup"><asp:Label ID="Branch" runat="server"></asp:Label></span></h2>
                        </div>
                    </div>
                </div><!-- end col -->

                <div class="col-lg-3 col-md-6">
                    <div class="card-box widget-box-two widget-two-primary">
                        <i class="mdi mdi-layers widget-two-icon"></i>
                        <div class="wigdet-two-content text-white">
                            <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="User This Month">Departments</p>
                            <h2 class="text-white"><span data-plugin="counterup"><asp:Label ID="Department" runat="server"></asp:Label></span></h2>
                        </div>
                    </div>
                </div><!-- end col -->

                <div class="col-lg-3 col-md-6">
                    <div class="card-box widget-box-two widget-two-danger">
                        <i class="mdi  mdi-gender-male widget-two-icon"></i>
                        <div class="wigdet-two-content text-white">
                            <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="Statistics">Female Employees</p>
                            <h2 class="text-white"><span data-plugin="counterup"><asp:Label ID="FemleEmployee" runat="server"></asp:Label></span></h2>
                        </div>
                    </div>
                </div><!-- end col -->

                <div class="col-lg-3 col-md-6">
                    <div class="card-box widget-box-two widget-two-success">
                        <i class="mdi mdi-gender-female widget-two-icon"></i>
                        <div class="wigdet-two-content text-white">
                            <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="User Today">Male Employees</p>
                            <h2 class="text-white"><span data-plugin="counterup"><asp:Label ID="MaleEmployee" runat="server"></asp:Label> </span> </h2>
                        </div>
                    </div>
                </div><!-- end col -->
            </div>
            &nbsp;
            <div class="row">
                <div class="col-lg-6">
                    <div class="panel panel-color panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">Events</h3>
                        </div>
                        <div class="panel-body">
                            <div class="inbox-widget slimscroll-alt" style="min-height: 327px;">
                                   <asp:Label ID="Events" runat="server"></asp:Label>
                              
                            </div>
                        </div>
                    </div><!-- end panel -->
                </div><!-- end col -->
                <div class="col-md-6">
                    <div class="panel panel-color panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">Birthdays</h3>
                        </div>
                        <div class="panel-body">
                            <div class="inbox-widget slimscroll-alt" style="min-height: 327px;">
                                <asp:Label ID="birthdays" runat="server"></asp:Label>
                                 <form runat="server" role="form" class="form-horizontal">
                                    <%--  <asp:Image ID="PersImage" runat="server" style="height: 50px; width: 50px ;border-style: ridge; border-width: 5px ;" />--%>
                               <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="484px">
                                    <Columns>
                                        <asp:BoundField DataField="Employee Name" HeaderText="Employee Name" />
                                        <asp:BoundField DataField="Birthday" HeaderText="Birthday" />
                                        <asp:BoundField DataField="Dept_name" HeaderText="Department" />
                                        <asp:BoundField DataField="Message" HeaderText="Message" />
                                    </Columns>

                                </asp:GridView>--%>
                                  </form>  
                            </div>
                        </div>
                    </div>
                    <!-- end panel -->
                </div>
            </div>
            <!-- end row -->
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>
