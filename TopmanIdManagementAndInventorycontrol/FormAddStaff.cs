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
    public partial class FormAddStaff : Form
    {
        //variabel buat sql
        private string sql;
        private SqlConnection conn;
        private string id_position;

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

        public FormAddStaff()
        {
            InitializeComponent();

            //code untuk sql
            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            //code untuk ambil data position
            GetPosition();

            //nentuin format datetime
            dtBirthdate.Format = DateTimePickerFormat.Custom;
            dtBirthdate.CustomFormat = "yyyy-MM-dd";

            //code untuk hide border windows
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
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

        //code untuk ambil data position
        void GetPosition()
        {
            sql = "SELECT position, status FROM position WHERE status <> 0 ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbPosition.Items.Add(dr["position"]);
            }
            conn.Close();
        }

        //code untuk ambil data position yg di pilih
        void GetSelectedPosition()
        {
            sql = "SELECT id, position FROM position WHERE position = '"+cmbPosition.Text.ToString()+"'";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                id_position = dr["id"].ToString();
            }
            conn.Close();
        }

        //code untuk cek duplicate id
        void ValidateId(string checkid)
        {
            sql = "SELECT id FROM staff WHERE id = '" + checkid + "'";
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
        void InsertDataStaff()
        {
            GetSelectedPosition();

            string id = txtId.Text.ToString();
            string id_card = txtIdcard.Text.ToString();
            string name = txtName.Text.ToString();
            name = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
            string address = txtAddress.Text.ToString();
            address = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(address.ToLower());
            string birthplace = txtBirthplace.Text.ToString();
            birthplace = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(birthplace.ToLower());
            string birthdate = dtBirthdate.Text.ToString();
            string register_date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string password = txtPassword.Text.ToString();
            //MessageBox.Show(id_position, "Warning", MessageBoxButtons.OK);

            sql = "INSERT INTO staff "
            + "VALUES ('" + id.ToUpper() + "', '" + id_position + "', '" + id_card.ToUpper() + "', '" + name + "', '" + address + "', '" + birthplace + "', '" + birthdate + "', '" + register_date + "', HASHBYTES('md5','" + password + "'), " + 0 + ")";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }

        //code untuk kalo button cancel di klik
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //code untuk kalo button add di klik
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            var regex = new Regex(@"[^a-zA-Z0-9]");
            ValidateId(txtId.Text.ToString());

            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(cmbPosition.Text) || string.IsNullOrEmpty(txtIdcard.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtBirthplace.Text) || string.IsNullOrEmpty(dtBirthdate.Text))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else if (regex.IsMatch(txtId.Text))
            {
                MessageBox.Show("ID cannot use special characters or space", "Warning", MessageBoxButtons.OK);
            }
            else if(duplicate)
            {
                MessageBox.Show("Id already registered, please choose another id", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                InsertDataStaff();
                MessageBox.Show("New Staff Sucessfully Added", "Warning", MessageBoxButtons.OK);
                this.Close();
            }
            
        }

        //code untuk kalo button close di klik
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
