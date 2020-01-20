namespace 工工综合实验模拟
{
    partial class Single_Hospital_Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.stiDays = new System.Windows.Forms.NumericUpDown();
            this.dataSwitch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ruleSwitch = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stiDays)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "模拟天数";
            // 
            // stiDays
            // 
            this.stiDays.Location = new System.Drawing.Point(144, 23);
            this.stiDays.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.stiDays.Name = "stiDays";
            this.stiDays.Size = new System.Drawing.Size(120, 25);
            this.stiDays.TabIndex = 1;
            this.stiDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dataSwitch
            // 
            this.dataSwitch.FormattingEnabled = true;
            this.dataSwitch.Items.AddRange(new object[] {
            "数据1",
            "数据2"});
            this.dataSwitch.Location = new System.Drawing.Point(144, 65);
            this.dataSwitch.Name = "dataSwitch";
            this.dataSwitch.Size = new System.Drawing.Size(121, 23);
            this.dataSwitch.TabIndex = 2;
            this.dataSwitch.Text = "数据1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "时变数据";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "换班规则";
            // 
            // ruleSwitch
            // 
            this.ruleSwitch.FormattingEnabled = true;
            this.ruleSwitch.Items.AddRange(new object[] {
            "规则1",
            "规则2",
            "规则3"});
            this.ruleSwitch.Location = new System.Drawing.Point(144, 102);
            this.ruleSwitch.Name = "ruleSwitch";
            this.ruleSwitch.Size = new System.Drawing.Size(121, 23);
            this.ruleSwitch.TabIndex = 5;
            this.ruleSwitch.Text = "规则1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "开始模拟";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Single_Hospital_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 259);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ruleSwitch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataSwitch);
            this.Controls.Add(this.stiDays);
            this.Controls.Add(this.label1);
            this.Name = "Single_Hospital_Main";
            this.Text = "单医院问题模拟";
            ((System.ComponentModel.ISupportInitialize)(this.stiDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown stiDays;
        private System.Windows.Forms.ComboBox dataSwitch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ruleSwitch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}