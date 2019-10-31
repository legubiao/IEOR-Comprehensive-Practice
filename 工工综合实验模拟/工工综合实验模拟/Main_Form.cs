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
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Hospital_Main hospital = new Hospital_Main(this)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            this.Hide();
            hospital.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Production_Main production = new Production_Main(this)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            this.Hide();
            production.Show();
        }
    }

}
