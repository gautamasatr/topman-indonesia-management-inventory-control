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
    public partial class UCDepartment : UserControl
    {
        private string sql;
        private SqlConnection conn;
        private string selectedId;

        //variabel untuk update data
        public static string uid;
        public static string udepartment;

        public UCDepartment()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetDepartmentData();

            if (FormLogin.plevel == 0 || FormLogin.plevel == 1 || FormLogin.plevel == 2)
            {
                btnAddNewDepartment.Hide();
                btnEdit.Hide();
                btnDelete.Hide();
            } 
        }

        public void refreshData()
        {
            GetDepartmentData();
        }

        void GetDepartmentData()
        {
            sql = "SELECT id as Department, name as Name FROM department";
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvDepartment.AutoGenerateColumns = true;
            dgvDepartment.ReadOnly = true;
            dgvDepartment.DataSource = DS.Tables[0];
            dgvDepartment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            conn.Close();
        }

        private void btnAddNewDepartment_Click(object sender, EventArgs e)
        {
            FormAddDepartment formAddDepartment = new FormAddDepartment();
            formAddDepartment.FormClosed += formAddDepartment_Closed;
            formAddDepartment.ShowDialog();
        }

        //code untuk kalo form add store di close
        void formAddDepartment_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

        //code untuk delete data
        void DeleteData()
        {
            sql = "DELETE FROM department "
                + "WHERE id = '" + selectedId + "' ";

            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDepartment.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select department", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Department with ID : " + selectedId + " will be deleted", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteData();
                    MessageBox.Show("Department data deleted successfully", "Warning", MessageBoxButtons.OK);
                    refreshData();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDepartment.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select department", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                foreach (DataGridViewRow row in dgvDepartment.SelectedRows)
                {
                    uid = row.Cells[0].Value.ToString();
                    udepartment = row.Cells[1].Value.ToString();

                    FormUpdateDepartment formUpdateDepartment = new FormUpdateDepartment();
                    formUpdateDepartment.FormClosed += formUpdateDepartment_Closed;
                    formUpdateDepartment.ShowDialog();
                }
            }
        }

        //code untuk kalo form update position di close
        void formUpdateDepartment_Closed(object sender, EventArgs e)
        {
            refreshData();
        }
    }
}
