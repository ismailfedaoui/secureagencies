using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Secure_Agencies
{
    public partial class dashboard : System.Web.UI.Page
    {
        SqlConnection cx = new SqlConnection(@"Server=ANDROID\SQLEXPRESS;Database=secureagencies_DB;Integrated Security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
           
            SqlCommand cmdhomme = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where sexe ='Homme' and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdfemme = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where sexe ='Femme' and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdjan = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 1 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdfeb = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 2 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdmar = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 3 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdabr = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 4 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdmai = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 5 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdjun = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 6 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdjul = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 7 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdaug = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 8 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdsep = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 9 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdoct = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 10 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdnov = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 11 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmddec = new SqlCommand("select count(*) from client join agence_client on agence_client.id_cl=client.id_cl where month(date_insc) = 12 and year(date_insc)=year(getdate()) and id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmddossier = new SqlCommand("select count(*) from dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdcontrat = new SqlCommand("select count(*) from contrat join dossier on dossier.num_dossier=contrat.num_dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmddocs = new SqlCommand("select count(*) from document join dossier on dossier.num_dossier=document.num_dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdrdvtotal = new SqlCommand("select count(*) from rendezvous where id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmdrdvdone = new SqlCommand("select count(*) from rendezvous where date_rdv < getdate() and id_ag=" + Authentification.id_agence, cx);
            cx.Open();
            int nb_homme = (int)cmdhomme.ExecuteScalar();
            int nb_femme = (int)cmdfemme.ExecuteScalar();
            int nb_jan = (int)cmdjan.ExecuteScalar();
            int nb_feb = (int)cmdfeb.ExecuteScalar();
            int nb_mars = (int)cmdmar.ExecuteScalar();
            int nb_abr = (int)cmdabr.ExecuteScalar();
            int nb_mai = (int)cmdmai.ExecuteScalar();
            int nb_jun = (int)cmdjun.ExecuteScalar();
            int nb_jul = (int)cmdjul.ExecuteScalar();
            int nb_aug = (int)cmdaug.ExecuteScalar();
            int nb_sep = (int)cmdsep.ExecuteScalar();
            int nb_oct = (int)cmdoct.ExecuteScalar();
            int nb_nov = (int)cmdnov.ExecuteScalar();
            int nb_dec = (int)cmddec.ExecuteScalar();
            int nb_dossiers = (int)cmddossier.ExecuteScalar();
            int nb_contrats = (int)cmdcontrat.ExecuteScalar();
            int nb_docs = (int)cmddocs.ExecuteScalar();
            int nb_rdvtotal = (int)cmdrdvtotal.ExecuteScalar();
            int nb_rdvdone = (int)cmdrdvdone.ExecuteScalar();
            cx.Close();
                TextBox1.Text = nb_homme.ToString();
                TextBox2.Text = nb_femme.ToString();
                
                jan.Text = nb_jan.ToString();
                feb.Text = nb_feb.ToString();
                mar.Text = nb_mars.ToString();
                abr.Text = nb_abr.ToString();
                mai.Text = nb_mai.ToString();
                jun.Text = nb_jun.ToString();
                jul.Text = nb_jul.ToString();
                aug.Text = nb_aug.ToString();
                septem.Text = nb_sep.ToString();
                oct.Text = nb_oct.ToString();
                nov.Text = nb_nov.ToString();
                decem.Text = nb_dec.ToString();
                L_dossiers.Text = nb_dossiers.ToString();
                Lab_contras.Text = nb_contrats.ToString();
                Label_docs.Text = nb_docs.ToString();
                int rdv = (int)(((double)nb_rdvdone / nb_rdvtotal) * 100);
            if(rdv>0)
                Lab_rdv.Text = rdv.ToString() + " %";
            else
            {
 Lab_rdv.Text = "0 %";
              rdv = 0;
            }
               
            Tb_rdv.Text = rdv.ToString();
            
        }
    }
}