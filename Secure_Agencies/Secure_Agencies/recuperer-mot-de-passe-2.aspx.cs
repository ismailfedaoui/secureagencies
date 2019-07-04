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
    public partial class recuperer_mot_de_passe_2 : System.Web.UI.Page
    {
       public static string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            email = Request.QueryString["email"];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select activation_code from agence where email_age like '" + email + "'", Inscription.cx);
            Inscription.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            Inscription.cx.Close();
            if (dt.Rows.Count == 0)
            {
                Label1.Text = "Ce compte n'existe pas, DON'T PLAY WITH US";
            }
            else
            {
               
                    if (dt.Rows[0][0].ToString() != TextBox1.Text)
                    {
                        Label1.Text = "Ce code est incorrect, merci de vérifier votre boite email.";
                    }
                    else
                    {
                        Response.Redirect("recuperer-mot-de-passe-3.aspx");
                    }
                
            }
        }
    }
}