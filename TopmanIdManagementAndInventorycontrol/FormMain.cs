using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TopmanIdManagementAndInventorycontrol
{
    public partial class FormMain : Form
    {
        
        public const int WM_NCLBUTTONDOWN = 0xA1; //variabel untuk custom drag window
        public const int HT_CAPTION = 0x2; //variabel untuk custom drag window

        
        //panggil fungsi di windows untuk drag custom window
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormMain()
        {
            InitializeComponent();
            style(); //panggil method style

            
        }


        //method untuk style
        void style()
        {
            
            lblWelcome.Text = lblWelcome.Text + FormLogin.name;

            this.Text = "TOPMAN INDONESIA MANAGEMENT & INVENTORY CONTROL"; //set title form
            this.ControlBox = false; //hide control maximize, minimize, close
            this.FormBorderStyle = FormBorderStyle.None; //hide border of form 
            this.Size = new Size(900, 600); //set ukuran form

            if (FormLogin.plevel == 0)
            {
                btnStaffMgt.Hide();
                btnStockMgt.Hide();
                btnPriceMgt.Hide();
            }
            else if (FormLogin.plevel == 1)
            {
                btnPriceMgt.Hide();
                btnPosition.Hide();
                btnStockTransfer.Hide();
            }
            else if (FormLogin.plevel == 2)
            {
                btnPosition.Hide();
            }

            ucWelcome1.BringToFront(); //membuat user control welcome berada di paling depan
            pnlStaffMgt.Hide(); //hide sub menu untuk staff management
            pnlProductMgt.Hide(); //hide sub menu untuk product management
            pnlStockMgt.Hide(); //hide sub menu untuk stock management
            pnlPriceMgt.Hide(); //hide sub menu untuk price management
            pnlStoreMgt.Hide(); //hide sub menu untuk store management
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Want to Exit?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }


        private void btnStaffMgt_Click(object sender, EventArgs e)
        {
            if (pnlStaffMgt.Visible)
                pnlStaffMgt.Hide();
            else if (!pnlStaffMgt.Visible)
                pnlStaffMgt.Show();

        }


        private void btnProductMgt_Click(object sender, EventArgs e)
        {
            if (pnlProductMgt.Visible)
                pnlProductMgt.Hide();
            else if (!pnlProductMgt.Visible)
                pnlProductMgt.Show();
        }


        private void btnStockMgt_Click(object sender, EventArgs e)
        {
            if (pnlStockMgt.Visible)
                pnlStockMgt.Hide();
            else if (!pnlStockMgt.Visible)
                pnlStockMgt.Show();
        }


        private void btnPriceMgt_Click(object sender, EventArgs e)
        {
            if (pnlPriceMgt.Visible)
                pnlPriceMgt.Hide();
            else if (!pnlPriceMgt.Visible)
                pnlPriceMgt.Show();
        }


        private void btnStoreMgt_Click(object sender, EventArgs e)
        {
            if (pnlStoreMgt.Visible)
                pnlStoreMgt.Hide();
            else if (!pnlStoreMgt.Visible)
                pnlStoreMgt.Show();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            //UCStaffData ucStaffData = new UCStaffData();
            //ucStaffData.refreshData();
            ucStaffData1.refreshData();
            ucStaffData1.BringToFront();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //UCPosition ucPosition = new UCPosition();
            ucPosition1.refreshData();
            ucPosition1.BringToFront();
        }

        private void btnMutation_Click(object sender, EventArgs e)
        {
            //UCMutation ucMutation = new UCMutation();
            ucMutation1.refreshData();
            ucMutation1.BringToFront();
        }

        private void btnStockList_Click(object sender, EventArgs e)
        {
            //UCStockList ucStockList = new UCStockList();
            ucStockList1.refreshData();
            ucStockList1.BringToFront();
        }

        private void btnStockTransferHistory_Click(object sender, EventArgs e)
        {
            //UCStockTransferHistory ucStockTransferHistory = new UCStockTransferHistory();
            ucStockTransfer1.refreshData();
            ucStockTransfer1.BringToFront();
        }

        private void btnPriceList_Click(object sender, EventArgs e)
        {
            //UCPriceList ucPriceList = new UCPriceList();
            ucPriceList1.refreshData();
            ucPriceList1.BringToFront();
        }

        private void btnPriceCategory_Click(object sender, EventArgs e)
        {
            //UCPriceCategory ucPriceCategory = new UCPriceCategory();
            ucPriceCategory1.refreshData();
            ucPriceCategory1.BringToFront();
        }


        private void btnStoreList_Click(object sender, EventArgs e)
        {
            //UCStoreList ucStoreList = new UCStoreList();
            ucStoreList1.refreshData();
            ucStoreList1.BringToFront();
        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
            //UCSalesHistory usSalesHistory = new UCSalesHistory();
            ucSalesHistory1.refreshData();
            ucSalesHistory1.BringToFront();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure Want to Logout?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnArticle_Click(object sender, EventArgs e)
        {
            ucArticle1.refreshData();
            ucArticle1.BringToFront();
        }

        private void btnArticleSeason_Click(object sender, EventArgs e)
        {
            ucArticleSeason1.refreshData();
            ucArticleSeason1.BringToFront();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            ucItem1.refreshData();
            ucItem1.BringToFront();
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            ucDepartment1.refreshData();
            ucDepartment1.BringToFront();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            ucCategory1.refreshData();
            ucCategory1.BringToFront();
        }

        private void btnSeason_Click(object sender, EventArgs e)
        {
            ucSeason1.refreshData();
            ucSeason1.BringToFront();
        }

        private void btnStockTransferHistory_Click_1(object sender, EventArgs e)
        {
            ucStockTransferHistory1.refreshData();
            ucStockTransferHistory1.BringToFront();
        }

    }
}
