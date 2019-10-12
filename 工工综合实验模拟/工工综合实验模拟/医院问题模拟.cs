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
    public partial class 医院问题模拟 : Form
    {
        public 模拟主界面 returnForm = null;
        public 医院问题模拟(模拟主界面 mainForm)
        {
            this.returnForm = mainForm;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {   //点击“单次模拟”进行一次模拟，观察模拟分布
            int total_service_time = 100;                           // 单次模拟时间
            int simulate_num = 5;                                   // 模拟次数

            QueueSystem system = new QueueSystem(total_service_time, 0);
            system.stimulate(simulate_num);
            textBox21.Text = system.avg_stay_time.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {   //点击返回键返回上个页面
            this.returnForm.Visible = true;
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
    }

    class Patient
    {
        public double arriveTime;
        public int hospital;
        public Patient(double ArriveTime)
        {
            arriveTime = ArriveTime;
            hospital = 0;
        }
    }
    enum BedStatus
    {//定义病床的两种状态
        SERVICE,    //病床服务中
        IDLE        //病床空闲
    }
    enum QueueStatus
    {
        CarEmpty,
        CarBusy,
    }
    class HospitalBed
    {
        private Patient patient;
        private BedStatus status;
        public HospitalBed()
        { //构造函数，初始时设置床位为空闲
            status = BedStatus.IDLE;
        }
        public void setBusy()//窗口设置为繁忙
        {
            status = BedStatus.SERVICE;
        }
        public void setIdle()//窗口设置为空闲
        {
            status = BedStatus.IDLE;
        }
        public void servePatient(Patient patient)
        {
            this.patient = patient;
        }
        public bool isIdle()
        {
            return (status == BedStatus.IDLE);
        }
        public double getArriveTime()
        {
            return (patient.arriveTime);
        }
    }
    struct Event
    {
        public double occur_time;       //事件发生的时间
        public int EventType;           //描述事件的类型,-1代表到达事件，否否则代表床位的编号
        public Event(double time,int type)
        {
            occur_time = time;
            EventType = type;
        }
    }
    class QueueSystem
    {
        double[]    patientIn = new double[] { 2.8, 2.2, 3.4, 2.5 };
            //四个救护站病人到达的参数
        double[,]   patient2Hos = new double[,]
        {   //从救护站转移到医院的参数
                {2.2, 2,   2.4, 1,   1.5} ,
                {2.8, 2.5, 1.8, 2.3, 3.1},
                {2,   2.2, 2.8, 3,   2.3},
                {2.5, 2.6, 2,   2.5, 2.1}
        };

        double[,] hosInfo = new double[,]
        {   //自行到达病人速率，单台病床服务速率，最大床位数，初始床位数
                {3.4, 0.42, 40, 13},
                {3.6, 0.5,  40, 15},
                {3.7, 0.46, 40, 20},
                {3.7, 0.55, 40, 20},
                {4,   0.55, 40, 20},
                {3.6, 0.4,  40, 18}
        };

        private double  total_service_time; //总的服务时间
        private int     total_patients;     //总的病人数目
        private double  total_stay_time;    //总的等待时间
        private int     hospital;           //所属医院编号
        private int     bed_number;             //医院床位数目
        public double  avg_stay_time;       //平均时间
        public double  avg_costomers;       //平均病人数目

        public HospitalBed [] beds;
        public ArrayList CarPatientQueue = new ArrayList();
        public ArrayList SelfPatientQueue = new ArrayList();

        public ArrayList events = new ArrayList();
        public Event currentEvent;
        public double[] lastArrive = new double[] { 0, 0, 0, 0 };
        public double[,] sentRatio = new double[,]
        {   //由救护站送往医院的比例，需要外部给定
            { 0.2, 0.3, 0.1, 0.2, 0.2},
            { 0.2, 0.2, 0.2, 0.2, 0.2},
            { 0.2, 0.3, 0.1, 0.3, 0.1},
            { 0.2, 0.3, 0.1, 0.2, 0.2} 
        };
        public ArrayList adjustLambda = new ArrayList();

        public double RandExp(double const_a)                           //此处的const_a是指数分布的那个参数λ
        {   //生成指数分布的随机数
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            double temp;
            if (const_a != 0)
                temp = 1 / const_a;
            else
                throw new System.InvalidOperationException("除数不能为零！不能产生参数为零的指数分布！");

            double randres;
            double p;
            while (true) //用于产生随机的密度，保证比参数λ小             
            {
                p = rand.NextDouble();
                if (p < const_a)
                    break;
            }
            randres = -temp * Math.Log(temp * p, Math.E);
            return randres;
        }
        void addEvent(ArrayList list,Event @event)
        {
            if (@event.occur_time > ((Event)list[list.Count-1]).occur_time)
            {
                list.Add(@event);
            }
            else
            {
                for (int i = 0; i != list.Count; i++)
                {
                    if (((Event)list[i]).occur_time > @event.occur_time)
                    {
                        list.Insert(i, @event);
                        break;
                    }
                }
            }
        }
        void init()                                                     //初始化函数，会生成两种类型各一个到达事件
        {
            events.Clear();
            events.Add(new Event(0,-1));                                //救护车病人到达事件
            events.Add(new Event(0, -2));                               //自行病人到达事件

            this.beds = new HospitalBed[(int)hosInfo[hospital, 2]];
            for (int i = 0; i != (int)hosInfo[hospital, 2]; i++)
            {
                beds[i] = new HospitalBed();
            }
        }
        double run()
        {
            init();
            while (events.Count != 0)
            {
                currentEvent = (Event)events[0];
                events.RemoveAt(0);
                if (currentEvent.EventType == -1)                       //事件类型为-1，处理救护车病人到达事件
                {
                    carPatientArrive(hospital);
                }
                else if (currentEvent.EventType == -2)                  //事件类型为-2，处理自行病人到达事件
                {
                    selfPatientArrive(hospital);            
                }
                else
                {
                    patientDeparture(hospital);                         //事件类型非-1或2，处理病人离开事件
                }
            }
            end();
            return ((double)total_stay_time / total_patients);          //计算得到顾客平均逗留时间并返回
        }
        void end()
        {
            events.Clear();
            CarPatientQueue.Clear();
            SelfPatientQueue.Clear();
        }
        void carPatientArrive(int hospital)                             //救护车病人到达函数
        {
            total_patients++;                                           //病人数目++

            //-------------------------------生成下一名病人的到达事件---------------------------------------//
            double intertime = RandExp((double)adjustLambda[hospital]); //下一名救护车病人到达的时间间隔
            double time = currentEvent.occur_time + intertime;          //下一名救护车病人的到达时间
            Event temp_event = new Event(time,-1);                      //生成下一名病人的到达事件

            //判断实验终止条件，如果已经到达最大服务时间，则不将事件加入事件列表。
            if (time < total_service_time)
            {
                addEvent(events, temp_event);
            }

            //------------------------------根据到达事件生成当前病人----------------------------------------//
            Patient inPatient = new Patient(currentEvent.occur_time);
            //将病人加入病人列表
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

                temp_event = new Event(time,idleIndex);                 //病人被安排至床位后，产生对应的离开事件
                addEvent(events, temp_event);
            }

        }
        void selfPatientArrive(int hospital)                            //自行病人到达函数
        {
            total_patients++;                                           //病人数目++

            //-------------------------------生成下一名病人的到达事件---------------------------------------//
            double intertime = RandExp(hosInfo[hospital, 0]);           //下一名自行病人到达的时间间隔
            double time = currentEvent.occur_time + intertime;          //下一名自行病人的到达时间
            Event temp_event = new Event(time,-2);                      //生成下一名病人的到达事件

            //判断实验终止条件，如果已经到达最大服务时间，则不将事件加入事件列表。
            if (time < total_service_time)
            {
                addEvent(events, temp_event);
            }

            //------------------------------根据到达事件生成当前病人----------------------------------------//
            Patient inPatient = new Patient(currentEvent.occur_time);
            //将病人加入病人列表
            SelfPatientQueue.Add(inPatient);

            //--------------------------------处理目前队列中的病人-----------------------------------------//
            int idleIndex = GetIdleBed();                               //寻找空闲的床位
            if (idleIndex >= 0)
            {
                if (returnQueueStatus() != QueueStatus.CarBusy)         //只有当没有救护车病人的时候自行病人才可以进入
                {
                    Patient outPatient = (Patient)SelfPatientQueue[0];
                    time = currentEvent.occur_time + RandExp(hosInfo[hospital, 1]);
                    SelfPatientQueue.RemoveAt(0);                       //将病人从队列中取出
                    beds[idleIndex].servePatient(outPatient);           //将病人安排至床位
                    beds[idleIndex].setBusy();                          //将床位状态设置为“繁忙”

                    temp_event = new Event(time,idleIndex);             //病人被安排至床位后，生成对应的离开事件
                    addEvent(events, temp_event);
                }
            }
        }
        void patientDeparture(int hospital)                             //病人离开函数
        {
            //判断实验终止条件，如果已经到达最大服务时间，则进行处理
            if (currentEvent.occur_time< total_service_time)
            {               
                //计算病人总逗留时间
                total_stay_time += currentEvent.occur_time - beds[currentEvent.EventType].getArriveTime();
                
                //如果队列中还有病人，则立刻对下一位病人进行服务，并生成下一位病人的离开事件
                //优先处理救护车病人
                if (CarPatientQueue.Count > 0)
                {
                    Patient patient = (Patient)CarPatientQueue[0];
                    CarPatientQueue.RemoveAt(0);
                    beds[currentEvent.EventType].servePatient(patient); //从队列中取出下一位病人并分配至当前床位

                    double InterTime = RandExp(hosInfo[hospital,1]);    //计算当前病人的治疗时间
                    double time = currentEvent.occur_time + InterTime;  //计算下一位病人离开事件的发生时间
                    Event temp_event = new Event(time, currentEvent.EventType);
                    addEvent(events, temp_event);
                }

                else if (SelfPatientQueue.Count > 0)
                {
                    Patient patient = (Patient)SelfPatientQueue[0];
                    SelfPatientQueue.RemoveAt(0);
                    beds[currentEvent.EventType].servePatient(patient); //从队列中取出下一位病人并分配至当前床位

                    double InterTime = RandExp(hosInfo[hospital, 1]);   //计算当前病人的治疗时间
                    double time = currentEvent.occur_time + InterTime;  //计算下一位病人离开事件的发生时间
                    Event temp_event = new Event(time, currentEvent.EventType);
                    addEvent(events, temp_event);
                }

                else
                {
                    beds[currentEvent.EventType].setIdle();
                }
            }
        }
        QueueStatus returnQueueStatus()
        {
            //查看当前救护车队列是否为空
            if (CarPatientQueue.Count >= 0)
            {
                return (QueueStatus.CarBusy);
            }
            else
            {
                return (QueueStatus.CarEmpty);
            }
        }
        int GetIdleBed()
        {
            for (int i = 10; i != bed_number; ++i)
            {
                if (beds[i].isIdle())
                {
                    return i;
                }
            }
            return -1;
        }

        public QueueSystem(double total_service_time, int hospital)     //构造函数
        {
            this.total_service_time = total_service_time;
            this.hospital = hospital;
            this.bed_number = (int)hosInfo[hospital, 2];
            this.total_stay_time = 0;
            total_service_time = 0;


            for (int i = 0; i != 5; i++)                                //根据比例，计算各个医院的救护车病人的到达参数
            {
                double lambda_i = 0;
                for (int j = 0; j != 4; j++)
                {
                    lambda_i += sentRatio[j, i] * patientIn[j];
                }
                this.adjustLambda.Add(lambda_i);
            }
        }
        public void stimulate(int stimulate_num)
        {
            double sum = 0;                                             //sum为多次模拟中病人平均逗留时间之和
            for (int i = 0; i != stimulate_num; i++)
            {
                sum += run();
            }

            //计算多次模拟的平均病人逗留时间和病人数目；
            avg_stay_time = sum / stimulate_num;
            avg_costomers = total_patients / (total_service_time * stimulate_num);
        }
    }

}
