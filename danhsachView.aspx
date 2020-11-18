<%@ Page Title="" Language="C#" MasterPageFile="~/trangchu.Master" AutoEventWireup="true" CodeBehind="danhsachView.aspx.cs" Inherits="Doanbaove.danhsachView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-container">
    <h5 class="w3-large"><strong> <asp:Label ID="lbl_tieude" runat="server" Text=""></asp:Label><asp:Label ID="lbl_ma" runat="server" Text=""></asp:Label> </strong></h5>
        <p class="w3-large">
            <asp:Label ID="lbl_tb" runat="server" ForeColor="Red"></asp:Label>
        </p>
     <div class="w3-padding-4" >
        <table>
            <tr>
                <td></td>
                <td style="text-align:center;">
                    <asp:Label ID="lbl_sv" runat="server" Text="Mã sinh viên - Tên sinh viên"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td><div style="float:left;">
                    <asp:Button ID="btt_add" runat="server" Text="Thêm"  CssClass="w3-btn w3-blue" OnClick="btt_add_Click" Height="36px" Width="80px"/>
                </div></td>
                <td><div style="float:left;">
                       <asp:DropDownList ID="dll_masv" runat="server" CssClass="w3-input w3-border" Width="346px" Height="36px" MaxLength="10" DataTextField="ten" DataValueField="masv" DataSourceID="SqlDataSource3"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="SELECT masv,masv + ' - ' + tensv as 'ten'  FROM tbl_sinhvien order by masv"></asp:SqlDataSource>
                </div></td>
                <td><div style="float:left;">
                    <asp:Button ID="btt_del" runat="server" Text="Xóa"  CssClass="w3-btn w3-blue" OnClick="btt_del_Click" Height="36px" Width="80px"/>
                </div></td>
            </tr>
        </table>
        <table>
            <tr>
                <td></td>
                <td style="text-align:center;">
                    <asp:Label ID="lbl_msv" runat="server" Text="Mã sinh viên"></asp:Label>
                </td>
                <td></td>
                <td style="text-align:center;">
                    <asp:Label ID="lbl_lop" runat="server" Text="Tên chuyên ngành - Mã sinh viên - Tên sinh viên"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><div style="float:left;">
                    <asp:Button ID="btt_del1" runat="server" Text="Xóa"  CssClass="w3-btn w3-blue" OnClick="btt_del1_Click" Height="36px" Width="80px"/>
                </div></td>
                <td><div style="float:left;">
                    <asp:TextBox ID="tbx_del1" runat="server" CssClass="w3-input w3-small  w3-border" Width="100px" Height="36px" OnTextChanged="tbx_del1_TextChanged" ></asp:TextBox>
                </div></td>
                <td><div style="float:left; margin-left: 30px;">
                    <asp:Button ID="btt_add1" runat="server" Text="Thêm"  CssClass="w3-btn w3-blue" OnClick="btt_add1_Click" Height="36px" Width="80px"/>
                </div></td>
                <td><div style="float:left;">
                       <asp:DropDownList ID="dll_lop" runat="server" CssClass="w3-input w3-border" Width="523px" Height="36px" MaxLength="10" DataTextField="ten1" DataValueField="masv" DataSourceID="SqlDataSource1"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="SELECT Masv,tencn + ' - ' + masv + ' - ' + tensv  as 'ten1' FROM tbl_sinhvien inner join tbl_chuyennganh on tbl_sinhvien.Chuyennganh = tbl_chuyennganh.macn order by macn"></asp:SqlDataSource>
                </div></td>
                
            </tr>
        </table>
        <%--<asp:Label ID="lbl_note1" runat="server" Text="* Nhập mã điều kiện và mã sinh viên để thêm * -|- * Chọn sinh viên để xóa *"></asp:Label>--%>
<%--        <asp:Label ID="lbl_note2" runat="server" Text="* Nhập mã mã sinh viên, mã lớp để thêm - Nhập mã sinh viên để xóa *"></asp:Label>--%>
        <br />
        <br />
        <asp:Literal ID="lit_kq" runat="server"></asp:Literal>
        </div>
        </div>
</asp:Content>
