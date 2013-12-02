using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CodeClubShmup1.Engine
{
    class Resources
    {
        static ContentManager content;

        private static Dictionary<string, Texture2D> texture2Ds;

        private static Dictionary<string, SpriteFont> fonts;

        private static Dictionary<string, Song> songs;
        private static Dictionary<string, SoundEffect> soundEffects;

        public static void Init(ContentManager cont)
        {
            content = cont;

            texture2Ds = new Dictionary<string, Texture2D>();
            fonts = new Dictionary<string, SpriteFont>();

            songs = new Dictionary<string, Song>();
            soundEffects = new Dictionary<string, SoundEffect>();
        }

        public static void LoadSong(string songName)
        {
            Song newSong = content.Load<Song>(songName);
            songs.Add(songName, newSong);
        }

        public static void LoadSoundEffect(string effectName)
        {
            SoundEffect newEffect = content.Load<SoundEffect>(effectName);
            soundEffects.Add(effectName, newEffect);
        }

        public static void LoadTexture2D(string textureName)
        {
            Texture2D newTexture = content.Load<Texture2D>(textureName);
            texture2Ds.Add(textureName, newTexture);
        }

        public static void LoadFont(string fontName)
        {
            SpriteFont newFont = content.Load<SpriteFont>(fontName);
            fonts.Add(fontName, newFont);
        }

        public static Texture2D GetTexture(string textureName)
        {
            if (texture2Ds.ContainsKey(textureName))
            {
                return texture2Ds[textureName];
            }
            else
            {
                Console.WriteLine("Error: GetTexture " + textureName + " null");
                return null;
            }
        }

        public static SpriteFont GetFont(string fontName)
        {
            if (fonts.ContainsKey(fontName))
            {
                return fonts[fontName];
            }
            else
            {
                Console.WriteLine("Error: GetFont " + fontName + " null");
                return null;
            }
        }

        public static Song GetSong(string songName)
        {
            if (songs.ContainsKey(songName))
            {
                return songs[songName];
            }
            else
            {
                Console.WriteLine("Error: GetSong " + songName + " null");
                return null;
            }
        }

        public static SoundEffect GetSoundEffect(string effectName)
        {
            if (soundEffects.ContainsKey(effectName))
            {
                return soundEffects[effectName];
            }
            else
            {
                Console.WriteLine("Error: GetSoundEffect " + effectName + " null");
                return null;
            }
        }

    }
}
