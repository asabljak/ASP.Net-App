<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="AntunIT.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Moj profil</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Moj profil</h1>

    <h3><asp:Label ID="Profil_Username" runat="server" Text="Label"></asp:Label></h3>

    <asp:Label ID="Profil_Ime" runat="server" Text="Label"></asp:Label>

    <asp:Label ID="Profil_Prezime" runat="server" Text="Label"></asp:Label> <br /> <br />

    <asp:Label ID="Profil_Email" runat="server" Text="Label"></asp:Label>

</asp:Content>
