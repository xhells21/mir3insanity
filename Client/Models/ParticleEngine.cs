/*using System;
using System.Collections.Generic;
using System.Drawing;
using Client.Envir;
using SlimDX;
using Library;

namespace Client.Models
{
    public class ParticleImageInfo
    {
        public MirLibrary Library;
        public int Index;

        public ParticleImageInfo(LibraryFile file, int index)
        {
            CEnvir.LibraryList.TryGetValue(file, out Library);
            Index = index;
        }
    }

    public class Particle
    {
        public ParticleImageInfo Image { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Color Color { get; set; }
        public float Size { get; set; }
        public int AliveTick { get; set; }
        public bool Blend { get; set; }
        public float BlendRate { get; set; }

        public Particle() { }

        public virtual void Update()
        {
            AliveTick--;
            Position += Velocity;
        }

        public void Draw()
        {
            int drawx = (int)Position.X;
            int drawy = (int)Position.Y;

            if (Blend)
                Image.Library.DrawBlend(Image.Index, drawx, drawy, Color.Maroon, true, 0.4F, ImageType.Image);
            else
                Image.Library.Draw(Image.Index, drawx, drawy, Color.White, true, 1.0F, ImageType.Image);

        }

        public virtual void OnParticleEnd()
        {
        }
    }

    public class ParticleEngine
    {

        protected Random random;
        public Vector2 EmitterLocation { get; set; }
        protected List<Particle> particles;
        protected List<ParticleImageInfo> Textures;
        public Vector2 ForceVelocity = Vector2.Zero;
        protected DateTime NextParticle;

        public ParticleEngine(List<ParticleImageInfo> textures, Vector2 location)
        {
            EmitterLocation = location;
            Textures = textures;
            particles = new List<Particle>();
            random = new Random();
            NextParticle = CEnvir.Now;
        }

        public void GenerateNewParticle()
        {
            if (CEnvir.Now < NextParticle) return;

            NextParticle = CEnvir.Now.AddMilliseconds(100);
            Particle part;
            part = new Particle()
            {
                Image = Textures[random.Next(Textures.Count)],
                Position = new Vector2(random.Next(Config.GameSize.Width), Config.GameSize.Height),
                Velocity = ForceVelocity == Vector2.Zero ? new Vector2(0, 0.1F * (float)(random.NextDouble() * -1)) : ForceVelocity,
                Color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)),
                Size = (float)random.NextDouble(),
                AliveTick = 20000,
                Blend = true,
            };

            particles.Add(part);
        }

        public void Update()
        {
            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].AliveTick <= 0)
                {
                    particles[particle].OnParticleEnd();
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw()
        {
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw();
            }
        }
    }
}*/
