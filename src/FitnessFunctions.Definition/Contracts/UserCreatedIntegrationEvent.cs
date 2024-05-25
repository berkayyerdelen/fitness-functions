using FitnessFunctions.SharedKernel.Messaging;

namespace FitnessFunctions.Definition.Contracts;

public sealed class UserCreatedIntegrationEvent :  IntegrationEvent
{
    public Guid UserId { get; set; }
}