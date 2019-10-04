using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工工综合实验模拟
{
    public partial class 模拟主界面 : Form
    {
        public 模拟主界面()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            医院问题模拟 hospital = new 医院问题模拟(this)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            this.Hide();
            hospital.Show();
        }
    }

}
