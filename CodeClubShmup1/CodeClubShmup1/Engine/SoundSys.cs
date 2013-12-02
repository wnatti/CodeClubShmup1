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
    class SoundSys
    {

        public static void PlaySong(string songName)
        {
            Song newSong = Resources.GetSong(songName);
            if (newSong  != null)
            {
                MediaPlayer.Play(newSong);
            }
        }

        public static void PauseSong()
        {
            MediaPlayer.Pause();
        }

        public static void ResumeSong()
        {
            MediaPlayer.Resume();
        }
    }
}
