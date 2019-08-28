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

            /*
              TSCLIB_DLL.openport("TSC TTP-343 Plus");
              TSCLIB_DLL.setup("100", "100", "3", "10", "0", "0", "0");
              TSCLIB_DLL.clearbuffer();
              TSCLIB_DLL.printerfont("10", "10", "4", "0", "1", "1", "TEST PRINTOUT");
              TSCLIB_DLL.barcode("10", "80", "39", "96", "1", "0", "2", "4", "0987654321");
              TSCLIB_DLL.sendcommand("BAR 400,200,300,100");
              TSCLIB_DLL.sendcommand("BOX 10,300,300,300,5");
              TSCLIB_DLL.windowsfont(10, 10, 80, 0, 2, 0, "arial", "Arial font 80 pt");
              TSCLIB_DLL.printlabel("1", "1");
              TSCLIB_DLL.closeport();
             */
        }

        // 新增 INSERT
        private void Insert_DB()
        {
            string connStr = "Server=localhost;Database=testdb;User Id=postgres;Password=abc123456;";
            string SQL = "INSERT INTO test_table(name, address) VALUES('Steve', 'US');";

            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
            //command.Parameters.Add(new NpgsqlParameter("", ""));
            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }

        // 修改 UPDATE
        private void Updata_DB()
        {
            string connStr = "Server=localhost;Database=testdb;User Id=postgres;Password=abc123456;";
            string SQL = "UPDATE test_table SET name = 'Bill', address = 'CA' WHERE ID = 8;";

            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
        }

        // 刪除 DELETE
        private void Delete_DB()
        {
            string connStr = "Server=localhost;Database=testdb;User Id=postgres;Password=abc123456;";
            string SQL = "DELETE FROM test_table WHERE ID = 8;";

            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand(SQL, conn);
            command.ExecuteNonQuery();

            command.Dispose();
            conn.Close();
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
            Insert_DB();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Updata_DB();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Delete_DB();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Select_DB();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Page1 page1 = new Page1();
            Page2 page2 = new Page2();

            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;

            switch (tabItem)
            {
                case "HOME":
                    page2 = null;
                    mainFrame.NavigationService.Navigate(page1);
                    break;

                case "DESIGN":
                    page1 = null;
                    mainFrame.NavigationService.Navigate(page2);
                    break;

                case "HELP":
                    break;

                default:
                    return;
            }
        }
    }
}