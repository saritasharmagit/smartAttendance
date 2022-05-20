<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Events/Event.Master" AutoEventWireup="true" CodeBehind="EditEvent.aspx.cs" Inherits="AttendanceKantipur.Admin.Events.EditEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
 <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="Dashboard.aspx">Home</a></li>
                            <li class="blue"><a href="Event.aspx">Event List</a></li>
                            <li class="active">
                                Edit Event
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
                <div class="well">
                    <asp:TextBox ID="txtEventid" CssClass="form-control hidden" runat="server"></asp:TextBox>
                        <div class="form-group">
                        <label class="control-label col-md-2"> Date <span style="color:red">*</span></label>
                        <div class="col-md-3">
                            <div class="input-group">
                                <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate1" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group">
                                <asp:TextBox ID="txtStartDate"  CssClass="form-control englishDate1" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>                                      
                        </div>                                   
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2"> Title <span style="color:red">*</span></label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtTitle" CssClass="form-control" AutoComplete="off"  runat="server"></asp:TextBox> 
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2"> Description <span style="color: red">*</span></label>
                        <div class="col-md-10">
                          
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdescription" TextMode="Multiline" Columns="20" Name="S1" Rows="2" Height="40px" Width="258px"></asp:TextBox>
                        </div>
                      
                    </div>
                
                </div>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnUpdate" CssClass="btn btn-success col-md-12" runat="server" Text="Update" OnClick="BtnUpdate_Click"/>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel"/>  
                    </div>
                </div>
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>

