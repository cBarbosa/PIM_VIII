<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarDisciplina.aspx.cs" Inherits="PIM_VIII.CadastrarDisciplina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>

    <div id="FormDisciplina">
        <asp:Label ID="Label1" runat="server" Text="Disciplina:"></asp:Label>
        <asp:TextBox ID="txtDisciplina" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Curso:"></asp:Label>
        <asp:DropDownList ID="ddlCurso" runat="server">
        </asp:DropDownList>
        <br/>
        <asp:Label ID="Label3" runat="server" Text="Atividade:"></asp:Label>
        <asp:DropDownList ID="ddlAtividade" runat="server">
        </asp:DropDownList>
        <br />
    </div>

    <p align="center">
        <asp:Button ID="Button1" runat="server" Text="Inserir" OnClick="Button1_Click" />
    </p>
    <p align="center">
        &nbsp;</p>
    
    </asp:Content>