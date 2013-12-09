using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CodeClubShmup1.Engine;

namespace CodeClubShmup1.Objects
{
    class Enemy:ObjectParent
    {

        public Enemy(Texture2D texture, Vector2 position, float speed)
            : base(texture, position, speed)
        {
            _sprite = new Sprite(texture,32,32,4,200);
        }

        public void Update(float deltaTime)
        {

            base.Update(deltaTime);
            _position -= new Vector2(1,0) * _speed * deltaTime;
        }

        public void Draw()
        {
            base.Draw();
        }
    }
}
