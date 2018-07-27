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
    public partial class UCStoreList : UserControl
    {
        private string sql;
        private SqlConnection conn;

        private string selectedId;

        public static string uid;
        public static string uname;
        public static string uaddress;
        public static string uphone;
        public static string ufax;
        public static string ustatus;

        public UCStoreList()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetStoreListData();
            dgvStoreList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStoreList_CellFormatting);

            if (FormLogin.plevel == 0 || FormLogin.plevel == 1 || FormLogin.plevel == 2)
            {
                btnAddNewStore.Hide();
                btnEdit.Hide();
                btnDelete.Hide();
            }
        }

        public void refreshData()
        {
            GetStoreListData();
        }

        void GetStoreListData()
        {
            sql = "SELECT id as [Store ID], name as [Store Name], address as Address, phone as Phone, fax as Fax, CAST(status AS INT) as Status FROM store";
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvStoreList.AutoGenerateColumns = true;
            dgvStoreList.ReadOnly = true;
            dgvStoreList.DataSource = DS.Tables[0];
            dgvStoreList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            conn.Close();
        }

        //code untuk delete data
        void DeleteData()
        {
            sql = "DELETE FROM store "
                + "WHERE id = '" + selectedId + "' ";

            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void dgvStoreList_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStoreList.Columns[e.ColumnIndex].Name.Equals("Status"))
            {
                if (e.Value != null & e.Value.ToString() == "0")
                    e.Value = "Closed";
                else if (e.Value != null & e.Value.ToString() == "1")
                    e.Value = "Open";
                else if (e.Value != null & e.Value.ToString() == "2")
                    e.Value = "Renovation";
            }

        }

        private void btnAddNewStore_Click(object sender, EventArgs e)
        {
            FormAddStore formAddStore = new FormAddStore();
            formAddStore.FormClosed += formAddStore_Closed;
            formAddStore.ShowDialog();
        }

        //code untuk kalo form add store di close
        void formAddStore_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStoreList.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select position", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Store with ID : " + selectedId + " will be deleted", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteData();
                    MessageBox.Show("Store data deleted successfully", "Warning", MessageBoxButtons.OK);
                    refreshData();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStoreList.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select store", "Warning", MessageBoxButtons.OK);

            }
            else
            {

                foreach (DataGridViewRow row in dgvStoreList.SelectedRows)
                {
                    uid = row.Cells[0].Value.ToString();
                    uname = row.Cells[1].Value.ToString();
                    uaddress = row.Cells[2].Value.ToString();
                    uphone = row.Cells[3].Value.ToString();
                    ufax = row.Cells[4].Value.ToString();
                    ustatus = row.Cells[5].Value.ToString();

                    FormUpdateStore formUpdateStore = new FormUpdateStore();
                    formUpdateStore.FormClosed += formUpdateStore_Closed;
                    formUpdateStore.ShowDialog();
                }
            }
        }

        //code untuk kalo form update store di close
        void formUpdateStore_Closed(object sender, EventArgs e)
        {
            refreshData();
        }
    }
}
