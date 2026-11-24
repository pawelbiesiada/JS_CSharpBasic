using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    internal class RainFall
    {
        private int[] _rainfalls = new int[12];

        public int Average
        {
            get
            {
                var sum = 0;
                foreach (var item in _rainfalls)
                {
                    sum += item;
                }
                //sum = _rainfalls.Sum();

                return sum / _rainfalls.Length;
            }
        }
        /// <summary>
        /// Zwraca opady dla zadanego miesiaca
        /// </summary>
        /// <param name="month"> Numer miesiąca</param>
        /// <returns></returns>
        public int GetMonthlyRainfall(int month)
        {
            if (month < 1 || month > 12)
                return 0;

            return _rainfalls[month - 1];
        }
        public int GetMonthlyRainfall(Month month)
        {
            return GetMonthlyRainfall(month);
        }
        public void AddRainFall(int month, int monthlyRainfall)
        {
            if (month < 1 || month > 12)
                return;

            _rainfalls[month - 1] += monthlyRainfall;
        }
        public void AddRainFall(Month month, int monthlyRainfall)
        {
            AddRainFall(month, monthlyRainfall);
        }
        public void ImportRainFall(RainFall rainFall)
        {
            if (rainFall == null)
                return;

            for (int i = 1; i <= 12; i++)
            {
                AddRainFall(i, rainFall.GetMonthlyRainfall(i));
            }
        }
    }



    class TestRainFall
    {
        public void Run()
        {
            var rf = new RainFall();

            rf.AddRainFall(Month.January, 12);

            var july = rf.GetMonthlyRainfall(7);

            var u = UserStatus.NonActive;
            // user.SetStatus(2); // Active
            // user.SetStatus(UserStatus.Active); // Active   UserStatus.Active = 2
        }
    }

    enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
    }


    enum UserStatus
    {
        /// <summary>
        /// Nowy użytkownik, który jeszcze nie został aktywowany
        /// </summary>
        NonActive = 1,
        Active = 2,
        /// <summary>
        /// Użytkownik, który został zablokowany
        /// </summary>
        Suspended = 5
    }
}
