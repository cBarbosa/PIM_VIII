<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="PIM_VIII.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p>
<asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
    <asp:TextBox ID="nome" runat="server"></asp:TextBox>
    </p>
    <p>
    <asp:Label ID="Label2" runat="server" Text="Matrícula"></asp:Label>&nbsp
    <asp:TextBox ID="matricula" runat="server"></asp:TextBox>&nbsp
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Senha"></asp:Label>&nbsp
    <asp:TextBox ID="senha" runat="server"></asp:TextBox>&nbsp
    </p>
    <asp:Button ID="Button1" runat="server" Text="Cadastrar" OnClick="Button1_Click" />    
</asp:Content>