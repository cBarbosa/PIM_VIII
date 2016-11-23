<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCronograma.aspx.cs" Inherits="PIM_VIII.Atendente.EditarCronograma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="msgRetorno" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>

    <table>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" Text="Curso" ></asp:Label>
                <br/>
                <asp:DropDownList ID="dpCurso" runat="server" AutoPostBack="True" OnTextChanged="dpCurso_TextChanged" Enabled="false"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label5" runat="server" Text="Disciplina" ></asp:Label>
                <br/>
                <asp:DropDownList ID="dpDisciplina" runat="server" Enabled="false"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" Text="Atividade" ></asp:Label>
                <br/>
                <asp:DropDownList ID="dpAtividade" runat="server" AutoPostBack="True"></asp:DropDownList>
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
            <td style="text-align:center" colspan="2">
                <asp:Button ID="btnEnviar" runat="server" Text="Salvar" OnClick="btnEnviar_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtVoltar" runat="server" OnClick="lbtVoltar_Click" >Voltar</asp:LinkButton>
            </td>
        </tr>
        
    </table>

</asp:Content>
