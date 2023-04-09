using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaia
{
    public class GravityPoint : IImpactPoint

    {
        public int size = 100;
        public int Power = 100; 
        public Color color= Color.White;
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
            {
                // то притягиваем ее
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }

        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(color),
                   X - size / 2,
                   Y - size / 2,
                   size,
                   size
               );
        }
    }
}
