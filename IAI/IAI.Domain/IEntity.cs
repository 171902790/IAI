using System;

namespace IAI.DomainModel
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}