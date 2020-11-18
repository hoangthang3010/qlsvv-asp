<%@ Page Title="" Language="C#" MasterPageFile="~/trangchu.Master" AutoEventWireup="true" CodeBehind="dsgiangvienView.aspx.cs" Inherits="Doanbaove.dsgiangvien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/angular.js"></script>
    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/dsgiangvienCtrl.js"></script>
    <style>
        th{
            background-color: #4e73df;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="w3-container">
            <h5 class="w3-large"><strong> Danh sách giảng viên: </strong></h5>
            <asp:GridView ID="GridView1" runat="server" CssClass="w3-table-all w3-hoverable w3-bordered w3-card-4 w3-small" AutoGenerateColumns="False" DataKeyNames="Magv" DataSourceID="SqlDataSource1">
                <HeaderStyle CssClass="w3-blue" />
                <Columns>
                    <asp:BoundField DataField="Magv" HeaderText="Mã giảng viên" ReadOnly="True" SortExpression="Magv" />
                    <asp:BoundField DataField="Tengv" HeaderText="Tên giảng viên" SortExpression="Tengv" />
                    <asp:BoundField DataField="Namsinh" HeaderText="Năm sinh" SortExpression="Namsinh" />
                    <asp:BoundField DataField="Column1" HeaderText="Giới tính" SortExpression="Column1" ReadOnly="True" />
                    <asp:BoundField DataField="Hocvi" HeaderText="Học vị" SortExpression="Hocvi" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Dienthoai" HeaderText="Điện thoại" SortExpression="Dienthoai" />
                    <asp:BoundField DataField="Diachi" HeaderText="Địa chỉ" SortExpression="Diachi" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="SELECT Magv,Tengv,Namsinh,Case Gioitinh when 1 then N'Nữ' else N'Nam' end,Hocvi,Email,Dienthoai,Diachi FROM [tbl_giangvien]"></asp:SqlDataSource>
    </div>--%>
  <div ng-app="myApp" ng-controller="dsgiangvienCtrl">
 <table class="table">
  <thead class="thead-blue">
    <tr>
      <th scope="col">Mã GV</th>
      <th scope="col">Tên GV</th>
      <th scope="col">Năm sinh</th>
      <th scope="col">Giới tính</th>
      <th scope="col">Học vị</th>
      <th scope="col">Email</th>
      <th scope="col">Điện thoại</th>
      <th scope="col">Địa chỉ</th>
    </tr>
  </thead>
  <tbody>
    <tr ng-repeat="truyxuat in danhsachgiangvien">
      <td>{{ truyxuat.Magv }}</td>
      <td>{{ truyxuat.Tengv }}</td>
      <td>{{ truyxuat.Namsinh }}</td>
      <td>{{ truyxuat.Gioitinh }}</td>
      <td>{{ truyxuat.Hocvi }}</td>
      <td>{{ truyxuat.Email }}</td>
      <td>{{ truyxuat.Dienthoai }}</td>
      <td>{{ truyxuat.Diachi }}</td>
    </tr>
  </tbody>
</table>
  </div>
    
</asp:Content>
