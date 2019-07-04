<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" EnableViewState="true" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="Secure_Agencies.Clients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
             
        button, input, optgroup, select, textarea {
            max-width: 110px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        Nom complet : <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;Sexe : <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        &nbsp;&nbsp;&nbsp;Ville : <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;Pays : <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" CssClass="btn btn-info" runat="server" Text="Rechercher" OnClick="Button1_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Exporter" OnClick="Button2_Click"  />
       
        <hr/>
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped custab"  OnRowDeleting="GridView1_RowDeleting" ShowFooter="True" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowCustomPaging="True" AllowPaging="True" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating1" ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="aucune enregistrement.">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <EditItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("id_cl") %>'></asp:Label>
                </EditItemTemplate>
                <FooterTemplate>
                    &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/assests/add.png" OnClick="ImageButton1_Click" />
                </FooterTemplate>

                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("id_cl") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nom Complet">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("full_name") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("full_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Téléphone">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("tel") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("tel") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sexe">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" Text='<%# Bind("sexe") %>'>
                        <asp:ListItem>Homme</asp:ListItem>
                        <asp:ListItem>Femme</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem>Homme</asp:ListItem>
                        <asp:ListItem>Femme</asp:ListItem>
                    </asp:DropDownList>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("sexe") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date de naissance">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("dns","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("dns","{0:yyyy-MM-dd}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Adresse">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("adresse") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("adresse") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ville">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("ville") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("ville") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pays">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("pays") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("pays") %>'></asp:Label>
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
