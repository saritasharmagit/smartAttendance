<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Reports/Reports.Master" AutoEventWireup="true" CodeBehind="Reports_ViewStaffDetails.aspx.cs" Inherits="AttendanceKantipur.Admin.Reports.Reports_ViewStaffDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="active">View Staff Details Report
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->

            <form runat="server" role="form" class="form-horizontal">
                
                <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true" >
                  <ContentTemplate>
                 
                 <div class="col-md-12 form-group">
                    <div class="col-md-6 button-list">  
                         <asp:Button ID="btnNew" CssClass="btn btn-success col-md-2 " runat="server" Text="New" OnClick="btnNew_Click1"/>   
                        <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2 " runat="server" Text="Excel" OnClick="BtnExport_Click"/>
                    </div>
                        <div class="col-md-6 button-list">
                        <asp:Button ID="btnExpproject_gender" CssClass="btn btn-success col-md-2"  runat="server" Text="Excel" OnClick="btnExpproject_gender_Click"/>
                    </div>
                     <div class="col-md-6 button-list">
                        <asp:Button ID="btnExpposition_project" CssClass="btn btn-success col-md-2 " runat="server" Text="Excel" OnClick="btnExpposition_project_Click"/>
                    </div>
                       <div class="col-md-6 button-list">
                        <asp:Button ID="btnExpgender_ethnicity" CssClass="btn btn-success col-md-2 " runat="server" Text="Excel" OnClick="btnExpgender_ethnicity_Click"/>
                    </div>
                      <div class="col-md-6 button-list">
                        <asp:Button ID="btnExpposition_gender" CssClass="btn btn-success col-md-2 " runat="server" Text="Excel" OnClick="btnExpposition_gender_Click"/>
                    </div>
                      <div class="col-md-6 button-list">
                        <asp:Button ID="btnExpPr_Po_Ge" CssClass="btn btn-success col-md-2 " runat="server" Text="Excel" OnClick="btnExpPr_Po_Ge_Click"/>
                    </div>
                </div>
               
             
                    <div class="col-md-12 form-group">
                        <div class="col-md-2">
                         <asp:Button ID="btnProject_Gender" CssClass="btn btn-primary" runat="server" Text="Project_Gender" OnClick="btnProject_Gender_Click" />
                        </div>
                        <div class="col-md-2">
                         <asp:Button ID="btnPosition_Project" CssClass="btn btn-primary" runat="server" Text="Project_Position" OnClick="btnPosition_Project_Click"/>
                        </div>
                         <div class="col-md-2">
                         <asp:Button ID="btnGender_Ethnicity" CssClass="btn btn-primary" runat="server" Text="Gender_Ethnicity" OnClick="btnGender_Ethnicity_Click"/>
                        </div>
                         <div class="col-md-2">
                         <asp:Button ID="btnPosition_Gender" CssClass="btn btn-primary" runat="server" Text="Position_Gender" OnClick="btnPosition_Gender_Click"/>
                        </div>
                         <div class="col-md-2">
                         <asp:Button ID="btnProject_Position_Gender" CssClass="btn btn-primary" runat="server" Text="Project_Position_Gender" OnClick="btnProject_Position_Gender_Click"/>
                        </div>
                     </div>
             
                 <asp:Panel ID="Panel1" runat="server">
                      <div style="font-weight:bold;" class="col-md-6">
                        <div style="font-weight: bold; font-size: large">
                            <asp:Label ID="lblDetails" runat="server" Text="CEAPRED Staff Details Report"></asp:Label>
                        </div>
                      
                    </div>
                    <div style="font-weight:bold;" class="col-md-6">
                        <div style="font-weight: bold; font-size: large">
                            <asp:Label ID="labelstaffdetails" runat="server" Text="CEAPRED Staff Details Report(Project_Gender)"></asp:Label>
                        </div>
                      
                    </div>
                     <div style="font-weight:bold;" class="col-md-6">
                        <div style="font-weight: bold; font-size: large">
                            <asp:Label ID="lblProject_position" runat="server" Text="CEAPRED Staff Details Report(Position_Project)"></asp:Label>
                        </div>
                      
                    </div>
                      <div style="font-weight:bold;" class="col-md-6">
                        <div style="font-weight: bold; font-size: large">
                            <asp:Label ID="lblgender_ethnicity" runat="server" Text="CEAPRED Staff Details Report(Gender_Ethnicity)"></asp:Label>
                        </div>
                      
                    </div>
                      <div style="font-weight:bold;" class="col-md-6">
                        <div style="font-weight: bold; font-size: large">
                            <asp:Label ID="lblPosition_gender" runat="server" Text="CEAPRED Staff Details Report(Position_Gender)"></asp:Label>
                        </div>
                      
                    </div>
                      <div style="font-weight:bold;" class="col-md-6">
                        <div style="font-weight: bold; font-size: large">
                            <asp:Label ID="lblP_P_G" runat="server" Text="CEAPRED Staff Details Report(Project_Position_Gender)"></asp:Label>
                        </div>
                      
                    </div>
                    </asp:Panel>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                                 <asp:GridView ID="GridView1" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added.">
                                <AlternatingRowStyle BackColor="White" />
                               <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="Employee (ID)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Fullname")+ " " +"("+ Eval("EMP_ID") +")"%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                      <asp:BoundField DataField="BRANCH_NAME" HeaderText="Project"/>
                                     <asp:BoundField DataField="GENDER" HeaderText="Gender"/>
                                    <asp:BoundField DataField="Ethnicity" HeaderText="Ethnicity"/>
                                    <asp:BoundField DataField="ProjectDistrict" HeaderText="Project District"/>
                                      <asp:BoundField DataField="DEG_NAME" HeaderText="Position"/> 
                                    <asp:BoundField DataField="STATUS_NAME" HeaderText="Status"/> 
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

                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                                 <asp:GridView ID="GridView2" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added." ShowFooter="true" OnRowDataBound="GridView2_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                               <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                         <FooterTemplate>
                                             Total
                                         </FooterTemplate>
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                         <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField> 
                                    
                                      <asp:BoundField DataField="BRANCH_NAME" HeaderText="Project"/>
                                     <asp:BoundField DataField="Male" HeaderText="Male"/>
                                    <asp:BoundField DataField="Female" HeaderText="Female"/>
                                    <asp:BoundField DataField="Total" HeaderText="Total Employee"/>
                                    <asp:BoundField DataField="mpc" HeaderText="Male %"/>
                                    <asp:BoundField DataField="fpc" HeaderText="Female %"/>
                                
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

                 <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                                 <asp:GridView ID="GridView3" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added." ShowFooter="true" OnRowDataBound="GridView3_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                               <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                           <FooterTemplate>
                                             Total
                                         </FooterTemplate>
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    
                                      <asp:BoundField DataField="BRANCH_NAME" HeaderText="Project"/>
                                      <asp:BoundField DataField="Manager" HeaderText="Manager"/>
                                      <asp:BoundField DataField="Officer" HeaderText="Officer"/>
                                      <asp:BoundField DataField="Assistant" HeaderText="Assistant"/>
                                      <asp:BoundField DataField="Support" HeaderText="Support"/>
                                    <asp:BoundField DataField="Total" HeaderText="Total Employee"/>
                                    
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

                  <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                                 <asp:GridView ID="GridView4" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added." ShowFooter="true" OnRowDataBound="GridView4_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                               <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                           <FooterTemplate>
                                             Total
                                         </FooterTemplate>
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                  
                                      <asp:BoundField DataField="Ethnicity" HeaderText="Ethnicity"/>
                                       <asp:BoundField DataField="Male" HeaderText="Male"/> 
                                    <asp:BoundField DataField="Female" HeaderText="Female"/> 
                                    <asp:BoundField DataField="Total" HeaderText="Total Employee"/>
                                      <asp:BoundField DataField="mpc" HeaderText="Male %"/>
                                    <asp:BoundField DataField="fpc" HeaderText="Female %"/>
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

                   <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                                 <asp:GridView ID="GridView5" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added." ShowFooter="true" OnRowDataBound="GridView5_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                              <Columns>
                                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                          <FooterTemplate>
                                             Total
                                         </FooterTemplate>
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                  
                                      <asp:BoundField DataField="GRADE_NAME" HeaderText="Position"/>
                                       <asp:BoundField DataField="Male" HeaderText="Male"/> 
                                    <asp:BoundField DataField="Female" HeaderText="Female"/> 
                                    <asp:BoundField DataField="Total" HeaderText="Total Employee"/>
                                     <asp:BoundField DataField="mpc" HeaderText="Male %"/>
                                    <asp:BoundField DataField="fpc" HeaderText="Female %"/>
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

                    <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                                 <asp:GridView ID="GridView6" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False" ShowHeader="False" showfooter="true"                          
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added." OnRowDataBound="GridView6_RowDataBound" OnRowCreated="GridView6_RowCreated">
                                <AlternatingRowStyle BackColor="White" />
                               <Columns>
                                     <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                          <FooterTemplate>
                                             Total
                                         </FooterTemplate>
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                     <asp:BoundField DataField="BRANCH_NAME" />
                                    <asp:BoundField DataField="ManagerMale"/>
                                      <asp:BoundField DataField="ManagerFemale"/>
                                     <asp:BoundField DataField="OfficerMale" />
                                      <asp:BoundField DataField="OfficerFemale"/>
                                     <asp:BoundField DataField="AssistantMale"/>
                                      <asp:BoundField DataField="AssistantFemale"/>
                                    <asp:BoundField DataField="SupportMale"/>
                                      <asp:BoundField DataField="SupportFemale"/>
                                    <asp:BoundField DataField="Maletotal"/>
                                     <asp:BoundField DataField="Femaletotal"/>
                                    
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
                  <%-- </asp:Panel>--%>
                </ContentTemplate>
                      <Triggers>
                          <asp:PostBackTrigger ControlID="BtnExport" />
                          <asp:PostBackTrigger ControlID="btnExpproject_gender" />
                          <asp:PostBackTrigger ControlID="btnExpposition_project" />
                          <asp:PostBackTrigger ControlID="btnExpgender_ethnicity" />
                          <asp:PostBackTrigger ControlID="btnExpposition_gender" />
                          <asp:PostBackTrigger ControlID="btnExpPr_Po_Ge" />

                      </Triggers>
                      
              </asp:UpdatePanel>

            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->

  
</asp:Content>
