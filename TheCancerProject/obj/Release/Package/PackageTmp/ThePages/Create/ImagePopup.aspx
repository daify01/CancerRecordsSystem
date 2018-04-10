<%@ Page Title="" Language="C#" MasterPageFile="~/CancerProject.Master" AutoEventWireup="true" CodeBehind="ImagePopup.aspx.cs" Inherits="TheCancerProject.ThePages.Create.ImagePopup" %>
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
                                        <asp:Image ID="imgPicture" ImageUrl="~/dist/img/DefualtUploadImage.png" Visible = "true" runat="server" Height = "400px" Width = "400px" />
                                            </div>
                                </div>
                            

                                           

        </div>

                    </form>
                  </div>
                </div>
                <!-- /.box -->

            </div>
            <!--/.col (right) -->        
        <!-- /.row -->
    </section>
</asp:Content>
