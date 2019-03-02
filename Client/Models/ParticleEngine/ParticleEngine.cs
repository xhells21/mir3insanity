using System.Collections.Generic;
using System;
using System.Drawing;
using Client.Envir;
using SlimDX;

namespace Client.Models.ParticleEngine
{
    public enum ParticleType
    {
        None = 0,
        Fog,
        BurningFog,
        BurningFogEmber,
    }

    public class ParticleEngine
    {    
        public Vector2 EmitterLocation { get; set; }
        protected List<Particle> particles;
        protected List<ParticleImageInfo> Textures;
        public Vector2 ForceVelocity = Vector2.Zero;
        public bool GenerateParticles;
        public DateTime NextParticleTime;

        public ParticleEngine(List<ParticleImageInfo> textures, Vector2 location)
        {
            EmitterLocation = location;
            Textures = textures;
            particles = new List<Particle>();
            GenerateParticles = true;
        }

        public virtual Particle GenerateNewParticle(ParticleType type)
        {
            Particle particle = null;
            switch (type)
            {
                case ParticleType.None:
                    
                    particle = new Particle()
                    {
                        Engine = this,
                        ImageInfo = Textures[CEnvir.Random.Next(Textures.Count)],
                        Color = Color.FromArgb(CEnvir.Random.Next(255), CEnvir.Random.Next(255), CEnvir.Random.Next(255)),
                        Size = (float)CEnvir.Random.NextDouble(),
                        AliveTime = CEnvir.Now.AddSeconds(1 + CEnvir.Random.Next(2)),
                        Blend = true,
                        BlendRate = 1.0F,
                    };                    

                    particles.Add(particle);
                    break;
                case ParticleType.Fog:

                    particle = new FogParticle(this, Textures[CEnvir.Random.Next(Textures.Count)])
                    {
                        Color = Color.White,
                        Size = 1F,
                        AliveTime = DateTime.MaxValue,
                        BlendRate = 0.4F,
                    };

                    particles.Add(particle);
                    break;
                case ParticleType.BurningFog:

                    particle = new FogParticle(this, Textures[CEnvir.Random.Next(Textures.Count)])
                    {
                        Color = Color.FromArgb(255, 100, 0, 0),
                        Size = 1F,
                        AliveTime = DateTime.MaxValue,
                        BlendRate = 0.5F,
                    };

                    particles.Add(particle);
                    break;
                case ParticleType.BurningFogEmber:
                    particle = new Particle()
                    {
                        Engine = this,
                        ImageInfo = Textures[CEnvir.Random.Next(Textures.Count)],
                        Color = Color.DarkRed,
                        Size = (float)CEnvir.Random.NextDouble(),
                        AliveTime = CEnvir.Now.AddSeconds(1 + CEnvir.Random.Next(2)),
                        Blend = true,
                        BlendRate = 0.35F,
                        Position = new Vector2(CEnvir.Random.Next(Config.GameSize.Width), CEnvir.Random.Next(Config.GameSize.Height / 2, Config.GameSize.Height)),
                        Velocity = new Vector2(0, -2F * CEnvir.Random.Next(3)),
                    };

                    particles.Add(particle);
                    break;
            }

            return particle;
        }

        protected Particle FindParticleFromLocation(Vector2 positon)
        {
            foreach (Particle particle in particles)
            {
                if (particle.Position == positon)
                    return particle;
            }

            return null;
        }

        public virtual void Update()
        {
            if (GenerateParticles && CEnvir.Now > NextParticleTime)
            {
                NextParticleTime = CEnvir.Now.AddMilliseconds(20);
                GenerateNewParticle(ParticleType.BurningFogEmber);
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {                
                particles[particle].Update();
                if (CEnvir.Now > particles[particle].AliveTime)
                {
                    particles[particle].OnParticleEnd();
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public virtual void Draw()
        {
            for (int index = 0; index < particles.Count; index++)
                particles[index].Draw();
        }

        public void ParticlesOffSet(Point offset)
        {
            for (int particle = 0; particle < particles.Count; particle++)
                particles[particle].Position += new Vector2(offset.X, offset.Y);
        }

        public void Dispose()
        {
            for (int i = particles.Count - 1; i > 0; i--)
                particles.RemoveAt(i);
            particles = null;

            for (int i = Textures.Count - 1; i > 0; i--)
                Textures.RemoveAt(i);
            Textures = null;

            EmitterLocation = Vector2.Zero;
            ForceVelocity = Vector2.Zero;
        }


    }
}
