using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;
using System.Data;

namespace PostgreSQL
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            getData();
        }

        void fillingDataGrid()
        {
            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("id", typeof(int));
            DataColumn name = new DataColumn("name", typeof(string));
            DataColumn address = new DataColumn("address", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(name);
            dt.Columns.Add(address);

            DataRow firstRow = dt.NewRow();
            // firstRow[i] = Convert.ToString(dr[i]);
        }

        // 查詢 SELECT
        private void Select_DB()
        {
            string connStr = "Server = localhost; Database = testdb; User Id = postgres; Password = abc123456;";
            string SQL = "SELECT * FROM test_table";

            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(SQL, conn);

            // MessageBox.Show(Convert.ToString(command.ExecuteReader()));
            NpgsqlDataReader dr = command.ExecuteReader();

            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("id", typeof(int));
            DataColumn name = new DataColumn("name", typeof(string));
            DataColumn address = new DataColumn("address", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(name);
            dt.Columns.Add(address);

            DataRow firstRow = dt.NewRow();

            while (dr.Read())
            {
                for (int i = 0; i < 3; i++)
                {
                    firstRow[i] = Convert.ToString(dr[i]);
                }
                /*MessageBox.Show(Convert.ToString(dr[0]));
                MessageBox.Show(Convert.ToString(dr[1]));
                MessageBox.Show(Convert.ToString(dr[2]));*/
            }
            dt.Rows.Add(firstRow);
            dataGridView1.ItemsSource = dt.DefaultView;

            command.Dispose();
            conn.Close();
        }

        private void getData()
        {
            DataTable dt = new DataTable();
            // string conn = "Server = localhost; Database = testdb; User Id = postgres; Password = abc123456;";
            // string SQL = "SELECT * FROM test_table";
            NpgsqlConnection conn =
                new NpgsqlConnection("Server=127.0.0.1; Port=5432;" +
                    "User Id=postgres; Password=abc123456;" +
                    "Database=testdb;");
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("select * from test_table", conn);

            try
            {
                NpgsqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                dataGridView1.ItemsSource = dt.DefaultView;
            }

            finally
            {
                conn.Close();
            }
        }
    }
}