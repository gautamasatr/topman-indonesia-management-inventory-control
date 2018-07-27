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
    public partial class UCArticle : UserControl
    {
        //variabel untuk sql
        private string sql;
        private SqlConnection conn;

        //variabel untuk delete data
        private string selectedId;

        //variabel untuk update data
        public static string uarticle;
        public static string udepartment;
        public static string ucategory;
        public static string udescription;

        //variabel untuk ambil data item berdasarkan filter
        private string department;
        private string category;

        public UCArticle()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetArticleData(department, category);
            GetDepartment();
            GetCategory();

            if (FormLogin.plevel == 0 || FormLogin.plevel == 1 || FormLogin.plevel == 2)
            {
                btnAddNewArticle.Hide();
                btnEdit.Hide();
            } 
        }

        public void refreshData()
        {
            cmbDepartment.Text = "";
            cmbCategory.Text = "";
            GetArticleData(department, category);
        }

        void GetArticleData(string dpt, string ctg)
        {
            sql = "SELECT a.article as Article, d.name as Department, c.description as Category, a.description as Description "
                + "FROM ((article a "
                + "INNER JOIN department d ON a.id_department = d.id) "
                + "INNER JOIN category c ON a.id_category = c.id) ";

            if (!string.IsNullOrEmpty(cmbDepartment.Text) && !string.IsNullOrEmpty(cmbCategory.Text))
                sql = sql + "WHERE d.name = '" + dpt + "' AND c.description = '" + ctg + "' ";
            else if (!string.IsNullOrEmpty(cmbDepartment.Text) && string.IsNullOrEmpty(cmbCategory.Text))
                sql = sql + "WHERE d.name = '" + dpt + "' ";
            else if (string.IsNullOrEmpty(cmbDepartment.Text) && !string.IsNullOrEmpty(cmbCategory.Text))
                sql = sql + "WHERE c.description = '" + ctg + "' ";

            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvArticle.AutoGenerateColumns = true;
            dgvArticle.ReadOnly = true;
            dgvArticle.DataSource = DS.Tables[0];
            dgvArticle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            conn.Close();
        }

        //code untuk ambil data department
        void GetDepartment()
        {
            cmbDepartment.Items.Add("");
            sql = "SELECT name FROM department ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbDepartment.Items.Add(dr["name"]);
            }
            conn.Close();
        }

        //code untuk ambil data department
        void GetCategory()
        {
            cmbCategory.Items.Add("");
            sql = "SELECT description FROM category ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbCategory.Items.Add(dr["description"]);
            }
            conn.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDepartment.Text) && !string.IsNullOrEmpty(cmbCategory.Text))
            {
                department = cmbDepartment.Text;
                category = cmbCategory.Text;
            }
            else if (!string.IsNullOrEmpty(cmbDepartment.Text) && string.IsNullOrEmpty(cmbCategory.Text))
            {
                department = cmbDepartment.Text;
            }
            else if (string.IsNullOrEmpty(cmbDepartment.Text) && !string.IsNullOrEmpty(cmbCategory.Text))
            {
                category = cmbCategory.Text;
            }
            GetArticleData(department, category);
        }

        private void btnAddNewArticle_Click(object sender, EventArgs e)
        {
            FormAddArticle formAddArticle = new FormAddArticle();
            formAddArticle.FormClosed += formAddArticle_Closed;
            formAddArticle.ShowDialog();
        }

        void formAddArticle_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvArticle.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select article", "Warning", MessageBoxButtons.OK);

            }
            else
            {

                foreach (DataGridViewRow row in dgvArticle.SelectedRows)
                {
                    uarticle = row.Cells[0].Value.ToString();
                    udepartment = row.Cells[1].Value.ToString();
                    ucategory = row.Cells[2].Value.ToString();
                    udescription = row.Cells[3].Value.ToString();

                    FormUpdateArticle formUpdateArticle = new FormUpdateArticle();
                    formUpdateArticle.FormClosed += formUpdateArticle_Closed;
                    formUpdateArticle.ShowDialog();
                }
            }
        }

        void formUpdateArticle_Closed(object sender, EventArgs e)
        {
            refreshData();
        }



    }
}
