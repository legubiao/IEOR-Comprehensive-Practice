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
    public partial class 医院问题模拟 : Form
    {
        public 模拟主界面 returnForm = null;
        public 医院问题模拟(模拟主界面 mainForm)
        {
            this.returnForm = mainForm;
            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.returnForm.Visible = true;
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
        class Patient
    {
        public double arriveTime;
        public double onRoadTime;
        public int hospital;
        public Patient(double ArriveTime,double OnRoadTime)
        {
            arriveTime = ArriveTime;
            onRoadTime = OnRoadTime;
            hospital = 0;
        }
    }
    enum BedStatus
    {//定义病床的两种状态
        SERVICE,    //病床服务中
        IDLE        //病床空闲
    }
    enum EventType
    {
        Arrive,
        Leave
    }
    class HospitalBed
    {
        private Patient patient;
        private BedStatus status;
        HospitalBed()
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
        public void getPatient(Patient patient)
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
        public double getOnRoadTime()
        {
            return (patient.onRoadTime);
        }
    }
    struct Event
    {
        public double occur_time;       //事件发生的时间
        public int EventType;           //描述事件的类型
        public Event(double time)
        {
            occur_time = time;
            EventType = 0;
        }
    }
    class Queue
    {
        Queue()
        {

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
        private int     total_costomer;     //总的服务顾客总数
        private double  total_stay_time;    //总的等待时间
        private int     windows_number;     //窗口数目
        private double  avg_stay_time;      //平均时间
        private double  avg_costomers;      //平均顾客数目


        public Patient[] patientQueue = new Patient[0];
        public Event[] events = new Event[0];
        public Event currentEvent;
        public double[] lastArrive = new double[] { 0, 0, 0, 0 };
        public double[,] sentRatio = new double[,]
        {   //由救护站送往医院的比例，需要外部给定
            { 0.2, 0.5, 0.6, 0.8, 1},
            { 0.2, 0.5, 0.6, 0.8, 1},
            { 0.2, 0.5, 0.6, 0.8, 1},
            { 0.2, 0.5, 0.6, 0.8, 1} 
        };

        public double RandExp(double const_a) //此处的const_a是指数分布的那个参数λ
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
        public int DesSelect(int station)
        {   //根据所属站点，生成目的地医院
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            double p = rand.NextDouble();
            for (int i=0; i<4; i++)
            {
                if (sentRatio[station,i] > p)
                {
                    return (i);
                }
            }
            return (0);
        }
        void init()
        {
            Event @event;
            @event.occur_time = 0;
            @event.EventType = 0;
            events.Append(@event);
            currentEvent = @event;
        }
        void run()
        {
            init();
            while (events.GetLength(0) != 0)
            {
                if (currentEvent.EventType == 0)
                {

                }
            }
        }
        void carPatientArrive(int station)                      //救护车病人到达函数
        {
            total_costomer++;                                   //总病人数目+1               
            double intertime = RandExp(patientIn[station]);     //根据所属救护站，计算病人生成间隔时间
            lastArrive[station] += intertime;                   //救护站最后到达时间更新
            double time = lastArrive[station];                  
            Event temp_event = new Event(time);
            if (time < total_service_time)
            {
                events.Append(temp_event);
            }
            patientQueue.Append(new Patient(time,RandExp(2)));  
        }
        void selfPatientArrive(int hospital)                    //自行病人到达函数
        {

        }
        void patientDeparture()
        {

        }
    }

    }
}
