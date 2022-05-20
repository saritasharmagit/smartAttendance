<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OutStation/OutStation.Master" AutoEventWireup="true" CodeBehind="EditOutstation.aspx.cs" Inherits="AttendanceKantipur.Admin.OutStation.EditOutstation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                           <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                            <li class="blue"><a href="Outstation.aspx">Outstation List</a></li>
                            <li class="active">
                                Edit OutStation
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
                        <label class="control-label col-md-2"> Travel ID </label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtTravelid" ReadOnly="true" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox> 
                        </div>
                    </div>
                    <asp:HiddenField ID="HiddenField1" runat="server" />

                    
                    
                     <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                      <div class="form-group">
                        <label class="control-label col-md-2"> Employee Name <span style="color:red">*</span></label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="CmbEmployee" ReadOnly="true" CssClass="form-control" runat="server" CausesValidation="True" AutoPostBack="true" ToolTip="Employee List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item"></asp:DropDownList>
                        </div>
                           <label class="control-label col-md-2"> Employee Id </label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtemployeeid" ReadOnly="true" CssClass="form-control" Type="number" AutoComplete="off" runat="server"></asp:TextBox> 
                        </div>
                    </div>
                         </ContentTemplate>
                    </asp:UpdatePanel>
                       <div class="form-group">
                       
                             <label class="control-label col-md-2"> Location/Site </label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtlocation" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox> 
                        </div>
                    </div>
                  
                   <div class="form-group">
                        <label class="control-label col-md-2"> Start Date  <span style="color:red">*</span></label>
                       
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
                        <label class="control-label col-md-2"> End Date <span style="color:red">*</span></label>
                      
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
                        <label class="control-label col-md-2"> Purpose of Journey </label>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtdescription" TextMode="Multiline" Columns="20" Name="S1" Rows="2"></asp:TextBox>
                        </div>
                    </div>
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                   <div class="form-group">
                        <label class="control-label col-md-2">Approval <span style="color:red">*</span></label>
                        <div class="col-md-3">
                             <asp:DropDownList ID="CmbApproval" AutoPostBack="true" CssClass="form-control" runat="server" CausesValidation="True"  ToolTip="Employee List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbApproval_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                     
                      <%--  <label class="control-label col-md-2"> No. of Days <span style="color:red">*</span></label>--%>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtdays" Visible="false"  CssClass="form-control" Type="number" AutoComplete="off" runat="server"></asp:TextBox> 
                        </div>
                    </div>
                         </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                            <label class="control-label col-md-2">Status <span style="color:red">*</span></label>
                            <div class="col-md-2">
                                <asp:RadioButton ID="rbStatus"  runat="server" Text="Active" GroupName="rbStatus" />
                                 <asp:RadioButton ID="rbInActive" runat="server" Text="InActive" GroupName="rbStatus" />
                            </div>                                                                                  
                        </div>
                </div>

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
