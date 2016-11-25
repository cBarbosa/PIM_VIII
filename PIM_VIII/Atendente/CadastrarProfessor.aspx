<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarProfessor.aspx.cs" Inherits="PIM_VIII.Atendente.CadastrarProfessor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de professores</h1>
    <hr />

    [<a href="CreateProfessor.aspx">Novo</a>]
    <br/>

    <asp:GridView ID="GridView1" runat="server"
        OnRowCancelingEdit="GridView1_RowCancelingEdit"
        OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating"
        OnRowDataBound="GridView1_RowDataBound"
        OnRowDeleting="GridView1_RowDeleting"
        AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Nome">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Nome") %>' Width="180px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nome") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="120px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Matricula">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Matricula") %>' Width="80px" ReadOnly="true"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Matricula") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CPF">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CPF") %>' Width="80px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("CPF") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RG">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("RG") %>' Width="60px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("RG") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dt Nasc">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("DataNascimento", "{0:dd/MM/yyyy}") %>' Width="100px" ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("DataNascimento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="35px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Disciplina">
                <ItemTemplate>
                    <asp:Label ID="lblFrom" runat="server" ><%# Eval("disciplina.Nome")%></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="drpDisciplina" runat="server" DataSourceID="dsDisciplina" DataTextField="DISCIPLINA" DataValueField="ID_DISCIPLINA"></asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Alterar"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Voltar" Text="Cancelar"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="" ShowDeleteButton="True" ShowHeader="false" />
        </Columns>
        
    </asp:GridView>
    <asp:SqlDataSource ID="dsDisciplina" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringAccess %>" ProviderName="<%$ ConnectionStrings:ConnectionStringAccess.ProviderName %>" SelectCommand="SELECT [ID_DISCIPLINA], [DISCIPLINA] FROM [tbl_disciplinas]" ></asp:SqlDataSource>
</asp:Content>
