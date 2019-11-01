using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

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
            else if(comboBox2.Text == "7个工件")
            {//对应7个工件的简单问题
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
            else
            { //对应15个工件的复杂问题
                string endInput = InputText.Substring(InputText.Length - 1, 1);
                string secondEndInput = "0";
                if (InputTextBox.TextLength > 1) 
                {
                    secondEndInput = InputText.Substring(InputText.Length - 2, 1);
                }
                if (Douhao.IndexOf(endInput) != -1)
                {
                    if (Number.IndexOf(e.KeyChar.ToString()) == -1)
                    {
                        e.Handled = true;
                    }
                }
                else if (Number.IndexOf(endInput) != -1 && Number.IndexOf(secondEndInput) != -1)
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

    class Part
    {
        public double arriveTime;
        public int hospital;
        public Part(double ArriveTime)
        {
            arriveTime = ArriveTime;
            hospital = 0;
        }
    }

    enum MachineStatus
    {//定义机床的两种状态
        SERVICE,    //服务中
        IDLE,       //空闲
        Changing    //换模中
    }
    class Machine
    {
        private Part part;
        private MachineStatus status;
        private int Machine_No;                                //机器编号
        public Machine()
        { //构造函数，初始时设置机器为空闲
            status = MachineStatus.IDLE;
        }
        public void setBusy()//窗口设置为繁忙
        {
            status = MachineStatus.SERVICE;
        }
        public void setIdle()//窗口设置为空闲
        {
            status = MachineStatus.IDLE;
        }
        public void servePatient(Part part)
        {
            this.part = part;
        }
        public bool isIdle()
        {
            return (status == MachineStatus.IDLE);
        }
        public double getArriveTime()
        {
            return (part.arriveTime);
        }
    }
    struct P_Event
    {
        public double occur_time;       //事件发生的时间
        public int EventType;           //描述事件的类型
        public P_Event(double time, int type)
        {
            occur_time = time;
            EventType = type;
        }
    }
    class ProductionSystem
    {
        void addEvent(ArrayList list, H_Event @event)
        {
            if (@event.occur_time > ((H_Event)list[list.Count - 1]).occur_time)
            {
                list.Add(@event);
            }
            else
            {
                for (int i = 0; i != list.Count; i++)
                {
                    if (((H_Event)list[i]).occur_time > @event.occur_time)
                    {
                        list.Insert(i, @event);
                        break;
                    }
                }
            }
        }
    }
}
