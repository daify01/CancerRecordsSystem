<%@ Page Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="ClinicVisits.aspx.cs" Inherits="TheCancerProject.ThePages.Create.ClinicVisits" %>
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
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">Clinic Visits</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <form id="form1" runat="server">
                        <div class="box-body">
                            <div class="col-md-12">

                            <div class="col-md-6">

                                <div>
                    <label for="dateAdmissionDate">Next Appointment</label>
            <input type="date" id="dateAppointmentDate" name="bday" class="form-control" runat="server">
              </div>

                                <div class="form-group">
                                <label for="txtPlan">Clinic Summary</label>
                        <textarea runat="server" class="form-control" id="txtSummary" cols="80" rows="20" required=""/>                              
                            </div> 
                                
                                </div>

                                <div class="col-md-3">
                                </div>                                                              
                                                              

                                </div>
                            <div class="box-footer">
            <button type="button"  id="btnNext" CssClass="next-btn" runat="server" class="btn btn-flat btn-primary col-md-6" OnServerClick="btnNext_Click">Save</button>
            </div>      

                            <div class="box-footer">
            <button type="button"  id="btnFinish" CssClass="next-btn" runat="server" class="btn btn-flat btn-primary pull-right" OnServerClick="btnFinsih_Click">Finish</button>
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
</asp:Content>
