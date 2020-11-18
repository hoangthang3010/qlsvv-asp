<%@ Page Title="" Language="C#" MasterPageFile="~/trangchu.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Doanbaove.home" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/animation.js"></script>
    <style>
        .row{
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <!-- Earnings (Monthly) Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Tổng số sinh viên</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lbl_sumsinhvien" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-users fa-2x text-gray-300"></i>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Earnings (Monthly) Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Tổng số giảng viên</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lbl_sumgiangvien" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-user-tie fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Earnings (Monthly) Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-info text-uppercase mb-1">Tổng số lớp học</div>
                            <div class="row no-gutters align-items-center">
                                <div class="col-auto">
                                    <div class="h5 mb-0 mr-3 font-weight-bold text-gray-800">
                                        <asp:Label ID="lbl_sumdoan" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col">
                                </div>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-book fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Pending Requests Card Example -->
        <div class="col-xl-3 col-md-6 mb-4">
            <div class="card border-left-warning shadow h-100 py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">Tổng số chuyên ngành</div>
                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                <asp:Label ID="lbl_sumchuyennganh" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-adjust fa-2x text-gray-300"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">Biểu đồ tỉ lệ sinh viên chuyên ngành</h6>
        </div>
        <div class="card-body">

            <%--  --%>
            <div id="tinhocmo">
                <h4 class="small font-weight-bold">Tin học Mỏ <span class="float-right">
                    <asp:Label ID="lbl_tinhocmo" runat="server" Text="Label"></asp:Label></span></h4>
                <div class="progress ">
                    <div class="progress-bar bg-danger" role="progressbar" style="width: 34.6%" aria-valuenow="20" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
            </div>

            <div id="popup_tinhocmo" style="display:none; margin-top: 10px;">
                <%--<asp:Literal ID="ltr_tinhocmo" runat="server"></asp:Literal>--%>
                <asp:GridView ID="GridView1" runat="server" class="table table-bordered dataTable" CssClass="w3-table-all w3-hoverable w3-bordered w3-card-4 w3-small" BorderStyle="None" AutoGenerateColumns="False" DataKeyNames="masv" DataSourceID="SqlDataSource1">
                    <HeaderStyle CssClass="w3-blue" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                       <asp:Label ID="numberrow" Text=" <%# Container.DataItemIndex + 1 %>" runat="server"></asp:Label>
                        
                                    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="masv" HeaderText="Mã SV" ReadOnly="True" SortExpression="masv" />
                        <asp:BoundField DataField="tensv" HeaderText="Tên SV" SortExpression="tensv" />
                        <asp:BoundField DataField="Column1" HeaderText="Giới tính" ReadOnly="True" SortExpression="Column1" />
                        <asp:BoundField DataField="Khoa" HeaderText="Khoá" SortExpression="Khoa" />
                        <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" SortExpression="Diachi" />
                        <asp:BoundField DataField="tencn" HeaderText="Tên chuyên ngành" SortExpression="tencn" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="Select masv, tensv, Case Gioitinh when 1 then N'Nữ' else N'Nam' end, Khoa,Diachi, tencn from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh = macn Where macn =1 order by Khoa"></asp:SqlDataSource>
                
            </div>

            <%--  --%>
            <div id="th_tracdia">
                <h4 class="small font-weight-bold">Tin học Trắc địa <span class="float-right">
                    <asp:Label ID="lbl_thtd" runat="server" Text="Label"></asp:Label></span></h4>
                <div class="progress ">
                    <div class="progress-bar bg-warning" role="progressbar" style="width: 11.5%" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
            </div>
            <div id="popup_thtd" style="display:none; margin-top: 10px;">  
                <asp:GridView ID="GridView2" runat="server" class="table table-bordered dataTable" CssClass="w3-table-all w3-hoverable w3-bordered w3-card-4 w3-small" BorderStyle="None" AutoGenerateColumns="False" DataKeyNames="masv" DataSourceID="SqlDataSource2">
                    <HeaderStyle CssClass="w3-blue" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                       <asp:Label ID="numberrow" Text=" <%# Container.DataItemIndex + 1 %>" runat="server"></asp:Label>
                        
                                    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="masv" HeaderText="Mã SV" ReadOnly="True" SortExpression="masv" />
                        <asp:BoundField DataField="tensv" HeaderText="Tên SV" SortExpression="tensv" />
                        <asp:BoundField DataField="Column1" HeaderText="Giới tính" ReadOnly="True" SortExpression="Column1" />
                        <asp:BoundField DataField="Khoa" HeaderText="Khoá" SortExpression="Khoa" />
                        <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" SortExpression="Diachi" />
                        <asp:BoundField DataField="tencn" HeaderText="Tên chuyên ngành" SortExpression="tencn" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="Select masv, tensv, Case Gioitinh when 1 then N'Nữ' else N'Nam' end, Khoa,Diachi, tencn from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh = macn Where macn =2 order by Khoa"></asp:SqlDataSource>
            </div>

            <%--  --%>
            <div id="thkt">
                <h4 class="small font-weight-bold">Tin học kinh tế <span class="float-right">
                    <asp:Label ID="lbl_thkt" runat="server" Text="Label"></asp:Label></span></h4>
                <div class="progress ">
                    <div class="progress-bar " role="progressbar" style="width: 15.4%" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
            </div>
            <div id="popup_thkt" style=" display: none; margin-top: 10px;">
                <asp:GridView ID="GridView3" runat="server" class="table table-bordered dataTable" CssClass="w3-table-all w3-hoverable w3-bordered w3-card-4 w3-small" BorderStyle="None" AutoGenerateColumns="False" DataKeyNames="masv" DataSourceID="SqlDataSource3">
                    <HeaderStyle CssClass="w3-blue" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                       <asp:Label ID="numberrow" Text=" <%# Container.DataItemIndex + 1 %>" runat="server"></asp:Label>
                        
                                    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="masv" HeaderText="Mã SV" ReadOnly="True" SortExpression="masv" />
                        <asp:BoundField DataField="tensv" HeaderText="Tên SV" SortExpression="tensv" />
                        <asp:BoundField DataField="Column1" HeaderText="Giới tính" ReadOnly="True" SortExpression="Column1" />
                        <asp:BoundField DataField="Khoa" HeaderText="Khoá" SortExpression="Khoa" />
                        <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" SortExpression="Diachi" />
                        <asp:BoundField DataField="tencn" HeaderText="Tên chuyên ngành" SortExpression="tencn" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="Select masv, tensv, Case Gioitinh when 1 then N'Nữ' else N'Nam' end, Khoa,Diachi, tencn from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh = macn Where macn = 3 order by Khoa"></asp:SqlDataSource>
            </div>

            <%--  --%>
            <div id="thdc">
                <h4 class="small font-weight-bold">Tin học Địa chất <span class="float-right">
                    <asp:Label ID="lbl_thdc" runat="server" Text="Label"></asp:Label></span></h4>
                <div class="progress ">
                    <div class="progress-bar bg-info" role="progressbar" style="width: 7.7%" aria-valuenow="80" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
            </div>
            <div id="popup_thdc" style="display: none; margin-top: 10px;">
                <asp:GridView ID="GridView4" runat="server"  class="table table-bordered dataTable" CssClass="w3-table-all w3-hoverable w3-bordered w3-card-4 w3-small" BorderStyle="None" AutoGenerateColumns="False" DataKeyNames="masv" DataSourceID="SqlDataSource4">
                    <HeaderStyle CssClass="w3-blue" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                       <asp:Label ID="numberrow" Text=" <%# Container.DataItemIndex + 1 %>" runat="server"></asp:Label>
                        
                                    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="masv" HeaderText="Mã SV" ReadOnly="True" SortExpression="masv" />
                        <asp:BoundField DataField="tensv" HeaderText="Tên SV" SortExpression="tensv" />
                        <asp:BoundField DataField="Column1" HeaderText="Giới tính" ReadOnly="True" SortExpression="Column1" />
                        <asp:BoundField DataField="Khoa" HeaderText="Khoá" SortExpression="Khoa" />
                        <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" SortExpression="Diachi" />
                        <asp:BoundField DataField="tencn" HeaderText="Tên chuyên ngành" SortExpression="tencn" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="Select masv, tensv, Case Gioitinh when 1 then N'Nữ' else N'Nam' end, Khoa,Diachi, tencn from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh = macn Where macn =4 order by Khoa"></asp:SqlDataSource>
            </div>

            <%--  --%>
            <div id="mmt">
                <h4 class="small font-weight-bold">Mạng máy tính <span class="float-right">
                    <asp:Label ID="lbl_mmt" runat="server" Text="Label"></asp:Label></span></h4>
                <div class="progress">
                    <div class="progress-bar bg-danger" role="progressbar" style="width: 3.8%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
            </div>
            <div id="popup_mmt" style=" display:none; margin-top: 10px;">
                <asp:GridView ID="GridView5" runat="server" class="table table-bordered dataTable" CssClass="w3-table-all w3-hoverable w3-bordered w3-card-4 w3-small" BorderStyle="None" AutoGenerateColumns="False" DataKeyNames="masv" DataSourceID="SqlDataSource5">
                    <HeaderStyle CssClass="w3-blue" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                       <asp:Label ID="numberrow" Text=" <%# Container.DataItemIndex + 1 %>" runat="server"></asp:Label>
                        
                                    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="masv" HeaderText="Mã SV" ReadOnly="True" SortExpression="masv" />
                        <asp:BoundField DataField="tensv" HeaderText="Tên SV" SortExpression="tensv" />
                        <asp:BoundField DataField="Column1" HeaderText="Giới tính" ReadOnly="True" SortExpression="Column1" />
                        <asp:BoundField DataField="Khoa" HeaderText="Khoá" SortExpression="Khoa" />
                        <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" SortExpression="Diachi" />
                        <asp:BoundField DataField="tencn" HeaderText="Tên chuyên ngành" SortExpression="tencn" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="Select masv, tensv, Case Gioitinh when 1 then N'Nam' else N'Nữ' end, Khoa,Diachi, tencn from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh = macn Where macn =5 order by Khoa"></asp:SqlDataSource>
            </div>
            <%--  --%>
            <div id="cnpm">
                <h4 class="small font-weight-bold">Công nghệ phần mềm <span class="float-right">
                    <asp:Label ID="lbl_cnpm" runat="server" Text="Label"></asp:Label></span></h4>
                <div class="progress">
                    <div class="progress-bar bg-secondary" role="progressbar" style="width: 26.9%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
            </div>
            <div id="popup_cnpm" style="display: none; margin-top: 10px;">
                <asp:GridView ID="GridView6" runat="server" class="table table-bordered dataTable" CssClass="w3-table-all w3-hoverable w3-bordered w3-card-4 w3-small" BorderStyle="None" AutoGenerateColumns="False" DataKeyNames="masv" DataSourceID="SqlDataSource6">
                    <HeaderStyle CssClass="w3-blue" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                       <asp:Label ID="numberrow" Text=" <%# Container.DataItemIndex + 1 %>" runat="server"></asp:Label>
                        
                                    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="masv" HeaderText="Mã SV" ReadOnly="True" SortExpression="masv" />
                        <asp:BoundField DataField="tensv" HeaderText="Tên SV" SortExpression="tensv" />
                        <asp:BoundField DataField="Column1" HeaderText="Giới tính" ReadOnly="True" SortExpression="Column1" />
                        <asp:BoundField DataField="Khoa" HeaderText="Khoá" SortExpression="Khoa" />
                        <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" SortExpression="Diachi" />
                        <asp:BoundField DataField="tencn" HeaderText="Tên chuyên ngành" SortExpression="tencn" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="Select masv, tensv, Case Gioitinh when 1 then N'Nam' else N'Nữ' end, Khoa,Diachi, tencn from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh = macn Where macn =6 order by Khoa"></asp:SqlDataSource>
            </div>
            <%--  --%>
            <div id="khmt">
                <h4 class="small font-weight-bold">Khoa học máy tính <span class="float-right">
                    <asp:Label ID="lbl_khmt" runat="server" Text="Label"></asp:Label></span></h4>
                <div class="progress">
                    <div class="progress-bar bg-success" role="progressbar" style="width: 0%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
            </div>
            <div id="popup_khmt" style="display: none; margin-top: 10px;">
                <asp:GridView ID="GridView7" runat="server" class="table table-bordered dataTable" CssClass="w3-table-all w3-hoverable w3-bordered w3-card-4 w3-small" BorderStyle="None" AutoGenerateColumns="False" DataKeyNames="masv" DataSourceID="SqlDataSource7">
                    <HeaderStyle CssClass="w3-blue" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                       <asp:Label ID="numberrow" Text=" <%# Container.DataItemIndex + 1 %>" runat="server"></asp:Label>
                        
                                    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="masv" HeaderText="Mã SV" ReadOnly="True" SortExpression="masv" />
                        <asp:BoundField DataField="tensv" HeaderText="Tên SV" SortExpression="tensv" />
                        <asp:BoundField DataField="Column1" HeaderText="Giới tính" ReadOnly="True" SortExpression="Column1" />
                        <asp:BoundField DataField="Khoa" HeaderText="Khoá" SortExpression="Khoa" />
                        <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" SortExpression="Diachi" />
                        <asp:BoundField DataField="tencn" HeaderText="Tên chuyên ngành" SortExpression="tencn" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="Select masv, tensv, Case Gioitinh when 1 then N'Nữ' else N'Nam' end, Khoa,Diachi, tencn from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh = macn Where macn =7 order by Khoa"></asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
