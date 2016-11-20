<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarAluno.aspx.cs" Inherits="PIM_VIII.Atendente.CadastrarAluno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    [<a href="CreateAluno.aspx">Novo</a>]
    <br/>

    <asp:GridView ID="GridView1" runat="server"
        OnRowCancelingEdit="GridView1_RowCancelingEdit"
        OnRowEditing="GridView1_RowEditing"
        OnRowUpdating="GridView1_RowUpdating"
        OnRowDataBound="GridView1_RowDataBound"
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

            <asp:TemplateField HeaderText="Curso">
                <ItemTemplate>
                    <asp:Label ID="lblFrom" runat="server" ><%# Eval("CursoMatriculado.Nome")%></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="drpCurso" runat="server" DataSourceID="dsCurso" DataTextField="CURSO" DataValueField="ID_CURSO"></asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Atualizar"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        
    </asp:GridView>
    <asp:SqlDataSource ID="dsCurso" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringAccess %>" ProviderName="<%$ ConnectionStrings:ConnectionStringAccess.ProviderName %>" SelectCommand="SELECT [ID_CURSO], [CURSO] FROM [tbl_curso]" ></asp:SqlDataSource>
</asp:Content>