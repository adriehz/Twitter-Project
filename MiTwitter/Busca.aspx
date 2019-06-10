<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaMaestra.master" AutoEventWireup="true" CodeFile="Busca.aspx.cs" Inherits="Busca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style22 {
            width: 283px;
            height: 70px;
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
<br />
<asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="nick" ForeColor="#333333" GridLines="None" Height="175px" Width="406px">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:CommandField SelectText="Seguir" ShowSelectButton="True" />
        <asp:BoundField DataField="nick" HeaderText="nick" ReadOnly="True" SortExpression="nick" />
    </Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TwitterDAI %>" SelectCommand="SELECT nick
FROM Usuario
WHERE nick LIKE @busca">
    <SelectParameters>
        <asp:CookieParameter CookieName="busca" Name="busca" />
    </SelectParameters>
</asp:SqlDataSource>
<p class="auto-style22">
    <strong>¿Qué quieres hacer con él?</strong></p>
    <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/fotos/seguir.png" OnClick="ImageButton7_Click" />
    <asp:ImageButton ID="ImageButton8" runat="server" Height="37px" ImageUrl="~/fotos/unfollow.png" OnClick="ImageButton8_Click" Width="117px" />
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="[Label]" Font-Bold="True" Font-Names="Arial Black" Font-Size="Large" Visible="False"></asp:Label>
<br />
<br />
</asp:Content>

