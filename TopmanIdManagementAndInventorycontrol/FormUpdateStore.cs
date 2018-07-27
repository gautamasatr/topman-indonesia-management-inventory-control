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
    public partial class FormUpdateStore : Form
    {
        private string sql;
        private SqlConnection conn;
        private int selectedStat;

        public const int WM_NCLBUTTONDOWN = 0xA1; //variabel untuk custom drag window
        public const int HT_CAPTION = 0x2; //variabel untuk custom drag window


        //panggil fungsi di windows untuk drag custom window
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormUpdateStore()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;
            GetStatus();

            this.ControlBox = false; //hide control maximize, minimize, close
            this.FormBorderStyle = FormBorderStyle.None; //hide border of form

            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);

            lblId.Text = UCStoreList.uid;
            txtName.Text = UCStoreList.uname;
            txtAddress.Text = UCStoreList.uaddress;
            txtPhone.Text = UCStoreList.uphone;
            txtFax.Text = UCStoreList.ufax;

            if (UCStoreList.ustatus == "0")
                cmbStatus.Text = "Closed";
            else if (UCStoreList.ustatus == "1")
                cmbStatus.Text = "Open";
            else if (UCStoreList.ustatus == "2")
                cmbStatus.Text = "Renovation";
        }

        void GetSelectedStatus()
        {
            if (cmbStatus.Text == "Closed")
                selectedStat = 0;
            else if (cmbStatus.Text == "Open")
                selectedStat = 1;
            else if (cmbStatus.Text == "Renovation")
                selectedStat = 2;
        }

        void GetStatus()
        {
            cmbStatus.Items.Add("");
            cmbStatus.Items.Add("Closed");
            cmbStatus.Items.Add("Open");
            cmbStatus.Items.Add("Renovation");
        }

        void UpdateDataStore()
        {
            GetSelectedStatus();

            String address = txtAddress.Text.ToString();
            address = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(address.ToLower());

            sql = "UPDATE store "
                + "SET name = '" + txtName.Text.ToString().ToUpper() + "', address = '" + txtAddress.Text.ToString() + "', phone = '" + txtPhone.Text.ToString() + "', fax = '" + txtFax.Text.ToString() + "', status = " + selectedStat + " "
                + "WHERE id = '" + lblId.Text.ToString() + "'";
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
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtFax.Text) || string.IsNullOrEmpty(cmbStatus.Text))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else
            {
                UpdateDataStore();
                MessageBox.Show("Store Sucessfully Updated", "Warning", MessageBoxButtons.OK);
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
