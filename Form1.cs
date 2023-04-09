using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Kursovaia
{
    public partial class Form1 : Form
    {
        Emmiter emitter; // добавили эмиттер
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.1),
                Y = 200,
                color = Color.Aqua
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.2),
                Y = 200,
                color = Color.Gray
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.3),
                Y = 200,
                color = Color.DeepPink
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.4),
                Y = 200,
                color = Color.BlueViolet
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.1),
                Y = 600,
                color = Color.Red
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.2),
                Y = 600,
                color = Color.Orange
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.3),
                Y = 600,
                color = Color.Purple
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.4),
                Y = 600,
                color = Color.OliveDrab
            });
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
                picDisplay.Invalidate();
            }
        }
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesCount = tbDirection.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int count = 1;
            foreach (IImpactPoint impactPoint in emitter.impactPoints)
            {
                impactPoint.X = trackBar1.Value + 140 * count;
                count++;
                if (count == 5){
                    count = 1;
                }
            }
            
        }

    }
}
