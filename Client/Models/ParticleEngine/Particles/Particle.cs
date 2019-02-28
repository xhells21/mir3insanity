using System;
using System.Drawing;
using Client.Envir;
using SlimDX;
using Library;

namespace Client.Models.ParticleEngine
{
    public class ParticleImageInfo
    {
        public MirLibrary Library;
        public int Index;
        public Size Size = Size.Empty;

        public ParticleImageInfo(LibraryFile file, int index)
        {
            Index = index;
            if (CEnvir.LibraryList.TryGetValue(file, out Library))
                Size = Library.GetSize(index);         
        }
    }

    public class Particle
    {
        public ParticleImageInfo ImageInfo { get; set; }
        public ParticleEngine Engine { get; set; }

        public Vector2 OldPosition = Vector2.Zero;
        public Vector2 Position
        {
            get
            { return _position; }
            set
            {
                if (_position == value) return;

                OldPosition = _position;
                _position = value;
                OnPositionChanged();
            }
        }
        private Vector2 _position { get; set; }        
        
        public Vector2 Velocity { get; set; }
        public Color Color { get; set; }
        public float Size { get; set; }
        public DateTime AliveTime { get; set; }
        public bool Blend { get; set; }
        public float BlendRate { get; set; }
        TimeSpan UpdateDelay = TimeSpan.FromMilliseconds(100);
        protected DateTime NextUpdateTime { get; set; }

    public virtual void Update()
        {
            if (CEnvir.Now < NextUpdateTime) return;
            NextUpdateTime = CEnvir.Now + UpdateDelay;

            Position += Velocity;            
        }

        public void Draw()
        {
            int drawx = (int)Position.X;
            int drawy = (int)Position.Y;

            if (Blend)
                ImageInfo.Library.DrawBlend(ImageInfo.Index, drawx, drawy, Color, true, BlendRate, ImageType.Image);
            else
                ImageInfo.Library.Draw(ImageInfo.Index, drawx, drawy, Color, true, BlendRate, ImageType.Image);

        }

        protected virtual void OnPositionChanged()
        {
        }

        public virtual void OnParticleEnd()
        {
        }
    }    
}
