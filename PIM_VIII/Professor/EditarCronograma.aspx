﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCronograma.aspx.cs" Inherits="PIM_VIII.Professor.EditarCronograma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" Text="Curso" ></asp:Label>
                <br/>
                <asp:DropDownList ID="dpCurso" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label5" runat="server" Text="Disciplina" ></asp:Label>
                <br/>
                <asp:DropDownList ID="dpDisciplina" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" Text="Atividade" ></asp:Label>
                <br/>
                <asp:DropDownList ID="dpAtividade" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Data Inicio" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtDtInicio" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Data Fim" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtDtFim" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Gravar" />

            </td>
        </tr>
        
    </table>
</asp:Content>
