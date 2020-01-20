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
    public partial class Single_Hospital_Result : Form
    {
        public Single_Hospital_Main returnForm = null;
        DataTable dt;
        public Single_Hospital_Result(Single_Hospital_Main returnForm,int[] total,int[] sl1,int[] sl2, int [] sl3)
        {
            InitializeComponent();
            this.returnForm = returnForm;

            dt = new DataTable();
            dt.Columns.Add("小时");
            for (int i = 1; i < 4; i++)
                dt.Columns.Add("服务水平" + (i + 1).ToString());
            for (int i = 0; i < 24; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i+1;
                dr[1] = ((double)(total[i]-sl1[i]) / total[i]).ToString("0.00000");
                dr[2] = ((double)(total[i]-sl2[i])/ total[i]).ToString("0.00000");
                dr[3] = ((double)(total[i]-sl3[i])/ total[i]).ToString("0.00000");
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.returnForm.Visible = true;
            this.Close();
        }
    }
}
