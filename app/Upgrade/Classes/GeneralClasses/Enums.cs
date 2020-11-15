﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrade.Classes
{
    class Enums
    {
        public enum Direction
        {
            Horizontal,
            Vertical
        }

        public enum TypeFont
        {
            Regular,
            Bold
        }

        public enum StatusTask
        {
            Empty,
            Done,
            Failed
        }

        public enum TypeBlock 
        {
            Task,
            Note,
            Target,
            Direction,
            TaskTarget,
            Schedule,
            DataService
        }

        public enum DayOfWeek
        {
            Понедельник = 1,
            Вторник = 2,
            Среда = 3,
            Четверг = 4,
            Пятница = 5,
            Суббота = 6,
            Воскресенье = 0
        };

        public enum Period 
        {
            LastWeek,
            Yesterday,
            Today,
            Tomorrow,
            CurrentWeek
        }

        public enum PeriodStatistic
        {
            today,
            week,
            month
        }

        public enum TypeAction { hide, show };
        public enum TypeTime { hour, minute };
    }
}
