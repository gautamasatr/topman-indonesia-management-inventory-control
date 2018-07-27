using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TopmanIdManagementAndInventorycontrol
{
    public partial class FormAddPrice : Form
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

        public FormAddPrice()
        {
            InitializeComponent();

            //code untuk sql
            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            //code untuk ambil data combo box
            GetArticle();

            //code untuk hide border windows
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;

            //code untuk disable season dan week
            cmbSeason.Enabled = false;
            cmbWeek.Enabled = false;
            cmbPriceCategory.Enabled = false;
            txtPrice.Enabled = false;

            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.cmbArticle.TextChanged += new System.EventHandler(this.cmbArticle_TextChanged);
            this.cmbSeason.TextChanged += new System.EventHandler(this.cmbSeason_TextChanged);
            this.cmbWeek.TextChanged += new System.EventHandler(this.cmbWeek_TextChanged);
            this.cmbPriceCategory.TextChanged += new System.EventHandler(this.cmbPriceCategory_TextChanged);
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
            sql = "SELECT DISTINCT(id_season) FROM article_season_week WHERE article = '" + cmbArticle.Text.ToString() + "' ";
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
            sql = "SELECT week FROM article_season_week WHERE article = '" + cmbArticle.Text.ToString() + "' AND id_season = '" + cmbSeason.Text.ToString() + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbWeek.Items.Add(dr["week"]);
            }
            conn.Close();
        }

        //code untuk ambil data price category
        void GetPriceCategory()
        {
            cmbPriceCategory.Items.Clear();
            cmbPriceCategory.Items.Add("");
            sql = "SELECT id FROM price_ctg ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbPriceCategory.Items.Add(dr["id"]);
            }
            conn.Close();
        }

        //code untuk baca data kalo article di ubah
        private void cmbArticle_TextChanged(object sender, EventArgs e)
        {
            cmbSeason.Text = "";
            cmbWeek.Text = "";
            cmbPriceCategory.Text = "";
            txtPrice.Text = "";
            cmbWeek.Enabled = false;
            cmbPriceCategory.Enabled = false;
            txtPrice.Enabled = false;
            System.Threading.Thread.Sleep(100);
            GetSeason();
            cmbSeason.Enabled = true;
        }

        //code untuk baca data kalo season di ubah
        private void cmbSeason_TextChanged(object sender, EventArgs e)
        {
            cmbWeek.Text = "";
            cmbPriceCategory.Text = "";
            txtPrice.Text = "";
            cmbPriceCategory.Enabled = false;
            txtPrice.Enabled = false;
            System.Threading.Thread.Sleep(100);
            GetWeek();
            cmbWeek.Enabled = true;
        }

        //code untuk baca data kalo week di ubah
        private void cmbWeek_TextChanged(object sender, EventArgs e)
        {
            cmbPriceCategory.Text = "";
            txtPrice.Text = "";
            txtPrice.Enabled = false;
            System.Threading.Thread.Sleep(100);
            GetPriceCategory();
            cmbPriceCategory.Enabled = true;
        }

        //code untuk baca data kalo price category di ubah
        private void cmbPriceCategory_TextChanged(object sender, EventArgs e)
        {
            txtPrice.Text = "";
            System.Threading.Thread.Sleep(100);
            txtPrice.Enabled = true;
        }

        //code untuk cek duplicate id
        void ValidateId(string checkarticle, string checkseason, string checkweek, string checkpricectg)
        {
            sql = "SELECT article, id_season, week, id_price_ctg FROM article_price WHERE article = '" + checkarticle + "' AND id_season = '" + checkseason + "' AND week = '" + checkweek + "' AND id_price_ctg = '" + checkpricectg + "' ";
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

        //code untuk insert data price baru
        void InsertDataPrice()
        {
            string article = cmbArticle.Text.ToString();
            string id_season = cmbSeason.Text.ToString();
            string week = cmbWeek.Text.ToString();
            string pricectg = cmbPriceCategory.Text.ToString();
            int price = Convert.ToInt32(txtPrice.Text.ToString());

            sql = "INSERT INTO article_price "
            + "VALUES ('" + article.ToUpper() + "', '" + id_season.ToUpper() + "', '" + week.ToUpper() + "', '" + pricectg.ToUpper() + "', " + price + ", 1) ";
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

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
            ValidateId(cmbArticle.Text.ToString(), cmbSeason.Text.ToString(), cmbWeek.Text.ToString(), cmbPriceCategory.Text.ToString());

            if (string.IsNullOrEmpty(cmbArticle.Text) || string.IsNullOrEmpty(cmbSeason.Text) || string.IsNullOrEmpty(cmbWeek.Text) || string.IsNullOrEmpty(cmbPriceCategory.Text))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else if (duplicate)
            {
                MessageBox.Show("Article/season/week/size already registered, please choose another", "Warning", MessageBoxButtons.OK);
            }
            else if (Convert.ToInt32(txtPrice.Text.ToString()) == 0)
            {
                MessageBox.Show("Price cannot be zero", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                InsertDataPrice();
                MessageBox.Show("New Price Sucessfully Added", "Warning", MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
