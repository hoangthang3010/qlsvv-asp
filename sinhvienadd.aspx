<%@ Page Title="" Language="C#" MasterPageFile="~/trangchu.Master" AutoEventWireup="true" CodeBehind="sinhvienadd.aspx.cs" Inherits="Doanbaove.sinhvienadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 276px;
        }

        .auto-style2 {
            width: 218px;
            height: 241px;
        }

        .auto-style3 {
            width: 380px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w3-card-4" style="width:100%">
    <header class="w3-container w3-light-grey w3-medium">
            <h3> <strong>Thêm mới hồ sơ sinh viên</strong> </h3>
    </header>
    <div class="w3-container" style="background-color:white;">
      <hr/>
         <table class="w3-table" style="width:950px;">
            <tr>
               
                <td class="auto-style1"><label> Mã sinh viên(*): </label> </td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbx_masv" runat="server" CssClass="w3-input w3-border" Width="145px" MaxLength="10"></asp:TextBox>
                    
                </td>
                <td style="width:40px;"> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbx_masv" CssClass="error" Font-Size="Smaller" ForeColor="Red">x</asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbx_masv" CssClass="error" ErrorMessage="RegularExpressionValidator" ValidationExpression="[0-9]{10}" Font-Size="Smaller" ForeColor="Red">x</asp:RegularExpressionValidator>
               </td>
                 
            </tr>
            <tr>
                <td class="auto-style1"> <label>Họ tên sinh viên(*):</label></td>
                <td class="auto-style3">  <asp:TextBox ID="tbx_tensv" runat="server" CssClass="w3-input w3-border" Width="300px"></asp:TextBox></td>
                <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="tbx_tensv" CssClass="error" Font-Size="Smaller" ForeColor="Red">x</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style1"><label>Ngày sinh(*): </label></td>
                <td class="auto-style3">
                     Ngày
                     <asp:DropDownList ID="ddlngay" runat="server" CssClass="w3-select w3-border" Width="62px">
                     </asp:DropDownList>
&nbsp;tháng
                     &nbsp;<asp:DropDownList ID="ddlthang" runat="server" CssClass="w3-select w3-border" Width="73px">
                     </asp:DropDownList>
                     năm
                     <asp:DropDownList ID="ddlnam" runat="server" CssClass="w3-select w3-border" Width="87px">
                     </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <label>Giới tính:</label>
                </td>
                <td class="auto-style3">
                    <asp:RadioButton ID="rbt_nam" CssClass="w3-radio" GroupName="gt" runat="server" Text="Nam" Checked="true" />
                    <asp:RadioButton ID="rbt_nu" CssClass="w3-radio" GroupName="gt" runat="server" Text="Nữ" />
                </td>
                <td>

                </td>
            </tr>
            
            <tr>
                <td class="auto-style1">
                    <label> Khóa:</label>
                </td>
                <td class="auto-style3">
                   <asp:DropDownList ID="dll_khoa" runat="server" CssClass="w3-select w3-border" Width="176px" DataSourceID="SqlDataSource1" DataTextField="tenkhoa" DataValueField="makh">

                </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="SELECT [makh], [tenkhoa] FROM [tbl_khoahoc]"></asp:SqlDataSource>
                </td>
                <td>

                </td>
            </tr>
            
            <tr>
                <td class="auto-style1">
                    <label> Chuyên ngành:</label>
                </td>
                <td class="auto-style3">
                  <asp:DropDownList ID="dllchuyennganh" runat="server" CssClass="w3-select w3-border" Width="266px" DataSourceID="SqlDataSource2" DataTextField="ten" DataValueField="macn">

                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:connec_DATN %>" SelectCommand="SELECT macn,Convert(nvarchar(2),macn,0) + ' - ' + tencn as 'ten' from tbl_chuyennganh order by macn"></asp:SqlDataSource>
                </td>
                <td>

                </td>
            </tr>
            
            <tr>
                <td class="auto-style1">
                    <label>Email:</label>
                </td>
                <td class="auto-style3">
                      <asp:TextBox ID="tbx_email" runat="server" CssClass="w3-input w3-border" Width="308px"></asp:TextBox>
                </td>
                <td>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbx_email" CssClass="error" ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Font-Size="Smaller">x</asp:RegularExpressionValidator>

                </td>
            </tr>
            
            <tr>
                <td class="auto-style1">
                    <label> Điện thoại:</label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbx_dienthoai" runat="server" CssClass="w3-input w3-border" Width="193px" MaxLength="11"></asp:TextBox>
                </td>
                <td>

                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tbx_dienthoai" CssClass="error" ErrorMessage="CompareValidator" Operator="DataTypeCheck" Type="Integer" ForeColor="Red" Font-Size="Smaller">x</asp:CompareValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <label>Địa chỉ: </label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbx_diachi" runat="server" CssClass="w3-input w3-border" Height="45px" TextMode="MultiLine" Width="380px"></asp:TextBox>
                </td>
                <td>

                </td>
            </tr>
             <tr>
                 <td colspan="3">
                     <asp:Label ID="lbl_tb" runat="server" Text="xxx" CssClass="error" Visible="False" Font-Size="Smaller" ForeColor="Red"></asp:Label>
                 </td>
             </tr>
            <tr>
                <td colspan="3" class="w3-center">
                   
                    <asp:Button ID="btt_add" runat="server" CssClass="w3-btn w3-green" Text="Cập Nhật" OnClick="btt_add_Click" />
                     &nbsp;&nbsp;
                     <asp:Button ID="btt_cancel" runat="server" CssClass="w3-btn w3-red" Text="Hủy Bỏ" CausesValidation="False" />
          
                </td>
            </tr>
        </table>
               
         </div>
      
  </div>
</asp:Content>
