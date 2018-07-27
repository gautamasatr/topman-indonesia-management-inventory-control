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
    public partial class UCCategory : UserControl
    {
        private string sql;
        private SqlConnection conn;
        private string selectedId;

        //variabel untuk update data
        public static string uid;
        public static string ucategory;

        public UCCategory()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;
            
            GetCategoryData();

            if (FormLogin.plevel == 0 || FormLogin.plevel == 1 || FormLogin.plevel == 2)
            {
                btnAddNewCategory.Hide();
                btnEdit.Hide();
                btnDelete.Hide();
            } 
        }

        public void refreshData()
        {
            GetCategoryData();
        }

        void GetCategoryData()
        {
            sql = "SELECT id as Category, description as Description FROM category";
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvCategory.AutoGenerateColumns = true;
            dgvCategory.ReadOnly = true;
            dgvCategory.DataSource = DS.Tables[0];
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            conn.Close();
        }

        private void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            FormAddCategory formAddCategory = new FormAddCategory();
            formAddCategory.FormClosed += formAddCategory_Closed;
            formAddCategory.ShowDialog();
        }

        //code untuk kalo form add store di close
        void formAddCategory_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

        //code untuk delete data
        void DeleteData()
        {
            sql = "DELETE FROM category "
                + "WHERE id = '" + selectedId + "' ";

            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCategory.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select category", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Category with ID : " + selectedId + " will be deleted", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteData();
                    MessageBox.Show("Category data deleted successfully", "Warning", MessageBoxButtons.OK);
                    refreshData();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCategory.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select category", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                foreach (DataGridViewRow row in dgvCategory.SelectedRows)
                {
                    uid = row.Cells[0].Value.ToString();
                    ucategory = row.Cells[1].Value.ToString();

                    FormUpdateCategory formUpdateCategory = new FormUpdateCategory();
                    formUpdateCategory.FormClosed += formUpdateCategory_Closed;
                    formUpdateCategory.ShowDialog();
                }
            }
        }

        //code untuk kalo form update position di close
        void formUpdateCategory_Closed(object sender, EventArgs e)
        {
            refreshData();
        }
    }
}
