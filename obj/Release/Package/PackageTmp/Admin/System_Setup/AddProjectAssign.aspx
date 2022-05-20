<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/System_Setup/System_Setup.Master" AutoEventWireup="true" CodeBehind="AddProjectAssign.aspx.cs" Inherits="AttendanceKantipur.Admin.System_Setup.AddProjectAssign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
			    <div class="col-xs-12">
				    <div class="page-title-box">
                         
                        <ol class="breadcrumb p-0 m-0">
                            
                            <li class="blue"><a href="ProjectAssign.aspx">Project Assign List</a></li>
                            <li class="active">
                                Add New Project Assign
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
            <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div class="well col-md-6">
                    <asp:TextBox ID="ProjectTitleId" CssClass="form-control hidden" runat="server"></asp:TextBox>
                    <div class="form-group">
                        <label class="control-label col-md-3"> Project Title <span style="color:red">*</span></label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="CmbProjectTitle" CssClass="form-control" AutoPostBack="true"  runat="server"  CausesValidation="True" ToolTip="District List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbProjectTitle_SelectedIndexChanged"></asp:DropDownList> 
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-4">Location Selection <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <asp:RadioButton ID="rbState"  GroupName="rblocation" AutoPostBack="true" runat="server" OnCheckedChanged="rbState_CheckedChanged"/> State
                            <asp:RadioButton ID="rbDistrict" GroupName="rblocation" runat="server" AutoPostBack="true" OnCheckedChanged="rbDistrict_CheckedChanged"/> District
                        </div>
                    </div>
                     <div class="form-group">
                         <asp:Label ID="lblState" runat="server" CssClass="control-label col-md-4" Text="State"></asp:Label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="CmbState" CssClass="form-control" AutoPostBack="true" runat="server"  CausesValidation="True" ToolTip="District List"  EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbState_SelectedIndexChanged"></asp:DropDownList> 
                        </div>
                    </div>
                   
                    <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-4">
                        <asp:Button ID="BtnAssign" CssClass="btn btn-success col-md-12" runat="server" Text="Assign" OnClick="BtnAssign_Click" />
                    </div>
                    <div class="col-md-4">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click"/>  
                    </div>
                </div>
               </div>
                 <div class="col-md-6">  
                       <asp:GridView ID="grvDistrict" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"                            
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added." OnRowDataBound="grvDistrict_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                               <Columns>
                                     <asp:TemplateField HeaderText="All">
                                      <HeaderTemplate>
                                           <asp:CheckBox ID="CheckBox1"  runat="server" Text="Select All" onclick = "checkAll(this);"/>  
                                                   
                                      </HeaderTemplate>  
                                                <ItemTemplate> 
                                         <asp:CheckBox ID="CheckBox2" runat="server"/>

                                     </ItemTemplate>
                                 </asp:TemplateField>
                                             <asp:BoundField DataField="DistrictId" HeaderText="District ID" />
                                           <asp:BoundField DataField="DistrictName" HeaderText="District Name" />
                                    <asp:BoundField DataField="StateId" HeaderText="State Id" />
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

                </ContentTemplate>
                </asp:UpdatePanel>
            </form>
        </div> <!-- container -->
    </div> <!-- content -->
     <script type = "text/javascript">

        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked

                        //check all checkboxes

                        //and highlight all rows

                       // row.style.backgroundColor = "aqua";

                        inputList[i].checked = true;

                    }

                    else {

                        //If the header checkbox is checked

                        //uncheck all checkboxes

                        //and change rowcolor back to original

                        if (row.rowIndex % 2 == 0) {

                            //Alternating Row Color

                            //row.style.backgroundColor = "#C2D69B";

                        }

                        else {

                           // row.style.backgroundColor = "white";

                        }

                        inputList[i].checked = false;

                    }

                }

            }

        }

</script>
</asp:Content>
