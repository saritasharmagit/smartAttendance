<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AttendanceKantipur.User.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="active">Dashboard
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
                            <h2 class="text-white"><span data-plugin="counterup"><asp:Label ID="countBranch" runat="server"></asp:Label></span></h2>
                        </div>
                    </div>
                </div><!-- end col -->

                <div class="col-lg-3 col-md-6">
                    <div class="card-box widget-box-two widget-two-primary">
                        <i class="mdi mdi-layers widget-two-icon"></i>
                        <div class="wigdet-two-content text-white">
                            <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="User This Month">Departments</p>
                            <h2 class="text-white"><span data-plugin="counterup"><asp:Label ID="countDepartment" runat="server"></asp:Label></span></h2>
                        </div>
                    </div>
                </div><!-- end col -->

                <div class="col-lg-3 col-md-6">
                    <div class="card-box widget-box-two widget-two-danger">
                        <i class="mdi  mdi-gender-male widget-two-icon"></i>
                        <div class="wigdet-two-content text-white">
                            <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="Statistics">Female Employees</p>
                            <h2 class="text-white"><span data-plugin="counterup"><asp:Label ID="countEmployeeFemale" runat="server"></asp:Label></span></h2>
                        </div>
                    </div>
                </div><!-- end col -->

                <div class="col-lg-3 col-md-6">
                    <div class="card-box widget-box-two widget-two-success">
                        <i class="mdi mdi-gender-female widget-two-icon"></i>
                        <div class="wigdet-two-content text-white">
                            <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="User Today">Male Employees</p>
                            <h2 class="text-white"><span data-plugin="counterup"><asp:Label ID="countEmployeeMale" runat="server"></asp:Label> </span> </h2>
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
                    </div>
                    <!-- end panel -->
                </div>
                <!-- end col -->
                <div class="col-md-6">
                    <div class="panel panel-color panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">Birthdays</h3>
                        </div>
                        <div class="panel-body">
                            <div class="inbox-widget slimscroll-alt" style="min-height: 327px;">
                                <asp:Label ID="birthdays" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <!-- end panel -->
                </div>
            </div>
            <!-- end row -->
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>

