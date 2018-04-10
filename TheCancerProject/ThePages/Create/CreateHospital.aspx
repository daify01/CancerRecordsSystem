<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateHospital.aspx.cs" Inherits="TheCancerProject.ThePages.CreateHospital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>User Management
            <small>Create Super Admin</small>
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
                  <h3 class="box-title" style="color:whitesmoke; font-family:Helvetica, Arial, sans-serif;">Create Hospital</h3>
                </div><!-- /.box-header -->
                    <!-- /.box-header -->

                    <!-- form start -->
                    <%--<form id="form1" runat="server">--%>
                        <div class="box-body">
                            <div class="col-md-6">
                             <input type="hidden" runat="server" id="TextBoxId"/>
                            <div class="form-group">
                                <label for="TextBoxNameFName">Name</label>
                        <input type="text" runat="server" class="form-control" id="TextBoxNameFName" title="Firstnames" pattern="[A-Za-z]*" maxlength="200" required="" placeholder="Enter Name"/>
                               
                            </div>
                             <div class="form-group">
                                 <label for="TextBoxNameLName">Address</label>
                        <input type="text" runat="server" class="form-control" id="TextBoxNameLName" title="LastName" pattern="[A-Za-z]*" maxlength="200" required="" placeholder="Enter Name"/>                                
                            </div>
                                </div>

                            <div class="col-md-6">
                            <div class="form-group">
                                <label for="TextBoxNameEmail">Email</label>
                        <input type="text" runat="server" class="form-control" id="TextBoxNameEmail" title="Enter proper email format" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$" maxlength="80" required="" placeholder="Enter Email"/>
                             
                            </div>                            
                            
                            <div class="form-group">
                                <label for="TextBoxNamePhone">PhoneNumber</label>
                        <input type="text" runat="server" class="form-control" id="TextBoxNamePhone" title="11 digit Phone Number, no spacing" pattern="[0-9][0-9]{10,10}" maxlength="15" required="" placeholder="Enter Phone"/>
                              
                            </div>

                        

                        <div class="box-footer">
                            <input type="submit" runat="server" OnServerClick="searchsubmit_OnServerClick" id="searchsubmit" class="btn btn-flat btn-primary pull-right" name="Add"/>
                           
                        </div>
                                </div>
                            </div>

                   <%-- </form>--%>
                </div>
                <!-- /.box -->

            </div>
            <!--/.col (right) -->
        </div>
        <!-- /.row -->
    </section>
    <!-- /.content -->
</asp:Content>
