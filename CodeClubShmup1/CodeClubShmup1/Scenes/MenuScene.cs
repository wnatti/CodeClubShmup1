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
    class MenuScene : SceneParent
    {
        Button button1;


        public override void Start()
        {
            button1 = new Button(Resources.GetTexture("button"),
                new Vector2(400, 250),
                "VITTU", Resources.GetFont("SpriteFont1"));
            button1.OnButtonPressed += onButton1Press;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            button1.Update(dt);

            if (Input.IsKeyPressed(Keys.M))
            {
                SceneSys.CloseCurrentScene();
                SceneSys.PauseCurrentScene(false);
            }
            
        }

        public override void Draw()
        {
           
            DrawSys.DrawText("C", Resources.GetFont("SpriteFont1"),
                new Vector2(100, 100), Color.Aquamarine);

            button1.Draw();
        }

        void onButton1Press()
        {
            SceneSys.GetScene(0).Paused = false;
            SceneSys.CloseCurrentScene();
        }
    }
}
