<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Reports/Reports.Master" AutoEventWireup="true" CodeBehind="Reports_ViewTransfer.aspx.cs" Inherits="AttendanceKantipur.Admin.Reports.Reports_ViewTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="active">
                                View Transfer Report
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
			    </div>
		    </div>
            <!-- end row -->
            <form runat="server" role="form" class="form-horizontal">
                <div class="col-md-12 form-group">
                    <div class="col-md-6 button-list">                       
                        <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2" runat="server" Text="Excel" OnClick="BtnExport_Click1"/>
                    </div> 
                      <asp:Panel ID="Panel1" runat="server">
                    <div style="font-weight:bold;" class="col-md-6">
                        <div style="font-weight: bold; font-size: large">
                            <asp:Label ID="labelTransfer" runat="server" Text="CEAPRED Staff Transfer Details Report"></asp:Label>
                        </div>
                      
                    </div>
                    </asp:Panel>
                    </div>
                  <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                 <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true" >
                  <ContentTemplate>
              <%--   <div class="well">--%>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        
                         <label class="control-label col-md-2">Transfer Year <span style="color:red">*</span></label>
                        <div class="col-md-3">
                           <asp:DropDownList ID="CmbYear" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CmbYear_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                         <label class="control-label col-md-1">Project <span style="color: red">*</span></label>
                        <div class="col-md-3">
                          <asp:DropDownList ID="CmbProject" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Project List" AutoPostBack="true"
                            EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true"  AllowCustomText="true" OnSelectedIndexChanged="CmbProject_SelectedIndexChanged"></asp:DropDownList>
                        </div>                                                                                 
                    </div>
               <%-- </div> --%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No records has been added." OnRowDataBound="GridView1_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                  <%--  <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                     <asp:BoundField DataField="Fullname" HeaderText="Full Name"/>
                                       <asp:BoundField DataField="branch_name_to" HeaderText="Current Project"/>
                                      <asp:BoundField DataField="branch_name_from" HeaderText="Previous Project"/>
                                    <asp:BoundField DataField="TDATE" HeaderText="Transfer Date" DataFormatString="{0:yyyy-MM-dd}" />
                                     
                                       <asp:BoundField DataField="District_To" HeaderText="Current District"/>
                                    <asp:BoundField DataField="District_From" HeaderText="Previous District"/>
                                  
                                      <asp:BoundField DataField="Desg_To" HeaderText="Current designation"/>
                                    <asp:BoundField DataField="Desg_From" HeaderText="Previous designation"/>
                                    
                                </Columns>
                                <EditRowStyle/>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />

                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                      </ContentTemplate>
                     </asp:UpdatePanel>
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>
