<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAluno.aspx.cs" Inherits="PIM_VIII.Atendente.CreateAluno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblNome" runat="server" Text="Nome" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMatricula" runat="server" Text="Matrícula" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtMatricula" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblDataNascimento" runat="server" Text="Data de Nascimento" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtDataNascimento" runat="server" Width="100px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCPF" runat="server" Text="CPF" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtCPF" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblRG" runat="server" Text="RG" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtRG" runat="server" Width="100px"></asp:TextBox>
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
            <asp:Button ID="btnEnviar" runat="server" Text="Salvar" OnClick="btnEnviar_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lbtVoltar" runat="server" OnClick="lbtVoltar_Click" >Voltar</asp:LinkButton>
        </td>
        </tr>
    </table>
</asp:Content>
