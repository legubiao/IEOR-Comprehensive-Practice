using System;
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
            Main_Form mainForm = new Main_Form();
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.Show();
            Application.Run();
        }
    }
}
