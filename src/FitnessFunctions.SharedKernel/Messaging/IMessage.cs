namespace FitnessFunctions.SharedKernel.Messaging;

/// <summary>
/// marker class
/// </summary>
public interface IMessage
{
    public Guid MessageId { get; set; }
}