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
    public partial class UCItem : UserControl
    {
        //variabel untuk sql
        private string sql;
        private SqlConnection conn;

        //variabel untuk delete data
        //private string selectedId;

        //variabel untuk update data
        public static string uarticle;
        public static string useason;
        public static string uweek;
        public static string usize;
        public static string uupc;

        //variabel untuk ambil data item berdasarkan filter
        private string season;

        public UCItem()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetItemData(season);
            GetSeason();

            if (FormLogin.plevel == 0 || FormLogin.plevel == 1 || FormLogin.plevel == 2)
            {
                btnAddNewItem.Hide();
            } 
        }

        public void refreshData()
        {
            cmbSeason.Text = "";
            GetItemData(season);
        }

        void GetItemData(string ssn)
        {
            sql = "SELECT i.article as Article, s.season as Season, i.week as Week, i.size as Size, i.upc as UPC "
                + "FROM item i "
                + "INNER JOIN season s ON i.id_season = s.id ";

            if (!string.IsNullOrEmpty(cmbSeason.Text))
                sql = sql + "WHERE s.season = '" + ssn + "' ";

            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvItem.AutoGenerateColumns = true;
            dgvItem.ReadOnly = true;
            dgvItem.DataSource = DS.Tables[0];
            dgvItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            conn.Close();
        }

        //code untuk ambil data department
        void GetSeason()
        {
            cmbSeason.Items.Add("");
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

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            FormAddItem formAddItem = new FormAddItem();
            formAddItem.FormClosed += formAddItem_Closed;
            formAddItem.ShowDialog();
        }

        void formAddItem_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbSeason.Text) && !string.IsNullOrEmpty(cmbSeason.Text))
            {
                season = cmbSeason.Text;
            }
            GetItemData(season);
        }

    }
}
