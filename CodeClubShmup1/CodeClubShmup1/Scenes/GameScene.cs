using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeClubShmup1.Components;
using CodeClubShmup1.Engine;
using Microsoft.Xna.Framework;
using CodeClubShmup1.Objects;
using Microsoft.Xna.Framework.Input;

namespace CodeClubShmup1.Scenes
{
    class GameScene : SceneParent
    {
        ScrollingBackground background1;
        ScrollingBackground background2;


        List<Bullet> bullets = new List<Bullet>();
        List<Enemy> enemies = new List<Enemy>();

        Random random = new Random();
        Timer enemy_spawn_timer;

        Player player;

        public GameScene()
            :base()
        {
            enemy_spawn_timer = new Timer(2000);
            player = new Player(Resources.GetTexture("Ship"), new Vector2(100, 100), 5);
            background1 = new ScrollingBackground(new Vector2(-50, -50), 400, new Sprite(Resources.GetTexture("perkele")));
            background2 = new ScrollingBackground(new Vector2(0, 0), 300, new Sprite(Resources.GetTexture("perkele2")));

            Game1.camera.setZoom(1.5f);

            Vector2 offset =
                new Vector2(Game1.screen_size.Width, Game1.screen_size.Height) * 0.5f;

            Game1.camera.PositionOffset = offset;
            Game1.camera.setOffset(offset);
            
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (Input.IsKeyPressed(Keys.M))
            {
                SceneSys.PauseCurrentScene(true);
                SceneSys.OpenScene(new MenuScene());
            }
 

            background1.Update(dt);
            background2.Update(dt);

            
            
            if (Input.IsKeyPressed(Keys.Space) && !player.IsDead)
                bullets.Add(new Bullet(Resources.GetTexture("Bullet"), player.Position, 100));

            if (enemy_spawn_timer.Update(dt))
            {
                enemies.Add(new Enemy(Resources.GetTexture("Enemy"),
                    new Vector2(Game1.screen_size.Width,
                        player.Position.Y),
                        1000));

                enemy_spawn_timer.Delay -= 500;
                if (enemy_spawn_timer.Delay <= 0)
                     enemy_spawn_timer.Delay += 1000;


            }

           

            // Game Objects Updates
            if (!player.IsDead)
                player.Update(dt);

            foreach (Bullet item in bullets)
            {
                item.Update(dt);

                foreach (Enemy e in enemies)
                {
                    if (item.CollisionRect.Intersects(e.CollisionRect)) {
                        e.IsDead = true;
                        item.IsDead = true;
                    }
                }

                if (item.Position.X > Game1.screen_size.Width) {
                    item.IsDead = true;
                }
            }

            foreach (Enemy item in enemies)
            {
                item.Update(dt);

                if (item.Position.X < 0)
                {
                    item.IsDead = true;
                  
                }
                if (!player.IsDead)
                {
                    if (item.CollisionRect.Intersects(player.CollisionRect) )
                    {


                        if (player.IsSuojakilpi == true)
                        {
                            player.IsSuojakilpi = false;
                            item.IsDead = true;
                        }
                        else
                        {
                            player.IsDead = true;
                            item.IsDead = true;
                        }
                
                    }

                  
                    
                }
            }

                //deleting objects
                for (int i = 0; i < enemies.Count; i++)
                {
                    Enemy e = enemies[i];

                    if (e.IsDead)
                    {
                        enemies.Remove(e);
                        i--;
                    }
                }

                for (int i = 0; i < bullets.Count; i++)
                {
                    Bullet e = bullets[i];

                    if (e.IsDead)
                    {
                        bullets.Remove(e);
                        i--;
                    }
                }

                Game1.camera.Position = player.Position;

                Vector2 offset = Game1.camera.PositionOffset / Game1.camera.getZoom();

                if (Game1.camera.Position.X < offset.X)
                    Game1.camera.Position.X = offset.X;
                if (Game1.camera.Position.X > Game1.screen_size.Width - offset.X)
                    Game1.camera.Position.X = Game1.screen_size.Width - offset.X;

                if (Game1.camera.Position.Y < offset.Y)
                    Game1.camera.Position.Y = offset.Y;
                if (Game1.camera.Position.Y > Game1.screen_size.Height - offset.Y)
                    Game1.camera.Position.Y = Game1.screen_size.Height - offset.Y;
        
        }

        public override void Draw()
        {

            background1.Draw();
            background2.Draw();


            if (!player.IsDead)
                player.Draw();

            foreach (Bullet item in bullets)
            {
                item.Draw();
            }
            foreach (Enemy item in enemies)
            {
                item.Draw();
            }   
        }
    }
}
