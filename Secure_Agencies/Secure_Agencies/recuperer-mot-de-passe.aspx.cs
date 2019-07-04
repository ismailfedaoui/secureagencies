using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Secure_Agencies
{
    public partial class recuperer_mot_de_passe : System.Web.UI.Page
    {
        string activationcode;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DataTable dt = new DataTable();
        protected void Button2_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("select count(*) from agence where email_age like '" + TextBox1.Text + "'", Inscription.cx);
            Inscription.cx.Open();
            int k = (int)cmd.ExecuteScalar();
            Inscription.cx.Close();
            if (k == 0)
            {
                Label1.Text = "Ce compte n'existe pas";
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("select full_name from agence where email_age like '" + TextBox1.Text + "'", Inscription.cx);
                Random random = new Random();
                activationcode = random.Next(100001, 999999).ToString();
                SqlCommand cmd3 = new SqlCommand("update agence set activation_code = '" + activationcode + "'", Inscription.cx);
                Inscription.cx.Open();
                cmd3.ExecuteScalar();
                SqlDataReader dr = cmd2.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                Inscription.cx.Close();
                sendcode();
                Response.Redirect("recuperer-mot-de-passe-2.aspx?email=" + TextBox1.Text);
            }

        }
        private void sendcode()
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                var basicCredential = new NetworkCredential("youruser@gmail.com", "yourpassword");
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress("youruser@gmail.com");

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = "Récuperez votre mot de pasee !";
                    message.IsBodyHtml = true;
                    message.Body = "Bonjour " + dt.Rows[0][0].ToString() + ",Nous avons constaté que vous voulez récuperer votre mot de passe voila votre code de récupération : " + activationcode + ". \n<a href='http://localhost:52596/recuperer-mot-de-passe-2.aspx?email=" + TextBox1.Text + "'>Cliquez ici pour récuperer votre mot de passe.</a>\n\nMerci de nous joindre.\n\nIsmail Fedaoui";
                    message.To.Add(TextBox1.Text);


                    try
                    {
                        smtpClient.Send(message);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
    }
}