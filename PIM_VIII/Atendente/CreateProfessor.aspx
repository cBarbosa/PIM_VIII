<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateProfessor.aspx.cs" Inherits="PIM_VIII.Atendente.CreateProfessor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cadastro de professor</h1>
    <hr />

    <asp:Label ID="msgRetorno" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>

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
                <asp:TextBox ID="txtMatricula" runat="server" Width="120px" MaxLength="7" TextMode="Number" onkeypress="return this.value.length<=6"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblDataNascimento" runat="server" Text="Data de Nascimento" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtDataNascimento" runat="server" Width="130px" MaxLength="10" TextMode="Date" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCPF" runat="server" Text="CPF" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtCPF" runat="server" Width="120px" MaxLength="11" TextMode="Number" onkeypress="return this.value.length<=10"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblRG" runat="server" Text="RG" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtRG" runat="server" Width="120px" MaxLength="10" TextMode="Number" onkeypress="return this.value.length<=6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCurso" runat="server" Text="Disciplina" ></asp:Label>
                <br/>
                <asp:DropDownList ID="dpDisciplina" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
        <td style="text-align:center" colspan="2">
            <asp:Button ID="btnEnviar" runat="server" Text="Cadastrar" OnClick="btnEnviar_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lbtVoltar" runat="server" OnClick="lbtVoltar_Click" >Voltar</asp:LinkButton>
        </td>
        </tr>
    </table>
</asp:Content>
