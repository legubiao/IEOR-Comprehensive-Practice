﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工工综合实验模拟
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            模拟主界面 mainForm = new 模拟主界面();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
            Application.Run();
        }
    }
}
