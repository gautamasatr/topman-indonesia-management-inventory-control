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
    public partial class UCStockTransferHistory : UserControl
    {
        private string sql;
        private SqlConnection conn;

        public UCStockTransferHistory()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetStockTransferHistoryData();
        }

        public void refreshData()
        {
            GetStockTransferHistoryData();
        }

        void GetStockTransferHistoryData()
        {
            sql = "SELECT date as Date, tsout as [Transfer From], tsin as [Transfer To], article as Article, id_season as Season, week as Week, size as Size, qty as Quantity, operator as [Operator ID] FROM stock_transfer_history";
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvStockTransferHistory.AutoGenerateColumns = true;
            dgvStockTransferHistory.ReadOnly = true;
            dgvStockTransferHistory.DataSource = DS.Tables[0];
            dgvStockTransferHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            conn.Close();
        }
    }
}
