<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AttendanceKantipur.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Avighna Attendance</title>
    <!-- App favicon -->
    <link rel="shortcut icon" href="Assets/images/favicon.ico"/>
    <!-- App css -->
    <link href="Assets/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="Assets/css/core.css" rel="stylesheet"/>
    <link href="Assets/css/icons.css" rel="stylesheet"/>
    <link href="Assets/css/menu.css" rel="stylesheet"/>
    <link href="Assets/css/components.css" rel="stylesheet"/>
    <link href="Assets/css/pages.css" rel="stylesheet"/>
    <link href="Assets/css/responsive.css" rel="stylesheet"/>
    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
    <script src="Assets/js/modernizr.min.js"></script>
    <!-- Sweet Alert-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/2.1.0/sweetalert.min.js"></script>

</head>
<body>
    <!-- HOME -->
   <section>
            <div class="container-alt">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="wrapper-page">
                            <div class="m-t-40 account-pages">
                                <div class="text-center account-logo-box">
                                    <h2 class="text-uppercase">
                                        <a href="index.html" class="text-success">
                                            <span><img src="Assets/images/sm.png" alt="" height="36"/></span>
                                        </a>
                                    </h2>
                                </div>
                                <div class="account-content">
                                    <form class="form-horizontal" runat="server">
                                        <div class="form-group ">
                                            <div class="col-xs-12">
                                                <asp:TextBox ID="TxtUserName" CssClass="form-control" placeholder="Id" runat="server" ToolTip="Enter UserName" AutoComplete="off"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-xs-12">
                                                <asp:TextBox ID="TxtPassword" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password" ToolTip="Enter Password"></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                        <div class="form-group account-btn text-center m-t-10">
                                            <div class="col-xs-12">
                                                <asp:Button ID="BtnLogin" CssClass="btn w-md btn-bordered btn-success waves-light" runat="server" Text="Log In" OnClick="BtnLogin_Click" />
                                            </div>
                                        </div>
                                    </form>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <!-- end card-box-->
                        </div>
                        <!-- end wrapper -->
                    </div>
                </div>
            </div>
        </section>
        <!-- END HOME -->
    <script>
        var resizefunc = [];
    </script>
    <script src="Assets/js/waves.js"></script>
    <script src="Assets/js/jquery.slimscroll.js"></script>
    <script src="Assets/js/jquery.scrollTo.min.js"></script>
    <script src="Assets/js/jquery.min.js"></script>
    <script src="Assets/js/jquery.blockUI.js"></script>
    <script src="Assets/js/fastclick.js"></script>
    <script src="Assets/js/detect.js"></script>
    <script src="Assets/js/bootstrap.min.js"></script>
</body>
</html>
