using System;

namespace Exercise_02_S2
{
    public struct Time
    {
        public int Minutes { get; set; }
        public int Hours { get; set; }

        
        public Time(int hours, int minutes)
        {
            Minutes = minutes + 60 * hours;
            Hours = hours;
        }
        public void AddMinutes(int minutes)
        {
            for(int i = 0; i < minutes; i++)
            {
                if(Minutes == 1440)
                {
                    Minutes = 0;
                    Hours = 0;
                }
                Minutes++;
                Hours = Minutes / 60;
            }
        }

        public void SubtractMinutes(int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                if (Minutes == 0)
                {
                    Minutes = 1440;
                    Hours = 0;
                }
                Minutes--;
                Hours = Minutes / 60;
            }
        }
        public override string ToString()
        {
            if(Minutes%60 == 0)
            {
                return $"{Minutes / 60}:{Minutes % 60}0";
            }
            if (Minutes % 60 < 9)
            {
                return $"{Minutes / 60}:0{Minutes % 60}".ToString();
            }
            else
            {
                return $"{Minutes / 60}:{Minutes % 60}".ToString();
            }
        }
    }
}
