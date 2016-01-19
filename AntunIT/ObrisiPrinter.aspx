﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ObrisiPrinter.aspx.cs" Inherits="AntunIT.ObrisiPrinter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Brisanje pisača</title>

    <script>
        function confirmDelete() {
            return confirm("Jeste li sigurni da se želite odjaviti?");
        
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Brisanje pisača</h1>

    <asp:AccessDataSource ID="AccessDataSourcePrinteri" runat="server" DataFile="~/App_Data/Database.mdb" SelectCommand="SELECT ID, Naziv, Model, Vrsta, Lokacija FROM pisaci" DeleteCommand="DELETE FROM pisaci WHERE ID=?">
        <DeleteParameters>
            <asp:ControlParameter ControlID="GridViewPrinteri" Name="ID" PropertyName="SelectedValue" />
        </DeleteParameters>
    </asp:AccessDataSource>
    <asp:GridView ID="GridViewPrinteri" CssClass="tablica" DataSourceID="AccessDataSourcePrinteri" runat="server" OnRowDeleting="printWarning" AllowPaging="True" PageSize="20" DataKeyNames="ID" AutoGenerateDeleteButton="true" AutoGenerateEditButton="false" AllowSorting="true"></asp:GridView>
  
</asp:Content>
