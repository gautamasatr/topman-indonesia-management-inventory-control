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
    public partial class FormUpdateStaff : Form
    {
        private string sql;
        private SqlConnection conn;
        private string selectedPos;
        private int selectedStat;

        public const int WM_NCLBUTTONDOWN = 0xA1; //variabel untuk custom drag window
        public const int HT_CAPTION = 0x2; //variabel untuk custom drag window


        //panggil fungsi di windows untuk drag custom window
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormUpdateStaff()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;
            GetPosition();
            GetStatus();

            this.ControlBox = false; //hide control maximize, minimize, close
            this.FormBorderStyle = FormBorderStyle.None; //hide border of form
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);

            lblId.Text =  UCStaffData.uid;
            cmbPosition.Text = UCStaffData.uposition;
            txtIdcard.Text = UCStaffData.uid_card;
            txtName.Text = UCStaffData.uname;
            txtAddress.Text = UCStaffData.uaddress;
            txtBirthplace.Text = UCStaffData.ubirthplace;
            dtBirthdate.Text = UCStaffData.ubirthdate;

            if (UCStaffData.ustatus == "0")
                cmbStatus.Text = "Deactive";
            else if (UCStaffData.ustatus == "1")
                cmbStatus.Text = "Active";
            else if (UCStaffData.ustatus == "2")
                cmbStatus.Text = "Leave";

            
        }

        void GetPosition()
        {
            sql = "SELECT id, position, status FROM position WHERE status <> 0 ";

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

        void GetSelectedPosition()
        {
            sql = "SELECT id, position FROM position WHERE position = '"+cmbPosition.Text.ToString()+"' ";

            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                selectedPos = dr["id"].ToString();
            }
            conn.Close();
        }

        void GetSelectedStatus()
        {
            if (cmbStatus.Text == "Deactive")
                selectedStat = 0;
            else if (cmbStatus.Text == "Active")
                selectedStat = 1;
            else if (cmbStatus.Text == "Leave")
                selectedStat = 2;
        }

        void GetStatus()
        {
            cmbStatus.Items.Add("");
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Deactive");
            cmbStatus.Items.Add("Leave");
        }

        void UpdateDataStaff()
        {
            GetSelectedPosition();
            GetSelectedStatus();

            string name = txtName.Text.ToString();
            name = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
            string address = txtAddress.Text.ToString();
            address = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(address.ToLower());
            string birthplace = txtBirthplace.Text.ToString();
            birthplace = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(birthplace.ToLower());

            sql = "UPDATE staff "
                + "SET name = '" + name + "', id_card = '" + txtIdcard.Text.ToString().ToUpper() + "', address = '" + address + "', birthplace = '" + birthplace + "', birthdate = '" + dtBirthdate.Text.ToString() + "', id_position = '" + selectedPos + "', status = " + selectedStat + " "
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
            if (string.IsNullOrEmpty(cmbPosition.Text) || string.IsNullOrEmpty(txtIdcard.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtBirthplace.Text) || string.IsNullOrEmpty(dtBirthdate.Text))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else
            {
                UpdateDataStaff();
                MessageBox.Show("Staff Sucessfully Updated", "Warning", MessageBoxButtons.OK);
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
