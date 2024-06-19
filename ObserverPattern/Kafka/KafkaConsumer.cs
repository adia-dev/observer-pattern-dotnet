namespace ObserverPattern.Kafka;

public class KafkaConsumer : ISubscriber
{
    private readonly Guid _id = Guid.NewGuid();
    private readonly string _topic;

    public KafkaConsumer(string topic) { _topic = topic; }

    public void update() {
        Console.WriteLine($"Message received on consumer {_id} for topic {_topic}");
    }
}
