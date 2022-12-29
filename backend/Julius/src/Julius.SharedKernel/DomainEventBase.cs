using MediatR;

namespace Julius.SharedKernel;

public class DomainEventBase : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}

