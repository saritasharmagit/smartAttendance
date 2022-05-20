<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Reports/Reports.Master" AutoEventWireup="true" CodeBehind="Reports_Employee.aspx.cs" Inherits="AttendanceKantipur.Admin.Reports.Reports_Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

  <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="active">Employee Report
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->

            <div class="panel-heading">
                <h3 class="panel-title" style="color: red;">* Denotes Mandatory Fields</h3>
            </div>

            <form runat="server" role="form" class="form-horizontal">
              
                <div class="form-group">
                    <label class="control-label col-md-2">Status <span style="color:red";>*</span></label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="CmbStatus" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Status List" AutoPostBack="false" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group" id="hidedatetype" hidden="hidden">
                    <label class="control-label col-md-2">Date Type <span style="color:red";>*</span></label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="CmbDatetype" AutoPostBack="false" CssClass="form-control" runat="server">
                            <asp:ListItem Value="">Select Date Type</asp:ListItem>
                            <asp:ListItem Value="1">Yearly</asp:ListItem>
                            <asp:ListItem Value="2">Half Yearly</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group" id="hideYear" hidden="hidden">
                    <label class="control-label col-md-2">Year <span style="color: red">*</span></label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="CmbYear" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div id="hideHalfYear" hidden="hidden">
                    <div class="form-group">
                        <label class="control-label col-md-2">Date <span style="color: red">*</span></label>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">From </label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate1" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtStartDate" CssClass="form-control englishDate1" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2">To </label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txttonepdate" CssClass="form-control nepaliDate2" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txttoengdate" CssClass="form-control englishDate2" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                    </div>
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
     <script>
         $(document).ready(function () {

             $('#<%=CmbStatus.ClientID%>').on('change', function (e) {

                 if ($('#<%=CmbStatus.ClientID%>').val() == 0) { 
                   
                    if ($('#<%=CmbDatetype.ClientID%>').val() == 1)
                    {
                        $('#hideYear').show();
                        $('#hideHalfYear').hide();
                       
                    }
                    else {
                        $('#hideYear').show();
                        $('#hideHalfYear').show();
                        $('#hidedatetype').show();
                    }
                  
                 }
                 if ($('#<%=CmbStatus.ClientID%>').val() == 0) {

                  
                     $('#hideHalfYear').hide();
                     $('#hideYear').hide();
                 }
                if ($('#<%=CmbStatus.ClientID%>').val() == 1) {

                    $('#hidedatetype').hide();
                    $('#hideHalfYear').hide();
                    $('#hideYear').hide();
                }
                
                 if ($('#<%=CmbStatus.ClientID%>').val() == 2) {

                     if ($('#<%=CmbDatetype.ClientID%>').val() == 1)
                     {
                         $('#hidedatetype').show();
                         $('#hideYear').show();
                         $('#hideHalfYear').hide();
                     }
                     else {
                         $('#hidedatetype').show();
                         $('#hideHalfYear').show();
                         $('#hideYear').hide();
                     }
                   
                 }
                 if ($('#<%=CmbStatus.ClientID%>').val() == 3) {
                     if ($('#<%=CmbDatetype.ClientID%>').val() == 1)
                     {
                         $('#hidedatetype').show();
                         $('#hideYear').show();
                         $('#hideHalfYear').hide();
                     }
                     else {
                         $('#hidedatetype').show();
                         $('#hideHalfYear').show();
                         $('#hideYear').hide();
                     }
                    
                 }
                 if ($('#<%=CmbStatus.ClientID%>').val() == 5) {
                     if ($('#<%=CmbDatetype.ClientID%>').val() == 1)
                     {
                         $('#hidedatetype').show();
                         $('#hideYear').show();
                         $('#hideHalfYear').hide();
                     }
                     else {
                         $('#hidedatetype').show();
                         $('#hideHalfYear').show();
                         $('#hideYear').hide();
                     }
                    
                 }
                 if ($('#<%=CmbStatus.ClientID%>').val() == 6) {
                     if ($('#<%=CmbDatetype.ClientID%>').val() == 1)
                     {
                         $('#hidedatetype').show();
                         $('#hideYear').show();
                         $('#hideHalfYear').hide();
                     }
                     else {
                         $('#hidedatetype').show();
                         $('#hideHalfYear').show();
                         $('#hideYear').hide();
                     }
                    
                 }
            })
        })
    </script>

      <script>
          $(document).ready(function () {

              $('#<%=CmbDatetype.ClientID%>').on('change', function (e) {

                if ($('#<%=CmbDatetype.ClientID%>').val() == 1) {

                    $('#hideYear').show();
                    $('#hideHalfYear').hide();
                }
                if ($('#<%=CmbDatetype.ClientID%>').val() == 2) {

                    $('#hideHalfYear').show();
                    $('#hideYear').hide();
                }
            })
        })
    </script>
</asp:Content>

