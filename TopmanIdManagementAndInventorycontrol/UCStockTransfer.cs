using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TopmanIdManagementAndInventorycontrol
{
    public partial class UCStockTransfer : UserControl
    {
        //variabel buat sql
        private string sql;
        private SqlConnection conn;

        //variabel buat cek id duplicate
        private bool duplicate;

        private int tsoutqty;
        private int tsinqty;

        private string operatorId;

        public UCStockTransfer()
        {
            InitializeComponent();

            //code untuk sql
            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            refreshData();

            //kode untuk baca combo box value nya berubah
            this.cmbTsout.TextChanged += new System.EventHandler(this.cmbTsout_TextChanged);
            this.cmbTsin.TextChanged += new System.EventHandler(this.cmbTsin_TextChanged);
            this.cmbArticle.TextChanged += new System.EventHandler(this.cmbArticle_TextChanged);
            this.cmbSeason.TextChanged += new System.EventHandler(this.cmbSeason_TextChanged);
            this.cmbWeek.TextChanged += new System.EventHandler(this.cmbWeek_TextChanged);
            this.cmbSize.TextChanged += new System.EventHandler(this.cmbSize_TextChanged);
        }

        public void refreshData()
        {
            GetTsoutStore();
            cmbTsout.Text = "";

            cmbTsin.Items.Clear();
            cmbArticle.Items.Clear();
            cmbSeason.Items.Clear();
            cmbWeek.Items.Clear();
            cmbSize.Items.Clear();
            nmrQuantity.Value = 0;

            cmbTsin.Enabled = false;
            cmbArticle.Enabled = false;
            cmbSeason.Enabled = false;
            cmbWeek.Enabled = false;
            cmbSize.Enabled = false;
            nmrQuantity.Enabled = false;
        }

        //code untuk ambil data store tsout
        void GetTsoutStore()
        {
            cmbTsout.Items.Clear();
            sql = "SELECT id FROM store ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbTsout.Items.Add(dr["id"]);
            }
            conn.Close();
        }

        //code untuk ambil data store tsin
        void GetTsinStore()
        {
            cmbTsin.Items.Clear();
            sql = "SELECT id FROM store WHERE id <> '" + cmbTsout.Text.ToString() + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbTsin.Items.Add(dr["id"]);
            }
            conn.Close();
        }

        //code untuk baca data kalo tsout di ubah
        private void cmbTsout_TextChanged(object sender, EventArgs e)
        {
            cmbArticle.Text = "";
            cmbSeason.Text = "";
            cmbWeek.Text = "";
            cmbSize.Text = "";
            nmrQuantity.Value = 0;

            cmbArticle.Enabled = false;
            cmbSeason.Enabled = false;
            cmbWeek.Enabled = false;
            cmbSize.Enabled = false;
            nmrQuantity.Enabled = false;
            
            System.Threading.Thread.Sleep(100);
            GetTsinStore();
            cmbTsin.Enabled = true;
        }

        //code untuk ambil data article tsout
        void GetArticle()
        {
            cmbArticle.Items.Clear();
            cmbArticle.Items.Add("");
            sql = "SELECT DISTINCT(article) FROM stock WHERE id_store = '" + cmbTsout.Text.ToString() + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbArticle.Items.Add(dr["article"]);
            }
            conn.Close();
        }

        //code untuk baca data kalo tsin di ubah
        private void cmbTsin_TextChanged(object sender, EventArgs e)
        {
            cmbSeason.Text = "";
            cmbWeek.Text = "";
            cmbSize.Text = "";
            nmrQuantity.Value = 0;

            cmbSeason.Enabled = false;
            cmbWeek.Enabled = false;
            cmbSize.Enabled = false;
            nmrQuantity.Enabled = false;

            System.Threading.Thread.Sleep(100);
            GetArticle();
            cmbArticle.Enabled = true;
        }

        //code untuk ambil data season tsout
        void GetSeason()
        {
            cmbSeason.Items.Clear();
            cmbSeason.Items.Add("");
            sql = "SELECT DISTINCT(id_season) FROM stock WHERE id_store = '" + cmbTsout.Text.ToString() + "' AND article = '" + cmbArticle.Text.ToString() + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbSeason.Items.Add(dr["id_season"]);
            }
            conn.Close();
        }

        //code untuk baca data kalo article di ubah
        private void cmbArticle_TextChanged(object sender, EventArgs e)
        {
            cmbWeek.Text = "";
            cmbSize.Text = "";
            nmrQuantity.Value = 0;

            cmbWeek.Enabled = false;
            cmbSize.Enabled = false;
            nmrQuantity.Enabled = false;

            System.Threading.Thread.Sleep(100);
            GetSeason();
            cmbSeason.Enabled = true;
        }

        //code untuk ambil data week tsout
        void GetWeek()
        {
            cmbWeek.Items.Clear();
            cmbWeek.Items.Add("");
            sql = "SELECT DISTINCT(week) FROM stock WHERE id_store = '" + cmbTsout.Text.ToString() + "' AND article = '" + cmbArticle.Text.ToString() + "' AND id_season = '" + cmbSeason.Text.ToString() + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbWeek.Items.Add(dr["week"]);
            }
            conn.Close();
        }

        //code untuk baca data kalo season di ubah
        private void cmbSeason_TextChanged(object sender, EventArgs e)
        {
            cmbSize.Text = "";
            nmrQuantity.Value = 0;

            cmbSize.Enabled = false;
            nmrQuantity.Enabled = false;

            System.Threading.Thread.Sleep(100);
            GetWeek();
            cmbWeek.Enabled = true;
        }

        //code untuk ambil data size tsout
        void GetSize()
        {
            cmbSize.Items.Clear();
            cmbSize.Items.Add("");
            sql = "SELECT DISTINCT(size) FROM stock WHERE id_store = '" + cmbTsout.Text.ToString() + "' AND article = '" + cmbArticle.Text.ToString() + "' AND id_season = '" + cmbSeason.Text.ToString() + "' AND week = '" + cmbWeek.Text.ToString() + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbSize.Items.Add(dr["size"]);
            }
            conn.Close();
        }

        //code untuk baca data kalo week di ubah
        private void cmbWeek_TextChanged(object sender, EventArgs e)
        {
            nmrQuantity.Value = 0;

            nmrQuantity.Enabled = false;

            System.Threading.Thread.Sleep(100);
            GetSize();
            cmbSize.Enabled = true;
        }

        //code untuk ambil data size tsout
        void GetQty()
        {
            nmrQuantity.Value = 0;
            sql = "SELECT qty FROM stock WHERE id_store = '" + cmbTsout.Text.ToString() + "' AND article = '" + cmbArticle.Text.ToString() + "' AND id_season = '" + cmbSeason.Text.ToString() + "' AND week = '" + cmbWeek.Text.ToString() + "' AND size = '" + cmbSize.Text.ToString() + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                nmrQuantity.Maximum = Convert.ToInt32(dr["qty"]);
            }
            conn.Close();
        }

        //code untuk baca data kalo size di ubah
        private void cmbSize_TextChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            GetQty();
            nmrQuantity.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        //code untuk cek duplicate id
        void ValidateId(string checkstore, string checkarticle, string checkseason, string checkweek, string checksize)
        {
            sql = "SELECT id_store, article, id_season, week, size FROM stock WHERE id_store = '" + checkstore + "' AND article = '" + checkarticle + "' AND id_season = '" + checkseason + "' AND week = '" + checkweek + "' AND size = '" + checksize + "' ";
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

        void GetTsoutQty()
        {
            sql = "SELECT qty FROM stock WHERE id_store = '" + cmbTsout.Text.ToString() + "' AND article = '" + cmbArticle.Text.ToString() + "' AND id_season = '" + cmbSeason.Text.ToString() + "' AND week = '" + cmbWeek.Text.ToString() + "' AND size = '" + cmbSize.Text.ToString() + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                tsoutqty = Convert.ToInt32(dr["qty"]);
            }
            conn.Close();
        }

        void GetTsinQty()
        {
            sql = "SELECT qty FROM stock WHERE id_store = '" + cmbTsin.Text.ToString() + "' AND article = '" + cmbArticle.Text.ToString() + "' AND id_season = '" + cmbSeason.Text.ToString() + "' AND week = '" + cmbWeek.Text.ToString() + "' AND size = '" + cmbSize.Text.ToString() + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                tsinqty = Convert.ToInt32(dr["qty"]);
            }
            conn.Close();
        }

        //code untuk update data stock
        void UpdateDataStock()
        {
            GetTsinQty();
            string id_store = cmbTsin.Text.ToString();
            string article = cmbArticle.Text.ToString();
            string id_season = cmbSeason.Text.ToString();
            string week = cmbWeek.Text.ToString();
            string size = cmbSize.Text.ToString();
            int qty = Convert.ToInt32(nmrQuantity.Value);
            int sumqty = qty + tsinqty;

            sql = "UPDATE stock "
                + "SET qty = " + sumqty + " "
                + "WHERE id_store = '" + id_store + "' AND article = '" + article + "' AND id_season = '" + id_season + "' AND week = '" + week + "' AND size = '" + size + "' ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //code untuk insert data stock baru
        void InsertDataStock()
        {
            string id_store = cmbTsin.Text.ToString();
            string article = cmbArticle.Text.ToString();
            string id_season = cmbSeason.Text.ToString();
            string week = cmbWeek.Text.ToString();
            string size = cmbSize.Text.ToString();
            int qty = Convert.ToInt32(nmrQuantity.Value);

            //MessageBox.Show("tsin qty = "+qty,"warning",MessageBoxButtons.OK);

            sql = "INSERT INTO stock "
            + "VALUES ('" + id_store.ToUpper() + "', '" + article.ToUpper() + "', '" + id_season.ToUpper() + "', '" + week.ToUpper() + "', '" + size + "', " + qty + ") ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //code untuk update data stock
        void DeductStock()
        {
            GetTsoutQty();
            string id_store = cmbTsout.Text.ToString();
            string article = cmbArticle.Text.ToString();
            string id_season = cmbSeason.Text.ToString();
            string week = cmbWeek.Text.ToString();
            string size = cmbSize.Text.ToString();
            int qty = Convert.ToInt32(nmrQuantity.Value);
            int decqty = tsoutqty - qty;

            sql = "UPDATE stock "
                + "SET qty = " + decqty + " "
                + "WHERE id_store = '" + id_store + "' AND article = '" + article + "' AND id_season = '" + id_season + "' AND week = '" + week + "' AND size = '" + size + "' ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //code untuk ambil id operator
        void GetOperatorId()
        {
            sql = "SELECT id FROM staff WHERE name = '" + FormLogin.name + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                operatorId = dr["id"].ToString();
            }
            conn.Close();
        }

        //code untuk catat stock transfer history
        void StockTransferRecord()
        {
            GetOperatorId();

            string date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string tsin = cmbTsin.Text.ToString();
            string tsout = cmbTsout.Text.ToString();
            string article = cmbArticle.Text.ToString();
            string id_season = cmbSeason.Text.ToString();
            string week = cmbWeek.Text.ToString();
            string size = cmbSize.Text.ToString();
            int qty = Convert.ToInt32(nmrQuantity.Value);

            sql = "INSERT INTO stock_transfer_history(date, tsin, tsout, article, id_season, week, size, qty, operator) "
            + "VALUES ('" + date + "', '" + tsin.ToUpper() + "', '" + tsout.ToUpper() + "', '" + article.ToUpper() + "', '" + id_season.ToUpper() + "', '" + week.ToUpper() + "', '" + size + "', " + qty + ", '" + operatorId + "' ) ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            ValidateId(cmbTsin.Text.ToString(), cmbArticle.Text.ToString(), cmbSeason.Text.ToString(), cmbWeek.Text.ToString(), cmbSize.Text.ToString());
            
            if (string.IsNullOrEmpty(cmbTsout.Text) || string.IsNullOrEmpty(cmbTsin.Text) || string.IsNullOrEmpty(cmbArticle.Text) || string.IsNullOrEmpty(cmbSeason.Text) || string.IsNullOrEmpty(cmbWeek.Text) || string.IsNullOrEmpty(cmbSize.Text) || string.IsNullOrEmpty(nmrQuantity.Text.ToString()))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else if (nmrQuantity.Value == 0)
                MessageBox.Show("Quantity must bigger than 0", "Warning", MessageBoxButtons.OK);
            else if (duplicate)
            {
                UpdateDataStock();
            }
            else
            {
                InsertDataStock();
            }
            DeductStock();
            StockTransferRecord();
            MessageBox.Show("Stock Successfully Transferred", "Warning", MessageBoxButtons.OK);
            refreshData();
        }








    }
}
