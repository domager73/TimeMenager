using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    class TimeManeger
    {
        private int[] initialTime;
        private int[] lastTime;
        private int MaxDayInitialTime;
        private int MaxDayFinalTime;

        private bool checkCorectNum = true;

        public TimeManeger(string initialTimeStr, string lastTimeStr)
        {
            this.initialTime = TimeTranslationFormat(initialTimeStr);
            MaxDayFinalTime = ChekCorrectFormatIntial(initialTime);

            this.lastTime = TimeTranslationFormat(lastTimeStr);
            MaxDayInitialTime = ChekCorrectFormatIntial(initialTime);
        }

        private int[] ParseIntArray(string[] str)
        {
            int[] result = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                result[i] = Convert.ToInt32(str[i]);
            }

            return result;
        }

        private int[] TimeTranslationFormat(string Time)
        {
            string[] SplitTime = Time.Split(' ');

            string[] dateTimeStr = SplitTime[0].Split('/');
            int[] datetime = ParseIntArray(dateTimeStr);

            string[] mintimeStr = SplitTime[1].Split(':');
            int[] minTime = ParseIntArray(mintimeStr);

            int[] maintTime = new int[datetime.Length + minTime.Length];
            int count = 0;
            for (int i = 0; i < datetime.Length; i++)
            {
                count = i;
                maintTime[i] = datetime[i];
            }

            for (int i = 0; i < minTime.Length; i++)
            {
                count++;
                maintTime[count] = minTime[i];
            }

            return maintTime;
        }

        public int[] GetLasttime() { return this.lastTime; }

        public int[] GetInitialTime() { return this.initialTime; }

        public void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        private int ChekCorrectFormatIntial(int[] array)
        {
            int MaxDay = 0;

            if (array[1] < 0 || array[1] > 12) 
            {
                this.checkCorectNum = false;
            }

            if (array[1] == 1 || array[1] == 3 || array[1] == 5 || array[1] == 7 ||
                array[1] == 8 || array[1] == 10 || array[1] == 12) 
            {
                if (array[0] < 0 || array[0] > 32) 
                {
                    this.checkCorectNum = false;
                }

                MaxDay = 31;
            }
            else if (array[1] == 4 || array[1] == 6 || array[1] == 9 || array[1] == 11)
            {
                if (array[0] < 0 || array[0] > 31)
                {
                    this.checkCorectNum = false;
                }

                MaxDay = 30;
            } 
            else 
            {
                if (array[0] < 0 || array[0] > 30)
                {
                    this.checkCorectNum = false;
                }

                MaxDay = 29;
            }

            if (array[3] < 0 || array[3] > 24)
            {
                this.checkCorectNum = false;
            }

            if (array[4] < 0 || array[4] > 60)
            {
                this.checkCorectNum = false;
            }

            return MaxDay;
        }

        public void TranslateHours() 
        {
            if (checkCorectNum)
            {
                BigInteger bigtime = new BigInteger();

                bigtime = this.lastTime[0] * 24 + this.lastTime[1] * 24 * MaxDayFinalTime + this.lastTime[2] * 365 * 24 + lastTime[3] -
                    (this.initialTime[0] * 24 + this.initialTime[1] * 24 * MaxDayInitialTime + this.initialTime[2] * 365 * 24 + initialTime[3]);

                Console.WriteLine($"Разница: {bigtime}(часы)");
            }
            else 
            {
                Console.WriteLine("Разница: Введено не точное значение");
            }
        }

        public void TranslateDays()
        {
            if (checkCorectNum)
            {
                BigInteger bigtime = new BigInteger();

                bigtime = this.lastTime[0] + this.lastTime[1] * MaxDayFinalTime + this.lastTime[2] * 365 + lastTime[3] / 24 -
                (this.initialTime[0] + this.initialTime[1] * MaxDayInitialTime + this.initialTime[2] * 365 + initialTime[3] / 24);

                Console.WriteLine($"Разница: {bigtime}(дни)");
            }
            else
            {
                Console.WriteLine("Разница: Введено не точное значение");
            }
        }

        public void TranslateMinutes()
        {
            if (checkCorectNum)
            {
                BigInteger bigtime = new BigInteger();

                bigtime = this.lastTime[0] * 24 * 60 + this.lastTime[1] * MaxDayFinalTime * 24 * 60 + this.lastTime[2] * 365 * 24 * 60 + lastTime[3] * 60 + initialTime[4] -
                (this.initialTime[0] * 24 * 60 + this.initialTime[1] * MaxDayInitialTime * 24 * 60 + this.initialTime[2] * 365 * 24 * 60 + initialTime[3] * 60 + initialTime[4]);

                Console.WriteLine($"Разница: {bigtime}(минуты)");
            }
            else
            {
                Console.WriteLine("Разница: Введено не точное значение");
            }
        }
    }
}
