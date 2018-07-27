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
    public partial class UCSeason : UserControl
    {
        private string sql;
        private SqlConnection conn;
        private string selectedId;

        //variabel untuk update data
        public static string uid;
        public static string useason;

        public UCSeason()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetSeasonData();

            if (FormLogin.plevel == 0 || FormLogin.plevel == 1 || FormLogin.plevel == 2)
            {
                btnAddNewSeason.Hide();
                btnEdit.Hide();
                btnDelete.Hide();
            } 
        }

        public void refreshData()
        {
            GetSeasonData();
        }

        void GetSeasonData()
        {
            sql = "SELECT id as ID, season as Season FROM season";
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvSeason.AutoGenerateColumns = true;
            dgvSeason.ReadOnly = true;
            dgvSeason.DataSource = DS.Tables[0];
            dgvSeason.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            conn.Close();
        }

        private void btnAddNewSeason_Click(object sender, EventArgs e)
        {
            FormAddSeason formAddSeason = new FormAddSeason();
            formAddSeason.FormClosed += formAddSeason_Closed;
            formAddSeason.ShowDialog();
        }

        //code untuk kalo form add store di close
        void formAddSeason_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

        //code untuk delete data
        void DeleteData()
        {
            sql = "DELETE FROM season "
                + "WHERE id = '" + selectedId + "' ";

            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSeason.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select season", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Season with ID : " + selectedId + " will be deleted", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteData();
                    MessageBox.Show("Season data deleted successfully", "Warning", MessageBoxButtons.OK);
                    refreshData();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSeason.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select season", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                foreach (DataGridViewRow row in dgvSeason.SelectedRows)
                {
                    uid = row.Cells[0].Value.ToString();
                    useason = row.Cells[1].Value.ToString();

                    FormUpdateSeason formUpdateSeason = new FormUpdateSeason();
                    formUpdateSeason.FormClosed += formUpdateSeason_Closed;
                    formUpdateSeason.ShowDialog();
                }
            }
        }

        //code untuk kalo form update position di close
        void formUpdateSeason_Closed(object sender, EventArgs e)
        {
            refreshData();
        }
    }
}
