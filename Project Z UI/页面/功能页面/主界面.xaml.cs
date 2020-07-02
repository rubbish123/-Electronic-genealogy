using Project_Z_UI.UserModel;
using Project_Z_UI.ViewModel;
using Project_Z_UI.类;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Project_Z_UI.页面
{

    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(); //用户名数据绑定
            first.Visibility = Visibility.Hidden;
            two.Visibility = Visibility.Hidden;

        }
        public void ConnectionSQLServerFunc()
        {
            //连接数据库字符串
            string strConn = "Data Source=(local);Initial Catalog=族谱数据库;User ID=sa;Password=123456";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    //连接数据库
                    conn.Open();
                    //查询数据库语句
                    string commandStr = "select * from TM_EMPLOYEE";
                    //要对数据源执行的 SQL 语句或存储过程
                    SqlCommand sqlCmd = new SqlCommand(commandStr, conn);
                    //表示一组数据命令和一个数据库连接，它们用于填充 System.Data.DataSet 和更新数据源。
                    SqlDataAdapter sqlDataAda = new SqlDataAdapter(sqlCmd);
                    //数据的内存中缓存
                    DataSet daSet = new DataSet();
                    //将获取到的数据填充到数据缓存中
                    sqlDataAda.Fill(daSet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            MessageBox.Show("Executing Finished");
        }
        protected override void OnSourceInitialized(EventArgs e)//去除左上图标
        {
            IconHelper.RemoveIcon(this);
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            first.Visibility = Visibility.Hidden;
            two.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            two.Visibility = Visibility.Hidden;
            first.Visibility = Visibility.Visible;            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        
        private void clickToAddPage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            功能页面.Window1 addUserPage = new 功能页面.Window1();
            addUserPage.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SqlConnection con=new SqlConnection("Data Source=(local);Database=族谱数据库;Uid=sa;Pwd=123456;");/* 将输入的数据存入数据库中*/
            con.Open();
            string sqlstr = "insert into 族谱信息表 (族谱名称,族谱编号,族谱简介,族谱代数) values(@族谱名称,@族谱编号,@族谱简介,@族谱代数)";
            SqlCommand mycom = new SqlCommand(sqlstr, con);
            mycom.Parameters.Add(new SqlParameter("@族谱名称", SqlDbType.VarChar));
            mycom.Parameters.Add(new SqlParameter("@族谱编号", SqlDbType.VarChar));
            mycom.Parameters.Add(new SqlParameter("@族谱简介", SqlDbType.VarChar));
            mycom.Parameters.Add(new SqlParameter("@族谱代数", SqlDbType.VarChar));
            mycom.Parameters["@族谱名称"].Value = f1.Text;
            mycom.Parameters["@族谱编号"].Value = f2.Text;
            mycom.Parameters["@族谱简介"].Value = f4.Text;
            mycom.Parameters["@族谱代数"].Value = f3.Text;
            mycom.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("族谱建立成功");
            first.Visibility = Visibility.Hidden;
            f1.Text = "";
            f2.Text = "";
            f3.Text = "";
            f4.Text = "";      
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
           
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            first.Visibility = Visibility.Hidden;
            f1.Text = "";
            f2.Text = "";
            f3.Text = "";
            f4.Text = ""; 
        }

        private void TextBox_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            /* 从数据库中读取所存储的内容*/
            SqlConnection dt = new SqlConnection("Data Source=(local);Database=族谱数据库;Uid=sa;Pwd=123456;");
            string message = "";
            dt.Open();
            SqlCommand com = new SqlCommand("select * from 族谱信息表 where 族谱编号 = '" + k1.Text + "'", dt);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                message = message + "族谱名称：" + read[0].ToString() + "\r\n" + "族谱编号:" + read[1].ToString() + "\r\n" + "族谱编号:" + read[3].ToString() + "\r\n" + "族谱编号:" + read[2].ToString() + "\r\n";
            }

            k2.Text = message;
            read.Close();
            com.ExecuteNonQuery();
            dt.Close();
            dt.Open();



            /*  将数据从数据库中删除*/
            string sql = "delete from 族谱信息表 where 族谱编号 ='" + k1.Text + "'";
            SqlCommand mycom = new SqlCommand(sql, dt);
            mycom.ExecuteNonQuery();
            MessageBox.Show("删除成功");
            dt.Close();
            two.Visibility = Visibility.Hidden;
            k1.Text = "";
            k2.Text = "";
        }


    }
}
