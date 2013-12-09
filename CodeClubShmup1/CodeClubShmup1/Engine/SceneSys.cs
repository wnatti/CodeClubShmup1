using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CodeClubShmup1.Engine
{
    class SceneSys
    {
        static List<SceneParent> currentScenes = new List<SceneParent>();

        static bool sceneChanged = false;
       

        public static SceneParent GetScene(int p)
        {
            return currentScenes[p];
        }

        public static void ChangeScene(SceneParent newScene)
        {
            currentScenes.Clear();
            OpenScene(newScene);
        }

        public static void OpenScene(SceneParent newScene)
        {
            currentScenes.Add(newScene);
            newScene.Start();
            sceneChanged = true;
        }


        public static void PauseCurrentScene(bool pause)
        {
            currentScenes[currentScenes.Count() - 1].Paused = pause;
        }

        public static void CloseCurrentScene()
        {
            currentScenes.RemoveAt(currentScenes.Count() - 1);
            sceneChanged = true;
        }

        public static void Update(float dt)
        {
            for (int i = 0; i < currentScenes.Count(); i++)
            {
                SceneParent s = currentScenes[i];
                if (!s.Paused)
                {
                    s.Update(dt);
                    if (sceneChanged)
                    {
                        sceneChanged = false;
                        break;
                    }
                }
            }
        }

        public static void Draw()
        {
            foreach (SceneParent s in currentScenes)
            {
                s.DrawRender();
            }
            Game1.graphics.GraphicsDevice.SetRenderTarget(null);
            Game1.spriteBatch.Begin();

            foreach (SceneParent s in currentScenes)
            {
               DrawSys.Draw(s.render,Vector2.Zero, Color.White);
            }
            Game1.spriteBatch.End();
        }
    }
}
