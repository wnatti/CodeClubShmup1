using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CodeClubShmup1.Engine
{
    class SceneParent
    {
        public bool Paused = false;

        protected Color Backgroundcolor = Color.Transparent;

        GraphicsDevice g;
        public RenderTarget2D render;

        protected Camera camera;

        public SceneParent()
        {
            g = Game1.graphics.GraphicsDevice;
            render = new RenderTarget2D(g,
                (int)(g.PresentationParameters.BackBufferWidth),
                (int)(g.PresentationParameters.BackBufferHeight),
                false,
                g.PresentationParameters.BackBufferFormat,
                g.PresentationParameters.DepthStencilFormat
                );
            camera = new Camera(Game1.graphics);

        }

        public virtual void Start() 
        {
 
        }

        public virtual void Update(float dt)
        {
           
        }

        public virtual void Draw()
        { 
        }

        public void DrawRender()
        {
            g.SetRenderTarget(render);
            g.Clear(Backgroundcolor);

            Game1.spriteBatch.Begin(SpriteSortMode.Immediate,
                null, null, null, null, null, camera.update());

            Draw();

            Game1.spriteBatch.End();
        }
    }
}
