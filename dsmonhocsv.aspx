<%@ Page Title="" Language="C#" MasterPageFile="~/trangchu.Master" AutoEventWireup="true" CodeBehind="dsmonhocsv.aspx.cs" Inherits="Doanbaove.dsmonhocsv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center;">
        <asp:Label ID="lbl_tensv" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lbl_masv" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lbl_cn" runat="server" Text=""></asp:Label>
    </div>
     <br />
        <p class="w3-large">
            <asp:Label ID="lbl_tb" runat="server" ForeColor="Red"></asp:Label>
        </p>
    <table>
        <tr>
            <td></td>
            
            <td style="text-align: center;">Mã môn học</td>
            <td></td>
        </tr>
        <tr>
            <td>
            <div style="float:left;">
                <asp:Button ID="btt_add" runat="server" Text="Thêm"  CssClass="w3-btn w3-blue" OnClick="btt_add_Click" Height="36px" Width="80px"/>
            </div></td>
            <td>
            <div style="float:left;">
                <asp:TextBox ID="tbx_mamh" runat="server" CssClass="w3-input w3-small  w3-border" Width="136px" Height="36px" OnTextChanged="tbx_mamh_TextChanged"></asp:TextBox>
            </div></td>
            <td>
            <div style="float:left;">
                <asp:Button ID="btt_del" runat="server" Text="Xóa"  CssClass="w3-btn w3-blue" OnClick="btt_del_Click" Height="36px" Width="80px"/>
            </div></td>
        </tr>
    </table>
        <%--<asp:Label ID="lbl_note1" runat="server" Text="* Nhập mã điều kiện và mã môn học để thêm * -|- * Nhập mã môn học để xóa *"></asp:Label>--%>
    <div id="test1">
        <br />
        <table class="w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white w3-card">
            <tr class="w3-blue w3-center">
                    <td><b> STT</b></td><td><b>Mã môn học</b></td><td><b>Tên môn học</b></td><td><b>Số tín chỉ</b></td>
                </tr>
            <tbody>
                <asp:Literal ID="dsach" runat="server"></asp:Literal>
            </tbody>
        </table>
    </div>
</asp:Content>
