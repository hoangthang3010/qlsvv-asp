<%@ Page Title="" Language="C#" MasterPageFile="~/trangchu.Master" AutoEventWireup="true" CodeBehind="dsdiem2.aspx.cs" Inherits="Doanbaove.dsdiem2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 70px;
            height: 45px;
        }
        .auto-style5 {
            width: 110px;
            height: 45px;
        }

        .auto-style7 {
            width: 226px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Cn">
        <%--<br />
        <asp:DropDownList ID="dll_madk" runat="server" CssClass="w3-select w3-border" DataSourceID="SqlDataSource2" DataTextField="ten" DataValueField="madk" Width="266px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="SELECT madk,madk + ' - ' + masv as 'ten' from tbl_chuyennganh order by macn"></asp:SqlDataSource>
        <br />--%>
        <asp:Label ID="lbl_tb" runat="server" ForeColor="Red"></asp:Label>
        <table>
            <tr>
                <td style="width:110px;">Mã môn học:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="tbx_mamon" runat="server" CssClass="w3-input w3-small  w3-border" Width="75px"></asp:TextBox>
                </td>
                <td class="auto-style2">Điểm C:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="tbx_diemc" runat="server" CssClass="w3-input w3-small  w3-border" Width="75px"></asp:TextBox>
                </td>

                <td class="auto-style2">Điểm B:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="tbx_diemb" runat="server" CssClass="w3-input w3-small  w3-border" Width="75px"></asp:TextBox>
                </td>
                <td class="auto-style2">Điểm A:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="tbx_diema" runat="server" CssClass="w3-input w3-small  w3-border" Width="75px"></asp:TextBox>
                </td>
               <td>
                    <asp:Button ID="update" runat="server" CssClass="w3-btn w3-blue" Text="Cập nhật" OnClick="update_Click" />
                </td>
            </tr>
            
        </table>
    </div>
    <br />
    <div style="text-align:center;">
        Tên sinh viên:
        <asp:Label ID="lbl_tensv" runat="server" Text=""></asp:Label>
        <br />
        Mã sinh viên:
        <asp:Label ID="lbl_masv" runat="server" Text=""></asp:Label>
        <br />
        Lớp:
        <asp:Label ID="lbl_lop" runat="server" Text=""></asp:Label>
        <br />
        Chuyên ngành:
        <asp:Label ID="lbl_cn" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <div id="test1">
        <table class="table" id="example">
            
            <tbody>
                <asp:Literal ID="dsach" runat="server"></asp:Literal>
            </tbody>
        </table>

    </div>
    <br />
    <table style="width: 100%;">
        <tr>
            <th class="auto-style7">Điểm trung bình hệ 10</th>
            <th>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></th>

        </tr>
        <tr>
            <th class="auto-style7">Điểm trung bình hệ 4</th>
            <th>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></th>

        </tr>
        <tr>
            <th class="auto-style7">Số tín chỉ tích lũy</th>
            <th>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></th>

        </tr>

    </table>
    <br />
</asp:Content>
