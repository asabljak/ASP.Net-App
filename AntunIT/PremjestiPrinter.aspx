<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="PremjestiPrinter.aspx.cs" Inherits="AntunIT.PremjestiPrinter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Premjesti pisač</title>

    <script type="text/javascript">
        function setText() {
            var lokacija = document.getElementById("ContentPlaceHolder1_NovaLokacijaTb");
            document.getElementById("ContentPlaceHolder1_HiddenLokacija").value = lokacija.value;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Premjesti pisač</h1>

    <asp:Label ID="Label1" runat="server" Text="Odaberite pisač"></asp:Label> <br />
    <asp:DropDownList ID="PrineriZaPremjestanjeDropDown" runat="server" OnSelectedIndexChanged="PrineriZaPremjestanjeDropDown_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList> <br /><br />

    <asp:Panel ID="Panel1" runat="server" DefaultButton="PromijeniLokacijuBttn">
        <asp:Label ID="NovaLokacijaLbl" runat="server" Text="Lokacija:"></asp:Label> <br />
        <asp:TextBox ID="NovaLokacijaTb" runat="server"></asp:TextBox> <br /><br />

        <asp:Button ID="PromijeniLokacijuBttn" runat="server" Text="Promijeni" OnClientClick="setText()" OnClick="PromijeniLokacijuBttn_Click" />
    </asp:Panel>

    <div class="hidden" runat="server">
        <asp:TextBox ID="HiddenLokacija" runat="server" CssClass=""></asp:TextBox>
    </div>
</asp:Content>

