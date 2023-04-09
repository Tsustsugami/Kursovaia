using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                Y = picDisplay.Height / 2,
                color = Color.Aqua
            }) ;
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.2),
                Y = picDisplay.Height / 2,
                color = Color.Gray
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.3),
                Y = picDisplay.Height / 2,
                color = Color.DeepPink
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.4),
                Y = picDisplay.Height / 2,
                color =Color.BlueViolet
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.5),
                Y = picDisplay.Height / 2,
                color = Color.Red
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.6),
                Y = picDisplay.Height / 2,
                color = Color.AliceBlue
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.7),
                Y = picDisplay.Height / 2,
                color = Color.Purple
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.8),
                Y = picDisplay.Height / 2,
                color = Color.OliveDrab
            });
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.9),
                Y = picDisplay.Height / 2,
                color = Color.Orange
            });
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // а тут теперь рендерим через эмиттер
                picDisplay.Invalidate();
            }
        }
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesCount = tbDirection.Value;
            tbDirection.Text = $"{tbDirection.Value}°"; // добавил вывод значения
        }
    }
}
