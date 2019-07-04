using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace Secure_Agencies
{
    public partial class Authentification : System.Web.UI.Page
    {
        SqlConnection cx = new SqlConnection(@"Server=ANDROID\SQLEXPRESS;Database=secureagencies_DB;Integrated Security=true");
        public static string email_agence;
        public static int id_agence;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inscription.aspx");
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from agence",cx);
            cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cx.Close();
            foreach(DataRow r in dt.Rows)
            {
                if (r[6].ToString() == TextBox1.Text && r[2].ToString() == TextBox2.Text)
                {
                    if (r[9].ToString() == "Verified")
                    {
                        id_agence = int.Parse(r[0].ToString());
                        email_agence = TextBox1.Text;
                        FormsAuthentication.RedirectFromLoginPage(TextBox1.Text,true);
                        break;
                    }
                    else
                    {
                        Label1.Text = "Vous douvrez activer votre compte, veuillez vérifier votre boite d'email !";
                        break;
                    }
                }
                else
                    Label1.Text = "Les informations sont inccorects.";
            }
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("recuperer-mot-de-passe.aspx");
        }
    }
}