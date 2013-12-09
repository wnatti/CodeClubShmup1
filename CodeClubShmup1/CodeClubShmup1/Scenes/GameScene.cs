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

        int points = 0;

        Random random = new Random();
        Timer enemy_spawn_timer;

        Player player;

        HUDScene hud;

        public override void  Start()
        {
            enemy_spawn_timer = new Timer(200);
            player = new Player(Resources.GetTexture("Ship"), new Vector2(100, 100), 5);
            background1 = new ScrollingBackground(new Vector2(-50, -50), 400, new Sprite(Resources.GetTexture("perkele")));
            background2 = new ScrollingBackground(new Vector2(0, 0), 300, new Sprite(Resources.GetTexture("perkele2")));

            camera.setZoom(1.5f);

            Vector2 offset =
                new Vector2(Game1.screen_size.Width, Game1.screen_size.Height) * 0.5f;

            camera.PositionOffset = offset;
            camera.setOffset(offset);

            hud = new HUDScene();

            SceneSys.OpenScene(hud);
            
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (Input.IsKeyPressed(Keys.M))
            {
                Paused = true;
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
                        300));

            }

           

            // Game Objects Updates
            if (!player.IsDead)
                player.Update(dt);
            else
                hud.SetGameOver();

            foreach (Bullet item in bullets)
            {
                item.Update(dt);

                foreach (Enemy e in enemies)
                {
                    if (item.CollisionRect.Intersects(e.CollisionRect)) {
                        e.IsDead = true;
                        item.IsDead = true;

  
                        points += 10;
                        hud.SetScore(points);
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
                            player.HP -= 10;
                            hud.SetHP(player.HP);
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

                camera.Position = player.Position;

                if (Input.IsKeyDown(Keys.L))
                    camera.addZoom(dt);
                if (Input.IsKeyDown(Keys.K))
                    camera.addZoom(-dt);
                if (Input.IsKeyDown(Keys.O))
                    camera.addRotation(dt);
                if (Input.IsKeyDown(Keys.P))
                    camera.addRotation(-dt);

                Vector2 offset = camera.PositionOffset / camera.getZoom();

                if (camera.Position.X < offset.X)
                    camera.Position.X = offset.X;
                if (camera.Position.X > Game1.screen_size.Width - offset.X)
                    camera.Position.X = Game1.screen_size.Width - offset.X;

                if (camera.Position.Y < offset.Y)
                    camera.Position.Y = offset.Y;
                if (camera.Position.Y > Game1.screen_size.Height - offset.Y)
                    camera.Position.Y = Game1.screen_size.Height - offset.Y;
        
        }

        public override void Draw()
        {
            Backgroundcolor = Color.Black;
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
