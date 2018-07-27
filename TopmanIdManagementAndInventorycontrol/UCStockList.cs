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
    public partial class UCStockList : UserControl
    {
        private string sql;
        private SqlConnection conn;

        public UCStockList()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetStockListData();

            if (FormLogin.plevel == 1 || FormLogin.plevel == 2)
            {
                btnStockReplenish.Hide();
            }
        }

        public void refreshData()
        {
            GetStockListData();
        }

        void GetStockListData()
        {
            sql = "SELECT id_store as [Store ID], article as Article, id_season as Season, week as Week, size as Size, qty as Quantity FROM stock";
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvStockList.AutoGenerateColumns = true;
            dgvStockList.ReadOnly = true;
            dgvStockList.DataSource = DS.Tables[0];
            dgvStockList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            conn.Close();
        }

        private void btnStockReplenish_Click(object sender, EventArgs e)
        {
            FormStockReplenish formStockReplenish = new FormStockReplenish();
            formStockReplenish.FormClosed += formStockReplenish_Closed;
            formStockReplenish.ShowDialog();
        }

        void formStockReplenish_Closed(object sender, EventArgs e)
        {
            refreshData();
        }
    }
}
