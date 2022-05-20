<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="AddBranch.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.AddBranch" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                             <li class="blue">Home</li>
                            <li class="blue"><a href="BranchSetup.aspx">Project List</a></li>
                            <li class="active">
                                Add New Project
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
                    <asp:TextBox ID="BRANCH_ID" CssClass="form-control hidden" runat="server"></asp:TextBox>
                    <div class="form-group">
                        <label class="control-label col-md-2"> Project Code <span style="color:red">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="BRANCH_CODE" CssClass="form-control" AutoComplete="off"  runat="server"></asp:TextBox> 
                        </div>
                    </div>
                      <div class="form-group">
                        <label class="control-label col-md-2">Abbreviation <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAbbr" CssClass="form-control" AutoComplete="off"  runat="server"></asp:TextBox> 
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-2"> Project Name <span style="color: red">*</span></label>
                        <div class="col-md-8">
                            <asp:TextBox ID="BRANCH_NAME" CssClass="form-control" AutoComplete="off"  runat="server"></asp:TextBox> 
                        </div>
                    </div>
                      <div class="form-group">
                        <label class="control-label col-md-2"> Valid From <span style="color:red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate1"  AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtStartDate"  CssClass="form-control englishDate1" AutoComplete="off"  placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>                                      
                        </div>                                   
                    </div>
                       <div class="form-group">
                        <label class="control-label col-md-2"> Valid To <span style="color:red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate2"  autocomplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtEndDate" CssClass="form-control englishDate2"  AutoComplete="off" placeholder="English Date"  runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>                                       
                        </div>                                            
                    </div> 
                    <div class="form-group">                                           
                        <label class="control-label col-md-2"> Status <span style="color: red">*</span></label>
                        <div class="col-md-5">
                            <asp:RadioButton ID="rbsta" Checked="true" GroupName="rbsta" runat="server"/> Active
                            <asp:RadioButton ID="rbsta1" GroupName="rbsta" runat="server"/> InActive
                        </div>
                    </div>
                </div>

                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click"/>  
                    </div>
                </div>
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>
