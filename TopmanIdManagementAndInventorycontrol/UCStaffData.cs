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
    public partial class UCStaffData : UserControl
    {
        private string sql;
        private SqlConnection conn;
        private string position;
        private int status;
        private string selectedId;

        public static string uid;
        public static string uposition;
        public static string uid_card;
        public static string uname;
        public static string uaddress;
        public static string ubirthplace;
        public static string ubirthdate;
        public static string ustatus;


        public UCStaffData()
        {
            InitializeComponent();
            
            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetStaffData(position, status);
            GetPosition(null);
            GetStatus();
            dgvStaff.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStaff_CellFormatting);

            if (FormLogin.plevel == 1 || FormLogin.plevel == 2)
            {
                btnAddNewStaff.Hide();
                btnEdit.Hide();
                btnDelete.Hide();
            }
            else if (FormLogin.plevel == 3)
            {
                btnDelete.Hide();
            }
        }

        public void refreshData()
        {
            cmbPosition.Text = "";
            cmbStatus.Text = "";
            GetStaffData(position, status);
            GetPosition(null);
        }

        void GetStaffData(string pos, int stats)
        {
            sql = "SELECT s.id as ID, s.name as [Full Name], p.position as Position, st.name as [Current Store], s.id_card as [ID Card], s.address as Address, s.birthplace as Birthplace, s.birthdate as Birthdate, s.register_date as [Register Date], s.status as Status "
                + "FROM (((staff s "
                + "LEFT JOIN position p ON s.id_position = p.id) "
                + "LEFT JOIN store_staff ss ON s.id = ss.id_staff) "
                + "LEFT JOIN store st ON ss.id_store = st.id) ";
            
            if (!string.IsNullOrEmpty(cmbPosition.Text) && !string.IsNullOrEmpty(cmbStatus.Text))
                sql = sql + "WHERE s.id_position = '" + pos + "' AND s.status = " + stats + "";
            else if (!string.IsNullOrEmpty(cmbPosition.Text) && string.IsNullOrEmpty(cmbStatus.Text))
                sql = sql + "WHERE s.id_position = '" + pos + "'";
            else if (string.IsNullOrEmpty(cmbPosition.Text) && !string.IsNullOrEmpty(cmbStatus.Text))
                sql = sql + "WHERE s.status = " + stats;
            
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvStaff.AutoGenerateColumns = true;
            dgvStaff.ReadOnly = true;
            dgvStaff.DataSource = DS.Tables[0];
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            conn.Close();

        }

        void GetPosition(string pos)
        {
            sql = "SELECT id, position, status FROM position WHERE status <> 0 ";

            if (!string.IsNullOrEmpty(cmbPosition.Text))
            {
                sql = sql + "AND position = '"+pos+"'";
                conn.Open();
                SqlCommand cmdSql = new SqlCommand(sql, conn);
                SqlDataReader dr = cmdSql.ExecuteReader();
                while (dr.Read())
                {
                    position = dr["id"].ToString();
                }
                conn.Close();
            }
            else if (string.IsNullOrEmpty(cmbPosition.Text))
            {
                cmbPosition.Items.Clear();
                cmbPosition.Items.Add("");
                conn.Open();
                SqlCommand cmdSql = new SqlCommand(sql, conn);
                SqlDataReader dr = cmdSql.ExecuteReader();
                while (dr.Read())
                {
                    cmbPosition.Items.Add(dr["position"]);
                }
                conn.Close();
            }
        }

        void GetStatus()
        {
            cmbStatus.Items.Add("");
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Deactive");
            cmbStatus.Items.Add("Leave");
        }

        void DeleteData()
        {
            sql = "DELETE FROM staff "
                + "WHERE id = '" + selectedId + "' ";

            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbPosition.Text) && !string.IsNullOrEmpty(cmbStatus.Text))
            {
                position = cmbPosition.Text;
                GetPosition(position);

                if (cmbStatus.Text == "Deactive")
                    status = 0;
                else if (cmbStatus.Text == "Active")
                    status = 1;
                else if (cmbStatus.Text == "Leave")
                    status = 2;
            }
            else if (!string.IsNullOrEmpty(cmbPosition.Text) && string.IsNullOrEmpty(cmbStatus.Text))
            {
                position = cmbPosition.Text;
                GetPosition(position);
            }
            else if (string.IsNullOrEmpty(cmbPosition.Text) && !string.IsNullOrEmpty(cmbStatus.Text))
            {
                if (cmbStatus.Text == "Deactive")
                    status = 0;
                else if (cmbStatus.Text == "Active")
                    status = 1;
                else if (cmbStatus.Text == "Leave")
                    status = 2;
            }
            GetStaffData(position, status);
            
        }

        private void dgvStaff_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStaff.Columns[e.ColumnIndex].Name.Equals("Status"))
            {
                if(e.Value!= null & e.Value.ToString() == "0")
                    e.Value = "Deactive";
                else if(e.Value!= null & e.Value.ToString() == "1")
                    e.Value = "Active";
                else if (e.Value != null & e.Value.ToString() == "2")
                    e.Value = "Leave";
            }

        }

        private void btnAddNewStaff_Click(object sender, EventArgs e)
        {
            FormAddStaff formAddStaff = new FormAddStaff();
            formAddStaff.FormClosed += formAddStaff_Closed;
            formAddStaff.ShowDialog();
        }

        void formAddStaff_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStaff.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select staff", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Staff with ID : " + selectedId + " will be deleted", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteData();
                    MessageBox.Show("Staff data deleted successfully", "Warning", MessageBoxButtons.OK);
                    refreshData();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStaff.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select staff", "Warning", MessageBoxButtons.OK);

            }
            else
            {

                foreach (DataGridViewRow row in dgvStaff.SelectedRows)
                {
                    uid = row.Cells[0].Value.ToString();
                    uposition = row.Cells[2].Value.ToString();
                    uid_card = row.Cells[4].Value.ToString();
                    uname = row.Cells[1].Value.ToString();
                    uaddress = row.Cells[5].Value.ToString();
                    ubirthplace = row.Cells[6].Value.ToString();
                    ubirthdate = row.Cells[7].Value.ToString();
                    ustatus = row.Cells[9].Value.ToString();

                    FormUpdateStaff formUpdateStaff = new FormUpdateStaff();
                    formUpdateStaff.FormClosed += formUpdateStaff_Closed;
                    formUpdateStaff.ShowDialog();
                } 
            }
        }

        void formUpdateStaff_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

    }
}
