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
    public partial class FormAddStore : Form
    {
        //variabel buat sql
        private string sql;
        private SqlConnection conn;

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

        public FormAddStore()
        {
            InitializeComponent();

            //code untuk sql
            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            //code untuk hide border windows
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;

            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
        }

        //code untuk cek duplicate id
        void ValidateId(string checkid)
        {
            sql = "SELECT id FROM store WHERE id = '" + checkid + "'";
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
        void InsertDataStore()
        {
            string id = txtId.Text.ToString();
            string name = txtName.Text.ToString();
            string address = txtAddress.Text.ToString();
            address = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(address.ToLower());
            string phone = txtPhone.Text.ToString();
            string fax = txtFax.Text.ToString();
            //MessageBox.Show(id_position, "Warning", MessageBoxButtons.OK);

            sql = "INSERT INTO store "
            + "VALUES ('" + id.ToUpper() + "', '" + name.ToUpper() + "', '" + address + "', '" + phone + "', '" + fax + "', 0 )";
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
            ValidateId(txtId.Text.ToString());

            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtFax.Text))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else if (regex.IsMatch(txtId.Text))
            {
                MessageBox.Show("ID cannot use special characters or space", "Warning", MessageBoxButtons.OK);
            }
            else if (duplicate)
            {
                MessageBox.Show("Id already registered, please choose another id", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                InsertDataStore();
                MessageBox.Show("New Store Sucessfully Added", "Warning", MessageBoxButtons.OK);
                this.Close();
            }
        }
    }
}
