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
    public partial class mot_de_passe_renitialise : System.Web.UI.Page
    {
  
        SqlConnection cx = new SqlConnection(@"Server=ANDROID\SQLEXPRESS;Database=secureagencies_DB;Integrated Security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = recuperer_mot_de_passe_2.email;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from agence", cx);
            cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cx.Close();
            foreach (DataRow r in dt.Rows)
            {
                if (r[6].ToString() == TextBox1.Text && r[2].ToString() == TextBox2.Text)
                {
                    if (r[9].ToString() == "Verified")
                    {
                        Response.Redirect("Clients.aspx");
                        break;
                    }
                    else
                    {
                        Label1.Text = "Vous douvez activez votre compte? veuillez vérifier votre boite d'email !";
                        break;
                    }
                }
                else
                    Label1.Text = "ce compte n'existe pas";
            }
        }
    }
}