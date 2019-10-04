using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 蒙特卡洛
{

    public partial class 主界面 : Form
    {
        //private int expcount = 0;
        private string S_Type = null;
        private string T_Type = null;


        //威布尔分布相关参数

        //对数正态相关分布
        public 主界面()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Generate_Time = Convert.ToInt32(ExpCount.Text);

            double count = 0;

            Box_Muller box_Muller = new Box_Muller();
            double tension = 0;
            double strength = 0;

            for (int i = 1; i <= Generate_Time; i = i + 1)
            {
                switch (T_Type)
                {
                    case "正态": tension = box_Muller.RandomNormal(Convert.ToDouble(T_N_mean.Text), Convert.ToDouble(T_N_variance.Text)); break;
                    case "指数": tension = RandExp(Convert.ToDouble(T_E_lambda.Text)); break;
                    case "威布尔":tension = Weibrand(Convert.ToDouble(T_W_a.Text), Convert.ToDouble(T_W_b.Text), Convert.ToDouble(T_W_c.Text)); break;
                    case "对数正态": tension = LogNormal(Convert.ToDouble(T_LM_a.Text), Convert.ToDouble(T_LM_b.Text), Convert.ToDouble(T_LM_c.Text)); break;
                }
                switch (S_Type)
                {
                    case "正态": strength = box_Muller.RandomNormal(Convert.ToDouble(S_N_mean.Text), Convert.ToDouble(S_N_variance.Text)); break;
                    case "指数": strength = RandExp(Convert.ToDouble(S_E_lambda.Text)); break;
                    case "威布尔": strength = Weibrand(Convert.ToDouble(S_W_a.Text), Convert.ToDouble(S_W_b.Text), Convert.ToDouble(S_W_c.Text)); break;
                    case "对数正态": strength = LogNormal(Convert.ToDouble(S_LM_a.Text), Convert.ToDouble(S_LM_b.Text), Convert.ToDouble(S_LM_c.Text)); break;
                }
                if (tension < strength)
                {
                    count = count + 1;
                }

            }
            textBox5.Text = Convert.ToString(count / Generate_Time);

        }

        private void T_tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            T_N_mean.Text = "0";
            T_N_variance.Text = "0";

            T_E_lambda.Text = "0";

            this.T_Type = null;
        }

        private void S_tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            S_N_mean.Text = "0";
            S_N_variance.Text = "0";

            S_E_lambda.Text = "0";
            this.S_Type = null;
        }


        private void T_N_variance_ValueChanged(object sender, EventArgs e)
        {
            this.T_Type = "正态";
        }

        private void S_N_variance_ValueChanged(object sender, EventArgs e)
        {
            this.S_Type = "正态";
        }

        private void T_E_lambda_ValueChanged(object sender, EventArgs e)
        {
            this.T_Type = "指数";
        }

        private void S_E_lambda_ValueChanged(object sender, EventArgs e)
        {
            this.S_Type = "指数";
        }

        //指数分布生成函数
        public static double RandExp(double const_a)//此处的const_a是指数分布的那个参数λ

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

        //威布尔分布
        public static double Weibrand(double a, double b, double c)

        {
            double x, y;
            Random rdmNum = new Random(Guid.NewGuid().GetHashCode());
            y = (rdmNum).NextDouble();
            x = (double)(c + Math.Pow(Math.Log(Math.E, 1 / y), 1 / a) * b);
            return x;
        }

        private void T_W_a_ValueChanged(object sender, EventArgs e)
        {
            this.T_Type = "威布尔";
        }

        private void S_W_a_ValueChanged(object sender, EventArgs e)
        {
            this.S_Type = "威布尔";
        }

        public static double LogNormal(double a,double b,double c)
        {
            double x,y;
            Box_Muller box_Muller = new Box_Muller();
            y = box_Muller.RandomNormal(a, b);
            x = Math.Exp(y)+c;
            return x;
        }

        private void T_LM_b_ValueChanged(object sender, EventArgs e)
        {
            this.T_Type = "对数正态";
        }

        private void S_LM_b_ValueChanged(object sender, EventArgs e)
        {
            this.S_Type = "对数正态";
        }
    }

    //正态分布 Box-Muller算法
    public class Box_Muller
    {
        Random rand = new Random(Guid.NewGuid().GetHashCode());

        //生成标准正态分布
        public double Normal()
        {
            double s = 0, u = 0, v = 0;
            while (s > 1 || s == 0)
            {
                u = rand.NextDouble() * 2 - 1;
                v = rand.NextDouble() * 2 - 1;

                s = u * u + v * v;
            }

            var z = Math.Sqrt(-2 * Math.Log(s) / s) * u;
            return (z);
        }

        //生成符合要求的正态分布随机数
        public double RandomNormal(double miu, double sigma)
        {
            var z = Normal() * sigma + miu;
            return (z);
        }
    }

}

