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
    public partial class FormUpdatePriceCategory : Form
    {
        private string sql;
        private SqlConnection conn;

        public const int WM_NCLBUTTONDOWN = 0xA1; //variabel untuk custom drag window
        public const int HT_CAPTION = 0x2; //variabel untuk custom drag window


        //panggil fungsi di windows untuk drag custom window
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private int selectedStat;

        public FormUpdatePriceCategory()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            this.ControlBox = false; //hide control maximize, minimize, close
            this.FormBorderStyle = FormBorderStyle.None; //hide border of form
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);

            GetStatus();
            lblId.Text = UCPriceCategory.uid;
            txtDescription.Text = UCPriceCategory.udescription;
            nmrDiscount.Value = Convert.ToInt32(UCPriceCategory.udiscount);

            if (UCPriceCategory.ustatus == "0")
                cmbStatus.Text = "Deactive";
            else if (UCPriceCategory.ustatus == "1")
                cmbStatus.Text = "Active";
        }

        void GetStatus()
        {
            cmbStatus.Items.Add("");
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Deactive");
        }

        void GetSelectedStatus()
        {
            if (cmbStatus.Text == "Deactive")
                selectedStat = 0;
            else if (cmbStatus.Text == "Active")
                selectedStat = 1;
        }

        void UpdateDataPriceCategory()
        {
            GetSelectedStatus();

            sql = "UPDATE price_ctg "
                + "SET description = '" + txtDescription.Text.ToString().ToUpper() + "', discount = " + Convert.ToInt32(nmrDiscount.Value) + ", status = " + selectedStat + " "
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
            if (string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(cmbStatus.Text) || string.IsNullOrEmpty(nmrDiscount.Value.ToString()))
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            else
            {
                UpdateDataPriceCategory();
                MessageBox.Show("Price Category Sucessfully Updated", "Warning", MessageBoxButtons.OK);
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
