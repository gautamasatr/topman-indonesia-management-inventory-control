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
    public partial class FormStockReplenish : Form
    {
        //variabel buat sql
        private string sql;
        private SqlConnection conn;

        //variabel buat cek id duplicate
        private bool duplicate;
        private int realqty;

        //variabel untuk custom drag window
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        //panggil fungsi di windows untuk drag custom window
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormStockReplenish()
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
            sql = "SELECT DISTINCT(article) FROM item ";
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
            sql = "SELECT DISTINCT(id_season) FROM item WHERE article = '" + cmbArticle.Text.ToString() + "' ";
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
            sql = "SELECT DISTINCT(week) FROM item WHERE article = '" + cmbArticle.Text.ToString() + "' AND id_season = '" + cmbSeason.Text.ToString() + "' ";
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
            sql = "SELECT DISTINCT(size) FROM item WHERE article = '" + cmbArticle.Text.ToString() + "' AND id_season = '" + cmbSeason.Text.ToString() + "' AND week = '" + cmbWeek.Text.ToString() + "' ";
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
            sql = "SELECT article, id_season, week, size FROM stock WHERE article = '" + checkarticle + "' AND id_season = '" + checkseason + "' AND week = '" + checkweek + "' AND size = '" + checksize + "' ";
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
        void InsertDataStock()
        {
            string id_store = lblStore.Text.ToString();
            string article = cmbArticle.Text.ToString();
            string id_season = cmbSeason.Text.ToString();
            string week = cmbWeek.Text.ToString();
            string size = cmbSize.Text.ToString();
            int qty = Convert.ToInt32(nmrQuantity.Value);

            sql = "INSERT INTO stock "
            + "VALUES ('" + id_store.ToUpper() + "', '" + article.ToUpper() + "', '" + id_season.ToUpper() + "', '" + week.ToUpper() + "', '" + size + "', " + qty + ") ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        void GetQty()
        {
            sql = "SELECT qty FROM stock WHERE id_store = '" + lblStore.Text.ToString() + "' AND article = '" + cmbArticle.Text.ToString() + "' AND id_season = '" + cmbSeason.Text.ToString() + "' AND week = '" + cmbWeek.Text.ToString() + "' AND size = '" + cmbSize.Text.ToString() + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                realqty = Convert.ToInt32(dr["qty"]);
            }
            conn.Close();
        }

        //code untuk update data stock
        void UpdateDataStock()
        {
            GetQty();
            string id_store = lblStore.Text.ToString();
            string article = cmbArticle.Text.ToString();
            string id_season = cmbSeason.Text.ToString();
            string week = cmbWeek.Text.ToString();
            string size = cmbSize.Text.ToString();
            int qty = Convert.ToInt32(nmrQuantity.Value);
            int sumqty = qty + realqty;

            sql = "UPDATE stock "
                + "SET qty = " + sumqty + " "
                + "WHERE id_store = '" + id_store + "' AND article = '" + article + "' AND id_season = '" + id_season + "' AND week = '" + week + "' AND size = '" + size + "' ";
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

        private void btnReplenish_Click(object sender, EventArgs e)
        {
            ValidateId(cmbArticle.Text.ToString(), cmbSeason.Text.ToString(), cmbWeek.Text.ToString(), cmbSize.Text.ToString());

            if (string.IsNullOrEmpty(cmbArticle.Text) || string.IsNullOrEmpty(cmbSeason.Text) || string.IsNullOrEmpty(cmbWeek.Text) || string.IsNullOrEmpty(cmbSize.Text) || string.IsNullOrEmpty(nmrQuantity.Text.ToString()))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else if (duplicate)
            {
                DialogResult dialogResult = MessageBox.Show("Stock already registered, do you want to add the stock amount?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    UpdateDataStock();
                    MessageBox.Show("Stock Quantity Sucessfully Added", "Warning", MessageBoxButtons.OK);
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            else
            {
                InsertDataStock();
                MessageBox.Show("New Stock Sucessfully Added", "Warning", MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
