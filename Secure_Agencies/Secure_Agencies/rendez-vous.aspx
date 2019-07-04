<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="rendez-vous.aspx.cs" Inherits="Secure_Agencies.rendez_vous" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
             
        button, input, optgroup, select, textarea {
            max-width: 210px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
     &nbsp;&nbsp;   Date : <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
       &nbsp;&nbsp; Client : <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;&nbsp;<asp:Button ID="Button1" CssClass="btn btn-info" runat="server" Text="Rechercher" OnClick="Button1_Click1" /> 
       &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Exporter" OnClick="Button2_Click"  />
        &nbsp;&nbsp&nbsp;&nbsp   <asp:CheckBox ID="CheckBox1" runat="server" Text="Afficher les rendez-vous non faites" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
      
        <hr/>
         <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped custab"  ShowFooter="True" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowCustomPaging="True" AllowPaging="True" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating1" OnRowDeleting="GridView1_RowDeleting" ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="aucune enregistrement.">
        <Columns>
            <asp:TemplateField HeaderText="Id">
                <EditItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("id_rdv") %>'></asp:Label>
                </EditItemTemplate>
                <FooterTemplate>
                                        
                    &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/assests/add.png" OnClick="ImageButton1_Click" />
                </FooterTemplate>

                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("id_rdv") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Date de rendez-vous">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox41" runat="server" Text='<%# Bind("date_rdv","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox42" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label43" runat="server" Text='<%# Bind("date_rdv","{0:yyyy-MM-dd}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Heure de rendez-vous">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox31" runat="server" Text='<%# Bind("heure_rdv") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox32" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label33" runat="server" Text='<%# Bind("heure_rdv") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nom">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nom") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server"  Text='<%# Bind("nom") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="N° de téléphone">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("tel") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("tel") %>'></asp:Label>
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