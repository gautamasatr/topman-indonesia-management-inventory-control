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
    public partial class UCPosition : UserControl
    {
        //variabel untuk sql
        private string sql;
        private SqlConnection conn;

        //variabel untuk delete data
        private string selectedId;
        //variabel untuk update data
        public static string uid;
        public static string uposition;
        public static string ustatus;
        public static string ulevel;

        public UCPosition()
        {
            InitializeComponent();

            //code untuk sql
            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            //code untuk ambil data position dari database
            GetPositionData();

            //code untuk custom format di grid view
            dgvPosition.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPosition_CellFormatting);

            if (FormLogin.plevel == 3)
            {
                btnDelete.Hide();
            }       
        }

        //code untuk refresh data di grid view
        public void refreshData()
        {
            GetPositionData();
        }

        //code untuk ambil data position dari database
        void GetPositionData()
        {
            sql = "SELECT id AS ID, position AS [Position Name], CAST(status AS INT) AS Status, permission_level AS [Permission Level] FROM position ORDER BY position ASC";
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvPosition.AutoGenerateColumns = true;
            dgvPosition.ReadOnly = true;
            dgvPosition.DataSource = DS.Tables[0];
            dgvPosition.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            conn.Close();
        }

        //code untuk delete data
        void DeleteData()
        {
            sql = "DELETE FROM position "
                + "WHERE id = '" + selectedId + "' ";

            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //code kalo button new position di klik
        private void btnAddNewPosition_Click(object sender, EventArgs e)
        {
            FormAddPosition formAddPosition = new FormAddPosition();
            formAddPosition.FormClosed += formAddPosition_Closed;
            formAddPosition.ShowDialog();
        }

        //code kalo form add position di close
        void formAddPosition_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

        //code untuk kalo button delete di klik
        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPosition.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select position", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Position with ID : " + selectedId + " will be deleted", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteData();
                    MessageBox.Show("Position data deleted successfully", "Warning", MessageBoxButtons.OK);
                    refreshData();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        //code untuk kalo button edit di klik
        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPosition.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select position", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                foreach (DataGridViewRow row in dgvPosition.SelectedRows)
                {
                    uid = row.Cells[0].Value.ToString();
                    uposition = row.Cells[1].Value.ToString();
                    ustatus = row.Cells[2].Value.ToString();
                    ulevel = row.Cells[3].Value.ToString();

                    FormUpdatePosition formUpdatePosition = new FormUpdatePosition();
                    formUpdatePosition.FormClosed += formUpdatePosition_Closed;
                    formUpdatePosition.ShowDialog();
                }
            }
        }

        //code untuk kalo form update position di close
        void formUpdatePosition_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

        //code untuk formatiing data di gridview
        private void dgvPosition_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPosition.Columns[e.ColumnIndex].Name.Equals("Status"))
            {
                if (e.Value != null & e.Value.ToString() == "0")
                    e.Value = "Deactive";
                else if (e.Value != null & e.Value.ToString() == "1")
                    e.Value = "Active";
            }

        }
  
    }
}
