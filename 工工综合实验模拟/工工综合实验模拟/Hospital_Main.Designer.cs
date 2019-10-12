namespace 工工综合实验模拟
{
    partial class Hospital_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.stiTimeBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.stiNumBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Bed5 = new System.Windows.Forms.TextBox();
            this.Bed4 = new System.Windows.Forms.TextBox();
            this.Bed3 = new System.Windows.Forms.TextBox();
            this.Bed2 = new System.Windows.Forms.TextBox();
            this.Bed1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Ratio4_5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Ratio4_4 = new System.Windows.Forms.TextBox();
            this.Ratio4_3 = new System.Windows.Forms.TextBox();
            this.Ratio4_2 = new System.Windows.Forms.TextBox();
            this.Ratio4_1 = new System.Windows.Forms.TextBox();
            this.Ratio3_5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Ratio3_4 = new System.Windows.Forms.TextBox();
            this.Ratio3_3 = new System.Windows.Forms.TextBox();
            this.Ratio3_2 = new System.Windows.Forms.TextBox();
            this.Ratio3_1 = new System.Windows.Forms.TextBox();
            this.Ratio2_5 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Ratio2_4 = new System.Windows.Forms.TextBox();
            this.Ratio2_3 = new System.Windows.Forms.TextBox();
            this.Ratio2_2 = new System.Windows.Forms.TextBox();
            this.Ratio2_1 = new System.Windows.Forms.TextBox();
            this.Ratio1_5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Ratio1_4 = new System.Windows.Forms.TextBox();
            this.Ratio1_3 = new System.Windows.Forms.TextBox();
            this.Ratio1_2 = new System.Windows.Forms.TextBox();
            this.Ratio1_1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(204, 283);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始模拟";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(389, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // performanceCounter1
            // 
            this.performanceCounter1.CategoryName = "Processor";
            this.performanceCounter1.CounterName = "% Processor Time";
            this.performanceCounter1.InstanceName = "_Total";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 157);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 121);
            this.tabControl1.TabIndex = 33;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.stiTimeBox);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 95);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基础参数";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(160, 41);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 20);
            this.label20.TabIndex = 37;
            this.label20.Text = "模拟时长：";
            // 
            // stiTimeBox
            // 
            this.stiTimeBox.Location = new System.Drawing.Point(244, 41);
            this.stiTimeBox.Margin = new System.Windows.Forms.Padding(2);
            this.stiTimeBox.Name = "stiTimeBox";
            this.stiTimeBox.Size = new System.Drawing.Size(32, 21);
            this.stiTimeBox.TabIndex = 36;
            this.stiTimeBox.Text = "100";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(425, 12);
            this.label17.TabIndex = 1;
            this.label17.Text = "说明：此页面可以调整一次模拟的时长，仅运行一次模拟，用以观察模拟的特征";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.stiNumBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(456, 95);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "模拟参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(293, 12);
            this.label19.TabIndex = 38;
            this.label19.Text = "说明：此页面可以调整模拟的次数，用以进行多次模拟";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(144, 42);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 19);
            this.label16.TabIndex = 37;
            this.label16.Text = "模拟次数";
            // 
            // stiNumBox
            // 
            this.stiNumBox.Location = new System.Drawing.Point(213, 42);
            this.stiNumBox.Margin = new System.Windows.Forms.Padding(2);
            this.stiNumBox.Name = "stiNumBox";
            this.stiNumBox.Size = new System.Drawing.Size(76, 21);
            this.stiNumBox.TabIndex = 35;
            this.stiNumBox.Text = "1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.Bed5);
            this.tabPage3.Controls.Add(this.Bed4);
            this.tabPage3.Controls.Add(this.Bed3);
            this.tabPage3.Controls.Add(this.Bed2);
            this.tabPage3.Controls.Add(this.Bed1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(456, 95);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "进阶参数";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(233, 12);
            this.label21.TabIndex = 72;
            this.label21.Text = "说明：此页面可以调整各个医院床位的数目";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(12, 64);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 19);
            this.label15.TabIndex = 71;
            this.label15.Text = "床位";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(384, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 22);
            this.label10.TabIndex = 70;
            this.label10.Text = "医院5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(304, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 22);
            this.label11.TabIndex = 69;
            this.label11.Text = "医院4";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(226, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 22);
            this.label12.TabIndex = 68;
            this.label12.Text = "医院3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(144, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 22);
            this.label13.TabIndex = 67;
            this.label13.Text = "医院2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(66, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 22);
            this.label14.TabIndex = 66;
            this.label14.Text = "医院1";
            // 
            // Bed5
            // 
            this.Bed5.Location = new System.Drawing.Point(373, 64);
            this.Bed5.Margin = new System.Windows.Forms.Padding(2);
            this.Bed5.Name = "Bed5";
            this.Bed5.Size = new System.Drawing.Size(76, 21);
            this.Bed5.TabIndex = 65;
            this.Bed5.Text = "18";
            // 
            // Bed4
            // 
            this.Bed4.Location = new System.Drawing.Point(293, 64);
            this.Bed4.Margin = new System.Windows.Forms.Padding(2);
            this.Bed4.Name = "Bed4";
            this.Bed4.Size = new System.Drawing.Size(76, 21);
            this.Bed4.TabIndex = 64;
            this.Bed4.Text = "20";
            // 
            // Bed3
            // 
            this.Bed3.Location = new System.Drawing.Point(213, 64);
            this.Bed3.Margin = new System.Windows.Forms.Padding(2);
            this.Bed3.Name = "Bed3";
            this.Bed3.Size = new System.Drawing.Size(76, 21);
            this.Bed3.TabIndex = 63;
            this.Bed3.Text = "20";
            // 
            // Bed2
            // 
            this.Bed2.Location = new System.Drawing.Point(133, 64);
            this.Bed2.Margin = new System.Windows.Forms.Padding(2);
            this.Bed2.Name = "Bed2";
            this.Bed2.Size = new System.Drawing.Size(76, 21);
            this.Bed2.TabIndex = 62;
            this.Bed2.Text = "15";
            // 
            // Bed1
            // 
            this.Bed1.Location = new System.Drawing.Point(53, 64);
            this.Bed1.Margin = new System.Windows.Forms.Padding(2);
            this.Bed1.Name = "Bed1";
            this.Bed1.Size = new System.Drawing.Size(76, 21);
            this.Bed1.TabIndex = 61;
            this.Bed1.Text = "13";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Ratio4_5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Ratio4_4);
            this.panel1.Controls.Add(this.Ratio4_3);
            this.panel1.Controls.Add(this.Ratio4_2);
            this.panel1.Controls.Add(this.Ratio4_1);
            this.panel1.Controls.Add(this.Ratio3_5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Ratio3_4);
            this.panel1.Controls.Add(this.Ratio3_3);
            this.panel1.Controls.Add(this.Ratio3_2);
            this.panel1.Controls.Add(this.Ratio3_1);
            this.panel1.Controls.Add(this.Ratio2_5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Ratio2_4);
            this.panel1.Controls.Add(this.Ratio2_3);
            this.panel1.Controls.Add(this.Ratio2_2);
            this.panel1.Controls.Add(this.Ratio2_1);
            this.panel1.Controls.Add(this.Ratio1_5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Ratio1_4);
            this.panel1.Controls.Add(this.Ratio1_3);
            this.panel1.Controls.Add(this.Ratio1_2);
            this.panel1.Controls.Add(this.Ratio1_1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 139);
            this.panel1.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(388, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 22);
            this.label9.TabIndex = 60;
            this.label9.Text = "医院5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(308, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 22);
            this.label8.TabIndex = 59;
            this.label8.Text = "医院4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(230, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 22);
            this.label7.TabIndex = 58;
            this.label7.Text = "医院3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(148, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 22);
            this.label6.TabIndex = 57;
            this.label6.Text = "医院2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(70, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 22);
            this.label5.TabIndex = 56;
            this.label5.Text = "医院1";
            // 
            // Ratio4_5
            // 
            this.Ratio4_5.Location = new System.Drawing.Point(377, 108);
            this.Ratio4_5.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio4_5.Name = "Ratio4_5";
            this.Ratio4_5.Size = new System.Drawing.Size(76, 21);
            this.Ratio4_5.TabIndex = 55;
            this.Ratio4_5.Text = "0.2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(7, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 19);
            this.label4.TabIndex = 54;
            this.label4.Text = "车站4";
            // 
            // Ratio4_4
            // 
            this.Ratio4_4.Location = new System.Drawing.Point(297, 108);
            this.Ratio4_4.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio4_4.Name = "Ratio4_4";
            this.Ratio4_4.Size = new System.Drawing.Size(76, 21);
            this.Ratio4_4.TabIndex = 53;
            this.Ratio4_4.Text = "0.2";
            // 
            // Ratio4_3
            // 
            this.Ratio4_3.Location = new System.Drawing.Point(217, 108);
            this.Ratio4_3.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio4_3.Name = "Ratio4_3";
            this.Ratio4_3.Size = new System.Drawing.Size(76, 21);
            this.Ratio4_3.TabIndex = 52;
            this.Ratio4_3.Text = "0.2";
            // 
            // Ratio4_2
            // 
            this.Ratio4_2.Location = new System.Drawing.Point(137, 108);
            this.Ratio4_2.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio4_2.Name = "Ratio4_2";
            this.Ratio4_2.Size = new System.Drawing.Size(76, 21);
            this.Ratio4_2.TabIndex = 51;
            this.Ratio4_2.Text = "0.2";
            // 
            // Ratio4_1
            // 
            this.Ratio4_1.Location = new System.Drawing.Point(57, 108);
            this.Ratio4_1.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio4_1.Name = "Ratio4_1";
            this.Ratio4_1.Size = new System.Drawing.Size(76, 21);
            this.Ratio4_1.TabIndex = 50;
            this.Ratio4_1.Text = "0.2";
            // 
            // Ratio3_5
            // 
            this.Ratio3_5.Location = new System.Drawing.Point(377, 83);
            this.Ratio3_5.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio3_5.Name = "Ratio3_5";
            this.Ratio3_5.Size = new System.Drawing.Size(76, 21);
            this.Ratio3_5.TabIndex = 49;
            this.Ratio3_5.Text = "0.2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 48;
            this.label3.Text = "车站3";
            // 
            // Ratio3_4
            // 
            this.Ratio3_4.Location = new System.Drawing.Point(297, 83);
            this.Ratio3_4.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio3_4.Name = "Ratio3_4";
            this.Ratio3_4.Size = new System.Drawing.Size(76, 21);
            this.Ratio3_4.TabIndex = 47;
            this.Ratio3_4.Text = "0.2";
            // 
            // Ratio3_3
            // 
            this.Ratio3_3.Location = new System.Drawing.Point(217, 83);
            this.Ratio3_3.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio3_3.Name = "Ratio3_3";
            this.Ratio3_3.Size = new System.Drawing.Size(76, 21);
            this.Ratio3_3.TabIndex = 46;
            this.Ratio3_3.Text = "0.2";
            // 
            // Ratio3_2
            // 
            this.Ratio3_2.Location = new System.Drawing.Point(137, 83);
            this.Ratio3_2.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio3_2.Name = "Ratio3_2";
            this.Ratio3_2.Size = new System.Drawing.Size(76, 21);
            this.Ratio3_2.TabIndex = 45;
            this.Ratio3_2.Text = "0.2";
            // 
            // Ratio3_1
            // 
            this.Ratio3_1.Location = new System.Drawing.Point(57, 83);
            this.Ratio3_1.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio3_1.Name = "Ratio3_1";
            this.Ratio3_1.Size = new System.Drawing.Size(76, 21);
            this.Ratio3_1.TabIndex = 44;
            this.Ratio3_1.Text = "0.2";
            // 
            // Ratio2_5
            // 
            this.Ratio2_5.Location = new System.Drawing.Point(377, 58);
            this.Ratio2_5.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio2_5.Name = "Ratio2_5";
            this.Ratio2_5.Size = new System.Drawing.Size(76, 21);
            this.Ratio2_5.TabIndex = 43;
            this.Ratio2_5.Text = "0.2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 42;
            this.label2.Text = "车站2";
            // 
            // Ratio2_4
            // 
            this.Ratio2_4.Location = new System.Drawing.Point(297, 58);
            this.Ratio2_4.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio2_4.Name = "Ratio2_4";
            this.Ratio2_4.Size = new System.Drawing.Size(76, 21);
            this.Ratio2_4.TabIndex = 41;
            this.Ratio2_4.Text = "0.2";
            // 
            // Ratio2_3
            // 
            this.Ratio2_3.Location = new System.Drawing.Point(217, 58);
            this.Ratio2_3.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio2_3.Name = "Ratio2_3";
            this.Ratio2_3.Size = new System.Drawing.Size(76, 21);
            this.Ratio2_3.TabIndex = 40;
            this.Ratio2_3.Text = "0.2";
            // 
            // Ratio2_2
            // 
            this.Ratio2_2.Location = new System.Drawing.Point(137, 58);
            this.Ratio2_2.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio2_2.Name = "Ratio2_2";
            this.Ratio2_2.Size = new System.Drawing.Size(76, 21);
            this.Ratio2_2.TabIndex = 39;
            this.Ratio2_2.Text = "0.2";
            // 
            // Ratio2_1
            // 
            this.Ratio2_1.Location = new System.Drawing.Point(57, 58);
            this.Ratio2_1.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio2_1.Name = "Ratio2_1";
            this.Ratio2_1.Size = new System.Drawing.Size(76, 21);
            this.Ratio2_1.TabIndex = 38;
            this.Ratio2_1.Text = "0.2";
            // 
            // Ratio1_5
            // 
            this.Ratio1_5.Location = new System.Drawing.Point(377, 33);
            this.Ratio1_5.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio1_5.Name = "Ratio1_5";
            this.Ratio1_5.Size = new System.Drawing.Size(76, 21);
            this.Ratio1_5.TabIndex = 37;
            this.Ratio1_5.Text = "0.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 36;
            this.label1.Text = "车站1";
            // 
            // Ratio1_4
            // 
            this.Ratio1_4.Location = new System.Drawing.Point(297, 33);
            this.Ratio1_4.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio1_4.Name = "Ratio1_4";
            this.Ratio1_4.Size = new System.Drawing.Size(76, 21);
            this.Ratio1_4.TabIndex = 35;
            this.Ratio1_4.Text = "0.2";
            // 
            // Ratio1_3
            // 
            this.Ratio1_3.Location = new System.Drawing.Point(217, 33);
            this.Ratio1_3.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio1_3.Name = "Ratio1_3";
            this.Ratio1_3.Size = new System.Drawing.Size(76, 21);
            this.Ratio1_3.TabIndex = 34;
            this.Ratio1_3.Text = "0.2";
            // 
            // Ratio1_2
            // 
            this.Ratio1_2.Location = new System.Drawing.Point(137, 33);
            this.Ratio1_2.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio1_2.Name = "Ratio1_2";
            this.Ratio1_2.Size = new System.Drawing.Size(76, 21);
            this.Ratio1_2.TabIndex = 33;
            this.Ratio1_2.Text = "0.2";
            // 
            // Ratio1_1
            // 
            this.Ratio1_1.Location = new System.Drawing.Point(57, 33);
            this.Ratio1_1.Margin = new System.Windows.Forms.Padding(2);
            this.Ratio1_1.Name = "Ratio1_1";
            this.Ratio1_1.Size = new System.Drawing.Size(76, 21);
            this.Ratio1_1.TabIndex = 32;
            this.Ratio1_1.Text = "0.2";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(12, 293);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 23);
            this.button3.TabIndex = 61;
            this.button3.Text = "复位";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Hospital_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 327);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Hospital_Main";
            this.Text = "医院问题模拟";
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox stiTimeBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox stiNumBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Bed5;
        private System.Windows.Forms.TextBox Bed4;
        private System.Windows.Forms.TextBox Bed3;
        private System.Windows.Forms.TextBox Bed2;
        private System.Windows.Forms.TextBox Bed1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Ratio4_5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Ratio4_4;
        private System.Windows.Forms.TextBox Ratio4_3;
        private System.Windows.Forms.TextBox Ratio4_2;
        private System.Windows.Forms.TextBox Ratio4_1;
        private System.Windows.Forms.TextBox Ratio3_5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Ratio3_4;
        private System.Windows.Forms.TextBox Ratio3_3;
        private System.Windows.Forms.TextBox Ratio3_2;
        private System.Windows.Forms.TextBox Ratio3_1;
        private System.Windows.Forms.TextBox Ratio2_5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Ratio2_4;
        private System.Windows.Forms.TextBox Ratio2_3;
        private System.Windows.Forms.TextBox Ratio2_2;
        private System.Windows.Forms.TextBox Ratio2_1;
        private System.Windows.Forms.TextBox Ratio1_5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Ratio1_4;
        private System.Windows.Forms.TextBox Ratio1_3;
        private System.Windows.Forms.TextBox Ratio1_2;
        private System.Windows.Forms.TextBox Ratio1_1;
        private System.Windows.Forms.Button button3;
    }
}