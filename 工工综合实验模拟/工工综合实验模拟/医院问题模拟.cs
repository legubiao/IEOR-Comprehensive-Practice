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
    public partial class 医院问题模拟 : Form
    {
        public readonly 模拟主界面 returnForm = null;
        public 医院问题模拟(模拟主界面 mainForm)
        {
            this.returnForm = mainForm;
            InitializeComponent();

        }

        double[] patientIn = new double[] { 2.8, 2.2, 3.4, 2.5 };
        double[,] patient2Hos = new double[,]
        {
                {2.2, 2,   2.4, 1,   1.5} ,
                {2.8, 2.5, 1.8, 2.3, 3.1},
                {2,   2.2, 2.8, 3,   2.3},
                {2.5, 2.6, 2,   2.5, 2.1}
        };
        double[,] hosInfo = new double[,]
        {//自行到达病人速率，单台病床服务速率，最大床位数，初始床位数
                {3.4, 0.42, 40, 13},
                {3.6, 0.5,  40, 15},
                {3.7, 0.46, 40, 20},
                {3.7, 0.55, 40, 20},
                {4,   0.55, 40, 20},
                {3.6, 0.4,  40, 18}
        };

        private void Button1_Click(object sender, EventArgs e)
        {
            returnForm.RandExp(patientIn[0]);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.returnForm.Visible = true;
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
