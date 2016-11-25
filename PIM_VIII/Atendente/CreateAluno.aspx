﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAluno.aspx.cs" Inherits="PIM_VIII.Atendente.CreateAluno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Cadastro de alunos</h1>

    <asp:Label ID="msgRetorno" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
    <hr />

    <table>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblNome" runat="server" Text="Nome" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtNome" runat="server" MaxLength="70" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMatricula" runat="server" Text="Matrícula" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtMatricula" runat="server" Width="120px" MaxLength="7" TextMode="Number"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblDataNascimento" runat="server" Text="Data de Nascimento" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtDataNascimento" runat="server" Width="130px" TextMode="Date" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCPF" runat="server" Text="CPF" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtCPF" runat="server" Width="120px" MaxLength="11" TextMode="Number"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblRG" runat="server" Text="RG" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtRG" runat="server" Width="120px" MaxLength="10" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCurso" runat="server" Text="Curso" ></asp:Label>
                <br/>
                <asp:DropDownList ID="dpCurso" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
        <td style="text-align:center" colspan="2">
            <asp:Button ID="btnEnviar" runat="server" Text="Atualizar" OnClick="btnEnviar_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lbtVoltar" runat="server" OnClick="lbtVoltar_Click" >Voltar</asp:LinkButton>
        </td>
        </tr>
    </table>
</asp:Content>
