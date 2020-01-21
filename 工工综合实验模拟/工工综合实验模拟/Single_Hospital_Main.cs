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

    public partial class Single_Hospital_Main : Form
    {
        Main_Form returnForm = null;
        protected int[,] lambda = new int[,]
        {
            { 3, 20, 25, 29, 13, 20, 15, 11, 14, 9, 11, 17, 14, 11, 15, 24, 29, 14, 9, 2, 3, 5, 4, 1 },
            { 5, 20, 38, 51, 33, 28, 22, 18, 22, 15, 15, 25, 20, 18, 23, 37, 28, 8, 4, 3, 5, 8, 6, 2 }
        };
        protected int[,] beds_num = new int[,]
        {
            { 2, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 2, 2, 2, 2, 2, 2 },
            { 3, 3, 6, 6, 6, 6, 6, 6, 6, 6, 5, 5, 5, 5, 5, 5, 5, 5, 3, 3, 3, 3, 3, 3 }
        };

        public Single_Hospital_Main(Main_Form returnForm)
        {
            InitializeComponent();
            this.returnForm = returnForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.returnForm.Visible = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int simulate_num = int.Parse(stiDays.Text);           // 模拟次数
            int Seed = int.Parse(randomSeed.Text);                // 随机数种子
            double miu;
            int[] lambda = new int[24];
            int[] beds_num = new int[24];
            int switchRule=0;
            if (dataSwitch.Text == "数据1")
            {
                miu = 5.9113;
                for (int i = 0; i != 24; i++)
                {
                    lambda[i] = this.lambda[0, i];
                    beds_num[i] = this.beds_num[0, i];
                }
            }
            else
            {
                miu = 5.8772;
                for (int i = 0; i != 24; i++)
                {
                    lambda[i] = this.lambda[1, i];
                    beds_num[i] = this.beds_num[1, i];
                }
            }
            
            switch (ruleSwitch.Text)
            {
                case "规则1":
                    switchRule = 0;
                    break;
                case "规则2":
                    switchRule = 1;
                    break;
                case "规则3":
                    switchRule = 2;
                    break;
            }
            S_QueueSystem system = new S_QueueSystem(miu,lambda,beds_num,switchRule,Seed);
            system.stimulate(simulate_num);
            Single_Hospital_Result Output = new Single_Hospital_Result (this,system.patientCount,system.sl1,system.sl2,system.sl3)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            this.Hide();
            Output.Show();

        }

        // ------------------------------------------------------------
        enum QueueStatus { Empty, Busy }
        enum BedStatus { SERVICE, IDLE }

        class S_Beds : HospitalBed
        {
            protected   S_Patient patient;
            public      S_Event LeaveEvent;
            public void servePatient(S_Patient patient,S_Event @event)
            {
                this.patient = patient;
                this.LeaveEvent = @event;
            }
            public S_Patient returnPatient()
            {
                return patient;
            }
        }

        class S_Event : H_Event
        {
            public int switchValue;
            public S_Event(double time,int type):base(time,type)
            {
                switchValue = 0;
            }
        }

        class S_Patient
        {
            public double arriveTime;               //病人到达时间
            public double remainTime;               //剩余治疗时间
            public double totalTime;                //总等待时间
            public double lastLeave;                //上一次从队列中退出的时间
            public S_Patient(double ArriveTime)
            {
                arriveTime = ArriveTime;
                remainTime = -1;
                totalTime = 0;
                lastLeave = 0;
            }
        }

        class S_QueueSystem
        {
            List<S_Beds> beds = new List<S_Beds>();
            List<S_Patient> PatientQueue = new List<S_Patient>();
            List<S_Event> events = new List<S_Event>();

            public int[] patientCount = new int[24];                               //计数器们
            public int[] sl1 = new int[24];                                        //不满足服务水平1的数量
            public int[] sl2 = new int[24];                                        //不满足服务水平2的数量
            public int[] sl3 = new int[24];                                        //不满足服务水平3的数量

            int switchRule;
            int seed;
            int[] beds_num = new int[24];                                   //各个时间段病床的数量
            int[] lambda = new int[24];                                     //各个时间段病人的平均到达数目
            double miu;                                                     //单个服务台服务速率

            S_Event currentEvent;

            public double RandExp(double lambda)                           //此处的const_a是指数分布的那个参数λ
            {
                //Random rand = new Random(Guid.NewGuid().GetHashCode());
                Random rand = new Random(seed);
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

            void addEvent(List<S_Event> list, S_Event @event)
            {
                if (list.Count != 0)
                {
                    if (@event.occur_time > ((S_Event)list[list.Count - 1]).occur_time)
                    {
                        list.Add(@event);
                    }
                    else
                    {
                        for (int i = 0; i != list.Count; i++)
                        {
                            if (((S_Event)list[i]).occur_time > @event.occur_time)
                            {
                                list.Insert(i, @event);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    list.Add(@event);
                }
            }
            void init()
            {               
                events.Add(new S_Event(0, -1));
                for (int i =0;i!= beds_num[0]; i++)
                {
                    beds.Add(new S_Beds());
                }
                for (int i = 1; i != 24; i++)
                {
                    //初始配置改变床位相关的事件
                    S_Event temp_event = new S_Event(i, -2);
                    temp_event.switchValue = beds_num[i] - beds_num[i - 1];
                    addEvent(events, temp_event);                   
                }
            }
            void reset()
            {
                events.Clear();
                PatientQueue.Clear();
                beds.Clear();
            }
            void run()
            {
                init();
                while (events.Count!=0)
                {
                    currentEvent = events[0];
                    if (currentEvent.EventType == -1)                       //事件类型为-1，病人到达
                    {
                        patientArrive((int)currentEvent.occur_time);
                    }
                    else if (currentEvent.EventType == -2)                  //事件类型为-2，医院换班
                    {
                        bedsSwitch(currentEvent.switchValue);
                    }
                    else
                    {
                        patientDeparture();                                 //事件类型非-1或2，处理病人离开事件
                    }
                    events.RemoveAt(0);
                }
                reset();
            }

            void patientArrive(int currentHour)
            {
                patientCount[currentHour] += 1;                             //该时间段内病人总数+1

                //-------------------------------生成下一名病人的到达事件---------------------------------------//                
                double intertime = RandExp((double)lambda[currentHour]);    //下一名救护车病人到达的时间间隔              
                double time = currentEvent.occur_time + intertime;          //下一名救护车病人的到达时间
                S_Event temp_event = new S_Event(time, -1);                 //生成下一名病人的到达事件

                //判断实验终止条件，如果已经到达24点，则不将事件加入事件列表。
                if (time < 24)
                {
                    addEvent(events, temp_event);
                }

                //------------------------------根据到达事件生成当前病人----------------------------------------//
                S_Patient inPatient = new S_Patient(currentEvent.occur_time);

                //将病人加入排队
                PatientQueue.Add(inPatient);


                //--------------------------------处理目前队列中的病人-----------------------------------------//
                int idleIndex = GetIdleBed();                               //寻找空闲的床位
                if (idleIndex >= 0)
                {
                    S_Patient outPatient = PatientQueue[0];
                    time = currentEvent.occur_time + RandExp(miu);
                    PatientQueue.RemoveAt(0);                               //将病人从队列中取出
                    beds[idleIndex].setBusy();                              //将床位状态设置为“繁忙”

                    temp_event = new S_Event(time, idleIndex);              //产生对应的离开事件
                    addEvent(events, temp_event);
                    beds[idleIndex].servePatient(outPatient,temp_event);    //将病人安排至床位
                }
                else
                {
                    //计算队长的变化
                }
            }
            void patientDeparture()
            {
                S_Patient this_Patient = beds[currentEvent.EventType].returnPatient();
                if (this_Patient.totalTime > 0.5)
                {
                    sl3[(int)this_Patient.arriveTime] += 1;
                }

                //依靠当前事件的 EventType 参数来确定窗口
                //判断实验终止条件，如果已经到达最大服务时间，则不进行处理
                if (currentEvent.occur_time < 24)
                {

                    //如果队列中还有病人，则生成下一位病人的离开事件
                    if (PatientQueue.Count > 0)
                    {
                        S_Patient patient = PatientQueue[0];
                        PatientQueue.RemoveAt(0);

                        double InterTime = 0;
                        double waitTime = 0;
                        if (patient.remainTime > 0)
                        {// 曾经被退回来的病人
                            InterTime = patient.remainTime;
                            waitTime = currentEvent.occur_time - patient.lastLeave;
                            patient.totalTime += waitTime;
                            if (patient.lastLeave < patient.arriveTime+0.5 && currentEvent.occur_time > patient.arriveTime + 0.5)
                            {
                                sl2[(int)patient.arriveTime - 1] += 1;
                            }
                        }
                        else
                        {// 第一次接受治疗的病人
                            InterTime = RandExp(miu);                    //计算当前病人的治疗时间

                            waitTime = currentEvent.occur_time - patient.arriveTime;
                            patient.totalTime += waitTime;
                            if (waitTime > 0.5)
                            {
                                sl1[(int)patient.arriveTime] += 1;
                                sl2[(int)patient.arriveTime] += 1;
                            }
                        }
                                          
                        double time = currentEvent.occur_time + InterTime;  //计算下一位病人离开事件的发生时间
                        S_Event temp_event = new S_Event(time, currentEvent.EventType);
                        addEvent(events, temp_event);

                        beds[currentEvent.EventType].servePatient(patient,temp_event); //从队列中取出下一位病人并分配至当前床位
                    }
                    else
                    {
                        beds[currentEvent.EventType].setIdle();
                    }
                }
            }
            void bedsSwitch(int amount)
            {
                if (amount > 0)                                             //增加床位
                {
                    for (int i = 0; i != amount; i++)
                    {
                        beds.Add(new S_Beds());
                    }
                }
                else if (amount < 0)
                {                                                           //减少床位
                    Random rand = new Random();
                    for (int i = 0; i != (-amount); i++)
                    {
                        int r = rand.Next(0, beds.Count - 1);

                        //处理标记为r处的床位的病人
                        //首先检查这个床位是否有人，如果没有的话就跳过
                        if (beds[r].isIdle())
                        {
                            beds.RemoveAt(r);
                        }
                        else
                        {
                            //计算病人剩余的治疗时间
                            int idleNum = GetIdleBed();
                            double currentTime = currentEvent.occur_time;
                            double endTime = beds[r].LeaveEvent.occur_time;

                            S_Patient rePatient = beds[r].returnPatient();
                            rePatient.remainTime = endTime - currentTime;

                            //移除病人原本的离开事件
                            events.Remove(beds[r].LeaveEvent);

                            //根据选择的策略处理换班
                            switch (switchRule)
                            {
                                case 0:
                                    if (idleNum != -1)
                                    {//若存在空闲服务台，正在服务中的服务台将工作转交给空闲服务台后下班
                                        S_Event event_0 = new S_Event(endTime, idleNum);
                                        addEvent(events, event_0);
                                        beds[idleNum].servePatient(rePatient, event_0);
                                    }
                                    else
                                    {//否则，正在服务中的服务台将完成当前顾客的服务后下班                                       
                                        if (rePatient.totalTime > 0.5)
                                        {
                                            sl3[(int)rePatient.arriveTime] += 1;
                                        }
                                    }
                                    break;
                                case 1:
                                    //正在服务中的服务台将直接下班，其正在服务中的顾客被退回队首
                                    rePatient.lastLeave = currentTime;
                                    PatientQueue.Insert(0, rePatient);                                  
                                    break;
                                case 2:
                                    //正在服务中的服务台完成当前顾客的服务后下班
                                    if (rePatient.totalTime > 0.5)
                                    {
                                        sl3[(int)rePatient.arriveTime] += 1;
                                    }
                                    break;
                            }
                            beds.RemoveAt(r);
                        }

                        for (int j = 0; j != events.Count; j++)
                        {
                            if (events[j].EventType >= r)
                            {
                                events[j].EventType -= 1;
                            }
                        }
                    }
                }
                for (int j = 0; j != events.Count; j++)
                {
                    if (events[j].EventType == -1)
                    {
                        S_Event newEvent = events[j];
                        newEvent.occur_time = currentEvent.occur_time;
                        events.RemoveAt(j);
                        addEvent(events, newEvent);
                        break;
                    }
                }
            }
            int GetIdleBed()
            {
                for (int i = 0; i != beds.Count; ++i)
                {
                    if (beds[i].isIdle())
                    {
                        return i;
                    }
                }
                return -1;
            }
            public void stimulate(int sti_times)
            {
                for (int i = 0; i != 24; i++)
                {//初始化计数器
                    patientCount[i] = 0;
                    sl1[i] = 0;
                    sl2[i] = 0;
                    sl3[i] = 0;
                }

                for (int i = 0; i != sti_times; i++)
                {
                    run();
                }
            }
            public S_QueueSystem(double miu,int[] lambda,int[]beds_num,int switchRule,int seed)
            {
                this.miu = miu;
                this.lambda = lambda;
                this.beds_num = beds_num;
                this.switchRule = switchRule;
                if (seed == 0)
                {
                    this.seed = Guid.NewGuid().GetHashCode();
                }
                else
                {
                    this.seed = seed;
                }
            }
        }
    }
}
