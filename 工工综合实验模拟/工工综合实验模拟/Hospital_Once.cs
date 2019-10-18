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
    public partial class Hospital_Once : Form
    {
        public Hospital_Main returnForm = null;
        public Hospital_Once(Hospital_Main hospital_Main,double[] avg_StayTime,double[] max_StayTime,
            double[]avg_line_self,double[] avg_line_car, double[]avg_line_total,
            double[]max_line_self,double[] max_line_car, double[]max_line_total)
        {
            InitializeComponent();
            this.returnForm = hospital_Main;

            for (int i =0; i != 5; i++)
            {
                this.Controls.Find("Hos" + (i + 1) + "_AvgTime", true)[0].Text = avg_StayTime[i].ToString("f3");
                this.Controls.Find("Avg_Selfline" + (i + 1), true)[0].Text = avg_line_self[i].ToString("f3");
                this.Controls.Find("Avg_Carline" + (i + 1), true)[0].Text = avg_line_car[i].ToString("f3");
                this.Controls.Find("Avg_Total" + (i + 1), true)[0].Text = avg_line_total[i].ToString("f3");

                this.Controls.Find("Hos" + (i + 1)+"_MaxTime", true)[0].Text = max_StayTime[i].ToString("f3");
                this.Controls.Find("Max_Selfline" + (i + 1), true)[0].Text = max_line_self[i].ToString("f3");
                this.Controls.Find("Max_Carline" + (i + 1), true)[0].Text = max_line_car[i].ToString("f3");
                this.Controls.Find("Max_Total" + (i + 1), true)[0].Text = max_line_total[i].ToString("f3");

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.returnForm.Visible = true;
            this.Close();
        }
    }
}
