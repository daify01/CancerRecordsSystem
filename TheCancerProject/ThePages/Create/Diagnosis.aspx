<%@ Page Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="Diagnosis.aspx.cs" Inherits="TheCancerProject.ThePages.Create.Diagnosis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="header">
         <hr />
         <h1>
            <small></small>
        </h1>
             <%--<small>History And Preliminary Examination</small>--%>
    </section>

        <!-- Main content -->
        <section class="content">
          <div class="row">
            <!-- left column -->
            <div class="col-md-6" style="width: 100%">
              <!-- general form elements -->
              <div class="box">
                <div class="box-header" style="background-color:steelblue">
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">Diagnosis</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <form id="form1" runat="server">
                        <div class="box-body">
                            <div class="col-md-12">

                            <div class="col-md-6">

                                <div class="form-group">
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
                                    </div>
                                
                                <div class="form-group">
                                <label for="txtPlan">Plan</label>
                        <textarea runat="server" class="form-control" id="txtPlan" cols="50" rows="10" required=""/>                              
                            </div> 

                                <div>
                    <label for="dateAdmissionDate">AdmissionDate</label>
            <input type="date" id="dateAdmissionDate" name="bday" class="form-control" runat="server">
              </div>

                                <div>
                    <label for="dateDischargeDate">DischargeDate</label>
            <input type="date" id="dateDischargeDate" name="bday" class="form-control" runat="server">
              </div>

                                <div class="form-group">
                                <label for="ddlFinalDiagnosis">Final Diagnosis</label>
            <asp:DropDownList ID="ddlFinalDiagnosis" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static" 
                                onselectindexchanged="ddlFinalDiagnosis_IndexChanged"  DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>

                                    <p id="lblFinalDiagnosis"
            style="border: 5px groove #99CCFF; font-family: 'Comic Sans MS'; font-size: large; color: #FFFF00; background-color: #800000"></p>  
                                    <%--<asp:Label runat="server" id="lblInitialDiagnosis"/>--%>
                            <%--<asp:ObjectDataSource ID="ObjBreastWithLesion" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.BreastWithLesion, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
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
            $('#ddlInitialDiagnosis').select2({ placeholder: "Please Select Initial Diagnosis" }),
            $('#ddlInitialDiagnosis').select2({ placeholder: "Please Select Initial Diagnosis" });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('select[id$=ddlFinalDiagnosis]').bind("change keyup", function () {
                $('#lblFinalDiagnosis').html(
                $('select[id$=ddlFinalDiagnosis] :selected').text() + ":  " + $(this).val());
            });
        });
    </script>
    <script type="text/javascript">
        $('select[id$=ddlInitialDiagnosis]').bind("change keyup", function () {
            $('#lblInitialDiagnosis').html(
            $('select[id$=ddlInitialDiagnosis] :selected').text() + ":  " + $(this).val());
        });
    </script>
</asp:Content>
