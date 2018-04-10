<%@ Page Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="Procedures.aspx.cs" Inherits="TheCancerProject.ThePages.Create.Procedures" %>
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
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">Procedures</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <form id="form1" runat="server">
                        <div class="box-body">
                            <div class="col-md-12">

                            <div class="col-md-6">

                                <div class="form-group">
                                <label for="txtProceduresDone">Procedures Done</label>
                        <textarea runat="server" class="form-control" id="txtProceduresDone" cols="200" rows="30" required=""/>                              
                            </div> 

                                <div class="form-group">
                                <label for="txtPostOpOrders">Post Op Orders</label>
                        <textarea runat="server" class="form-control" id="txtPostOpOrders" cols="50" rows="30" required=""/>                              
                            </div>

                                <div class="form-group">
                                <label for="txtDischargeMedicationsWithDoses">Discharge Medications With Doses</label>
                        <textarea runat="server" class="form-control" id="txtDischargeMedicationsWithDoses" cols="30" rows="30" required=""/>                              
                            </div>

                                <div class="form-group">
                                <label for="ddlDischargeState">Discharge State</label>
            <asp:DropDownList ID="ddlDischargeState" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static"
                                DataSourceID="ObjDischargeState" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjDischargeState" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.DischargeState, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
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
    <%--<script type="text/javascript">  
        $(document).ready(function () {
            $("#ddlDischargeMedicationsWithDoses").chosen({ placeholder_text_multiple: "Select Medical History" });
        });
        </script>--%>
    <script type="text/javascript">
         $(function () {
             $('#ddlDischargeState').select2({ placeholder: "Please Select A Discharge State" })
         });
    </script>
</asp:Content>
