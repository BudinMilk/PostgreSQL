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

namespace PostgreSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 新增 INSERT
        private void Insert_DB()
        {
            /*string connStr = "Server=localhost;Database=testdb;User Id=postgres;Password=abc123456;";
            string SQL = "SELECT * FROM test_table";

            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(SQL, conn);

            // MessageBox.Show(Convert.ToString(command.ExecuteReader()));
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                MessageBox.Show(Convert.ToString(dr[0]));
                MessageBox.Show(Convert.ToString(dr[1]));
                MessageBox.Show(Convert.ToString(dr[2]));
            }
            command.Dispose();
            conn.Close();*/
            /*DataSet ds = new DataSet();
            adapter.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                column columnRecord = new column();
                columnRecord.division_no = ds.Tables[0].Rows[i]["DBの列名"].ToStirng();
                (同様の処理を続け、取り出す)


            columnRecords.Add(columnRecord);*/
        }

        // 修改 UPDATE
        private void Updata_DB()
        {
            //
        }
        // 刪除 DELETE
        private void Delete_DB()
        {
            //
        }

        // 查詢 SELECT
        private void Select_DB()
        {
            string connStr = "Server=localhost;Database=testdb;User Id=postgres;Password=abc123456;";
            string SQL = "SELECT * FROM test_table";

            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(SQL, conn);

            // MessageBox.Show(Convert.ToString(command.ExecuteReader()));
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                MessageBox.Show(Convert.ToString(dr[0]));
                MessageBox.Show(Convert.ToString(dr[1]));
                MessageBox.Show(Convert.ToString(dr[2]));
            }
            command.Dispose();
            conn.Close();
        }        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Select_DB();
        }
    }
}