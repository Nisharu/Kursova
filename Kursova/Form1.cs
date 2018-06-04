using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Kursova
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadImg();
            KeyPreview = true;
        }
        Image spaceship, landing;
        Thread threadOrbit;
        Thread thread;
        bool drawing = true;
        bool leftOrbit, OrbitLeave, Start, trigger, align, land, t1, t2;
        float angleE = 0.0f;
        float angleM = 0.0f;
        float angleMO = 0.0f;
        float distanceA, distanceR;
        float angleObjS, angleObjOrb;
        float radE = 2*149.6f;
        float radM = 2*227.9f;
        float radMO = 2*3.8f;
        float radOM = 384;
        float radObj, radObjOrb;
        float cx, cy, speed, tempspeed;
        float objSpeedS, objSpeedOrb;
        
        SolidBrush penE = new SolidBrush(Color.CadetBlue);
        SolidBrush penM = new SolidBrush(Color.PaleVioletRed);
        SolidBrush penMo = new SolidBrush(Color.DarkSlateGray);
        SolidBrush penS = new SolidBrush(Color.OrangeRed);
        RectangleF sun, moon, earth, mars, OrbitEarth, OrbitMoon, spsship;
        PointF loc = PointF.Empty;
        Graphics g = null;
        Graphics bg = null;
        Graphics obj = null;
        Graphics bgo = null;
        PointF org = PointF.Empty;
        PointF orgM = PointF.Empty;
        PointF pos = PointF.Empty;   
        PointF orgOE = Point.Empty;
        PointF orgMo = PointF.Empty;
        PointF orgObj = PointF.Empty;
        //Earth 1y, Marth 1.88y;
        //Earth 30km/sec, Mars 24 km/sec
        //Sun: 1391016 km; Earth:12742 km; Mars: 6 779 km; Moon 3474 km
        // 1 : 0,00916 : 0,00487
        // sun->earth: 149 600 000 km; sun->mars: 227 900 000 km
        // moon : earth  1 : 0,273
        // moon->earth 384400 km , 29d , 12.414
        private void Form1_Load(object sender, EventArgs e)
        {
            g = Graphics.FromImage(Graph.BackgroundImage);
            obj = Graphics.FromImage(Graph.BackgroundImage);
            bg = Graph.CreateGraphics();
            bgo = Graph.CreateGraphics();
            cx = (float)Graph.Width / 2;
            cy = (float)Graph.Height / 2;
            org = new PointF(15, 15);
            orgM = new PointF(2.25f, 2.25f);
            orgOE = new PointF(50, 50);
            orgMo = new PointF(2.75f, 2.75f);
            orgObj = org;
            sun = new RectangleF(cx-15, cy-15, 30, 30);
            earth = new RectangleF(0, 0, 5.5f, 5.5f);
            mars = new RectangleF(0, 0, 2.922f, 2.922f);
            OrbitEarth = new RectangleF(cx - 50, cy - 50, 100, 100);
            OrbitMoon = new RectangleF(0, 0, 23.7f, 23.7f);
            moon = new RectangleF(0,0,1.5f,1.5f );
            spsship = new RectangleF(0, 0, 3.5f, 5);
            pos = new PointF(0, 0);
            thread = new Thread(Draw);
            thread.IsBackground = true;
            threadOrbit = new Thread(DrawOrbit);
            threadOrbit.IsBackground = true;
            radObj = radE;
            radObjOrb = 50;
            Start = false;
            leftOrbit = false;
            OrbitLeave = false;
            trigger = false;
            align = false;
            land = false;
            t1 = t2 = false;
            objSpeedS = 0.055f;
            objSpeedOrb = 1;
            speed = 1;

        }
        private void LoadImg()
        {
            spaceship = Image.FromFile("d2b8c8dba33a42bec0a2daf0c430beff.png");
            landing = Image.FromFile("hd-aspect-1493140013-kws3wqx.jpg");
        }
        public void Draw()
        {
            while (drawing)
            {   
                
                g.Clear(Color.Black);
                g.FillEllipse(Brushes.OrangeRed, sun);
                loc = Location(radE, angleE, org);

                earth.X = loc.X - (earth.Width / 2) + sun.X;
                earth.Y = loc.Y - (earth.Height / 2) + sun.Y;

                g.FillEllipse(Brushes.CadetBlue, earth);

                loc = Location(radM, angleM, org);

                mars.X = loc.X - (mars.Width / 2) + sun.X;
                mars.Y = loc.Y - (mars.Height / 2) + sun.Y;

                g.FillEllipse(Brushes.PaleVioletRed, mars);

                loc = Location(radMO, angleMO, orgMo);

                moon.X = loc.X - (moon.Width / 2) + earth.X;
                moon.Y = loc.Y - (moon.Height / 2) + earth.Y;

                g.FillEllipse(Brushes.LightGray, moon);

                if (Start == true && leftOrbit == true)
                {   
                    if (align == true)
                    {
                      KeyPreview = false;
                      while (radObj != radM)
                        {                           
                            g.Clear(Color.Black);
                            g.FillEllipse(Brushes.OrangeRed, sun);
                            loc = Location(radE, angleE, org);

                            earth.X = loc.X - (earth.Width / 2) + sun.X;
                            earth.Y = loc.Y - (earth.Height / 2) + sun.Y;

                            g.FillEllipse(Brushes.CadetBlue, earth);

                            loc = Location(radM, angleM, org);

                            mars.X = loc.X - (mars.Width / 2) + sun.X;
                            mars.Y = loc.Y - (mars.Height / 2) + sun.Y;

                            g.FillEllipse(Brushes.PaleVioletRed, mars);

                            loc = Location(radMO, angleMO, orgMo);

                            moon.X = loc.X - (moon.Width / 2) + earth.X;
                            moon.Y = loc.Y - (moon.Height / 2) + earth.Y;

                            g.FillEllipse(Brushes.LightGray, moon);
                            if (radObj < radM)
                            {
                                radObj += 0.1f*speed;
                                t1 = true;
                            }
                            if (radObj > radM)
                            {
                                radObj -= 0.1f*speed;
                                t2 = true;
                            }
                            if (t1 == true && t2 == true)
                            {
                                t1 = t2 = false;
                                radObj = radM;
                            }

                            loc = Location(radObj, angleObjS, orgObj);
                            spsship.X = loc.X - (spsship.Width / 2) + sun.X;
                            spsship.Y = loc.Y - (spsship.Height / 2) + sun.Y;
                            g.DrawImage(spaceship, spsship);

                            bg.DrawImage(Graph.BackgroundImage, pos);

                            if (angleObjS < 360) angleObjS += objSpeedS * speed;
                            else
                            {
                                angleObjS += objSpeedS * speed;
                                angleObjS -= 360;
                            }

                            if (angleE < 360) angleE += 0.05f * speed;
                            else angleE = 0;

                            if (angleM < 360) angleM += 0.0266f * speed;
                            else
                            {
                                angleM += 0.0266f * speed;
                                angleM -= 360;
                            }

                            if (angleMO < 360) angleMO += 0.62f * speed;
                            else
                            {
                                angleMO += 0.62f * speed;
                                angleMO -= 360;
                            }
                        }
                        KeyPreview = true;
                        align = false;
                    }
                    distanceA = Math.Abs(radObj - radM);
                    distanceR = Math.Abs(angleObjS - angleM);
                    if (land = true && distanceA <= 0.5f && distanceR <= 0.5f)
                    {
                        g.DrawImage(landing,-600,0, 1820,1024);
                        bg.DrawImage(Graph.BackgroundImage, pos);
                        thread.Abort();                        
                        threadOrbit.Abort();
                        drawing = false;
                    }


                    loc = Location(radObj, angleObjS, orgObj);
                    spsship.X = loc.X - (spsship.Width / 2) + sun.X;
                    spsship.Y = loc.Y - (spsship.Height / 2) + sun.Y;
                    g.DrawImage(spaceship, spsship);

                    if (angleObjS < 360) angleObjS += objSpeedS * speed;
                    else
                    {
                        angleObjS += objSpeedS * speed;
                        angleObjS -= 360;
                    }                   
                }

                bg.DrawImage(Graph.BackgroundImage, pos);

                if (angleE < 360) angleE += 0.05f*speed;
                else angleE = 0;
                if (angleM < 360) angleM += 0.0266f*speed;
                else
                {
                    angleM += 0.0266f * speed;
                    angleM -= 360;
                }
                if (angleMO < 360) angleMO += 0.62f * speed;
                else
                {
                    angleMO += 0.62f * speed;
                    angleMO -= 360;
                }
            }

        }

        public void DrawOrbit()
        {
            while (drawing)
            {
                
                if (Start == true && leftOrbit == false)
                { 
                    if (OrbitLeave == true)
                    {
                        KeyPreview = false;
                        while (radObjOrb < 600)
                        {
                            obj.Clear(Color.Black);
                            obj.FillEllipse(Brushes.CadetBlue, OrbitEarth);
                            loc = Location(radOM, angleMO, orgOE);

                            OrbitMoon.X = loc.X - (OrbitMoon.Width / 2) + OrbitEarth.X;
                            OrbitMoon.Y = loc.Y - (OrbitMoon.Height / 2) + OrbitEarth.Y;

                            obj.FillEllipse(Brushes.LightGray, OrbitMoon);

                            loc = Location(radObjOrb, angleObjOrb, orgOE);
                            spsship.X = loc.X - (spsship.Width / 2) + OrbitEarth.X;
                            spsship.Y = loc.Y - (spsship.Height / 2) + OrbitEarth.Y;
                            obj.DrawImage(spaceship, spsship);
                            if (angleObjOrb < 360 + angleE+ 90 && trigger == false) angleObjOrb += objSpeedOrb * speed;
                            else
                            {
                                trigger = true;
                            }
                            if (trigger==true)
                            {
                                radObjOrb += 1.5f*objSpeedOrb * speed;
                                angleObjOrb += 0.025f * speed;
                            }
                            if (angleMO < 360) angleMO += 0.62f * speed;
                            else
                            {
                                angleMO += 0.62f * speed;
                                angleMO -= 360;
                            }
                            bg.DrawImage(Graph.BackgroundImage, pos);
                        }
                        OrbitLeave = false;
                        KeyPreview = true;
                    }
                    

                  if (radObjOrb >= 600)
                    {
                        leftOrbit = true;
                        angleObjS = angleE +1.3f;
                        
                    }

                    while (radObjOrb < 65)
                    {
                        obj.Clear(Color.Black);
                        obj.FillEllipse(Brushes.CadetBlue, OrbitEarth);
                        loc = Location(radOM, angleMO, orgOE);

                        OrbitMoon.X = loc.X - (OrbitMoon.Width / 2) + OrbitEarth.X;
                        OrbitMoon.Y = loc.Y - (OrbitMoon.Height / 2) + OrbitEarth.Y;

                        obj.FillEllipse(Brushes.LightGray, OrbitMoon);

                        loc = Location(radObjOrb, angleObjOrb, orgOE);
                        spsship.X = loc.X - (spsship.Width / 2) + OrbitEarth.X;
                        spsship.Y = loc.Y - (spsship.Height / 2) + OrbitEarth.Y;
                        obj.DrawImage(spaceship, spsship);
                        radObjOrb += 0.15f*speed;
                        if (angleObjOrb < 360) angleObjOrb += objSpeedOrb * speed;
                        else
                        {
                            angleObjOrb += objSpeedOrb * speed;
                            angleObjOrb -= 360;
                        }
                        if (angleMO < 360) angleMO += 0.62f * speed;
                        else
                        {
                            angleMO += 0.62f * speed;
                            angleMO -= 360;
                        }

                        bgo.DrawImage(Graph.BackgroundImage, pos);
                    }
                    obj.Clear(Color.Black);
                    obj.FillEllipse(Brushes.CadetBlue, OrbitEarth);
                    loc = Location(radOM, angleMO, orgOE);

                    OrbitMoon.X = loc.X - (OrbitMoon.Width / 2) + OrbitEarth.X;
                    OrbitMoon.Y = loc.Y - (OrbitMoon.Height / 2) + OrbitEarth.Y;

                    obj.FillEllipse(Brushes.LightGray, OrbitMoon);
                   
                    loc = Location(radObjOrb, angleObjOrb, orgOE);
                    spsship.X = loc.X - (spsship.Width / 2) + OrbitEarth.X;
                    spsship.Y = loc.Y - (spsship.Height / 2) + OrbitEarth.Y;
                    obj.DrawImage(spaceship, spsship);

                    bgo.DrawImage(Graph.BackgroundImage, pos);

                    if (angleMO < 360) angleMO += 0.62f * speed;
                    else
                    {
                        angleMO += 0.62f * speed;
                        angleMO -= 360;
                    }
                    if (angleObjOrb < 360) angleObjOrb += objSpeedOrb * speed;
                    else
                    {
                        angleObjOrb += objSpeedOrb * speed;
                        angleObjOrb -= 360;
                    }
                }
                else
                {

                    obj.Clear(Color.Black);
                    obj.FillEllipse(Brushes.CadetBlue, OrbitEarth);
                    loc = Location(radOM, angleMO, orgOE);

                    OrbitMoon.X = loc.X - (OrbitMoon.Width / 2) + OrbitEarth.X;
                    OrbitMoon.Y = loc.Y - (OrbitMoon.Height / 2) + OrbitEarth.Y;

                    obj.FillEllipse(Brushes.LightGray, OrbitMoon);
                    bgo.DrawImage(Graph.BackgroundImage, pos);

                    if (angleMO < 360) angleMO += 0.62f * speed;
                    else
                    {
                        angleMO += 0.62f * speed;
                        angleMO -= 360;
                    }
                }
            }

        }

        private void Graph_Paint(object sender, PaintEventArgs e)
        {
        }

        private void LeaveOrbit_Click(object sender, EventArgs e)
        {
            OrbitLeave = true;
        }

        public void Solar_Click(object sender, EventArgs e)
        {   

            if (MarsTravel.Text == "View Earth's Orbit")
            {
                MarsTravel.Text = "View Solar System";
                if (thread.IsAlive) thread.Suspend();
                if (threadOrbit.IsAlive) threadOrbit.Resume();
                else if (!threadOrbit.IsAlive) threadOrbit.Start();


            }

            else
            {
                MarsTravel.Text = "View Earth's Orbit";

                if (threadOrbit.IsAlive) threadOrbit.Suspend();
                if (thread.IsAlive) thread.Resume();
                else if (!thread.IsAlive) thread.Start();



            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (Start == true && leftOrbit == true)
                    {
                        radObj -= 0.1f * speed;
                        if (radObj < 100) radObj = 100;
                    }
                    else if (Start = true && leftOrbit == false)
                    {
                        radObjOrb -= 0.15f * speed;
                    }
                    break;
                case Keys.D:
                    if (Start == true && leftOrbit == true)
                    {
                        radObj += 0.1f * speed;
                        if (radObj > 500) radObj = 500;
                    }
                    else if (Start = true && leftOrbit == false)
                    {
                        radObjOrb += 0.15f * speed;
                    }
                    break;
                case Keys.W:
                    if (Start == true && leftOrbit == true)
                    {
                        if (objSpeedS < 0.1)
                        {
                            objSpeedS += 0.0025f;
                        }
                    }
                    else if (Start = true && leftOrbit == false)
                    {
                        if (objSpeedOrb < 1.5f)
                        {
                            objSpeedOrb += 0.025f;
                        }
                    }
                    break;
                case Keys.S:
                    if (Start == true && leftOrbit == true)
                    {
                        if (objSpeedS > 0.005f)
                        {
                            objSpeedS -= 0.0025f;
                        }
                    }
                    else if (Start = true && leftOrbit == false)
                    {
                        if (objSpeedOrb > 0.5f)
                        {
                            objSpeedOrb -= 0.025f;
                        }

                    }
                    break;
                default:
                    break;
                
            }

        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (PauseButton.Text == "Pause")
            {
                tempspeed = speed;
                speed = 0;
                PauseButton.Text = "Resume";
            }
            else
            {
                PauseButton.Text = "Pause";
                speed = tempspeed;
            }
            
        }
        private void Align_Click(object sender, EventArgs e)
        {
            align = true;
        }

        private void Land_Click(object sender, EventArgs e)
        {
            if (Land.Text == "Prepare for Landing")
            {
                land = true;
                Land.Text = "Cancell Landing";
            }
            else
            {
                Land.Text = "Prepare for Landing";
                land = false;
            }

        }

        private void Lauch_Click(object sender, EventArgs e)
        {
            Start = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            speed = (float)numericUpDown1.Value;
        }
        public PointF Location(float radius, float angleInDegrees, PointF origin)
        {
            float x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.X;
            float y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.Y;
            return new PointF(x, y);
        }

    }
}
