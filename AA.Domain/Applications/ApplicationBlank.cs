using System;

namespace AA.Domain.Applications
{
    public class ApplicationBlank
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public String? Name { get; set; }

        public ApplicationBlank() { }

        public ApplicationBlank(Guid? id, Guid? userId, String? name)
        {
            Id = id;
            UserId = userId;
            Name = name;
        }
    }
}
