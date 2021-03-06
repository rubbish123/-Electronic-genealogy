﻿using Project_Z_UI.ViewModel;
using Project_Z_UI.类;
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
using System.Windows.Shapes;

namespace Project_Z_UI.页面.功能页面
{
    /// <summary>
    /// 人员管理.xaml 的交互逻辑
    /// </summary>
    public partial class 人员管理 : Window
    {
        public 人员管理()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();//用户名数据绑定
        }
        protected override void OnSourceInitialized(EventArgs e)//去除左上图标
        {
            IconHelper.RemoveIcon(this);
        }
    }
}
