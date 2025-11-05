using System.Threading.Channels;

public sealed class InMemoryMessageQueue
{
    private readonly Channel<IDomainEvent> channel = Channel.CreateUnbounded<IDomainEvent>();

    public ChannelReader<IDomainEvent> Reader => channel.Reader;

    public ChannelWriter<IDomainEvent> Writer => channel.Writer;
}
