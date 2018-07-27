using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TopmanIdManagementAndInventorycontrol
{
    public partial class FormLogin : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1; //variabel untuk custom drag window
        public const int HT_CAPTION = 0x2; //variabel untuk custom drag window
        public static string name;
        public static int plevel;

        private string sql;
        private SqlConnection conn;

        //panggil fungsi di windows untuk drag custom window
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormLogin()
        {
            InitializeComponent();
            dbConnection db = new dbConnection();
            db.createConn();
            conn = db.masterConn;
            style();
            this.ActiveControl = txtUsername;
        }

        //coding untuk style
        void style()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //gabisa di resize
            this.MaximizeBox = false; //gabisa di maximize
            this.Text = "TOPMAN INDONESIA MANAGEMENT & INVENTORY CONTROL"; //set title form
            this.ControlBox = false; //hide control maximize, minimize, close
            this.FormBorderStyle = FormBorderStyle.None; //hide border of form
            ttClose.SetToolTip(btnClose, "Close"); //untuk show tooltip kalo button close di hover
        }

        //coding untuk validasi username & password
        void validateUser()
        {
            string username;
            string password;

            username = txtUsername.Text;
            password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("All fields cannot be left blank",
                    "Konfirmasi", MessageBoxButtons.OK);
            }
            else
            {
                getLevel();

                sql = "SELECT id, name "
                    + " FROM staff "
                    + " WHERE id = '" + username + "' "
                    + " AND password = HASHBYTES('md5','" + password + "') ";

                conn.Open();
                SqlCommand cmdSql = new SqlCommand(sql, conn);
                SqlDataReader dr = cmdSql.ExecuteReader();

                if (dr.Read())
                {
                    name = dr["name"].ToString();
                    MessageBox.Show("Login Success", "Warning", MessageBoxButtons.OK);
                    //MessageBox.Show(plevel.ToString(), "Warning", MessageBoxButtons.OK);
                    FormMain frmUtama = new FormMain();
                    frmUtama.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or password wrong","Warning", MessageBoxButtons.OK);
                }
                conn.Close();

            }
        }

        //coding untuk mendapatkan permission level
        void getLevel()
        {
            sql = "SELECT permission_level FROM position INNER JOIN staff ON position.id = staff.id_position WHERE staff.id = '" + txtUsername.Text.ToString() + "'";

            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                plevel = Convert.ToInt16(dr["permission_level"].ToString());
            }
            conn.Close();

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

        private void btnProfile_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Want to Close this application?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            validateUser();
        }
    }
}
