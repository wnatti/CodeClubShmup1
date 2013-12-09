using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeClubShmup1.Components;
using CodeClubShmup1.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CodeClubShmup1.Menu;

namespace CodeClubShmup1.Scenes
{
    class HUDScene : SceneParent
    {

        string score_text = "0", gameover_text = "K", hp_text = "100";
        Vector2 gameover_pos;
        bool gameover = false;
        int hp_sourcerectangle_witdth;


        public override void Start()
        {
            var size = Resources.GetFont("SpriteFont1").MeasureString(gameover_text);
            gameover_pos = new Vector2(Game1.screen_size.Width,
                Game1.screen_size.Height) * 0.5f - new Vector2(size.X, size.Y) * 0.5f;
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }

        public override void Draw()
        {

            if (gameover)
                DrawSys.DrawText(gameover_text, Resources.GetFont("SpriteFont1"), gameover_pos, Color.Pink);

            DrawSys.DrawText(score_text, Resources.GetFont("SpriteFont1"),
                new Vector2(2, 2), Color.White);

            DrawSys.DrawText(hp_text, Resources.GetFont("SpriteFont1"),
                new Vector2(20, 2), Color.Red);
        
        }

        public void SetGameOver()
        {
            gameover = true;
        }

        public void SetScore(int points)
        {
            score_text = "" + points;
        }
        public void SetHP(int hp)
        {
            hp_text = "" + hp;
        }

    }
}
