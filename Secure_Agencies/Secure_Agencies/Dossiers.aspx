<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master"  AutoEventWireup="true" CodeBehind="Dossiers.aspx.cs" Inherits="Secure_Agencies.Dossiers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 20px;
            height: 20px;
        }
     
        button, input, optgroup, select, textarea {
            max-width: 260px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form runat="server">
        N° de dossier : <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;Date création : <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;Client : <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" CssClass="btn btn-info" runat="server" Text="Rechercher" OnClick="Button1_Click" /> 
          &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Exporter" OnClick="Button2_Click"  />
        <hr/>
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped custab" ShowFooter="True"  AutoGenerateColumns="false" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="aucune enregistrement.">
        <Columns>
            <asp:TemplateField HeaderText="Numéro de dossier">
                <EditItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("num_dossier") %>'></asp:Label>
                </EditItemTemplate>
                <FooterTemplate>
                    &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/assests/add.png" OnClick="ImageButton1_Click" />
                </FooterTemplate>

                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("num_dossier") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date de création">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("date_creation","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("date_creation","{0:yyyy-MM-dd}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("description_dossier") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("description_dossier") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id client">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" Text='<%# Bind("id_client") %>' DataSourceID="SqlDataSource1" DataTextField="full_name" DataValueField="id_cl"></asp:DropDownList>
  
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:secureagencies_DBConnectionString %>" SelectCommand="SELECT [id_cl], [full_name] FROM [client]"></asp:SqlDataSource>
  
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" Text='<%# Bind("id_client") %>' DataSourceID="SqlDataSource1" DataTextField="full_name" DataValueField="id_cl"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:secureagencies_DBConnectionString %>" SelectCommand="SELECT [id_cl], [full_name] FROM [client]"></asp:SqlDataSource>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("id_client") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Image" UpdateImageUrl="~/assests/valider.png" EditImageUrl="~/assests/edit.png" ShowEditButton="True" CancelImageUrl="~/assests/annuler.png" />
            <asp:CommandField ButtonType="Image" ShowDeleteButton="True" DeleteImageUrl="~/assests/delete.png" DeleteText="" EditText="" />
            <asp:ButtonField CommandName="ajouter" DataTextField="id_cl" Text="Bouton" Visible="False" />
        </Columns>
        <EmptyDataTemplate>
           aucune enregistrement.
        </EmptyDataTemplate>
        </asp:GridView>
</form>
    </asp:Content>