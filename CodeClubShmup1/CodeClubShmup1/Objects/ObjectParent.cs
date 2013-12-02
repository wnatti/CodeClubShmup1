using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CodeClubShmup1.Engine;

namespace CodeClubShmup1.Objects
{
    public class ObjectParent
    {
        protected Sprite _sprite;

        protected Vector2 _position;
        protected float _speed;

        public Vector2 Position { get { return _position; } }
        public Rectangle CollisionRect { get; protected set; }
        public bool IsDead;
        public bool IsSuojakilpi;

        public ObjectParent(Texture2D texture, Vector2 position, float speed)
        {
            _sprite = new Sprite(texture);
            _position = position;
            _speed = speed;
      
        }

        public void Update(float deltaTime)
        {
            _sprite.Update(deltaTime);

            CollisionRect = new Rectangle((int)_position.X,(int)_position.Y,
                _sprite.FrameWidth, _sprite.FrameHeight);
        }

        public void Draw()
        {
            _sprite.Draw(_position);
        }
    }
}
