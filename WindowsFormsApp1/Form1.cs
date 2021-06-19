using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static ManualResetEvent ManualWait;
        public int Total = 100;  //total length
        //private bool GameState; 
        private GameTimer timechange;  
        public Batmobile Bat;
        public Beetlemobile Beetle;
        private Thread time_thread;
        private Thread bat_thread;
        private Thread beetle_thread;

        public enum GameState
        {
            Prep,    //prepare state
            Running, 
            Pause,
            Exit  
        }
        public GameState State;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            ManualWait = new ManualResetEvent(false);
            timechange = new GameTimer(this);
            Bat = new Batmobile(this); 
            Beetle = new Beetlemobile(this);
            Bat.Attack += new EventHandler(Bat_Attack);
            Beetle.Attack += new EventHandler(Beetle_Attack);
            
            State = GameState.Prep;   //at prepare state

            //create the three time thread
            time_thread = new Thread(new ThreadStart(timechange.Run));
            bat_thread = new Thread(new ThreadStart(Bat.Run));
            beetle_thread = new Thread(new ThreadStart(Beetle.Run));

            //Start the car engine 
            Bat.StartEngine(); Beetle.StartEngine();
        }
        public delegate void InvokeFunction();
        public delegate void InvokeFunction1(int s);
        public delegate void InvokeFunction2(bool s, string st);

        public void Bat_Attack(object sender, EventArgs e)
        {
            Beetle.WeakPoint();
        }
        public void Beetle_Attack(object sender, EventArgs e)
        {
            Bat.WeakPoint(); 
        }
        /*public void GameOver(object sender,EventArgs e)
        {
            Start.
        }*/
        public void setTime(int s)
        {
            this.textBox1.Text = s.ToString() + " sec";
        }
        public void setBat()
        {
            BatProgress.Value = Bat.Miles;
            BatPos.Text = (Bat.Miles).ToString();
        }
        public void setBat(int m)
        {
            BatProgress.Value = m;
            BatPos.Text = (m).ToString();
        }
        public void setBeetle()
        {
            BeetleProgress.Value = Beetle.Miles;
            BeetlePos.Text = (Beetle.Miles).ToString();
        }
        public void setBeetle(int m)
        {
            BeetleProgress.Value = m;
            BeetlePos.Text = (m).ToString();
        }
        public void setBatAttack(bool vis,string sent)
        {
            if (vis)
                this.BatAttack.Text = sent;
            else
                this.BatAttack.Text = "";
        }
        public void setBeetleAttack(bool vis,string sent)
        {
            if(vis)
                this.BeetleAttack.Text = sent;
            else
                this.BeetleAttack.Text = "";
        }
        public void showResult(int s)
        {
            if (s == 0) this.Result.Text = "Bat wins!";
            else if (s == 1) this.Result.Text = "Beetle wins!";
            else if (s == 2) this.Result.Text = "Tie!";
            else this.Result.Text = "";
            Stop.Enabled = false;
            State = GameState.Pause;
        }
        
        private void StartGame()
        {
            bat_thread.Start(); beetle_thread.Start();time_thread.Start();
            Stop.Enabled = true; 
            Start.Text = "Restart";
            State = GameState.Running;
            ManualWait.Set();  //release at the same time
        }
        private void RestartGame()
        {   
            timechange.Stop(); Bat.Stop(); Beetle.Stop();
            ManualWait.Dispose();
            Thread.Sleep(1000);
            ManualWait = new ManualResetEvent(false);
            time_thread = new Thread(new ThreadStart(timechange.Run));
            bat_thread = new Thread(new ThreadStart(Bat.Run));
            beetle_thread = new Thread(new ThreadStart(Beetle.Run));
            
            bat_thread.Start(); beetle_thread.Start();time_thread.Start();
            State = GameState.Running; 
            Stop.Text = "Pause"; Stop.Enabled = true; 
            Result.Text = ""; 
            //Console.WriteLine("Restart");
            ManualWait.Set();
        }
        private void Start_Click(object sender, EventArgs e)
        {
            if (State == GameState.Prep)
                StartGame();
            else if(State == GameState.Running || State == GameState.Pause)
                RestartGame();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (State == GameState.Running)   //pause
            {
                State = GameState.Pause;
                Stop.Text = "Continue";
                ManualWait.Reset();
            }
            else if(State == GameState.Pause)   //continue
            {
                State = GameState.Running;
                Stop.Text = "Pause";
                ManualWait.Set();
            }
        }
        
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.S)    //Start or Restart
            { 
                if (State == GameState.Prep)
                    StartGame();
                else if (State == GameState.Running || State == GameState.Pause)
                    RestartGame();
            }
            if (e.KeyChar == (char)Keys.P)  //Pause or Continue
            {
                if (State == GameState.Running)  //pause
                {
                    State = GameState.Pause;
                    Stop.Text = "Continue";
                    ManualWait.Reset();
                }
                else if (State == GameState.Pause)   //continue
                {
                    State = GameState.Running;
                    Stop.Text = "Pause";
                    ManualWait.Set();
                }
            }
            if (State == GameState.Running)
            {
                if (e.KeyChar == (char)Keys.X)
                { 
                   
                    Bat.SpecialSkill();
                   
                    Thread batCount_thread = new System.Threading.Thread(new System.Threading.ThreadStart(Bat.show_attack.run));
                    batCount_thread.Start();
                }
                if (e.KeyChar == (char)Keys.C)
                {
                    Bat.Turbo();
                    Thread batCount_thread = new Thread(new ThreadStart(Bat.show_turbo.run));
                    batCount_thread.Start();
                }
                if (e.KeyChar == (char)Keys.M)
                {
                    Beetle.SpecialSkill();
                    Thread beetleCount_thread = new Thread(new ThreadStart(Beetle.show_attack.run));
                    beetleCount_thread.Start();
                }
                if (e.KeyChar == (char)Keys.N)
                {
                    Beetle.Turbo();
                    Thread batCount_thread = new Thread(new ThreadStart(Beetle.show_turbo.run));
                    batCount_thread.Start();
                }
            }
        }

    }
}
