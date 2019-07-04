using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Secure_Agencies
{
    public partial class codesent_registration : System.Web.UI.Page
    {
      public  static string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            email = Request.QueryString["email"];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select etat_compte,code_activation from agence where email_age like '"+email+"'",Inscription.cx);
            Inscription.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            Inscription.cx.Close();
            if (dt.Rows.Count == 0) {
                Label1.Text ="Ce compte n'existe pas";
            }
            else
            {
                if (dt.Rows[0][0].ToString() == "Verified")
                {
                    Label1.Text = "Ce compte est déjà vérifié.";
                }
                else
                {
                    if(dt.Rows[0][1].ToString() != TextBox1.Text)
                    {
                        Label1.Text = "Ce code est incorrect, merci de vérifier votre boite email.";
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("update agence set etat_compte='Verified' where email_age='"+email+"'",Inscription.cx);
                        Inscription.cx.Open();
                        cmd2.ExecuteNonQuery();
                        Inscription.cx.Close();
                        Response.Redirect("authentification.aspx");
                    }
                }
            }

        }
    }
}