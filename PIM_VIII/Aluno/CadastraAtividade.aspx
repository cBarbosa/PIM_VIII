<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastraAtividade.aspx.cs" Inherits="PIM_VIII.Aluno.CadastraAtividade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField DataField="atividade.Nome" HeaderText="Atividade" />
            <asp:BoundField DataField="disciplina.Nome" HeaderText="Disciplina" />
            <asp:BoundField DataField="disciplina.curso.Nome" HeaderText="Curso" />
            <asp:BoundField DataField="DataInicio" HeaderText="Dt.Inicio" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="DataFim" HeaderText="Dt Fim" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Aluno/EnviarAtividade.aspx?Id={0}" Text="[Enviar]" />
        </Columns>
    </asp:GridView>
</asp:Content>