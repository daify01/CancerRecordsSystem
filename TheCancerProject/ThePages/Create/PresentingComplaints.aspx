<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="PresentingComplaints.aspx.cs" Inherits="TheCancerProject.ThePages.Create.PresentingComplaints" %>
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
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">Presenting Complaints</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <form id="form1" runat="server">
                        <div class="box-body">
                            <div class="col-md-12">

                            <div class="col-md-6">
                                <div class="form-group">
                                <label for="ddlPresentingComplaints">Complaint</label>
        
                                    
            <asp:ListBox ID="ddlPresentingComplaints" ClientIDMode="Static" CssClass="form-control" runat="server" SelectionMode="Multiple"></asp:ListBox> 
            <%--<asp:DropDownList ID="ddlPresentingComplaints" runat="server" AppendDataBoundItems="True" class="chosen-default" ClientIDMode="Static"
                                DataSourceID="ObjPresentingComplaints" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>--%>
                            <%--<asp:ObjectDataSource ID="ObjPresentingComplaints" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.PresentedComplaints, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
                                    </div>
      
                            <div class="form-group">
                                <label for="txtDuration">Duration of Complaints</label>
                        <input type="text" runat="server" class="form-control" id="TxtDuration" title="Duration" required="" placeholder="Enter Duration"/>
                               
                            </div>

                                <div class="form-group">
                                <label for="txtHistoryOfComplaints">History of Presenting Complaints</label>
                        <textarea runat="server" class="form-control" id="txtHistoryOfComplaints" cols="70" rows="40" required=""/>                               
                            </div>

                                <div class="form-group">
                                <label for="ddlPresentingComplaints">Cause</label>
        
            <asp:ListBox ID="ddlCause" ClientIDMode="Static" CssClass="form-control" runat="server"  SelectionMode="Multiple"></asp:ListBox> 
            <%--<asp:DropDownList ID="ddlCause" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static"
                                DataSourceID="ObjCause" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCause" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.Cause, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
                                    </div>

                                <div class="form-group">
                                <label for="ddlPresentingComplaints">Complications</label>
        
            <asp:ListBox ID="ddlComplications" ClientIDMode="Static" CssClass="form-control" runat="server"  SelectionMode="Multiple"></asp:ListBox> 
            <%--<asp:DropDownList ID="ddlComplications" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static"
                                DataSourceID="ObjComplications" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjComplications" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.Complications, TheCancerProject.Core" Name="enumStringType"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>--%>
                                    </div>

                                <div class="form-group">
                                <label for="ddlPresentingComplaints">Care</label>

        <asp:ListBox ID="ddlCare" ClientIDMode="Static" CssClass="form-control" runat="server"  SelectionMode="Multiple"></asp:ListBox> 
            <%--<asp:DropDownList ID="ddlCare" runat="server" AppendDataBoundItems="True" CssClass="form-control" ClientIDMode="Static"
                                DataSourceID="ObjCare" DataTextField="Name" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjCare" runat="server" SelectMethod="GetEnumNames"
                                TypeName="TheCancerProject.Core.Utilities.Utilities">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="TheCancerProject.Core.Care, TheCancerProject.Core" Name="enumStringType"
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
        <%--<button type="button"  id="btnPrint" CssClass="next-btn" runat="server" class="btn btn-flat btn-primary pull-left" OnServerClick="btnPrint_Click">Print</button>--%>
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
            $("#ddlPresentingComplaints").chosen({ placeholder_text_multiple: "Select The Complaints" }),
            $("#ddlCause").chosen({ placeholder_text_multiple: "Select Possible Causes" })
            $("#ddlComplications").chosen({ placeholder_text_multiple: "Select Complications" })
            $("#ddlCare").chosen({ placeholder_text_multiple: "Select Relevant Cares" });
        });
        </script>
    <%--<script type="text/javascript">
         $(function () {
             //$('#ddlPresentingComplaints').select2({ placeholder: "Please Select A Complaint" }),
             ////$('#ddlCause').select2({ placeholder: "Please Select Cause" });
             //$('#ddlComplications').select2({ placeholder: "Please Select A Complication" }),
             //$('#ddlCare').select2({ placeholder: "Please Select Care" });
         });
    </script>--%>
</asp:Content>
