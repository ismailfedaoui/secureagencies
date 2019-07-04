using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Secure_Agencies
{
    public partial class Dossiers : System.Web.UI.Page
    {
        SqlConnection cx = new SqlConnection(@"Server=ANDROID\SQLEXPRESS;Database=secureagencies_DB;Integrated Security=true");
        int k;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                    actualiser();
            }
        }
        void ExportDataTableToPdf(DataTable dtblTable, String strPdfPath, string strHeader)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, Color.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 10, 1, Color.GRAY);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("SECURE AGENCY", fntAuthor));
            prgAuthor.Add(new Chunk("\nLe : " + DateTime.Now.ToShortDateString(), fntAuthor));
            document.Add(prgAuthor);

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, Color.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            table.WidthPercentage = 100;

            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 8, 1, Color.WHITE);

            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string num_d, client;
            if (TextBox16.Text == "") num_d = "%";
            else num_d = TextBox16.Text;
            if (TextBox18.Text == "") client = "%";
            else client = TextBox18.Text;
            DataTable dt = new DataTable();
            if (TextBox17.Text == "")
            {
                SqlCommand cmd = new SqlCommand("select * from dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where cast(num_dossier as varchar) like '" + num_d + "' and id_client in (select id_cl from client join dossier on dossier.id_client= id_cl where full_name like '"+client +"') and id_ag=" + Authentification.id_agence + client, cx);
                cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
               
                dt.Load(dr);
                cx.Close();
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
                else
                {
                    DataRow r = dt.NewRow();
                    r[0] = -2;
                    r[1] = "2001-01-01";
                    r[2] = "Dossier 1";
                    r[3] = 1;
                    r[4] = 1;
                    r[5] = "ismail fedaoui";
                    r[6] = "0636720520";
                    r[7] = "Homme";
                    r[8] = "1994-10-25";
                    r[9] = "lot argana";
                    r[10] = "ait melloul";
                    r[11] = "maroc";
                    r[12] = "2019-02-01";
                    r[13] = "1";
                    r[14] = "1";
                    dt.Rows.Add(r);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    int indice = 0;
                    foreach (GridViewRow s in GridView1.Rows)
                    {
                        if (s.Cells[0].ToString() == "-2") indice = s.RowIndex;
                    }
                    GridView1.Rows[indice].Visible = false;
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where cast(num_dossier as varchar) like '" + num_d + "' and id_client in (select id_cl from client join dossier on dossier.id_client= id_cl where full_name like '" + client + "') and date_creation='" + TextBox17.Text + "' and id_ag=" + Authentification.id_agence, cx);
                cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                cx.Close();
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
                else
                {
                    DataRow r = dt.NewRow();
                    r[0] = -2;
                    r[1] = "2001-01-01";
                    r[2] = "Dossier 1";
                    r[3] = 1;
                    r[4] = 1;
                    r[5] = "ismail fedaoui";
                    r[6] = "0636720520";
                    r[7] = "Homme";
                    r[8] = "1994-10-25";
                    r[9] = "lot argana";
                    r[10] = "ait melloul";
                    r[11] = "maroc";
                    r[12] = "2019-02-01";
                    r[13] = "1";
                    r[14] = "1";
                    dt.Rows.Add(r);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    int indice = 0;
                    foreach (GridViewRow s in GridView1.Rows)
                    {
                        if (s.Cells[0].ToString() == "-2") indice = s.RowIndex;
                    }
                    GridView1.Rows[indice].Visible = false;
                }
            }



            ExportDataTableToPdf(dt, @"C:\Users\FEDAOUI\Desktop\ExportToPdf\dossiers.pdf", "La liste des dossiers :");

            System.Diagnostics.Process.Start(@"C:\Users\FEDAOUI\Desktop\ExportToPdf\dossiers.pdf");


        }
        protected void actualiser()
        {
            SqlCommand cmd = new SqlCommand("select * from dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where id_ag=" + Authentification.id_agence, cx);
            SqlCommand cmd2 = new SqlCommand("select count(*) from rendezvous where date_rdv >= getdate() and id_ag="+Authentification.id_agence, cx);

            cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            k = (int)cmd2.ExecuteScalar();
            cx.Close();
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            else
            {
                DataRow r = dt.NewRow();
                r[0] = -2;
                r[1] = "2001-01-01";
                r[2] = "Dossier 1";
                r[3] = 1;
                r[4] = 1;
                r[5] = "ismail fedaoui";
                r[6] = "0636720520";
                r[7] = "Homme";
                r[8] = "1994-10-25";
                r[9] = "lot argana";
                r[10] = "ait melloul";
                r[11] = "maroc";
                r[12] = "2019-02-01";
                r[13] = "1";
                r[14] = "1";

                dt.Rows.Add(r);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int indice = 0;
                foreach (GridViewRow s in GridView1.Rows)
                {
                    if (s.Cells[0].ToString() == "-2") indice = s.RowIndex;
                }
                GridView1.Rows[indice].Visible = false;
            }
            ((Label)Master.FindControl("Label1")).Text = k.ToString();
        }
        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into dossier values(@datecreation,@description,@client)", cx);
            cmd.Parameters.AddWithValue("@datecreation", ((TextBox)(GridView1.FooterRow.FindControl("TextBox9"))).Text);
            cmd.Parameters.AddWithValue("@description", ((TextBox)(GridView1.FooterRow.FindControl("TextBox10"))).Text);
            cmd.Parameters.AddWithValue("@client", ((DropDownList)(GridView1.FooterRow.FindControl("DropDownList2"))).SelectedValue);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();
            cx.Close();
            GridView1.EditIndex = -1;
            actualiser();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string num_d,client;
            if (TextBox16.Text == "") num_d = "%";
            else num_d = TextBox16.Text;
            if (TextBox18.Text == "") client = "%";
            else client = TextBox18.Text;
            if (TextBox17.Text == "") {
            SqlCommand cmd = new SqlCommand("select * from dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where cast(num_dossier as varchar) like '" + num_d + "' and id_client in (select id_cl from client join dossier on dossier.id_client= id_cl where full_name like '"+client+ "')  and id_ag=" + Authentification.id_agence, cx);
            cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cx.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where cast(num_dossier as varchar) like '" + num_d + "' and id_client in (select id_cl from client join dossier on dossier.id_client= id_cl where full_name like '" + client + "') and date_creation='"+TextBox17.Text+ "' and id_ag=" + Authentification.id_agence, cx);
                cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                cx.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
          

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            string num_d, client;
            if (TextBox16.Text == "") num_d = "%";
            else num_d = TextBox16.Text;
            if (TextBox18.Text == "") client = "%";
            else client = TextBox18.Text;
            if (TextBox17.Text == "")
            {
                SqlCommand cmd = new SqlCommand("select * from dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where cast(num_dossier as varchar) like '" + num_d + "' and id_client in (select id_cl from client join dossier on dossier.id_client= id_cl where full_name like '" + client + "') and id_ag=" + Authentification.id_agence, cx);
                cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                cx.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where cast(num_dossier as varchar) like '" + num_d + "' and id_client in (select id_cl from client join dossier on dossier.id_client= id_cl where full_name like '" + client + "') and date_creation='" + TextBox17.Text + "' and id_ag=" + Authentification.id_agence, cx);
                cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                cx.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }


        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update dossier set date_creation=@datecreation,description_dossier=@description,id_client=@client where num_dossier = @numdossier", cx);
            cmd.Parameters.AddWithValue("@datecreation", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox2"))).Text);
            cmd.Parameters.AddWithValue("@description", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox3"))).Text);
            cmd.Parameters.AddWithValue("@client", ((DropDownList)(GridView1.Rows[e.RowIndex].FindControl("DropDownList1"))).SelectedValue);
            cmd.Parameters.AddWithValue("@numdossier", ((Label)(GridView1.Rows[e.RowIndex].FindControl("Label9"))).Text);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();
            GridView1.EditIndex = -1;
            actualiser();
            TextBox16.Text = "";
            TextBox17.Text = "";
            TextBox18.Text = "";
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            actualiser();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete dossier where num_dossier =" + ((Label)GridView1.Rows[e.RowIndex].FindControl("Label1")).Text, cx);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();
            actualiser();
        }
    }
}
