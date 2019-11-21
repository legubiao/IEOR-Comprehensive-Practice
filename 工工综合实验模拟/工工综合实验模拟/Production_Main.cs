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
            else if (comboBox2.Text == "7个工件")
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
            if (InputTextBox.Text != "")
            {
                string[] InputString = InputTextBox.Text.Split(',');
                int[] Sequence = new int[InputString.Length];
                for (int i = 0; i < InputString.Length; i++)
                {
                    Sequence[i] = int.Parse(InputString[i]) - 1;
                }
                ProblemType Q_type;
                ProductionType P_type;
                if (comboBox1.Text == "固定加工问题")
                {
                    P_type = ProductionType.Fixed;
                }
                else
                {
                    P_type = ProductionType.Random;
                }
                bool isvalid = true;
                if (comboBox2.Text == "7个工件")
                {
                    Q_type = ProblemType.small;
                    foreach (int i in Sequence)
                    {
                        if (i > 6)
                        {
                            MessageBox.Show("工件序号超出最大值");
                            isvalid = false;
                        }
                    }
                }
                else
                {
                    Q_type = ProblemType.big;
                    foreach (int i in Sequence)
                    {
                        if (i > 14)
                        {
                            MessageBox.Show("工件序号超出最大值");
                            isvalid = false;
                        }
                    }
                }
                if (isvalid)
                {
                    ProductionSystem system = new ProductionSystem(Q_type, P_type, Sequence);
                    system.stimulate(1);

                    DataTable dt = new DataTable();
                    for (int i = 0; i < system.leaveTimes.GetLength(1); i++)
                        dt.Columns.Add(i.ToString(), typeof(int));
                    for (int i = 0; i < system.leaveTimes.GetLength(0); i++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < system.leaveTimes.GetLength(1); j++)
                            dr[j] = system.leaveTimes[i, j];
                        dt.Rows.Add(dr);
                    }
                    this.dataGridView1.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("输入不能为空哦");
            }
        }
    }

    class Part
    {
        public PartStatus part_status;
        public int part_No;
        public int part_Type;
        public Part(int part_Type)
        {
            this.part_Type = part_Type;
            part_status = PartStatus.onHold;
        }
    }
    enum PartStatus
    {
        onHold,
        Processing,
        Finished
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
    enum ProblemType
    {
        small,      //七个工件的小问题
        big         //十多个工件的大问题
    }
    class Machine
    {
        private MachineStatus status;
        public int      Machine_No;                                 //机器编号
        public int      Machine_Type;                               //机器类型            
        public double   finished_Time;
        public Machine(int M_No,int M_type)
        { //构造函数，初始时设置机器为空闲
            status = MachineStatus.IDLE;
            Machine_No = M_No;
            Machine_Type = M_type;
        }
        public void setBusy()//窗口设置为繁忙
        {
            status = MachineStatus.SERVICE;
        }
        public void setIdle()//窗口设置为空闲
        {
            status = MachineStatus.IDLE;
        }
        public bool isIdle()
        {
            return (status == MachineStatus.IDLE);
        }
    }
    struct P_Event
    {
        public double occur_time;       //事件发生的时间
        public int EventType;           //描述事件的类型
        public int machine;             //事件相关的机器
        public int part_i;              //事件相关的部件的序号

        public P_Event(double time, int type, int Machine, int Part)
        {
            occur_time = time;
            EventType = type;
            machine = Machine;
            part_i = Part;
        }
    }
    class ProductionSystem
    {
        public ArrayList events = new ArrayList();
        public P_Event currentEvent;

        int[] Part_Num1 = new int[] {
            3,
            5,
            4,
            2,
            4,
            3,
            4
        };
        int[] Part_Num2 = new int[]
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
        int[,] Part_Change1 = new int[,]
        {
            { 0, 300, 100, 100, 400, 400, 1200 },
            { 220, 0, 500, 100, 200, 400, 110 },
            { 600, 1000, 0, 2000, 700, 1000, 500 },
            { 500, 200, 100, 0, 400, 300, 600 },
            { 300, 300, 200, 150, 0, 770, 240 },
            { 900, 150, 210, 290, 260, 0, 260 },
            { 200, 180, 600, 300, 500, 400, 0 }
        };
        int[,] Part_Change2 = new int[,]
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
        int[,] ProductionTime1 = new int[,]
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
        int[,] ProductionTime2 = new int[,]
        {
            { 275,170, 364,111, 90,  300, 100, 200, 120, 580, 150, 70,  120,111, 111 },
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

        int Total_Machine_No=10;
        int Total_Parts_No;
        int[] Parts_Sequence;                                           //部件初始进入的次序

        ProductionType productionType;                                  //加工时间的计算是指数分布还是固定数值
        ProblemType problemType;                                        //问题是7个的小问题还是14个的大问题
        Machine[] machines;
        Part[] parts;

        public double[] arriveTimes;
        public double[,] leaveTimes;

        void addEvent(ArrayList list, P_Event @event)
        {
            if (@event.occur_time >= ((P_Event)list[list.Count - 1]).occur_time)
            {
                list.Add(@event);
            }
            else
            {
                for (int i = 0; i != list.Count; i++)
                {
                    if (((P_Event)list[i]).occur_time > @event.occur_time)
                    {
                        list.Insert(i, @event);
                        break;
                    }
                }
            }
        }
        double RandExp(double lambda)                                   //此处的const_a是指数分布的那个参数λ
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
        void partArrive(Machine machine,int part_i)
        {
            Part currentPart = parts[part_i];
            Part lastPart;
            if (part_i == 0)
            {
                lastPart = currentPart;
            }
            else
            {
                lastPart = parts[part_i - 1];
            }
            double ProcessTime = 0;
            double ChangeTime = 0;
            machine.setBusy();
            if (problemType == ProblemType.small)
            {
                if (productionType == ProductionType.Random)
                {

                    ProcessTime = Part_Num1[currentPart.part_Type]*RandExp((float)1/ProductionTime1[machine.Machine_Type, currentPart.part_Type]);
                }
                else
                {
                    ProcessTime = Part_Num1[currentPart.part_Type] * ProductionTime1[machine.Machine_Type, currentPart.part_Type];
                }
                ChangeTime = Part_Change1[lastPart.part_No, currentPart.part_No];
            }
            else
            {
                if (productionType == ProductionType.Random)
                {
                    ProcessTime = Part_Num2[currentPart.part_Type] * RandExp((float)1 / ProductionTime2[machine.Machine_Type, currentPart.part_Type]);
                }
                else
                {
                    ProcessTime = Part_Num2[currentPart.part_Type] * ProductionTime2[machine.Machine_Type, currentPart.part_Type];
                }
                ChangeTime = Part_Change2[lastPart.part_Type, currentPart.part_Type];
            }

            double time = currentEvent.occur_time + ChangeTime + ProcessTime;
            //生成当前部件在当前机器的下机事件
            P_Event down_Event = new P_Event(time, -1, machine.Machine_No, currentPart.part_No);
            addEvent(events, down_Event);
            machine.finished_Time = time;

            if (machine.Machine_Type == 0)
            {
                //如果是第一台机器，就顺便安排下一个部件的上机   
                if (currentPart.part_No != parts.Length-1)
                {
                    P_Event up_Event = new P_Event(time, 1, machine.Machine_No, currentPart.part_No + 1);
                    addEvent(events, up_Event);
                    arriveTimes.Append(time);
                }
            }


        }
        void partLeave(Machine current_machine, int part_i)
        {
            current_machine.setIdle();
        
            double time = 0;

            if (current_machine.Machine_Type < Total_Machine_No-1)
            {
                Machine next_machine;
                if (current_machine.Machine_No == 4)                            //对应位置6的双机器
                {
                    if (machines[5].finished_Time > machines[10].finished_Time)
                    {
                        next_machine = machines[10];
                    }
                    else
                    {
                        next_machine = machines[5];
                    }
                }
                else
                {
                    next_machine = machines[current_machine.Machine_Type + 1];
                }
                if (currentEvent.occur_time < next_machine.finished_Time)
                {
                    time = next_machine.finished_Time;
                }
                else
                {
                    time = currentEvent.occur_time;
                }
                leaveTimes[current_machine.Machine_Type,part_i] = currentEvent.occur_time;
                //若当前机器不是最后一个，则生成该工件在下一个机器的到达事件
                P_Event up_Event = new P_Event(time, 1, next_machine.Machine_Type, parts[part_i].part_No);
                addEvent(events, up_Event);
            }
            else
            {
                parts[part_i].part_status = PartStatus.Finished;        //表示工件已经加工完成
                leaveTimes[part_i, Total_Machine_No-1] = currentEvent.occur_time;
            }
        }
        void init()                                                     //初始化函数，会生成两种类型各一个到达事件
        {
            events.Clear();

            this.machines = new Machine[Total_Machine_No+1];              //初始化机器队列
            for (int i = 0; i != Total_Machine_No; i++)
            {
                machines[i] = new Machine(i,i);
            }
            machines[10]=(new Machine(10,5));

            this.parts = new Part[Total_Parts_No];                      //初始化部件队列
            for (int i = 0; i != Total_Parts_No; i++)
            {
                parts[i] = new Part(Parts_Sequence[i]);
                parts[i].part_No = i;
            }
            events.Add(new P_Event(0,1,parts[0].part_No,machines[0].Machine_No));
            arriveTimes=new double[] {0};
        }
        public void stimulate(int stimulate_num)
        {
            for (int i = 0; i != stimulate_num; i++)
            {
                run();
            }
        }
        void run()
        {
            init();
            while (events.Count != 0)
            {
                currentEvent = (P_Event)events[0];
                if (currentEvent.EventType == 1)                       //事件类型为1，上机事件
                {
                    partArrive(machines[currentEvent.machine], currentEvent.part_i) ;
                }
                else
                {
                    partLeave(machines[currentEvent.machine], currentEvent.part_i);
                }
                events.RemoveAt(0);
            }
            end();
        }
        void end()
        {
            events.Clear();
        }
        public ProductionSystem(ProblemType problemType,ProductionType productionType ,int[] parts)
        {
            this.problemType = problemType;
            this.productionType = productionType;
            this.Total_Parts_No = parts.Length;
            this.leaveTimes = new double[Total_Parts_No,Total_Machine_No];
            this.Parts_Sequence = parts;
        }
    }
}
  