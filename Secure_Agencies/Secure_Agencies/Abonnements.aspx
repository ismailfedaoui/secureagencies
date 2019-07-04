<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Abonnements.aspx.cs" Inherits="Secure_Agencies.Abonnements" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet"/> 
      <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700,200" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/master3.css" rel="stylesheet" />
    <link href="Content/paperdashboard.css" rel="stylesheet" />
    <link href="Content/demo.css" rel="stylesheet" />
       
    <link href="https://use.fontawesome.com/releases/v5.0.6/css/all.css" rel="stylesheet">
    <style>
        
        .page-wrapper .page-content > div {
    padding: 20px 0px;
}
 .page-wrapper.toggled .page-content {
    padding-left: 0px;
}
 .page-wrapper .page-content {
    padding-top: 80px;
}
             .col-md-4 {
          -ms-flex: 0 0 33.333333%;
          flex: 0 0 23.333333%;
          max-width: 23.333333%;
          margin-left: 49px;
  
      }

 .main-panel>.content {
    padding: 0px 0px;
}
.col-md-8 {
    -ms-flex: 0 0 69.6%;
    flex: 0 0 69.6%;
    max-width: 69.6%;
}
.page-wrapper .page-content > div {
    padding: 00px 0px;
}
.card-user hr {
    margin: 0px 0px 0px;
}
hr{
        margin-block-start: 0px;
    margin-block-end: 0px;
    overflow:hidden;
}
navbar12.{    position: relative;
    display: flex;
    -ms-flex-wrap: wrap;
    flex-wrap: wrap;
    -webkit-box-align: center;
    align-items: center;
    -webkit-box-pack: justify;
    justify-content: space-between;
    padding: .5rem 1rem;}


