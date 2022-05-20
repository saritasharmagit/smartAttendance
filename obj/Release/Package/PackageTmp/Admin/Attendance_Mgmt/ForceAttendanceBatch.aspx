<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Attendance_Mgmt/Attendance_mgmt.Master" AutoEventWireup="true" CodeBehind="ForceAttendanceBatch.aspx.cs" Inherits="AttendanceKantipur.Admin.Attendance_Mgmt.ForceAttendanceBatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="Dashboard.aspx">Home</a></li>
                            <li class="active">Force Attendance Batch</li>
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
              
                
                   
               <div class="well col-md-6">
                <div class="form-group">
                        <asp:TextBox ID="Org_Id" CssClass="form-control hidden" runat="server"></asp:TextBox>
                        <div class="form-group">
                            <label class="control-label col-md-3"> Type <span style="color:red">*</span></label>
                            <div class="col-md-9">
                                <asp:RadioButton ID="rbsta"  GroupName="rbsta" runat="server"/> Sign In
                                <asp:RadioButton ID="rbsta1"  GroupName="rbsta" runat="server"/> Sign Out
                            </div>
                        </div>
                     <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true" >
                  <ContentTemplate>
                      
                     
                        <div class="form-group">
                            <label class="control-label col-md-3"> Time <span style="color:red">*</span></label>
                            <div class="col-md-6">
                                <asp:TextBox ID="TxtTime"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:CheckBox ID="DefTime" runat="server" AutoPostBack="true" OnCheckedChanged="DefTime_CheckedChanged" /> Default

                            </div>
                         </div> 
                        </ContentTemplate>
                  </asp:UpdatePanel>                     
                        <div class="form-group">
                            <label class="control-label col-md-3"> Remarks <span style="color:red">*</span></label>
                            <div class="col-md-8">
                                <asp:TextBox ID="TxtRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                       </div>
            <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
                     
                          <div class="form-group">
                            <label class="control-label col-md-3"> Date <span style="color:red">*</span></label>
                            <div class="col-md-4">
                                <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate2" AutoComplete="off" placeholder="Nepali" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-4">
                                <asp:TextBox ID="txtEndDate" CssClass="form-control englishDate2" AutoComplete="off" placeholder="English"  runat="server"></asp:TextBox>
                            </div>                                            
                        </div>
                    </div>
                      <div class="col-md-7 col-md-offset-4">
                        <div class="col-md-5">
                            <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click" />
                            </div>
                            <div class="col-md-5">
                                <asp:Button ID="BtnReset" CssClass="btn btn-danger col-md-12" runat="server" Text="Reset" OnClick="BtnReset_Click"/>  
                            </div>
                        </div>
                    </div>
                 <div class="col-md-6">
                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" runat="server"
                                    Font-Size="Small"
                                    AutoGenerateColumns="False"                            
                                    CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                    EmptyDataText="No records has been added.">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:templatefield>
                                            <HeaderTemplate>
                                                <asp:checkbox ID="chkAll"  runat="server"  onclick = "checkAll(this);"></asp:checkbox>
                                            </HeaderTemplate>
                                            <itemtemplate>
                                                <asp:checkbox ID="chk" runat="server"></asp:checkbox>
                                            </itemtemplate>
                                        </asp:templatefield>
                                        <asp:BoundField Visible="true" DataField="emp_id" HeaderText="EMP ID"/>
                                        <asp:BoundField DataField= "emp_Fullname" HeaderText="Employee Name"/>
                                      <%--  <asp:BoundField DataField="Time" HeaderText="Time"/>--%>
                                       <%-- <asp:BoundField DataField="Status(Holiday/Leave)" HeaderText="Status"/> --%>
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
                      <div class="col-md-8 col-md-offset-6">
                    <div class="col-md-6 form-group">
                        <asp:Button ID="BtnSave" CssClass="btn btn-success" runat="server" Text="Save" OnClick="BtnSave_Click"/>
                    </div>
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
