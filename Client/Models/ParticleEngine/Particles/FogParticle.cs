using System;
using Client.Envir;
using SlimDX;

namespace Client.Models.ParticleEngine
{
    public class FogParticle : Particle
    {
        private static int xwidth = (int)(512 * (Math.Ceiling(Config.GameSize.Width / 512M) + 2));
        private static int ywidth = (int)(512 * (Math.Ceiling(Config.GameSize.Height / 512M) + 2));
        private Vector2 xreset = new Vector2(xwidth, 0);
        private Vector2 yreset = new Vector2(0, ywidth);

        public FogParticle(ParticleEngine engine, ParticleImageInfo image)
        {
            Engine = engine;
            ImageInfo = image;
        }

        public override void Update()
        {
            if (CEnvir.Now < NextUpdateTime) return;

            NextUpdateTime = CEnvir.Now.AddMilliseconds(20);
            Position += Velocity;
        }

        protected override void OnPositionChanged()
        {
            if (Position.Y < -ImageInfo.Size.Height * 2)
                Position += yreset;
            else if (Position.Y > Config.GameSize.Height + ImageInfo.Size.Height)
                Position -= yreset;
            else if (Position.X < -ImageInfo.Size.Width * 2)
                Position += xreset;
            else if (Position.X > Config.GameSize.Width + ImageInfo.Size.Width)
                Position -= xreset;
        }
    }    
}
