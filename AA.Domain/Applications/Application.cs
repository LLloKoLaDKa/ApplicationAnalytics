using System;

namespace AA.Domain.Applications
{
    public class Application
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public String Name { get; }
        public DateTime Date { get; }

        public String DateString => $"Создан: {Date.ToShortDateString()}";

        public Application(Guid id, Guid userId, String name, DateTime date)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Date = date;
        }
    }
}
