<%@ Page Title="" Language="C#" MasterPageFile="~/trangchu.Master" AutoEventWireup="true" CodeBehind="dsmonhocView.aspx.cs" Inherits="Doanbaove.dsmonhocView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container">
            <h5 class="w3-large"><strong> Xem môn học của từng sinh viên: </strong></h5>
            <%--<div class="dn" style="margin-left:50px;"> 
                <span>Nhập mã sinh viên</span>
                <asp:TextBox ID="txtMaSV" runat="server" CssClass="w3-input w3-small  w3-border" Width="100px"></asp:TextBox>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Vui lòng nhập đúng mã sinh viên" ControlToValidate="txtMaSV" ForeColor="Red" ValidationExpression="\d{10}">Đây không phải Mã Sinh Viên ( 10 số)</asp:RegularExpressionValidator>     
                <br />
                <asp:Button ID="btt_ok" runat="server" CssClass="w3-btn w3-blue" Text="OK" class="btn btn-success" OnClick="btt_ok_Click" Width="81px"/>        
                &nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>--%>
            <div class="dn" style="margin-left:50px;"> 
                <span>Nhập mã Sinh viên</span>
                <br />
                <br />
                <table>
                    <tr>
                        <td><asp:TextBox ID="txtMaSV" runat="server" CssClass="w3-input w3-small  w3-border" Width="100px" Height="35"></asp:TextBox></td>  
                        <td><asp:Button ID="btt_ok" runat="server" CssClass="w3-btn w3-blue" Text="OK" class="btn btn-success" Height="35" OnClick="btt_ok_Click"/></td>
                    </tr>
                </table>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text=""></asp:Label><br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Vui lòng nhập đúng mã sinh viên" ControlToValidate="txtMaSV" ForeColor="Red" ValidationExpression="\d{10}">Đây không phải Mã Sinh Viên ( 10 số)</asp:RegularExpressionValidator>
        
             </div>
            <h5 class="w3-large"><strong> Danh sách môn học: </strong></h5>
            <table class="w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white w3-card">
            <%--<tr><td colspan="3"><span onclick="this.parentElement.style.display='none'" class="w3-closebtn w3-padding w3-margin-right w3-medium">x</span></td></tr>--%>
                <tr class="w3-blue w3-center">
                    <td><b> STT</b></td><td><b>Mã môn học</b></td><td><b>Tên môn học</b></td><td><b>Số tín chỉ</b></td><td><b>Chi tiết</b></td>
                </tr>
            <asp:Literal ID="ltr_sv_mh" runat="server" Mode="Transform"></asp:Literal>
            <%-- Sử dụng control Literal hiển thị mã chuyển đổi HTML --%>
          </table>
        </div>
</asp:Content>
