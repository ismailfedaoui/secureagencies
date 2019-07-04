using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace Secure_Agencies
{
    public partial class informations : System.Web.UI.Page
    {
        public static SqlConnection cx = new SqlConnection(@"server=ANDROID\SQLEXPRESS;database=secureagencies_DB;integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select date_inscription,etat_paiement,mdp,adresse,ville_ag,tel_ag,photo_ag,nom_ag from agence where email_age='" + Authentification.email_agence + "'", cx);
            cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cx.Close();
            email.Text = Authentification.email_agence;
            date_insc.Text = dt.Rows[0][0].ToString();
            etat.Text = dt.Rows[0][1].ToString();
            mdp1.Text = dt.Rows[0][2].ToString();
            mdp2.Text = dt.Rows[0][2].ToString();
            adresse.Text = dt.Rows[0][3].ToString();
            ville.Text = dt.Rows[0][4].ToString();
            tel.Text = dt.Rows[0][5].ToString();
            if (dt.Rows[0][6].ToString() != "null")
            {
                Image1.ImageUrl = "photos/" + dt.Rows[0][6].ToString();
            }
            else {
                Image1.ImageUrl = "photos/user.jpg";
                    }
            Label1.Text = dt.Rows[0][7].ToString().ToUpper();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (mdp1.Text == mdp2.Text)
            {
                SqlCommand cmd = new SqlCommand("update agence set mdp=@mdp,adresse=@adr,ville_ag=@ville,tel_ag=@tel where email_age=@email", cx);
                cmd.Parameters.AddWithValue("@mdp", mdp1.Text);
                cmd.Parameters.AddWithValue("@adr", adresse.Text);
                cmd.Parameters.AddWithValue("@ville", ville.Text);
                cmd.Parameters.AddWithValue("@tel", tel.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cx.Open();
                cmd.ExecuteNonQuery();
                cx.Close();
            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {

                string imgfile = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(HttpContext.Current.Request.PhysicalApplicationPath + "photos/" + imgfile);
                SqlCommand cmd2 = new SqlCommand("update agence set photo_ag='" + imgfile + "' where email_age=@email", cx);
                cmd2.Parameters.AddWithValue("@email", Authentification.email_agence);
                cx.Open();
                cmd2.ExecuteNonQuery();
                cx.Close();
               
            }
        }
    }
}