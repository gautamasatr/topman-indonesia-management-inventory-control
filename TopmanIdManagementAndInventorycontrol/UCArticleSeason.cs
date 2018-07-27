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
    public partial class UCArticleSeason : UserControl
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

        //variabel untuk ambil data item berdasarkan filter
        private string season;

        public UCArticleSeason()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetArticleSeasonData(season);
            GetSeason();

            if (FormLogin.plevel == 0 || FormLogin.plevel == 1 || FormLogin.plevel == 2)
            {
                btnAddNewArticleSeason.Hide();
            } 
        }

        public void refreshData()
        {
            cmbSeason.Text = "";
            GetArticleSeasonData(season);
        }

        void GetArticleSeasonData(string ssn)
        {
            sql = "SELECT asw.article as Article, s.season as Season, asw.week as Week "
                + "FROM article_season_week asw "
                + "INNER JOIN season s ON asw.id_season = s.id ";

            if (!string.IsNullOrEmpty(cmbSeason.Text))
                sql = sql + "WHERE s.season = '" + ssn + "' ";

            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvArticleSeason.AutoGenerateColumns = true;
            dgvArticleSeason.ReadOnly = true;
            dgvArticleSeason.DataSource = DS.Tables[0];
            dgvArticleSeason.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbSeason.Text))
            {
                season = cmbSeason.Text;
            }
            GetArticleSeasonData(season);
        }

        private void btnAddNewArticleSeason_Click(object sender, EventArgs e)
        {
            FormAddArticleSeason formAddArticleSeason = new FormAddArticleSeason();
            formAddArticleSeason.FormClosed += formAddArticleSeason_Closed;
            formAddArticleSeason.ShowDialog();
        }

        void formAddArticleSeason_Closed(object sender, EventArgs e)
        {
            refreshData();
        }


    }
}
