<%@ Page Title="" Language="C#" MasterPageFile="~/trangchu.Master" AutoEventWireup="true" CodeBehind="dssinhvienView.aspx.cs" Inherits="Doanbaove.hososinhvienView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w3-padding-4" >
         
         <asp:Label ID="lbl_thongbao" runat="server" CssClass="error" Text="xxx" Visible="False" Font-Size="Small" ForeColor="Red"></asp:Label>
         <br />
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Vui lòng nhập đúng mã sinh viên" ControlToValidate="tbx_del" ForeColor="Red" ValidationExpression="\d{10}">Đây không phải Mã Sinh Viên ( 10 số)</asp:RegularExpressionValidator>
         <br />
         <div> 
        <div style="float:left;">
            <asp:TextBox ID="tbx_search" runat="server" CssClass="w3-input w3-small  w3-border" Width="100px" Height="36px" ></asp:TextBox>
        </div>
        <div style="float:left;">
            <asp:Button ID="btt_search" runat="server" Text="Tìm kiếm"  CssClass="w3-btn w3-blue" OnClick="btt_search_Click" Height="36px" Width="100px"/>
        </div>
         <div style="float:left; margin-left:50px">
               <asp:DropDownList ID="ddl_khoa" runat="server" CssClass="w3-select w3-border w3-small" Width="80px" Height="36px" DataSourceID="SqlDataSource_khoa" DataTextField="tenkhoa" DataValueField="makh" OnSelectedIndexChanged="ddl_khoa_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
               <asp:SqlDataSource ID="SqlDataSource_khoa" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="SELECT [makh], [tenkhoa] FROM [tbl_khoahoc]"></asp:SqlDataSource>
        </div>
         <div style="float:left;margin-left:20px;">
                <asp:DropDownList ID="ddl_chuyennganh" runat="server" CssClass="w3-select w3-small w3-border" OnSelectedIndexChanged="ddl_chuyennganh_SelectedIndexChanged" Width="220px" Height="36px" AutoPostBack="True" DataSourceID="SqlDataSource_chuyennganh" DataTextField="ten" DataValueField="macn">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource_chuyennganh" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="SELECT macn,Convert(nvarchar(2),macn,0) + ' - ' + tencn as 'ten' from tbl_chuyennganh order by macn"></asp:SqlDataSource>
          </div>
        <div style="float:left; margin-left:50px">
            <asp:Button ID="btt_add" runat="server" Text="Thêm"  CssClass="w3-btn w3-blue" OnClick="btt_add_Click" Height="36px" Width="80px" PostBackUrl="~/sinhvienadd.aspx" />
        &nbsp;</div>
        <div style="float:left;">
            <asp:Button ID="btt_edit" runat="server" Text="Sửa"  CssClass="w3-btn w3-blue" OnClick="btt_edit_Click" Height="36px" Width="80px"/>
        </div>
        <div style="float:left;">
            <asp:TextBox ID="tbx_del" runat="server" CssClass="w3-input w3-small  w3-border" Width="100px" Height="36px" ></asp:TextBox>
        </div>
        <div style="float:left;">
            <asp:Button ID="btt_del" runat="server" Text="Xóa"  CssClass="w3-btn w3-blue" OnClick="btt_del_Click" Height="36px" Width="80px"/>
        </div>
        
           
        </div>
       <br />
         <br />
         <h5 class="w3-large"><strong>Danh sách sinh viên: </strong></h5>
         <div style="margin-top:20px;">
                <asp:GridView ID="GridView1" runat="server" CssClass="w3-table-all w3-hoverable w3-bordered w3-card-4 w3-small" BorderStyle="None" EnableTheming="True" OnPageIndexChanging="GridView1_PageIndexChanging" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <HeaderStyle CssClass="w3-blue" />
                        <Columns>
                                <asp:TemplateField HeaderText="STT">
                                   <ItemTemplate>
                                       <asp:Label ID="numberrow" Text=" <%# Container.DataItemIndex + 1 %>" runat="server"></asp:Label>
                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                 </asp:GridView>
        </div>
    </div>
</asp:Content>
