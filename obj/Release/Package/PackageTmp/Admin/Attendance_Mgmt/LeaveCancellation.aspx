<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Attendance_Mgmt/Attendance_mgmt.Master" AutoEventWireup="true" CodeBehind="LeaveCancellation.aspx.cs" Inherits="AttendanceKantipur.Admin.Attendance_Mgmt.LeaveCancellation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
				<div class="col-xs-12">
					<div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                             <li class="blue">Attendance Management</li>
                            <li class="active">
                                Leave Cancellation
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
                 <asp:ScriptManager ID="scrManager" runat="server"> </asp:ScriptManager>
              <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true" >
                <ContentTemplate>                 
                <div class="well">
                    <div class="form-group">
                        <label class="control-label col-md-6"> Employee ID <span style="color:red">*</span></label>
                        <div class="col-md-2">
                            <div class="input-group">
                                <asp:TextBox ID="TxtId" CssClass="form-control" Type="number" AutoComplete="off" AutoPostBack="true" runat="server" OnTextChanged="TxtId_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label CssClass="control-label col-md-2" runat="server">Designation <span style="color:red">*</span></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="TxtDesg" CssClass="form-control" AutoComplete ="off" runat="server" ReadOnly="true" required=""></asp:TextBox>
                        </div>
                        <asp:Label CssClass="control-label col-md-2" runat="server">Applicant <span style="color:red">*</span></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="TxtEmp" CssClass="form-control" AutoComplete ="off" runat="server" ReadOnly="true" required=""></asp:TextBox>
                        </div>
                        
                    </div>
                    <div class="form-group">
                        <asp:Label CssClass="control-label col-md-2" runat="server">Department  <span style="color:red">*</span></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="TxtDept" CssClass="form-control" AutoComplete ="off" runat="server" ReadOnly="true" required=""></asp:TextBox>
                        </div>
                        <asp:Label CssClass="control-label col-md-2" runat="server">Project <span style="color:red">*</span></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="TxtBranch" CssClass="form-control" AutoComplete ="off" runat="server" ReadOnly="true" required=""></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label CssClass="control-label col-md-2" runat="server">Year <span style="color:red">*</span></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox ID="TxtYear" runat="server" CssClass="form-control" type="number" Text="2019"></asp:TextBox>
                        </div>
                        <asp:Label CssClass="control-label col-md-2" runat="server">Month <span style="color:red">*</span></asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="DDLMonth" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Month List"
                            EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                  </div>  
                 </ContentTemplate>
              </asp:UpdatePanel>  
                <div class="form-group col-md-12">
                <div class="col-md-6 col-md-offset-6">
                    <div class="col-md-3">
                        <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click"/>
                    </div>                        
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click"/>  
                    </div>
                </div>
                    </div>
                   <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
                <div class="form-group col-md-10">
                  <asp:GridView ID="GridView1" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added." OnRowDataBound="GridView1_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                <asp:TemplateField HeaderText="All">
                                      <HeaderTemplate>
                                           <asp:CheckBox ID="CheckBox1"  runat="server" Text="Select"  onclick = "checkAll(this);" />           
                                      </HeaderTemplate>  
                                                <ItemTemplate> 
                                         <asp:CheckBox ID="CheckBox2" runat="server"/>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                       
                                 <asp:BoundField DataField="SNo" HeaderText="S.N"/>
                                  <asp:TemplateField HeaderText="Leave Name">
                                        <ItemTemplate>
                                            <asp:Label ID="txtLeaveName" runat="server" Text='<%# Eval("Leave Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Taken Date">
                                        <ItemTemplate>
                                            <asp:Label ID="txtDate" runat="server"  Text='<%# Eval("Leave_Date","{0:yyyy-MM-dd}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="txtRemarks" runat="server" Text='<%# Eval("REMARKS") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Approved By">
                                        <ItemTemplate>
                                            <asp:Label ID="txtApproved" runat="server" Text='<%# Eval("Approver_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                      <%--  <asp:BoundField DataField="Leave Name" HeaderText="Leave Name" />
                        <asp:BoundField DataField="Leave_Date" HeaderText="Taken Date" DataFormatString="{0:yyyy/MM/dd}"/>
                        <asp:BoundField DataField="REMARKS" HeaderText="Remarks" />
                        <asp:BoundField DataField="ApprovedBy" HeaderText="Approved By" />--%>
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
                 <div class="col-md-6 col-md-offset-6">
                    <div class="col-md-3">
                        <asp:Button ID="btnDelete" CssClass="btn btn-danger col-md-12" runat="server" Text="Delete" OnClick="btnDelete_Click"/>  
                    </div>
                </div> 
                                    
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
      <script type = "text/javascript">
         function checkAll(objRef) {

             var GridView = objRef.parentNode.parentNode.parentNode;

             var inputList = GridView.getElementsByTagName("input");

             for (var i = 0; i < inputList.length; i++) {

                 var row = inputList[i].parentNode.parentNode;

                 if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                     if (objRef.checked) {

                         inputList[i].checked = true;

                     }

                     else {
                         inputList[i].checked = false;

                     }

                 }

             }

         }

</script> 
</asp:Content>
