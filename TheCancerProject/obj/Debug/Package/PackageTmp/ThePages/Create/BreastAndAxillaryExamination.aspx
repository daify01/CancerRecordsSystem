<%@ Page Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="BreastAndAxillaryExamination.aspx.cs" Inherits="TheCancerProject.ThePages.Create.BreastAndAxillaryExamination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Breast And Axillary Examination
            <small>Breast And Axillary Examination</small>
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
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">Breast And Axillary Examination</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <form id="form1" runat="server">
                        <div class="box-body">
                            <div class="col-md-12">

                            <div class="col-md-6">

                                <%--<div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkEndemaInArms"> Endema In Arms
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkSupraClavicularFullness"> SupraClavicular Fullness
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkAxillaryFullness"> Axillary Fullness
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkAnteriorChestWallFullness"> Anterior Chest Wall Fullness
                </label>
              </div>--%>

                                <div class="form-group">
                                <label for="ddlAxillaryLymphNodes">Axillary Lymph Nodes</label>
        <asp:ListBox ID="ddlAxillaryLymphNodes" ClientIDMode="Static" CssClass="form-control" runat="server"  SelectionMode="Multiple"></asp:ListBox> 
                                    </div>

                                <div class="form-group">
                                <label for="ddlSupraClavicularNodes">SupraClavicular Nodes</label>
        <asp:ListBox ID="ddlSupraClavicularNodes" ClientIDMode="Static" CssClass="form-control" runat="server"  SelectionMode="Multiple"></asp:ListBox> 
                                    </div>

                                <div class="form-group">
                                <label for="ddlAnteriorChestWallNodules">Anterior Chest Wall Nodules</label>
        <asp:ListBox ID="ddlAnteriorChestWallNodules" ClientIDMode="Static" CssClass="form-control" runat="server"  SelectionMode="Multiple"></asp:ListBox> 
                                    </div>

                                <div class="form-group">
                                <label for="txtFindingsUnderBreast">Findings under breast with the hands above the head</label>
                        <textarea runat="server" class="form-control" id="Textarea1" cols="50" rows="10" required=""/>                              
                            </div>

                                <div class="form-group">
                                <label for="txtFindingsWithArmsOnHips">Findings with the arms pressing on the hips</label>
                        <textarea runat="server" class="form-control" id="txtPastSurgicalHistory" cols="50" rows="10" required=""/>                              
                            </div>    
                                
                                
                                <div class="form-group">
                                <label for="ddlBreastWithLesion">Breast With Lesion</label>
            <asp:DropDownList ID="ddlBreastWithLesion" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static" 
                                DataSourceID="ObjBreastWithLesion" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjBreastWithLesion" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.BreastWithLesion, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                                    </div>

                                <div class="form-group">
                                <label for="ddlLocationOfLesions">Location of Lesions</label>
        <asp:ListBox ID="ddlLocationOfLesions" ClientIDMode="Static" CssClass="form-control" runat="server"  SelectionMode="Multiple"></asp:ListBox> 
                                    </div>

                                <div class="form-group">
                                <label for="ddlTemperature">Temperature</label>
            <asp:DropDownList ID="ddlTemperature" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static" 
                                DataSourceID="ObjTemperature" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjTemperature" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.Temperature, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                                    </div>

                                <div class="form-group">
                                <label for="ddlAppearance">Appearance</label>
            <asp:DropDownList ID="ddlAppearance" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static" 
                                DataSourceID="ObjAppearance" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjAppearance" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.Appearance, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                                    </div>
                                                            
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkElevated"> Elevated
                </label>
              </div>

                                <div class="form-group">
                                <label for="txtNumberOfLesions">Number of Lesions</label>
                        <input type="text" runat="server" class="form-control" id="txtNumberOfLesions" title="Number of Lesions" required="" placeholder="Enter Number of Lesions"/>                            
                            </div>
      
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkDeviated"> Deviated
                </label>
              </div>

                            <div class="form-group">
                                <label for="txtSize">Size(cm)</label>
                        <input type="text" runat="server" class="form-control" id="txtSize" title="Size" required="" placeholder="Enter Size"/>
                               
                            </div>


                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkCracks"> Cracks
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkFissure"> Fissure
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkUlcer"> Ulcer
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkScales"> Scales
                </label>
              </div>
                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkDischarge"> Discharge
                </label>
              </div>
                                <div class="form-group">
                                <label for="ddlTypeOfDischarge">Type of Discharge</label>
            <asp:DropDownList ID="ddlTypeOfDischarge" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static" 
                                DataSourceID="ObjTypeOfDischarge" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjTypeOfDischarge" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.TypeOfDischarge, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                                    </div>

                                <div class="checkbox icheck">
                <label>
                  <input type="checkbox" id="chkFissures"> Fissures
                </label>
              </div>

                                <div>
                    <label for="txtAreolaColour">Areola Colour</label>
            <input type="text" runat="server" class="form-control" id="txtAreolaColour" title="Areola Colour" required="" placeholder="Enter Areola Colour"/>
              </div>

                               <div class="form-group">
                                <label for="txtSurface">Surface</label>
                <input type="text" runat="server" class="form-control" id="txSurface" title="Surface" required="" placeholder="Enter Surface"/>   
                               </div>

                                </div>

                                <div class="col-md-6">
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
            $("#ddlAxillaryLymphNodes").chosen({ placeholder_text_multiple: "Select Axillary Lymph Nodes" }),
            $("#ddlSupraClavicularNodes").chosen({ placeholder_text_multiple: "Select Supra Clavicular Nodes" })
            $("#ddlAnteriorChestWallNodules").chosen({ placeholder_text_multiple: "Select Anterior Chest Wall Nodules" }),
            $('#ddlBreastWithLesion').select2({ placeholder: "Please Select Breast With Lesion" }),
            $("#ddlLocationOfLesions").chosen({ placeholder_text_multiple: "Select Location Of Lesions" }),
             $('#ddlTemperature').select2({ placeholder: "Please Select Temperature" }),
             $('#ddlAppearance').select2({ placeholder: "Please Select Appearance" }),
             $('#ddlTypeOfDischarge').select2({ placeholder: "Please Select TypeOfDischarge" });
         });
    </script>
</asp:Content>
