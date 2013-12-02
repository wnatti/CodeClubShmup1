using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CodeClubShmup1.Engine
{
    class DrawSys
    {
        static SpriteBatch _sb;

        public static void InitSpriteBatch(SpriteBatch sb)
        {
            _sb = sb;
        }

        public static void Draw(Texture2D tex, Vector2 pos)
        {
            _sb.Draw(tex, pos, Color.White);
        }

        public static void Draw(Texture2D tex, Vector2 pos, Color col)
        {
            _sb.Draw(tex, pos, col);
        }

        public static void Draw(Texture2D tex, Vector2 pos, Rectangle sourceRectangle, Color col, Vector2 offset,
                                float rotation = 0, float scale = 1, SpriteEffects effect = SpriteEffects.None, float depth = 0)
        {
            _sb.Draw(tex, pos, sourceRectangle, col, rotation, offset, scale, effect, depth);
        }

        public static void DrawText(string text, SpriteFont font, Vector2 pos, Color color)
        {
            _sb.DrawString(font, text, pos, color);
        }

        public static void DrawText(string text, SpriteFont font, Vector2 pos, Color color, Vector2 offset, 
            float rotation = 0, float scale = 1, SpriteEffects effect = SpriteEffects.None, float depth = 0)
        {
            _sb.DrawString(font, text, pos, color, rotation, offset, scale, effect, depth);
        }
    }
}
