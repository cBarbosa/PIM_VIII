<%@ Page Title="Cadastro de Atividades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormCadastraAtividade.aspx.cs" Inherits="PIM_VIII.Atendente.FormCadastraAtividade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Lista de tipo atividades</h1>
    <hr />
    
    [<a href="CreateFormCadastroAtividade.aspx">Novo</a>]
    <br/>

    <asp:GridView ID="GridView1" runat="server"
        OnRowCancelingEdit="GridView1_RowCancelingEdit"
        OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating"
        OnRowDeleting="GridView1_RowDeleting"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" ReadOnly="True" />
            <asp:TemplateField HeaderText="Atividade">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Nome") %>' Width="180px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nome") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Alterar"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Voltar"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="" ShowDeleteButton="True" ShowHeader="false" />
            
        </Columns>
        </asp:GridView>

</asp:Content>
