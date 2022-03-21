using System;

namespace AA.Domain.Applications.Events
{
    public enum ApplicationEventType
    {
        EventOne = 1,
        EventTwo = 2,
        EventThree = 3,
        EventFour = 4
    }

    public static class ApplicationEventTypeExtensions
    {
        public static String GetDisplayName(this ApplicationEventType type)
        {
            switch(type)
            {
                case ApplicationEventType.EventOne: return "Событие 1";
                case ApplicationEventType.EventTwo: return "Событие 2";
                case ApplicationEventType.EventThree: return "Событие 3";
                case ApplicationEventType.EventFour: return "Событие 4";

                default:    throw new Exception("Точка недостижимости");
            }
        }
    }

}
