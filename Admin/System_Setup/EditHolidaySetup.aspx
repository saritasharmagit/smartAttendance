<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="EditHolidaySetup.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.EditHolidaySetup" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
            <div class="container">
                <div class="row">
					<div class="col-xs-12">
						<div class="page-title-box">
                         
                            <ol class="breadcrumb p-0 m-0">
                                <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                                <li class="blue"><a href="HolidaySetup.aspx">Holiday List</a></li>
                                <li class="active">
                                     Edit Holiday
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
                          <asp:TextBox ID="HOLIDAY_ID" runat="server" Visible="False"></asp:TextBox>
                         <div class="form-group">
                            <label class="control-label col-md-2"> Holiday Date <span style="color:red">*</span></label>
                           <%-- <div class="col-md-3">
                                <asp:TextBox ID="txtHolidaydate" CssClass="form-control"  runat="server"></asp:TextBox> 
                            </div>--%>
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
                            <label class="control-label col-md-2"> Holiday Name <span style="color: red">*</span></label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtHolidayname" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>
                         </div> 
                         <div class="form-group">
                            <label class="control-label col-md-2">Holiday Type <span style="color:red">*</span></label>
                            <div class="col-md-6">
                                <asp:RadioButton ID="rbStandard" Checked="true" runat="server" Text="Standard" GroupName="rbHolidayType" OnCheckedChanged="rbStandard_CheckedChanged" />
                                 <asp:RadioButton ID="rbSpecific" runat="server" Text="Specific" GroupName="rbHolidayType" OnCheckedChanged="rbSpecific_CheckedChanged" />
                                <asp:RadioButton ID="rbUnofficial" runat="server" Text="UnOfficial" GroupName="rbHolidayType" OnCheckedChanged="rbUnofficial_CheckedChanged"/>
                            </div>                                                                                  
                        </div>
                         <div class="form-group">
                            <label class="control-label col-md-2"> Female Only</label>
                            <div class="col-md-3">
                                <asp:CheckBox ID="chkFemale" runat="server" />
                            </div>
                         </div> 
                          <div class="form-group">
                            <label class="control-label col-md-2">No. of Holiday <span style="color: red">*</span></label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtnumber" Type="number" CssClass="form-control" runat="server"></asp:TextBox> 
                            </div>
                         </div> 
                         <div class="form-group">
                            <label class="control-label col-md-2">Status <span style="color:red">*</span></label>
                            <div class="col-md-2">
                                <asp:RadioButton ID="rbStatus" Checked="true" runat="server" Text="Active" GroupName="rbStatus" />
                                 <asp:RadioButton ID="rbInActive" runat="server" Text="InActive" GroupName="rbStatus" />
                            </div>                                                                                  
                        </div>
                    </div>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <div class="col-md-8 col-md-offset-4">
                        <div class="col-md-3">
                            <asp:Button ID="BtnUpdate" CssClass="btn btn-success col-md-12" runat="server" Text="Update" OnClick="BtnUpdate_Click"/>
                        </div>              
                        <div class="col-md-3">
                             <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click"/>  
                        </div>
                    </div>      
                </form>
            </div> <!-- container -->
        </div> <!-- content -->
</asp:Content>
