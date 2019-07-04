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
    public partial class rendez_vous : System.Web.UI.Page
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
        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (CheckBox1.Checked)
            {
                SqlCommand cmd = new SqlCommand("select * from rendezvous where date_rdv >= getdate() and id_ag="+Authentification.id_agence, cx);

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
                    r[2] = "08:30";
                    r[3] = "Ahmadi";
                    r[4] = "067773737";
                    r[5] = 1;
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
                string date, client;
                if (TextBox16.Text == "") date = "%";
                else date = TextBox16.Text;
                if (TextBox3.Text == "") client = "%";
                else client = TextBox3.Text;
                SqlCommand cmd = new SqlCommand("select * from rendezvous where nom like '" + client + "' and cast(date_rdv as varchar) like '" + date + "' and id_ag="+Authentification.id_agence, cx);
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
                    r[2] = "08:30";
                    r[3] = "Ahmadi";
                    r[4] = "067773737";
                    r[5] = 1;
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

            ExportDataTableToPdf(dt, @"C:\Users\FEDAOUI\Desktop\ExportToPdf\rendez-vous.pdf", "La liste des documents :");

            System.Diagnostics.Process.Start(@"C:\Users\FEDAOUI\Desktop\ExportToPdf\rendez-vous.pdf");


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
        protected void actualiser()
    {

        SqlCommand cmd = new SqlCommand("select * from rendezvous where id_ag="+Authentification.id_agence, cx);
            SqlCommand cmd2 = new SqlCommand("select count(*) from rendezvous where date_rdv >= getdate() and id_ag="+Authentification.id_agence, cx);

            cx.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);
          k=(int)  cmd2.ExecuteScalar();
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
                r[2] = "08:30";
                r[3] = "Ahmadi";
                r[4] = "067773737";
                r[5] = 1;
                dt.Rows.Add(r);
        GridView1.DataSource = dt;
        GridView1.DataBind();
                int indice=0;
                foreach(GridViewRow s in GridView1.Rows)
                {
                    if (s.Cells[0].ToString() == "-2") indice = s.RowIndex;
                }
                GridView1.Rows[indice].Visible = false;
            }
        
           ((Label)Master.FindControl("Label1")).Text=k.ToString();
    }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            actualiser();
        }

        protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update rendezvous set date_rdv=@date_rdv,heure_rdv=@heure_rdv,nom=@nom,tel=@tel where id_rdv=@id_rdv", cx);
            cmd.Parameters.AddWithValue("@date_rdv", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox41"))).Text);
            cmd.Parameters.AddWithValue("@heure_rdv", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox31"))).Text);
            cmd.Parameters.AddWithValue("@nom", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox1"))).Text);
            cmd.Parameters.AddWithValue("@tel", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox5"))).Text);
            cmd.Parameters.AddWithValue("@id_rdv", ((Label)(GridView1.Rows[e.RowIndex].FindControl("Label9"))).Text);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();
            GridView1.EditIndex = -1;
            actualiser();
            TextBox16.Text = "";
            TextBox3.Text = "";
        }
        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into rendezvous values(@date_rdv,@heure_rdv,@nom,@tel,@id_ag)", cx);
            cmd.Parameters.AddWithValue("@date_rdv", ((TextBox)(GridView1.FooterRow.FindControl("TextBox42"))).Text);
            cmd.Parameters.AddWithValue("@heure_rdv", ((TextBox)(GridView1.FooterRow.FindControl("TextBox32"))).Text);
            cmd.Parameters.AddWithValue("@nom", ((TextBox)(GridView1.FooterRow.FindControl("TextBox2"))).Text);
            cmd.Parameters.AddWithValue("@tel", ((TextBox)(GridView1.FooterRow.FindControl("TextBox4"))).Text);
            cmd.Parameters.AddWithValue("@id_ag", Authentification.id_agence);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();

            GridView1.EditIndex = -1;
            actualiser();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete rendezvous where id_rdv =" + ((Label)GridView1.Rows[e.RowIndex].FindControl("Label1")).Text, cx);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();
            actualiser();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string date,client;
            if (TextBox16.Text == "") date = "%";
            else date = TextBox16.Text;
            if (TextBox3.Text == "") client = "%";
            else client = TextBox3.Text;
            SqlCommand cmd = new SqlCommand("select * from rendezvous where nom like '" + client + "' and cast(date_rdv as varchar) like '" + date + "'", cx);
            cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cx.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
          
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            string date, client;
            if (TextBox16.Text == "") date = "%";
            else date = TextBox16.Text;
            if (TextBox3.Text == "") client = "%";
            else client = TextBox3.Text;
            SqlCommand cmd = new SqlCommand("select * from rendezvous where nom like '" + client + "' and cast(date_rdv as varchar) like '" + date + "'", cx);
            cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cx.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                SqlCommand cmd= new SqlCommand("select * from rendezvous where date_rdv >= getdate() and id_ag="+Authentification.id_agence, cx);

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
                    r[0] = -2;
                    r[1] = "2001-01-01";
                    r[2] = "08:30";
                    r[3] = "Ahmadi";
                    r[4] = "067773737";
                    r[5] = 1;
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
                actualiser();
            }
        }
    }

}