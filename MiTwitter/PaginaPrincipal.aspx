<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaMaestra.master" AutoEventWireup="true" CodeFile="PaginaPrincipal.aspx.cs" Inherits="PaginaPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" BorderStyle="Double" Caption="Mi Muro" CaptionAlign="Top" CellSpacing="10" Font-Bold="True" Font-Names="Arial" Font-Overline="False" Font-Strikeout="False" Height="364px" Width="639px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:CommandField SelectText="Like" ShowSelectButton="True" />
        <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" />
        <asp:BoundField DataField="nickStalkeado" HeaderText="Usuario" SortExpression="nickStalker" />
        <asp:BoundField DataField="texto" HeaderText="Tweet" SortExpression="texto" />
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TwitterDAI %>" SelectCommand="SELECT distinct texto, fecha, Seguidor.nickStalkeado
FROM Tweet INNER JOIN Usuario
ON Tweet.nick=Usuario.nick
INNER JOIN Seguidor 
ON Usuario.nick = Seguidor.nickStalkeado
Where nickStalker = @user
ORDER BY fecha DESC">
    <SelectParameters>
        <asp:CookieParameter CookieName="usuario" Name="user" />
    </SelectParameters>
</asp:SqlDataSource>
</asp:Content>

