using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TopmanIdManagementAndInventorycontrol
{
    public partial class FormAddArticleSeason : Form
    {
        //variabel buat sql
        private string sql;
        private SqlConnection conn;
        private string id_season;

        //variabel buat cek id duplicate
        private bool duplicate;

        //variabel untuk custom drag window
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        //panggil fungsi di windows untuk drag custom window
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        public FormAddArticleSeason()
        {
            InitializeComponent();

            //code untuk sql
            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            //code untuk ambil data combo box
            GetArticle();
            GetSeason();

            //code untuk hide border windows
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;

            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
        }

        //code untuk ambil data article
        void GetArticle()
        {
            sql = "SELECT article FROM article ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbArticle.Items.Add(dr["article"]);
            }
            conn.Close();
        }

        //code untuk ambil data season
        void GetSeason()
        {
            sql = "SELECT season FROM season ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbSeason.Items.Add(dr["season"]);
            }
            conn.Close();
        }

        //code untuk ambil data id season yg di pilih
        void GetSelectedSeason()
        {
            sql = "SELECT id, season FROM season WHERE season = '" + cmbSeason.Text.ToString() + "'";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                id_season = dr["id"].ToString();
            }
            conn.Close();
        }

        //code untuk cek duplicate id
        void ValidateId(string checkarticle, string checkseason, string checkweek)
        {
            sql = "SELECT article, id_season, week FROM article_season_week WHERE article = '" + checkarticle + "' AND id_season = '" + checkseason + "' AND week = '" + checkweek + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                duplicate = true;
            }
            else
            {
                duplicate = false;
            }
            conn.Close();
        }

        //code untuk insert data article season baru
        void InsertDataArticleSeason()
        {
            GetSelectedSeason();

            string article = cmbArticle.Text.ToString();
            string week = txtWeek.Text.ToString();

            //MessageBox.Show(article+" "+id_department+" "+id_category+" "+description,"warning",MessageBoxButtons.OK);

            sql = "INSERT INTO article_season_week "
            + "VALUES ('" + article.ToUpper() + "', '" + id_season.ToUpper() + "', '" + week.ToUpper() + "') ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //code untuk window bisa di drag
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9]");
            GetSelectedSeason();
            ValidateId(cmbArticle.Text.ToString(), id_season, txtWeek.Text.ToString());

            if (string.IsNullOrEmpty(cmbArticle.Text) || string.IsNullOrEmpty(cmbSeason.Text) || string.IsNullOrEmpty(txtWeek.Text))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else if (regex.IsMatch(txtWeek.Text))
            {
                MessageBox.Show("Week cannot use special characters or space", "Warning", MessageBoxButtons.OK);
            }
            else if (duplicate)
            {
                MessageBox.Show("Article/Season/Week already registered, please choose another", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                InsertDataArticleSeason();
                MessageBox.Show("New Article Season Sucessfully Added", "Warning", MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
