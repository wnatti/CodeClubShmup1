using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using CodeClubShmup1.Engine;

namespace CodeClubShmup1.Components
{
    class ScrollingBackground
    {
        Vector2 position;
        Vector2 startPosition;
        float speed;
        Sprite sprite;

        public ScrollingBackground(Vector2 position, float speed, Sprite sprite)
        {
            startPosition = this.position = position;
            this.speed = speed;
            this.sprite = sprite;

            this.sprite.Origin = Vector2.Zero;

        }

        public void Update(float dt)
        {
            position.X -= dt * speed;
            if (position.X < startPosition.X - sprite.FrameWidth)
                position.X = startPosition.X;
        }

        public void Draw()
        {
            sprite.Draw(position);
            sprite.Draw(position + Vector2.UnitX * sprite.FrameWidth);
        }
    }
}
