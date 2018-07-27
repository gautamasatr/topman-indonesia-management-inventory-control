using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TopmanIdManagementAndInventorycontrol
{
    public partial class FormAddArticle : Form
    {
        //variabel buat sql
        private string sql;
        private SqlConnection conn;
        private string id_department;
        private string id_category;

        //variabel buat cek id duplicate
        private bool duplicate;

        //variabel untuk custom drag window
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        //panggil fungsi di windows untuk drag custom window
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormAddArticle()
        {
            InitializeComponent();

            //code untuk sql
            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            //code untuk ambil data combo box
            GetDepartment();
            GetCategory();

            //code untuk hide border windows
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;

            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
        }

        //code untuk ambil data department
        void GetDepartment()
        {
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

        //code untuk ambil data category
        void GetCategory()
        {
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

        //code untuk ambil data id department yg di pilih
        void GetSelectedDepartment()
        {
            sql = "SELECT id, name FROM department WHERE name = '" + cmbDepartment.Text.ToString() + "'";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                id_department = dr["id"].ToString();
            }
            conn.Close();
        }

        //code untuk ambil data id category yg di pilih
        void GetSelectedCategory()
        {
            sql = "SELECT id, description FROM category WHERE description = '" + cmbCategory.Text.ToString() + "'";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                id_category = dr["id"].ToString();
            }
            conn.Close();
        }

        //code untuk cek duplicate id
        void ValidateId(string checkarticle)
        {
            sql = "SELECT article FROM article WHERE article = '" + checkarticle + "' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                duplicate = true;
            }
            else
            {
                duplicate = false;
            }
            conn.Close();
        }

        //code untuk insert data staff baru
        void InsertDataArticle()
        {
            GetSelectedDepartment();
            GetSelectedCategory();

            string article = txtArticle.Text.ToString();
            string description = txtDescription.Text.ToString();

            //MessageBox.Show(article+" "+id_department+" "+id_category+" "+description,"warning",MessageBoxButtons.OK);

            sql = "INSERT INTO article "
            + "VALUES ('" + article.ToUpper() + "', '" + id_department.ToUpper() + "', '" + id_category.ToUpper() + "', '" + description.ToUpper() + "') ";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //code untuk window bisa di drag
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9]");
            ValidateId(txtArticle.Text.ToString());

            if (string.IsNullOrEmpty(txtArticle.Text) || string.IsNullOrEmpty(cmbDepartment.Text) || string.IsNullOrEmpty(cmbCategory.Text) || string.IsNullOrEmpty(txtDescription.Text))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else if (regex.IsMatch(txtArticle.Text))
            {
                MessageBox.Show("Article cannot use special characters or space", "Warning", MessageBoxButtons.OK);
            }
            else if (duplicate)
            {
                MessageBox.Show("Article already registered, please choose another", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                InsertDataArticle();
                MessageBox.Show("New Article Sucessfully Added", "Warning", MessageBoxButtons.OK);
                this.Close();
            }
        }


    }
}
