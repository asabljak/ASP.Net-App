<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AntunIT.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registracija korisnika</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="regForm">
        <h1>Dodavanje korisnika</h1>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="RegisterBttn">
            <asp:Label ID="NewNameLbl" runat="server" Text="Ime:"></asp:Label> <br />
            <asp:TextBox ID="NewNameTb" runat="server"></asp:TextBox> <br /> <br />

            <asp:Label ID="NewSurnameLbl" runat="server" Text="Prezime:"></asp:Label> <br />
            <asp:TextBox ID="NewSurnameTb" runat="server"></asp:TextBox> <br /> <br />

            <asp:Label ID="NewUsernameLbl" runat="server" Text="Korisničko ime:"></asp:Label> <br />
            <asp:TextBox ID="NewUsernameTb" runat="server"></asp:TextBox> <br /> <br />

            <asp:Label ID="NewUserEmailLbl" runat="server" Text="Email:"></asp:Label> <br />
            <asp:TextBox ID="NewUserEmailTb" runat="server" TextMode="Email"></asp:TextBox> <br /><br />
                
            <asp:Button ID="RegisterBttn" runat="server" Text="Kreiraj" OnClick="RegisterBttn_Click" /> <br /> <br />
        </asp:Panel>
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

