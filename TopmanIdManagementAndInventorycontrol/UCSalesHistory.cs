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
    public partial class UCSalesHistory : UserControl
    {
        private string sql;
        private SqlConnection conn;

        public UCSalesHistory()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetSalesHistoryData();
        }

        public void refreshData()
        {
            GetSalesHistoryData();
        }

        void GetSalesHistoryData()
        {
            sql = "SELECT date as Date, id_store as [Store ID], article as Article, id_season as Season, week as Week, id_price_ctg as [Price Category], price as Price, qty as Quantity, total as [Total Price], sales_staff as [Sales Staff] FROM sales_history";
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvSalesHistory.AutoGenerateColumns = true;
            dgvSalesHistory.ReadOnly = true;
            dgvSalesHistory.DataSource = DS.Tables[0];
            dgvSalesHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            conn.Close();
        }
    }
}