.navbar-brand {
    display: inline-block;
    padding-top: .3125rem;
    padding-bottom: .3125rem;
    margin-right: 1rem;
    font-size: 1.25rem;
    line-height: inherit;
    white-space: nowrap;
}
.bg-light {
    background-color: #31353d !important;
    z-index: 0;
}
.fixed-top {
    position: fixed;
    top: 0;
    right: 0;
    left: 0;
    z-index: 1030;
}
.chiller-theme .sidebar-wrapper {
     background: transparent; 
}
.page-wrapper.toggled .sidebar-wrapper {
    left: 0px;
    width: 100%;
}
        .navbar {
            padding-top: 0px;
            padding-bottom: 0px;
        }
        .navbar .navbar-brand {
            text-transform: capitalize;
            font-size: 20px;
            padding-top: 0px;
            padding-bottom: 0px;
        }
        .sidebar .nav li > a, .off-canvas-sidebar .nav li > a {
            padding:0px;
        }
        p {
    margin-top: 0;
    margin-bottom: 0px;
}
        .sidebar[data-active-color="danger"] .nav li.active>a, .sidebar[data-active-color="danger"] .nav li.active>a i{
            color:#3395FF;
        }
        .btn{
            background-color:#3395FF;
               margin-left: 750px;
    margin-top: -70px;
        }
        #Label1{       margin-left:38px;
                       margin-top:33px;
        }
        a{color:#3395FF;}
        .card-user .author {
            margin-top: 0px;
        }
        .fa-home  {
            color:#DEDEDF;
        }
        .fa-1x {
    font-size: x-large;}
    </style>

</head>
<body>
    <form runat="server" action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post" target="_blank">
        <nav  class="navbar navbar-light bg-light fixed-top">
  <a class="navbar-brand" style="text-transform: uppercase;
    font-weight: bold;
    flex-grow: 1; color: #56a7ff;"> &nbsp; &nbsp; <img height="35px" src="assests/images.png" /> </a>
             <a href="./dashboard">
              <div  class="fa fa-home fa-1x"></div>
                </a> &nbsp; &nbsp;&nbsp;
<a href="./authentification">
                    <img src="assests/exit_delete_close_remove_door-512.png"/>
                </a>&nbsp;&nbsp;
       
      </nav>
<div class="page-wrapper chiller-theme toggled">
 

 
  <!-- sidebar-wrapper  -->
  <main class="page-content">
    <div class="container-fluid">
        
  <div class="wrapper ">
    
    <div class="main-panel">
      <!-- Navbar -->
     
      <!-- <div class="panel-header panel-header-sm">
  
  
</div> -->
      <div  class="content">
        <div class="row" style="margin-top:30px">
          <div  class="col-md-4">
            <div style="min-height:444px;" class="card card-user">
              <div class="image">
                <img src="assests/homepage-product-office-space.jpg" alt="...">
              </div>
              <div  class="card-body">
                <div class="author">
                  <a href="#">
                      <asp:Image ID="Image1" class="avatar border-gray" runat="server" />
                    <h5 class="title">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h5>
                  </a>
                </div>
              </div>
                
                      
                      
              <div  class="card-footer">
                <hr>
                <div class="button-container">
                  <div class="row">
<div class="sidebar" data-color="white" data-active-color="danger">
      <div class="sidebar-wrapper">
        <ul class="nav">
          <li >
            <a href="./informations">
              <i class="fa fa-address-card"></i>
              <p>Informations</p>
            </a>
          </li>
          <li  class="active">
            <a href="./abonnements">
              <i class="fa fa-credit-card"></i>
              <p>Abonnement</p>
            </a>
          </li>
        </ul>
      </div>
    </div>





                  </div>
                </div>
              </div>
            </div>
            
          </div>
          <div class="col-md-8">
            <div style="min-height:444px;" class="card card-user">
              <div class="card-header">
                <h3 class="card-title">Vos Abonnements :</h3>
              </div>
              <div  class="card-body">
                
                  <div class="row">
                    <div class="col-md-5 pr-1">
                      <div class="form-group">
              <label> <h5 class="card-title">NB : 20€/mois :</h5></label>
                                             <div class="update ml-auto mr-auto">
                      
<input type="hidden" name="cmd" value="_s-xclick">
<input type="hidden" name="hosted_button_id" value="AUWNVS4DWU24S">
<asp:Button ID="Button1"  class="btn btn-primary btn-round" runat="server" Text="Payer" OnClick="Button1_Click" src="https://www.sandbox.paypal.com/en_US/i/btn/btn_subscribeCC_LG.gif" border="0" name="submit" target="_blank" alt="PayPal - The safer, easier way to pay online!"/>
<img alt="" border="0" src="https://www.sandbox.paypal.com/fr_XC/i/scr/pixel.gif" width="1" height="1">


                        </div>
                      </div>                      
                    
                    </div>  
                   
                    </div>
                    <hr />
                    <label> <h5 class="card-title ">Historique :</h5></label><br />
                          <asp:GridView ID="GridView1" style="top:0px; margin-left:10px;width:900px" CssClass="table table-striped custab" runat="server" ShowHeader="true" ShowHeaderWhenEmpty="true" EmptyDataText="aucune enregistrement."></asp:GridView>

                  </div>
          </div>
        </div>
      </div>
    </div>
  </div>
        
    </div>

  </main>
  <!-- page-content" -->
</div>
    </form>
      
<!-- page-wrapper -->
      <!--   Core JS Files   -->
        <script src="Scripts/jquery-3.3.1.min.js"></script>
        <script src="Scripts/popper.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
        <script src="Scripts/perfect-scrollbar.jquery.min.js"></script>
  <!--  Google Maps Plugin    -->
  <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE"></script>
  <!--  Notifications Plugin    -->
        <script src="Scripts/bootstrap-notify.js"></script>
  <!-- Control Center for Now Ui Dashboard: parallax effects, scripts for the example pages etc -->
        <script src="Scripts/paper-dashboard.min.js?v=2.0.0"></script>
  <!-- Paper Dashboard DEMO methods, don't include it in your project! -->

        <script src="Scripts/demo.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"
        crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"
        crossorigin="anonymous"></script>
    <script type="text/javascript">
      jQuery(function ($) {

    $(".sidebar-dropdown > a").click(function() {
  $(".sidebar-submenu").slideUp(200);
  if (
    $(this)
      .parent()
      .hasClass("active")
  ) {
    $(".sidebar-dropdown").removeClass("active");
    $(this)
      .parent()
      .removeClass("active");
  } else {
    $(".sidebar-dropdown").removeClass("active");
    $(this)
      .next(".sidebar-submenu")
      .slideDown(200);
    $(this)
      .parent()
      .addClass("active");
  }
});

$("#close-sidebar").click(function() {
  $(".page-wrapper").removeClass("toggled");
});
$("#show-sidebar").click(function() {
  $(".page-wrapper").addClass("toggled");
});


   
   
});
    </script>
</body>
</html>

