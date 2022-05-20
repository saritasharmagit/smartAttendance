<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="AddWorkingHours.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.AddWorkingHours" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
  
     <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                            <li class="blue"><a href="WorkingHours.aspx">  Working Hour List</a></li>
                          
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
                  <asp:ScriptManager ID="scrManager" runat="server">
                </asp:ScriptManager>
              
                 <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                  <ContentTemplate>
                    <div class="form-group">
                        <label class="control-label col-md-2"> Group Name <span style="color:red">*</span></label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtGroupname" CssClass="form-control" runat="server"></asp:TextBox> 
                        </div>
                    </div>
                         <div class="form-group">
                        <label class="control-label col-md-2"> In Time <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtIntime" CssClass="form-control" AutoComplete="off" placeholder="Enter 24 hour format(HH:mm:ss)"  runat="server"></asp:TextBox> 
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtIntime1" CssClass="form-control" AutoComplete="off" placeholder="Enter 24 hour format(HH:mm:ss)"  runat="server"></asp:TextBox> 
                        </div>
                    </div>
                     <div class="form-group">
                        <label class="control-label col-md-2"> Out Time <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOuttime" CssClass="form-control" AutoPostBack="true" placeholder="Enter 24 hour format(HH:mm:ss)"  runat="server" OnTextChanged="txtOuttime_TextChanged"></asp:TextBox> 
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOuttime1" CssClass="form-control" AutoComplete="off" placeholder="Enter 24 hour format(HH:mm:ss)"  runat="server"></asp:TextBox> 
                        </div>
                    </div>
                  <div class="form-group">
                        <label class="control-label col-md-2"> Working Hours <span style="color: red">*</span></label>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtworking" CssClass="form-control" ReadOnly="true"  runat="server"></asp:TextBox> 
                        </div>
                          <label class="control-label col-md-2"> Minute <span style="color: red">*</span></label>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtworkingMn" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox> 
                        </div>
                          <label class="control-label col-md-2"> Lunch Time <span style="color: red">*</span></label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtLunch" CssClass="form-control" Type="number" AutoComplete="off" Text="2"  runat="server"></asp:TextBox> 
                        </div>
                     </div>
                     <div class="form-group">                                           
                        <label class="control-label col-md-3"> Night Shift <span style="color: red">*</span></label>
                        <div class="col-md-5">
                            <asp:RadioButton ID="rbNsh" GroupName="rbNsh" runat="server"/> Yes
                            <asp:RadioButton ID="rbNsh1" GroupName="rbNsh" Checked="true" runat="server"/> No
                        </div>
                    </div>
                    <div class="form-group">                                           
                        <label class="control-label col-md-3"> Default For All Weekdays <span style="color: red">*</span></label>
                        <div class="col-md-5">
                            <asp:RadioButton ID="rbdef" GroupName="rbdef" Checked="true" runat="server"/> Yes
                            <asp:RadioButton ID="rbdef1" GroupName="rbdef" runat="server"/> No
                        </div>
                    </div>
                    <div class="form-group">                                           
                        <label class="control-label col-md-3"> Status <span style="color: red">*</span></label>
                        <div class="col-md-5">
                            <asp:RadioButton ID="rbsta"  GroupName="rbsta" Checked="true" runat="server"/> Active
                            <asp:RadioButton ID="rbsta1" GroupName="rbsta" runat="server"/> InActive
                        </div>
                    </div>
                       </ContentTemplate>
            </asp:UpdatePanel>
                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click"/>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click"/>  
                    </div>
                </div>
            </form>
        </div> <!-- container -->
    </div> <!-- content -->

</asp:Content>
