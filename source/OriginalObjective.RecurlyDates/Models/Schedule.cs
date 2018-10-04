using System;
using System.Collections.Generic;
using OriginalObjective.RecurlyDates.Enums;

namespace OriginalObjective.RecurlyDates.Models
{
    public class Schedule
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Recurrence Recurrence { get; set; }
        public int WeeklyRecurrencePattern { get; set; }
        public bool[] DailyRecurrencePattern { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public RecurrencePatternSpecificer RecurrencePatternSpecificer { get; set; }
        public DayTypeSpecifier DayTypeSpecifier { get; set; }
        public int Month { get; set; }

        public IEnumerable<DateTime> GetDates()
        {
            IEnumerable<DateTime> dates;

            switch (Recurrence)
            {
                case Recurrence.None:
                    dates = NoRecurrence();
                    break;

                case Recurrence.Daily:
                    dates = DailyRecurrence();
                    break;

                case Recurrence.Weekly:
                    dates = WeeklyRecurrence();
                    break;

                case Recurrence.Monthly:
                    dates = MonthlyRecurrence();
                    break;

                case Recurrence.Annually:
                    dates = AnnualRecurrence();
                    break;

                default:
                    dates = NoRecurrence();
                    break;
            }

            return dates;
        }

        private IEnumerable<DateTime> AnnualRecurrence()
        {
            var dates = new List<DateTime>();

            if (RecurrenceType == RecurrenceType.UseStartDate)
            {
                for (var date = StartDate; date <= EndDate; date = date.AddYears(1))
                {
                    dates.Add(date);
                }
            }
            else
            {
                for (var date = StartDate; date <= EndDate; date = date.AddDays(1))
                {
                    switch (DayTypeSpecifier)
                    {
                        case DayTypeSpecifier.WeekDay:
                            if (IsWeekend(date.DayOfWeek))
                            {
                                continue;
                            }
                            break;
                        case DayTypeSpecifier.WeekendDay:
                            if (!IsWeekend(date.DayOfWeek))
                            {
                                continue;
                            }
                            break;
                        default:
                            if (date.DayOfWeek != (DayOfWeek)DayTypeSpecifier)
                            {
                                continue;
                            }
                            break;
                    }

                    switch (RecurrencePatternSpecificer)
                    {
                        case RecurrencePatternSpecificer.First:
                            if (date.Day <= 7 && date.Month == Month)
                            {
                                dates.Add(date);
                            }
                            break;
                        case RecurrencePatternSpecificer.Second:
                            if (date.Day > 7 && date.Day <= 14 && date.Month == Month)
                            {
                                dates.Add(date);
                            }
                            break;
                        case RecurrencePatternSpecificer.Third:
                            if (date.Day > 14 && date.Day <= 21 && date.Month == Month)
                            {
                                dates.Add(date);
                            }
                            break;
                        case RecurrencePatternSpecificer.Fourth:
                            if (date.Day > 21 && date.Day <= 28 && date.Month == Month)
                            {
                                dates.Add(date);
                            }
                            break;
                        case RecurrencePatternSpecificer.Fifth:
                            if (date.Day > 28 && date.Month == Month)
                            {
                                dates.Add(date);
                            }
                            break;
                        case RecurrencePatternSpecificer.Last:
                            if (date.AddDays(7).Day <= 7 && date.Month == Month)
                            {
                                dates.Add(date);
                            }
                            break;
                        default:
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                    }
                }
            }

            return dates;
        }

        private IEnumerable<DateTime> MonthlyRecurrence()
        {
            var dates = new List<DateTime>();

            if (RecurrenceType == RecurrenceType.UseStartDate)
            {
                for (var date = StartDate; date <= EndDate; date = date.AddMonths(1))
                {
                    dates.Add(date);
                }
            }
            else
            {
                for (var date = StartDate; date <= EndDate; date = date.AddDays(1))
                {
                    switch (DayTypeSpecifier)
                    {
                        case DayTypeSpecifier.WeekDay:
                            if (IsWeekend(date.DayOfWeek))
                            {
                                continue;
                            }
                            break;
                        case DayTypeSpecifier.WeekendDay:
                            if (!IsWeekend(date.DayOfWeek))
                            {
                                continue;
                            }
                            break;
                        default:
                            if (date.DayOfWeek != (DayOfWeek)DayTypeSpecifier)
                            {
                                continue;
                            }
                            break;
                    }

                    switch (RecurrencePatternSpecificer)
                    {
                        case RecurrencePatternSpecificer.First:
                            if (date.Day <= 7)
                            {
                                dates.Add(date);
                            }
                            break;
                        case RecurrencePatternSpecificer.Second:
                            if (date.Day > 7 && date.Day <= 14)
                            {
                                dates.Add(date);
                            }
                            break;
                        case RecurrencePatternSpecificer.Third:
                            if (date.Day > 14 && date.Day <= 21)
                            {
                                dates.Add(date);
                            }
                            break;
                        case RecurrencePatternSpecificer.Fourth:
                            if (date.Day > 21 && date.Day <= 28)
                            {
                                dates.Add(date);
                            }
                            break;
                        case RecurrencePatternSpecificer.Fifth:
                            if (date.Day > 28)
                            {
                                dates.Add(date);
                            }
                            break;
                        case RecurrencePatternSpecificer.Last:
                            if (date.AddDays(7).Day <= 7)
                            {
                                dates.Add(date);
                            }
                            break;
                        default:
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                    }
                }
            }

            return dates;
        }

        private static bool IsWeekend(DayOfWeek dayOfWeek)
        {
            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
        }

        private IEnumerable<DateTime> WeeklyRecurrence()
        {
            var dates = new List<DateTime>();

            for (var date = StartDate; date <= EndDate; date = date.AddDays(1))
            {
                var dayOfWeek = (int)date.DayOfWeek;

                var startDateDayOfWeek = (int)StartDate.DayOfWeek;

                var offSet = dayOfWeek - startDateDayOfWeek;
                if (offSet < 0)
                {
                    offSet = offSet + 7;
                }

                if (!DailyRecurrencePattern[dayOfWeek])
                {
                    continue;
                }

                if (date.Subtract(StartDate).Days % (WeeklyRecurrencePattern * 7) == offSet)
                {
                    dates.Add(date);
                }
            }

            return dates;
        }

        private IEnumerable<DateTime> DailyRecurrence()
        {
            var dates = new List<DateTime>();

            for (var date = StartDate; date <= EndDate; date = date.AddDays(1))
            {
                var dayOfWeek = (int)date.DayOfWeek;
                if (DailyRecurrencePattern[dayOfWeek])
                {
                    dates.Add(date);
                }
            }

            return dates;
        }

        private IEnumerable<DateTime> NoRecurrence()
        {
            var dates = new List<DateTime>();

            for (var date = StartDate; date <= EndDate; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            return dates;
        }
    }
}