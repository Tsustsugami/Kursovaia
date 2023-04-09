using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaia
{
    public class Emmiter
    {
        public List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();
        public float GravitationX = 0;
        public float GravitationY = 1;
        public int ParticlesCount = 500;
        public int SpeedMin = 1; 
        public int SpeedMax = 10; 
        public int RadiusMin = 2; 
        public int RadiusMax = 10; 
        public int LifeMin = 20;
        public int LifeMax = 200; 
        public int ParticlesPerTick = 1;
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;
            foreach (var particle in particles)
            {
                particle.Life -= 1; 
                if (particle.Life < 0)
                {
                    ResetParticle(particle);

                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1; 
                        ResetParticle(particle);
                    }
                }
                else
                {
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < ParticlesCount) 
                {
                    var particle = new Particle();
                    particle.FromColor = Color.White;
                    particle.ToColor = Color.FromArgb(0, Color.Black);
                    particles.Add(particle);
                    ResetParticle(particle); 
                }
                else
                {
                    break;
                }
            }
        }
        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
            foreach (var point in impactPoints) 
            {
                point.Render(g); 
            }
        }
        public virtual void ResetParticle(Particle particle)
        {

            particle.Life = Particle.rand.Next(LifeMin, LifeMax);
            var speed = Particle.rand.Next(SpeedMin, SpeedMax);
            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }
    }
}
