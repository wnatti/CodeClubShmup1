using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CodeClubShmup1.Engine
{

    public class Camera
    {
        Matrix Cam;
        Viewport screen;

        public Vector2 Position, PositionOffset;
        Vector2 Zoom, Offset;
        float rotation;

        public Camera(GraphicsDeviceManager gfx)
        {
            Cam = Matrix.Identity;
            Position = Vector2.Zero;
            Zoom = Vector2.One;
            rotation = 0;

            screen = gfx.GraphicsDevice.Viewport;
        }

        public Matrix update()
        {
            Cam = Matrix.CreateTranslation(
                new Vector3(-Position, 0))
                * Matrix.CreateTranslation(new Vector3(PositionOffset, 0))
                * Matrix.CreateTranslation(new Vector3(-Offset, 0))

                * Matrix.CreateRotationZ(rotation)
                * Matrix.CreateScale(new Vector3(Zoom, 1))
                * Matrix.CreateTranslation(new Vector3(Offset, 0))

            ;
            return Cam;
        }

        public void addRotation(float rot)
        {
            rotation += rot;
        }
        public void setRotation(float rot)
        {
            rotation = rot;
        }

        public void setOffset(Vector2 offset)
        {
            Offset = offset;
        }
        public Vector2 getOffset()
        {
            return Offset;
        }

        public void setZoom(float zoom)
        {
            Zoom = new Vector2(zoom, zoom);
        }

        public void addZoom(float zoom)
        {
            Zoom.X += zoom;
            Zoom.Y += zoom;
        }

        public Vector2 getZoom()
        {
            return Zoom;
        }


    }
}