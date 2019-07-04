using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Secure_Agencies
{
    public partial class Clients : System.Web.UI.Page
    {

        SqlConnection cx = new SqlConnection(@"Server=ANDROID\SQLEXPRESS;Database=secureagencies_DB;Integrated Security=true");
        int k;
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.Items.Add("Homme");
                DropDownList1.Items.Add("Femme");
                DropDownList1.Items.Add("Tous");
                DropDownList1.Text = "Tous";
                actualiser();
            }
        }
        protected void actualiser()
        {

        SqlCommand cmd = new SqlCommand("select * from client join agence_client on client.id_cl=agence_client.id_cl where id_ag=" + Authentification.id_agence, cx);
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
                r[1] = "ismail fedaoui";
                r[2] = "0636720520";
                r[3] = "Homme";
                r[4] = "1994-10-25";
                r[5] = "lot argana";
                r[6] = "ait melloul";
                r[7] = "maroc";
                r[8] = "2019-02-01";
                r[9] = "1";
                r[10] = "1";
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
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete client where id_cl ="+ ((Label)GridView1.Rows[e.RowIndex].FindControl("Label1")).Text, cx);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();
            actualiser();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nom,sexe,ville,pays;
            if (TextBox16.Text == "") nom = "%";
            else nom = TextBox16.Text;
            if (TextBox17.Text == "") ville = "%";
            else ville = TextBox17.Text;
            if (TextBox18.Text == "") pays = "%";
            else pays = TextBox18.Text;
            if (DropDownList1.Text == "Tous") sexe = "%";
            else sexe = DropDownList1.Text;
                SqlCommand cmd = new SqlCommand("select * from client join agence_client on client.id_cl=agence_client.id_cl where full_name like '" + nom + "' and sexe like '"+sexe+"' and ville like '"+ville+"' and pays like '"+pays+ "' and id_ag=" + Authentification.id_agence, cx);
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
                r[1] = "ismail fedaoui";
                r[2] = "0636720520";
                r[3] = "Homme";
                r[4] = "1994-10-25";
                r[5] = "lot argana";
                r[6] = "ait melloul";
                r[7] = "maroc";
                r[8] = "2019-02-01";
                r[9] = "1";
                r[10] = "1";
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

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
          
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            string nom, sexe, ville, pays;
            if (TextBox16.Text == "") nom = "%";
            else nom = TextBox16.Text;
            if (TextBox17.Text == "") ville = "%";
            else ville = TextBox17.Text;
            if (TextBox18.Text == "") pays = "%";
            else pays = TextBox18.Text;
            if (DropDownList1.Text == "Tous") sexe = "%";
            else sexe = DropDownList1.Text;
            SqlCommand cmd = new SqlCommand("select * from client join agence_client on client.id_cl=agence_client.id_cl where full_name like '" + nom + "' and sexe like '" + sexe + "' and ville like '" + ville + "' and pays like '" + pays + "' and id_ag=" + Authentification.id_agence, cx);
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
                r[1] = "ismail fedaoui";
                r[2] = "0636720520";
                r[3] = "Homme";
                r[4] = "1994-10-25";
                r[5] = "lot argana";
                r[6] = "ait melloul";
                r[7] = "maroc";
                r[8] = "2019-02-01";
                r[9] = "1";
                r[10] = "1";
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
        
            protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update client set full_name=@nom,tel=@tel,sexe=@sexe,dns=@dns,adresse=@adresse,ville=@ville,pays=@pays where id_cl=@id_cl",cx);
            cmd.Parameters.AddWithValue("@nom",((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox2"))).Text);
            cmd.Parameters.AddWithValue("@tel", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox3"))).Text);
            cmd.Parameters.AddWithValue("@sexe", ((DropDownList)(GridView1.Rows[e.RowIndex].FindControl("DropDownList2"))).Text);
            cmd.Parameters.AddWithValue("@dns", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox5"))).Text);
            cmd.Parameters.AddWithValue("@adresse", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox6"))).Text);
            cmd.Parameters.AddWithValue("@ville", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox7"))).Text);
            cmd.Parameters.AddWithValue("@pays", ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("TextBox8"))).Text);
            cmd.Parameters.AddWithValue("@id_cl", ((Label)(GridView1.Rows[e.RowIndex].FindControl("Label9"))).Text);
            cx.Open();
            cmd.ExecuteNonQuery();
            cx.Close();
            GridView1.EditIndex =- 1;
            actualiser();
            TextBox16.Text = "";
            TextBox17.Text = "";
            TextBox18.Text = "";
            DropDownList1.Text = "Tous";
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex =- 1;
            actualiser();

        }

    

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
                SqlCommand cmd = new SqlCommand("insert into client values(@nom,@tel,@sexe,@dns,@adresse,@ville,@pays,@date_insc)", cx);
                cmd.Parameters.AddWithValue("@nom", ((TextBox)(GridView1.FooterRow.FindControl("TextBox9"))).Text);
                cmd.Parameters.AddWithValue("@tel", ((TextBox)(GridView1.FooterRow.FindControl("TextBox10"))).Text);
                cmd.Parameters.AddWithValue("@sexe", ((DropDownList)(GridView1.FooterRow.FindControl("DropDownList3"))).Text);
                cmd.Parameters.AddWithValue("@dns", ((TextBox)(GridView1.FooterRow.FindControl("TextBox12"))).Text);
                cmd.Parameters.AddWithValue("@adresse", ((TextBox)(GridView1.FooterRow.FindControl("TextBox13"))).Text);
                cmd.Parameters.AddWithValue("@ville", ((TextBox)(GridView1.FooterRow.FindControl("TextBox14"))).Text);
                cmd.Parameters.AddWithValue("@pays", ((TextBox)(GridView1.FooterRow.FindControl("TextBox15"))).Text);

            cmd.Parameters.AddWithValue("@date_insc", DateTime.Now.ToShortDateString());
            SqlCommand cmd2 = new SqlCommand("insert into dossier values (@date_crea,@desc,@id_cl)",cx);
            cmd2.Parameters.AddWithValue("@date_crea",DateTime.Now.ToShortDateString());
            cmd2.Parameters.AddWithValue("@desc","");

            SqlCommand cmd3 = new SqlCommand("select max(id_cl) from client",cx);

            SqlCommand cmd4 = new SqlCommand("insert into agence_client values(@id_ag,@id_cl)", cx);
            cmd4.Parameters.AddWithValue("@id_ag",Authentification.id_agence);
          
            cx.Open();
            cmd.ExecuteNonQuery();
            int k = (int)cmd3.ExecuteScalar();
            cx.Close();
            cmd4.Parameters.AddWithValue("@id_cl", k);
            cmd2.Parameters.AddWithValue("@id_cl",k);
            cx.Open();
            cmd4.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cx.Close();

                GridView1.EditIndex = -1;
                actualiser();
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
        

            string nom, sexe, ville, pays;
            if (TextBox16.Text == "") nom = "%";
            else nom = TextBox16.Text;
            if (TextBox17.Text == "") ville = "%";
            else ville = TextBox17.Text;
            if (TextBox18.Text == "") pays = "%";
            else pays = TextBox18.Text;
            if (DropDownList1.Text == "Tous") sexe = "%";
            else sexe = DropDownList1.Text;
            SqlCommand cmd = new SqlCommand("select client.id_cl,full_name,tel,sexe,dns,adresse,ville,pays, convert(varchar(10),date_insc,103) as 'date inscription' from client join agence_client on client.id_cl=agence_client.id_cl where full_name like '" + nom + "' and sexe like '" + sexe + "' and ville like '" + ville + "' and pays like '" + pays + "' and id_ag=" + Authentification.id_agence, cx);
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
                r[1] = "ismail fedaoui";
                r[2] = "0636720520";
                r[3] = "Homme";
                r[4] = "1994-10-25";
                r[5] = "lot argana";
                r[6] = "ait melloul";
                r[7] = "maroc";
                r[8] = "2019-02-01";
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
            ExportDataTableToPdf(dt, @"C:\Users\FEDAOUI\Desktop\ExportToPdf\clients.pdf", "La liste des clients :");

            System.Diagnostics.Process.Start(@"C:\Users\FEDAOUI\Desktop\ExportToPdf\clients.pdf");


        }
    }
    }
