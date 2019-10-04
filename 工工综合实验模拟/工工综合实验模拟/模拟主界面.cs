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

        public double RandExp(double const_a)//此处的const_a是指数分布的那个参数λ

        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            double temp;
            if (const_a != 0)
                temp = 1 / const_a;
            else
                throw new System.InvalidOperationException("除数不能为零！不能产生参数为零的指数分布！");

            double randres;
            double p;
            while (true) //用于产生随机的密度，保证比参数λ小             
            {
                p = rand.NextDouble();
                if (p < const_a)
                    break;
            }
            randres = -temp * Math.Log(temp * p, Math.E);
            return randres;
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
