<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mot-de-passe-renitialise.aspx.cs" Inherits="Secure_Agencies.mot_de_passe_renitialise" %>


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
                  <p class="text-muted">Votre mot de passe à étè rénitialisé avec succés.</p>
                  <div class="input-group mb-3">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="icon-user"></i></span>
                    </div>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="identifiant/email" ></asp:TextBox>
                  </div>
                  <div class="input-group mb-4">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="icon-lock"></i></span>
                    </div>
                    <asp:TextBox ID="TextBox2" runat="server" type="password" class="form-control" placeholder="mot de passe"></asp:TextBox>
                  </div>
                  <div>
       <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                      </div>
                  <div class="row">
                      
                    <div class="btn1 col-6">
        <asp:Button ID="Button2" runat="server" type="button"  class="btn btn-primary px-4" Text="Connexion" OnClick="Button2_Click" />

                    </div>
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