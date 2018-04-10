<%@ Page Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="Biodata.aspx.cs" Inherits="TheCancerProject.ThePages.Biodata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Patient Management
            <small>Complete Biodata</small>
        </h1>
    </section>

    <!-- Main content -->
        <section class="content">
          <div class="row">
            <!-- left column -->
            <div class="col-md-6" style="width: 100%">
              <!-- general form elements -->
              <div class="box">
                <div class="box-header" style="background-color:steelblue">
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">Biodata</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <form id="form1" runat="server">
                        <div class="box-body"> 
                             
                            <div class="col-md-1"> 
                                </div>
            <div class="col-md-4">    
                          
            <div class="form-group">
                <asp:Label ID="lblTitle" runat="server" Font-Bold="true">Title</asp:Label>
            <asp:DropDownList ID="ddlTitle" runat="server" AppendDataBoundItems="True"
                                DataSourceID="ObjTitle" DataTextField="Name" DataValueField="Value" class="form-group" CssClass="form-control" ClientIDMode="Static">
                                <asp:ListItem Value="">None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjTitle" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.Title, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                </div>

                <div class="form-group">
                                <label for="FirstName">First Name</label>
                        <input required runat="server" type="text" class="form-control" id="txtFirstName" title="Firstnames" pattern="[A-Za-z]*" maxlength="50" placeholder="Enter First Name"/>
               </div>
                <div class="form-group">
                                <label for="LastName">Last Name</label>
                        <input runat="server" type="text" class="form-control" id="txtLastName" title="Lastname" pattern="[A-Za-z]*" maxlength="50" required="" placeholder="Enter Last Name"/>
                               
               </div>
                <div class="form-group">
                                <label for="FirstName">Other Names</label>
                        <input runat="server" type="text" class="form-control" id="txtOtherNames" title="OtherNames" pattern="[A-Za-z]*" maxlength="50" required="" placeholder="Enter Other Names"/>
                               
               </div>
                <div class="form-group">
                                <label for="FirstName">Hospital Number</label>
                        <input runat="server" type="text" class="form-control" id="txtHospitalNumber" title="HospitalNumber" pattern="[A-Za-z]*" maxlength="50" required="" placeholder="Enter Hospital Number"/>
                               
               </div>

                <div class="form-group">
                <asp:Label ID="lblSex" runat="server" Font-Bold="true">Sex</asp:Label>
                    <asp:DropDownList ID="ddlSex" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static"
                                DataSourceID="ObjSex" DataTextField="Name" DataValueField="Value">
                                <asp:ListItem Value="">None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSex" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.Sex, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                    </div>

                <div class="form-group">
                                <label for="FirstName">Address</label>
                        <input runat="server" type="text" class="form-control" id="txtAddress" title="Address" pattern="[A-Za-z]*" maxlength="200" required="" placeholder="Enter Hospital Number"/>
                               
               </div>

                <div class="form-group">
                <asp:Label ID="Label1" runat="server" Font-Bold="true">State Of Residence</asp:Label>
                    <asp:DropDownList ID="ddlStates" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static"
                                DataSourceID="ObjStates" DataTextField="Name" DataValueField="Value">
                                <asp:ListItem Value="">None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjStates" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.State, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                    </div>
        </div>

                            <div class="col-md-2"> 
                                </div>

    <div class="col-md-4">  
        <div class="form-group">
                <asp:Label ID="Label2" runat="server" Font-Bold="true">Religion</asp:Label>
                    <asp:DropDownList ID="ddlReligion" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static"
                                DataSourceID="ObjReligion" DataTextField="Name" DataValueField="Value">
                                <asp:ListItem Value="">None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjReligion" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.Religion, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                    </div>

        <div class="form-group">
                                <label for="txtOccupation">Occupation</label>
                        <input runat="server" type="text" class="form-control" id="txtOccupation" title="Occupation" pattern="[A-Za-z]*" maxlength="200" required="" placeholder="Enter Occupation"/>
                               
               </div>

        <div class="form-group">
                <asp:Label ID="Label3" runat="server" Font-Bold="true">Marital Status</asp:Label>
                    <asp:DropDownList ID="ddlMaritalStatus" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static"
                                DataSourceID="ObjMaritalStatus" DataTextField="Name" DataValueField="Value">
                                <asp:ListItem Value="">None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjMaritalStatus" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.MaritalStatus, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                    </div>


        <div class="form-group">
                                <label for="txtOccupation">Phone Number</label>
                        <input runat="server" type="text" class="form-control" id="txtPhone" title="Phone Number" pattern="[A-Za-z]*" maxlength="11" required="" placeholder="Enter Occupation"/>
                               
               </div>

        <div class="form-group">
                <asp:Label ID="lblRelationship" runat="server" Font-Bold="true">Next of Kin Relationship</asp:Label>
                    <asp:DropDownList ID="ddlRelationship" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static"
                                DataSourceID="ObjRelationship" DataTextField="Name" DataValueField="Value">
                                <asp:ListItem Value="">None</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjRelationship" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.Relationship, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                    </div>

        <div class="form-group">
                                <label for="txtOccupation">Next of Kin Name</label>
                        <input runat="server" type="text" class="form-control" id="txtNextOfKinName" title="Next of Kin Name" pattern="[A-Za-z]*" maxlength="50" required="" placeholder="Enter Next of Kin Name"/>
                               
               </div>

        <div class="form-group">
                                <label for="txtOccupation">Next of Kin Phone</label>
                        <input runat="server" type="text" class="form-control" id="txtNextofKinPhone" title="Next of Kin Phone" pattern="[A-Za-z]*" maxlength="11" required="" placeholder="Enter Next of Kin Phone"/>
                               
               </div>

        <div class="box-footer">
            <button type="button"  id="btnNext" CssClass="next-btn" runat="server" class="btn btn-flat btn-primary pull-right" OnServerClick="btnNext_Click">Next</button>
        <%--<asp:Button ID="btnNext" CssClass="next-btn" Text="Next" runat="server" class="btn btn-flat btn-primary pull-right" OnClick="btnNext_Click" />--%>
            </div>

        </div>
                            <div class="col-md-1"> 
                                </div>
                             </div>

                    </form>
                </div>
                <!-- /.box -->

            </div>
            <!--/.col (right) -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->
    <script type="text/javascript">
         $(function () {
             $('#ddlTitle').select2({ placeholder: "Please Select A Title" }),
             $('#ddlSex').select2({ placeholder: "Please Select Sex" });
             $('#ddlStates').select2({ placeholder: "Please Select A State" }),
             $('#ddlReligion').select2({ placeholder: "Please Select Religion" });
             $('#ddlMaritalStatus').select2({ placeholder: "Please Select Marital Status" }),
             $('#ddlRelationship').select2({ placeholder: "Please Select Relationship" });
         });
    </script>
</asp:Content>
