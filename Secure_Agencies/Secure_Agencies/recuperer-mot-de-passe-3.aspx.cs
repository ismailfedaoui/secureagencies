using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace Secure_Agencies
{
    public partial class recuperer_mot_de_passe_3 : System.Web.UI.Page
    {
        public static SqlConnection cx = new SqlConnection(@"server=ANDROID\SQLEXPRESS;database=secureagencies_DB;integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == TextBox3.Text)
            {
                SqlCommand cmd = new SqlCommand("update agence set mdp='" + TextBox2.Text + "' where email='"+recuperer_mot_de_passe_2.email+"'", cx);
                cx.Open();
                cmd.ExecuteNonQuery();
                cx.Close();
                Response.Redirect("mot-de-passe-renitialise.aspx");

            }
            else Label1.Text = "les mots de passes ne corresponds pas";

        }
    }
}