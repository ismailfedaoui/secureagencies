<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Secure_Agencies.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/all.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

   
    <style type="text/css">
        .t1 {
            max-width: 2px;
        }
        .border-left-warning{border-left:.25rem solid #f6c23e!important}
        .border-left-primary{border-left:.25rem solid #4e73df!important}
        .border-left-success{border-left:.25rem solid #1cc88a!important}
        .border-left-info{border-left:.25rem solid #36b9cc!important}
        .card{position:relative;display:-webkit-box;display:-ms-flexbox;display:flex;-webkit-box-orient:vertical;-webkit-box-direction:normal;-ms-flex-direction:column;flex-direction:column;min-width:0;word-wrap:break-word;background-color:#fff;background-clip:border-box;border:1px solid #e3e6f0;border-radius:.35rem}
       .shadow{-webkit-box-shadow:0 .4rem 0.4rem 0 rgba(58,59,69,.15)!important;box-shadow:0 .4rem 0.4rem 0 rgba(58,59,69,.15)!important}
        .h-100{height:100%!important}

        .femme {
    color: #FF1493;
}
 .page-wrapper .page-content > div {
    padding: 15px 10px;

}
 .rdv{
     color:#17A2B8;
 }
 #wrapper{
     overflow:hidden;
 }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
                          

          <div id="wrapper">

             
                       <!-- Content Row -->
          <div class="row" style="margin-left: 0px;  margin-right: 0px;">

            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-3 col-md-6 mb-4">
              <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Dossiers</div>
                      <div class="h5 mb-0 font-weight-bold text-gray-800">
                          <asp:Label ID="L_dossiers" runat="server" Text="1994"></asp:Label></div>
                    </div>
                    <div class="col-auto">
                      <i class="fa fa-folder rdv fa-3x"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-3 col-md-6 mb-4">
              <div class="card border-left-success shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Documents</div>
                      <div class="h5 mb-0 font-weight-bold text-gray-800">
                          <asp:Label ID="Label_docs" runat="server" Text="1994"></asp:Label></div>
                    </div>
                    <div class="col-auto">
                      <i class="fas  fa-book rdv fa-3x"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Earnings (Monthly) Card Example -->
            <div class="col-xl-3 col-md-6 mb-4">
              <div class="card border-left-info shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="text-xs font-weight-bold text-info text-uppercase mb-1">Rendez-vous</div>
                      <div class="row no-gutters align-items-center">
                        <div class="col-auto">
                          <div class="h5 mb-0 mr-3 font-weight-bold text-gray-800">
                              <asp:Label ID="Lab_rdv" runat="server" Text="1994"></asp:Label></div>
                        </div>
                        <div class="col">
                          <div class="progress progress-sm mr-2">
                            <div id="progressbar1" class="progress-bar bg-info" role="progressbar" style="width: 70%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                          </div>
                        </div>
                      </div>
                    </div>
                    <div class="col-auto">
                      <i class="far fa-calendar-alt rdv fa-3x"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Pending Requests Card Example -->
            <div class="col-xl-3 col-md-6 mb-4">
              <div class="card border-left-warning shadow h-100 py-2">
                <div class="card-body">
                  <div class="row no-gutters align-items-center">
                    <div class="col mr-2">
                      <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">Contrats</div>
                      <div class="h5 mb-0 font-weight-bold text-gray-800">
                          <asp:Label ID="Lab_contras" runat="server" Text="1994"></asp:Label></div>
                    </div>
                    <div class="col-auto">
                      <i class="fas  fa-file-alt rdv fa-3x"></i>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
    <!-- Content Wrapper -->
    <div id="content-wrapper" class="d-flex flex-column">

      <!-- Main Content -->
      <div id="content">



        <!-- Begin Page Content -->
        <div class="container-fluid">

        

       
          <div class="row">

            <!-- Area Chart -->
            <div class="col-xl-8 col-lg-7">
              <div  class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                  <h6 class="m-0 font-weight-bold text-primary">CLIENTS</h6>

                </div>
                <!-- Card Body -->
                <div class="card-body">
                  <div class="chart-area">
                    <canvas style="min-height:242px" id="myAreaChart"></canvas>
                  </div>
                </div>
              </div>
            </div>

            <!-- Pie Chart -->
            <div class="col-xl-4 col-lg-5">
              <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                  <h6 class="m-0 font-weight-bold text-primary">SEXE</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                  <div class="chart-pie pt-4 pb-2" style="min-height:200px">
                    <canvas id="myPieChart"></canvas>
                  </div>
                  <div class="mt-4 text-center small">
                    <span class="mr-2">
                      <i class="fas fa-circle femme"></i> Femme
                    </span>
                    <span class="mr-2">
                      <i class="fas fa-circle text-primary"></i> Homme
                    </span>
                   
                  </div>
                </div>
              </div>
            </div>
          </div>



        </div>
        <!-- /.container-fluid -->

      </div>
      <!-- End of Main Content -->



    </div>
    <!-- End of Content Wrapper -->

  </div>
  <!-- End of Page Wrapper -->

   <asp:TextBox ID="TextBox1" runat="server"  CssClass="t1" style="visibility:hidden" Text="1994" ></asp:TextBox>
              <asp:TextBox ID="TextBox2" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="jan" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="feb" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="mar" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="abr" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="mai" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="jun" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="jul" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="aug" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="septem" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="oct" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="nov" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
                            <asp:TextBox ID="decem" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>
         <asp:TextBox ID="Tb_rdv" runat="server" CssClass="t1" style="visibility:hidden" Text="1994"></asp:TextBox>


  <!-- Bootstrap core JavaScript-->
        <script src="Scripts/jquery-3.3.1.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>

  <!-- Core plugin JavaScript-->
        <script src="Scripts/jquery.easing.min.js"></script>

  <!-- Custom scripts for all pages-->

        <script src="Scripts/sb-admin-2.min.js"></script>
  <!-- Page level plugins -->
        <script src="Scripts/Chart.min.js"></script>

        <script type="text/javascript">
            var rdv_width = document.getElementById('<%=Tb_rdv.ClientID%>').value;
            var progressbar = document.getElementById("progressbar1");
            progressbar.style.width =rdv_width+"%";

        </script>
  <!-- Page level custom scripts -->
        <script type="text/javascript">
            // Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';

function number_format(number, decimals, dec_point, thousands_sep) {
  // *     example: number_format(1234.56, 2, ',', ' ');
  // *     return: '1 234,56'
  number = (number + '').replace(',', '').replace(' ', '');
  var n = !isFinite(+number) ? 0 : +number,
    prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
    sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
    dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
    s = '',
    toFixedFix = function(n, prec) {
      var k = Math.pow(10, prec);
      return '' + Math.round(n * k) / k;
    };
  // Fix for IE parseFloat(0.55).toFixed(0) = 0;
  s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
  if (s[0].length > 3) {
    s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
  }
  if ((s[1] || '').length < prec) {
    s[1] = s[1] || '';
    s[1] += new Array(prec - s[1].length + 1).join('0');
  }
  return s.join(dec);
}
var jan = document.getElementById('<%=jan.ClientID%>');
var feb = document.getElementById('<%=feb.ClientID%>');
var mar = document.getElementById('<%=mar.ClientID%>');
var abr = document.getElementById('<%=abr.ClientID%>');
var mai = document.getElementById('<%=mai.ClientID%>');
var jun = document.getElementById('<%=jun.ClientID%>');
var jul = document.getElementById('<%=jul.ClientID%>');
var aug = document.getElementById('<%=aug.ClientID%>');
var septem = document.getElementById('<%=septem.ClientID%>');
var oct = document.getElementById('<%=oct.ClientID%>');
var nov = document.getElementById('<%=nov.ClientID%>');
var decem = document.getElementById('<%=decem.ClientID%>');
// Area Chart Example
var ctx = document.getElementById("myAreaChart");
var myLineChart = new Chart(ctx, {
  type: 'line',
  data: {
    labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
    datasets: [{
      label: "clients",
      lineTension: 0.3,
      backgroundColor: "rgba(78, 115, 223, 0.05)",
      borderColor: "rgba(78, 115, 223, 1)",
      pointRadius: 3,
      pointBackgroundColor: "rgba(78, 115, 223, 1)",
      pointBorderColor: "rgba(78, 115, 223, 1)",
      pointHoverRadius: 3,
      pointHoverBackgroundColor: "rgba(78, 115, 223, 1)",
      pointHoverBorderColor: "rgba(78, 115, 223, 1)",
      pointHitRadius: 10,
      pointBorderWidth: 2,
      data: [jan.value, feb.value, mar.value, abr.value, mai.value, jun.value, jul.value, aug.value, septem.value, oct.value,nov.value, decem.value],
    }],
  },
  options: {
    maintainAspectRatio: false,
    layout: {
      padding: {
        left: 10,
        right: 25,
        top: 25,
        bottom: 0
      }
    },
    scales: {
      xAxes: [{
        time: {
          unit: 'date'
        },
        gridLines: {
          display: false,
          drawBorder: false
        },
        ticks: {
          maxTicksLimit: 12
        }
      }],
      yAxes: [{
        ticks: {
          maxTicksLimit: 5,
          padding: 10,
          // Include a dollar sign in the ticks
          callback: function(value, index, values) {
            return + number_format(value);
          }
        },
        gridLines: {
          color: "rgb(234, 236, 244)",
          zeroLineColor: "rgb(234, 236, 244)",
          drawBorder: false,
          borderDash: [2],
          zeroLineBorderDash: [2]
        }
      }],
    },
    legend: {
      display: false
    },
    tooltips: {
      backgroundColor: "rgb(255,255,255)",
      bodyFontColor: "#858796",
      titleMarginBottom: 10,
      titleFontColor: '#6e707e',
      titleFontSize: 14,
      borderColor: '#dddfeb',
      borderWidth: 1,
      xPadding: 15,
      yPadding: 15,
      displayColors: false,
      intersect: false,
      mode: 'index',
      caretPadding: 10,
      callbacks: {
        label: function(tooltipItem, chart) {
          var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
          return  number_format(tooltipItem.yLabel) +' '+ datasetLabel;
        }
      }
    }
  }
});

        </script>
        <script type="text/javascript">
        
            // Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';

            var homme = document.getElementById('<%=TextBox1.ClientID%>').value;
            var femme = document.getElementById('<%=TextBox2.ClientID%>').value;
            var ctx = document.getElementById("myPieChart");
var myPieChart = new Chart(ctx, {
  type: 'doughnut',
  data: {
    labels: ["Hommes", "Femmes"],
    datasets: [{
      data: [homme, femme],
      backgroundColor: ['#4e73df', '#FF1493'],
      hoverBackgroundColor: ['#2e59d9', '#FF1499'],
      hoverBorderColor: "rgba(234, 236, 244, 1)",
    }],
  },
  options: {
    maintainAspectRatio: false,
    tooltips: {
      backgroundColor: "rgb(255,255,255)",
      bodyFontColor: "#858796",
      borderColor: '#dddfeb',
      borderWidth: 1,
      xPadding: 15,
      yPadding: 15,
      displayColors: false,
      caretPadding: 10,
    },
    legend: {
      display: false
    },
    cutoutPercentage: 80,
  },
});

        
        
    </script>
</form>

</asp:Content>
