﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="AntunIT.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Popis korisnika</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="">Popis korisnika</h1>
    <asp:AccessDataSource ID="AccessDataSourceKorisnici" runat="server" DataFile="~/App_Data/Database.mdb" SelectCommand="SELECT ID, Ime, Prezime, Email FROM Korisnici"></asp:AccessDataSource>
    <asp:GridView ID="GridViewKorisnici" CssClass="tablica" DataSourceID="AccessDataSourceKorisnici" OnSorting="makniSearch" runat="server" AllowPaging="True" PageSize="20" DataKeyNames="ID" AutoGenerateDeleteButton="false" AutoGenerateEditButton="false" AllowSorting="true"></asp:GridView>
      
    <br />
    <div id="content" runat="server">
            <asp:Panel runat="server" DefaultButton="TraziBttn">
                <asp:TextBox ID="TraziTb" runat="server" placeholder="Korisnik"></asp:TextBox>
                &nbsp;<asp:Button ID="TraziBttn" runat="server" OnClick="Trazi" Text="Traži" />
                &nbsp;<asp:Button ID="PonistiBttn" runat="server" OnClick="Trazi" Text="Poništi" />
            </asp:Panel>
    </div>
    <asp:Button ID="PonistiFilterBttn" runat="server" OnClick="Trazi" Text="Poništi" Visible="false"/>
</asp:Content>
