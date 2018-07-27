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
    public partial class FormAddItem : Form
    {
        //variabel buat sql
        private string sql;
        private SqlConnection conn;

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

        public FormAddItem()
        {
            InitializeComponent();

            //code untuk sql
            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            //code untuk ambil data combo box
            GetArticle();
            //GetSeason();
            //GetSize();

            //code untuk hide border windows
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;

            //code untuk disable season dan week
            cmbSeason.Enabled = false;
            cmbWeek.Enabled = false;
            cmbSize.Enabled = false;

            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.cmbArticle.TextChanged += new System.EventHandler(this.cmbArticle_TextChanged);
            this.cmbSeason.TextChanged += new System.EventHandler(this.cmbSeason_TextChanged);
            this.cmbWeek.TextChanged += new System.EventHandler(this.cmbWeek_TextChanged);
        }

        //code untuk ambil data article
        void GetArticle()
        {
            cmbArticle.Items.Clear();
            sql = "SELECT DISTINCT(article) FROM article_season_week ";
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
            cmbSeason.Items.Clear();
            cmbSeason.Items.Add("");
            sql = "SELECT DISTINCT(id_season) FROM article_season_week WHERE article = '" + cmbArticle.Text.ToString() +"' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbSeason.Items.Add(dr["id_season"]);
            }
            conn.Close();
        }

        //code untuk ambil data season
        void GetWeek()
        {
            cmbWeek.Items.Clear();
            cmbWeek.Items.Add("");
            sql = "SELECT week FROM article_season_week WHERE article = '" + cmbArticle.Text.ToString() + "' AND id_season = '" + cmbSeason.Text.ToString() +"' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbWeek.Items.Add(dr["week"]);
            }
            conn.Close();
        }

        //code untuk ambil data size
        void GetSize()
        {
            cmbSize.Items.Clear();
            cmbSize.Items.Add("");
            sql = "SELECT size FROM size ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbSize.Items.Add(dr["size"]);
            }
            conn.Close();
        }

        //code untuk baca data kalo article di ubah
        private void cmbArticle_TextChanged(object sender, EventArgs e)
        {
            cmbSeason.Text = "";
            cmbWeek.Text = "";
            cmbSize.Text = "";
            cmbWeek.Enabled = false;
            cmbSize.Enabled = false;
            System.Threading.Thread.Sleep(100);
            GetSeason();
            cmbSeason.Enabled = true;
        }

        //code untuk baca data kalo season di ubah
        private void cmbSeason_TextChanged(object sender, EventArgs e)
        {
            cmbWeek.Text = "";
            cmbSize.Text = "";
            cmbSize.Enabled = false;
            System.Threading.Thread.Sleep(100);
            GetWeek();
            cmbWeek.Enabled = true;
        }

        //code untuk baca data kalo week di ubah
        private void cmbWeek_TextChanged(object sender, EventArgs e)
        {
            cmbSize.Text = "";
            System.Threading.Thread.Sleep(100);
            GetSize();
            cmbSize.Enabled = true;
        }

        //code untuk cek duplicate id
        void ValidateId(string checkarticle, string checkseason, string checkweek, string checksize)
        {
            sql = "SELECT article, id_season, week, size FROM item WHERE article = '" + checkarticle + "' AND id_season = '" + checkseason + "' AND week = '" + checkweek + "' AND size = '" + checksize + "' ";
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

        //code untuk insert data staff baru
        void InsertDataItem()
        {
            string article = cmbArticle.Text.ToString();
            string id_season = cmbSeason.Text.ToString();
            string week = cmbWeek.Text.ToString();
            string size = cmbSize.Text.ToString();
            string upc = txtUpc.Text.ToString();

            sql = "INSERT INTO item "
            + "VALUES ('" + article.ToUpper() + "', '" + id_season.ToUpper() +"', '" + week.ToUpper() + "', '" + size + "', '" + upc + "') ";
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
            ValidateId(cmbArticle.Text.ToString(), cmbSeason.Text.ToString(), cmbWeek.Text.ToString(), cmbSize.Text.ToString());

            if (string.IsNullOrEmpty(cmbArticle.Text) || string.IsNullOrEmpty(cmbSeason.Text) || string.IsNullOrEmpty(cmbWeek.Text) || string.IsNullOrEmpty(cmbSize.Text) || string.IsNullOrEmpty(txtUpc.Text))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else if (regex.IsMatch(cmbArticle.Text))
            {
                MessageBox.Show("Article cannot use special characters or space", "Warning", MessageBoxButtons.OK);
            }
            else if (duplicate)
            {
                MessageBox.Show("Article/season/week/size already registered, please choose another", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                InsertDataItem();
                MessageBox.Show("New Item Sucessfully Added", "Warning", MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
