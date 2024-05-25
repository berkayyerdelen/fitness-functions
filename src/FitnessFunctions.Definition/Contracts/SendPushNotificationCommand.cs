using FitnessFunctions.SharedKernel.Messaging;

namespace FitnessFunctions.Definition.Contracts;

public sealed class SendPushNotificationCommand : IntegrationCommand
{
    public Guid UserId { get; set; }
}