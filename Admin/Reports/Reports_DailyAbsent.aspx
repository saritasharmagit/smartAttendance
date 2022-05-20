﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Reports/Reports.Master" AutoEventWireup="true" CodeBehind="Reports_DailyAbsent.aspx.cs" Inherits="AttendanceKantipur.Admin.Reports.Reports_DailyAbsent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
        <div class="container">
            <div class="row">
				<div class="col-xs-12">
					<div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="blue">Attendance Reports</li>
                            <li class="active">
                                DailyAbsent Attendance Report
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
                    <div class="form-group">
                        <label class="control-label col-md-2"> Date <span style="color:red">*</span></label>
                        <div class="col-md-5">
                            <div class="input-group">
                                <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate1" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>

                            </div>
                        </div>
                        <div class="col-md-5 ">
                            <div class="input-group">
                                <asp:TextBox ID="txtStartDate"  CssClass="form-control englishDate1" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>                                      
                        </div>                                   
                    </div>
                     <%-- <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                 <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true" >
                  <ContentTemplate>
                  
                    <div class="form-group">
                        <label class="control-label col-md-2"> Employee <span style="color: red">*</span></label>
                            <div class="col-md-5">
                                <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Employee List" AutoPostBack="true"
                            EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true"  AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtEmpId" CssClass="form-control" ReadOnly="true" AutoComplete="off" runat="server" AutoPostBack="True"></asp:TextBox> 
                        </div>
                          <div class="col-sm-2">
                            <asp:CheckBox ID="Chkemp" AutoPostBack="True" runat="server" OnCheckedChanged="Chkemp_CheckedChanged"/><span class="lbl"> All Employee</span>
                        </div>   
                    </div>
                    
                </div>
              </ContentTemplate>
            </asp:UpdatePanel>--%>

                    
                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click"/>
                    </div>
                                            
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel"/>  
                    </div>
                </div>   
                          
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>
