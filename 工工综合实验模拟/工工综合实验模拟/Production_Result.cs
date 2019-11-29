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
    public partial class Production_Result : Form
    {
        public Production_Main returnForm = null;

        DataTable dt;
        public Production_Result(Production_Main production_Main, double[,] leaveTimes,int[] record)
        {
            InitializeComponent();
            this.returnForm = production_Main;

            dt = new DataTable();

            for (int i = 0; i < leaveTimes.GetLength(1); i++)
                dt.Columns.Add("机器" + (i + 1).ToString());
            dt.Columns.Add("机器6选择".ToString());

            int maxPart = 0;
            double maxTime = 0;
            for (int i = 0; i < leaveTimes.GetLength(0); i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < leaveTimes.GetLength(1); j++)
                {
                    dr[j] = Math.Round(leaveTimes[i, j], 2);
                    if (leaveTimes[i, j] > maxTime)
                    {
                        maxTime = Math.Round(leaveTimes[i, j],2);
                        maxPart = i+1;
                    }
                }
                dr[10] = record[i];
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Rows[1].DefaultCellStyle.Format = "N2";

            summary.Text = "最后完工的为工件"+ maxPart.ToString() +   ",  总完工时间为"+maxTime.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.returnForm.Visible = true;
            this.Close();
        }

        private void Production_Result_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            for (int i= 0; i != dt.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = "部件"+(i+1).ToString();               
            }
        }
    }
}
