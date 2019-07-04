using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using MimeKit;
using System.Text;

namespace Secure_Agencies
{
    public partial class Inscription : System.Web.UI.Page
    {
        static string activationcode;
        public static SqlConnection cx = new SqlConnection(@"server=ANDROID\SQLEXPRESS;database=secureagencies_DB;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            activationcode = random.Next(100001, 999999).ToString();
            SqlCommand cmd = new SqlCommand("insert into agence(nom_ag, mdp ,date_creation,tel_ag,email_age,adresse,ville_ag,code_activation) values(@nom,@mdp,@date_crea,@tel,@email,@adresse,@ville,"+activationcode+")", cx);
            cmd.Parameters.AddWithValue("@nom",TextBox1.Text);
            cmd.Parameters.AddWithValue("@mdp", TextBox3.Text);
            cmd.Parameters.AddWithValue("@date_crea", TextBox7.Text);
            cmd.Parameters.AddWithValue("@tel", TextBox4.Text);
            cmd.Parameters.AddWithValue("@email", TextBox2.Text);
            cmd.Parameters.AddWithValue("@adresse", TextBox5.Text);
            cmd.Parameters.AddWithValue("@ville", TextBox6.Text);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();
            sendcode();
            Response.Redirect("codesent_registration.aspx?email="+TextBox2.Text);
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
                    message.Subject = "Activez votre compte !";
                    message.IsBodyHtml = true;
                    message.Body = "Bonjour " + TextBox1.Text + ",Votre code d'activation : " + activationcode + ". \n<a href='http://localhost:52596/codesent_registration.aspx?email=" + TextBox2.Text + "'>Cliquez ici pour acitver votre compte.</a>\n\nMerci de nous joindre.\n\nIsmail Fedaoui";
                    message.To.Add(TextBox2.Text);


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


  
        protected void button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Authentification.aspx");
        }
    }
}