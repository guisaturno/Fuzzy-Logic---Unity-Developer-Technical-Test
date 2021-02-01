using UnityEngine;

    public class Timer
    {
        //Private Variables
        private bool timing;

        //Public methods
        public bool Counting(ref float time, float baseTime)
        {
            //Verifies that the timer is updated
            if (!timing)
            {
                time = baseTime;
                timing = true;
            }

            //Verifies if countdown is over
            if (time < 0)
            {
                time = baseTime;
                timing = false;
                return false;
            }

            //Countdown
            time -= Time.fixedDeltaTime;
            return true;
        }
    }