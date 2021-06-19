using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1;

public static class ObjectExtension
{
    public static void RaiseEvent(this object obj, EventHandler handler, EventArgs e)
    {
        if (handler == null)
            return;;
        handler(obj, e);
    }
    public static void RaiseEvent<TEventArgs>(this object obj, EventHandler<TEventArgs> handler, TEventArgs e) where TEventArgs : EventArgs
    {
        if (handler == null)
            return;
        handler(obj, e);
    }
}

public class GameTimer
{
    public Form1 form;
    public Boolean state = true;
    public int s;
    public GameTimer(Form1 form1)
    {
        form = form1;
        s = 0;
    }
    public void Stop()
    {
        state = false;
    }
    public void Run() 
    {

        s = 0;  state = true;
        while (state)
        {
            Thread.Sleep(20);
            Form1.ManualWait.WaitOne(Timeout.Infinite);
            s++;

            if (state)
            { 
                form.Invoke(new Form1.InvokeFunction1(form.setTime), new object[] { s });
                Thread.Sleep(30);
                form.Invoke(new Form1.InvokeFunction(form.setBat), null);
                form.Invoke(new Form1.InvokeFunction(form.setBeetle), null);
            }

            if (form.Bat.Miles >= form.Total || form.Beetle.Miles >= form.Total)
            {
                Form1.ManualWait.Reset();  //terminate all the threads
                int r;
                if (form.Bat.Miles > form.Beetle.Miles) r = 0;
                else if (form.Bat.Miles < form.Beetle.Miles) r = 1;
                else r = 2;
                form.Invoke(new Form1.InvokeFunction1(form.showResult), new object[] { r });
                break;
            }
            System.Threading.Thread.Sleep(1000);
        }
        form.Bat.Stop(); form.Beetle.Stop();
    }
}

public class Vehicle
{
    public Form1 form;
    public Boolean state = true;
    public Boolean turbo = false;
    public int s;
    public int speed, miles;
    public int Miles
    {
        get { return miles; }
        set { miles = value; }
    }
    public bool on;
    public int backwardStep;
    public CountDown show_attack;
    public CountDown show_turbo;

    //public Vehicle();

    public void StartEngine() { on = true; }
    public void Stop()
    {
        state = false;
        speed = 0;
    }
    public virtual void Run() { }     
    public virtual void Turbo() { }    //double the speed
    public virtual void SpecialSkill() { }  //attack
    public virtual void WeakPoint() { }
    
}
public class Batmobile : Vehicle
{
    public Batmobile(Form1 f)
    {
        form = f;
        miles = 0; backwardStep = speed; on = false;
        show_attack = new CountDown(form,500,0,"Attack");
        show_turbo = new CountDown(form,500,0, "Turbo");

    }
    public override void Run()
    {
        miles = 0; state = true;
        var rand = new Random();
        speed = rand.Next(1, 11);
        backwardStep = speed;
        while (state)
        {
            Form1.ManualWait.WaitOne(Timeout.Infinite);

            if (turbo)
            {
                miles += speed * 2;
                turbo = false;
            }
            else
            {
                miles += speed;
            }
            if (miles > 100) miles = 100;
            System.Threading.Thread.Sleep(1000);
        }
    }
    public override void Turbo()
    {
        turbo = true;
    }
    public override void SpecialSkill()
    {
        this.RaiseEvent(Attack, EventArgs.Empty);
    }
    public override void WeakPoint()
    {
        if (miles > backwardStep)
            miles -= 2*backwardStep;
        else
            miles = 0;
    }
    public event EventHandler Attack;
}

public class Beetlemobile : Vehicle
{
    public Beetlemobile(Form1 f)
    {
        form = f;
        miles = 0; backwardStep = speed; on = false;
        show_attack = new CountDown(form, 500, 1, "Attack");
        show_turbo = new CountDown(form, 500, 1, "Turbo");
    }

    public override void Run()      
    {
        miles = 0; state = true;
        Thread.Sleep(20);
        var rand = new Random();
        speed = rand.Next(1, 11);
        backwardStep = speed;
        while (state)
        {
            Form1.ManualWait.WaitOne(Timeout.Infinite);
            //true: pause, false: continue

            if (turbo)
            {
                miles += speed * 2;
                turbo = false;
            }
            else
            {
                miles += speed;
            }
            if (miles > 100) miles = 100;
            System.Threading.Thread.Sleep(1000);
        }
    }
    public override void Turbo()
    {
        turbo = true;
    }
    public override void SpecialSkill()
    {
        this.RaiseEvent(Attack, EventArgs.Empty);
    }
    public override void WeakPoint() {
        if (miles > backwardStep)
            miles -= 2*backwardStep;
        else
            miles = 0;
    }
    public event EventHandler Attack;  
}

public class CountDown  //to show "Attack" for 1 sec 
{
    private Form1 form;
    private int s, car;
    private string show;

    public CountDown(Form1 form1,int Total,int car_type,string output)
    {
        form = form1;
        s = Total;
        car = car_type;
        show = output;
    }

    public void run()
    {
        if (car == 0)
        {
            form.Invoke(new Form1.InvokeFunction2(form.setBatAttack), new object[] { true, show });
            System.Threading.Thread.Sleep(s);//停一秒
            form.Invoke(new Form1.InvokeFunction2(form.setBatAttack), new object[] { false, show });
        }
        else
        {
            form.Invoke(new Form1.InvokeFunction2(form.setBeetleAttack), new object[] { true, show });
            System.Threading.Thread.Sleep(s);//停一秒
            form.Invoke(new Form1.InvokeFunction2(form.setBeetleAttack), new object[] { false, show });
        }
    }
}