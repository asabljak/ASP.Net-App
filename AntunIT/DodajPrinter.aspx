<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="DodajPrinter.aspx.cs" Inherits="AntunIT.DodajPrinter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dodavanje pisača</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Dodavanje pisača</h1>
    <br />
        <asp:Label ID="NewPrinterNameLbl" runat="server" Text="Proizvođač:"></asp:Label> <br />
        <asp:TextBox ID="NewPrinterNameTb" runat="server"></asp:TextBox> <br /> <br />

        <asp:Label ID="NewPrinterModelLbl" runat="server" Text="Model:"></asp:Label> <br />
        <asp:TextBox ID="NewPrinterModelTb" runat="server"></asp:TextBox> <br /> <br />

        <asp:Label ID="NewPrinterTipLbl" runat="server" Text="Tip:"></asp:Label> <br />
        <asp:DropDownList ID="NewPrinterTipDD" runat="server" AutoPostBack="true">
            <asp:ListItem>Laserski</asp:ListItem>
            <asp:ListItem>Tintni</asp:ListItem>
        </asp:DropDownList> <br /> <br />

        <asp:Label ID="NewPrinterLokacijaLbl" runat="server" Text="Lokacija:"></asp:Label> <br />
        <asp:TextBox ID="NewPrinterLokacijaTb" runat="server"></asp:TextBox> <br /><br />

        <asp:Button ID="DodajPrinterBtttn" runat="server" Text="Dodaj" OnClick="RegisterBttn_Click" /> <br /> <br />
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
</asp:Content>
