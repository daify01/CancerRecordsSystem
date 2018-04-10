<%@ Page Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="HistoryAndPreliminaryExamination.aspx.cs" Inherits="TheCancerProject.ThePages.Create.HistoryAndPreliminaryExamination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section class="header">
         <hr />
         <h1>General Examination
            <small>General Examination</small>
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
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">Other History</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <form id="form1" runat="server">
                        <div class="box-body">
                            <div class="col-md-12">

                            <div class="col-md-6">
                                <div class="form-group">
                                <label for="ddlPastMedHistory">Past Medical History</label>
        
            <asp:ListBox ID="ddlPastMedHistory" ClientIDMode="Static" CssClass="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox> 
            <%--<asp:DropDownList ID="ddlPastMedHistory" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static"
                                DataSourceID="ObjPastMedHistory" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjPastMedHistory" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.PastMedicalHistory, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
                                    </div>

                                <div class="form-group">
                                <label for="txtPastSurgicalHistory">Past Surgical Hsitory</label>
                        <textarea runat="server" class="form-control" id="txtPastSurgicalHistory" cols="50" rows="10" required=""/>                              
                            </div>
      
                            <div class="form-group">
                                <label for="txtParity">Parity</label>
                        <input type="text" runat="server" class="form-control" id="txtParity" title="Parity" required="" placeholder="Enter Parity"/>
                               
                            </div>

                                <div>
                    <label for="dateMenarche">Menarche</label>
            <input type="date" id="dateMenarche" name="bday" class="form-control">
              </div>

                               <div class="form-group">
                                <label for="txtDurationOfMenses">Duration of Menses (Days)</label>
                <input type="text" runat="server" class="form-control" id="txtDurationOfMenses" title="Duration of Menses" required="" placeholder="Enter Duration of Menses"/>   
                               </div>

                                <div class="form-group">
                                <label for="txtLengthOfMenstrualCycle">Length of Menstrual Cycle (Days)</label>
                <input type="text" runat="server" class="form-control" id="txtLengthOfMenstrualCycle" title="Length of Menstrual Cycle" required="" placeholder="Enter Length Of Menstrual Cycle"/>   
                               </div>

                                 <div class="form-group">
                                <label for="txtRoutineMedications">Routine Medications</label>
                <input type="text" runat="server" class="form-control" id="txtRoutineMedications" title="Routine Medications" required="" placeholder="Enter Routine Medications"/>   
                               </div>

                                 <div class="form-group">
                                <label for="txtAllergicReactions">Allergic Reactions</label>
                <input type="text" runat="server" class="form-control" id="txtAllergicReactions" title="Allergic Reactions" required="" placeholder="Enter Allergic Reactions"/>   
                               </div>                                

                                <div class="form-group">
                                <label for="txtAllergicReactions">Allergic Reactions</label>
                <input type="text" runat="server" class="form-control" id="Text4" title="Allergic Reactions" required="" placeholder="Enter Length Of Menstrual Cycle"/>   
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
            $("#ddlPastMedHistory").chosen({ placeholder_text_multiple: "Select Medical History" });
        });
        </script>
    <%--<script type="text/javascript">
         $(function () {
             $('#ddlPastMedHistory').select2({ placeholder: "Please Select A Complaint" })
         });
    </script>--%>
</asp:Content>
