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
    public partial class FormUpdateArticle : Form
    {
        private string sql;
        private SqlConnection conn;
        private string selectedDpt;
        private string selectedCtg;

        public const int WM_NCLBUTTONDOWN = 0xA1; //variabel untuk custom drag window
        public const int HT_CAPTION = 0x2; //variabel untuk custom drag window


        //panggil fungsi di windows untuk drag custom window
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormUpdateArticle()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;
            GetDepartment();
            GetCategory();

            this.ControlBox = false; //hide control maximize, minimize, close
            this.FormBorderStyle = FormBorderStyle.None; //hide border of form
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);

            lblArticle.Text = UCArticle.uarticle;
            cmbDepartment.Text = UCArticle.udepartment;
            cmbCategory.Text = UCArticle.ucategory;
            txtDescription.Text = UCArticle.udescription;
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
                selectedDpt = dr["id"].ToString();
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
                selectedCtg = dr["id"].ToString();
            }
            conn.Close();
        }

        void UpdateDataArticle()
        {
            GetSelectedDepartment();
            GetSelectedCategory();

            sql = "UPDATE article "
                + "SET id_department = '" + selectedDpt + "', id_category = '" + selectedCtg + "', description = '" + txtDescription.Text.ToString().ToUpper() + "' "
                + "WHERE article = '" + lblArticle.Text.ToString() + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9]");
            if (string.IsNullOrEmpty(cmbDepartment.Text) || string.IsNullOrEmpty(cmbCategory.Text) || string.IsNullOrEmpty(txtDescription.Text))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else
            {
                UpdateDataArticle();
                MessageBox.Show("Article Sucessfully Updated", "Warning", MessageBoxButtons.OK);
                this.Close();
            }
        }

        //coding untuk membuat panel atas bisa drag form kalo di klik tahan
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

    }
}
