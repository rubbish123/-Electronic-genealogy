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

using System.Data;
using System.Data.SqlClient;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           // getData();
        }

        SqlDataAdapter sda;
        DataTable dt;

        void getData()
        {
            //init sqlconnection
            SqlConnectionStringBuilder connbuilder = new SqlConnectionStringBuilder();
            connbuilder.DataSource = "(local)";
            connbuilder.IntegratedSecurity = true;
            connbuilder.InitialCatalog = "族谱信息数据库";

            //start to make sql query
            SqlConnection conn = new SqlConnection(connbuilder.ConnectionString);
            sda = new SqlDataAdapter("select 族谱名称,族谱编号,族谱简介,族谱代数 from 族谱信息表 where 族谱编号<=100;", conn);
            SqlCommandBuilder commbuilder = new SqlCommandBuilder(sda);
            sda.UpdateCommand = commbuilder.GetUpdateCommand();
            dt = new DataTable();
            sda.AcceptChangesDuringUpdate = true;
            sda.Fill(dt);
            listView1.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sda.Update(dt);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            getData();
        }
    }
}
