using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace CodeClubShmup1.Engine
{
    class Input
    {
        static KeyboardState k_state, k_state_old;

        static MouseState m_state, m_state_old;

        public static void UpdateState() {
            k_state_old = k_state;
            k_state = Keyboard.GetState();
            m_state_old = m_state;
            m_state = Mouse.GetState();
        }
           public static bool IsKeyDown(Keys key) {
            return k_state.IsKeyDown(key);
        }

        public static bool IsKeyUp(Keys key)
        {
            return k_state.IsKeyUp(key);
        }

        public static bool IsKeyPressed(Keys key) {
            return k_state.IsKeyDown(key) && k_state_old.IsKeyUp(key);
        }

        public static bool IsKeyReleased(Keys key)
        {
            return k_state.IsKeyUp(key) && k_state_old.IsKeyDown(key);
        }

        public static bool IsButtonDown()
        {
           return m_state.LeftButton == ButtonState.Pressed;
        }

        public static bool IsButtonUp()
        {
            return m_state.LeftButton == ButtonState.Released;
        }

        public static bool IsButtonPressed()
        {
            return m_state.LeftButton == ButtonState.Pressed &&
            m_state_old.LeftButton == ButtonState.Released;
        }

        public static bool IsButtonReleased()
        {
            return m_state.LeftButton == ButtonState.Released &&
            m_state_old.LeftButton == ButtonState.Pressed;
        }

        public static Vector2 MousePosition
        {
            get
            {
                return new Vector2(m_state.X, m_state.Y);
            }
        }

    }
}
