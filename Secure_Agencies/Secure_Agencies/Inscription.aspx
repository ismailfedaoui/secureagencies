<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Inscription.aspx.cs" Inherits="Secure_Agencies.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="Content/simple-line-icons.css" rel="stylesheet" />
    <link href="Content/app.css" rel="stylesheet" />
<link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet"/> 
    
</head>
<body>
   
    <div class="app-body">
  <main class="main d-flex align-items-center">
    <div class="container">
      <div class="row">
        <div class="col-md-6 mx-auto">
          <div class="card mx-4">
           
              <form runat="server" autocomplete="off">
                   <div class="card-body p-3">
                <h1>S'inscrire</h1>
                <div class="input-group mb-3">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="icon-user"></i></span>
                  </div>
<asp:TextBox ID="TextBox1" name="nom_agence" class="form-control" placeholder="Nom d'agence"  runat="server"></asp:TextBox>
                  

                </div>
                <div class="input-group mb-3">
                  <div class="input-group-prepend">
                    <span class="input-group-text">@</span>
                  </div>
                  <asp:TextBox ID="TextBox2" runat="server" name="email_agence" class="form-control" placeholder="Email"  ></asp:TextBox>
                </div>
                <div class="input-group mb-3">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="icon-lock"></i></span>
                  </div>
                  <asp:TextBox ID="TextBox3" runat="server" type="password" name="mdp_agence" class="form-control" placeholder="Mot de passe"></asp:TextBox>
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="icon-phone"></i></span>
                    </div>
                    <asp:TextBox ID="TextBox4" runat="server" name="tel_agence" class="form-control" placeholder="Téléphone"  />
                  </div>
               <div class="input-group mb-3">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="icon-home"></i></span>
                  </div>
                  <asp:TextBox ID="TextBox5" runat="server" name="adresse_agence"  class="form-control" placeholder="Adresse" />
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="icon-map"></i></span>
                    </div>
                    <asp:TextBox ID="TextBox6" runat="server" name="ville_agence"  class="form-control" placeholder="Ville"  />
                  </div>
                  <div class="input-group mb-3">
                      <div class="input-group-prepend">
                        <span class="input-group-text"><i class="icon-calendar"></i></span>
                      </div>
                      <asp:TextBox ID="TextBox7" runat="server" class="form-control" name="date_creation_ag" placeholder="Date de création"/>
               
                 </div>
                  
                <asp:Button ID="button1" type="submit" runat="server" class="btn btn-block btn-success" Text="Créer" OnClick="button1_Click"/>

            </div>

            <div class="card-footer p-3">
            
                  <asp:Button ID="button2" type="button" runat="server" class="btn btn-block btn-info"  Text="Se connecter" OnClick="button2_Click"/>
             
            </div>
             </form>
          </div>
        </div>
      </div>
    </div>
  </main>
</div>


</body>
</html>
