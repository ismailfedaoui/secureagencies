<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperer-mot-de-passe-3.aspx.cs" Inherits="Secure_Agencies.recuperer_mot_de_passe_3" %>

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
    <style type="text/css">
        .card {
            margin-top: 174px;
        }
    </style>
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
                <h1>Rénicialisez votre mot de passe :)</h1>
                
                <div class="input-group mb-3">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="icon-lock"></i></span>
                  </div>
                  <asp:TextBox ID="TextBox3" runat="server" type="password" name="mdp_agence" class="form-control" placeholder="nouveau mot de passe"></asp:TextBox>
                </div>
                
                              <div class="input-group mb-3">
                  <div class="input-group-prepend">
                    <span class="input-group-text"><i class="icon-lock"></i></span>
                  </div>
                  <asp:TextBox ID="TextBox2" runat="server" type="password" name="mdp_agence" class="form-control" placeholder="repeter votre nouveau mot de passe"></asp:TextBox>
                </div>  
                  <div>
<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                  </div>
                  
                <asp:Button ID="button1" type="submit" runat="server" class="btn btn-block btn-info" Text="rénitialiser" OnClick="button1_Click" />

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
