using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CodeClubShmup1.Engine
{
    public class Sprite
    {
        Timer frameTimer;

        public Texture2D texture{get;private set;}
        public Rectangle SourceRectangle{get;set;}

        public int Width{get { return texture.Width; }}
        public int Height{get { return texture.Height; }}
        public int FrameWidth { get { return frameWidth; } }
        public int FrameHeight { get { return frameHeight; } }

        private int frameWidth, frameHeight;
        private int currentFrame, frameCount;

        public Color Tint { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public float Scale { get; set; }
        public SpriteEffects spriteEffects { get; set; }
        public float Depth { get; set; }

        public Sprite(Texture2D texture)
        {
            this.texture = texture;
            SourceRectangle = texture.Bounds;
            Tint = Color.White;
            Rotation = 0.0f;
            Origin = new Vector2(Width / 2, Height / 2);
            Scale = 1;
            spriteEffects = SpriteEffects.None;
            Depth = 0;

            frameWidth = Width;
            frameHeight = Height;

            frameCount = 0;
        }

        public Sprite(Texture2D texture, int frameWidth, int frameHeight, int frameCount, float frameTime = 200)
            :this(texture)
        {
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.currentFrame = 0;

            Origin = new Vector2(frameWidth / 2, frameHeight / 2);

            SourceRectangle = new Rectangle(0, 0, frameWidth, frameHeight);

            frameTimer = new Timer(frameTime);
        }

        public void Update(float dt)
        {
            if (frameCount != 0 && frameTimer.Update(dt))
            {
                currentFrame = (currentFrame + 1) % frameCount;

                SourceRectangle = new Rectangle((currentFrame * frameWidth) % texture.Width,
                                                ((currentFrame * frameWidth) / texture.Width) * frameHeight,
                                                frameWidth,
                                                frameHeight);
            }
        }

        public void Draw(Vector2 position)
        {
            DrawSys.Draw(texture, position, SourceRectangle, Tint, Origin, Rotation, Scale, spriteEffects, Depth);
        }
    }
}
