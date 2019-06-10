<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaMaestra.master" AutoEventWireup="true" CodeFile="Follow.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style20 {
        font-family: "Arial Black";
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="auto-style20">
    Selecciona un usuario:</p>
<p>
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="nick" DataValueField="nick">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TwitterDAI %>" SelectCommand="SELECT [nick] FROM [Usuario]"></asp:SqlDataSource>
</p>
<p class="auto-style20">
    ¿Qué quieres hacer con él?</p>
<p>
    &nbsp;<asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/fotos/seguir.png" OnClick="ImageButton7_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="ImageButton8" runat="server" Height="37px" ImageUrl="~/fotos/unfollow.png" OnClick="ImageButton8_Click" Width="117px" />
    </p>
<p>
    <asp:Label ID="Label5" runat="server" Text="[Label]" Font-Bold="True" Font-Names="Arial Black" Font-Size="Large" Visible="False"></asp:Label>
</p>
</asp:Content>

