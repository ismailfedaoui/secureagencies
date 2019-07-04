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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public static SqlConnection cx = new SqlConnection(@"server=ANDROID\SQLEXPRESS;database=secureagencies_DB;integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("select count(*) from rendezvous where date_rdv >= getdate() and id_ag="+Authentification.id_agence, cx);

            SqlCommand cmd = new SqlCommand("select nom_ag,photo_ag from agence where email_age='"+Authentification.email_agence+"'", cx);
            cx.Open();
            int k = (int)cmd2.ExecuteScalar();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cx.Close();
            Label1.Text = k.ToString();

            Label2.Text = dt.Rows[0][0].ToString().ToUpper();
     
            if (dt.Rows[0][1].ToString() != "null")
            {
                image1.ImageUrl = "photos/" + dt.Rows[0][1].ToString();
            }
            else
            {
                image1.ImageUrl = "photos/user.jpg";

            }
        }
    }
}