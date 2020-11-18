<%@ Page Title="" Language="C#" MasterPageFile="~/trangchu.Master" AutoEventWireup="true" CodeBehind="dslophocView.aspx.cs" Inherits="Doanbaove.dslophoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container">
            <h5 class="w3-large"><strong> Danh sách lớp: </strong></h5>
            <table class="w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white w3-card">
            <%--<tr><td colspan="3"><span onclick="this.parentElement.style.display='none'" class="w3-closebtn w3-padding w3-margin-right w3-medium">x</span></td></tr>--%>
                <tr class="w3-blue w3-center">
                    <td><b> STT</b></td><td><b>Tên lớp</b></td><td><b>Bộ môn</b></td><td><b>Tên giảng viên</b></td><td><b>Chi tiết</b></td>
                </tr>
            <asp:Literal ID="ltr_sv_lop" runat="server" Mode="Transform"></asp:Literal>
            <%-- Sử dụng control Literal hiển thị mã chuyển đổi HTML --%>
          </table>
        </div>
</asp:Content>
