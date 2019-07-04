using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Secure_Agencies
{
    public partial class Abonnements : System.Web.UI.Page
    {
        public static SqlConnection cx = new SqlConnection(@"server=ANDROID\SQLEXPRESS;database=secureagencies_DB;integrated security=true");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select nom_ag,photo_ag from agence where email_age='" + Authentification.email_agence + "'", cx);
            cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cx.Close();
            Label2.Text = dt.Rows[0][0].ToString().ToUpper();
            if (dt.Rows[0][1].ToString() != "null")
            {
                Image1.ImageUrl = "photos/" + dt.Rows[0][1].ToString();
            }
            else
            {
                Image1.ImageUrl = "photos/user.jpg";
            }
       
                SqlCommand cmd2 = new SqlCommand("select id_paiement,date_paiement,montant from paiement where id_ag="+Authentification.id_agence, cx);
                cx.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                dr2.Close();
                cx.Close();
                GridView1.DataSource = dt2;
                GridView1.DataBind();
            
        }

        protected void mois_TextChanged(object sender, EventArgs e)
        {

           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {   SqlCommand cmd = new SqlCommand("insert into paiement values(@id_ag,@date,@montant)",cx);
            cmd.Parameters.AddWithValue("@id_ag",2);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("@montant", 20);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();
        }
    }
}