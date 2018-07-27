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
    public partial class UCPriceCategory : UserControl
    {
        private string sql;
        private SqlConnection conn;
        private string selectedId;

        //variabel untuk update data
        public static string uid;
        public static string udescription;
        public static int udiscount;
        public static string ustatus;

        public UCPriceCategory()
        {
            InitializeComponent();

            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            GetPriceCategoryData();

            //code untuk custom format di grid view
            dgvPriceCategory.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPriceCategory_CellFormatting);

            if (FormLogin.plevel == 2)
            {
                btnAddNewPriceCategory.Hide();
                btnEdit.Hide();
            }
        }

        public void refreshData()
        {
            GetPriceCategoryData();
        }

        void GetPriceCategoryData()
        {
            sql = "SELECT id as ID, description as Description, discount as Discount, CAST(status AS INT) as Status FROM price_ctg";
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder SCB = new SqlCommandBuilder(SDA);
            var DS = new DataSet();
            SDA.Fill(DS);
            dgvPriceCategory.AutoGenerateColumns = true;
            dgvPriceCategory.ReadOnly = true;
            dgvPriceCategory.DataSource = DS.Tables[0];
            dgvPriceCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            conn.Close();
        }

        private void btnAddNewPriceCategory_Click(object sender, EventArgs e)
        {
            FormAddPriceCategory formAddPriceCategory = new FormAddPriceCategory();
            formAddPriceCategory.FormClosed += formAddPriceCategory_Closed;
            formAddPriceCategory.ShowDialog();
        }

        //code untuk kalo form update position di close
        void formAddPriceCategory_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPriceCategory.SelectedRows)
            {
                selectedId = row.Cells[0].Value.ToString();
            }

            if (string.IsNullOrEmpty(selectedId) == true)
            {
                MessageBox.Show("Please select price category", "Warning", MessageBoxButtons.OK);

            }
            else
            {
                foreach (DataGridViewRow row in dgvPriceCategory.SelectedRows)
                {
                    uid = row.Cells[0].Value.ToString();
                    udescription = row.Cells[1].Value.ToString();
                    udiscount = Convert.ToInt32(row.Cells[2].Value);
                    ustatus = row.Cells[3].Value.ToString();

                    FormUpdatePriceCategory formUpdatePriceCategory = new FormUpdatePriceCategory();
                    formUpdatePriceCategory.FormClosed += formUpdatePriceCategory_Closed;
                    formUpdatePriceCategory.ShowDialog();
                }
            }
        }

        //code untuk kalo form update position di close
        void formUpdatePriceCategory_Closed(object sender, EventArgs e)
        {
            refreshData();
        }

        //code untuk formatiing data di gridview
        private void dgvPriceCategory_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPriceCategory.Columns[e.ColumnIndex].Name.Equals("Status"))
            {
                if (e.Value != null & e.Value.ToString() == "0")
                    e.Value = "Deactive";
                else if (e.Value != null & e.Value.ToString() == "1")
                    e.Value = "Active";
            }

        }
    }
}
