using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CodeClubShmup1.Engine;

namespace CodeClubShmup1.Menu
{
    public class Button
    {
        protected Sprite _sprite;

        protected Vector2 _position;

        public Action OnButtonPressed;

        public Vector2 Position { get { return _position; } }
        public Rectangle CollisionRect { get; protected set; }

        public Button(Texture2D texture, Vector2 position)
        {
            _sprite = new Sprite(texture);
            _position = position;
        }

        public void Update(float deltaTime)
        {
            _sprite.Update(deltaTime);

            CollisionRect = new Rectangle(
                (int)(_position.X - _sprite.Origin.X),
                (int)(_position.Y - _sprite.Origin.Y),
                _sprite.FrameWidth, _sprite.FrameHeight);
            if (Input.IsButtonPressed())
            {
                if (CollisionRect.Contains(
                    (int)Input.MousePosition.X,
                    (int)Input.MousePosition.Y))
                {
                    if (OnButtonPressed != null)
                        OnButtonPressed();
                }
            }
        }

        public void Draw()
        {
            _sprite.Draw(_position);
        }
    }
}
