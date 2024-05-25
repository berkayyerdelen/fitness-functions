namespace FitnessFunctions.SharedKernel.Messaging;

public class IntegrationCommand : IMessage
{
    public Guid MessageId { get; set; } = Guid.NewGuid();
}