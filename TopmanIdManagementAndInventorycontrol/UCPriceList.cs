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
    public partial class UCPriceList : UserControl
    {
        private string sql;
        private SqlConnection conn;

        public UCPriceList()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetPriceListData();

            if (FormLogin.plevel == 2)
            {
                btnAddNewPrice.Hide();
            }
        }


        public void refreshData()
        {
            GetPriceListData();
        }

        void GetPriceListData()
        {
            sql = "SELECT article as Article, id_season as Season, week as Week, id_price_ctg as [Price Category], price as Price, status as Status FROM article_price";
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvPriceList.AutoGenerateColumns = true;
            dgvPriceList.ReadOnly = true;
            dgvPriceList.DataSource = DS.Tables[0];
            dgvPriceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            conn.Close();
        }

        private void btnAddNewPrice_Click(object sender, EventArgs e)
        {
            FormAddPrice formAddPrice = new FormAddPrice();
            formAddPrice.FormClosed += formAddPrice_Closed;
            formAddPrice.ShowDialog();
        }

        void formAddPrice_Closed(object sender, EventArgs e)
        {
            refreshData();
        }
    }
}
