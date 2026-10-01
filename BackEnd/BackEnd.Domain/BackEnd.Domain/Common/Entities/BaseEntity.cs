using BackEnd.Domain.Common.Enums;

namespace BackEnd.Domain.Common.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }

    public DateTime CreateAt { get; protected set; }

    public DateTime? UpdateAt { get; protected set; }

    public RecordStatus RecordStatus { get; protected set; }
}