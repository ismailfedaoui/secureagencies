<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="documents.aspx.cs" Inherits="Secure_Agencies.documents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 20px;
            height: 20px;
        }
     
        button, input, optgroup, select, textarea {
            max-width: 110px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        Identifiant : <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;Type : <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;Dossier : <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;Date d'expiration : <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" CssClass="btn btn-info" runat="server" Text="Rechercher" OnClick="Button1_Click1" /> 
          &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Exporter" OnClick="Button2_Click"  />
        <hr/>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:secureagencies_DBConnectionString %>" SelectCommand="SELECT [num_dossier] FROM [dossier]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:secureagencies_DBConnectionString %>" SelectCommand="SELECT [num_dossier] FROM [dossier]"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server"  CssClass="table table-striped custab"  ShowFooter="True" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowCustomPaging="True" AllowPaging="True" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating1" OnRowDeleting="GridView1_RowDeleting" ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="aucune enregistrement.">
        <Columns>
            <asp:TemplateField HeaderText="Identifiant">
                <EditItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("id_document") %>'></asp:Label>
                </EditItemTemplate>
                <FooterTemplate>
                                       
                   <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/assests/add.png" OnClick="ImageButton1_Click" />
             &nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </FooterTemplate>

                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("id_document") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("type_document") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("type_document") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date d'expiration">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox31" runat="server" Text='<%# Bind("date_exp","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox32" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label33" runat="server" Text='<%# Bind("date_exp","{0:yyyy-MM-dd}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("description_document") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("description_document") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dossier">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList2" runat="server" Text='<%# Bind("num_dossier") %>' DataSourceID="SqlDataSource1" DataTextField="num_dossier" DataValueField="num_dossier"></asp:DropDownList>
            
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" Text='<%# Bind("num_dossier") %>' DataSourceID="SqlDataSource2" DataTextField="num_dossier" DataValueField="num_dossier"></asp:DropDownList>
    
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("num_dossier") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            

            <asp:CommandField ButtonType="Image" UpdateImageUrl="~/assests/valider.png" EditImageUrl="~/assests/edit.png" ShowEditButton="True" CancelImageUrl="~/assests/annuler.png" />
            <asp:CommandField ButtonType="Image" ShowDeleteButton="True" DeleteImageUrl="~/assests/delete.png" DeleteText="" EditText="" />
        
        </Columns>
        <EmptyDataTemplate>
           aucune enregistrement.
        </EmptyDataTemplate>
        </asp:GridView>
</form>

</asp:Content>