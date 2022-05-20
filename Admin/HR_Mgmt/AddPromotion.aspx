<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/HR_Mgmt/HR.Master" AutoEventWireup="true" CodeBehind="AddPromotion.aspx.cs" Inherits="AttendanceKantipur.Admin.HR_Mgmt.AddPromotion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
				<div class="col-xs-12">
					<div class="page-title-box">
                         <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="Promotion.aspx">Promotion List</a></li>
                            <li class="active">
                                Add New Promotion
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
                 <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
               
                    <div class="form-group">                      
                        <label class="control-label col-md-6"> Employee ID <span style="color:red">*</span></label>
                        <div class="col-md-2">
                            <div class="input-group">
                                <asp:TextBox ID="txtEmpId" CssClass="form-control" AutoComplete="off" AutoPostBack="true" runat="server" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div> 
          
                    <div class="form-group">
                        <asp:Label CssClass="control-label col-md-6" runat="server">Employee Name <span style="color:red">*</span></asp:Label>
                        <div class="col-md-6">
                            <div class="input-group">
                                <asp:TextBox ID="txtName" CssClass="form-control" AutoComplete ="off" runat="server" ReadOnly="true" ></asp:TextBox>
                            </div>
                        </div>                 
                    </div>
          
                    <div class="form-group">
                        <label class="control-label col-md-2">First Join Date</label> 
                      <div class="col-md-3">
                            <div class="input-group">
                                <asp:TextBox ID="txtStartDate"  CssClass="form-control" AutoComplete="off" ReadOnly="true" placeholder="English Date"  runat="server"></asp:TextBox>
                              
                            </div>                                 
                        </div>                                            
                    </div>
                          <div class="form-group">
                        <label class="control-label col-md-2">Contract From </label> 
                      <div class="col-md-3">
                            <div class="input-group">
                                <asp:TextBox ID="txtContractFrom"  CssClass="form-control" AutoComplete="off" ReadOnly="true" placeholder="English Date"  runat="server"></asp:TextBox>
                              
                            </div>                                 
                        </div> 
                              <label class="control-label col-md-2">Contract To</label> 
                            <div class="col-md-3">
                            <div class="input-group">
                                <asp:TextBox ID="txtContractTo"  CssClass="form-control" AutoComplete="off" ReadOnly="true" placeholder="English Date"  runat="server"></asp:TextBox>
                             
                            </div>                                 
                        </div>                                             
                    </div>
                        
                        
                  </ContentTemplate>
                </asp:UpdatePanel>
                    <div class="form-group">
                        <label class="control-label col-md-2">Date <span style="color:red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate1" Autocomplete="off" AutoPostBack="true" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                     
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtDate" CssClass="form-control englishDate1" AutoComplete="off" placeholder="English Date"  runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                                
                            </div>                                 
                        </div> 

                                                                   
                    </div>
                    <div class="form-group">
                      <label class="control-label col-md-3">New Contract Date</label>
                            <div class="col-md-2">
                            <asp:CheckBox ID="chkContract" runat="server" AutoPostBack="true" OnCheckedChanged="chkContract_CheckedChanged"/>
                          </div>
                     </div>
                 <div class="form-group">
                     <asp:Label ID="lblnewContractfrom" CssClass="control-label col-md-2" runat="server" Text="New Contract From"></asp:Label>
                    
                        <div class="col-md-4">  
                                <asp:TextBox ID="txtNewContractFromNepali" CssClass="form-control nepaliDate2" Autocomplete="off" AutoPostBack="true" placeholder="Nepali Date" runat="server"></asp:TextBox>
                        </div>
                     
                        <div class="col-md-4">  
                                <asp:TextBox ID="txtNewContract" CssClass="form-control englishDate2" AutoComplete="off" placeholder="English Date"  runat="server"></asp:TextBox>                         
                        </div>                                            
                    </div>
                 <div class="form-group">
                       <asp:Label ID="lblNewContractTo" CssClass="control-label col-md-2" runat="server" Text="New Contract To"></asp:Label>
                        <div class="col-md-4">   
                                <asp:TextBox ID="txtNewContractToNepali" CssClass="form-control nepaliDate3" Autocomplete="off" AutoPostBack="true" placeholder="Nepali Date" runat="server"></asp:TextBox>
                           
                        </div>
                        <div class="col-md-4">    
                                <asp:TextBox ID="txtNewContractTo" CssClass="form-control englishDate3" AutoComplete="off" placeholder="English Date"  runat="server"></asp:TextBox>
                                                           
                        </div>                                            
                    </div>
        
             <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div class="col-md-6 well">
                      <h4><asp:Label CssClass="control-label" runat="server">Promoted From </asp:Label></h4>
                     <div class="form-group">
                        <asp:Label CssClass="control-label col-md-4" runat="server">Project </asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtProject" CssClass="form-control" AutoPostBack="true" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                          <div class="col-md-3 hidden">
                            <asp:TextBox ID="txtProjectid" CssClass="form-control" AutoPostBack="true" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label CssClass="control-label col-md-4" runat="server">District </asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDistrict" CssClass="form-control" AutoPostBack="true" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                          <div class="col-md-3 hidden">
                            <asp:TextBox ID="txtDistrictid" CssClass="form-control" AutoPostBack="true" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label CssClass="control-label col-md-4" runat="server">Present Designation </asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDesignation" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                         <div class="col-md-2 hidden">
                            <asp:TextBox ID="txtDegid" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <asp:Label CssClass="control-label col-md-4" runat="server">Old Salary </asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtOldSalary" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div> 
                </div>
                 
                <div class="col-md-6 well">
                   <h4><asp:Label CssClass="control-label" runat="server">Promoted To </asp:Label></h4>
                   <div class="form-group">
                        <asp:Label CssClass="control-label col-md-4" runat="server">New Project </asp:Label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="CmbNewProject" CssClass="form-control" AutoPostBack="true" runat="server"  CausesValidation="True" ToolTip="Project List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbNewProject_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-2 hidden">
                            <asp:TextBox ID="txtnewprojectid" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                  <div class="form-group">
                        <asp:Label CssClass="control-label col-md-4" runat="server">District </asp:Label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="CmbnewDistrict" CssClass="form-control" AutoPostBack="true" runat="server"  CausesValidation="True" ToolTip="District List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbnewDistrict_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-4 hidden">
                            <asp:TextBox ID="txtnewDistrictid" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label CssClass="control-label col-md-4" runat="server">New Designation </asp:Label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="CmbDesignation" CssClass="form-control" runat="server"  CausesValidation="True" ToolTip="Designation List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbDesignation_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                         <div class="col-md-2 hidden">
                            <asp:TextBox ID="txtnewdegid" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <asp:Label CssClass="control-label col-md-4" runat="server">New Salary </asp:Label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtNewSalary" CssClass="form-control" Type="number" runat="server"></asp:TextBox>
                        </div>
                    </div> 
                  
                </div>
          </ContentTemplate>
                </asp:UpdatePanel>
            <div class="form-group col-md-8">
              <label class="control-label col-md-3"> Latest Promotion</label>
                      <div class="col-md-1">
                        <asp:CheckBox ID="chkPromotion" runat="server"/>
                    </div>
                  </div>
             <div class="form-group col-md-8">
             <label class="control-label col-md-3">Description</label>
                 <asp:TextBox id="txtDescription" TextMode="multiline" Columns="50" Rows="5" runat="server" />
             
                 </div>
                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click"/>
                    </div>
                                            
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel"/>  
                    </div>
                </div> 
                       
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>
