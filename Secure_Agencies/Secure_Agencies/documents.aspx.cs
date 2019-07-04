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

    public partial class documents : System.Web.UI.Page
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
            string id, type, date_exp, dossier;
            if (TextBox16.Text == "") id = "%";
            else id = TextBox16.Text;
            if (TextBox17.Text == "") dossier = "%";
            else dossier = TextBox17.Text;
            if (TextBox18.Text == "") date_exp = "%";
            else date_exp = TextBox18.Text;
            if (TextBox3.Text == "") type = "%";
            else type = TextBox3.Text;
            SqlCommand cmd = new SqlCommand("select * from document join dossier on dossier.num_dossier=document.num_dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where id_document like '" + id + "' and type_document like '" + type + "' and cast(num_dossier as varchar) like '" + dossier + "' and cast(date_exp as varchar) like '" + date_exp + "' and id_ag=" + Authentification.id_agence, cx);
            cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
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
                r[0] = "--2";
                r[1] = "cin";
                r[2] = "2001-01-01";
                r[3] = "Description";
                r[4] = 1;
                r[5] = -2;
                r[6] = "2001-01-01";
                r[7] = "Dossier 1";
                r[8] = 1;
                r[9] = 1;
                r[10] = "ismail fedaoui";
                r[11] = "0636720520";
                r[12] = "Homme";
                r[13] = "1994-10-25";
                r[14] = "lot argana";
                r[15] = "ait melloul";
                r[16] = "maroc";
                r[17] = "2019-02-01";
                r[18] = "1";
                r[19] = "1";
                dt.Rows.Add(r);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int indice = 0;
                foreach (GridViewRow s in GridView1.Rows)
                {
                    if (s.Cells[0].ToString() == "--2") indice = s.RowIndex;
                }
                GridView1.Rows[indice].Visible = false;
            }


            ExportDataTableToPdf(dt, @"C:\Users\FEDAOUI\Desktop\ExportToPdf\documents.pdf", "La liste des documents :");

            System.Diagnostics.Process.Start(@"C:\Users\FEDAOUI\Desktop\ExportToPdf\documents.pdf");


        }
        protected void actualiser()
        {

            SqlCommand cmd = new SqlCommand("select * from document join dossier on dossier.num_dossier=document.num_dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where id_ag=" + Authentification.id_agence, cx);
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
                r[0] = "--2";
                r[1] = "cin";
                r[2] = "2001-01-01";
                r[3] = "Description";
                r[4] = 1;
                r[5] = -2;
                r[6] = "2001-01-01";
                r[7] = "Dossier 1";
                r[8] = 1;
                r[9] = 1;
                r[10] = "ismail fedaoui";
                r[11] = "0636720520";
                r[12] = "Homme";
                r[13] = "1994-10-25";
                r[14] = "lot argana";
                r[15] = "ait melloul";
                r[16] = "maroc";
                r[17] = "2019-02-01";
                r[18] = "1";
                r[19] = "1";
                dt.Rows.Add(r);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int indice = 0;
                foreach (GridViewRow s in GridView1.Rows)
                {
                    if (s.Cells[0].ToString() == "--2") indice = s.RowIndex;
                }
                GridView1.Rows[indice].Visible = false;
            }
            ((Label)Master.FindControl("Label1")).Text = k.ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            actualiser();
        }

        protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update document set type_document=@type,date_exp=@date_exp,description_document=@desc,num_dossier=@n_dossier where id_document=@id_doc", cx);
            cmd.Parameters.AddWithValue("@type", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox2"))).Text);
            cmd.Parameters.AddWithValue("@date_exp", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox31"))).Text);
            cmd.Parameters.AddWithValue("@desc", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox5"))).Text);
            cmd.Parameters.AddWithValue("@n_dossier", ((DropDownList)(GridView1.Rows[e.RowIndex].FindControl("DropDownList2"))).Text);
            cmd.Parameters.AddWithValue("@id_doc", ((Label)(GridView1.Rows[e.RowIndex].FindControl("Label9"))).Text);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();
            GridView1.EditIndex = -1;
            actualiser();
            TextBox16.Text = "";
            TextBox17.Text = "";
            TextBox18.Text = "";
            TextBox3.Text = "";
        }
        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into document values(@id_doc,@type_doc,@date_exp,@desc,@num_dossier)", cx);
            cmd.Parameters.AddWithValue("@id_doc", ((TextBox)(GridView1.FooterRow.FindControl("TextBox1"))).Text);
            cmd.Parameters.AddWithValue("@type_doc", ((TextBox)(GridView1.FooterRow.FindControl("TextBox9"))).Text);
            cmd.Parameters.AddWithValue("@date_exp", ((TextBox)(GridView1.FooterRow.FindControl("TextBox32"))).Text);
            cmd.Parameters.AddWithValue("@desc", ((TextBox)(GridView1.FooterRow.FindControl("TextBox12"))).Text);
            cmd.Parameters.AddWithValue("@num_dossier", ((DropDownList)(GridView1.FooterRow.FindControl("DropDownList1"))).Text);

            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();

            GridView1.EditIndex = -1;
            actualiser();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete document where id_document =" + ((Label)GridView1.Rows[e.RowIndex].FindControl("Label1")).Text, cx);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();
            actualiser();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            string id, type, date_exp, dossier;
            if (TextBox16.Text == "") id = "%";
            else id = TextBox16.Text;
            if (TextBox17.Text == "") dossier = "%";
            else dossier = TextBox17.Text;
            if (TextBox18.Text == "") date_exp = "%";
            else date_exp = TextBox18.Text;
            if (TextBox3.Text == "") type = "%";
            else type = TextBox3.Text;
            SqlCommand cmd = new SqlCommand("select * from document join dossier on dossier.num_dossier=document.num_dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where id_document like '" + id + "' and type_document like '" + type + "' and cast(num_dossier as varchar) like '" + dossier + "' and cast(date_exp as varchar) like '" + date_exp + "' and id_ag=" + Authentification.id_agence, cx);
            cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
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
                r[0] = "--2";
                r[1] = "cin";
                r[2] = "2001-01-01";
                r[3] = "Description";
                r[4] = 1;
                r[5] = -2;
                r[6] = "2001-01-01";
                r[7] = "Dossier 1";
                r[8] = 1;
                r[9] = 1;
                r[10] = "ismail fedaoui";
                r[11] = "0636720520";
                r[12] = "Homme";
                r[13] = "1994-10-25";
                r[14] = "lot argana";
                r[15] = "ait melloul";
                r[16] = "maroc";
                r[17] = "2019-02-01";
                r[18] = "1";
                r[19] = "1";
                dt.Rows.Add(r);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int indice = 0;
                foreach (GridViewRow s in GridView1.Rows)
                {
                    if (s.Cells[0].ToString() == "--2") indice = s.RowIndex;
                }
                GridView1.Rows[indice].Visible = false;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string id, type, date_exp, dossier;
            if (TextBox16.Text == "") id = "%";
            else id = TextBox16.Text;
            if (TextBox17.Text == "") dossier = "%";
            else dossier = TextBox17.Text;
            if (TextBox18.Text == "") date_exp = "%";
            else date_exp = TextBox18.Text;
            if (TextBox3.Text == "") type = "%";
            else type = TextBox3.Text;
            SqlCommand cmd = new SqlCommand("select * from document join dossier on dossier.num_dossier=document.num_dossier join client on dossier.id_client=client.id_cl join agence_client on agence_client.id_cl=client.id_cl where id_document like '" + id + "' and type_document like '" + type + "' and cast(dossier.num_dossier as varchar) like '" + dossier + "' and cast(date_exp as varchar) like '" + date_exp + "' and id_ag=" + Authentification.id_agence, cx);
            cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
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
                r[0] = "--2";
                r[1] = "cin";
                r[2] = "2001-01-01";
                r[3] = "Description";
                r[4] = 1;
                r[5] = -2;
                r[6] = "2001-01-01";
                r[7] = "Dossier 1";
                r[8] = 1;
                r[9] = 1;
                r[10] = "ismail fedaoui";
                r[11] = "0636720520";
                r[12] = "Homme";
                r[13] = "1994-10-25";
                r[14] = "lot argana";
                r[15] = "ait melloul";
                r[16] = "maroc";
                r[17] = "2019-02-01";
                r[18] = "1";
                r[19] = "1";
                dt.Rows.Add(r);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int indice = 0;
                foreach (GridViewRow s in GridView1.Rows)
                {
                    if (s.Cells[0].ToString() == "--2") indice = s.RowIndex;
                }
                GridView1.Rows[indice].Visible = false;
            }
        }
    }
}