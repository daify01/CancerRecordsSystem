<%@ Page Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="GeneralExamination.aspx.cs" Inherits="TheCancerProject.ThePages.Create.GeneralExamination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section class="content-header">
        <h1>General Examination
            <small>General Examination</small>
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
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">General Examination</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <form id="form1" runat="server">
                        <div class="box-body">
                            <div class="col-md-12">

                            <div class="col-md-6">
                                <div class="form-group">
                                <label for="ddlGeneralExam">General Exam</label>
        <asp:ListBox ID="ddlGeneralExam" ClientIDMode="Static" CssClass="form-control" runat="server"  SelectionMode="Multiple"></asp:ListBox> 
            <%--<asp:DropDownList ID="ddlGeneralExam" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static" 
                                DataSourceID="ObjGeneralExam" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjGeneralExam" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.GeneralExam, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
                                    </div>

                                <div class="form-group">
                                <label for="txtWeight">Weight(kg)</label>
                        <input type="text" runat="server" class="form-control" id="txtWeight" title="Weight" required="" placeholder="Enter Weight"/>                            
                            </div>
      
                            <div class="form-group">
                                <label for="txtHeight">Height(m)</label>
                        <input type="text" runat="server" class="form-control" id="txtHeight" title="Height" required="" placeholder="Enter Height"/>
                               
                            </div>

                                <div>
                    <label for="txtBMI">BMI(kg/m^2)</label>
            <input type="text" runat="server" class="form-control" id="txtBMI" title="BMI" required="" placeholder="Enter BMI"/>
              </div>

                               <div class="form-group">
                                <label for="txtBSA">BSA(m^2)</label>
                <input type="text" runat="server" class="form-control" id="txtBSA" title="BSA" required="" placeholder="Enter BSA"/>   
                               </div>

                                <div class="form-group">
                                <label for="txtTemperature">Temperature (celsius)</label>
                <input type="text" runat="server" class="form-control" id="txtTemperature" title="Temperature" required="" placeholder="Enter Temperature"/>   
                               </div>

                                <%--<div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkDilatedVeins"> Dilated Veins
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkPluckering"> Pluckering
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkPeauDOrange"> Peau D'Orange
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkSkinTethering"> Skin Tethering
                </label>
              </div>--%>
                                <div class="form-group">
                                <label for="ddlTexture">Texture</label>
        <asp:ListBox ID="ddlTexture" ClientIDMode="Static" CssClass="form-control" runat="server"  SelectionMode="Multiple"></asp:ListBox>
            <%--<asp:DropDownList ID="ddlTexture" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static" 
                                DataSourceID="ObjTexture" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjTexture" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.Texture, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
                                    </div>

                                <%--<div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkTenderness"> Tenderness
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkNodules"> Nodules
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkUlceration"> Ulceration
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkUlceratingMass"> Ulcerating Mass
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkPresenceOfNippleRetraction"> Presence of (Nipple) Retraction
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkNippleDestruction"> Nipple Destruction
                </label>
              </div>--%>

                                <div class="form-group">
                                <label for="ddlLocationOfLesion">Location Of Lesion</label>
        <asp:ListBox ID="ddlLocationOfLesion" ClientIDMode="Static" CssClass="form-control" runat="server"  SelectionMode="Multiple"></asp:ListBox>
            <%--<asp:DropDownList ID="ddlLocationOfLesion" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static" 
                                DataSourceID="ObjLocationOfLesion" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjLocationOfLesion" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.LocationOfLesion, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
                                    </div>                                                             

                                 <div class="form-group">
                                <label for="txtOtherObservations">OtherObservations</label>
                        <textarea runat="server" class="form-control" id="txtOtherObservations" cols="50" rows="10" required=""/>                              
                            </div>

                                </div>

                                <div class="col-md-6">

                                     <div class="form-group">
                                <label for="ddlSymmetry">Symmetry</label>
            <asp:DropDownList ID="ddlSymmetry" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static" 
                                DataSourceID="ObjSymmetry" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjSymmetry" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.Symmetry, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                                    </div> 
                                     <div class="form-group">
                                <label for="txtShape">Shape</label>
                        <input type="text" runat="server" class="form-control" id="Text1" title="Shape" required="" placeholder="Enter Shape"/>                            
                            </div>

                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkVisibleMass"> Visible Mass
                </label>
              </div>
                                <div class="form-group">
                                <label for="ddlQuadrantLocated">Quadrant Located</label>
        <asp:ListBox ID="ddlQuadrantLocated" ClientIDMode="Static" CssClass="form-control" runat="server"  SelectionMode="Multiple"></asp:ListBox>
            <%--<asp:DropDownList ID="ddlLocationOfLesion" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static" 
                                DataSourceID="ObjLocationOfLesion" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjLocationOfLesion" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.LocationOfLesion, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
                                    </div>
                                
                                <div class="form-group">
                                <label for="txtColorOfSkinArea">Color Of Skin Area</label>
                        <input type="text" runat="server" class="form-control" id="Text2" title="ColorOfSkinArea" required="" placeholder="Enter Color Of Skin Area"/>  
                            </div>

                                <div class="form-group">
                                <label for="txtBloodPressure">Blood Pressure</label>
                <input type="text" runat="server" class="form-control" id="txtBloodPressure" title="Blood Pressure" required="" placeholder="Enter Blood Pressure"/>   
                               </div>

                                <div class="form-group">
                                <label for="txtRespiratoryRate">Respiratory Rate (Cyc/min)</label>
                <input type="text" runat="server" class="form-control" id="txtRespiratoryRate" title="Respiratory Rate" required="" placeholder="Enter Respiratory Rate"/>   
                               </div>

                                <div class="form-group">
                                <label for="txtHeartSounds">Heart Sounds</label>
                <input type="text" runat="server" class="form-control" id="txtHeartSounds" title="Heart Sounds" required="" placeholder="Enter Heart Sounds"/>   
                               </div>

                                <div class="form-group">
                                <label for="txtPulseRRate">Pulse Rate (b/min)</label>
                <input type="text" runat="server" class="form-control" id="Text3" title="Pulse Rate" required="" placeholder="Enter Pulse RAte"/>   
                               </div>
                                </div>                                                              
                                                               

                                </div>


                            <div class="box-footer">
            <button type="button"  id="btnNext" CssClass="next-btn" runat="server" class="btn btn-flat btn-primary pull-right" OnServerClick="btnNext_Click">Next</button>
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
        $(document).ready(function () {
            $("#ddlGeneralExam").chosen({ placeholder_text_multiple: "Select The General Exam" }),
            $("#ddlTexture").chosen({ placeholder_text_multiple: "Select Texture" })
            $("#ddlLocationOfLesion").chosen({ placeholder_text_multiple: "Select Location Of Lesion" }),
            $("#ddlQuadrantLocated").chosen({ placeholder_text_multiple: "Select Location Of Lesion" }),
             $('#ddlSymmetry').select2({ placeholder: "Please Select Symmetry" });
         });
    </script>
</asp:Content>
