<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authentification.aspx.cs" Inherits="Secure_Agencies.Authentification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Agency | Authentifiction</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="Content/app.css" rel="stylesheet" />
    <link href="Content/simple-line-icons.css" rel="stylesheet" />
</head>
<body>
   <div class="app-body">
  <main class="main d-flex align-items-center">
    <div class="container">
      <div class="row">
        <div class="col-md-8 mx-auto">
 
                <form runat="server">
                             <div class="card-group">
                                <div class="card p-4">
              <div class="card-body">
                  <h1>Authentification</h1>
                  <p class="text-muted">se connecter à votre compte :</p>
                  <div class="input-group mb-3">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="icon-user"></i></span>
                    </div>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="email" ></asp:TextBox>
                  </div>
                  <div class="input-group mb-4">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="icon-lock"></i></span>
                    </div>
                    <asp:TextBox ID="TextBox2" runat="server" type="password" class="form-control" placeholder="mot de passe"></asp:TextBox>
                  </div>
                  <div class="row">
<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <div class="col-6">
                      <asp:Button ID="button3" runat="server" typ="button" class="btn btn-primary px-4" Text= "connexion" OnClick="button3_Click"/>
                    </div>
                    <div>
                      <asp:Button  ID="button1"  runat="server" type="button" class="btn btn-link px-0" text="mot de passe oublié?" OnClick="button1_Click"/>
                    </div>
                  </div>
                                </div>
            </div>
             
            <div class="card text-white bg-primary py-5 d-md-down-none" style="width:44%">
              <div class="card-body text-center">
                <div>
                  <h2>S'inscrire</h2>
                  <p>Notre platforme vous permet de gérer vos clients, les documents, les contrats et ses types. Gérer votre agence d'assurance facilement !</p>
                  <asp:Button  ID="button2"  runat="server"  class="btn btn-primary active mt-3" Text="7 jours gratuit" OnClick="button2_Click" />
                </div> 
              </div>
            </div>
                                 </div>
                       </form>
          
        </div>
      </div>
    </div>
  </main>
</div>

</body>
</html>
