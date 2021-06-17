using System;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            
            timechange.Stop(); Bat.Stop(); Beetle.Stop();
            ManualWait.Dispose(); 
            System.Environment.Exit(0); //terminate all 
            
            /*if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);*/
          
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BeetlePos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.Label();
            this.BatPos = new System.Windows.Forms.TextBox();
            this.BatProgress = new System.Windows.Forms.ProgressBar();
            this.BeetleProgress = new System.Windows.Forms.ProgressBar();
            this.BatAttack = new System.Windows.Forms.Label();
            this.BeetleAttack = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(112, 217);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(187, 46);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(373, 217);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(202, 46);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "Pause";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.label1.Location = new System.Drawing.Point(46, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.label2.Location = new System.Drawing.Point(46, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Beetle";
            // 
            // BeetlePos
            // 
            this.BeetlePos.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.BeetlePos.Location = new System.Drawing.Point(495, 119);
            this.BeetlePos.Name = "BeetlePos";
            this.BeetlePos.Size = new System.Drawing.Size(54, 39);
            this.BeetlePos.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.label3.Location = new System.Drawing.Point(267, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 13F);
            this.textBox1.Location = new System.Drawing.Point(341, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 7;
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Result.Location = new System.Drawing.Point(281, 175);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(0, 40);
            this.Result.TabIndex = 8;
            this.Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BatPos
            // 
            this.BatPos.Font = new System.Drawing.Font("微軟正黑體", 18F);
            this.BatPos.Location = new System.Drawing.Point(495, 61);
            this.BatPos.Name = "BatPos";
            this.BatPos.Size = new System.Drawing.Size(54, 39);
            this.BatPos.TabIndex = 4;
            // 
            // BatProgress
            // 
            this.BatProgress.Location = new System.Drawing.Point(161, 61);
            this.BatProgress.Name = "BatProgress";
            this.BatProgress.Size = new System.Drawing.Size(305, 38);
            this.BatProgress.TabIndex = 9;
            // 
            // BeetleProgress
            // 
            this.BeetleProgress.Location = new System.Drawing.Point(161, 122);
            this.BeetleProgress.Name = "BeetleProgress";
            this.BeetleProgress.Size = new System.Drawing.Size(305, 38);
            this.BeetleProgress.TabIndex = 10;
            // 
            // BatAttack
            // 
            this.BatAttack.AutoSize = true;
            this.BatAttack.Location = new System.Drawing.Point(585, 61);
            this.BatAttack.Name = "BatAttack";
            this.BatAttack.Size = new System.Drawing.Size(0, 40);
            this.BatAttack.TabIndex = 11;
            // 
            // BeetleAttack
            // 
            this.BeetleAttack.AutoSize = true;
            this.BeetleAttack.Location = new System.Drawing.Point(585, 116);
            this.BeetleAttack.Name = "BeetleAttack";
            this.BeetleAttack.Size = new System.Drawing.Size(0, 40);
            this.BeetleAttack.TabIndex = 12;
            // 
            // Form1
            // 
            this.AcceptButton = this.Stop;
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(717, 292);
            this.Controls.Add(this.BeetleAttack);
            this.Controls.Add(this.BatAttack);
            this.Controls.Add(this.BeetleProgress);
            this.Controls.Add(this.BatProgress);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BeetlePos);
            this.Controls.Add(this.BatPos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BeetlePos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.TextBox BatPos;
        private System.Windows.Forms.ProgressBar BatProgress;
        private System.Windows.Forms.ProgressBar BeetleProgress;
        private System.Windows.Forms.Label BatAttack;
        private System.Windows.Forms.Label BeetleAttack;
    }
}

