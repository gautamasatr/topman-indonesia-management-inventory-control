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
    public partial class FormMutation : Form
    {
        //variabel buat sql
        private string sql;
        private SqlConnection conn;

        //variabel untuk update
        private string id_staff;
        private string previous_store;
        private string present_store;
        private string mutation_date;

        //variabel untuk custom drag window
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        //panggil fungsi di windows untuk drag custom window
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormMutation()
        {
            InitializeComponent();

            //code untuk sql
            dbConnection dbConn = new dbConnection();
            dbConn.createConn();
            conn = dbConn.masterConn;

            //code untuk hide border windows
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;

            //code untuk custom auto complete text box ID
            this.txtId.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtId.AutoCompleteSource = AutoCompleteSource.CustomSource;

            GetStore();
        }

        //kode untuk ambil data store untuk di masukan ke combo box
        void GetStore()
        {
            sql = "SELECT id, name FROM store ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                cmbNewStore.Items.Add(dr["name"].ToString());
            }
            conn.Close();
        }

        //kode untuk ambil staff data berdasarkan text box ID
        void GetStaffData(string id_staff2)
        {
            sql = "SELECT s.id, s.name as name, p.position as position, st.name as store "
                + "FROM (((staff s "
                + "LEFT JOIN position p ON s.id_position = p.id) "
                + "LEFT JOIN store_staff ss ON s.id = ss.id_staff) "
                + "LEFT JOIN store st ON ss.id_store = st.id) "
                + "WHERE s.id = '"+id_staff2+"'";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                //MessageBox.Show(dr["name"].ToString(),"warning",MessageBoxButtons.OK);
                lblName.Text = dr["name"].ToString();
                lblPosition.Text = dr["position"].ToString();
                lblCurrentStore.Text = dr["store"].ToString();
                if (string.IsNullOrEmpty(lblCurrentStore.Text))
                    lblCurrentStore.Text = "TOPMAN OFFICE";
            }
            else
            {
                lblName.Text = "Staff ID Not Found";
                lblPosition.Text = "Staff ID Not Found";
                lblCurrentStore.Text = "Staff ID Not Found";
            }
            conn.Close();
        }

        //kode untuk ambil data id untuk suggestion berdasarkan text box id staff
        void GetIdSuggestion(string id_staff)
        {
            AutoCompleteStringCollection suggestion = new AutoCompleteStringCollection();

            sql = "SELECT id, name FROM staff WHERE id LIKE '%" + id_staff + "%' ";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            while (dr.Read())
            {
                suggestion.Add(dr["id"].ToString());
            }
            conn.Close();
            txtId.AutoCompleteCustomSource = suggestion;
        }

        //coding untuk timer user ngetik di text box buat munculin suggestion
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            
        }

        //coding untuk suggestion dan baca data id staff kalo text box id staff berubah value nya
        private void txtId_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();

            if (timer1!=null)
            {
                if (txtId.Text.Length >= 4)
                {
                    GetIdSuggestion(txtId.Text);
                }
                GetStaffData(txtId.Text);
            }
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

        //kode untuk ambil data id previous store
        void GetPreviousStore(string prev_store_name)
        {
            sql = "SELECT id, name FROM store WHERE name = '"+prev_store_name+"'";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                previous_store = dr["id"].ToString();
            }
            conn.Close();
        }

        //kode untuk ambil data id present store
        void GetPresentStore(string pres_store_name)
        {
            sql = "SELECT id, name FROM store WHERE name = '" + pres_store_name + "'";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                present_store = dr["id"].ToString();
            }
            conn.Close();
        }

        void mutate_staff()
        {
            sql = "INSERT INTO mutation_history (id_staff, previous_store, present_store, mutation_date) "
            + "VALUES ('" + id_staff + "', '" + previous_store + "', '" + present_store + "', '" + mutation_date + "' )";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        void update_store_staff()
        {
            bool store_staff_exist;

            sql = "SELECT id_staff FROM store_staff WHERE id_staff = '" + id_staff + "'";
            conn.Open();
            SqlCommand cmdSql = new SqlCommand(sql, conn);
            SqlDataReader dr = cmdSql.ExecuteReader();
            if (dr.Read())
            {
                store_staff_exist = true;
            }
            else
            {
                store_staff_exist = false;
            }
            conn.Close();

            if (store_staff_exist)
            {
                sql = "UPDATE store_staff "
                + "SET id_store = '" + present_store + "', date_active = '" + mutation_date + "' "
                + "WHERE id_staff = '" + id_staff + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                sql = "INSERT INTO store_staff (id_staff, id_store, date_active, status) "
                    + "VALUES ('" + id_staff + "', '" + present_store + "', '" + mutation_date + "', 0 )";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            id_staff = txtId.Text.ToString();
            GetPreviousStore(lblCurrentStore.Text);
            GetPresentStore(cmbNewStore.Text);
            mutation_date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            if (string.IsNullOrEmpty(previous_store))
                previous_store = "TM00";

            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(cmbNewStore.Text))
            {
                MessageBox.Show("All field must be filled", "Warning", MessageBoxButtons.OK);
            }
            else if(lblName.Text == "Staff ID Not Found")
            {
                MessageBox.Show("ID Staff not found", "Warning", MessageBoxButtons.OK);
            }
            else if(present_store == previous_store)
            {
                MessageBox.Show("Move Store cannot be same as Current Store", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Staff with ID: " + txtId.Text + " will be moved From: " + lblCurrentStore.Text + " To: " + cmbNewStore.Text + "", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    mutate_staff();
                    update_store_staff();
                    MessageBox.Show("Staff successfully moved", "Warning", MessageBoxButtons.OK);
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        
    }
}
