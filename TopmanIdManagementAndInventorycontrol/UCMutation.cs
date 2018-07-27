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
    public partial class UCMutation : UserControl
    {
        private string sql;
        private SqlConnection conn;

        public UCMutation()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetMutationData();

            if (FormLogin.plevel == 1)
            {
                btnNewMutation.Hide();
            } 
        }

        public void refreshData()
        {
            GetMutationData();
        }

        void GetMutationData()
        {
            sql = "SELECT mh.mutation_date as [Mutation Date], mh.id_staff as ID, s.name as Name, st1.name as [Previous Store], st2.name as [Present Store] "
                + "FROM (((mutation_history mh "
                + "LEFT JOIN staff s ON mh.id_staff = s.id) "
                + "LEFT JOIN store st1 ON mh.previous_store = st1.id) "
                + "LEFT JOIN store st2 ON mh.present_store = st2.id)"
                + "ORDER BY mh.mutation_date DESC";
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvMutation.AutoGenerateColumns = true;
            dgvMutation.ReadOnly = true;
            dgvMutation.DataSource = DS.Tables[0];
            dgvMutation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            conn.Close();
        }

        private void btnNewMutation_Click(object sender, EventArgs e)
        {
            FormMutation formMutation = new FormMutation();
            formMutation.FormClosed += formMutation_Closed;
            formMutation.ShowDialog();
        }

        void formMutation_Closed(object sender, EventArgs e)
        {
            refreshData();
        }
    }
}
