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
    public partial class Production_Main : Form
    {
        public Main_Form returnForm = null;
        public Production_Main(Main_Form main_Form)
        {
            InitializeComponent();
            this.returnForm = main_Form;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Number = "0123456789";
            string Douhao = ",";
            string InputText = InputTextBox.Text.ToString();

            if ((Keys)(e.KeyChar) == Keys.Back || (Keys)(e.KeyChar) == Keys.Delete) //删除键正常
            {
                return;
            }
            if ((e.KeyChar == 3) || (e.KeyChar == 24) || (e.KeyChar == 26))         //组合键正常
            {
                return;
            }

            if (InputTextBox.TextLength == 0)
            {
                if (Number.IndexOf(e.KeyChar.ToString()) == -1)                    //不在列表内的字符不能输入
                {
                    e.Handled = true;
                }
            }
            else 
            {
                string endInput = InputText.Substring(InputText.Length - 1, 1);
                if (Douhao.IndexOf(endInput) != -1)
                {
                    if (Number.IndexOf(e.KeyChar.ToString()) == -1)
                    {
                        e.Handled = true;
                    }
                }
                else if (Number.IndexOf(endInput) != -1)
                {
                    if (Douhao.IndexOf(e.KeyChar.ToString()) == -1)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.returnForm.Visible = true;
            this.Close();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string[] InputString = InputTextBox.Text.Split(',');
            //整形数组
            int[] Sequence = new int[InputString.Length];
            for (int i = 0; i < InputString.Length; i++)
            {
                Sequence[i] = int.Parse(InputString[i]);
            }
        }
    }
}
