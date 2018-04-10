<%@ Page Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="Investigation2.aspx.cs" Inherits="TheCancerProject.ThePages.Create.Investigation2" %>
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
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">Add Investigation Results</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <form id="form1" runat="server">
                        <div class="box-body">
                            <div class="col-md-12">

                                <div class="form-group">
                                    <asp:Panel ID="pnlImage" runat="server">
                                        <div class="col-md-5">
                                            <label for="summary">UPLOAD A PHOTO</label>
                                        <%--<asp:Label ID="lblUpload" runat="server" Text="Upload A Photo!"></asp:Label>--%>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                            <asp:Button ID="viewImage" class="btn btn-flat btn-primary" runat="server" Text="View Image"
    onclick="btnViewImage_Click" />
                                        <asp:Image ID="imgPicture" ImageUrl="~/dist/img/DefualtUploadImage.png" Visible = "true" runat="server" Height = "400px" Width = "400px" />
                                            </div>

                                        <div class="col-md-7">
                                            <br />
                                            <br />
                                        <label for="summary">Summary</label>
                                        <%--<asp:Label ID="lblSummary" runat="server" Text="Summary"></asp:Label>--%>
                                        <asp:TextBox id="txtSummary" TextMode="multiline" Columns="100" Rows="20" runat="server" />

                                        <br />
                                        <asp:Label ID="lblDateUploaded" runat="server" Text="Date Uploaded: "></asp:Label>
                                            </div>

                                        <br />

                                        <div class="col-md-3">
                                            </div>
                                        <asp:Button ID="saveEntries" class="btn btn-flat btn-primary col-md-6" runat="server" Text="Save Entries"
    onclick="ibtnUpload_Click" />
                                        <asp:Label ID="lblErrorMsg" ForeColor="Red" runat="server"></asp:Label>
                                    </asp:Panel>

                                </div>    
                                
                                <div class="row">
                                </div>                           
                                    
                                             <%--<div class="form-group">                                                                                
                                    <div class="row">
                                        <br />
                                    <asp:Button ID="addNewIvestigation" class="btn btn-flat btn-primary col-md-12" BackColor="#663300" runat="server" Text="Add New Investigation"
    onclick="btnAddNewInvestigation_Click" />
                                        </div>  
                                                  </div> --%>                          

                                </div>

                            <label for="summary">History Of Investigations For Patient</label>

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                     AllowPaging="True" Width="100%"  OnDataBound="GridView1_DataBound"
                    onrowcommand="GridView1_RowCommand" HeaderStyle-CssClass="dataViewHeader">
                    <Columns>
                        <asp:TemplateField HeaderText="S/N">
                            <ItemTemplate>
                                <asp:Label ID="IdNo" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="dataViewRow" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Summary">
                            <ItemTemplate>
                                <asp:Label ID="Label100" runat="server" Text='<%#Eval("Summary") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="dataViewRow" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Patient's Hospital No">
                            <ItemTemplate>
                                <asp:Label ID="Label71" runat="server" Text='<%#Eval("PatientHospitalNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="dataViewRow" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Date Uploaded" 
                            HeaderStyle-CssClass="dataViewHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("DateUpdated") %>'> </asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="dataViewHeader" />
                        </asp:TemplateField>
                        <%--<asp:TemplateField >
                            <ItemTemplate>
                               <asp:HyperLink ID="lnkViewImage" runat="server" NavigateUrl="#" Text="View Image" onclick='<%# GetPopupURL(Eval("Id")) %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField >
                            <ItemTemplate>
                               <asp:HyperLink ID="lnkViewImage" runat="server" NavigateUrl="#" Text="View Image"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns> 
                    <EmptyDataTemplate>
                        No Investigations were found that meet the search Criteria
                    </EmptyDataTemplate>

<HeaderStyle CssClass="dataViewHeader"></HeaderStyle>
                </asp:GridView>


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
</asp:Content>
