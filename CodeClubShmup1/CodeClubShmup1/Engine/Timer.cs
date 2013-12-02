using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeClubShmup1.Engine
{
    class Timer
    {
        float currentTime, delay;

        public float Delay {
            get {
                return delay;
            }

            set {
                delay = value;
            }
        }

        public Timer(float delayMilliseconds) {
            delay = delayMilliseconds;
            currentTime = delay;
        }

        public bool Update(float deltatime) {

            currentTime -= deltatime * 1000f;

            if (currentTime < 0) {
                currentTime = delay;
                return true;
            }

            return false;
        }
    }
}
