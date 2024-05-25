namespace FitnessFunctions.SharedKernel.Messaging;

public class IntegrationEvent: IMessage
{
    public Guid MessageId { get; set; } = Guid.NewGuid();
}