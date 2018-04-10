<%@ Page Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="ViewListOfPatients.aspx.cs" Inherits="TheCancerProject.ThePages.View.ViewListOfPatients" %>
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
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">List of Patients</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <form id="form1" runat="server">
                        <div class="box-body">
                            <div class="col-md-12">                     

                                </div>

                            <label for="summary">HISTORY OF INVESTIGATIONS FOR PATIENT</label>

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                     AllowPaging="true" Width="100%"  PageSize="100" OnPageIndexChanging="OnPageIndexChanging" OnRowCommand="GridView1_RowCommand"
                     HeaderStyle-CssClass="dataViewHeader">
                    <Columns>
                        <asp:TemplateField HeaderText="S/N">
                            <ItemTemplate>
                                <asp:Label ID="IdNo" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="dataViewRow" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="Label100" runat="server" Text='<%#Eval("TheBiodata.Name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="dataViewRow" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Patient's Hospital No">
                            <ItemTemplate>
                                <asp:Label ID="Label71" runat="server" Text='<%#Eval("TheBiodata.HospitalNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="dataViewRow" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="PhoneNumber" 
                            HeaderStyle-CssClass="dataViewHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("TheBiodata.PhoneNumber") %>'> </asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="dataViewHeader" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Sex" 
                            HeaderStyle-CssClass="dataViewHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("TheBiodata.Sex") %>'> </asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="dataViewHeader" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField >
                            <ItemTemplate>
                               <asp:Button ID="btnGetPDFSummary" runat="server" OnClientClick='<%# String.Format("return confirm(\"Do you wish to download PDF File for this patient?\");") %>'
                                    Text="Get PDF Summary" CommandName="DownloadPDF" CommandArgument='<%# Eval("Id") %>'></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns> 
                    <EmptyDataTemplate>
                        No patients were found that meet the search Criteria
                    </EmptyDataTemplate>

<HeaderStyle CssClass="dataViewHeader"></HeaderStyle>
                </asp:GridView>


                            <div class="box-footer">
            <%--<button type="button"  id="btnNext" CssClass="next-btn" runat="server" class="btn btn-flat btn-primary pull-right" OnServerClick="btnNext_Click">Next</button>--%>
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
</asp:Content>
