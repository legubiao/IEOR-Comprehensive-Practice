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
        public Hospital_Once(Hospital_Main hospital_Main,double[] avg_StayTime,double[]avg_line_self,double[] avg_line_car)
        {
            InitializeComponent();
            this.returnForm = hospital_Main;

            Hos1_AvgTime.Text = avg_StayTime[0].ToString("f3");
            Hos2_AvgTime.Text = avg_StayTime[1].ToString("f3");
            Hos3_AvgTime.Text = avg_StayTime[2].ToString("f3");
            Hos4_AvgTime.Text = avg_StayTime[3].ToString("f3");
            Hos5_AvgTime.Text = avg_StayTime[4].ToString("f3");

            Selfline1.Text = avg_line_self[0].ToString("f3");
            Selfline2.Text = avg_line_self[1].ToString("f3");
            Selfline3.Text = avg_line_self[2].ToString("f3");
            Selfline4.Text = avg_line_self[3].ToString("f3");
            Selfline5.Text = avg_line_self[4].ToString("f3");

            CarLine1.Text = avg_line_car[0].ToString("f3");
            CarLine2.Text = avg_line_car[1].ToString("f3");
            CarLine3.Text = avg_line_car[2].ToString("f3");
            CarLine4.Text = avg_line_car[3].ToString("f3");
            CarLine5.Text = avg_line_car[4].ToString("f3");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.returnForm.Visible = true;
            this.Close();
        }
    }
}
