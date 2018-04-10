<%@ Page Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="EventsOnAdmission.aspx.cs" Inherits="TheCancerProject.ThePages.Create.EventsOnAdmission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section class="content-header">
        <h1>
            <small></small>
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
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">Events On Admission</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <form id="form1" runat="server">
                        <div class="box-body">
                            <div class="col-md-12">

                            <div class="col-md-6">

                                <%--<div class="form-group">
                                <label for="ddlInitialDiagnosis">Initial Diagnosis</label>
            <asp:DropDownList ID="ddlInitialDiagnosis" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static" 
                                onselectindexchanged="ddlInitialDiagnosis_IndexChanged"  DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>

                                    <p id="lblInitialDiagnosis"
            style="border: 5px groove #99CCFF; font-family: 'Comic Sans MS'; font-size: large; color: #FFFF00; background-color: #800000"></p>  
                                    <%--<asp:Label runat="server" id="lblInitialDiagnosis"/>--%>
                            <%--<asp:ObjectDataSource ID="ObjBreastWithLesion" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.BreastWithLesion, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
                                    </div>--%>
                                
                                <%--<div class="form-group">
                                <label for="txtPlan">Plan</label>
                        <textarea runat="server" class="form-control" id="Textarea2" cols="50" rows="10" required=""/>                              
                            </div> --%>

                                <div class="form-group">
                                <label for="txtDailyUpdatesAndManagement">Daily Updates And Management</label>
                        <textarea runat="server" class="form-control" id="txtDailyUpdatesAndManagement" cols="50" rows="10" required=""/>                              
                            </div> 

                                <div class="form-group">
                                <label for="txtChemotherapyRegimen">Chemotherapy Regimen</label>
                        <textarea runat="server" class="form-control" id="txtChemotherapyRegimen" cols="50" rows="10" required=""/>                              
                            </div> 

                                <div class="form-group">
                                <label for="txtRadiotherapyRegimen">Radiotherapy Regimen</label>
                        <textarea runat="server" class="form-control" id="txtRadiotherapyRegimen" cols="50" rows="10" required=""/>                              
                            </div> 

                                <%--<div class="form-group">
                                <label for="txtInvestigations">Investigations</label>
                        <textarea runat="server" class="form-control" id="Textarea6" cols="50" rows="10" required=""/>                              
                            </div> --%>

                                <div class="form-group">
                                <label for="txtComplicationsManagedOnAdmission">Complications Managed On Admission</label>
                        <textarea runat="server" class="form-control" id="txtComplicationsManagedOnAdmission" cols="50" rows="10" required=""/>                              
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
             $('#ddlInitialDiagnosis').select2({ placeholder: "Please Select Initial Diagnosis" });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('select[id$=ddlInitialDiagnosis]').bind("change keyup", function () {
                $('#lblInitialDiagnosis').html(
                $('select[id$=ddlInitialDiagnosis] :selected').text() + ":  " + $(this).val());
            });
        });
    </script>
</asp:Content>
