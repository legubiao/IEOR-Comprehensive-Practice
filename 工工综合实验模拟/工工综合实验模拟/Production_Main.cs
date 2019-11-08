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
        public int[] Part_Num1 = new int[] {
            3,
            5,
            4,
            2,
            4,
            3,
            4
        };
        public int[] Part_Num2 = new int[]
        {
            5,
            6,
            7,
            5,
            3,
            5,
            2,
            4,
            5,
            4,
            5,
            3,
            5,
            4,
            4
        };
        public int[,] Part_Change1 = new int[,]
        {
            { 0, 300, 100, 100, 400, 400, 1200 },
            { 220, 0, 500, 100, 200, 400, 110 },
            { 600, 1000, 0, 2000, 700, 1000, 500 },
            { 500, 200, 100, 0, 400, 300, 600 },
            { 300, 300, 200, 150, 0, 770, 240 },
            { 900, 150, 210, 290, 260, 0, 260 },
            { 200, 180, 600, 300, 500, 400, 0 }
        };
        public int[,] Part_Change2 = new int[,]
        {
            { 0,   300, 100, 100, 400, 400, 120, 660, 230, 450, 280, 350, 240, 250, 510 },
            { 220, 0,   500, 100, 200, 400, 110, 100, 190, 120, 120, 320, 240, 530, 270 },
            { 600, 100, 0,   200, 700, 1000,500, 350, 380, 270, 560, 370, 450, 490, 430 },
            { 500, 200, 100, 0,   400, 300, 600, 90,  150, 300, 200, 330, 570, 590, 460 },
            { 300, 300, 200, 150, 0,   770, 240, 100, 260, 90,  180, 280, 240, 370, 290 },
            { 900, 150, 210, 290, 260, 0,   260, 170, 150, 300, 220, 300, 410, 370, 310 },
            { 200, 180, 600, 300, 500, 400, 0,   170, 150, 390, 250, 360, 240, 500, 390 },
            { 600, 80,  220, 450, 240, 270, 190, 0,   500, 280, 370, 390, 310, 350, 460 },
            { 200, 150, 200, 150, 350, 200, 170, 400, 0,   290, 390, 250, 200, 300, 370 },
            { 210, 290, 210, 150, 50,  190, 270, 700, 350, 0,   600, 380, 550, 550, 310 },
            { 100, 200, 200, 300, 200, 150, 200, 600, 200, 280, 0,   250, 440, 600, 310 },
            { 340, 270, 340, 260, 290, 310, 220, 260, 360, 310, 260, 0,   200, 480, 380 },
            { 360, 330, 310, 340, 310, 400, 380, 340, 320, 300, 390, 400, 0,   330, 500 },
            { 370, 370, 230, 320, 300, 360, 230, 220, 360, 350, 230, 400, 410, 0,   210 },
            { 350, 310, 300, 350, 330, 260, 270, 240, 310, 390, 220, 250, 570, 590, 0 }
        };
        public int[,] ProductionTime1 = new int[,]
        {
            { 175, 170, 180, 190, 270, 533, 523 },
            { 324, 280, 88, 320, 164, 155, 155 },
            { 389, 300, 370, 67, 112, 179, 220 },
            { 342, 380, 390, 112, 166, 55, 210 },
            { 50, 50, 400, 413, 446, 390, 572 },
            { 550, 350, 550, 750, 834, 590, 520 },
            { 260, 240, 234, 322, 280, 177, 280 },
            { 290, 90, 190, 90, 440, 340, 90 },
            { 20, 10, 50, 190, 160, 140, 190 },
            { 180, 195, 140, 100, 170, 190, 130 }
        };
        public int[,] ProductionTime2 = new int[,]
        {
            { 80, 240, 80, 350, 700, 300, 200, 200, 120, 200, 150, 120, 90, 120, 400 },
            { 142, 84, 100, 200, 20, 400, 400, 108, 300, 110, 90, 50, 44, 50, 200 },
            { 110, 96, 200, 90, 20, 100, 120, 110, 40, 190, 300, 300, 470, 90, 54 },
            { 215, 300, 470, 190, 200, 100, 100, 500, 300, 400, 90, 111, 45, 450, 120 },
            { 316, 500, 870, 500, 500, 550, 490, 700, 300, 490, 490, 300, 480, 600, 500 },
            { 291, 158, 120, 50, 50, 500, 500, 210, 120, 400, 90, 66, 120, 50, 150 },
            { 514, 50, 600, 50, 50, 500, 200, 410, 100, 500, 400, 50, 150, 50, 87 },
            { 110, 340, 120, 70, 80, 350, 90, 200, 50, 500, 400, 33, 50, 80, 90 },
            { 101, 94, 210, 60, 30, 500, 90, 200, 50, 500, 500, 50, 50, 60, 79 }
        };
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
            MessageBox.Show("功能还没做好哦");
            /*
            string[] InputString = InputTextBox.Text.Split(',');
            //整形数组
            int[] Sequence = new int[InputString.Length];
            for (int i = 0; i < InputString.Length; i++)
            {
                Sequence[i] = int.Parse(InputString[i]);
            }*/

        }
    }

    class Part
    {
        public int part_status;
        public int part_type;
        public double arriveTime;
        public Part(double ArriveTime)
        {
            arriveTime = ArriveTime;
            part_type = 0;
        }
    }

    enum MachineStatus
    {//定义机床的两种状态
        SERVICE,    //服务中
        IDLE,       //空闲
    }
    enum ProductionType
    {//定义问题的两种类型
        Fixed,      //固定加工时间
        Random      //随机加工时间
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
        public void workingPart(Part part)
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
        public int machine;         //事件相关的机器
        public int   part;               //事件相关的部件

        public P_Event(double time, int type, int Machine, int Part)  
        {
            occur_time = time;
            EventType = type;
            machine = Machine;
            part = Part;
        }
    }
    class ProductionSystem
    {
        public ArrayList events = new ArrayList();
        public P_Event currentEvent;

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
        double RandExp(double lambda)                           //此处的const_a是指数分布的那个参数λ
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            double pV = 0.0;
            while (true)
            {
                pV = rand.NextDouble();
                if (pV != 1)
                {
                    break;
                }
            }
            pV = (-1.0 / lambda) * Math.Log(1 - pV, Math.E);
            return pV;
        }
        void partArrive(Machine machine, Part part)                             //救护车病人到达函数
        {
            //-------------------------------生成下一名病人的到达事件---------------------------------------//
            double intertime = RandExp((double)adjustLambda[hospital]); //下一名救护车病人到达的时间间隔
            double time = currentEvent.occur_time + intertime;          //下一名救护车病人的到达时间
            P_Event temp_event = new P_Event(time, -1,machine,part);                      //生成下一名病人的到达事件

            //判断实验终止条件，如果已经到达最大服务时间，则不将事件加入事件列表。
            if (time < total_service_time)
            {
                addEvent(events, temp_event);
            }

            //------------------------------根据到达事件生成当前病人----------------------------------------//
            Patient inPatient = new Patient(currentEvent.occur_time);

            //将病人加入排队
            CarPatientQueue.Add(inPatient);


            //--------------------------------处理目前队列中的病人-----------------------------------------//
            int idleIndex = GetIdleBed();                               //寻找空闲的床位
            if (idleIndex >= 0)
            {                                                           //救护车病人有优先排队权，因此无需判定救护车队伍是否为空
                Patient outPatient = (Patient)CarPatientQueue[0];
                time = currentEvent.occur_time + RandExp(hosInfo[hospital, 1]);
                CarPatientQueue.RemoveAt(0);                            //将病人从队列中取出
                beds[idleIndex].servePatient(outPatient);               //将病人安排至床位
                beds[idleIndex].setBusy();                              //将床位状态设置为“繁忙”

                temp_event = new H_Event(time, idleIndex);                 //病人被安排至床位后，产生对应的离开事件
                addEvent(events, temp_event);
            }
            else
            {
                avg_line_car += (CarPatientQueue.Count - 1) * (currentEvent.occur_time - car_line_time);
                car_line_time = currentEvent.occur_time;

                avg_line_total += (CarPatientQueue.Count - 1 + SelfPatientQueue.Count) * (currentEvent.occur_time - total_line_time);
                total_line_time = currentEvent.occur_time;

                if (CarPatientQueue.Count > max_line_car)
                {
                    max_line_car = CarPatientQueue.Count;
                }

                if (CarPatientQueue.Count + SelfPatientQueue.Count > max_line_total)
                {
                    max_line_total = CarPatientQueue.Count + SelfPatientQueue.Count;
                }

            }
        }

    }

  