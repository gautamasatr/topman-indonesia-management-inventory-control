using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TopmanIdManagementAndInventorycontrol
{
    class dbConnection
    {
        public string connStr;
        public SqlConnection masterConn;

        public void createConn()
        {
            connStr = "DATA SOURCE='E6410-PC\\SQLEXPRESS';" + //server name sql server
                "INITIAL CATALOG='db_topmanid';" + //nama database
                "INTEGRATED SECURITY=TRUE;" +
                "USER ID='';" + //username sql server
                "PASSWORD=''"; //password sql server
            masterConn = new SqlConnection(connStr);
            masterConn.Open();

            if (masterConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Database Connection Failure");
                masterConn.Close();
            }
            masterConn.Close();
        }
    }
}
